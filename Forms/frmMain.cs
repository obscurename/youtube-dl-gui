using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using Octokit;

// Please read the github readme. \\

namespace youtube_dl_gui
{
    public partial class frmMain : Form
    {

        #region Variables
        bool hasUpdated = false;
        #endregion

        #region Form
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            niTray.ContextMenu = cmTray;
            // Check for updater batch file & delete it.
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat"))
            {
                hasUpdated = true;
            }

            // Checks the download directory setting, if it's null just ask the user to specify a location to download.
            // Way easier than using a first-time setup.
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.DownloadDir))
            {
            retry:
                switch (MessageBox.Show("Would you like to use " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads" + " as your download path?", "Youtube-DL GUI", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        Properties.Settings.Default.DownloadDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                        Properties.Settings.Default.Save();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder for videos to download to" };
                        switch (fbd.ShowDialog())
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                Properties.Settings.Default.DownloadDir = fbd.SelectedPath;
                                Properties.Settings.Default.Save();
                                break;
                            case System.Windows.Forms.DialogResult.Cancel:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
            }

            // Downloads the youtube-dl application if it does not exist, otherwise it checks for updates.
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\youtube-dl.exe"))
            {
                DownloadYoutubeDL();
            }
            else
            {
                CheckForUpdate();
            }

            
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            chkHoverURL.Checked = Properties.Settings.Default.HoverURL;
            chkAutoClearURL.Checked = Properties.Settings.Default.ClearURL;
            chkDeleteExecutable.Checked = Properties.Settings.Default.DeleteAfterClose;
            chkUpdate.Checked = Properties.Settings.Default.UpdateDL;
            numUpdateDays.Value = Convert.ToDecimal(Properties.Settings.Default.DaysBetweenUpdate);
            txtDownloadLocation.Text = Properties.Settings.Default.DownloadDir;

            if (hasUpdated)
            {
                niTray.BalloonTipIcon = ToolTipIcon.Info;
                niTray.BalloonTipTitle = "youtube-dl-gui updated";
                niTray.BalloonTipText = "youtube-dl-gui has been updated to " + Properties.Settings.Default.appVersion + ".";
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat");
            }
        }
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.DeleteAfterClose == true)
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\youtube-dl.exe");
            }
            niTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region Custom
        private async void CheckForUpdate()
        {
            // Check for youtube-dl update, if enabled.
            if (Properties.Settings.Default.UpdateDL == true)
            {
                DateTime PreviousUpdated = Properties.Settings.Default.DateLastUpdated;
                DateTime TodayDate = DateTime.Now;
                if ((PreviousUpdated - TodayDate).TotalDays > Properties.Settings.Default.DaysBetweenUpdate)
                {
                    DownloadYoutubeDL();
                }
            }

            // Check for application update then copy the resourced batch file, run it, and exit immediately.
            var client = new GitHubClient(new ProductHeaderValue("youtube-dl-gui"));
            var releases = await client.Repository.Release.GetAll("obscurename", "youtube-dl-gui");
            var latest = releases[0];
            if (latest.TagName != Properties.Settings.Default.appVersion)
            {
                switch (MessageBox.Show("An update for youtube-dl-gui is available. Update now?", "youtube-dl-gui", MessageBoxButtons.YesNo))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        CreateUpdater();

                        Process Updater = new Process();
                        Updater.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\ydgu.bat";
                        Updater.StartInfo.Arguments = latest.TagName + " " + System.AppDomain.CurrentDomain.FriendlyName;
                        Updater.StartInfo.UseShellExecute = false;
                        Updater.StartInfo.CreateNoWindow = false;
                        Updater.Start();

                        niTray.Visible = false;
                        Environment.Exit(0);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        return;
                }
            }

        }
        private void CreateUpdater()
        {
            string updaterCode = "@echo off\necho ===========================================\necho // YOUTUBE-DL-GUI UPDATER  (BAT VERSION) \\\\\necho //      CURRENT BATCH VERSION: 1.1       \\\\\necho //  IF THIS WINDOW DOES NOT CLOSE AFTER  \\\\\necho //    YOUTUBE-DL-GUI IS FULLY UPDATED    \\\\\necho //       THEN IT IS SAFE TO CLOSE.       \\\\\necho ===========================================\nset arg1=%1\nset arg2=%2\ntimeout /t 5\ndel %arg2%\npowershell -Command \"(New-Object Net.WebClient).DownloadFile('https://github.com/obscurename/youtube-dl-gui/releases/download/%arg1%/youtube-dl-gui.exe', '%arg2%')\"\n%arg2%";

            /*
             * This is the entire code for the updater, it is designed to be light-weight and so is batch-based.
             
             @echo off
             echo ===========================================
             echo // YOUTUBE-DL-GUI UPDATER  (BAT VERSION) \\
             echo //      CURRENT BATCH VERSION: 1.1       \\
             echo //  IF THIS WINDOW DOES NOT CLOSE AFTER  \\
             echo //    YOUTUBE-DL-GUI IS FULLY UPDATED    \\
             echo //       THEN IT IS SAFE TO CLOSE.       \\
             echo ===========================================
             set arg1=%1
             set arg2=%2
             timeout /t 5
             del %arg2%
             powershell -Command "(New-Object Net.WebClient).DownloadFile('https://github.com/obscurename/youtube-dl-gui/releases/download/%arg1%/youtube-dl-gui.exe', '%arg2%')"
             %arg2%

             */

            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat"))
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat");

            File.Create(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat").Dispose();
            System.IO.StreamWriter writeApp = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + "\\ydgu.bat");
            writeApp.WriteLine(updaterCode);
            writeApp.Close();
        }
        public static async void DownloadYoutubeDL()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("youtube-dl"));
                var releases = await client.Repository.Release.GetAll("rg3", "youtube-dl");
                var latest = releases[0];

                if (latest.TagName == Properties.Settings.Default.ytDLVersion)
                {
                    MessageBox.Show("youtube-dl is already at the latest version.");
                    return;
                }

                string YtDl = "https://github.com/rg3/youtube-dl/releases/download/" + latest.TagName + "/youtube-dl.exe";
            RetryDownload:
                try
                {

                    WebClient DownloadFile = new WebClient();

                    if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\youtube-dl.exe"))
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + "\\youtube-dl.exe");
                    }

                    DownloadFile.DownloadFile(YtDl, System.Windows.Forms.Application.StartupPath + "\\youtube-dl.exe");

                    Properties.Settings.Default.DateLastUpdated = DateTime.Now;
                }
                catch (Exception ex)
                {
                    switch (MessageBox.Show("An exception has occured. Please open an issue with the following:\n\n" + ex.ToString(), "Youtube-DL GUI", MessageBoxButtons.RetryCancel))
                    {
                        case DialogResult.Retry:
                            goto RetryDownload;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Downloader
        private void llSupported_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            youtube_dl_gui.Forms.frmSupported supportedFrm = new youtube_dl_gui.Forms.frmSupported();
            supportedFrm.Show();
        }

        private void txtURL_MouseEnter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HoverURL == true)
            {
                if (Clipboard.ContainsText() & Clipboard.GetText() != null)
                {
                    txtURL.Clear();
                    txtURL.Text = Clipboard.GetText();
                }
            }
        }
        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            //if (!txtURL.Text.Contains("youtube.com/watch?v="))
            //{
            //    gbDownloadAs.Enabled = false;
            //    rbVideo.Checked = true;
            //}else{
            //    gbDownloadAs.Enabled = true;
            //}
        }

        private void rbVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCustom.Checked)
            {
                txtArgs.ReadOnly = true;
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                cbQuality.Text = "";
                cbFormat.Text = "";
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCustom.Checked)
            {
                txtArgs.ReadOnly = true;
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                cbQuality.Text = "256K";
                cbFormat.Text = "mp3";
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                txtArgs.ReadOnly = false;
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                cbQuality.Text = "";
                cbFormat.Text = "";
            }
        }
        private void LinkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rg3/youtube-dl/blob/master/README.md");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            StartDownload(txtURL.Text, txtArgs.Text, false, false);
        }

        private void StartDownload(string URL, string Args, bool fromTray, bool dlTrayAudio)
        {
            string OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s\" ";
            Process Downloader = new Process();
            Downloader.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "/youtube-dl.exe";
            if (fromTray)
            {
                if (string.IsNullOrWhiteSpace(Clipboard.GetText()))
                {
                    MessageBox.Show("Please copy a URL before attemping to download.");
                    return;
                }
                if (dlTrayAudio)
                {
                    Downloader.StartInfo.Arguments = "" + OutputFolder + "-x --audio-format " + "mp3" + " --audio-quality " + "256K" + " " + "\"" + URL + "\"";
                }
                else
                {
                    Downloader.StartInfo.Arguments = "" + OutputFolder + "\"" + URL + "\"";
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtURL.Text))
                {
                    MessageBox.Show("Please enter a URL before attempting to download.", "Youtube-DL GUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbVideo.Checked)
                {
                    MessageBox.Show("" + OutputFolder+ "\"" + URL + "\"");
                    Downloader.StartInfo.Arguments = "" + OutputFolder + "\"" + URL + "\"";
                }
                else if (rbAudio.Checked)
                {
                    Downloader.StartInfo.Arguments = "" + OutputFolder + "-x --audio-format " + cbFormat.SelectedItem + " --audio-quality " + cbQuality.SelectedItem + " " + "\"" + URL + "\"";
                }
                else if (rbCustom.Checked)
                {
                    Downloader.StartInfo.Arguments = Args + " \"" + URL + "\"";
                }
            }

            Downloader.StartInfo.UseShellExecute = false;
            Downloader.StartInfo.CreateNoWindow = false;
            Downloader.Start();

            if (Properties.Settings.Default.ClearURL == true)
            {
                txtURL.Clear();
                Clipboard.Clear();
            }
        }
        #endregion
        #region Converter
        private void btnBrowseConvFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Title = "Select file to convert" };
            switch (ofd.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    txtConvFile.Text = ofd.FileName;
                    if (chkSaveToMaster.Checked)
                    {
                        btnConvert.Enabled = true;
                    }else{
                        btnBrowseConvSaveFile.Enabled = true;
                    }
                    break;
            }
        }
        private void btnBrowseConvSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Title = "Save converted file as..." };
            switch (sfd.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    txtConvSave.Text = sfd.FileName;
                    btnConvert.Enabled = true;
                    break;
            }
        }
        private void chkSaveToMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaveToMaster.Checked)
            {
                btnBrowseConvSaveFile.Enabled = false;
                txtConvSave.Text = null;
                btnBrowseConvSaveFile.Enabled = false;
                Properties.Settings.Default.SaveToMaster = true;
            }else{
                btnBrowseConvSaveFile.Enabled = true;
                Properties.Settings.Default.SaveToMaster = false;
            }
            Properties.Settings.Default.Save();
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertFile(txtConvFile.Text);
        }
        private void ConvertFile(string FileInput)
        {
            Process Converter = new Process();
            Converter.StartInfo.FileName = "ffmpeg.exe";
            if (chkSaveToMaster.Checked)
            {
                Converter.StartInfo.Arguments = "-i \"" + FileInput + "\" -ab " + cbConvQuality.Text + " \"" + Path.GetDirectoryName(txtConvFile.Text) + "\\" + Path.GetFileNameWithoutExtension(txtConvFile.Text) + "." + cbConvFormat.Text + "\"";
            }
            else
            {
                Converter.StartInfo.Arguments = "-i \"" + FileInput + "\" -ab " + cbConvQuality.Text + " \"" + txtConvSave.Text + "\\" + Path.GetFileNameWithoutExtension(txtConvFile.Text) + "." + cbConvFormat.Text + "\"";
            }
            Converter.StartInfo.UseShellExecute = false;
            Converter.StartInfo.CreateNoWindow = false;
            Converter.Start();
        }
        #endregion
        #region About / Settings
        private void chkHoverURL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHoverURL.Checked != Properties.Settings.Default.HoverURL)
            {
                Properties.Settings.Default.HoverURL = chkHoverURL.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void chkAutoClearURL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoClearURL.Checked != Properties.Settings.Default.ClearURL)
            {
                Properties.Settings.Default.ClearURL = chkAutoClearURL.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void chkDeleteExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteExecutable.Checked != Properties.Settings.Default.DeleteAfterClose)
            {
                Properties.Settings.Default.DeleteAfterClose = chkDeleteExecutable.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdate.Checked != Properties.Settings.Default.UpdateDL)
            {
                Properties.Settings.Default.UpdateDL = chkUpdate.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void numUpdateDays_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numUpdateDays.Value) != Properties.Settings.Default.DaysBetweenUpdate)
            {
                Properties.Settings.Default.DaysBetweenUpdate = Convert.ToInt32(numUpdateDays.Value);
                Properties.Settings.Default.Save();
            }
        }

        private void btnBrws_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to save downloads to" };
            switch (fbd.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    Properties.Settings.Default.DownloadDir = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    return;
            }
        }
        private void btnRedownload_Click(object sender, EventArgs e)
        {
            DownloadYoutubeDL();
        }

        #endregion
        #region Notification icon + ContextMenu
        private void niTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void cmTrayShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void cmTrayDownloadAudio_Click(object sender, EventArgs e)
        {
            StartDownload(Clipboard.GetText(), txtArgs.Text, true, true);
        }
        private void cmTrayDownloadVideo_Click(object sender, EventArgs e)
        {
            StartDownload(Clipboard.GetText(), txtArgs.Text, true, false);
        }
        private void cmTrayCheckForUpdate_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }
        private void cmTrayExit_Click(object sender, EventArgs e)
        {
            niTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

    }
}
