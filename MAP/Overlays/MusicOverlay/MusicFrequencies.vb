Public Class MusicFrequencies
    Implements Overlay.IOverlay
    Public Property Settings As Object = New MusicFrequenciesOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
        New Overlay.Setting("Drawing Mode", Overlay.Setting.SettingType.ComboBox, "Drawing_Mode", {"Bars", "Spline", "Circle", "Circle Spline"}),
        New Overlay.Setting("Drawing X", Overlay.Setting.SettingType.Trackbar, "Drawing_X", Min_:=0, Max_:=4096),
        New Overlay.Setting("Drawing Y", Overlay.Setting.SettingType.Trackbar, "Drawing_Y", Min_:=0, Max_:=4096),
        New Overlay.Setting("Drawing Size", Overlay.Setting.SettingType.Trackbar, "Drawing_Size", {1}, Min_:=0, Max_:=100),
        New Overlay.Setting("Color", Overlay.Setting.SettingType.Color, "Color"),
        New Overlay.Setting("Frequency Rounding Level", Overlay.Setting.SettingType.Trackbar, "Frequency_Rounding_Level", Min_:=1, Max_:=50)
        }.ToList Implements Overlay.IOverlay.ClientSettings

    Public Property RefreshDelay As Overlay.RefreshDelay = Overlay.RefreshDelay.Frame Implements Overlay.IOverlay.RefreshDelay

    Public ReadOnly Property Dependences As String() Implements Overlay.IOverlay.Dependences
        Get
            Return {"MusicModule"}
        End Get
    End Property

    Public ReadOnly Property Icon As Icon = My.Resources.music_player_icn Implements Overlay.IOverlay.Icon

    Public Function Save() As XElement Implements Overlay.IOverlay.Save
        Dim xDoc As New XElement("settings",
                New XElement("Drawing_Mode", Settings.Drawing_Mode),
                New XElement("Drawing_X", Settings.Drawing_X),
                New XElement("Drawing_Y", Settings.Drawing_Y),
                New XElement("Drawing_Size", Settings.Drawing_Size),
                New XElement("Color", Settings.Color.ToARGB()),
                New XElement("Frequency_Rounding_Level", Settings.Frequency_Rounding_Level)
                )
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.Drawing_Mode = code.Element("settings").Element("Drawing_Mode").Value
            Settings.Drawing_X = code.Element("settings").Element("Drawing_X").Value
            Settings.Drawing_Y = code.Element("settings").Element("Drawing_Y").Value
            Settings.Drawing_Size = code.Element("settings").Element("Drawing_Size").Value
            Settings.Color = Color.FromArgb(code.Element("settings").Element("Color").Value)
            Settings.Frequency_Rounding_Level = Math.Max(1, CInt(code.Element("settings").Element("Frequency_Rounding_Level").Value))
        End If
    End Sub
    Dim flag As New Bitmap(1, 1)
    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick

        Dim RightAmplitude(128) As Int32
        Dim LeftAmplitude(128) As Int32
        Dim currentRoundingLevel = Math.Max(1, Settings.Frequency_Rounding_Level)
        For i = 0 To 127
            Dim right = MusicModule.RightAmplitude.ToList.GetRange(i, currentRoundingLevel).Sum
            Dim Left = MusicModule.LeftAmplitude.ToList.GetRange(i, currentRoundingLevel).Sum
            right /= currentRoundingLevel
            Left /= currentRoundingLevel
            RightAmplitude(i) = right
            LeftAmplitude(i) = Left
        Next

        Dim BarsColorBrush As New SolidBrush(Settings.Color)
        If flag.Width <> Size.Width Or flag.Height <> Size.Height Then
            flag = New Bitmap(Size.Width, Size.Height)
        End If
        'Dim flag As New Bitmap(Size.Width, Size.Height)
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

            If Settings.Drawing_Mode = 0 Then
                Dim UV_Rectangles = New List(Of Rectangle)
                For i = 0 To 127
                    UV_Rectangles.Add(New Rectangle(i * (Size.Width / 128), Size.Height - (RightAmplitude(i) ^ 2) / 15 * (Settings.Drawing_Size / 10), (Size.Width / 128) / 1.5, (RightAmplitude(i) ^ 2) / 15 * (Settings.Drawing_Size / 10)))
                Next
                g.FillRectangles(BarsColorBrush, UV_Rectangles.ToArray)
            ElseIf Settings.Drawing_Mode = 1 Then
                Dim UV_Points = New List(Of Point)
                UV_Points.Add(New Point(0, Size.Height))
                For i = 0 To 127 Step Math.Floor(currentRoundingLevel / 3 + 1)
                    UV_Points.Add(New Point(i * (Size.Width / 128), Size.Height - (RightAmplitude(i) ^ 2) / 15 * (Settings.Drawing_Size / 10)))
                Next
                UV_Points.Add(New Point(Size.Width, Size.Height))
                g.FillClosedCurve(BarsColorBrush, UV_Points.ToArray)
            ElseIf Settings.Drawing_Mode = 2 Then
                g.TranslateTransform(Settings.Drawing_X, Settings.Drawing_Y)
                For i = 0 To 127
                    g.FillRectangle(BarsColorBrush, New Rectangle(-2 * (Settings.Drawing_Size / 10), 50 * (Settings.Drawing_Size / 10), 4 * (Settings.Drawing_Size / 10), LeftAmplitude(i) / 2 * (Settings.Drawing_Size / 10)))
                    g.RotateTransform(360 / 256)
                Next
                For i = 127 To 0 Step -1
                    g.FillRectangle(BarsColorBrush, New Rectangle(-2 * (Settings.Drawing_Size / 10), 50 * (Settings.Drawing_Size / 10), 4 * (Settings.Drawing_Size / 10), RightAmplitude(i) / 2 * (Settings.Drawing_Size / 10)))
                    g.RotateTransform(360 / 256)
                Next
                g.TranslateTransform(Settings.Drawing_X * -1, Settings.Drawing_Y * -1)
            ElseIf Settings.Drawing_Mode = 3 Then
                Dim gp As New Drawing2D.GraphicsPath
                gp.FillMode = Drawing2D.FillMode.Alternate
                gp.AddEllipse(CInt(Settings.Drawing_X - 50 * (Settings.Drawing_Size / 10)), CInt(Settings.Drawing_Y - 50 * (Settings.Drawing_Size / 10)), CInt(100 * (Settings.Drawing_Size / 10)), CInt(100 * (Settings.Drawing_Size / 10)))
                gp.AddRectangle(New Rectangle(0, 0, Size.Width, Size.Height))
                g.SetClip(gp)
                g.TranslateTransform(Settings.Drawing_X, Settings.Drawing_Y)
                For i = 0 To 127
                    g.FillEllipse(BarsColorBrush, New Rectangle(-8 * (Settings.Drawing_Size / 10), 0, 16 * (Settings.Drawing_Size / 10), (LeftAmplitude(i) / 2 * (Settings.Drawing_Size / 10)) + (50 * (Settings.Drawing_Size / 10))))
                    g.RotateTransform(360 / 256)
                Next
                For i = 127 To 0 Step -1
                    g.FillEllipse(BarsColorBrush, New Rectangle(-8 * (Settings.Drawing_Size / 10), 0, 16 * (Settings.Drawing_Size / 10), (RightAmplitude(i) / 2 * (Settings.Drawing_Size / 10)) + (50 * (Settings.Drawing_Size / 10))))
                    g.RotateTransform(360 / 256)
                Next
                g.TranslateTransform(Settings.Drawing_X * -1, Settings.Drawing_Y * -1)
            End If
        End Using

        Return flag
    End Function
    Private Class MusicFrequenciesOptions
        Property Drawing_Mode As Int32 = 0
        Property Drawing_X As Int32 = 225
        Property Drawing_Y As Int32 = 225
        Property Drawing_Size As Double = 1

        Property Frequency_Rounding_Level As Int32 = 1

        Property Color As Color = Color.FromArgb(0, 0, 0)
    End Class
End Class