﻿namespace youtube_dl_gui
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenu();
            this.cmTrayShow = new System.Windows.Forms.MenuItem();
            this.cmTrayClipboard = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadAudio = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadVideo = new System.Windows.Forms.MenuItem();
            this.cmTraySep = new System.Windows.Forms.MenuItem();
            this.cmTrayExit = new System.Windows.Forms.MenuItem();
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.tabDownloader = new System.Windows.Forms.TabPage();
            this.lblAudioQuality = new System.Windows.Forms.Label();
            this.lblAudioFormat = new System.Windows.Forms.Label();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.gbDownloadAs = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lblCustomArgs = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tabConvert = new System.Windows.Forms.TabPage();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblConvertAudioFormat = new System.Windows.Forms.Label();
            this.cbConvFormat = new System.Windows.Forms.ComboBox();
            this.cbConvQuality = new System.Windows.Forms.ComboBox();
            this.lblConvertAudioQuality = new System.Windows.Forms.Label();
            this.btnBrowseConvSaveFile = new System.Windows.Forms.Button();
            this.btnBrowseConvFile = new System.Windows.Forms.Button();
            this.txtConvFile = new System.Windows.Forms.TextBox();
            this.lblFileToConvert = new System.Windows.Forms.Label();
            this.txtConvSave = new System.Windows.Forms.TextBox();
            this.lblSaveAs = new System.Windows.Forms.Label();
            this.lblVideoURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.mFrmMain = new System.Windows.Forms.MainMenu(this.components);
            this.mFrmMainSettings = new System.Windows.Forms.MenuItem();
            this.mFrmMainHelp = new System.Windows.Forms.MenuItem();
            this.mFrmMainSupported = new System.Windows.Forms.MenuItem();
            this.mFrmMainSep = new System.Windows.Forms.MenuItem();
            this.mFrmMainAbout = new System.Windows.Forms.MenuItem();
            this.MainTabs.SuspendLayout();
            this.tabDownloader.SuspendLayout();
            this.gbDownloadAs.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // niTray
            // 
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "youtube-dl-gui";
            this.niTray.Visible = true;
            this.niTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseDoubleClick);
            // 
            // cmTray
            // 
            this.cmTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayShow,
            this.cmTrayClipboard,
            this.cmTraySep,
            this.cmTrayExit});
            // 
            // cmTrayShow
            // 
            this.cmTrayShow.Index = 0;
            this.cmTrayShow.Text = "Show";
            this.cmTrayShow.Click += new System.EventHandler(this.cmTrayShow_Click);
            // 
            // cmTrayClipboard
            // 
            this.cmTrayClipboard.Index = 1;
            this.cmTrayClipboard.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayDownloadAudio,
            this.cmTrayDownloadVideo});
            this.cmTrayClipboard.Text = "Download from Clipboard...";
            // 
            // cmTrayDownloadAudio
            // 
            this.cmTrayDownloadAudio.Index = 0;
            this.cmTrayDownloadAudio.Text = "Audio (Best)";
            this.cmTrayDownloadAudio.Click += new System.EventHandler(this.cmTrayDownloadAudio_Click);
            // 
            // cmTrayDownloadVideo
            // 
            this.cmTrayDownloadVideo.Index = 1;
            this.cmTrayDownloadVideo.Text = "Video (Best)";
            this.cmTrayDownloadVideo.Click += new System.EventHandler(this.cmTrayDownloadVideo_Click);
            // 
            // cmTraySep
            // 
            this.cmTraySep.Index = 2;
            this.cmTraySep.Text = "-";
            // 
            // cmTrayExit
            // 
            this.cmTrayExit.Index = 3;
            this.cmTrayExit.Text = "Exit";
            this.cmTrayExit.Click += new System.EventHandler(this.cmTrayExit_Click);
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.tabDownloader);
            this.MainTabs.Controls.Add(this.tabConvert);
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainTabs.Location = new System.Drawing.Point(0, 65);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(240, 233);
            this.MainTabs.TabIndex = 16;
            this.MainTabs.SelectedIndexChanged += new System.EventHandler(this.MainTabs_SelectedIndexChanged);
            // 
            // tabDownloader
            // 
            this.tabDownloader.Controls.Add(this.lblAudioQuality);
            this.tabDownloader.Controls.Add(this.lblAudioFormat);
            this.tabDownloader.Controls.Add(this.cbQuality);
            this.tabDownloader.Controls.Add(this.gbDownloadAs);
            this.tabDownloader.Controls.Add(this.cbFormat);
            this.tabDownloader.Controls.Add(this.lblCustomArgs);
            this.tabDownloader.Controls.Add(this.txtArgs);
            this.tabDownloader.Controls.Add(this.btnDownload);
            this.tabDownloader.Location = new System.Drawing.Point(4, 22);
            this.tabDownloader.Name = "tabDownloader";
            this.tabDownloader.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloader.Size = new System.Drawing.Size(232, 207);
            this.tabDownloader.TabIndex = 0;
            this.tabDownloader.Text = "Downloader";
            this.tabDownloader.UseVisualStyleBackColor = true;
            // 
            // lblAudioQuality
            // 
            this.lblAudioQuality.AutoSize = true;
            this.lblAudioQuality.Location = new System.Drawing.Point(59, 68);
            this.lblAudioQuality.Name = "lblAudioQuality";
            this.lblAudioQuality.Size = new System.Drawing.Size(39, 13);
            this.lblAudioQuality.TabIndex = 4;
            this.lblAudioQuality.Text = "Quality";
            // 
            // lblAudioFormat
            // 
            this.lblAudioFormat.AutoSize = true;
            this.lblAudioFormat.Location = new System.Drawing.Point(59, 95);
            this.lblAudioFormat.Name = "lblAudioFormat";
            this.lblAudioFormat.Size = new System.Drawing.Size(39, 13);
            this.lblAudioFormat.TabIndex = 13;
            this.lblAudioFormat.Text = "Format";
            // 
            // cbQuality
            // 
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "best",
            "-- VIDEO --",
            "1080",
            "720",
            "640",
            "480",
            "360",
            "240",
            "-- AUDIO --",
            "8K",
            "16K",
            "24K",
            "32K",
            "40K",
            "48K",
            "56K",
            "64K",
            "80K",
            "96K",
            "112K",
            "128K",
            "144K",
            "160K",
            "192K",
            "224K",
            "256K",
            "320K"});
            this.cbQuality.Location = new System.Drawing.Point(104, 65);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(66, 21);
            this.cbQuality.TabIndex = 3;
            this.cbQuality.SelectedIndexChanged += new System.EventHandler(this.cbQuality_SelectedIndexChanged);
            // 
            // gbDownloadAs
            // 
            this.gbDownloadAs.Controls.Add(this.rbCustom);
            this.gbDownloadAs.Controls.Add(this.rbAudio);
            this.gbDownloadAs.Controls.Add(this.rbVideo);
            this.gbDownloadAs.Location = new System.Drawing.Point(9, 9);
            this.gbDownloadAs.Name = "gbDownloadAs";
            this.gbDownloadAs.Size = new System.Drawing.Size(215, 39);
            this.gbDownloadAs.TabIndex = 2;
            this.gbDownloadAs.TabStop = false;
            this.gbDownloadAs.Text = "Download type";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(146, 15);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(60, 17);
            this.rbCustom.TabIndex = 2;
            this.rbCustom.Text = "Custom";
            this.rbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.AutoSize = true;
            this.rbAudio.Location = new System.Drawing.Point(77, 15);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(52, 17);
            this.rbAudio.TabIndex = 1;
            this.rbAudio.Text = "Audio";
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Checked = true;
            this.rbVideo.Location = new System.Drawing.Point(8, 15);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(52, 17);
            this.rbVideo.TabIndex = 0;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "Video";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // cbFormat
            // 
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "best",
            "-- VIDEO --",
            "avi",
            "flv",
            "mp4",
            "mvk",
            "webm",
            "-- AUDIO --",
            "aac",
            "flac",
            "m4a",
            "mp3",
            "opus",
            "vorbis",
            "wav"});
            this.cbFormat.Location = new System.Drawing.Point(104, 92);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(66, 21);
            this.cbFormat.TabIndex = 12;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // lblCustomArgs
            // 
            this.lblCustomArgs.AutoSize = true;
            this.lblCustomArgs.Location = new System.Drawing.Point(9, 125);
            this.lblCustomArgs.Name = "lblCustomArgs";
            this.lblCustomArgs.Size = new System.Drawing.Size(66, 13);
            this.lblCustomArgs.TabIndex = 5;
            this.lblCustomArgs.Text = "Custom Args";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(6, 143);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.ReadOnly = true;
            this.txtArgs.Size = new System.Drawing.Size(222, 20);
            this.txtArgs.TabIndex = 6;
            this.txtArgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(149, 176);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(76, 24);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.btnConvert);
            this.tabConvert.Controls.Add(this.lblConvertAudioFormat);
            this.tabConvert.Controls.Add(this.cbConvFormat);
            this.tabConvert.Controls.Add(this.cbConvQuality);
            this.tabConvert.Controls.Add(this.lblConvertAudioQuality);
            this.tabConvert.Controls.Add(this.btnBrowseConvSaveFile);
            this.tabConvert.Controls.Add(this.btnBrowseConvFile);
            this.tabConvert.Controls.Add(this.txtConvFile);
            this.tabConvert.Controls.Add(this.lblFileToConvert);
            this.tabConvert.Controls.Add(this.txtConvSave);
            this.tabConvert.Controls.Add(this.lblSaveAs);
            this.tabConvert.Location = new System.Drawing.Point(4, 22);
            this.tabConvert.Name = "tabConvert";
            this.tabConvert.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvert.Size = new System.Drawing.Size(232, 207);
            this.tabConvert.TabIndex = 1;
            this.tabConvert.Text = "Converter";
            this.tabConvert.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(149, 176);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(76, 24);
            this.btnConvert.TabIndex = 18;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblConvertAudioFormat
            // 
            this.lblConvertAudioFormat.AutoSize = true;
            this.lblConvertAudioFormat.Location = new System.Drawing.Point(60, 135);
            this.lblConvertAudioFormat.Name = "lblConvertAudioFormat";
            this.lblConvertAudioFormat.Size = new System.Drawing.Size(39, 13);
            this.lblConvertAudioFormat.TabIndex = 17;
            this.lblConvertAudioFormat.Text = "Format";
            // 
            // cbConvFormat
            // 
            this.cbConvFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvFormat.FormattingEnabled = true;
            this.cbConvFormat.Items.AddRange(new object[] {
            "best",
            "-- VIDEO --",
            "avi",
            "flv",
            "mp4",
            "mvk",
            "webm",
            "-- AUDIO --",
            "aac",
            "flac",
            "m4a",
            "mp3",
            "opus",
            "vorbis",
            "wav"});
            this.cbConvFormat.Location = new System.Drawing.Point(105, 132);
            this.cbConvFormat.Name = "cbConvFormat";
            this.cbConvFormat.Size = new System.Drawing.Size(66, 21);
            this.cbConvFormat.TabIndex = 16;
            this.cbConvFormat.SelectedIndexChanged += new System.EventHandler(this.cbConvFormat_SelectedIndexChanged);
            // 
            // cbConvQuality
            // 
            this.cbConvQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvQuality.FormattingEnabled = true;
            this.cbConvQuality.Items.AddRange(new object[] {
            "-- VIDEO --",
            "1080p",
            "720p",
            "480p",
            "320p",
            "240p",
            "144p",
            "-- AUDIO --",
            "8K",
            "16K",
            "24K",
            "32K",
            "40K",
            "48K",
            "56K",
            "64K",
            "80K",
            "96K",
            "112K",
            "128K",
            "144K",
            "160K",
            "192K",
            "224K",
            "256K",
            "320K"});
            this.cbConvQuality.Location = new System.Drawing.Point(105, 105);
            this.cbConvQuality.Name = "cbConvQuality";
            this.cbConvQuality.Size = new System.Drawing.Size(66, 21);
            this.cbConvQuality.TabIndex = 14;
            this.cbConvQuality.SelectedIndexChanged += new System.EventHandler(this.cbConvQuality_SelectedIndexChanged);
            // 
            // lblConvertAudioQuality
            // 
            this.lblConvertAudioQuality.AutoSize = true;
            this.lblConvertAudioQuality.Location = new System.Drawing.Point(60, 108);
            this.lblConvertAudioQuality.Name = "lblConvertAudioQuality";
            this.lblConvertAudioQuality.Size = new System.Drawing.Size(39, 13);
            this.lblConvertAudioQuality.TabIndex = 15;
            this.lblConvertAudioQuality.Text = "Quality";
            // 
            // btnBrowseConvSaveFile
            // 
            this.btnBrowseConvSaveFile.Enabled = false;
            this.btnBrowseConvSaveFile.Location = new System.Drawing.Point(195, 72);
            this.btnBrowseConvSaveFile.Name = "btnBrowseConvSaveFile";
            this.btnBrowseConvSaveFile.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseConvSaveFile.TabIndex = 6;
            this.btnBrowseConvSaveFile.Text = "...";
            this.btnBrowseConvSaveFile.UseVisualStyleBackColor = true;
            this.btnBrowseConvSaveFile.Click += new System.EventHandler(this.btnBrowseConvSaveFile_Click);
            // 
            // btnBrowseConvFile
            // 
            this.btnBrowseConvFile.Location = new System.Drawing.Point(195, 25);
            this.btnBrowseConvFile.Name = "btnBrowseConvFile";
            this.btnBrowseConvFile.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseConvFile.TabIndex = 5;
            this.btnBrowseConvFile.Text = "...";
            this.btnBrowseConvFile.UseVisualStyleBackColor = true;
            this.btnBrowseConvFile.Click += new System.EventHandler(this.btnBrowseConvFile_Click);
            // 
            // txtConvFile
            // 
            this.txtConvFile.Location = new System.Drawing.Point(8, 27);
            this.txtConvFile.Name = "txtConvFile";
            this.txtConvFile.ReadOnly = true;
            this.txtConvFile.Size = new System.Drawing.Size(181, 20);
            this.txtConvFile.TabIndex = 4;
            // 
            // lblFileToConvert
            // 
            this.lblFileToConvert.AutoSize = true;
            this.lblFileToConvert.Location = new System.Drawing.Point(7, 8);
            this.lblFileToConvert.Name = "lblFileToConvert";
            this.lblFileToConvert.Size = new System.Drawing.Size(77, 13);
            this.lblFileToConvert.TabIndex = 3;
            this.lblFileToConvert.Text = "File to convert:";
            // 
            // txtConvSave
            // 
            this.txtConvSave.Location = new System.Drawing.Point(8, 74);
            this.txtConvSave.Name = "txtConvSave";
            this.txtConvSave.ReadOnly = true;
            this.txtConvSave.Size = new System.Drawing.Size(181, 20);
            this.txtConvSave.TabIndex = 2;
            // 
            // lblSaveAs
            // 
            this.lblSaveAs.AutoSize = true;
            this.lblSaveAs.Location = new System.Drawing.Point(7, 55);
            this.lblSaveAs.Name = "lblSaveAs";
            this.lblSaveAs.Size = new System.Drawing.Size(46, 13);
            this.lblSaveAs.TabIndex = 1;
            this.lblSaveAs.Text = "Save as";
            // 
            // lblVideoURL
            // 
            this.lblVideoURL.AutoSize = true;
            this.lblVideoURL.Location = new System.Drawing.Point(4, 3);
            this.lblVideoURL.Name = "lblVideoURL";
            this.lblVideoURL.Size = new System.Drawing.Size(80, 13);
            this.lblVideoURL.TabIndex = 0;
            this.lblVideoURL.Text = "Download URL";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(10, 19);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(220, 20);
            this.txtURL.TabIndex = 8;
            this.txtURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtURL.MouseEnter += new System.EventHandler(this.txtURL_MouseEnter);
            // 
            // mFrmMain
            // 
            this.mFrmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mFrmMainSettings,
            this.mFrmMainHelp});
            // 
            // mFrmMainSettings
            // 
            this.mFrmMainSettings.Index = 0;
            this.mFrmMainSettings.Text = "Settings";
            this.mFrmMainSettings.Click += new System.EventHandler(this.mFrmMainSettings_Click);
            // 
            // mFrmMainHelp
            // 
            this.mFrmMainHelp.Index = 1;
            this.mFrmMainHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mFrmMainSupported,
            this.mFrmMainSep,
            this.mFrmMainAbout});
            this.mFrmMainHelp.Text = "Help";
            // 
            // mFrmMainSupported
            // 
            this.mFrmMainSupported.Index = 0;
            this.mFrmMainSupported.Text = "Supported Sites";
            this.mFrmMainSupported.Click += new System.EventHandler(this.mFrmMainSupported_Click);
            // 
            // mFrmMainSep
            // 
            this.mFrmMainSep.Index = 1;
            this.mFrmMainSep.Text = "-";
            // 
            // mFrmMainAbout
            // 
            this.mFrmMainAbout.Index = 2;
            this.mFrmMainAbout.Text = "About";
            this.mFrmMainAbout.Click += new System.EventHandler(this.mFrmMainAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 298);
            this.Controls.Add(this.lblVideoURL);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.txtURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(256, 336);
            this.Menu = this.mFrmMain;
            this.MinimumSize = new System.Drawing.Size(256, 336);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.MainTabs.ResumeLayout(false);
            this.tabDownloader.ResumeLayout(false);
            this.tabDownloader.PerformLayout();
            this.gbDownloadAs.ResumeLayout(false);
            this.gbDownloadAs.PerformLayout();
            this.tabConvert.ResumeLayout(false);
            this.tabConvert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenu cmTray;
        private System.Windows.Forms.MenuItem cmTrayShow;
        private System.Windows.Forms.MenuItem cmTrayClipboard;
        private System.Windows.Forms.MenuItem cmTrayDownloadAudio;
        private System.Windows.Forms.MenuItem cmTrayDownloadVideo;
        private System.Windows.Forms.MenuItem cmTraySep;
        private System.Windows.Forms.MenuItem cmTrayExit;
        internal System.Windows.Forms.TabControl MainTabs;
        internal System.Windows.Forms.TabPage tabDownloader;
        internal System.Windows.Forms.Label lblVideoURL;
        internal System.Windows.Forms.Label lblAudioFormat;
        internal System.Windows.Forms.GroupBox gbDownloadAs;
        internal System.Windows.Forms.RadioButton rbCustom;
        internal System.Windows.Forms.RadioButton rbAudio;
        internal System.Windows.Forms.RadioButton rbVideo;
        internal System.Windows.Forms.ComboBox cbFormat;
        internal System.Windows.Forms.ComboBox cbQuality;
        internal System.Windows.Forms.Label lblAudioQuality;
        internal System.Windows.Forms.Label lblCustomArgs;
        internal System.Windows.Forms.TextBox txtArgs;
        internal System.Windows.Forms.TextBox txtURL;
        internal System.Windows.Forms.Button btnDownload;
        internal System.Windows.Forms.TabPage tabConvert;
        internal System.Windows.Forms.Button btnConvert;
        internal System.Windows.Forms.Label lblConvertAudioFormat;
        internal System.Windows.Forms.ComboBox cbConvFormat;
        internal System.Windows.Forms.ComboBox cbConvQuality;
        internal System.Windows.Forms.Label lblConvertAudioQuality;
        internal System.Windows.Forms.Button btnBrowseConvSaveFile;
        internal System.Windows.Forms.Button btnBrowseConvFile;
        internal System.Windows.Forms.TextBox txtConvFile;
        internal System.Windows.Forms.Label lblFileToConvert;
        internal System.Windows.Forms.TextBox txtConvSave;
        internal System.Windows.Forms.Label lblSaveAs;
        private System.Windows.Forms.MainMenu mFrmMain;
        private System.Windows.Forms.MenuItem mFrmMainSettings;
        private System.Windows.Forms.MenuItem mFrmMainHelp;
        private System.Windows.Forms.MenuItem mFrmMainSupported;
        private System.Windows.Forms.MenuItem mFrmMainSep;
        private System.Windows.Forms.MenuItem mFrmMainAbout;
    }
}

