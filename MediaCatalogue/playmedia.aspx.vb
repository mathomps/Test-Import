
Partial Class Default2
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim sectionIDString As String = Request.QueryString("sectionId")
    Dim sectionID As Guid
    Dim filePath As String = ""
    Dim offsetString As String = ""
    Dim offset As Integer = 0

    Dim mediaSourceTA As New MediaSourceTableAdapters.MediaSourceTableAdapter
    Dim mediaSectionTA As New MediaSourceTableAdapters.MediaSectionTableAdapter

    'Try

    If sectionIDString IsNot Nothing Then
      sectionID = New Guid(sectionIDString)

      Dim o As Object = mediaSourceTA.GetMediaSectionFilename(sectionID)
      If o IsNot Nothing Then
        filePath = DirectCast(o, String)
      End If

      offsetString = mediaSectionTA.GetSectionTimeOffset(sectionID)
      If offsetString <> "" Then
        offset = Integer.Parse(offsetString) / 1000
      End If

    End If

    ' Fix for UNC paths in MEdia Player URL
    filePath = "file:/" + filePath.Replace("\", "/")

    ClientScript.RegisterStartupScript(Me.GetType, "loadMedia", String.Format("document.Player.URL = '{0}' ; document.Player.controls.currentPosition = '{1}' ;", filePath, offset), True)

    'Catch ex As Exception

    'End Try

  End Sub

End Class
