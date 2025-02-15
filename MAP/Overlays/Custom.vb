Imports System.Text.RegularExpressions
Public Class Custom
    Implements Overlay.IOverlay
    Public Property Settings As Object = New CustomOptions() Implements Overlay.IOverlay.Settings

    Public Property ClientSettings As List(Of Overlay.Setting) = {
        New Overlay.Setting("Format", Overlay.Setting.SettingType.TextBox, "Format"), '{"Bars", "Spline", "Circle", "Circle Spline"}
        New Overlay.Setting("Font", Overlay.Setting.SettingType.Font, "Font"),
        New Overlay.Setting("Color", Overlay.Setting.SettingType.Color, "Color"),
        New Overlay.Setting("Web Request Refresh Rate", Overlay.Setting.SettingType.ComboBox, "RefreshRate", {"2s", "5s", "10s", "30s", "1m", "2m", "5m", "10m", "15m"})
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
                New XElement("Format", Settings.Format),
                New XElement("Font_Name", Settings.Font.Name),
                New XElement("Font_Size", CInt(Settings.Font.Size)),
                New XElement("Font_Style", CInt(Settings.Font.Style)),
                New XElement("Color", Settings.Color.ToARGB()),
                New XElement("RefreshRate", Settings.RefreshRate)
                )
        Return xDoc
    End Function

    Public Sub Load(code As XElement) Implements Overlay.IOverlay.Load
        If code IsNot Nothing Then
            Settings.Format = code.Element("settings").Element("Format").Value
            Settings.Font = New Font(code.Element("settings").Element("Font_Name").Value, CSng(code.Element("settings").Element("Font_Size").Value), CType(code.Element("settings").Element("Font_Style").Value, FontStyle))
            Settings.Color = Color.FromArgb(code.Element("settings").Element("Color").Value)
            Settings.RefreshRate = code.Element("settings").Element("RefreshRate").Value
        End If
    End Sub

    Dim webinfos As New Dictionary(Of String, String)
    Dim refresh_index As Int32 = 0
    Dim refresh_rates = {20, 50, 100, 300, 600, 1200, 3000, 6000, 9000}
    Public Function Tick(Size As Size, Quality As Overlay.Quality) As Image Implements Overlay.IOverlay.Tick
        Dim texts = Regex.Split(CStr(Settings.Format), "\{([^}]*)\}")
        If refresh_index >= refresh_rates(Settings.RefreshRate) Then
            For Each x In webinfos
                If Not texts.Contains("url:" & x.Key) Then webinfos.Remove(x.Key)
            Next
#Disable Warning BC42358
            UpdateValuesAsync()
#Enable Warning BC42358
            refresh_index = 0
        End If
        refresh_index += 1

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
                            End Select
                        Case "url"
                            Dim url = texts(i).Remove(0, 4)
                            If Not webinfos.ContainsKey(url) Then
                                Dim value = "[URL: " & url & "]"
                                webinfos.Add(url, value)
                                refresh_index = refresh_rates(Settings.RefreshRate) - 5
                            End If
                            texts(i) = webinfos(url)
                    End Select
                Catch ex As Exception
                    texts(i) &= "ERROR [" & ex.Message & "]"
                End Try
            Next
            'g.CopyFromScreen(New Point(10, 10), New Point(0, 0), Size)
            g.DrawString(String.Join("", texts), Settings.Font, New SolidBrush(Settings.Color), 5, 5)
        End Using

        Return flag
    End Function
    Private Async Function UpdateValuesAsync() As Task
        For webinfosrefreshindex = 0 To webinfos.Count - 1
            Try
                Dim value = webinfos.ElementAt(webinfosrefreshindex).Value
                value = Text.Encoding.UTF8.GetString(Await New Net.WebClient().DownloadDataTaskAsync(webinfos.ElementAt(webinfosrefreshindex).Key))
                'MsgBox(value)
                webinfos(webinfos.ElementAt(webinfosrefreshindex).Key) = value
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        Next
    End Function
    Private Class CustomOptions
        Property Format As String = "{musicmodule:artist} - {musicmodule:title}"
        Property Font As Font = New Font("Segoe UI", 16)
        Property Color As Color = Color.FromArgb(255, 255, 255)
        Property RefreshRate As Int32 = 2
    End Class
End Class