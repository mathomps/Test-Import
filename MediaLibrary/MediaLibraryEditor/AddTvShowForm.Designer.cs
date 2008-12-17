namespace MediaLibraryEditor
{
    partial class AddTvShowForm
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
            this.uxFilenameTextBox = new System.Windows.Forms.TextBox();
            this.uxBrowseFileButton = new System.Windows.Forms.Button();
            this.uxTvSeriesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uxAddEditButton = new System.Windows.Forms.Button();
            this.uxTtileTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename:";
            // 
            // uxFilenameTextBox
            // 
            this.uxFilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxFilenameTextBox.Location = new System.Drawing.Point(93, 10);
            this.uxFilenameTextBox.Name = "uxFilenameTextBox";
            this.uxFilenameTextBox.Size = new System.Drawing.Size(208, 20);
            this.uxFilenameTextBox.TabIndex = 1;
            // 
            // uxBrowseFileButton
            // 
            this.uxBrowseFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBrowseFileButton.Location = new System.Drawing.Point(307, 8);
            this.uxBrowseFileButton.Name = "uxBrowseFileButton";
            this.uxBrowseFileButton.Size = new System.Drawing.Size(28, 23);
            this.uxBrowseFileButton.TabIndex = 2;
            this.uxBrowseFileButton.Text = "...";
            this.uxBrowseFileButton.UseVisualStyleBackColor = true;
            // 
            // uxTvSeriesComboBox
            // 
            this.uxTvSeriesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTvSeriesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uxTvSeriesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.uxTvSeriesComboBox.FormattingEnabled = true;
            this.uxTvSeriesComboBox.Location = new System.Drawing.Point(93, 63);
            this.uxTvSeriesComboBox.Name = "uxTvSeriesComboBox";
            this.uxTvSeriesComboBox.Size = new System.Drawing.Size(242, 21);
            this.uxTvSeriesComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Series:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // uxDescriptionTextBox
            // 
            this.uxDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDescriptionTextBox.Location = new System.Drawing.Point(93, 90);
            this.uxDescriptionTextBox.Multiline = true;
            this.uxDescriptionTextBox.Name = "uxDescriptionTextBox";
            this.uxDescriptionTextBox.Size = new System.Drawing.Size(242, 97);
            this.uxDescriptionTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 95);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segments";
            // 
            // uxAddEditButton
            // 
            this.uxAddEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAddEditButton.Location = new System.Drawing.Point(260, 294);
            this.uxAddEditButton.Name = "uxAddEditButton";
            this.uxAddEditButton.Size = new System.Drawing.Size(75, 23);
            this.uxAddEditButton.TabIndex = 8;
            this.uxAddEditButton.Text = "Add";
            this.uxAddEditButton.UseVisualStyleBackColor = true;
            this.uxAddEditButton.Click += new System.EventHandler(this.uxAddEditButton_Click);
            // 
            // uxTtileTextBox
            // 
            this.uxTtileTextBox.Location = new System.Drawing.Point(93, 37);
            this.uxTtileTextBox.Name = "uxTtileTextBox";
            this.uxTtileTextBox.Size = new System.Drawing.Size(242, 20);
            this.uxTtileTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Title:";
            // 
            // AddTvShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 327);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxTtileTextBox);
            this.Controls.Add(this.uxAddEditButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uxDescriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxTvSeriesComboBox);
            this.Controls.Add(this.uxBrowseFileButton);
            this.Controls.Add(this.uxFilenameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddTvShowForm";
            this.Text = "Add/Edit TV Show";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxFilenameTextBox;
        private System.Windows.Forms.Button uxBrowseFileButton;
        private System.Windows.Forms.ComboBox uxTvSeriesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxDescriptionTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uxAddEditButton;
        private System.Windows.Forms.TextBox uxTtileTextBox;
        private System.Windows.Forms.Label label4;
    }
}