namespace youtube_dl_gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.lblVideoURL = new System.Windows.Forms.Label();
            this.lblAudioFormat = new System.Windows.Forms.Label();
            this.gbDownloadAs = new System.Windows.Forms.GroupBox();
            this.LinkHelp = new System.Windows.Forms.LinkLabel();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.lblAudioQuality = new System.Windows.Forms.Label();
            this.lblCustomArgs = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tabConvert = new System.Windows.Forms.TabPage();
            this.chkSaveToMaster = new System.Windows.Forms.CheckBox();
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
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.btnOptions = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.MainTabs.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.gbDownloadAs.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.tabDownload);
            this.MainTabs.Controls.Add(this.tabConvert);
            this.MainTabs.Controls.Add(this.tabAbout);
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(248, 270);
            this.MainTabs.TabIndex = 15;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.lblVideoURL);
            this.tabDownload.Controls.Add(this.lblAudioFormat);
            this.tabDownload.Controls.Add(this.gbDownloadAs);
            this.tabDownload.Controls.Add(this.cbFormat);
            this.tabDownload.Controls.Add(this.cbQuality);
            this.tabDownload.Controls.Add(this.lblAudioQuality);
            this.tabDownload.Controls.Add(this.lblCustomArgs);
            this.tabDownload.Controls.Add(this.txtArgs);
            this.tabDownload.Controls.Add(this.txtURL);
            this.tabDownload.Controls.Add(this.btnDownload);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(240, 244);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "Download";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // lblVideoURL
            // 
            this.lblVideoURL.AutoSize = true;
            this.lblVideoURL.Location = new System.Drawing.Point(8, 6);
            this.lblVideoURL.Name = "lblVideoURL";
            this.lblVideoURL.Size = new System.Drawing.Size(155, 13);
            this.lblVideoURL.TabIndex = 0;
            this.lblVideoURL.Text = "Video / Playlist / Channel URL:";
            // 
            // lblAudioFormat
            // 
            this.lblAudioFormat.AutoSize = true;
            this.lblAudioFormat.Location = new System.Drawing.Point(53, 133);
            this.lblAudioFormat.Name = "lblAudioFormat";
            this.lblAudioFormat.Size = new System.Drawing.Size(69, 13);
            this.lblAudioFormat.TabIndex = 13;
            this.lblAudioFormat.Text = "Audio Format";
            // 
            // gbDownloadAs
            // 
            this.gbDownloadAs.Controls.Add(this.LinkHelp);
            this.gbDownloadAs.Controls.Add(this.rbCustom);
            this.gbDownloadAs.Controls.Add(this.rbAudio);
            this.gbDownloadAs.Controls.Add(this.rbVideo);
            this.gbDownloadAs.Enabled = false;
            this.gbDownloadAs.Location = new System.Drawing.Point(7, 47);
            this.gbDownloadAs.Name = "gbDownloadAs";
            this.gbDownloadAs.Size = new System.Drawing.Size(226, 47);
            this.gbDownloadAs.TabIndex = 2;
            this.gbDownloadAs.TabStop = false;
            this.gbDownloadAs.Text = "Download as";
            // 
            // LinkHelp
            // 
            this.LinkHelp.AutoSize = true;
            this.LinkHelp.Location = new System.Drawing.Point(191, 21);
            this.LinkHelp.Name = "LinkHelp";
            this.LinkHelp.Size = new System.Drawing.Size(13, 13);
            this.LinkHelp.TabIndex = 3;
            this.LinkHelp.TabStop = true;
            this.LinkHelp.Text = "?";
            this.LinkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHelp_LinkClicked);
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(137, 19);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(59, 17);
            this.rbCustom.TabIndex = 2;
            this.rbCustom.Text = "Custom";
            this.rbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.AutoSize = true;
            this.rbAudio.Location = new System.Drawing.Point(80, 19);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(51, 17);
            this.rbAudio.TabIndex = 1;
            this.rbAudio.Text = "Audio";
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Checked = true;
            this.rbVideo.Location = new System.Drawing.Point(23, 19);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(51, 17);
            this.rbVideo.TabIndex = 0;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "Video";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // cbFormat
            // 
            this.cbFormat.Enabled = false;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "best",
            "aac",
            "m4a",
            "mp3",
            "opus",
            "vorbis",
            "wav"});
            this.cbFormat.Location = new System.Drawing.Point(128, 130);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(59, 21);
            this.cbFormat.TabIndex = 12;
            // 
            // cbQuality
            // 
            this.cbQuality.Enabled = false;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
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
            this.cbQuality.Location = new System.Drawing.Point(128, 103);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(59, 21);
            this.cbQuality.TabIndex = 3;
            // 
            // lblAudioQuality
            // 
            this.lblAudioQuality.AutoSize = true;
            this.lblAudioQuality.Location = new System.Drawing.Point(53, 106);
            this.lblAudioQuality.Name = "lblAudioQuality";
            this.lblAudioQuality.Size = new System.Drawing.Size(69, 13);
            this.lblAudioQuality.TabIndex = 4;
            this.lblAudioQuality.Text = "Audio Quality";
            // 
            // lblCustomArgs
            // 
            this.lblCustomArgs.AutoSize = true;
            this.lblCustomArgs.Location = new System.Drawing.Point(8, 165);
            this.lblCustomArgs.Name = "lblCustomArgs";
            this.lblCustomArgs.Size = new System.Drawing.Size(161, 13);
            this.lblCustomArgs.TabIndex = 5;
            this.lblCustomArgs.Text = "Custom Args:       (Uses FFmpeg)";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(8, 186);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.ReadOnly = true;
            this.txtArgs.Size = new System.Drawing.Size(226, 20);
            this.txtArgs.TabIndex = 6;
            this.txtArgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(8, 22);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(226, 20);
            this.txtURL.TabIndex = 8;
            this.txtURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            this.txtURL.MouseEnter += new System.EventHandler(this.txtURL_MouseEnter);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(6, 209);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(228, 30);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.chkSaveToMaster);
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
            this.tabConvert.Size = new System.Drawing.Size(240, 244);
            this.tabConvert.TabIndex = 1;
            this.tabConvert.Text = "Convert Audio";
            this.tabConvert.UseVisualStyleBackColor = true;
            // 
            // chkSaveToMaster
            // 
            this.chkSaveToMaster.AutoSize = true;
            this.chkSaveToMaster.Checked = true;
            this.chkSaveToMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveToMaster.Location = new System.Drawing.Point(39, 70);
            this.chkSaveToMaster.Name = "chkSaveToMaster";
            this.chkSaveToMaster.Size = new System.Drawing.Size(162, 17);
            this.chkSaveToMaster.TabIndex = 0;
            this.chkSaveToMaster.Text = "Save to same path as master";
            this.chkSaveToMaster.UseVisualStyleBackColor = true;
            this.chkSaveToMaster.CheckedChanged += new System.EventHandler(this.chkSaveToMaster_CheckedChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(83, 195);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 18;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblConvertAudioFormat
            // 
            this.lblConvertAudioFormat.AutoSize = true;
            this.lblConvertAudioFormat.Location = new System.Drawing.Point(53, 166);
            this.lblConvertAudioFormat.Name = "lblConvertAudioFormat";
            this.lblConvertAudioFormat.Size = new System.Drawing.Size(69, 13);
            this.lblConvertAudioFormat.TabIndex = 17;
            this.lblConvertAudioFormat.Text = "Audio Format";
            // 
            // cbConvFormat
            // 
            this.cbConvFormat.FormattingEnabled = true;
            this.cbConvFormat.Items.AddRange(new object[] {
            "best",
            "aac",
            "flac",
            "m4a",
            "mp3",
            "opus",
            "vorbis",
            "wav"});
            this.cbConvFormat.Location = new System.Drawing.Point(128, 163);
            this.cbConvFormat.Name = "cbConvFormat";
            this.cbConvFormat.Size = new System.Drawing.Size(59, 21);
            this.cbConvFormat.TabIndex = 16;
            this.cbConvFormat.Text = "mp3";
            // 
            // cbConvQuality
            // 
            this.cbConvQuality.FormattingEnabled = true;
            this.cbConvQuality.Items.AddRange(new object[] {
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
            this.cbConvQuality.Location = new System.Drawing.Point(128, 136);
            this.cbConvQuality.Name = "cbConvQuality";
            this.cbConvQuality.Size = new System.Drawing.Size(59, 21);
            this.cbConvQuality.TabIndex = 14;
            this.cbConvQuality.Text = "192K";
            // 
            // lblConvertAudioQuality
            // 
            this.lblConvertAudioQuality.AutoSize = true;
            this.lblConvertAudioQuality.Location = new System.Drawing.Point(53, 139);
            this.lblConvertAudioQuality.Name = "lblConvertAudioQuality";
            this.lblConvertAudioQuality.Size = new System.Drawing.Size(69, 13);
            this.lblConvertAudioQuality.TabIndex = 15;
            this.lblConvertAudioQuality.Text = "Audio Quality";
            // 
            // btnBrowseConvSaveFile
            // 
            this.btnBrowseConvSaveFile.Enabled = false;
            this.btnBrowseConvSaveFile.Location = new System.Drawing.Point(205, 104);
            this.btnBrowseConvSaveFile.Name = "btnBrowseConvSaveFile";
            this.btnBrowseConvSaveFile.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseConvSaveFile.TabIndex = 6;
            this.btnBrowseConvSaveFile.Text = "...";
            this.btnBrowseConvSaveFile.UseVisualStyleBackColor = true;
            this.btnBrowseConvSaveFile.Click += new System.EventHandler(this.btnBrowseConvSaveFile_Click);
            // 
            // btnBrowseConvFile
            // 
            this.btnBrowseConvFile.Location = new System.Drawing.Point(205, 44);
            this.btnBrowseConvFile.Name = "btnBrowseConvFile";
            this.btnBrowseConvFile.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseConvFile.TabIndex = 5;
            this.btnBrowseConvFile.Text = "...";
            this.btnBrowseConvFile.UseVisualStyleBackColor = true;
            this.btnBrowseConvFile.Click += new System.EventHandler(this.btnBrowseConvFile_Click);
            // 
            // txtConvFile
            // 
            this.txtConvFile.Location = new System.Drawing.Point(10, 46);
            this.txtConvFile.Name = "txtConvFile";
            this.txtConvFile.ReadOnly = true;
            this.txtConvFile.Size = new System.Drawing.Size(189, 20);
            this.txtConvFile.TabIndex = 4;
            this.txtConvFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFileToConvert
            // 
            this.lblFileToConvert.AutoSize = true;
            this.lblFileToConvert.Location = new System.Drawing.Point(7, 27);
            this.lblFileToConvert.Name = "lblFileToConvert";
            this.lblFileToConvert.Size = new System.Drawing.Size(77, 13);
            this.lblFileToConvert.TabIndex = 3;
            this.lblFileToConvert.Text = "File to convert:";
            // 
            // txtConvSave
            // 
            this.txtConvSave.Location = new System.Drawing.Point(10, 106);
            this.txtConvSave.Name = "txtConvSave";
            this.txtConvSave.ReadOnly = true;
            this.txtConvSave.Size = new System.Drawing.Size(189, 20);
            this.txtConvSave.TabIndex = 2;
            // 
            // lblSaveAs
            // 
            this.lblSaveAs.AutoSize = true;
            this.lblSaveAs.Location = new System.Drawing.Point(7, 87);
            this.lblSaveAs.Name = "lblSaveAs";
            this.lblSaveAs.Size = new System.Drawing.Size(46, 13);
            this.lblSaveAs.TabIndex = 1;
            this.lblSaveAs.Text = "Save as";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.btnOptions);
            this.tabAbout.Controls.Add(this.lblAbout);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(240, 244);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(86, 131);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(69, 23);
            this.btnOptions.TabIndex = 10;
            this.btnOptions.Text = "Settings";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.Location = new System.Drawing.Point(8, 90);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(224, 27);
            this.lblAbout.TabIndex = 0;
            this.lblAbout.Text = "This program made by Matty (ecaep42)\r\nYoutube-DL made by rg3\r\n";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 270);
            this.Controls.Add(this.MainTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(256, 300);
            this.MinimumSize = new System.Drawing.Size(256, 300);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainTabs.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.tabDownload.PerformLayout();
            this.gbDownloadAs.ResumeLayout(false);
            this.gbDownloadAs.PerformLayout();
            this.tabConvert.ResumeLayout(false);
            this.tabConvert.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl MainTabs;
        internal System.Windows.Forms.TabPage tabDownload;
        internal System.Windows.Forms.Label lblVideoURL;
        internal System.Windows.Forms.Label lblAudioFormat;
        internal System.Windows.Forms.GroupBox gbDownloadAs;
        internal System.Windows.Forms.LinkLabel LinkHelp;
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
        internal System.Windows.Forms.CheckBox chkSaveToMaster;
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
        internal System.Windows.Forms.TabPage tabAbout;
        internal System.Windows.Forms.Button btnOptions;
        internal System.Windows.Forms.Label lblAbout;
    }
}

