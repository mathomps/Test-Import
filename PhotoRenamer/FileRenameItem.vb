Imports System.IO

Public Class FileRenameItem

  Public OriginalFilename As String
  Public NewFilename As String
  Public OriginalModifiedDate As DateTime

  Public Overrides Function ToString() As String
    Return Path.GetFileName(OriginalFilename) & " -> " & Path.GetFileName(NewFilename)
  End Function

End Class
