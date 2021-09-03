Public Class Format
    Public MoldFileName As String
    Public SourceFileName As String
    Public Disposable As Boolean

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub Format_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'When already Disposable, the parent form is officially closing this form, so let it do so
        If Not Me.Disposable Then
            'Don't let the form close itself
            Me.Disposable = True
            Me.Visible = False
            Me.Activate()
        End If
    End Sub

    Private Sub Format_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Disposable = False

        Me.Text = SourceFileName

        Me.RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(SourceFileName)

        If "" = MoldFileName Then
            Me.ToolStripStatusLabel1.Text = "Active Mold: [default]"
        Else
            Me.ToolStripStatusLabel1.Text = "Active Mold: " & MoldFileName
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText(RichTextBox1.SelectedText, TextDataFormat.Text)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub RichTextBox1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        If (0 = RichTextBox1.SelectionLength) Then
            CopyToolStripMenuItem.Enabled = False
            FormatSelectionToolStripMenuItem.Enabled = False
        Else
            CopyToolStripMenuItem.Enabled = True
            FormatSelectionToolStripMenuItem.Enabled = True
        End If
    End Sub

End Class