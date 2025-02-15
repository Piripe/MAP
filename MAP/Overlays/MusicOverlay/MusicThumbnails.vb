Public Class MusicThumbnails
    Implements Overlay.IOverlay
    Public Property Settings As Object = New MusicFrequenciesOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
        New Overlay.Setting("Thumbnail Resize Mode", Overlay.Setting.SettingType.ComboBox, "Thumbnail_Resize_Mode", {"Zoom Inner", "Zoom Outter", "Stretch"}),
            New Overlay.Setting("Round Corner", Overlay.Setting.SettingType.Trackbar, "RoundCorner", Min_:=0, Max_:=97)
        }.ToList Implements Overlay.IOverlay.ClientSettings

    Public Property RefreshDelay As Overlay.RefreshDelay = Overlay.RefreshDelay.Ms100 Implements Overlay.IOverlay.RefreshDelay

    Public ReadOnly Property Dependences As String() Implements Overlay.IOverlay.Dependences
        Get
            Return {"MusicModule"}
        End Get
    End Property

    Public ReadOnly Property Icon As Icon = My.Resources.music_player_icn Implements Overlay.IOverlay.Icon

    Public Function Save() As XElement Implements Overlay.IOverlay.Save
        Dim xDoc As New XElement("settings",
                New XElement("Thumbnail_Resize_Mode", Settings.Thumbnail_Resize_Mode),
                New XElement("RoundCorner", Settings.RoundCorner)
                )
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.Thumbnail_Resize_Mode = code.Element("settings").Element("Thumbnail_Resize_Mode").Value
            Settings.RoundCorner = code.Element("settings").Element("RoundCorner").Value
        End If
    End Sub
    'Dim CurrentImage As Image = My.Resources.music_player
    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick
        Dim flag As New Bitmap(Size.Width, Size.Height)
        'flag.MakeTransparent()
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
            Dim brush = New Drawing.TextureBrush(MusicThumbnail)
            brush.WrapMode = Drawing2D.WrapMode.TileFlipXY
            Dim x, y, w, h As Int32

            If Settings.Thumbnail_Resize_Mode = 0 Then
                Dim ratio = MusicModule.MusicThumbnail.Width / MusicModule.MusicThumbnail.Height
                'Dim min_size = Math.Min(Math.Min(Math.Min(ratio, 1) * Size.Width, 1 / ratio * Size.Width), Math.Min(Math.Min(ratio, 1) * Size.Height, 1 / ratio * Size.Height))
                ''If CSng(Math.Max(1, ratio) * min_size) < Size.Width And CSng(1 / Math.Min(1, ratio) * min_size) < Size.Height Then min_size = Math.Max(Math.Min(Math.Min(ratio, 1) * Size.Width, 1 / ratio * Size.Width), Math.Min(Math.Min(ratio, 1) * Size.Height, 1 / ratio * Size.Height))
                '
                Dim w_ratio = Size.Width / MusicModule.MusicThumbnail.Width
                Dim h_ratio = Size.Height / MusicModule.MusicThumbnail.Height
                'Dim min_size = If(w_ratio > h_ratio, Size.Height * Math.Min(ratio, (1 / ratio)), Size.Width * Math.Min(ratio, (1 / ratio)))
                Dim min_size = If(w_ratio > h_ratio, h_ratio * MusicModule.MusicThumbnail.Height * ratio, w_ratio * MusicThumbnail.Width / ratio)
                If CSng(Math.Max(1, ratio) * min_size) > Size.Width Then min_size = 1 / Math.Min(1, ratio) * Size.Width
                If CSng(1 / Math.Min(1, ratio) * min_size) > Size.Height Then min_size = Math.Max(1, 1 / ratio) * Size.Height
                'If (w_ratio > h_ratio) Then
                'Console.WriteLine("TRUE" & vbTab & min_size & vbTab & h_ratio * MusicModule.MusicThumbnail.Height * ratio)
                'Else
                '   Console.WriteLine("FALSE" & vbTab & min_size & vbTab & w_ratio * MusicThumbnail.Width / ratio)
                'End If

                Dim width = CSng(Math.Max(1, ratio) * min_size)
                    Dim height = CSng(1 / Math.Min(1, ratio) * min_size)
                    brush.ScaleTransform(width / MusicModule.MusicThumbnail.Width, height / MusicModule.MusicThumbnail.Height)
                    'brush.TranslateTransform(100, 100, Drawing2D.MatrixOrder.Append)
                    brush.TranslateTransform((Size.Width - width) / 2, (Size.Height - height) / 2, Drawing2D.MatrixOrder.Append)

                    'brush.Trans
                    x = (Size.Width - width) / 2
                    y = (Size.Height - height) / 2
                    w = width
                    h = height
                ElseIf Settings.Thumbnail_Resize_Mode = 1 Then
                    Dim ratio = MusicModule.MusicThumbnail.Width / MusicModule.MusicThumbnail.Height
                    Dim min_size = Math.Min(Math.Max(Math.Max(1, ratio) * Size.Width, Math.Max(1, ratio) * Size.Height), Math.Max(1 / Math.Min(1, ratio) * Size.Width, 1 / Math.Min(1, ratio) * Size.Height))
                    Dim width = CSng(Math.Max(1, ratio) * min_size)
                    Dim height = CSng(1 / Math.Min(1, ratio) * min_size)
                    brush.ScaleTransform(width / MusicModule.MusicThumbnail.Width, height / MusicModule.MusicThumbnail.Height)
                    brush.TranslateTransform((Size.Width - width) / 2, (Size.Height - height) / 2, Drawing2D.MatrixOrder.Append)
                    x = 0
                    y = 0
                    w = Size.Width
                    h = Size.Height
                ElseIf Settings.Thumbnail_Resize_Mode = 2 Then
                    brush.ScaleTransform(Size.Width / MusicModule.MusicThumbnail.Width, Size.Height / MusicModule.MusicThumbnail.Height)
                x = 0
                y = 0
                w = Size.Width
                h = Size.Height
            End If

            g.FillRoundedRectangle(brush, New Rectangle(x, y, w, h), Settings.RoundCorner / 100 * Math.Min(w, h))
        End Using
        Return flag
    End Function
    Private Class MusicFrequenciesOptions
        Property Thumbnail_Resize_Mode As Int32 = 0
        Property RoundCorner As Int32 = 0
    End Class
End Class