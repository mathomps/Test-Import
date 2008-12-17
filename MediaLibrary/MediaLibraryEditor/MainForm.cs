using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaLibraryEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void uxEditTvToolStripButton_Click(object sender, EventArgs e)
        {
            AddTvShowForm frm = new AddTvShowForm(new Data.Media_Item(), true);
            frm.ShowDialog(this);
        }
    }
}
