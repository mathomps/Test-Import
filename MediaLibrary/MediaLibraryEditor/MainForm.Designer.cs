namespace MediaLibraryEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uxStandardToolStrip = new System.Windows.Forms.ToolStrip();
            this.uxEditTvToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uxStandardToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStandardToolStrip
            // 
            this.uxStandardToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxEditTvToolStripButton});
            this.uxStandardToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uxStandardToolStrip.Name = "uxStandardToolStrip";
            this.uxStandardToolStrip.Size = new System.Drawing.Size(659, 25);
            this.uxStandardToolStrip.TabIndex = 0;
            this.uxStandardToolStrip.Text = "Standard";
            // 
            // uxEditTvToolStripButton
            // 
            this.uxEditTvToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxEditTvToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("uxEditTvToolStripButton.Image")));
            this.uxEditTvToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxEditTvToolStripButton.Name = "uxEditTvToolStripButton";
            this.uxEditTvToolStripButton.Size = new System.Drawing.Size(78, 22);
            this.uxEditTvToolStripButton.Text = "Edit TV Shows";
            this.uxEditTvToolStripButton.ToolTipText = "Edit TV Shows";
            this.uxEditTvToolStripButton.Click += new System.EventHandler(this.uxEditTvToolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 279);
            this.Controls.Add(this.uxStandardToolStrip);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.uxStandardToolStrip.ResumeLayout(false);
            this.uxStandardToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uxStandardToolStrip;
        private System.Windows.Forms.ToolStripButton uxEditTvToolStripButton;
    }
}

