Imports System.IO



Public Class MainForm

  Private Const m_SequenceFilename As String = "seq.txt"
  Private WithEvents m_FolderWatcher As FileSystemWatcher

  Private m_FileExtensions As String() = {".avi", ".jpg", ".jpeg"}

  Dim m_FileRenameList As List(Of FileRenameItem)


  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    uxWatchFolderLabel.Text = My.Settings.WatchFolder
    uxLastSequenceNumberLabel.Text = GetLastSequenceNumber.ToString("0000")

    m_FolderWatcher = New FileSystemWatcher(My.Settings.WatchFolder, "*.jpg")
    m_FolderWatcher.EnableRaisingEvents = True

  End Sub


#Region "--  UI Events  --"

  Private Sub uxGenerateRenamesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxGenerateRenamesRenameButton.Click
    GenerateRenameFiles()
  End Sub

  Private Sub uxRenameFilesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxRenameFilesButton.Click
    RenameFiles()
  End Sub

#End Region

#Region "--  Private Methods  --"

  '--  Sequence NumberHandling  --

  Private Function GetLastSequenceNumber() As Integer

    Dim filename As String = Path.Combine(My.Settings.WatchFolder, m_SequenceFilename)

    If Not File.Exists(filename) Then Return 0

    Dim lines As String = File.ReadAllText(filename)
    Dim seqNo As Integer

    If Integer.TryParse(lines, seqNo) Then
      Return seqNo
    End If

    Return 0

  End Function

  Private Sub UpdateSequenceNumber(ByVal newSequenceNumber As Integer)
    Dim filename As String = Path.Combine(My.Settings.WatchFolder, m_SequenceFilename)
    File.WriteAllText(filename, newSequenceNumber.ToString)
  End Sub

  Private Sub GenerateRenameFiles()

    Dim dir As New DirectoryInfo(My.Settings.WatchFolder)

    If Not dir.Exists Then Return

    Dim sortedFiles = dir.GetFiles().OrderBy(Function(file) file.LastWriteTime)
    Dim files = sortedFiles.Where(Function(file) m_FileExtensions.Contains(Path.GetExtension(file.Name.ToLower())))

    m_FileRenameList = New List(Of FileRenameItem)

    For Each file As FileInfo In files
      Dim renameItem As New FileRenameItem() With {.OriginalFilename = file.FullName, _
                                                 .OriginalModifiedDate = file.LastWriteTime, _
                                                 .NewFilename = AllocateNextFilename(file.FullName) _
                                               }
      m_FileRenameList.Add(renameItem)

      uxRenameOperationsListBox.Items.Add(renameItem)

    Next

  End Sub

  Private Sub RenameFiles()
    If m_FileRenameList Is Nothing Then Return
    For Each fr In m_FileRenameList
      If File.Exists(fr.OriginalFilename) Then
        File.Move(fr.OriginalFilename, fr.NewFilename)
        File.AppendAllText(Path.Combine(My.Settings.WatchFolder, "renames.txt"), fr.ToString() & ControlChars.CrLf)
      End If
    Next
  End Sub

  Private Function AllocateNextFilename(ByVal originalFilename As String) As String
    Dim seqNo As Integer = GetLastSequenceNumber() + 1
    Dim filename As String = Path.Combine(My.Settings.WatchFolder, My.Settings.FilePrefix) & seqNo.ToString("0000") & Path.GetExtension(originalFilename)
    Do While File.Exists(filename)
      seqNo += 1
      filename = Path.Combine(My.Settings.WatchFolder, My.Settings.FilePrefix) & seqNo.ToString("0000") & Path.GetExtension(originalFilename)
    Loop
    UpdateSequenceNumber(seqNo)
    Return filename
  End Function

#End Region

End Class
