using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.numericMaxHour = new System.Windows.Forms.NumericUpDown();
            this.labelMaxHour = new System.Windows.Forms.Label();
            this.numericSimulNum = new System.Windows.Forms.NumericUpDown();
            this.labelSimulNum = new System.Windows.Forms.Label();
            this.chkShowUsername = new System.Windows.Forms.CheckBox();
            this.chkMinToTray = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ttHints = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSimulNum)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeneral.Controls.Add(this.numericMaxHour);
            this.grpGeneral.Controls.Add(this.labelMaxHour);
            this.grpGeneral.Controls.Add(this.numericSimulNum);
            this.grpGeneral.Controls.Add(this.labelSimulNum);
            this.grpGeneral.Controls.Add(this.chkShowUsername);
            this.grpGeneral.Controls.Add(this.chkMinToTray);
            this.grpGeneral.Location = new System.Drawing.Point(13, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(345, 122);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // numericMaxHour
            // 
            this.numericMaxHour.Location = new System.Drawing.Point(143, 90);
            this.numericMaxHour.Maximum = new decimal(new int[] {
            876000,
            0,
            0,
            0});
            this.numericMaxHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxHour.Name = "numericMaxHour";
            this.numericMaxHour.Size = new System.Drawing.Size(190, 21);
            this.numericMaxHour.TabIndex = 8;
            this.numericMaxHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMaxHour.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // labelMaxHour
            // 
            this.labelMaxHour.AutoSize = true;
            this.labelMaxHour.Location = new System.Drawing.Point(78, 92);
            this.labelMaxHour.Name = "labelMaxHour";
            this.labelMaxHour.Size = new System.Drawing.Size(59, 12);
            this.labelMaxHour.TabIndex = 7;
            this.labelMaxHour.Text = "Max hour:";
            this.labelMaxHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericSimulNum
            // 
            this.numericSimulNum.Location = new System.Drawing.Point(143, 64);
            this.numericSimulNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericSimulNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSimulNum.Name = "numericSimulNum";
            this.numericSimulNum.Size = new System.Drawing.Size(190, 21);
            this.numericSimulNum.TabIndex = 6;
            this.numericSimulNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSimulNum.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // labelSimulNum
            // 
            this.labelSimulNum.AutoSize = true;
            this.labelSimulNum.Location = new System.Drawing.Point(6, 66);
            this.labelSimulNum.Name = "labelSimulNum";
            this.labelSimulNum.Size = new System.Drawing.Size(131, 12);
            this.labelSimulNum.TabIndex = 5;
            this.labelSimulNum.Text = "Simultaneous numbers:";
            this.labelSimulNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowUsername
            // 
            this.chkShowUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowUsername.Location = new System.Drawing.Point(8, 40);
            this.chkShowUsername.Name = "chkShowUsername";
            this.chkShowUsername.Size = new System.Drawing.Size(331, 18);
            this.chkShowUsername.TabIndex = 2;
            this.chkShowUsername.Text = "Show Steam username of signed on user";
            this.chkShowUsername.UseVisualStyleBackColor = true;
            // 
            // chkMinToTray
            // 
            this.chkMinToTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMinToTray.Location = new System.Drawing.Point(8, 18);
            this.chkMinToTray.Name = "chkMinToTray";
            this.chkMinToTray.Size = new System.Drawing.Size(331, 16);
            this.chkMinToTray.TabIndex = 0;
            this.chkMinToTray.Text = "Minimize Idle Master to system tray";
            this.chkMinToTray.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(202, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 21);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&Accept";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdvanced.Image = global::IdleMaster.Properties.Resources.imgLock;
            this.btnAdvanced.Location = new System.Drawing.Point(12, 147);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(25, 21);
            this.btnAdvanced.TabIndex = 4;
            this.ttHints.SetToolTip(this.btnAdvanced, "Display advanced authentication information");
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 179);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Idle Master Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSimulNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpGeneral;
        private CheckBox chkMinToTray;
        private Button btnCancel;
        private Button btnOK;
        private Button btnAdvanced;
        private ToolTip ttHints;
        private CheckBox chkShowUsername;
        private NumericUpDown numericSimulNum;
        private Label labelSimulNum;
        private NumericUpDown numericMaxHour;
        private Label labelMaxHour;
    }
}