Public Class Jackrava
    Private MoldFileName As String
    Private MoldCurrentDir As String
    Private SourceCurrentDir As String

    Public FormatForms As New Collection
    Private FileMenuItems As New Collection

    Private Sub SM2006_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FileMenuItems.Add(Me.ToolStripFileName1)
        FileMenuItems.Add(Me.ToolStripFileName2)
        FileMenuItems.Add(Me.ToolStripFileName3)
        FileMenuItems.Add(Me.ToolStripFileName4)
        FileMenuItems.Add(Me.ToolStripFileName5)
        FileMenuItems.Add(Me.ToolStripFileName6)
        FileMenuItems.Add(Me.ToolStripFileName7)
        FileMenuItems.Add(Me.ToolStripFileName8)
        FileMenuItems.Add(Me.ToolStripFileName9)
        FileMenuItems.Add(Me.ToolStripFileName10)
    End Sub

    Private Sub SM2006_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If "" = MoldFileName Then
            Me.ToolStripStatusLabel1.Text = "Active Mold: [default]"
        Else
            Me.ToolStripStatusLabel1.Text = "Active Mold: " & MoldFileName
        End If
    End Sub

    Private Sub SM2006_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        RebuildFileList()
    End Sub

    Private Sub SM2006_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If FormWindowState.Minimized = Me.WindowState Then
            For Each ThisFormatForm As Format In FormatForms
                If ThisFormatForm.Visible Then
                    ThisFormatForm.Hide()
                End If
            Next ThisFormatForm
        Else
            For Each ThisFormatForm As Format In FormatForms
                If Not ThisFormatForm.Visible Then
                    ThisFormatForm.Show()
                End If
            Next ThisFormatForm
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripFileName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName1.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName1.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName2.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName2.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName3.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName3.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName4.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName4.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName5.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName5.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName6.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName6.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName7.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName7.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName8.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName8.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName9.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName9.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripFileName10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFileName10.Click
        Dim ThisFormatForm As Format
        ThisFormatForm = FormatForms.Item(ToolStripFileName10.ToolTipText)
        ThisFormatForm.BringToFront()
    End Sub

    Private Sub ToolStripMenuItemMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMore.Click
        For Each ThisFormatForm As Format In FormatForms
            Files.FileList.Items.Add(ThisFormatForm.SourceFileName)
        Next

        Files.Show()
    End Sub

    Private Sub OpenFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFormatToolStripMenuItem.Click
        Dim Dialog As New OpenFileDialog()
        Dialog.AddExtension = True
        Dialog.CheckFileExists = True
        Dialog.CheckPathExists = True
        Dialog.DefaultExt = "*.mld"
        Dialog.DereferenceLinks = True
        Dialog.Multiselect = False
        Dialog.RestoreDirectory = True
        Dialog.ShowHelp = False
        Dialog.ShowReadOnly = False
        Dialog.SupportMultiDottedExtensions = True
        Dialog.Title = "Open a Mold File"
        Dialog.ValidateNames = True

        Dialog.InitialDirectory = MoldCurrentDir

        Dialog.Filter = "(Mold file) *.mld|*.mld|(All files) *.*|*.*"

        Dialog.ShowDialog()

        If (Dialog.FileName <> "") Then
            MoldFileName = Dialog.FileName
            MoldCurrentDir = Mid(Dialog.FileName, 1, InStrRev(Dialog.FileName, "\", , CompareMethod.Text) - 1)
            'Load Mold File
        End If
    End Sub

    Private Sub OpenSourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSourceToolStripMenuItem.Click
        Dim Dialog As New OpenFileDialog()

        Dialog.AddExtension = True
        Dialog.CheckFileExists = True
        Dialog.CheckPathExists = True
        Dialog.DefaultExt = ""
        Dialog.DereferenceLinks = True
        Dialog.Multiselect = True
        Dialog.RestoreDirectory = True
        Dialog.ShowHelp = False
        Dialog.ShowReadOnly = False
        Dialog.SupportMultiDottedExtensions = True
        Dialog.Title = "Open Source File(s)"
        Dialog.ValidateNames = False

        Dialog.InitialDirectory = SourceCurrentDir

        Dialog.Filter = "(C file) *.c;*.h|*.c;*.h|(C source) *.c|*.c|(C header) *.h|*.h|(All files) *.*|*.*"

        Dialog.ShowDialog()

        If (Dialog.FileName <> "") Then
            SourceCurrentDir = Mid(Dialog.FileName, 1, InStrRev(Dialog.FileName, "\", , CompareMethod.Text) - 1)

            For Each FileName As String In Dialog.FileNames

                Dim ThisFormatForm As New Format

                ThisFormatForm.SourceFileName = FileName
                ThisFormatForm.MoldFileName = MoldFileName
                ThisFormatForm.Show()

                FormatForms.Add(ThisFormatForm, FileName)
            Next FileName

            RebuildFileList()
        End If
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ThisFormatForm As Format In FormatForms
            ThisFormatForm.Close()
        Next ThisFormatForm
        RebuildFileList()
    End Sub

    Private Sub RebuildFileList()
        Dim Item As Integer
        Dim ThisFormatForm As Format

        'Clear out forms that have been closed from our managed list

        Item = 1

        While Item <= FormatForms.Count
            ThisFormatForm = FormatForms.Item(Item)

            If ThisFormatForm.Disposable Then
                ThisFormatForm.Dispose()
                FormatForms.Remove(Item)
            Else
                Item = Item + 1
            End If
        End While

        'Set the Windows drop down list

        Item = 1

        For Each ThisFileMenuItem As ToolStripMenuItem In FileMenuItems
            If Item <= FormatForms.Count Then
                ThisFormatForm = FormatForms.Item(Item)
                ThisFileMenuItem.Text = Mid(ThisFormatForm.SourceFileName, InStrRev(ThisFormatForm.SourceFileName, "\", -1, CompareMethod.Text) + 1)
                ThisFileMenuItem.ToolTipText = ThisFormatForm.SourceFileName
                ThisFileMenuItem.Visible = True
            Else
                ThisFileMenuItem.Text = ""
                ThisFileMenuItem.ToolTipText = ""
                ThisFileMenuItem.Visible = False
            End If
            Item = Item + 1
        Next

        If 10 >= FormatForms.Count Then
            ToolStripMenuItemMore.Enabled = False
        Else
            ToolStripMenuItemMore.Enabled = True
        End If

        If 0 = FormatForms.Count Then
            ToolStripSeparator3.Enabled = False
            Me.CloseAllToolStripMenuItem.Enabled = False
        Else
            ToolStripSeparator3.Enabled = True
            Me.CloseAllToolStripMenuItem.Enabled = True
        End If
    End Sub

End Class
