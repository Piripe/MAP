Imports System.Runtime.InteropServices
Public Class MusicFrequenciesOverlay

    Dim LeftAmplitude(128) As Int32
    Dim RightAmplitude(128) As Int32


    Public Drawing_Mode As Int32 = 0
    Public Drawing_X As Int32 = 225
    Public Drawing_Y As Int32 = 225
    Public Drawing_Size As Double = 1

    Public ColorR = 0
    Public ColorG = 0
    Public ColorB = 0

    Public Sensibility = 0

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function

    Private Sub OverlayGestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(0, My.Computer.Screen.WorkingArea.Height / 4 * 3)
        Size = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height / 4 * 1)

        'SetWindowLong(Me.Handle, -20, GetWindowLong(Me.Handle, -20) Or &H80000 Or &H20)

    End Sub

    Sub Tick() Handles MFTickTimer.Tick
        MsgBox("Pre Tick")
        Dim LeftAmplitude_(128) As Int32
        Dim RightAmplitude_(128) As Int32
        Dim StereoAmplitude(257) As String
        'music_player.GetFFTData(2048, TFFTWindow.fwRectangular, HarmonicNumber_, HarmonicFreq_, LeftAmplitude_, RightAmplitude_, LeftPhase_, RightPhase_)
        MsgBox("Tick 1")
        StereoAmplitude = Console.In.ReadToEnd().Split(" ")
        Dim min = Math.Min(RightAmplitude_.Max() / (1.5 + Sensibility / 10), LeftAmplitude_.Max() / (1.5 + Sensibility / 10))
        Dim new_thing = False
        For i = 0 To 127
            Try
                RightAmplitude_(i) = StereoAmplitude(i)
                LeftAmplitude_(i) = StereoAmplitude(128 + i)
            Catch
                RightAmplitude_(i) = RightAmplitude(i)
                LeftAmplitude_(i) = LeftAmplitude(i)
            End Try
            If Not (RightAmplitude(i) = RightAmplitude_(i) And LeftAmplitude(i) = LeftAmplitude_(i)) Then new_thing = True
            RightAmplitude(i) = Math.Max(2, (RightAmplitude(i) + (Math.Max(0, RightAmplitude_(i) - min) ^ 1.2 - RightAmplitude(i)) / 5))
            LeftAmplitude(i) = Math.Max(2, (LeftAmplitude(i) + (Math.Max(0, LeftAmplitude_(i) - min) ^ 1.2 - LeftAmplitude(i)) / 5))
        Next

        MsgBox("Tick 2")

        'If MusicModule.Playlist.Count > 0 And new_thing Then 
        MFPictureBox.Invalidate()
        MsgBox("Ticked")
    End Sub

    Private Sub RenderFrame(sender As Object, e As PaintEventArgs) Handles MFPictureBox.Paint
        Dim BarsColorBrush As New SolidBrush(Color.FromArgb(ColorR, ColorG, ColorB))
        Dim g = e.Graphics
        'Dim flag As New Bitmap(PictureBox1.Size.Width, PictureBox1.Size.Height)
        'Using g = Graphics.FromImage(flag)
        g.CompositingMode = Drawing2D.CompositingMode.SourceOver
        g.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed

        If Drawing_Mode = 0 Then
            Dim UV_Rectangles = New List(Of Rectangle)
            For i = 0 To 127
                UV_Rectangles.Add(New Rectangle(i * (MFPictureBox.Size.Width / 128), MFPictureBox.Size.Height - (RightAmplitude(i) ^ 2) / 15 * Drawing_Size, (MFPictureBox.Size.Width / 128) / 1.5, (RightAmplitude(i) ^ 2) / 15 * Drawing_Size))
            Next
            g.FillRectangles(BarsColorBrush, UV_Rectangles.ToArray)
        ElseIf Drawing_Mode = 1 Then
            Dim UV_Points = New List(Of Point)
            UV_Points.Add(New Point(0, MFPictureBox.Size.Height))
            For i = 0 To 127
                UV_Points.Add(New Point(i * (MFPictureBox.Size.Width / 128), MFPictureBox.Size.Height - (RightAmplitude(i) ^ 2) / 15 * Drawing_Size))
            Next
            UV_Points.Add(New Point(MFPictureBox.Size.Width, MFPictureBox.Size.Height))
            g.FillClosedCurve(BarsColorBrush, UV_Points.ToArray)
        ElseIf Drawing_Mode = 2 Then
            g.TranslateTransform(Drawing_X, Drawing_Y)
            For i = 0 To 127
                g.FillRectangle(BarsColorBrush, New Rectangle(-2 * Drawing_Size, 50 * Drawing_Size, 4 * Drawing_Size, RightAmplitude(i) / 2 * Drawing_Size))
                g.RotateTransform(360 / 256)
            Next
            For i = 127 To 0 Step -1
                g.FillRectangle(BarsColorBrush, New Rectangle(-2 * Drawing_Size, 50 * Drawing_Size, 4 * Drawing_Size, LeftAmplitude(i) / 2 * Drawing_Size))
                g.RotateTransform(360 / 256)
            Next
            g.TranslateTransform(Drawing_X * -1, Drawing_Y * -1)
        ElseIf Drawing_Mode = 3 Then
            Dim gp As New Drawing2D.GraphicsPath
            gp.FillMode = Drawing2D.FillMode.Alternate
            gp.AddEllipse(CInt(Drawing_X - 50 * Drawing_Size), CInt(Drawing_Y - 50 * Drawing_Size), CInt(100 * Drawing_Size), CInt(100 * Drawing_Size))
            gp.AddRectangle(New Rectangle(0, 0, MFPictureBox.Size.Width, MFPictureBox.Size.Height))
            g.SetClip(gp)
            g.TranslateTransform(Drawing_X, Drawing_Y)
            For i = 0 To 127
                g.FillEllipse(BarsColorBrush, New Rectangle(-8 * Drawing_Size, 0, 16 * Drawing_Size, (RightAmplitude(i) / 2 * Drawing_Size) + (50 * Drawing_Size)))
                g.RotateTransform(360 / 256)
            Next
            For i = 127 To 0 Step -1
                g.FillEllipse(BarsColorBrush, New Rectangle(-8 * Drawing_Size, 0, 16 * Drawing_Size, (LeftAmplitude(i) / 2 * Drawing_Size) + (50 * Drawing_Size)))
                g.RotateTransform(360 / 256)
            Next
            g.TranslateTransform(Drawing_X * -1, Drawing_Y * -1)
        End If
        'End Using
        'If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
        'PictureBox1.Image = flag
    End Sub
End Class
