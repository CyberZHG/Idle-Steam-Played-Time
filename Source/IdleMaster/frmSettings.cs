using System;
using System.Windows.Forms;
using IdleMaster.Properties;
using System.Threading;
using System.Text.RegularExpressions;

namespace IdleMaster
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.simulNum = (int)numericSimulNum.Value;
            Settings.Default.maxHour = (int)numericMaxHour.Value;

            Settings.Default.minToTray = chkMinToTray.Checked;
            Settings.Default.showUsername = chkShowUsername.Checked;
            Settings.Default.Save();
            Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (Settings.Default.minToTray)
            {
                chkMinToTray.Checked = true;
            }

            if (Settings.Default.showUsername)
            {
                chkShowUsername.Checked = true;
            }

            numericSimulNum.Value = Settings.Default.simulNum;
            numericMaxHour.Value = Settings.Default.maxHour;
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            var frm = new frmSettingsAdvanced();
            frm.ShowDialog();
        }
    }
}
