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
            this.lblSteamStatus = new System.Windows.Forms.Label();
            this.tmrCheckSteam = new System.Windows.Forms.Timer(this.components);
            this.lnkResetCookies = new System.Windows.Forms.LinkLabel();
            this.lnkSignIn = new System.Windows.Forms.LinkLabel();
            this.mnuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officialGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrReadyToGo = new System.Windows.Forms.Timer(this.components);
            this.ssFooter = new System.Windows.Forms.StatusStrip();
            this.lblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.picCookieStatus = new System.Windows.Forms.PictureBox();
            this.picSteamStatus = new System.Windows.Forms.PictureBox();
            this.tmrStartNext = new System.Windows.Forms.Timer(this.components);
            this.tmrBadgeReload = new System.Windows.Forms.Timer(this.components);
            this.lblSignedOnAs = new System.Windows.Forms.Label();
            this.GamesState = new System.Windows.Forms.ListView();
            this.GameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InIdle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrCardDropCheck = new System.Windows.Forms.Timer(this.components);
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuTop.SuspendLayout();
            this.ssFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSteamStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCookieStatus
            // 
            this.lblCookieStatus.AutoSize = true;
            this.lblCookieStatus.Location = new System.Drawing.Point(31, 54);
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
            // lblSteamStatus
            // 
            this.lblSteamStatus.AutoSize = true;
            this.lblSteamStatus.Location = new System.Drawing.Point(30, 33);
            this.lblSteamStatus.Name = "lblSteamStatus";
            this.lblSteamStatus.Size = new System.Drawing.Size(125, 12);
            this.lblSteamStatus.TabIndex = 3;
            this.lblSteamStatus.Text = "Steam is not running";
            // 
            // tmrCheckSteam
            // 
            this.tmrCheckSteam.Enabled = true;
            this.tmrCheckSteam.Interval = 500;
            this.tmrCheckSteam.Tick += new System.EventHandler(this.tmrCheckSteam_Tick);
            // 
            // lnkResetCookies
            // 
            this.lnkResetCookies.AutoSize = true;
            this.lnkResetCookies.Location = new System.Drawing.Point(233, 54);
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
            this.lnkSignIn.Location = new System.Drawing.Point(243, 54);
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
            this.mnuTop.Size = new System.Drawing.Size(394, 24);
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
            this.changelogToolStripMenuItem,
            this.officialGroupToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Image = global::IdleMaster.Properties.Resources.imgDocument;
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.changelogToolStripMenuItem.Text = "&Release Notes";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
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
            this.ssFooter.Size = new System.Drawing.Size(394, 22);
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
            this.picCookieStatus.Location = new System.Drawing.Point(15, 53);
            this.picCookieStatus.Name = "picCookieStatus";
            this.picCookieStatus.Size = new System.Drawing.Size(15, 15);
            this.picCookieStatus.TabIndex = 8;
            this.picCookieStatus.TabStop = false;
            // 
            // picSteamStatus
            // 
            this.picSteamStatus.Location = new System.Drawing.Point(15, 31);
            this.picSteamStatus.Name = "picSteamStatus";
            this.picSteamStatus.Size = new System.Drawing.Size(15, 15);
            this.picSteamStatus.TabIndex = 7;
            this.picSteamStatus.TabStop = false;
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
            // lblSignedOnAs
            // 
            this.lblSignedOnAs.AutoSize = true;
            this.lblSignedOnAs.Location = new System.Drawing.Point(30, 66);
            this.lblSignedOnAs.Name = "lblSignedOnAs";
            this.lblSignedOnAs.Size = new System.Drawing.Size(77, 12);
            this.lblSignedOnAs.TabIndex = 27;
            this.lblSignedOnAs.Text = "Signed in as";
            this.lblSignedOnAs.Visible = false;
            // 
            // GamesState
            // 
            this.GamesState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamesState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.AppId,
            this.GameName,
            this.Hours,
            this.InIdle});
            this.GamesState.Location = new System.Drawing.Point(15, 80);
            this.GamesState.Margin = new System.Windows.Forms.Padding(2);
            this.GamesState.Name = "GamesState";
            this.GamesState.Size = new System.Drawing.Size(365, 309);
            this.GamesState.TabIndex = 28;
            this.GamesState.UseCompatibleStateImageBehavior = false;
            this.GamesState.View = System.Windows.Forms.View.Details;
            // 
            // GameName
            // 
            this.GameName.Tag = "";
            this.GameName.Text = "Name";
            this.GameName.Width = 196;
            // 
            // Hours
            // 
            this.Hours.Text = "Hours";
            this.Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Hours.Width = 44;
            // 
            // InIdle
            // 
            this.InIdle.Text = "In";
            this.InIdle.Width = 31;
            // 
            // tmrCardDropCheck
            // 
            this.tmrCardDropCheck.Enabled = true;
            this.tmrCardDropCheck.Interval = 1000;
            this.tmrCardDropCheck.Tick += new System.EventHandler(this.tmrCardDropCheck_Tick);
            // 
            // Id
            // 
            this.Id.Text = "ID";
            this.Id.Width = 26;
            // 
            // AppId
            // 
            this.AppId.Text = "App ID";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 413);
            this.Controls.Add(this.GamesState);
            this.Controls.Add(this.lblSignedOnAs);
            this.Controls.Add(this.picCookieStatus);
            this.Controls.Add(this.picSteamStatus);
            this.Controls.Add(this.lnkSignIn);
            this.Controls.Add(this.lnkResetCookies);
            this.Controls.Add(this.lblSteamStatus);
            this.Controls.Add(this.lblCookieStatus);
            this.Controls.Add(this.mnuTop);
            this.Controls.Add(this.ssFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTop;
            this.Name = "frmMain";
            this.Text = "Idle Master 2400";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClose);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnuTop.ResumeLayout(false);
            this.mnuTop.PerformLayout();
            this.ssFooter.ResumeLayout(false);
            this.ssFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSteamStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCookieStatus;
        private Timer tmrCheckCookieData;
        private Label lblSteamStatus;
        private Timer tmrCheckSteam;
        private LinkLabel lnkResetCookies;
        private LinkLabel lnkSignIn;
        private PictureBox picSteamStatus;
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
        private ToolStripMenuItem changelogToolStripMenuItem;
        private ToolStripMenuItem officialGroupToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private Timer tmrBadgeReload;
        private Label lblSignedOnAs;
    private ListView GamesState;
    private ColumnHeader GameName;
    private ColumnHeader Hours;
        private Timer tmrCardDropCheck;
        private ColumnHeader InIdle;
        private ColumnHeader Id;
        private ColumnHeader AppId;
    }
}

