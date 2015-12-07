using System;
using System.Diagnostics;
using System.IO;

namespace IdleMaster
{
    public class Game
    {
        private static string GAME_PATH = "games/";
        private static string IDLER_NAME = "idler.exe";
        private static string STEAM_DLL_NAME = "steam_api.dll";
        private static string STEAM_APPID_TXT_NAME = "steam_appid.txt";

        public int AppId { get; set; }
        public string Name { get; set; }
        public double HoursPlayed { get; set; }
        public int SelectedCount { get; set; }

        private Process idleProcess;

        public bool InIdle { get { return idleProcess != null && !idleProcess.HasExited; } }

        public Process Idle()
        {
            if (InIdle)
            {
                return idleProcess;
            }
            if (!Directory.Exists(GAME_PATH))
            {
                Directory.CreateDirectory(GAME_PATH);
            }
            string appPath = GAME_PATH + AppId.ToString() + "/";
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            string steamDllPath = appPath + STEAM_DLL_NAME;
            if (!File.Exists(steamDllPath))
            {
                File.Copy(STEAM_DLL_NAME, steamDllPath);
            }
            string steamAppIdTxtPath = appPath + STEAM_APPID_TXT_NAME;
            if (!File.Exists(steamAppIdTxtPath))
            {
                StreamWriter writer = new StreamWriter(steamAppIdTxtPath);
                writer.WriteLine(AppId);
                writer.Flush();
                writer.Close();
            }
            string idlerPath = appPath + IDLER_NAME;
            if (!File.Exists(idlerPath))
            {
                File.Copy(IDLER_NAME, idlerPath);
            }
            string processPath = Environment.CurrentDirectory + "/" + idlerPath;
            idleProcess = Process.Start(new ProcessStartInfo(processPath) { WindowStyle = ProcessWindowStyle.Hidden });
            return idleProcess;
        }

        public void StopIdle()
        {
            if (InIdle)
            {
                idleProcess.Kill();
            }
        }
        
        public void UpdateStats(double hours)
        {
            HoursPlayed = hours;
        }

        public override bool Equals(object obj)
        {
            var badge = obj as Game;
            return badge != null && Equals(AppId, badge.AppId);
        }

        public override int GetHashCode()
        {
            return AppId.GetHashCode();
        }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? AppId.ToString() : Name;
        }

        public Game(int id, string name, double hours) : this()
        {
            AppId = id;
            Name = name;
            UpdateStats(hours);
        }

        public Game()
        { }
    }
}
