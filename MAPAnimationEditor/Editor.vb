Public Class Editor
    Dim TimeLine_Scroll As Int32 = 0
    Dim TimeLine_Zoom As Int32
    Dim pjt As Project = New Project

    Private Sub TimeLinePictureBox_Paint(sender As Object, e As PaintEventArgs) Handles TimeLinePictureBox.Paint
        Dim g = e.Graphics
        Dim mse_pos = TimeLinePictureBox.PointToClient(MousePosition)
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
        g.DrawEllipse(New Pen(Color.WhiteSmoke, 2), mse_pos.X - 10, mse_pos.Y - 10, 20, 20)
        g.DrawString(pjt.LastChange, DefaultFont, Brushes.White, 20, 20)
    End Sub

    Private Sub TimeLinePictureBox_Click(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove

    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        TimeLinePictureBox.Refresh()
    End Sub
End Class
