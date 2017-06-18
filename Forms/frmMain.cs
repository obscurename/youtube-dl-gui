using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using youtube_dl_gui.Classes;
using youtube_dl_gui.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace youtube_dl_gui
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Form settingsForm = new frmSettings();

        private void CheckForUpdate()
        {
            if (Properties.Settings.Default.UpdateDL == true)
            {
                DateTime PreviousUpdated = Properties.Settings.Default.DateLastUpdated;
                DateTime TodayDate = DateTime.Now;
                if ((PreviousUpdated - TodayDate).TotalDays > Properties.Settings.Default.DaysBetweenUpdate)
                {
                    GlobalFunctions.DownloadYoutubeDL();
                }
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.DownloadDir))
            {
                MessageBox.Show("Please select a directory to save downloaded files", "Youtube-DL GUI", MessageBoxButtons.OK);
                FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder for videos to download to", RootFolder = Environment.SpecialFolder.UserProfile };
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
            }

            if (!File.Exists(Application.StartupPath + "\\youtube-dl.exe"))
            {
                GlobalFunctions.DownloadYoutubeDL();
            }

            CheckForUpdate();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.DeleteAfterClose == true)
            {
                File.Delete(Application.StartupPath + "\\youtube-dl.exe");
            }
        }

        #region Downloader
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
            if (!txtURL.Text.Contains("youtube.com/watch?v="))
            {
                gbDownloadAs.Enabled = false;
                rbVideo.Checked = true;
            }else{
                gbDownloadAs.Enabled = true;
            }
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
            StartDownload(txtURL.Text, txtArgs.Text);
        }

        private void StartDownload(string URL, string Args)
        {
            string OutputFolder = "-o " + Properties.Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s ";

            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                MessageBox.Show("Please enter a URL before attempting to download a video.", "Youtube-DL GUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process Downloader = new Process();
            Downloader.StartInfo.FileName = Application.StartupPath + "/youtube-dl.exe";

            if (rbVideo.Checked)
            {
                Downloader.StartInfo.Arguments = OutputFolder + "\"" + URL + "\"";
            }
            else if (rbAudio.Checked)
            {
                Downloader.StartInfo.Arguments = OutputFolder + "-x --audio-format " + cbFormat.SelectedItem + " --audio-quality " + cbQuality.SelectedItem + " " + "\"" + URL + "\"";
            }
            else if (rbCustom.Checked)
            {
                Downloader.StartInfo.Arguments = Args + " \"" + URL + "\"";
            }

            Downloader.StartInfo.UseShellExecute = false;
            Downloader.StartInfo.CreateNoWindow = false;
            Downloader.Start();
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
        #region About
        private void btnOptions_Click(object sender, EventArgs e)
        {
            settingsForm.Show();
        }
        #endregion
    }
}
