﻿using System;
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
    public partial class frmSupported : Form
    {
        public frmSupported()
        {
            InitializeComponent();
        }

        private void llbSupported_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://rg3.github.io/youtube-dl/supportedsites.html");
        }

    }
}
