﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {

        public frmAbout() {
            InitializeComponent();
        }
        private void frmAbout_Shown(object sender, EventArgs e) {
            lbVersion.Text = "v" + Properties.Settings.Default.currentVersion.ToString();
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Thread checkUpdates = new Thread(() => {
                decimal cV = Updater.getCloudVersion();
                if (Updater.isUpdateAvailable(cV)) {
                    if (MessageBox.Show("An update is available.\nNew verison: " + cV.ToString() + " | Your version: " + Properties.Settings.Default.currentVersion.ToString() + "\n\nWould you like to update?", "youtube-dl-gui", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                        Updater.createUpdaterStub(cV);
                        Updater.runUpdater();
                    }
                }
            });
        }
        private void pbIcon_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui/");
        }
    }
}
