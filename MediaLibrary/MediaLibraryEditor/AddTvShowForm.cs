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
    public partial class AddTvShowForm : Form
    {
        private bool m_IsNewRecord;
        private Data.Media_Item m_MediaItem;

        public AddTvShowForm(Data.Media_Item mediaItem, bool isNew)
        {
            InitializeComponent();

            m_MediaItem = mediaItem;
            m_IsNewRecord = isNew;

            if (isNew)
            {
                uxAddEditButton.Text = "Add";
            }
            else
            {
                uxAddEditButton.Text = "Update";
            }


            // Populate TV Series ComboBox
            uxTvSeriesComboBox.ValueMember = "id";
            uxTvSeriesComboBox.DisplayMember = "Description";
            uxTvSeriesComboBox.DataSource = from series in Global.DataContext.TV_Series
                                            select series;
            
        }

        private void uxAddEditButton_Click(object sender, EventArgs e)
        {
            if (uxTvSeriesComboBox.SelectedValue == null)
            {
                // Add a new TV Series entry
                string seriesName = uxTvSeriesComboBox.Text;
                m_MediaItem.Title = "foo";
                m_MediaItem.Description = ux
            }


            if (m_IsNewRecord)
            {
                Global.DataContext.Media_Items.InsertOnSubmit(m_MediaItem);
            }

            Global.DataContext.SubmitChanges();
        }
    }
}
