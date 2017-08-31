namespace youtube_dl_gui.Forms
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
            this.btnBrws = new System.Windows.Forms.Button();
            this.txtDownloadLocation = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.numUpdateDays = new System.Windows.Forms.NumericUpDown();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDeleteExecutable = new System.Windows.Forms.CheckBox();
            this.chkHoverURL = new System.Windows.Forms.CheckBox();
            this.ttOptions = new System.Windows.Forms.ToolTip(this.components);
            this.chkAutoClearURL = new System.Windows.Forms.CheckBox();
            this.btnRedownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrws
            // 
            this.btnBrws.Location = new System.Drawing.Point(251, 119);
            this.btnBrws.Name = "btnBrws";
            this.btnBrws.Size = new System.Drawing.Size(29, 23);
            this.btnBrws.TabIndex = 14;
            this.btnBrws.Text = "...";
            this.ttOptions.SetToolTip(this.btnBrws, "Customize the location of which videos will be downloaded.\r\n\r\nThe default locatio" +
        "n is the User\'s Downloads folder.");
            this.btnBrws.UseVisualStyleBackColor = true;
            this.btnBrws.Click += new System.EventHandler(this.btnBrws_Click);
            // 
            // txtDownloadLocation
            // 
            this.txtDownloadLocation.Location = new System.Drawing.Point(12, 121);
            this.txtDownloadLocation.Name = "txtDownloadLocation";
            this.txtDownloadLocation.ReadOnly = true;
            this.txtDownloadLocation.Size = new System.Drawing.Size(233, 20);
            this.txtDownloadLocation.TabIndex = 13;
            this.ttOptions.SetToolTip(this.txtDownloadLocation, "Customize the location of which videos will be downloaded.\r\n\r\nThe default locatio" +
        "n is the User\'s Downloads folder.");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 103);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(133, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Videos are downloaded to:";
            this.ttOptions.SetToolTip(this.Label1, "Customize the location of which videos will be downloaded.\r\n\r\nThe default locatio" +
        "n is the User\'s Downloads folder.");
            // 
            // numUpdateDays
            // 
            this.numUpdateDays.Enabled = false;
            this.numUpdateDays.Location = new System.Drawing.Point(172, 77);
            this.numUpdateDays.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpdateDays.Name = "numUpdateDays";
            this.numUpdateDays.Size = new System.Drawing.Size(49, 20);
            this.numUpdateDays.TabIndex = 11;
            this.numUpdateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttOptions.SetToolTip(this.numUpdateDays, "The amount of days in between updates.");
            this.numUpdateDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdateDays.ValueChanged += new System.EventHandler(this.numUpdateDays_ValueChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Enabled = false;
            this.chkUpdate.Location = new System.Drawing.Point(12, 78);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(251, 17);
            this.chkUpdate.TabIndex = 10;
            this.chkUpdate.Text = "Update youtube-dl.exe every   xxxxxxx      day(s)";
            this.ttOptions.SetToolTip(this.chkUpdate, "Updates the youtube-dl.exe file every X days.\r\n\r\nThis may wear out SSDs, so it\'s " +
        "recommended to keep this disabled.");
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // chkDeleteExecutable
            // 
            this.chkDeleteExecutable.AutoSize = true;
            this.chkDeleteExecutable.Location = new System.Drawing.Point(12, 55);
            this.chkDeleteExecutable.Name = "chkDeleteExecutable";
            this.chkDeleteExecutable.Size = new System.Drawing.Size(259, 17);
            this.chkDeleteExecutable.TabIndex = 9;
            this.chkDeleteExecutable.Text = "Automatically delete youtube-dl.exe during closing";
            this.ttOptions.SetToolTip(this.chkDeleteExecutable, "When the program closes, the youtube-dl.exe that was created will be deleted.\r\n\r\n" +
        "This may wear out SSDs, so it\'s recommended to keep this disabled.");
            this.chkDeleteExecutable.UseVisualStyleBackColor = true;
            this.chkDeleteExecutable.CheckedChanged += new System.EventHandler(this.chkDeleteExecutable_CheckedChanged);
            // 
            // chkHoverURL
            // 
            this.chkHoverURL.AutoSize = true;
            this.chkHoverURL.Checked = true;
            this.chkHoverURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoverURL.Location = new System.Drawing.Point(12, 9);
            this.chkHoverURL.Name = "chkHoverURL";
            this.chkHoverURL.Size = new System.Drawing.Size(247, 17);
            this.chkHoverURL.TabIndex = 8;
            this.chkHoverURL.Text = "Hover over URL textbox to paste clipboard text";
            this.ttOptions.SetToolTip(this.chkHoverURL, resources.GetString("chkHoverURL.ToolTip"));
            this.chkHoverURL.UseVisualStyleBackColor = true;
            this.chkHoverURL.CheckedChanged += new System.EventHandler(this.chkHoverURL_CheckedChanged);
            // 
            // ttOptions
            // 
            this.ttOptions.AutomaticDelay = 250;
            this.ttOptions.AutoPopDelay = 10000;
            this.ttOptions.InitialDelay = 250;
            this.ttOptions.ReshowDelay = 50;
            // 
            // chkAutoClearURL
            // 
            this.chkAutoClearURL.AutoSize = true;
            this.chkAutoClearURL.Checked = true;
            this.chkAutoClearURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoClearURL.Location = new System.Drawing.Point(12, 32);
            this.chkAutoClearURL.Name = "chkAutoClearURL";
            this.chkAutoClearURL.Size = new System.Drawing.Size(214, 17);
            this.chkAutoClearURL.TabIndex = 15;
            this.chkAutoClearURL.Text = "Auto-Clear URL when starting download";
            this.ttOptions.SetToolTip(this.chkAutoClearURL, "Clears the URL Text Box when a download initializes.");
            this.chkAutoClearURL.UseVisualStyleBackColor = true;
            this.chkAutoClearURL.CheckedChanged += new System.EventHandler(this.chkAutoClearURL_CheckedChanged);
            // 
            // btnRedownload
            // 
            this.btnRedownload.Location = new System.Drawing.Point(89, 145);
            this.btnRedownload.Name = "btnRedownload";
            this.btnRedownload.Size = new System.Drawing.Size(114, 24);
            this.btnRedownload.TabIndex = 16;
            this.btnRedownload.Text = "Redownload Binary";
            this.btnRedownload.UseVisualStyleBackColor = true;
            this.btnRedownload.Click += new System.EventHandler(this.btnRedownload_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 170);
            this.Controls.Add(this.btnRedownload);
            this.Controls.Add(this.btnBrws);
            this.Controls.Add(this.txtDownloadLocation);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.numUpdateDays);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkDeleteExecutable);
            this.Controls.Add(this.chkHoverURL);
            this.Controls.Add(this.chkAutoClearURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.frmSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnBrws;
        internal System.Windows.Forms.ToolTip ttOptions;
        internal System.Windows.Forms.TextBox txtDownloadLocation;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NumericUpDown numUpdateDays;
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.CheckBox chkDeleteExecutable;
        internal System.Windows.Forms.CheckBox chkHoverURL;
        internal System.Windows.Forms.CheckBox chkAutoClearURL;
        private System.Windows.Forms.Button btnRedownload;

    }
}