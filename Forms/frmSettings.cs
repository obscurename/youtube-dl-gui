using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using youtube_dl_gui.Classes;

namespace youtube_dl_gui.Forms
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Shown(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            chkHoverURL.Checked = Properties.Settings.Default.HoverURL;
            chkAutoClearURL.Checked = Properties.Settings.Default.ClearURL;
            chkDeleteExecutable.Checked = Properties.Settings.Default.DeleteAfterClose;
            chkUpdate.Checked = Properties.Settings.Default.UpdateDL;
            numUpdateDays.Value = Convert.ToDecimal(Properties.Settings.Default.DaysBetweenUpdate);
            txtDownloadLocation.Text = Properties.Settings.Default.DownloadDir;
        }

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
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to save downloads to", RootFolder = Environment.SpecialFolder.UserProfile };
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
            GlobalFunctions.DownloadYoutubeDL();
        }

    }
}
