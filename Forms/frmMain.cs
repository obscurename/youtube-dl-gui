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
using System.Net.NetworkInformation;

// Please read the github readme. \\

namespace youtube_dl_gui
{
    public partial class frmMain : Form
    {

        #region Variables
        bool hasUpdated = false;
        //bool networkAvailable = true;
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

            // Ping google for network availability.
            //networkAvailable = pingGoogle();
            //if (!networkAvailable)
            //    MessageBox.Show("Warning: Network connection not detected.\n\nDownloading the required files or videos may not work.");

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
                // If the network is unavailable, skip downloading.
                //if (!networkAvailable)
                //    return;
                DownloadYoutubeDL();
            }
            CheckForUpdate();
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

            if (rbVideo.Checked)
                reloadVideoParams();
            else if (rbVideo.Checked)
                reloadAudioParams();

            if (Properties.Settings.Default.saveDlParams)
            {
                cbFormat.SelectedIndex = Properties.Settings.Default.vidFormat;
                cbQuality.SelectedIndex = Properties.Settings.Default.vidQuality;
            } else {
                cbFormat.SelectedIndex = 0;
                cbQuality.SelectedIndex = 0;
            }

            if (Properties.Settings.Default.saveConvParams)
            {
                cbConvFormat.SelectedIndex = Properties.Settings.Default.convFormat;
                cbConvQuality.SelectedIndex = Properties.Settings.Default.convQuality;
            } else {
                cbConvFormat.SelectedIndex = -1;
                cbConvQuality.SelectedIndex = -1;
            }
        }
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.DeleteAfterClose)
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");

            niTray.Visible = false;
        }
        #endregion

        #region Custom
        private async void CheckForUpdate()
        {
            if (Properties.Settings.Default.updateCheck == false)
                return;

            // Check for youtube-dl update, if enabled.
            if (Properties.Settings.Default.UpdateDL == true)
            {
                DateTime PreviousUpdated = Properties.Settings.Default.DateLastUpdated;
                DateTime TodayDate = DateTime.Now;

                if ((PreviousUpdated - TodayDate).TotalDays > Properties.Settings.Default.DaysBetweenUpdate)
                    DownloadYoutubeDL();
            }


            // Check for application update then copy the resourced batch file, run it, and exit immediately.
            var client = new GitHubClient(new ProductHeaderValue("youtube-dl-gui"));
            var releases = await client.Repository.Release.GetAll("obscurename", "youtube-dl-gui");
            var latest = releases[0];
            if (latest.TagName != Properties.Settings.Default.appVersion)
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

            GC.Collect();
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

            GC.Collect();
        }

        private void reloadAudioParams()
        {
            cbQuality.Items.Clear();
            cbQuality.Items.Add("best");
            cbQuality.Items.Add("8K");
            cbQuality.Items.Add("16K");
            cbQuality.Items.Add("24K");
            cbQuality.Items.Add("32K");
            cbQuality.Items.Add("40K");
            cbQuality.Items.Add("48K");
            cbQuality.Items.Add("56K");
            cbQuality.Items.Add("64K");
            cbQuality.Items.Add("80K");
            cbQuality.Items.Add("96K");
            cbQuality.Items.Add("112K");
            cbQuality.Items.Add("128K");
            cbQuality.Items.Add("144K");
            cbQuality.Items.Add("160K");
            cbQuality.Items.Add("192K");
            cbQuality.Items.Add("224K");
            cbQuality.Items.Add("256K");
            cbQuality.Items.Add("320K");

            cbFormat.Items.Clear();
            cbFormat.Items.Add("best");
            cbFormat.Items.Add("aac");
            cbFormat.Items.Add("flac");
            cbFormat.Items.Add("m4a");
            cbFormat.Items.Add("mp3");
            cbFormat.Items.Add("opus");
            cbFormat.Items.Add("vorbis");
            cbFormat.Items.Add("wav");
        }
        private void reloadVideoParams()
        {
            cbQuality.Items.Clear();
            cbQuality.Items.Add("best");
            cbQuality.Items.Add("1080p");
            cbQuality.Items.Add("720p");
            cbQuality.Items.Add("640p");
            cbQuality.Items.Add("480p");
            cbQuality.Items.Add("360p");
            cbQuality.Items.Add("240p");
            cbQuality.Items.Add("144p");

            cbFormat.Items.Clear();
            cbFormat.Items.Add("best");
            cbFormat.Items.Add("avi");
            cbFormat.Items.Add("flv");
            cbFormat.Items.Add("mp4");
            cbFormat.Items.Add("mkv");
            cbFormat.Items.Add("webm");
        }

        private void reloadConvAudio()
        {
            cbConvQuality.Enabled = true;
            cbConvQuality.Items.Clear();
            cbConvQuality.Items.Add("best");
            cbConvQuality.Items.Add("8K");
            cbConvQuality.Items.Add("16K");
            cbConvQuality.Items.Add("24K");
            cbConvQuality.Items.Add("32K");
            cbConvQuality.Items.Add("40K");
            cbConvQuality.Items.Add("48K");
            cbConvQuality.Items.Add("56K");
            cbConvQuality.Items.Add("64K");
            cbConvQuality.Items.Add("80K");
            cbConvQuality.Items.Add("96K");
            cbConvQuality.Items.Add("112K");
            cbConvQuality.Items.Add("128K");
            cbConvQuality.Items.Add("144K");
            cbConvQuality.Items.Add("160K");
            cbConvQuality.Items.Add("192K");
            cbConvQuality.Items.Add("224K");
            cbConvQuality.Items.Add("256K");
            cbConvQuality.Items.Add("320K");

            cbConvFormat.Items.Clear();
            cbConvFormat.Items.Add("aac");
            cbConvFormat.Items.Add("flac");
            cbConvFormat.Items.Add("m4a");
            cbConvFormat.Items.Add("mp3");
            cbConvFormat.Items.Add("opus");
            cbConvFormat.Items.Add("vorbis");
            cbConvFormat.Items.Add("wav");
        }
        private void reloadConvVideo()
        {
            cbConvQuality.Enabled = false;
            cbConvQuality.Items.Clear();
            cbConvQuality.Items.Add("best");
            cbConvQuality.Items.Add("1080p");
            cbConvQuality.Items.Add("720p");
            cbConvQuality.Items.Add("640p");
            cbConvQuality.Items.Add("480p");
            cbConvQuality.Items.Add("360p");
            cbConvQuality.Items.Add("240p");
            cbConvQuality.Items.Add("144p");
            cbConvQuality.SelectedIndex = 0;

            cbConvFormat.Items.Clear();
            cbConvFormat.Items.Add("avi");
            cbConvFormat.Items.Add("flv");
            cbConvFormat.Items.Add("mp4");
            cbConvFormat.Items.Add("mkv");
            cbConvFormat.Items.Add("webm");
        }

        public static bool pingGoogle()
        {
            Ping pingGoogle = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int pingTimeout = 5000;
            PingOptions pingOpt = new PingOptions();
            PingReply getPing = pingGoogle.Send(host, pingTimeout, buffer, pingOpt);

            if (getPing.Status == IPStatus.TimedOut)
                return false;
             else if (getPing.Status == IPStatus.Success)
                return true;
            
            return true;
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
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");
                   
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
        private void txtURL_MouseEnter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HoverURL == true)
                if (Clipboard.ContainsText() && txtURL.Text != Clipboard.GetText())
                {
                    txtURL.Clear();
                    txtURL.Text = Clipboard.GetText();
                }
        }
        private void txtURL_TextChanged(object sender, EventArgs e)
        {}

        private void rbVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVideo.Checked)
            {
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                txtArgs.ReadOnly = true;
                reloadVideoParams();
                txtArgs.Clear();

                if (Properties.Settings.Default.saveDlParams)
                {
                    //cbFormat.SelectedIndex = Properties.Settings.Default.vidFormat;
                    //cbQuality.SelectedIndex = Properties.Settings.Default.vidQuality;
                }

                cbFormat.SelectedIndex = 0;
                cbQuality.SelectedIndex = 0;
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAudio.Checked)
            {
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                txtArgs.ReadOnly = true;
                reloadAudioParams();
                txtArgs.Clear();

                if (Properties.Settings.Default.saveDlParams)
                {
                    cbFormat.SelectedIndex = Properties.Settings.Default.audFormat;
                    cbQuality.SelectedIndex = Properties.Settings.Default.audQuality;
                }
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                txtArgs.ReadOnly = false;

                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.savedArgs))
                    txtArgs.Text = Properties.Settings.Default.savedArgs;

                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
            }
        }

        private void cbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbQuality.SelectedIndex == 1)
            //    cbQuality.SelectedIndex = 0;

            //if (cbQuality.SelectedIndex == 8)
            //    cbQuality.SelectedIndex = 0;

            //if (rbAudio.Checked && cbQuality.SelectedIndex < 8)
            //    cbQuality.SelectedIndex = 0;

            //if (rbVideo.Checked && cbQuality.SelectedIndex > 8)
            //    cbQuality.SelectedIndex = 0;
        }
        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbFormat.SelectedIndex == 1)
            //    cbFormat.SelectedIndex = 0;

            //if (cbFormat.SelectedIndex == 7)
            //    cbFormat.SelectedIndex = 0;

            //if (rbAudio.Checked && cbFormat.SelectedIndex < 7)
            //    cbFormat.SelectedIndex = 0;

            //if (rbVideo.Checked && cbFormat.SelectedIndex > 7)
            //    cbFormat.SelectedIndex = 0;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            int dlType = -1;

            if (rbVideo.Checked)
                dlType = 0;
            else if (rbAudio.Checked)
                dlType = 1;

            StartDownload("\"" + txtURL.Text + "\"", txtArgs.Text, dlType, false, false);

            if (Properties.Settings.Default.saveDlParams)
                if (rbVideo.Checked)
                {
                    Properties.Settings.Default.vidFormat = cbFormat.SelectedIndex;
                    Properties.Settings.Default.vidQuality = cbQuality.SelectedIndex;
                } else if (rbAudio.Checked) {
                    Properties.Settings.Default.audFormat = cbFormat.SelectedIndex;
                    Properties.Settings.Default.audQuality = cbQuality.SelectedIndex;
                }

            if (Properties.Settings.Default.saveArgs)
                Properties.Settings.Default.savedArgs = txtArgs.Text;

            Properties.Settings.Default.Save();
        }

        private void StartDownload(string URL, string Args, int downloadType, bool fromTray, bool dlTrayAudio)
        {
            string OutputFolder; 
            if (rbAudio.Checked)
                downloadType = 0; // Sort to Audio
            else if (rbVideo.Checked)
                downloadType = 1; // Sort to Video
            else
                downloadType = 2; // Do not sort, remain in the root download directory.

            if (Properties.Settings.Default.sortDownloads)
                if (downloadType == 0)
                    OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/Audio/%(title)s-%(id)s.%(ext)s\" ";
                else if (downloadType == 1)
                    OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/Video/%(title)s-%(id)s.%(ext)s\" ";
                else
                    OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s\" ";
            else
                OutputFolder = "-o \"" + Properties.Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s\" ";

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
                    setArgs = OutputFolder + URL + " -x --audio-format mp3  --audio-quality 256K";
                else
                   setArgs =  OutputFolder + URL + " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";

            } else {

                if (string.IsNullOrWhiteSpace(txtURL.Text))
                {
                    MessageBox.Show("Please enter a URL before attempting to download.", "youtube-dl-gui", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbVideo.Checked)
                {

                    if (cbQuality.SelectedIndex == 0)
                        dlQuality = "best";
                    else
                        dlQuality = cbQuality.SelectedItem.ToString();

                    if (cbFormat.SelectedIndex == 0)
                        dlFormat = "best";
                    else
                        dlFormat = cbFormat.SelectedItem.ToString();

                    if (cbQuality.SelectedIndex == 0 && cbFormat.SelectedIndex == 0)
                        setArgs = OutputFolder + URL + " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    else
                        setArgs = OutputFolder + URL + " -f \"bestvideo[height<=" + dlQuality + "][ext=" + dlFormat + "]+bestaudio[ext=m4a]/best[height<=" + dlQuality + "][ext=" + dlFormat + "]/best ";

                } else if (rbAudio.Checked) {

                    if (cbQuality.SelectedIndex == 0)
                        dlQuality = "256K";
                    else 
                        dlQuality = cbQuality.SelectedItem.ToString();

                    dlFormat = cbFormat.SelectedItem.ToString();

                    setArgs = OutputFolder + URL + " -x --audio-format " + dlFormat + " --audio-quality " + dlQuality;

                } else if (rbCustom.Checked) {

                    setArgs = OutputFolder + txtArgs.Text + " \"" + URL + "\"";

                    if (Properties.Settings.Default.saveArgs)
                        Properties.Settings.Default.savedArgs = txtArgs.Text;

                    Properties.Settings.Default.Save();
                }

            }

            Downloader.StartInfo.Arguments = setArgs;
            Downloader.StartInfo.UseShellExecute = false;
            Downloader.StartInfo.CreateNoWindow = false;
            bool errOccured = false;

            try
            {
                Downloader.Start();
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("The system cannot find the file specified"))
                {
                    MessageBox.Show("Error: youtube-dl.exe not found.\n\nPlease redownload it from the settings, or restart the application.", "youtube-dl-gui");
                    errOccured = true;
                }else{
                    MessageBox.Show("Unknown error. Please start a new issue on Github with this exception:\n\n" + ex.ToString(), "youtube-dl-gui");
                    errOccured = true;
                }
            }

pingError:
            if (errOccured)
            {
                GC.Collect();
                return;
            }

            if (Properties.Settings.Default.ClearURL == true)
            {
                txtURL.Clear();
                Clipboard.Clear();
            }

            GC.Collect();
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
                    if (Properties.Settings.Default.SaveToMaster)
                    {
                        btnConvert.Enabled = true;
                    }else{
                        btnBrowseConvSaveFile.Enabled = true;
                    }
                    break;
            }

            if (Properties.Settings.Default.saveConvParams)
            {
                cbConvFormat.SelectedIndex = Properties.Settings.Default.convFormat;
                cbConvQuality.SelectedIndex = Properties.Settings.Default.convQuality;
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

        private void cbConvQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbConvQuality.SelectedIndex == 0)
            //    cbConvQuality.SelectedIndex = -1;

            //if (cbConvQuality.SelectedIndex == 7)
            //    cbConvQuality.SelectedIndex = -1;
        }
        private void cbConvFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbConvFormat.SelectedIndex == 0)
            //    cbConvFormat.SelectedIndex = -1;

            //if (cbConvFormat.SelectedIndex == 6)
            //    cbConvFormat.SelectedIndex = -1;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (cbConvQuality.SelectedIndex == -1 || cbConvQuality.SelectedIndex == 0 || cbConvQuality.SelectedIndex == 7)
            {
                MessageBox.Show("Please select a quality before converting.");
                return;
            }

            if (cbConvFormat.SelectedIndex == -1 || cbConvFormat.SelectedIndex == 1 || cbConvFormat.SelectedIndex == 7)
            {
                MessageBox.Show("Please select a format before converting.");
                return;
            }

            ConvertFile(txtConvFile.Text);

            if (Properties.Settings.Default.saveConvParams)
            {
                Properties.Settings.Default.convFormat = cbConvFormat.SelectedIndex;
                Properties.Settings.Default.convQuality = cbConvQuality.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }

        private void ConvertFile(string FileInput)
        {
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

            Process Converter = new Process();
            Converter.StartInfo.FileName = "ffmpeg.exe";
            string setArgs = "";
            string convTo = "";
            string vidFormat = "";

            if (cbConvQuality.SelectedIndex > 0 && cbConvQuality.SelectedIndex < 7)
            {
                // Video
                string vidTrueRes = "";
                bool selectedQuality = true;

                if (cbConvQuality.SelectedIndex == 1) // 1080p
                    vidTrueRes = "1920x1080";
                else if (cbConvQuality.SelectedIndex == 2) //720p
                    vidTrueRes = "1280x720";
                else if (cbConvQuality.SelectedIndex == 3) //480p
                    vidTrueRes = "640x480";
                else if (cbConvQuality.SelectedIndex == 4) //360p
                    vidTrueRes = "480x360";
                else if (cbConvQuality.SelectedIndex == 5) //240p
                    vidTrueRes = "360x240";
                else if (cbConvQuality.SelectedIndex == 6) // 144p
                    vidTrueRes = "192x144";
                else
                    selectedQuality = false;

                if (selectedQuality)
                    vidFormat = " -s " + vidTrueRes;
            }

            if (Properties.Settings.Default.SaveToMaster)
            {
                convTo = Path.GetDirectoryName(txtConvFile.Text);
                setArgs = "-i \"" + FileInput + "\" -ab " + cbConvQuality.Text + " \"" + convTo + "\\" + Path.GetFileNameWithoutExtension(FileInput) + "." + cbConvFormat.Text + "\"";
            }
            else
            {
                convTo = txtConvSave.Text;
                setArgs = "-i \"" + FileInput + "\" -ab " + cbConvQuality.Text + " \"" + convTo + "\\" + Path.GetFileNameWithoutExtension(convTo) + "." + cbConvFormat.Text + "\"";
            }

            Converter.StartInfo.Arguments = setArgs;
            Converter.StartInfo.UseShellExecute = false;
            Converter.StartInfo.CreateNoWindow = false;
            Converter.Start();

            GC.Collect();
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
            StartDownload("\"" + Clipboard.GetText() + "\"", txtArgs.Text, 0, true, true);
        }
        private void cmTrayDownloadVideo_Click(object sender, EventArgs e)
        {
            StartDownload(Clipboard.GetText(), txtArgs.Text, 1, true, false);
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
            settingsForm.ShowDialog();
            settingsForm.Dispose();
            GC.Collect();
        }
        private void mFrmMainSupported_Click(object sender, EventArgs e)
        {
            Process.Start("https://rg3.github.io/youtube-dl/supportedsites.html");
        }
        private void mFrmMainAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.ShowDialog();
            aboutForm.Dispose();
            GC.Collect();
        }
        private void MainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabs.SelectedIndex == 1)
                txtURL.Enabled = false;
            else
                txtURL.Enabled = true;
        }
        #endregion

        private void rbConvAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConvAudio.Checked)
            {
                reloadConvAudio();
                if (Properties.Settings.Default.saveConvParams)
                {
                    // cbConvQuality.SelectedIndex = Properties.Settings.Default.convQuality;
                    cbConvFormat.SelectedIndex = Properties.Settings.Default.convFormat;
                }
            }
        }
        private void rbConvVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConvVideo.Checked)
            {
                reloadConvVideo();
                if (Properties.Settings.Default.saveConvParams)
                {
                    cbConvQuality.SelectedIndex = Properties.Settings.Default.convQuality;
                    cbConvFormat.SelectedIndex = Properties.Settings.Default.convFormat;
                }
            }
        }
    }
}
