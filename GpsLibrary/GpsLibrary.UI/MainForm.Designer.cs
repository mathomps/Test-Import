namespace GpsLibrary.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.uxInitialiseMenuItem = new System.Windows.Forms.MenuItem();
            this.uxDebugText = new System.Windows.Forms.TextBox();
            this.uxClearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxLatitudeLabel = new System.Windows.Forms.Label();
            this.uxLongitudeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxSpeedLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.uxTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uxBearingLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.uxInitialiseMenuItem);
            // 
            // uxInitialiseMenuItem
            // 
            this.uxInitialiseMenuItem.Text = "Initialise";
            this.uxInitialiseMenuItem.Click += new System.EventHandler(this.uxInitialiseMenuItem_Click);
            // 
            // uxDebugText
            // 
            this.uxDebugText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDebugText.Location = new System.Drawing.Point(3, 3);
            this.uxDebugText.Multiline = true;
            this.uxDebugText.Name = "uxDebugText";
            this.uxDebugText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxDebugText.Size = new System.Drawing.Size(231, 173);
            this.uxDebugText.TabIndex = 0;
            // 
            // uxClearButton
            // 
            this.uxClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxClearButton.Location = new System.Drawing.Point(146, 182);
            this.uxClearButton.Name = "uxClearButton";
            this.uxClearButton.Size = new System.Drawing.Size(88, 20);
            this.uxClearButton.TabIndex = 2;
            this.uxClearButton.Text = "Clear";
            this.uxClearButton.Click += new System.EventHandler(this.uxClearButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.Text = "Lat:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.Text = "Long:";
            // 
            // uxLatitudeLabel
            // 
            this.uxLatitudeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uxLatitudeLabel.Location = new System.Drawing.Point(45, 4);
            this.uxLatitudeLabel.Name = "uxLatitudeLabel";
            this.uxLatitudeLabel.Size = new System.Drawing.Size(100, 20);
            this.uxLatitudeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uxLongitudeLabel
            // 
            this.uxLongitudeLabel.BackColor = System.Drawing.Color.Silver;
            this.uxLongitudeLabel.Location = new System.Drawing.Point(45, 24);
            this.uxLongitudeLabel.Name = "uxLongitudeLabel";
            this.uxLongitudeLabel.Size = new System.Drawing.Size(100, 20);
            this.uxLongitudeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.Text = "Speed:";
            // 
            // uxSpeedLabel
            // 
            this.uxSpeedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.uxSpeedLabel.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular);
            this.uxSpeedLabel.Location = new System.Drawing.Point(61, 61);
            this.uxSpeedLabel.Name = "uxSpeedLabel";
            this.uxSpeedLabel.Size = new System.Drawing.Size(162, 59);
            this.uxSpeedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 157);
            this.tabControl1.TabIndex = 10;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.uxBearingLabel);
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Controls.Add(this.uxTimeLabel);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.uxSpeedLabel);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Controls.Add(this.label3);
            this.tabInfo.Controls.Add(this.uxLatitudeLabel);
            this.tabInfo.Controls.Add(this.uxLongitudeLabel);
            this.tabInfo.Location = new System.Drawing.Point(0, 0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(317, 134);
            this.tabInfo.Text = "Info";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.uxDebugText);
            this.tabDebug.Controls.Add(this.uxClearButton);
            this.tabDebug.Location = new System.Drawing.Point(0, 0);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(237, 214);
            this.tabDebug.Text = "Debug";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(167, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.Text = "Time:";
            // 
            // uxTimeLabel
            // 
            this.uxTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uxTimeLabel.Location = new System.Drawing.Point(220, 4);
            this.uxTimeLabel.Name = "uxTimeLabel";
            this.uxTimeLabel.Size = new System.Drawing.Size(67, 20);
            this.uxTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(167, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.Text = "Bearing:";
            // 
            // uxBearingLabel
            // 
            this.uxBearingLabel.BackColor = System.Drawing.Color.Silver;
            this.uxBearingLabel.Location = new System.Drawing.Point(220, 24);
            this.uxBearingLabel.Name = "uxBearingLabel";
            this.uxBearingLabel.Size = new System.Drawing.Size(67, 20);
            this.uxBearingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(320, 188);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "GPS Test";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uxDebugText;
        private System.Windows.Forms.Button uxClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label uxLatitudeLabel;
        private System.Windows.Forms.Label uxLongitudeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label uxSpeedLabel;
        private System.Windows.Forms.MenuItem uxInitialiseMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Label uxTimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label uxBearingLabel;
        private System.Windows.Forms.Label label5;
    }
}

