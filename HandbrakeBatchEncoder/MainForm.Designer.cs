namespace HandbrakeBatchEncoder
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uxWatchFolderNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxEncodeQueueListView = new System.Windows.Forms.ListView();
            this.uxNowEncodingFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Watch Folder:";
            // 
            // uxWatchFolderNameLabel
            // 
            this.uxWatchFolderNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxWatchFolderNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxWatchFolderNameLabel.Location = new System.Drawing.Point(101, 9);
            this.uxWatchFolderNameLabel.Name = "uxWatchFolderNameLabel";
            this.uxWatchFolderNameLabel.Size = new System.Drawing.Size(317, 18);
            this.uxWatchFolderNameLabel.TabIndex = 1;
            this.uxWatchFolderNameLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Encode Queue:";
            // 
            // uxEncodeQueueListView
            // 
            this.uxEncodeQueueListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxEncodeQueueListView.Location = new System.Drawing.Point(101, 31);
            this.uxEncodeQueueListView.Name = "uxEncodeQueueListView";
            this.uxEncodeQueueListView.Size = new System.Drawing.Size(317, 115);
            this.uxEncodeQueueListView.TabIndex = 3;
            this.uxEncodeQueueListView.UseCompatibleStateImageBehavior = false;
            this.uxEncodeQueueListView.View = System.Windows.Forms.View.List;
            // 
            // uxNowEncodingFile
            // 
            this.uxNowEncodingFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNowEncodingFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxNowEncodingFile.Location = new System.Drawing.Point(101, 149);
            this.uxNowEncodingFile.Name = "uxNowEncodingFile";
            this.uxNowEncodingFile.Size = new System.Drawing.Size(317, 18);
            this.uxNowEncodingFile.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Now Encoding:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 176);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxNowEncodingFile);
            this.Controls.Add(this.uxEncodeQueueListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxWatchFolderNameLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Handbrake Batch Encoder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxWatchFolderNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView uxEncodeQueueListView;
        private System.Windows.Forms.Label uxNowEncodingFile;
        private System.Windows.Forms.Label label3;
    }
}

