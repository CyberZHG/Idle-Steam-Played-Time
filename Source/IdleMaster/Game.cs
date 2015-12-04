using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using IdleMaster.Properties;

namespace IdleMaster
{
    public class Game
    {
        public int AppId { get; set; }

        public string Name { get; set; }

        public string StringId
        {
            get { return AppId.ToString(); }
            set { AppId = string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value); }
        }
        
        public double HoursPlayed { get; set; }

        private Process idleProcess;

        public bool InIdle { get { return idleProcess != null && !idleProcess.HasExited; } }

        public Process Idle()
        {
            if (InIdle)
            {
                return idleProcess;
            }
            idleProcess = Process.Start(new ProcessStartInfo("steam-idle.exe", AppId.ToString()) { WindowStyle = ProcessWindowStyle.Hidden });
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
            return string.IsNullOrWhiteSpace(Name) ? StringId : Name;
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
