namespace youtube_dl_gui
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnRedownload = new System.Windows.Forms.Button();
            this.btnBrws = new System.Windows.Forms.Button();
            this.txtDownloadLocation = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.numUpdateDays = new System.Windows.Forms.NumericUpDown();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDeleteExecutable = new System.Windows.Forms.CheckBox();
            this.chkAutoClearURL = new System.Windows.Forms.CheckBox();
            this.chkHoverURL = new System.Windows.Forms.CheckBox();
            this.chkSaveArgs = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttHelp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRedownload
            // 
            this.btnRedownload.Location = new System.Drawing.Point(64, 174);
            this.btnRedownload.Name = "btnRedownload";
            this.btnRedownload.Size = new System.Drawing.Size(186, 24);
            this.btnRedownload.TabIndex = 32;
            this.btnRedownload.Text = "Redownload youtube-dl application";
            this.ttHelp.SetToolTip(this.btnRedownload, "Redownload youtube-dl.exe if it seems to not work.");
            this.btnRedownload.UseVisualStyleBackColor = true;
            this.btnRedownload.Click += new System.EventHandler(this.btnRedownload_Click);
            // 
            // btnBrws
            // 
            this.btnBrws.Location = new System.Drawing.Point(274, 25);
            this.btnBrws.Name = "btnBrws";
            this.btnBrws.Size = new System.Drawing.Size(25, 20);
            this.btnBrws.TabIndex = 31;
            this.btnBrws.Text = "...";
            this.ttHelp.SetToolTip(this.btnBrws, "Browse for a new download path");
            this.btnBrws.UseVisualStyleBackColor = true;
            this.btnBrws.Click += new System.EventHandler(this.btnBrws_Click);
            // 
            // txtDownloadLocation
            // 
            this.txtDownloadLocation.Location = new System.Drawing.Point(27, 25);
            this.txtDownloadLocation.Name = "txtDownloadLocation";
            this.txtDownloadLocation.ReadOnly = true;
            this.txtDownloadLocation.Size = new System.Drawing.Size(241, 20);
            this.txtDownloadLocation.TabIndex = 30;
            this.ttHelp.SetToolTip(this.txtDownloadLocation, "The location where videos will get downloaded");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Download path";
            // 
            // numUpdateDays
            // 
            this.numUpdateDays.Enabled = false;
            this.numUpdateDays.Location = new System.Drawing.Point(177, 124);
            this.numUpdateDays.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpdateDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdateDays.Name = "numUpdateDays";
            this.numUpdateDays.Size = new System.Drawing.Size(49, 20);
            this.numUpdateDays.TabIndex = 28;
            this.numUpdateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttHelp.SetToolTip(this.numUpdateDays, "Amount of days to wait.");
            this.numUpdateDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Enabled = false;
            this.chkUpdate.Location = new System.Drawing.Point(18, 125);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(249, 17);
            this.chkUpdate.TabIndex = 27;
            this.chkUpdate.Text = "Update youtube-dl.exe every   xxxxxxx     day(s)";
            this.ttHelp.SetToolTip(this.chkUpdate, "After X amount of days, download a fresh version of youtube-dl.");
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // chkDeleteExecutable
            // 
            this.chkDeleteExecutable.AutoSize = true;
            this.chkDeleteExecutable.Location = new System.Drawing.Point(18, 102);
            this.chkDeleteExecutable.Name = "chkDeleteExecutable";
            this.chkDeleteExecutable.Size = new System.Drawing.Size(257, 17);
            this.chkDeleteExecutable.TabIndex = 26;
            this.chkDeleteExecutable.Text = "Automatically delete youtube-dl.exe when closing";
            this.ttHelp.SetToolTip(this.chkDeleteExecutable, "Deletes youtube-dl.exe when exiting.");
            this.chkDeleteExecutable.UseVisualStyleBackColor = true;
            this.chkDeleteExecutable.CheckedChanged += new System.EventHandler(this.chkDeleteExecutable_CheckedChanged);
            // 
            // chkAutoClearURL
            // 
            this.chkAutoClearURL.AutoSize = true;
            this.chkAutoClearURL.Checked = true;
            this.chkAutoClearURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoClearURL.Location = new System.Drawing.Point(18, 79);
            this.chkAutoClearURL.Name = "chkAutoClearURL";
            this.chkAutoClearURL.Size = new System.Drawing.Size(215, 17);
            this.chkAutoClearURL.TabIndex = 25;
            this.chkAutoClearURL.Text = "Auto-Clear URL when starting download";
            this.ttHelp.SetToolTip(this.chkAutoClearURL, "Automatically clear the Download URL text box and clipboard when starting the dow" +
        "nload.");
            this.chkAutoClearURL.UseVisualStyleBackColor = true;
            this.chkAutoClearURL.CheckedChanged += new System.EventHandler(this.chkAutoClearURL_CheckedChanged);
            // 
            // chkHoverURL
            // 
            this.chkHoverURL.AutoSize = true;
            this.chkHoverURL.Checked = true;
            this.chkHoverURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoverURL.Location = new System.Drawing.Point(18, 56);
            this.chkHoverURL.Name = "chkHoverURL";
            this.chkHoverURL.Size = new System.Drawing.Size(248, 17);
            this.chkHoverURL.TabIndex = 24;
            this.chkHoverURL.Text = "Hover over URL textbox to paste clipboard text";
            this.chkHoverURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttHelp.SetToolTip(this.chkHoverURL, "When hovering over the Download URL, automatically paste the text  in the clipboa" +
        "rd.");
            this.chkHoverURL.UseVisualStyleBackColor = true;
            this.chkHoverURL.CheckedChanged += new System.EventHandler(this.chkHoverURL_CheckedChanged);
            // 
            // chkSaveArgs
            // 
            this.chkSaveArgs.AutoSize = true;
            this.chkSaveArgs.Checked = true;
            this.chkSaveArgs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveArgs.Location = new System.Drawing.Point(18, 148);
            this.chkSaveArgs.Name = "chkSaveArgs";
            this.chkSaveArgs.Size = new System.Drawing.Size(270, 17);
            this.chkSaveArgs.TabIndex = 33;
            this.chkSaveArgs.Text = "Remember custom arguments and save to ./args.txt";
            this.ttHelp.SetToolTip(this.chkSaveArgs, "Save the arguments the user creates when downloading with a custom preset.\r\n\r\n./a" +
        "rgs.txt = the args.txt file within youtube-dl-gui\'s directory.");
            this.chkSaveArgs.UseVisualStyleBackColor = true;
            this.chkSaveArgs.CheckedChanged += new System.EventHandler(this.chkSaveArgs_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(228, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ttHelp
            // 
            this.ttHelp.AutoPopDelay = 30000;
            this.ttHelp.InitialDelay = 150;
            this.ttHelp.ReshowDelay = 100;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(314, 242);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkSaveArgs);
            this.Controls.Add(this.btnRedownload);
            this.Controls.Add(this.btnBrws);
            this.Controls.Add(this.txtDownloadLocation);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.numUpdateDays);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkDeleteExecutable);
            this.Controls.Add(this.chkAutoClearURL);
            this.Controls.Add(this.chkHoverURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 280);
            this.MinimumSize = new System.Drawing.Size(330, 280);
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.frmSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedownload;
        internal System.Windows.Forms.Button btnBrws;
        internal System.Windows.Forms.TextBox txtDownloadLocation;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NumericUpDown numUpdateDays;
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.CheckBox chkDeleteExecutable;
        internal System.Windows.Forms.CheckBox chkAutoClearURL;
        internal System.Windows.Forms.CheckBox chkHoverURL;
        private System.Windows.Forms.CheckBox chkSaveArgs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip ttHelp;
    }
}