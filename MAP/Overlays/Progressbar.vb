Imports System.Text.RegularExpressions

Public Class Progressbar
    Implements Overlay.IOverlay
    Public Property Settings As Object = New ProgressbarOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
            New Overlay.Setting("Value", Overlay.Setting.SettingType.TextBox, "Value"), '{"Bars", "Spline", "Circle", "Circle Spline"}
            New Overlay.Setting("Style", Overlay.Setting.SettingType.ComboBox, "Style", {"Default", "Horizontal Full Rounded", "Experiment"}),
            New Overlay.Setting("Progress Bar Height", Overlay.Setting.SettingType.Trackbar, "ProgressBarHeight", Min_:=0, Max_:=38),
            New Overlay.Setting("Color", Overlay.Setting.SettingType.Color, "Color"),
            New Overlay.Setting("Border Color", Overlay.Setting.SettingType.Color, "BorderColor"),
            New Overlay.Setting("Background Color", Overlay.Setting.SettingType.Color, "BackColor"),
            New Overlay.Setting("Border Width", Overlay.Setting.SettingType.Trackbar, "BorderWidth", Min_:=0, Max_:=100),
            New Overlay.Setting("Round Corner", Overlay.Setting.SettingType.Trackbar, "RoundCorner", Min_:=0, Max_:=97),
            New Overlay.Setting("Draw Background Color", Overlay.Setting.SettingType.Checkbox, "DrawBackColor")
            }.ToList Implements Overlay.IOverlay.ClientSettings

    Public Property RefreshDelay As Overlay.RefreshDelay = Overlay.RefreshDelay.Ms100 Implements Overlay.IOverlay.RefreshDelay

    Public ReadOnly Property Dependences As String() Implements Overlay.IOverlay.Dependences
        Get
            Return {}
        End Get
    End Property

    Public ReadOnly Property Icon As Icon = My.Resources.map_icon Implements Overlay.IOverlay.Icon

    Public Function Save() As XElement Implements Overlay.IOverlay.Save
        Dim xDoc As New XElement("settings",
                    New XElement("Value", Settings.Value),
                    New XElement("Style", Settings.Style),
                    New XElement("ProgressBarHeight", Settings.ProgressBarHeight),
                    New XElement("Color", Settings.Color.ToArgb()),
                    New XElement("BorderColor", Settings.BorderColor.ToArgb()),
                    New XElement("BackColor", Settings.BackColor.ToArgb()),
                    New XElement("BorderWidth", Settings.BorderWidth),
                    New XElement("RoundCorner", Settings.RoundCorner),
                    New XElement("DrawBackColor", Settings.DrawBackColor)
)
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.Value = code.Element("settings").Element("Value").Value
            Settings.Style = code.Element("settings").Element("Style").Value
            Settings.Color = Color.FromArgb(code.Element("settings").Element("Color").Value)
            Settings.BorderColor = Color.FromArgb(code.Element("settings").Element("BorderColor").Value)
            Settings.BackColor = Color.FromArgb(code.Element("settings").Element("BackColor").Value)
            Settings.BorderWidth = code.Element("settings").Element("BorderWidth").Value
            Settings.RoundCorner = code.Element("settings").Element("RoundCorner").Value
            Settings.DrawBackColor = code.Element("settings").Element("DrawBackColor").Value
            Settings.ProgressBarHeight = code.Element("settings").Element("ProgressBarHeight").Value
        End If
    End Sub
    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick

        Dim texts = Regex.Split(CStr(Settings.Value), "\{([^}]*)\}")

        For i = 1 To texts.Length - 1 Step 2
            Try
                Dim splited = texts(i).Split(":")
                Select Case splited(0)
                    Case "time"
                        texts(i) = Date.Now.ToString(texts(i).Remove(0, 5))
                    Case "hardware"
                        Select Case splited(1)
                            Case "cpu_usage"
                                texts(i) = HardwareInfosModule.CPU_percent
                            Case "cpu"
                                texts(i) = HardwareInfosModule.CPU(texts(i).Remove(0, 13))
                            Case "gpu"
                                texts(i) = HardwareInfosModule.GPU(texts(i).Remove(0, 13))
                            Case "ram_usage"
                                texts(i) = HardwareInfosModule.RAM_usage
                            Case "ram_percent"
                                texts(i) = HardwareInfosModule.RAM_percent
                            Case "ram_total"
                                texts(i) = HardwareInfosModule.RAM_total
                        End Select
                    Case "musicmodule"
                        Select Case splited(1)
                            Case "title"
                                texts(i) = MusicModule.MusicTitle
                            Case "artist"
                                texts(i) = MusicModule.MusicArtist
                            Case "filename"
                                texts(i) = MusicModule.MusicFilename
                            Case "filename_withoutextension"
                                texts(i) = MusicModule.MusicFilenameWithoutExtension
                            Case "time"
                                Dim Music_infos As New libZPlay.TStreamInfo
                                Dim Music_pos As libZPlay.TStreamTime
                                MusicModule.music_player.GetStreamInfo(Music_infos)
                                MusicModule.music_player.GetPosition(Music_pos)
                                Dim time_texts = Regex.Split(texts(i).Remove(0, 17), "(?<!\\)\/")
                                If time_texts.Count > 1 Then
                                    texts(i) = New TimeSpan(Music_pos.hms.hour, Music_pos.hms.minute, Music_pos.hms.second).ToString(Regex.Replace(time_texts(0), "\\(?=\/)", "")) & "/" & New TimeSpan(Music_infos.Length.hms.hour, Music_infos.Length.hms.minute, Music_infos.Length.hms.second).ToString(Regex.Replace(time_texts(1), "\\(?=\/)", ""))
                                Else
                                    texts(i) = New TimeSpan(Music_pos.hms.hour, Music_pos.hms.minute, Music_pos.hms.second).ToString(Regex.Replace(time_texts(0), "\\(?=\/)", ""))
                                End If
                            Case "total_ms"
                                Dim Music_infos As New libZPlay.TStreamInfo
                                MusicModule.music_player.GetStreamInfo(Music_infos)
                                texts(i) = Music_infos.Length.ms
                            Case "current_ms"
                                Dim Music_pos As New libZPlay.TStreamTime
                                MusicModule.music_player.GetPosition(Music_pos)
                                texts(i) = Music_pos.ms
                        End Select
                End Select
            Catch ex As Exception
                texts(i) &= "ERROR [" & ex.Message & "]"
            End Try
        Next
        Dim Value As Double = 0
        Try
            Value = Math.Max(0, Math.Min(1, New DataTable().Compute(String.Join("", texts), Nothing)))
        Catch
        End Try
        Value = If(Double.IsNaN(Value), 0, Value)
        'Dim g = e.Graphics
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
            'g.DrawString(String.Join("", texts), Settings.Font, New SolidBrush(Settings.Color), 5, 5)

            If Settings.Style = ProgressbarStyle.Horizontal Or Settings.Style = ProgressbarStyle.FullRoundedHorizontal Then
                ' Dim graphicPath As New Drawing2D.GraphicsPath
                'graphicPath.FillMode = Drawing2D.FillMode.Winding
                'graphicPath.AddEllipse(New Rectangle(0, 0, Settings.RoundCorner * 2, Settings.RoundCorner * 2))
                'graphicPath.AddEllipse(New Rectangle(Size.Width - Settings.RoundCorner * 2, 0, Settings.RoundCorner * 2, Settings.RoundCorner * 2))
                'graphicPath.AddEllipse(New Rectangle(0, (Size.Height - Settings.ProgressBarHeight) - Settings.RoundCorner * 2, Settings.RoundCorner * 2, Settings.RoundCorner * 2))
                'graphicPath.AddEllipse(New Rectangle(Size.Width - Settings.RoundCorner * 2, (Size.Height - Settings.ProgressBarHeight) - Settings.RoundCorner * 2, Settings.RoundCorner * 2, Settings.RoundCorner * 2))
                'graphicPath.AddRectangle(New Rectangle(Settings.RoundCorner, 0, Size.Width - Settings.RoundCorner * 2, Size.Height - Settings.ProgressBarHeight))
                'graphicPath.AddRectangle(New Rectangle(0, Settings.RoundCorner, Size.Width, (Size.Height - Settings.ProgressBarHeight) - Settings.RoundCorner * 2))
                'graphicPath.AddClosedCurve({New Point(0, Settings.RoundCorner * 2), New Point(Settings.RoundCorner * 2, 0),
                '                          New Point(Size.Width - Settings.RoundCorner, 0), New Point(Size.Width, Settings.RoundCorner),
                '                         New Point(Size.Width, Size.Height - Settings.RoundCorner), New Point(Size.Width - Settings.RoundCorner, Size.Height),
                '                        New Point(Settings.RoundCorner, Size.Height), New Point(0, Size.Height - Settings.RoundCorner)})
                'g.SetClip(graphicPath)
                'g.SetClip(New Rectangle())
                'g.SetClipAsRoundedRectangle(New Rectangle(0, CInt(Settings.ProgressBarHeight / 2), Size.Width, Size.Height - Settings.ProgressBarHeight), (Size.Height - Settings.ProgressBarHeight) / 2 * (Settings.RoundCorner / 100))
                'g.FillPath(New SolidBrush(Settings.BorderColor), 0, 0, Size.Width, Size.Height)
                Dim border = (Settings.BorderWidth / 200) * (Size.Height - Settings.ProgressBarHeight)

                'g.ResetClip()
                'g.SetClip(graphicPath)

                'g.SetClipAsRoundedRectangle()
                If Settings.DrawBackColor Then
                    g.FillRoundedRectangle(New SolidBrush(Settings.BackColor), New Rectangle(border, CSng(Settings.ProgressBarHeight / 2) + border, Size.Width - border * 2, Size.Height - Settings.ProgressBarHeight - border * 2), (Size.Height - Settings.ProgressBarHeight - border * 2) * (Settings.RoundCorner / 100))
                Else
                        'g.FillRoundedRectangle(New SolidBrush(Color.Transparent), New Rectangle(border, CInt(Settings.ProgressBarHeight / 2) + border, Size.Width - border * 2, Size.Height - Settings.ProgressBarHeight - border * 2), (Size.Height - Settings.ProgressBarHeight - border * 2) / 2 * (Settings.RoundCorner / 100))
                    End If
                Dim max_val = Size.Width - border * 2

                g.SetClipAsRoundedRectangle(New Rectangle(border, CSng(Settings.ProgressBarHeight / 2) + border - 1, Size.Width - border * 2, Size.Height - Settings.ProgressBarHeight - border * 2 + 2), (Size.Height - Settings.ProgressBarHeight - border * 2) * (Settings.RoundCorner / 100))
                If Settings.Style = ProgressbarStyle.Horizontal Then
                    g.FillRectangle(New SolidBrush(Settings.Color), New Rectangle(CSng(max_val * Value - max_val + border), CSng(Settings.ProgressBarHeight / 2) + border - 1, CSng(Size.Width - border * 2), Size.Height - Settings.ProgressBarHeight - border * 2 + 2))
                Else
                    g.FillRoundedRectangle(New SolidBrush(Settings.Color), New Rectangle(CSng(max_val * Value - max_val + border), CSng(Settings.ProgressBarHeight / 2) + border - 1, CSng(Size.Width - border * 2), Size.Height - Settings.ProgressBarHeight - border * 2 + 2), (Size.Height - Settings.ProgressBarHeight - border * 2) * (Settings.RoundCorner / 100))
                End If

                If Settings.BorderWidth <> 0 Then
                    g.ResetClip()
                    g.SetClip(g.GetRoundedRectangleGraphicPath(New Rectangle(border + 1, CSng(Settings.ProgressBarHeight / 2 + border + 1), Size.Width - border * 2 - 2, Size.Height - Settings.ProgressBarHeight - border * 2 - 2), (Size.Height - Settings.ProgressBarHeight - border * 2) * (Settings.RoundCorner / 100)), Drawing2D.CombineMode.Exclude)
                    g.FillRoundedRectangle(New SolidBrush(Settings.BorderColor), New Rectangle(0, CSng(Settings.ProgressBarHeight / 2), Size.Width, Size.Height - Settings.ProgressBarHeight), (Size.Height - Settings.ProgressBarHeight) * (Settings.RoundCorner / 100))
                    g.ResetClip()
                End If

            ElseIf Settings.Style = ProgressbarStyle.Experimental Then
                    g.FillRectangle(New SolidBrush(Settings.Color), 0, CSng(Settings.ProgressBarHeight / 2), CSng(Size.Width * Value), Size.Height - Settings.ProgressBarHeight)
            End If
        End Using

        Return flag
    End Function
    Enum ProgressbarStyle
        Horizontal = 0
        FullRoundedHorizontal = 1
        Experimental = 2
    End Enum
    Private Class ProgressbarOptions
        Property Value As String = "{musicmodule:current_ms} / {musicmodule:total_ms}"
        Property Style As Int32 = 0
        Property ProgressBarHeight As Int32 = 0
        Property Color As Color = Color.FromArgb(255, 255, 255)
        Property BorderColor As Color = Color.FromArgb(255, 255, 255)
        Property BackColor As Color = Color.FromArgb(255, 255, 255)
        Property BorderWidth As Int32 = 0
        Property RoundCorner As Int32 = 0
        Property DrawBackColor As Boolean = True

    End Class
End Class
