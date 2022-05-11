using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppVersionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Uri uri = new Uri("https://code.visualstudio.com/docs/?dv=win32user");
        string filename = @"C:\Users\cccadm\AppData\Local\Temp\example.exe";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string version = "1.0.0";
                string _updatedVersion = "1.1.0";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                else
                {
                    WebClient wc = new WebClient();
                    wc.DownloadDataAsync(uri, filename);
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //if (progressBar1.Value == progressBar1.Maximum)
            //{
            //    progressBar1.Value = 0;
            //}
        }
        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Download complete!, running exe", "Completed!");
                Process.Start(filename);
            }
            else
            {
                MessageBox.Show("Unable to download exe, please check your connection", "Download failed!");
            }
        }
    }
}
