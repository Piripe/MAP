Public Class ZoneConfig
    Dim selected_overlay As Form = OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Form
    Dim old_pos As Point = OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Location
    Dim old_size As Size = OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Form.Size
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Location = Location
        selected_overlay.Size = Size
        selected_overlay.Location = Location
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Location = old_pos
        selected_overlay.Location = old_pos
        selected_overlay.Size = old_size
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Location = New Point(0, My.Computer.Screen.WorkingArea.Height / 4 * 3)
        Size = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height / 4 * 1)
    End Sub

    Private Sub CustomConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        selected_overlay = OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Form
        Size = Settings.before_overlay_resize_size
        Location = Settings.before_overlay_resize_location
    End Sub

    Private Sub ZoneConfig_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        OverlayGestion.OverlaysList(Settings.OverlaysCheckedListBox.SelectedIndex).Location = Location
        selected_overlay.Location = Location
    End Sub

    Private Sub ZoneConfig_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        selected_overlay.Size = Size
    End Sub
End Class