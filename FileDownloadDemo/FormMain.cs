using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileDownloadDemo
{
    // Todo (19/6/2017):
    //
    // Once m_thd_file_download finishes running,
    // reset it to null.
    //
    // Hint: Use delegates.

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // The OnClickHandler for btnStartDownload.
        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            // If the thread is null or not alive (i.e. not running), we start
            // the thread.
            if ((m_thd_file_download == null) || (m_thd_file_download.IsAlive == false))
            {
                MessageBox.Show("Starting new thread.");

                // The entry-point of the thread will be the FileDownloadThread() static method
                // of the FormDownload class.
                m_thd_file_download = new Thread(new ThreadStart(FormDownload.FileDownloadThread));
                m_thd_file_download.Start();
            }
        }

        // The thread that starts the download activity.
        // Initially set to null.
        //
        // NOTE: This is not necessariy the same thread
        // that performs the download, since we are doing
        // the download Asynchronously.
        private Thread m_thd_file_download = null;
    }
}
