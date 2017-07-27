namespace FileDownloadDemo
{
    partial class FormDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoOfBytesDownloaded = new System.Windows.Forms.Label();
            this.lblPercentageCompleted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.Location = new System.Drawing.Point(12, 118);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(461, 34);
            this.btnCancelDownload.TabIndex = 1;
            this.btnCancelDownload.Text = "Cancel Download";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "No. of bytes downloaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Percentage completed";
            // 
            // lblNoOfBytesDownloaded
            // 
            this.lblNoOfBytesDownloaded.AutoSize = true;
            this.lblNoOfBytesDownloaded.Location = new System.Drawing.Point(212, 13);
            this.lblNoOfBytesDownloaded.Name = "lblNoOfBytesDownloaded";
            this.lblNoOfBytesDownloaded.Size = new System.Drawing.Size(0, 17);
            this.lblNoOfBytesDownloaded.TabIndex = 4;
            // 
            // lblPercentageCompleted
            // 
            this.lblPercentageCompleted.AutoSize = true;
            this.lblPercentageCompleted.Location = new System.Drawing.Point(212, 52);
            this.lblPercentageCompleted.Name = "lblPercentageCompleted";
            this.lblPercentageCompleted.Size = new System.Drawing.Size(0, 17);
            this.lblPercentageCompleted.TabIndex = 5;
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 164);
            this.Controls.Add(this.lblPercentageCompleted);
            this.Controls.Add(this.lblNoOfBytesDownloaded);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDownload);
            this.Name = "FormDownload";
            this.Text = "FormDownload";
            this.Load += new System.EventHandler(this.FormDownload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoOfBytesDownloaded;
        private System.Windows.Forms.Label lblPercentageCompleted;
    }
}