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
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat"))
            {
                hasUpdated = true;
            }

            // Checks the download directory setting, if it's null just ask the user to specify a location to download.
            // Way easier than using a first-time setup.
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.DownloadDir))
            {
                switch (MessageBox.Show("Would you like to use " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads" + " as your download path?", "Youtube-DL GUI", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        Properties.Settings.Default.DownloadDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
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
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe"))
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
            if (hasUpdated)
            {
                niTray.BalloonTipIcon = ToolTipIcon.Info;
                niTray.BalloonTipTitle = "youtube-dl-gui updated";
                niTray.BalloonTipText = "youtube-dl-gui has been updated to " + Properties.Settings.Default.appVersion + ".";
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat");
            }

            if (Properties.Settings.Default.saveArgs)
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\args.txt"))
                    txtArgs.Text = File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\args.txt");

            cbFormat.SelectedIndex = 0;
            cbQuality.SelectedIndex = 0;
            cbConvFormat.SelectedIndex = 0;
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
            if (Properties.Settings.Default.DeleteAfterClose)
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");
            }
            if (Properties.Settings.Default.saveArgs)
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\args.txt"))
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\args.txt");

                File.Create(System.Windows.Forms.Application.StartupPath + @"\args.txt").Dispose();
                File.WriteAllText(System.Windows.Forms.Application.StartupPath + @"\args.txt", txtArgs.Text);

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
                        Updater.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\ydgu.bat";
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
            string updaterCode = "@echo off\necho ===========================================\necho // YOUTUBE-DL-GUI UPDATER  (BAT VERSION) \\\\\necho //      CURRENT BATCH VERSION: 1.2       \\\\\necho //  IF THIS WINDOW DOES NOT CLOSE AFTER  \\\\\necho //    YOUTUBE-DL-GUI IS FULLY UPDATED    \\\\\necho //       THEN IT IS SAFE TO CLOSE.       \\\\\necho ===========================================\nset arg1=%1\nset arg2=%2\ntimeout /t 5\ndel %arg2%\npowershell -Command \"(New-Object Net.WebClient).DownloadFile('https://github.com/obscurename/youtube-dl-gui/releases/download/%arg1%/youtube-dl-gui.exe', '%arg2%')\"\n%arg2%\nexit";

            /*
             * This is the entire code for the updater, it is designed to be light-weight and so is batch-based.
             
             @echo off
             echo ===========================================
             echo // YOUTUBE-DL-GUI UPDATER  (BAT VERSION) \\
             echo //      CURRENT BATCH VERSION: 1.2       \\
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
             exit

             */

            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat"))
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat");

            File.Create(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat").Dispose();
            System.IO.StreamWriter writeApp = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat");
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

                    if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe"))
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");
                    }

                    DownloadFile.DownloadFile(YtDl, System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");

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
            frmSupported supportedFrm = new frmSupported();
            supportedFrm.Show();
        }

        private void txtURL_MouseEnter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HoverURL == true)
            {
                if (Clipboard.ContainsText() && txtURL.Text != Clipboard.GetText())
                {
                    txtURL.Clear();
                    txtURL.Text = Clipboard.GetText();
                }
            }
        }
        private void txtURL_TextChanged(object sender, EventArgs e)
        {}

        private void rbVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVideo.Checked)
            {
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                txtArgs.ReadOnly = true;
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAudio.Checked)
            {
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                txtArgs.ReadOnly = true;
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                txtArgs.ReadOnly = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            StartDownload("\"" + txtURL.Text + "\"", txtArgs.Text, false, false);
        }

        private void StartDownload(string URL, string Args, bool fromTray, bool dlTrayAudio)
        {
            string OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s\" ";
            string dlFormat = "best";
            string dlQuality = "best";
            string setArgs = "";
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
                    setArgs = OutputFolder + URL + " -x --audio-format mp3  --audio-quality 256K";
                }
                else
                {
                   setArgs =  OutputFolder + URL + " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtURL.Text))
                {
                    MessageBox.Show("Please enter a URL before attempting to download.", "youtube-dl-gui", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbVideo.Checked)
                {
                    if (cbQuality.SelectedIndex == 0 || cbQuality.SelectedIndex == 1)
                    {
                        dlQuality = "best";
                    }
                    else if (cbQuality.SelectedIndex > 8)
                    {
                        MessageBox.Show("Please select a video quality in the quality drop box.");
                        return;
                    } 
                        else if (cbQuality.SelectedIndex < 8 && cbQuality.SelectedIndex > 1)
                    {
                        dlQuality = cbQuality.SelectedItem.ToString();
                    } 

                    if (cbFormat.SelectedIndex > 7)
                    {
                        MessageBox.Show("Please select a video format in the format drop box.");
                        return;
                    }
                    else if (cbFormat.SelectedIndex < 7 && cbFormat.SelectedIndex > 1)
                    {
                        dlFormat = cbFormat.SelectedItem.ToString();
                    }

                    if (dlFormat == "best" && dlQuality == "best")
                    {
                        setArgs = OutputFolder + URL + " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    } else {
                        setArgs = OutputFolder + URL + " -f \"bestvideo[height<=" + dlQuality + "][ext=" + dlFormat + "]+bestaudio[ext=m4a]/best[height<=" + dlQuality + "][ext=" + dlFormat + "]/best ";
                    }
                }
                else if (rbAudio.Checked)
                {
                    if (cbQuality.SelectedIndex == 0)
                    {
                        dlQuality = "256K";
                    }
                    else if (cbQuality.SelectedIndex < 9 && cbQuality.SelectedIndex != 0)
                    {
                        MessageBox.Show("Please select a audio format in the format drop box");
                        return;
                    }
                    else 
                    {
                        dlQuality = cbQuality.SelectedItem.ToString();
                    }

                    if (cbFormat.SelectedIndex < 8 && cbFormat.SelectedIndex != 0)
                    {
                        MessageBox.Show("Please select a audio format in the format drop box.");
                        return;
                    }
                    else
                    {
                        dlFormat = cbFormat.SelectedItem.ToString();
                    }

                    setArgs = OutputFolder + URL + " -x --audio-format " + dlFormat + " --audio-quality " + dlQuality;
                }
                else if (rbCustom.Checked)
                {
                    setArgs = OutputFolder + Args + " \"" + URL + "\"";
                }
            }

            MessageBox.Show(setArgs);
            Downloader.StartInfo.Arguments = setArgs;
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
            string setArgs = "";
            string convTo = "";
            if (chkSaveToMaster.Checked)
            {
                convTo = Path.GetDirectoryName(txtConvFile.Text);
            }
            else
            {
                convTo = txtConvSave.Text;
            }

            if (cbConvQuality.SelectedIndex == 0 || cbConvQuality.SelectedIndex == 7)
            {
                MessageBox.Show("Please select a valid quality.");
                return;
            }
            if (cbConvFormat.SelectedIndex == 1 || cbConvFormat.SelectedIndex == 7)
            {
                MessageBox.Show("Please select a valid format.");
                return;
            }

            setArgs = "-i \"" + FileInput + "\" -ab " + cbConvQuality.Text + " \"" + convTo + "\\" + Path.GetFileNameWithoutExtension(convTo + "." + cbConvFormat.Text + "\"");

            Converter.StartInfo.Arguments = setArgs;
            Converter.StartInfo.UseShellExecute = false;
            Converter.StartInfo.CreateNoWindow = false;
            Converter.Start();
        }
        #endregion

        #region About / Settings
        

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
            StartDownload("\"" + Clipboard.GetText() + "\"", txtArgs.Text, true, true);
        }
        private void cmTrayDownloadVideo_Click(object sender, EventArgs e)
        {
            StartDownload(Clipboard.GetText(), txtArgs.Text, true, false);
        }
        private void cmTrayExit_Click(object sender, EventArgs e)
        {
            niTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region mFrmMain
        private void mFrmMainSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.Show();
        }
        private void mFrmMainSupported_Click(object sender, EventArgs e)
        {
            frmSupported supportedForm = new frmSupported();
            supportedForm.Show();
        }
        private void mFrmMainAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.Show();
        }
        #endregion

    }
}
