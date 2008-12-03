using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaLibrary.Web
{
    public partial class collections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxAddButton_Click(object sender, EventArgs e)
        {
            Data.MediaLibraryDataContext db = new Data.MediaLibraryDataContext();
            Data.Collection coll = new Data.Collection();
            coll.CollectionID = Guid.NewGuid();
            coll.Description = uxNewCollectionTextBox.Text;
            db.Collections.InsertOnSubmit(coll);
            db.SubmitChanges();

            uxCollectionsGrid.DataBind();

            uxNewCollectionTextBox.Text = "";
        }
    }
}
