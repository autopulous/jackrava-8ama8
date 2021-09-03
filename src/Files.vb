Imports System.Windows.Forms

Public Class Files

    Private Sub FileList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileList.DoubleClick
        BringFormToFront()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        BringFormToFront()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BringFormToFront()
        Dim ThisFormatForm As Format

        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        If -1 <> FileList.SelectedIndex Then
            ThisFormatForm = Jackrava.FormatForms.Item(FileList.SelectedItem)
            ThisFormatForm.BringToFront()
        End If

        Me.Close()
    End Sub
End Class
