Public Class MusicModulePlaylist
    Dim IgnoreActiveForm As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not PlayListBox.Items.Count = MusicModule.Playlist.Count Then
            Dim selectedI = PlayListBox.SelectedIndex
            PlayListBox.Items.Clear()
            For Each i In MusicModule.Playlist
                PlayListBox.Items.Add(IO.Path.GetFileNameWithoutExtension(i))
            Next
            PlayListBox.SelectedIndex = Math.Min(selectedI, PlayListBox.Items.Count - 1)
            PlayListBox.Size = New Size(159, PlayListBox.Items.Count * PlayListBox.ItemHeight)
        End If

        Try
            TitleLabel.Text = "Title : " & MusicModule.MusicTitle
            ArtistLabel.Text = "Artist : " & MusicModule.MusicArtist
            ThumbnailPictureBox.Image = MusicModule.MusicThumbnail
            Dim ratio = MusicModule.MusicThumbnail.Width / MusicModule.MusicThumbnail.Height
            ThumbnailPictureBox.Size = New Size(Math.Max(1, ratio) * 64, 1 / Math.Min(1, ratio) * 64)
            Dim x = ThumbnailPictureBox.Size.Width + 18
            TitleLabel.Location = New Point(x, 12)
            ArtistLabel.Location = New Point(x, 29)
            Label2.Location = New Point(x, 46)
        Catch
        End Try
        Dim Music_infos As New libZPlay.TStreamInfo
        Dim Music_pos As libZPlay.TStreamTime
        MusicModule.music_player.GetStreamInfo(Music_infos)
        MusicModule.music_player.GetPosition(Music_pos)
        If Music_infos.Length.hms.hour = 0 Then
            Label2.Text = New TimeSpan(Music_pos.hms.hour, Music_pos.hms.minute, Music_pos.hms.second).ToString("mm\:ss") & "/" & New TimeSpan(Music_infos.Length.hms.hour, Music_infos.Length.hms.minute, Music_infos.Length.hms.second).ToString("mm\:ss")
        Else
            Label2.Text = New TimeSpan(Music_pos.hms.hour, Music_pos.hms.minute, Music_pos.hms.second).ToString("hh\:mm\:ss") & "/" & New TimeSpan(Music_infos.Length.hms.hour, Music_infos.Length.hms.minute, Music_infos.Length.hms.second).ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MusicModule.music_player.StopPlayback()
        MusicModule.StoppedMusic = 1
        MusicModule.Pos = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MusicModule.music_player.PausePlayback()
        MusicModule.StoppedMusic = 1
        MusicModule.PausedMusic = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MusicModule.PausedMusic Then
            MusicModule.StoppedMusic = False
            MusicModule.music_player.ResumePlayback()
        Else
            MusicModule.Pos = -1
            MusicModule.StoppedMusic = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MusicModule.music_player.StopPlayback()
        If PlayingMode = 2 Then Pos += 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MusicModule.music_player.StopPlayback()
        MusicModule.Pos += -2
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        IgnoreActiveForm = True
        MusicModule.OpenFile()
        Timer1_Tick(sender, e)
        IgnoreActiveForm = False

        Activate()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        MusicModule.music_player.SetMasterVolume(TrackBar1.Value, TrackBar1.Value)
    End Sub

    Private Sub Playlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MusicModule.music_player.GetMasterVolume(TrackBar1.Value, TrackBar1.Value)
        UpdatePlayModeButton()
    End Sub

    Private Sub PlayListBox_DoubleClick(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click, PlayListBox.DoubleClick
        MusicModule.music_player.StopPlayback()
        MusicModule.Pos = PlayListBox.SelectedIndex - 1
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        IgnoreActiveForm = True
        MusicModule.OpenFile()
        Timer1_Tick(sender, e)
        IgnoreActiveForm = False

        Activate()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If PlayListBox.SelectedIndex > -1 Then
            MusicModule.Playlist.RemoveAt(PlayListBox.SelectedIndex)
            If MusicModule.Pos = PlayListBox.SelectedIndex Then
                MusicModule.Pos += -1
                MusicModule.music_player.StopPlayback()
            ElseIf MusicModule.Pos > PlayListBox.SelectedIndex Then
                MusicModule.Pos += -1
            End If
            Timer1_Tick(sender, e)
        End If
    End Sub

    Private Sub MyBase_Leave(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If Not IgnoreActiveForm Then
            OverlayGestion.StopIgnoreTopMost()
        End If
    End Sub

    Private Sub MyBase_Enter(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Not IgnoreActiveForm Then
            OverlayGestion.StartIgnoreTopMost()
        End If
    End Sub

    Private Sub PlayPosPictureBox_Paint(sender As Object, e As PaintEventArgs) Handles PlayPosPictureBox.Paint
        Dim Music_infos As New libZPlay.TStreamInfo
        Dim Music_pos As libZPlay.TStreamTime
        MusicModule.music_player.GetStreamInfo(Music_infos)
        MusicModule.music_player.GetPosition(Music_pos)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(55, 55, 59)), 6, 2, PlayPosPictureBox.Size.Width - 12, 6)
        e.Graphics.FillRectangle(Brushes.Red, 6, 2, CInt(Music_pos.ms / Math.Max(1, Music_infos.Length.ms) * (PlayPosPictureBox.Size.Width - 12)), 6)
        e.Graphics.FillEllipse(Brushes.White, CInt(Music_pos.ms / Math.Max(1, Music_infos.Length.ms) * (PlayPosPictureBox.Size.Width - 12)) + 2, 0, 9, 9)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        PlayPosPictureBox.Refresh()
        MusicModule.music_player.GetMasterVolume(TrackBar1.Value, TrackBar1.Value)
    End Sub
    Dim move_time As Boolean = False
    Private Sub PlayPosPictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PlayPosPictureBox.MouseDown
        move_time = True
    End Sub

    Private Sub PlayPosPictureBox_MouseUp(sender As Object, e As MouseEventArgs) Handles PlayPosPictureBox.MouseUp
        move_time = False
    End Sub

    Private Sub PlayPosPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PlayPosPictureBox.MouseMove
        If move_time Then
            Dim Music_infos As New libZPlay.TStreamInfo
            'Dim Music_pos As libZPlay.TStreamTime
            MusicModule.music_player.GetStreamInfo(Music_infos)
            'MusicModule.music_player.GetPosition(Music_pos)
            Dim new_pos As libZPlay.TStreamTime
            new_pos.ms = CInt(Math.Min(Math.Max(0, PlayPosPictureBox.PointToClient(MousePosition).X - 6) / (PlayPosPictureBox.Size.Width - 12) * Music_infos.Length.ms, Music_infos.Length.ms))
            MusicModule.music_player.Seek(libZPlay.TTimeFormat.tfMillisecond, new_pos, libZPlay.TSeekMethod.smFromBeginning)
        End If
    End Sub

    Private Sub PlayPosPictureBox_Click(sender As Object, e As EventArgs) Handles PlayPosPictureBox.Click
        Dim Music_infos As New libZPlay.TStreamInfo
        'Dim Music_pos As libZPlay.TStreamTime
        MusicModule.music_player.GetStreamInfo(Music_infos)
        'MusicModule.music_player.GetPosition(Music_pos)
        Dim new_pos As libZPlay.TStreamTime
        new_pos.ms = CInt(Math.Min(Math.Max(0, PlayPosPictureBox.PointToClient(MousePosition).X - 6) / (PlayPosPictureBox.Size.Width - 12) * Music_infos.Length.ms, Music_infos.Length.ms))
        MusicModule.music_player.Seek(libZPlay.TTimeFormat.tfMillisecond, new_pos, libZPlay.TSeekMethod.smFromBeginning)
    End Sub

    Private Sub PlayListBox_DragDrop(sender As Object, e As DragEventArgs) Handles PlayListBox.DragDrop
        'MsgBox(String.Join(" | ", e.Data.GetFormats))
        Dim strfiles = e.Data.GetData(DataFormats.FileDrop)
        For i = 0 To strfiles.GetUpperBound(0)
            MusicModule.AddFile(strfiles(i))
        Next
        Timer1_Tick(sender, e)
    End Sub

    Private Sub PlayListBox_DragEnter(sender As Object, e As DragEventArgs) Handles PlayListBox.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub PlayListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PlayListBox.KeyDown
        If e.KeyCode = 46 Then
            RemoveToolStripMenuItem_Click(sender, e)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MusicModule.PlayingMode = (PlayingMode + 1) Mod 4
        UpdatePlayModeButton()
    End Sub
    Sub UpdatePlayModeButton()
        Select Case PlayingMode
            Case 0
                Button7.BackgroundImage = My.Resources.PlayMode_Normal
            Case 1
                Button7.BackgroundImage = My.Resources.PlayMode_Repeat
            Case 2
                Button7.BackgroundImage = My.Resources.PlayMode_Repeat_one
            Case 3
                Button7.BackgroundImage = My.Resources.PlayMode_Shuffle
        End Select
    End Sub
End Class