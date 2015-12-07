using IdleMaster.Properties;
using System;
using System.Windows.Forms;

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
            Settings.Default.Save();
            Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            numericSimulNum.Value = Settings.Default.simulNum;
        }
    }
}
