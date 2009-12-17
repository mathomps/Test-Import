<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.uxRenameOperationsListBox = New System.Windows.Forms.ListBox
    Me.uxWatchFolderLabel = New System.Windows.Forms.Label
    Me.uxLastSequenceNumberLabel = New System.Windows.Forms.Label
    Me.uxGenerateRenamesRenameButton = New System.Windows.Forms.Button
    Me.uxRenameFilesButton = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(9, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(74, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Watch Folder:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(9, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(99, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Last Sequence No:"
    '
    'uxRenameOperationsListBox
    '
    Me.uxRenameOperationsListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.uxRenameOperationsListBox.FormattingEnabled = True
    Me.uxRenameOperationsListBox.Location = New System.Drawing.Point(12, 66)
    Me.uxRenameOperationsListBox.Name = "uxRenameOperationsListBox"
    Me.uxRenameOperationsListBox.Size = New System.Drawing.Size(340, 251)
    Me.uxRenameOperationsListBox.TabIndex = 2
    '
    'uxWatchFolderLabel
    '
    Me.uxWatchFolderLabel.Location = New System.Drawing.Point(114, 9)
    Me.uxWatchFolderLabel.Name = "uxWatchFolderLabel"
    Me.uxWatchFolderLabel.Size = New System.Drawing.Size(239, 18)
    Me.uxWatchFolderLabel.TabIndex = 3
    '
    'uxLastSequenceNumberLabel
    '
    Me.uxLastSequenceNumberLabel.Location = New System.Drawing.Point(114, 22)
    Me.uxLastSequenceNumberLabel.Name = "uxLastSequenceNumberLabel"
    Me.uxLastSequenceNumberLabel.Size = New System.Drawing.Size(71, 18)
    Me.uxLastSequenceNumberLabel.TabIndex = 4
    '
    'uxGenerateRenamesRenameButton
    '
    Me.uxGenerateRenamesRenameButton.Location = New System.Drawing.Point(12, 38)
    Me.uxGenerateRenamesRenameButton.Name = "uxGenerateRenamesRenameButton"
    Me.uxGenerateRenamesRenameButton.Size = New System.Drawing.Size(130, 23)
    Me.uxGenerateRenamesRenameButton.TabIndex = 5
    Me.uxGenerateRenamesRenameButton.Text = "Generate Renames"
    Me.uxGenerateRenamesRenameButton.UseVisualStyleBackColor = True
    '
    'uxRenameFilesButton
    '
    Me.uxRenameFilesButton.Location = New System.Drawing.Point(148, 38)
    Me.uxRenameFilesButton.Name = "uxRenameFilesButton"
    Me.uxRenameFilesButton.Size = New System.Drawing.Size(130, 23)
    Me.uxRenameFilesButton.TabIndex = 6
    Me.uxRenameFilesButton.Text = "Rename Them!"
    Me.uxRenameFilesButton.UseVisualStyleBackColor = True
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(364, 329)
    Me.Controls.Add(Me.uxRenameFilesButton)
    Me.Controls.Add(Me.uxGenerateRenamesRenameButton)
    Me.Controls.Add(Me.uxLastSequenceNumberLabel)
    Me.Controls.Add(Me.uxWatchFolderLabel)
    Me.Controls.Add(Me.uxRenameOperationsListBox)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Name = "MainForm"
    Me.Text = "Photo Renamer"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents uxRenameOperationsListBox As System.Windows.Forms.ListBox
  Friend WithEvents uxWatchFolderLabel As System.Windows.Forms.Label
  Friend WithEvents uxLastSequenceNumberLabel As System.Windows.Forms.Label
  Friend WithEvents uxGenerateRenamesRenameButton As System.Windows.Forms.Button
  Friend WithEvents uxRenameFilesButton As System.Windows.Forms.Button

End Class
