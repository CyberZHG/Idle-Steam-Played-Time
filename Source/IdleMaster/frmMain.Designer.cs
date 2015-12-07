using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblCookieStatus = new System.Windows.Forms.Label();
            this.tmrCheckCookieData = new System.Windows.Forms.Timer(this.components);
            this.lnkResetCookies = new System.Windows.Forms.LinkLabel();
            this.lnkSignIn = new System.Windows.Forms.LinkLabel();
            this.mnuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officialGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrReadyToGo = new System.Windows.Forms.Timer(this.components);
            this.ssFooter = new System.Windows.Forms.StatusStrip();
            this.lblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.picCookieStatus = new System.Windows.Forms.PictureBox();
            this.tmrStartNext = new System.Windows.Forms.Timer(this.components);
            this.tmrBadgeReload = new System.Windows.Forms.Timer(this.components);
            this.tmrCardDropCheck = new System.Windows.Forms.Timer(this.components);
            this.dataGridGameState = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAppId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFavor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColNever = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mnuTop.SuspendLayout();
            this.ssFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGameState)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCookieStatus
            // 
            this.lblCookieStatus.AutoSize = true;
            this.lblCookieStatus.Location = new System.Drawing.Point(31, 37);
            this.lblCookieStatus.Name = "lblCookieStatus";
            this.lblCookieStatus.Size = new System.Drawing.Size(227, 12);
            this.lblCookieStatus.TabIndex = 0;
            this.lblCookieStatus.Text = "Idle Master is not connected to Steam";
            // 
            // tmrCheckCookieData
            // 
            this.tmrCheckCookieData.Enabled = true;
            this.tmrCheckCookieData.Tick += new System.EventHandler(this.tmrCheckCookieData_Tick);
            // 
            // lnkResetCookies
            // 
            this.lnkResetCookies.AutoSize = true;
            this.lnkResetCookies.Location = new System.Drawing.Point(233, 37);
            this.lnkResetCookies.Name = "lnkResetCookies";
            this.lnkResetCookies.Size = new System.Drawing.Size(65, 12);
            this.lnkResetCookies.TabIndex = 4;
            this.lnkResetCookies.TabStop = true;
            this.lnkResetCookies.Text = "(Sign out)";
            this.lnkResetCookies.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetCookies_LinkClicked);
            // 
            // lnkSignIn
            // 
            this.lnkSignIn.AutoSize = true;
            this.lnkSignIn.Location = new System.Drawing.Point(243, 37);
            this.lnkSignIn.Name = "lnkSignIn";
            this.lnkSignIn.Size = new System.Drawing.Size(59, 12);
            this.lnkSignIn.TabIndex = 5;
            this.lnkSignIn.TabStop = true;
            this.lnkSignIn.Text = "(Sign in)";
            this.lnkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignIn_LinkClicked);
            // 
            // mnuTop
            // 
            this.mnuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuTop.Location = new System.Drawing.Point(0, 0);
            this.mnuTop.Name = "mnuTop";
            this.mnuTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuTop.Size = new System.Drawing.Size(733, 24);
            this.mnuTop.TabIndex = 19;
            this.mnuTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::IdleMaster.Properties.Resources.imgSettings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::IdleMaster.Properties.Resources.imgExit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.officialGroupToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // officialGroupToolStripMenuItem
            // 
            this.officialGroupToolStripMenuItem.Image = global::IdleMaster.Properties.Resources.imgGlobe;
            this.officialGroupToolStripMenuItem.Name = "officialGroupToolStripMenuItem";
            this.officialGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.officialGroupToolStripMenuItem.Text = "&Official Group";
            this.officialGroupToolStripMenuItem.Click += new System.EventHandler(this.officialGroupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(145, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::IdleMaster.Properties.Resources.imgInfo;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tmrReadyToGo
            // 
            this.tmrReadyToGo.Enabled = true;
            this.tmrReadyToGo.Tick += new System.EventHandler(this.tmrReadyToGo_Tick);
            // 
            // ssFooter
            // 
            this.ssFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTimer,
            this.toolStripStatusLabel1});
            this.ssFooter.Location = new System.Drawing.Point(0, 391);
            this.ssFooter.Name = "ssFooter";
            this.ssFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ssFooter.ShowItemToolTips = true;
            this.ssFooter.Size = new System.Drawing.Size(733, 22);
            this.ssFooter.SizingGrip = false;
            this.ssFooter.TabIndex = 20;
            this.ssFooter.Text = "statusStrip1";
            // 
            // lblTimer
            // 
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(34, 17);
            this.lblTimer.Text = "15:00";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel1.Text = "Next check";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Idle Master";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // picCookieStatus
            // 
            this.picCookieStatus.Location = new System.Drawing.Point(15, 36);
            this.picCookieStatus.Name = "picCookieStatus";
            this.picCookieStatus.Size = new System.Drawing.Size(15, 15);
            this.picCookieStatus.TabIndex = 8;
            this.picCookieStatus.TabStop = false;
            // 
            // tmrStartNext
            // 
            this.tmrStartNext.Tick += new System.EventHandler(this.tmrStartNext_Tick);
            // 
            // tmrBadgeReload
            // 
            this.tmrBadgeReload.Interval = 1000;
            this.tmrBadgeReload.Tick += new System.EventHandler(this.tmrBadgeReload_Tick);
            // 
            // tmrCardDropCheck
            // 
            this.tmrCardDropCheck.Enabled = true;
            this.tmrCardDropCheck.Interval = 1000;
            this.tmrCardDropCheck.Tick += new System.EventHandler(this.tmrCardDropCheck_Tick);
            // 
            // dataGridGameState
            // 
            this.dataGridGameState.AllowUserToAddRows = false;
            this.dataGridGameState.AllowUserToDeleteRows = false;
            this.dataGridGameState.AllowUserToOrderColumns = true;
            this.dataGridGameState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridGameState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGameState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColAppId,
            this.ColName,
            this.ColHours,
            this.ColIdle,
            this.IdleCount,
            this.ColFavor,
            this.ColNever});
            this.dataGridGameState.Location = new System.Drawing.Point(13, 56);
            this.dataGridGameState.Name = "dataGridGameState";
            this.dataGridGameState.RowHeadersVisible = false;
            this.dataGridGameState.RowTemplate.Height = 23;
            this.dataGridGameState.Size = new System.Drawing.Size(706, 332);
            this.dataGridGameState.TabIndex = 29;
            this.dataGridGameState.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridGameState_CellValueChanged);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColId.Width = 40;
            // 
            // ColAppId
            // 
            this.ColAppId.HeaderText = "App ID";
            this.ColAppId.Name = "ColAppId";
            this.ColAppId.ReadOnly = true;
            this.ColAppId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAppId.Width = 80;
            // 
            // ColName
            // 
            this.ColName.FillWeight = 200F;
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Width = 300;
            // 
            // ColHours
            // 
            this.ColHours.HeaderText = "Hours";
            this.ColHours.Name = "ColHours";
            this.ColHours.ReadOnly = true;
            this.ColHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColHours.Width = 80;
            // 
            // ColIdle
            // 
            this.ColIdle.HeaderText = "Idle";
            this.ColIdle.Name = "ColIdle";
            this.ColIdle.ReadOnly = true;
            this.ColIdle.Width = 40;
            // 
            // IdleCount
            // 
            this.IdleCount.HeaderText = "Count";
            this.IdleCount.Name = "IdleCount";
            this.IdleCount.ReadOnly = true;
            this.IdleCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdleCount.Width = 60;
            // 
            // ColFavor
            // 
            this.ColFavor.HeaderText = "Favor";
            this.ColFavor.Name = "ColFavor";
            this.ColFavor.Width = 40;
            // 
            // ColNever
            // 
            this.ColNever.HeaderText = "Never";
            this.ColNever.Name = "ColNever";
            this.ColNever.Width = 40;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(733, 413);
            this.Controls.Add(this.dataGridGameState);
            this.Controls.Add(this.picCookieStatus);
            this.Controls.Add(this.lnkSignIn);
            this.Controls.Add(this.lnkResetCookies);
            this.Controls.Add(this.lblCookieStatus);
            this.Controls.Add(this.mnuTop);
            this.Controls.Add(this.ssFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTop;
            this.Name = "frmMain";
            this.Text = "Idle Steam Played Time";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClose);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnuTop.ResumeLayout(false);
            this.mnuTop.PerformLayout();
            this.ssFooter.ResumeLayout(false);
            this.ssFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGameState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCookieStatus;
        private Timer tmrCheckCookieData;
        private LinkLabel lnkResetCookies;
        private LinkLabel lnkSignIn;
        private PictureBox picCookieStatus;
        private MenuStrip mnuTop;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Timer tmrReadyToGo;
        private StatusStrip ssFooter;
        private ToolStripStatusLabel lblTimer;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private NotifyIcon notifyIcon1;
        private Timer tmrStartNext;
        private ToolStripMenuItem officialGroupToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private Timer tmrBadgeReload;
        private Timer tmrCardDropCheck;
        private DataGridView dataGridGameState;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColAppId;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColHours;
        private DataGridViewCheckBoxColumn ColIdle;
        private DataGridViewTextBoxColumn IdleCount;
        private DataGridViewCheckBoxColumn ColFavor;
        private DataGridViewCheckBoxColumn ColNever;
    }
}

