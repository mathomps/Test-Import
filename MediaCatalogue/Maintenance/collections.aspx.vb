Imports System.Web.Configuration


Partial Class Maintenance_collections
    Inherits System.Web.UI.Page

  Protected Sub btnAddCollection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCollection.Click
    ds.InsertParameters.Add("description", "<new record>")
    ds.Insert()
  End Sub

End Class
