
Partial Class Default2
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Request.QueryString("mediasrc") IsNot Nothing Then
      hdnMediaSourceID.Value = Request.QueryString("mediasrc")
      Dim g As Guid = New Guid(Request.QueryString("mediasrc"))



    End If
  End Sub

End Class
