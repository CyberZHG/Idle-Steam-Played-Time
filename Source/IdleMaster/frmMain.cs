using IdleMaster.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IdleMaster
{
    public partial class frmMain : Form
    {
        public List<Game> AllGames { get; set; }
        private List<int> whiteList;
        private List<int> blackList;

        public bool IsCookieReady;
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
            int n = AllGames.Count;
            if (n == 0)
            {
                return;
            }
            int[] appIds = new int[n];
            double[] hours = new double[n];
            double[] sum = new double[n];
            for (int i = 0; i < n; ++i)
            {
                var game = AllGames.ElementAt(i);
                appIds[i] = game.AppId;
                if (blackList.Contains(appIds[i]))
                {
                    hours[i] = 0.0;
                }
                else
                {
                    hours[i] = game.HoursPlayed + 1.0;
                    if (whiteList.Contains(appIds[i]))
                    {
                        hours[i] *= 5;
                    }
                }
                if (i > 0)
                {
                    sum[i] += hours[i] + sum[i - 1];
                }
                else
                {
                    sum[i] = hours[i];
                }
            }
            Random random = new Random();
            for (int i = 0; i < Settings.Default.simulNum; ++i)
            {
                double r = random.NextDouble() * sum[n - 1];
                for (int j = 0; j < n; ++j)
                {
                    if ((j == 0 && r < sum[0]) || (j > 0 && sum[j - 1] < r && r < sum[j]))
                    {
                        var game = AllGames.ElementAt(j);
                        game.Idle();
                        ++game.SelectedCount;
                        for (int k = j; k < n; ++k)
                        {
                            sum[k] -= hours[j] + 1e-10;
                        }
                        break;
                    }
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
            if (string.IsNullOrWhiteSpace(Settings.Default.sessionid))
            {
                ResetClientStatus();
            }
            else
            {
                if (ReloadCount != 0)
                {
                    return;
                }
                if (AllGames.Count() > 0)
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
            dataGridGameState.Rows.Clear();
            AllGames = AllGames.OrderByDescending(b => b.HoursPlayed).ToList();
            double totalHour = 0.0;
            int totalSelected = 0;
            for (int i = 0; i < AllGames.Count; ++i)
            {
                var game = AllGames.ElementAt(i);
                totalHour += game.HoursPlayed;
                totalSelected += game.SelectedCount;
                dataGridGameState.Rows.Add(new object[] {
                    i + 1,
                    game.AppId,
                    game.Name,
                    game.HoursPlayed,
                    game.InIdle,
                    game.SelectedCount,
                    whiteList.Contains(game.AppId),
                    blackList.Contains(game.AppId) });
            }
            dataGridGameState.Rows.Insert(0, new object[] {
                    0,
                    0,
                    "Total",
                    totalHour,
                    false,
                    totalSelected,
                    false,
                    false });
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
            catch (Exception)
            {
            }
        }

        public void IdleComplete()
        {
        }


        public void LoadGamesAsync()
        {
            var gamesURL = "http://steamcommunity.com/profiles/" + SteamProfile.GetSteamId() + "/games/?tab=all";
            try
            {
                var response = CookieClient.GetHttp(gamesURL);
                if (string.IsNullOrEmpty(response))
                {
                    RetryCount++;
                    if (RetryCount == 18)
                    {
                        ResetClientStatus();
                        return;
                    }
                    throw new Exception("");
                }
                ProcessGamesOnPage(response);
            }
            catch (Exception)
            {
                ReloadCount = 1;
                tmrBadgeReload.Enabled = true;
                return;
            }
        }

        /// <summary>
        /// Processes all games
        /// </summary>
        private void ProcessGamesOnPage(string document)
        {
            var gamesJson = Regex.Match(document, @"var rgGames = ([^\n]*)").Groups[1].ToString();
            for (int i = gamesJson.Count() - 1; i >= 0; --i)
            {
                if (gamesJson[i] == ';')
                {
                    gamesJson = gamesJson.Remove(i);
                    break;
                }
            }
            var gameApps = JsonConvert.DeserializeObject<GameApp[]>(gamesJson);
            foreach (var gameApp in gameApps)
            {
                var gameInMemory = AllGames.FirstOrDefault(g => g.AppId == gameApp.AppId);
                if (gameInMemory != null)
                {
                    gameInMemory.UpdateStats(gameApp.HoursForever);
                }
                else
                {
                    AllGames.Add(new Game(gameApp.AppId, gameApp.Name, gameApp.HoursForever));
                }
            }
            RetryCount = 0;
            if (AllGames.Count() == 0)
            {
                IdleComplete();
            }
            UpdateIdleProcesses();
        }
        
        public frmMain()
        {
            InitializeComponent();
            AllGames = new List<Game>();
            whiteList = Settings.Default.whiteList.Split(',').Select(s => Int32.Parse(s)).ToList();
            blackList = Settings.Default.blackList.Split(',').Select(s => Int32.Parse(s)).ToList();
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
        }

        private void frmMain_FormClose(object sender, FormClosedEventArgs e)
        {
            StopIdle();
        }

        private void tmrCheckCookieData_Tick(object sender, EventArgs e)
        {
            var connected = !string.IsNullOrWhiteSpace(Settings.Default.sessionid) && !string.IsNullOrWhiteSpace(Settings.Default.steamLogin);
            
            picCookieStatus.Image = connected ? Resources.imgTrue : Resources.imgFalse;
            lnkSignIn.Visible = !connected;
            lnkResetCookies.Visible = connected;
            IsCookieReady = connected;
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
            tmrCheckCookieData.Interval = 500;

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
            if (!IsCookieReady)
                return;

            tmrReadyToGo.Enabled = false;

            // Call the loadBadges() function asynchronously
            LoadGamesAsync();

            StartIdle();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSettings();
            frm.ShowDialog();          
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
                notifyIcon1.Visible = true;
                Hide();
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

        private void dataGridGameState_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string appIdStr = dataGridGameState.Rows[e.RowIndex].Cells[ColAppId.Index].Value.ToString();
            if (appIdStr == "")
            {
                return;
            }
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridGameState.Rows[e.RowIndex].Cells[e.ColumnIndex];
            int appId = Int32.Parse(appIdStr);
            if (appId == 0)
            {
                return;
            }
            if (e.ColumnIndex == ColFavor.Index)
            {
                if ((bool)cell.Value)
                {
                    if (!whiteList.Contains(appId))
                    {
                        whiteList.Add(appId);
                    }
                }
                else
                {
                    whiteList.Remove(appId);
                }
                Settings.Default.whiteList = String.Join(",", whiteList.Select(i => i.ToString()).ToArray());
                Settings.Default.Save();
            }
            else if (e.ColumnIndex == ColNever.Index)
            {
                if ((bool)cell.Value)
                {
                    if (!blackList.Contains(appId))
                    {
                        blackList.Add(appId);
                    }
                }
                else
                {
                    blackList.Remove(appId);
                }
                Settings.Default.blackList = String.Join(",", blackList.Select(i => i.ToString()).ToArray());
                Settings.Default.Save();
            }
            else if (e.ColumnIndex == ColIdle.Index)
            {
                if ((bool)cell.Value)
                {
                    AllGames.Find(g => g.AppId == appId).Idle();
                }
                else
                {
                    AllGames.Find(g => g.AppId == appId).StopIdle();
                }
            }
        }

        private void dataGridGameState_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridGameState.IsCurrentCellDirty)
            {
                dataGridGameState.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}