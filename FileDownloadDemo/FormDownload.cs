using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FileDownloadDemo
{
    public partial class FormDownload : Form
    {
        private const string STR_REMOTE_URI = @"https://upload.wikimedia.org/wikipedia/commons/b/b8/";
        private const string STR_FILE_NAME = "ESO_Very_Large_Telescope.jpg";

        public FormDownload()
        {
            InitializeComponent();
            m_mtx_file_downloading = new Mutex();
        }

        // Upon loading the form (which, in this program, is
        // done by the File Download Thread in FileDownloadThread()),
        // the download process will start.
        private void FormDownload_Load(object sender, EventArgs e)
        {
            DownloadFile();
        }

        // This method serves as the entry-point for the
        // File Download Thread (created in Main.cs).
        public static void FileDownloadThread()
        {
            try
            {
                // The following starts a UI Thread with
                // FormDownload as the foreground window.
                // Application.Run() will only return when
                // FormDownload closes.
                Application.Run(new FormDownload());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Closing FileDownloadThread.");
            }
        }

        // The OnClickHandler for btnCancelDownload.
        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            CancelDownload();
        }

        // This method is where the download process takes place.
        private void DownloadFile()
        {
            try
            {
                Uri uriWebResource = new Uri(STR_REMOTE_URI + STR_FILE_NAME);

                // Specify that the DownloadFileCallback() method gets called
                // when the download completes or has been cancelled.
                m_webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompletedCallback);
                m_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChangedCallback);

                // Download the Web resource and save it as a local file.
                m_webClient.DownloadFileAsync(uriWebResource, STR_FILE_NAME);

                // Update FileDownloading to show that a download is currently
                // in progress.
                FileDownloading = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // DownloadFileCompletedCallback() is a callback method that gets
        // called by m_webClient when download has completed or
        // has been cancelled.
        //
        // Note that DownloadFileCompletedCallback() may be called from
        // a thread separate from the DownloadFile() thread.
        public void DownloadFileCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Download cancelled.");
                File.Delete(STR_FILE_NAME);
            }

            FileDownloading = false;
            m_webClient.DownloadFileCompleted -= new AsyncCompletedEventHandler(DownloadFileCompletedCallback);
            this.Close();
        }

        // DownloadProgressChangedCallback() is a callback method that gets
        // called by m_webClient whenever there is a change in the file
        // download progress.
        //
        // Note that DownloadFileProgressChangedCallback() may be called from
        // a thread separate from the DownloadFile() thread.
        public void DownloadProgressChangedCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateLabelControl(lblNoOfBytesDownloaded, Convert.ToString(e.BytesReceived));
            UpdateLabelControl(lblPercentageCompleted, Convert.ToString(e.ProgressPercentage) + "%");
        }

        // FileDownloading is a property accessor 
        // that encapsulates the thread-safe acquisition
        // of the m_bFileDownloading boolean
        // variable.
        //
        // By using a Mutex, this property accessor ensures 
        // that only one thread is able to get/set the value 
        // for m_bFileDownloading.
        private bool FileDownloading
        {
            get
            {
                m_mtx_file_downloading.WaitOne();
                bool b_Ret = m_bFileDownloading;
                m_mtx_file_downloading.ReleaseMutex();

                return b_Ret;
            }

            set
            {
                m_mtx_file_downloading.WaitOne();
                m_bFileDownloading = value;
                m_mtx_file_downloading.ReleaseMutex();
            }
        }

        // This method is where the download cancellation
        // takes place. The CancelAsync() method of m_webClient
        // is called, cancelling the aynchronous download process.
        private void CancelDownload()
        {
            m_webClient.CancelAsync();
        }

        // A custom delegate method used for updating
        // the UI with data.
        public delegate void UIUpdateDelegate(Label lblControl, string strTextForUpdating);

        // This method takes in two parameters:
        //
        // 1. The Label control to update with data.
        // 
        // 2. A string which represents the data to display
        // on the label.
        //
        // The UIUpdateDelegate custom delegate was created for
        // this purpose.
        private void UpdateLabelControl(Label lblControl, string strTextForUpdating)
        {
            if (lblControl.InvokeRequired)
            {
                lblControl.BeginInvoke(new UIUpdateDelegate(UIUpdateMethod), new object[] { lblControl, strTextForUpdating });
            }
            else
            {
                lblControl.Text = strTextForUpdating;
            }
        }

        // This method will be executed in the thread 
        // where the label was created (e.g. in the 
        // main UI thread).
        private void UIUpdateMethod(Label lblControl, string strTextForUpdating)
        {
            lblControl.Text = strTextForUpdating;
        }

        // A WebClient that allows the file to be downloaded.
        private WebClient m_webClient = new WebClient();

        // A Mutex to control access to b_FileDownloading.
        private Mutex m_mtx_file_downloading;

        // A bool variable which states whether or not
        // the Web Client is currently downloading a file.
        private bool m_bFileDownloading = false;
    }
}
