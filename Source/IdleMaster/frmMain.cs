using IdleMaster.Properties;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace IdleMaster
{
    public partial class frmMain : Form
    {
        public List<Game> AllGames { get; set; }

        public bool IsCookieReady;
        public bool IsSteamReady;
        public int TimeLeft = 3600;
        public int RetryCount = 0;
        public int ReloadCount = 0;
        
        private void CopyResource(string resourceName, string file)
        {
            using (var resource = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    return;
                }
                using (Stream output = File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }
        
        public void UpdateIdleProcesses()
        {
            StopIdle();
            foreach (var game in AllGames)
            {
                if (game.HoursPlayed < Settings.Default.maxHour && AllGames.Count(b => b.InIdle) < Settings.Default.simulNum)
                {
                    game.Idle();
                }
            }
            for (int i = AllGames.Count - 1; i >= 0; --i)
            {
                var game = AllGames.ElementAt(i);
                if (game.HoursPlayed < Settings.Default.maxHour && !game.InIdle)
                {
                    game.Idle();
                    break;
                }
            }
            RefreshGamesStateListView();
        }

        private void StartIdle()
        {
            // Kill all existing processes before starting any new ones
            // This prevents rogue processes from interfering with idling time and slowing card drops
            try 
            {
                String username = WindowsIdentity.GetCurrent().Name;
                foreach (var process in Process.GetProcessesByName("steam-idle"))
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ProcessID = " + process.Id);
                    ManagementObjectCollection processList = searcher.Get();

                    foreach (ManagementObject obj in processList)
                    {
                        string[] argList = new string[] { string.Empty, string.Empty };
                        int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                        if (returnVal == 0)
                        {
                            if (argList[1] + "\\" + argList[0] == username)
                            {
                                process.Kill();
                            }
                        }
                    }
                    
                }
            }
            catch (Exception)
            {

            }
            
            // Check if user is authenticated and if any badge left to idle
            // There should be check for IsCookieReady, but property is set in timer tick, so it could take some time to be set.
            if (string.IsNullOrWhiteSpace(Settings.Default.sessionid) || !IsSteamReady)
            {
                ResetClientStatus();
            }
            else
            {
                if (ReloadCount != 0)
                {
                    return;
                }
                var multi = AllGames.Where(b => b.HoursPlayed < Settings.Default.maxHour);
                if (multi.Count() > 0)
                {
                    StartMultipleIdle();
                }
                else
                {
                    IdleComplete();
                }
            }
        }
        
        public void StartMultipleIdle()
        {
            // Reset the timer
            TimeLeft = 3600;
            
            RefreshGamesStateListView();
        }

        private void RefreshGamesStateListView()
        {
            GamesState.Items.Clear();
            for (int i = 0; i < AllGames.Count; ++i)
            {
                var game = AllGames.ElementAt(i);
                var line = new ListViewItem((i + 1).ToString());
                line.SubItems.Add(game.AppId.ToString());
                line.SubItems.Add(game.Name);
                line.SubItems.Add(game.HoursPlayed.ToString());
                line.SubItems.Add(game.InIdle ? "Y" : "");
                GamesState.Items.Add(line);
            }
        }

        public void StopIdle()
        {
            try
            {
                // Kill the idling process
                foreach (var badge in AllGames.Where(b => b.InIdle))
                {
                    badge.StopIdle();
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "frmMain -> StopIdle");
            }
        }

        public void IdleComplete()
        {
        }


        public void LoadGamesAsync()
        {
            var profileLink = "http://steamcommunity.com/id/" + SteamProfile.GetSteamIdName() + "/games/?tab=all&xml=1";
            try
            {
                var webClient = new WebClient() { Encoding = Encoding.UTF8 };
                webClient.DownloadStringCompleted += (sender, e) =>
                {
                    var xml = new XmlDocument();
                    xml.LoadXml(e.Result);
                    ProcessGamesOnPage(xml);
                };
                webClient.DownloadStringAsync(new Uri(profileLink));
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Badge -> LoadBadgesAsync, for profile = " + Settings.Default.myProfileURL);
                ReloadCount = 1;
                tmrBadgeReload.Enabled = true;
                return;
            }
        }

        /// <summary>
        /// Processes all badges on page
        /// </summary>
        /// <param name="document">HTML document (1 page) from x</param>
        private void ProcessGamesOnPage(XmlDocument document)
        {
            foreach (XmlNode gameNode in document.SelectNodes("//game"))
            {
                var appid = Int32.Parse(gameNode.SelectSingleNode("./appID").InnerText);
                var name = gameNode.SelectSingleNode("./name").InnerText;
                var hours = 0.0;
                try
                {
                    hours = Double.Parse(gameNode.SelectSingleNode("./hoursOnRecord").InnerText);
                }
                catch (Exception)
                {
                }
                var badgeInMemory = AllGames.FirstOrDefault(b => b.AppId == appid);
                if (badgeInMemory != null)
                {
                    badgeInMemory.UpdateStats(hours);
                }
                else
                {
                    AllGames.Add(new Game(appid, name, hours));
                }
            }
            AllGames = AllGames.OrderBy(b => b.HoursPlayed).ToList();
            RetryCount = 0;
            if (AllGames.Where(b => b.HoursPlayed < Settings.Default.maxHour).Count() == 0)
            {
                IdleComplete();
            }
            UpdateIdleProcesses();
        }
        
        public frmMain()
        {
            InitializeComponent();
            AllGames = new List<Game>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Copy external references to the output directory.  This allows ClickOnce install.
            if (File.Exists(Environment.CurrentDirectory + "\\steam_api.dll") == false)
            {
                CopyResource("IdleMaster.Resources.steam_api.dll", Environment.CurrentDirectory + @"\steam_api.dll");
            }
            if (File.Exists(Environment.CurrentDirectory + "\\CSteamworks.dll") == false)
            {
                CopyResource("IdleMaster.Resources.CSteamworks.dll", Environment.CurrentDirectory + @"\CSteamworks.dll");
            }
            if (File.Exists(Environment.CurrentDirectory + "\\steam-idle.exe") == false)
            {
                CopyResource("IdleMaster.Resources.steam-idle.exe", Environment.CurrentDirectory + @"\steam-idle.exe");
            }

            // Update the settings, if needed.  When the application updates, settings will persist.
            if (Settings.Default.updateNeeded)
            {
                Settings.Default.Upgrade();
                Settings.Default.updateNeeded = false;
                Settings.Default.Save();
            }

            // Set the interface language from the settings
            if (Settings.Default.language != "")
            {
                string language_string = "en";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language_string);                
            }            
            
        }

        private void frmMain_FormClose(object sender, FormClosedEventArgs e)
        {
            StopIdle();
        }

        private void tmrCheckCookieData_Tick(object sender, EventArgs e)
        {
            var connected = !string.IsNullOrWhiteSpace(Settings.Default.sessionid) && !string.IsNullOrWhiteSpace(Settings.Default.steamLogin);

            lblCookieStatus.Text = connected ? localization.strings.idle_master_connected : localization.strings.idle_master_notconnected;
            lblCookieStatus.ForeColor = connected ? Color.Green : Color.Black;
            picCookieStatus.Image = connected ? Resources.imgTrue : Resources.imgFalse;
            lnkSignIn.Visible = !connected;
            lnkResetCookies.Visible = connected;
            IsCookieReady = connected;
        }

        private void tmrCheckSteam_Tick(object sender, EventArgs e)
        {
            var isSteamRunning = SteamAPI.IsSteamRunning() || Settings.Default.ignoreclient;
            lblSteamStatus.Text = isSteamRunning ? (Settings.Default.ignoreclient ? localization.strings.steam_ignored : localization.strings.steam_running) : localization.strings.steam_notrunning;
            lblSteamStatus.ForeColor = isSteamRunning ? Color.Green : Color.Black;
            picSteamStatus.Image = isSteamRunning ? Resources.imgTrue : Resources.imgFalse;
            tmrCheckSteam.Interval = isSteamRunning ? 5000 : 500;
            IsSteamReady = isSteamRunning;
        }

        private void lnkResetCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetClientStatus();
        }

        /// <summary>
        /// Performs reset to initial state
        /// </summary>
        private void ResetClientStatus()
        {
            // Clear the settings
            Settings.Default.sessionid = string.Empty;
            Settings.Default.steamLogin = string.Empty;
            Settings.Default.myProfileURL = string.Empty;
            Settings.Default.steamparental = string.Empty;
            Settings.Default.Save();

            // Stop the steam-idle process
            StopIdle();

            // Clear the badges list
            AllGames.Clear();
            
            // Set timer intervals
            tmrCheckSteam.Interval = 500;
            tmrCheckCookieData.Interval = 500;

            // Hide signed user name
            if (Settings.Default.showUsername)
            {
                lblSignedOnAs.Text = String.Empty;
                lblSignedOnAs.Visible = false;
            }

            // Set IsCookieReady to false
            IsCookieReady = false;

            // Re-enable tmrReadyToGo
            tmrReadyToGo.Enabled = true;
        }

        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmBrowser();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmrReadyToGo_Tick(object sender, EventArgs e)
        {
            if (!IsCookieReady || !IsSteamReady)
                return;

            // Update the form elements
            if (Settings.Default.showUsername)
            {
                lblSignedOnAs.Text = SteamProfile.GetSignedAs();
                lblSignedOnAs.Visible = true;
            }

            tmrReadyToGo.Enabled = false;

            // Call the loadBadges() function asynchronously
            LoadGamesAsync();

            StartIdle();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSettings();
            frm.ShowDialog();
            
            if (Settings.Default.showUsername && IsCookieReady)
            {
                lblSignedOnAs.Text = SteamProfile.GetSignedAs();
                lblSignedOnAs.Visible = Settings.Default.showUsername;
            }            
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            frm.ShowDialog();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Settings.Default.minToTray)
                {
                    notifyIcon1.Visible = true;
                    Hide();
                }
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void lblCurrentRemaining_Click(object sender, EventArgs e)
        {
            if (TimeLeft > 2)
            {
                TimeLeft = 2;
            }
        }

        private void tmrStartNext_Tick(object sender, EventArgs e)
        {
            tmrStartNext.Enabled = false;
            StartIdle();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangelog();
            frm.Show();
        }

        private void officialGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/groups/idlemastery");
        }

        private void tmrBadgeReload_Tick(object sender, EventArgs e)
        {
            ReloadCount = ReloadCount + 1;

            if (ReloadCount == 10)
            {
                tmrBadgeReload.Enabled = false;
                tmrReadyToGo.Enabled = true;
                ReloadCount = 0;
            }
        }

        private void tmrCardDropCheck_Tick(object sender, EventArgs e)
        {
            if (TimeLeft <= 0)
            {

                LoadGamesAsync();
                TimeLeft = 3600;
            }
            else
            {
                TimeLeft = TimeLeft - 1;
                lblTimer.Text = TimeSpan.FromSeconds(TimeLeft).ToString(@"mm\:ss");
            }
        }
    }
}