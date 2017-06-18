using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace youtube_dl_gui.Classes
{
    class GlobalFunctions
    {
        #region Youtube-DL Downloading
        public static string ReadLine(int LineWanted, List<string> LineList)
        {
            return LineList[LineWanted - 1];
        }
        public static string GetVersion()
        {
            string URL = "https://rg3.github.io/youtube-dl/download.html";
            RichTextBox DownloadedHTML = new RichTextBox { Text = new WebClient().DownloadString(URL) };
            string SourceTrim = ReadLine(19, DownloadedHTML.Lines.ToList());
            DownloadedHTML.Clear();
            return SourceTrim.Substring(64, SourceTrim.Length - 147);
            // Replace(".", "/") to get Date/Time yyyy/MM/dd Convert.ToDateTime();
        }

        public static bool DownloadYoutubeDL()
        {
            string YoutubeDLVersion = GetVersion();
            string YtDl = "https://github.com/rg3/youtube-dl/releases/download/" + YoutubeDLVersion + "/youtube-dl.exe";

            RetryDownload:
            try
            {
                WebClient DownloadFile = new WebClient();
                DownloadFile.DownloadFile(YtDl, Application.StartupPath + "\\youtube-dl.part");
                if (File.Exists(Application.StartupPath + "\\youtube-dl.exe"))
                {
                    File.Delete(Application.StartupPath + "\\youtube-dl.exe");
                }
                File.Move(Application.StartupPath + "\\youtube-dl.part", Application.StartupPath + "\\youtube-dl.exe");
                Properties.Settings.Default.DateLastUpdated = DateTime.Now;
                return true;
            }
            catch (Exception ex)
            {
                switch (MessageBox.Show("An exception has occured. Please open an issue with the following:\n\n" + ex.ToString(), "Youtube-DL GUI", MessageBoxButtons.RetryCancel))
                {
                    case DialogResult.Retry:
                        goto RetryDownload;
                }
                return false;
            }
        }
        #endregion
    }
}
