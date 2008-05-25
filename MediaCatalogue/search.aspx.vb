
Partial Class Default2
    Inherits System.Web.UI.Page

  Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    BindSearchResults()
  End Sub

  Protected Sub ddlPresenter_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPresenter.DataBinding
    ' Clear all elements except the '(all)' one (which has an index of 0)
    Do While ddlPresenter.Items.Count > 1
      ddlPresenter.Items.RemoveAt(1)
    Loop

  End Sub

  Protected Sub grdResults_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim s As String
    For Each p As Parameter In SearchResultsDataSource.SelectParameters
      s = p.ToString
    Next
  End Sub

  Protected Sub txtKeywords_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKeywords.TextChanged
    BindSearchResults()
  End Sub



  Private Sub BindSearchResults()
    SearchResultsDataSource.SelectParameters("Keywords").DefaultValue = String.Format("%{0}%", txtKeywords.Text)
    grdResults.DataBind()
  End Sub

End Class
