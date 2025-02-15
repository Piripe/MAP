Imports System.Text.RegularExpressions
Public Class ImageOverlay
    Implements Overlay.IOverlay
    Public Property Settings As Object = New ImageOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
        New Overlay.Setting("Image Path", Overlay.Setting.SettingType.TextBox, "ImagePath"),
        New Overlay.Setting("Thumbnail Resize Mode", Overlay.Setting.SettingType.ComboBox, "Thumbnail_Resize_Mode", {"Zoom Inner", "Zoom Outter", "Stretch"}),
        New Overlay.Setting("Round Corner", Overlay.Setting.SettingType.Trackbar, "RoundCorner", Min_:=0, Max_:=97)
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
                New XElement("ImagePath", Settings.ImagePath),
                New XElement("Thumbnail_Resize_Mode", Settings.Thumbnail_Resize_Mode),
                New XElement("RoundCorner", Settings.RoundCorner)
                )
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.ImagePath = code.Element("settings").Element("ImagePath").Value
            Settings.Thumbnail_Resize_Mode = code.Element("settings").Element("Thumbnail_Resize_Mode").Value
            Settings.RoundCorner = code.Element("settings").Element("RoundCorner").Value
        End If
    End Sub

    Dim last_write = New Date(0)
    Dim last_settings = New ImageOptions
    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick

        Dim tmp_last_write = IO.File.GetLastWriteTime(Settings.ImagePath)
        If (tmp_last_write <> last_write) Or (CType(Settings, ImageOptions).Equals(CType(last_settings, ImageOptions))) Then
            Dim new_image = Image.FromFile(Settings.ImagePath)
            Dim flag As New Bitmap(Size.Width, Size.Height)
            Using g = Graphics.FromImage(flag)
                g.CompositingMode = Drawing2D.CompositingMode.SourceOver
                If Quality = Overlay.Quality.High Then
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                Else
                    g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
                End If
                'g.Clear(Color.Green)
                Dim brush = New Drawing.TextureBrush(new_image)
                brush.WrapMode = Drawing2D.WrapMode.TileFlipXY
                Dim x, y, w, h As Int32

                If Settings.Thumbnail_Resize_Mode = 0 Then
                    Dim ratio = new_image.Width / new_image.Height
                    'Dim min_size = Math.Min(Math.Min(Math.Min(ratio, 1) * Size.Width, 1 / ratio * Size.Width), Math.Min(Math.Min(ratio, 1) * Size.Height, 1 / ratio * Size.Height))
                    ''If CSng(Math.Max(1, ratio) * min_size) < Size.Width And CSng(1 / Math.Min(1, ratio) * min_size) < Size.Height Then min_size = Math.Max(Math.Min(Math.Min(ratio, 1) * Size.Width, 1 / ratio * Size.Width), Math.Min(Math.Min(ratio, 1) * Size.Height, 1 / ratio * Size.Height))
                    '
                    Dim w_ratio = Size.Width / new_image.Width
                    Dim h_ratio = Size.Height / new_image.Height
                    'Dim min_size = If(w_ratio > h_ratio, Size.Height * Math.Min(ratio, (1 / ratio)), Size.Width * Math.Min(ratio, (1 / ratio)))
                    Dim min_size = If(w_ratio > h_ratio, h_ratio * new_image.Height * ratio, w_ratio * new_image.Width / ratio)
                    If CSng(Math.Max(1, ratio) * min_size) > Size.Width Then min_size = 1 / Math.Min(1, ratio) * Size.Width
                    If CSng(1 / Math.Min(1, ratio) * min_size) > Size.Height Then min_size = Math.Max(1, 1 / ratio) * Size.Height
                    'If (w_ratio > h_ratio) Then
                    'Console.WriteLine("TRUE" & vbTab & min_size & vbTab & h_ratio * MusicModule.MusicThumbnail.Height * ratio)
                    'Else
                    '   Console.WriteLine("FALSE" & vbTab & min_size & vbTab & w_ratio * MusicThumbnail.Width / ratio)
                    'End If

                    Dim width = CSng(Math.Max(1, ratio) * min_size)
                    Dim height = CSng(1 / Math.Min(1, ratio) * min_size)
                    brush.ScaleTransform(width / new_image.Width, height / new_image.Height)
                    'brush.TranslateTransform(100, 100, Drawing2D.MatrixOrder.Append)
                    brush.TranslateTransform((Size.Width - width) / 2, (Size.Height - height) / 2, Drawing2D.MatrixOrder.Append)

                    'brush.Trans
                    x = (Size.Width - width) / 2
                    y = (Size.Height - height) / 2
                    w = width
                    h = height
                ElseIf Settings.Thumbnail_Resize_Mode = 1 Then
                    Dim ratio = new_image.Width / new_image.Height
                    Dim min_size = Math.Min(Math.Max(Math.Max(1, ratio) * Size.Width, Math.Max(1, ratio) * Size.Height), Math.Max(1 / Math.Min(1, ratio) * Size.Width, 1 / Math.Min(1, ratio) * Size.Height))
                    Dim width = CSng(Math.Max(1, ratio) * min_size)
                    Dim height = CSng(1 / Math.Min(1, ratio) * min_size)
                    brush.ScaleTransform(width / new_image.Width, height / new_image.Height)
                    brush.TranslateTransform((Size.Width - width) / 2, (Size.Height - height) / 2, Drawing2D.MatrixOrder.Append)
                    x = 0
                    y = 0
                    w = Size.Width
                    h = Size.Height
                ElseIf Settings.Thumbnail_Resize_Mode = 2 Then
                    brush.ScaleTransform(Size.Width / new_image.Width, Size.Height / new_image.Height)
                    x = 0
                    y = 0
                    w = Size.Width
                    h = Size.Height
                End If

                g.FillRoundedRectangle(brush, New Rectangle(x, y, w, h), Settings.RoundCorner / 100 * Math.Min(w, h))
            End Using
            last_write = tmp_last_write
            last_settings = Settings
            Return flag
        End If
#Disable Warning BC42105 ' La fonction ne retourne pas de valeur sur tous les chemins du code
    End Function
#Enable Warning BC42105 ' La fonction ne retourne pas de valeur sur tous les chemins du code

    Private Class ImageOptions
        Property ImagePath As String = ""
        Property Thumbnail_Resize_Mode As Int32 = 0
        Property RoundCorner As Int32 = 0
    End Class
End Class