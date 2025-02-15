Public Class ReadonlyTextboxDialog
    Property ReadOnlyText As String = ""
    Private Sub OverlaysTabButton_Click(sender As Object, e As EventArgs) Handles OverlaysTabButton.Click
        Close()
    End Sub

    Private Sub ReadonlyTextboxDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ReadOnlyText
    End Sub
End Class