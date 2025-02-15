Imports MAP.libZPlay
Module MusicModule
    Public music_player As New ZPlay()

    Public Playlist As New List(Of String)
    Public Pos As Int32 = 0
    Public StoppedMusic As Boolean = False
    Public PausedMusic As Boolean = False
    Public PlayingMode As Int32 = 0

    Public Sensibility As Int32 = 2
    Public HarmonicNumber As Int32
    Public HarmonicFreq(1024) As Int32
    Public LeftAmplitude(1024) As Int32
    Public RightAmplitude(1024) As Int32
    Public LeftPhase(1024) As Int32
    Public RightPhase(1024) As Int32

    Public MusicTitle As String = ""
    Public MusicArtist As String = ""
    Public MusicFilename As String = ""
    Public MusicFilenameWithoutExtension As String = ""
    Public MusicThumbnail As Image = My.Resources.music_player

    Public ReadOnly SupportedExtensions As String() = {".mp3", ".mp2", ".mp1", ".wav", ".ogg", ".ac3", ".flac", ".oga", ".raw", ".m3u"}
    Public ReadOnly MusicSupportedExtensions As String() = {".mp3", ".mp2", ".mp1", ".wav", ".ogg", ".ac3", ".flac", ".oga", ".raw"}
    Public ReadOnly PlaylistSupportedExtensions As String() = {".m3u"}

    Private rnd As New Random()

    Public Sub OpenFile()
        Dim OpenMusicFile As New OpenFileDialog
        OpenMusicFile.Multiselect = True
        OpenMusicFile.Filter = "Any File|*.*|MP3 File|*.mp3;*.mp2;*.mp1|WAV File|*.wav|OGG File|*.ogg|AC3 File|*.ac3|FLAC d'eau File|*.flac;*.oga|RAW File|*.raw"
        OverlayGestion.StartIgnoreTopMost()
        If OpenMusicFile.ShowDialog = DialogResult.OK Then
            AddFile(OpenMusicFile.FileNames)
        End If
        OverlayGestion.StopIgnoreTopMost()
    End Sub
    Public Sub AddFile(ParamArray files As String())
        Dim FormatNotSupportedList As New List(Of String)
        For Each file In files
            If MusicSupportedExtensions.Contains(IO.Path.GetExtension(file)) Then
                Playlist.Add(file)
                If StoppedMusic Then Pos = Playlist.Count - 2
                StoppedMusic = False
            ElseIf PlaylistSupportedExtensions.Contains(IO.Path.GetExtension(file)) Then
                Dim m3u_file = IO.File.ReadAllLines(file).ToList
                Dim new_files As New List(Of String)
                m3u_file.ForEach(Sub(x)
                                     If x.Contains(":/") Then
                                         Dim link = ""
                                         For i = 0 To x.Count - 9
                                             If x.Substring(i, 8) = "file:///" Then
                                                 link = x.Remove(0, i + 8)
                                                 Exit For
                                             ElseIf (x.Substring(i, 2) = ":/") Or (x.Substring(i, 2) = ":\") Then
                                                 link = x
                                                 Exit For
                                             End If
                                         Next
                                         new_files.Add(Web.HttpUtility.UrlDecode(link))
                                         'MsgBox(new_files.Last)
                                     ElseIf Not x.StartsWith("#") Then
                                         Dim new_link = Web.HttpUtility.UrlDecode(x)
                                         If Not (new_link.Contains(":/") Or new_link.Contains(":\")) Then
                                             new_link = IO.Path.GetDirectoryName(file) & "\" & new_link
                                         End If
                                         new_files.Add(new_link)
                                         'MsgBox(new_files.Last)
                                     End If
                                 End Sub)
                AddFile(new_files.ToArray)
            Else
                If Not FormatNotSupportedList.Contains(IO.Path.GetExtension(file).ToUpper) And IO.Path.GetExtension(file) <> "" Then FormatNotSupportedList.Add(IO.Path.GetExtension(file).ToUpper)
            End If
        Next
        If FormatNotSupportedList.Count > 0 Then MsgBox("Format(s) not supported : " & String.Join(", ", FormatNotSupportedList), MsgBoxStyle.Critical)

    End Sub

    Public Sub Load(code As XElement)
        If code IsNot Nothing Then
            PlayingMode = code.Element("settings").Element("playing_mode").Value
        End If
    End Sub

    Public Function Save() As XElement
        Return New XElement("settings", New XElement("playing_mode", PlayingMode))
    End Function

    Public Sub TickFrame()

        Dim HarmonicNumber_ As Int32
        Dim HarmonicFreq_(1024) As Int32
        Dim LeftAmplitude_(1024) As Int32
        Dim RightAmplitude_(1024) As Int32
        Dim LeftPhase_(1024) As Int32
        Dim RightPhase_(1024) As Int32
        music_player.GetFFTData(2048, TFFTWindow.fwRectangular, HarmonicNumber_, HarmonicFreq_, LeftAmplitude_, RightAmplitude_, LeftPhase_, RightPhase_)

        Dim min = Math.Max(RightAmplitude_.Max() / (1.5 + Sensibility / 100), LeftAmplitude_.Max() / (1.5 + Sensibility / 100))
        'Dim new_thing = False
        For i = 0 To 192
            'If Not (RightAmplitude(i) = MusicModule.RightAmplitude(i) And LeftAmplitude(i) = MusicModule.LeftAmplitude(i)) Then new_thing = True
            RightAmplitude(i) = RightAmplitude(i) + (Math.Max(0, RightAmplitude_(i) - min) ^ 1.3 - RightAmplitude(i)) / 5
            LeftAmplitude(i) = LeftAmplitude(i) + (Math.Max(0, LeftAmplitude_(i) - min) ^ 1.3 - LeftAmplitude(i)) / 5
            'RightAmplitude(i) = RightAmplitude_(i)
            'LeftAmplitude(i) = LeftAmplitude_(i)
        Next
    End Sub

    Public Sub TickMS100()
        Dim status As TStreamStatus
        music_player.GetStatus(status)
        If Not status.fPlay And Not StoppedMusic Then
            Try
                Select Case PlayingMode
                    Case 0
                        Pos += 1
                        If Pos >= Playlist.Count Then
                            Pos = -1
                            StoppedMusic = True
                        End If
                    Case 1
                        Pos += 1
                    Case 3
                        Pos = Rnd.Next(0, Playlist.Count - 1)
                End Select
                If Pos <= -1 Then Pos = Playlist.Count - 1
                If Pos >= Playlist.Count Then Pos = 0
                Dim MusicTag As New MP3File(Playlist(Pos))
                Dim changed_title As Boolean = False
                Dim changed_artist As Boolean = False
                Try
                    MusicTitle = MusicTag.Title
                    changed_title = True
                    MusicArtist = MusicTag.Artist
                    changed_artist = True
                    MusicThumbnail = MusicTag.Tag2.GetArtworkImage(MusicTag.Tag2.GetFrame("APIC"))
                Catch
                    Dim TitleSplit As String() = IO.Path.GetFileNameWithoutExtension(Playlist(Pos)).Split("-")
                    If (Not changed_title) Or (MusicTitle = "") Then MusicTitle = If(TitleSplit.Count >= 2, String.Join(" ", TitleSplit(1).Split(" ")), String.Join(" ", TitleSplit(0).Split(" ")))
                    If (Not changed_artist) Or (MusicArtist = "") Then MusicArtist = If(TitleSplit.Count >= 2, String.Join(" ", TitleSplit(0).Split(" ")), "Unknow Artist")
                    Try
                        If IO.File.Exists(IO.Path.GetDirectoryName(Playlist(Pos)) & "\front.jpg") Then
                            MusicThumbnail = Image.FromFile(IO.Path.GetDirectoryName(Playlist(Pos)) & "\front.jpg")
                        ElseIf IO.File.Exists(IO.Path.GetDirectoryName(Playlist(Pos)) & "\cover.jpg") Then
                            MusicThumbnail = Image.FromFile(IO.Path.GetDirectoryName(Playlist(Pos)) & "\cover.jpg")
                        ElseIf IO.File.Exists(IO.Path.GetDirectoryName(Playlist(Pos)) & "\" & IO.Path.GetFileName(Playlist(Pos)) & ".jpg") Then
                            MusicThumbnail = Image.FromFile(IO.Path.GetDirectoryName(Playlist(Pos)) & "\" & IO.Path.GetFileName(Playlist(Pos)) & ".jpg")
                        ElseIf IO.File.Exists(IO.Path.GetDirectoryName(Playlist(Pos)) & "\folder.jpg") Then
                            MusicThumbnail = Image.FromFile(IO.Path.GetDirectoryName(Playlist(Pos)) & "\folder.jpg")
                        ElseIf IO.File.Exists(IO.Path.GetDirectoryName(Playlist(Pos)) & "\" & MusicTag.Album & ".jpg") Then
                            MusicThumbnail = Image.FromFile(IO.Path.GetDirectoryName(Playlist(Pos)) & "\" & MusicTag.Album & ".jpg")
                        Else
                            MusicThumbnail = My.Resources.music_player
                        End If
                    Catch
                        MusicThumbnail = My.Resources.music_player
                    End Try
                End Try
                    MusicFilename = IO.Path.GetFileName(Playlist(Pos))
                    MusicFilenameWithoutExtension = IO.Path.GetFileNameWithoutExtension(Playlist(Pos))
                    music_player.OpenFile(Playlist(Pos), TStreamFormat.sfAutodetect)
                    music_player.StartPlayback()

                Catch
                End Try
        End If
    End Sub

    Public Sub TickMS1000()
    End Sub
End Module
