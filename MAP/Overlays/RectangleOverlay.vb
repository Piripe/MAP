Imports System.Text.RegularExpressions
Public Class RectangleOverlay
    Implements Overlay.IOverlay
    Public Property Settings As Object = New CustomOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
        New Overlay.Setting("Color", Overlay.Setting.SettingType.Color, "Color")
        }.ToList Implements Overlay.IOverlay.ClientSettings

    Public Property RefreshDelay As Overlay.RefreshDelay = Overlay.RefreshDelay.Ms1000 Implements Overlay.IOverlay.RefreshDelay

    Public ReadOnly Property Dependences As String() Implements Overlay.IOverlay.Dependences
        Get
            Return {}
        End Get
    End Property

    Public ReadOnly Property Icon As Icon = My.Resources.map_icon Implements Overlay.IOverlay.Icon

    Public Function Save() As XElement Implements Overlay.IOverlay.Save
        Dim xDoc As New XElement("settings",
                New XElement("Color", Settings.Color.ToARGB())
                )
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.Color = Color.FromArgb(code.Element("settings").Element("Color").Value)
        End If
    End Sub

    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick

        Dim BarsColorBrush As New SolidBrush(Settings.Color)
        Dim flag As New Bitmap(Size.Width, Size.Height)
        Using g = Graphics.FromImage(flag)
            g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            If Quality = Overlay.Quality.High Then
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Else
                g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
                g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            End If

            'g.CopyFromScreen(New Point(10, 10), New Point(0, 0), Size)
            g.FillRectangle(BarsColorBrush, 0, 0, Size.Width, Size.Height)
        End Using

        Return flag
    End Function

    Private Class CustomOptions
        Property Color As Color = Color.FromArgb(255, 255, 255)
    End Class
End Class