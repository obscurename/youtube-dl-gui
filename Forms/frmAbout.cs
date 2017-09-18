using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        private void frmAbout_Shown(object sender, EventArgs e)
        {
            lbVersion.Text = Properties.Settings.Default.appVersion;
        }

        #region Updater
        private async void CheckForUpdate()
        {
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
        #endregion

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void pbIcon_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/obscurename/youtube-dl-gui/");
        }


    }
}
