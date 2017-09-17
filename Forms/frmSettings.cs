using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private void frmSettings_Shown(object sender, EventArgs e)
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
                Properties.Settings.Default.HoverURL = chkHoverURL.Checked;
        }
        private void chkAutoClearURL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoClearURL.Checked != Properties.Settings.Default.ClearURL)
                Properties.Settings.Default.ClearURL = chkAutoClearURL.Checked;
        }
        private void chkDeleteExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteExecutable.Checked != Properties.Settings.Default.DeleteAfterClose)
                Properties.Settings.Default.DeleteAfterClose = chkDeleteExecutable.Checked;
        }
        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdate.Checked != Properties.Settings.Default.UpdateDL)
                Properties.Settings.Default.UpdateDL = chkUpdate.Checked;
        }
        private void numUpdateDays_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numUpdateDays.Value) != Properties.Settings.Default.DaysBetweenUpdate)
                Properties.Settings.Default.DaysBetweenUpdate = Convert.ToInt32(numUpdateDays.Value);
        }
        private void chkSaveArgs_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.saveArgs != chkSaveArgs.Checked)
                Properties.Settings.Default.saveArgs = chkSaveArgs.Checked;
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
            frmMain.DownloadYoutubeDL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
