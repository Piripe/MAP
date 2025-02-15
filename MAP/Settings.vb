Public Class Settings
    Dim IgnoreActiveForm As Boolean = False
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/Piripe/MAP/issues/new")
    End Sub

    Private Sub FPSTimer_Tick(sender As Object, e As EventArgs) Handles FPSTimer.Tick
        Label1.Text = "FPS : " & CInt((1000 / FPSTimer.Interval) * Math.Max(1, OverlayGestion.RenderedFrames))
        OverlayGestion.RenderTime = 0
        OverlayGestion.RenderedFrames = 0
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ModulesCheckedListBox.SelectedIndexChanged
        If Not ModulesCheckedListBox.SelectedIndex = -1 Then
            ModuleIconPictureBox.BackgroundImage = OverlayGestion.ModulesIcon(ModulesCheckedListBox.SelectedIndex)
            ModuleNameTextBox.Text = OverlayGestion.ModulesName(ModulesCheckedListBox.SelectedIndex)
            ModuleDescriptionTextBox.Text = OverlayGestion.ModulesDescription(ModulesCheckedListBox.SelectedIndex)
            ToggleModuleButton.Visible = True
        End If
    End Sub

    Private Sub ToggleModuleButton_Click(sender As Object, e As EventArgs) Handles ToggleModuleButton.Click
        ModulesCheckedListBox.SetItemChecked(ModulesCheckedListBox.SelectedIndex, Not ModulesCheckedListBox.GetItemChecked(ModulesCheckedListBox.SelectedIndex))
        For i = 0 To ModulesCheckedListBox.Items.Count - 1
            OverlayGestion.ActiveModules(i) = ModulesCheckedListBox.GetItemChecked(i)
        Next
    End Sub

    Private Sub CheckedListBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles ModulesCheckedListBox.MouseUp
        For i = 0 To ModulesCheckedListBox.Items.Count - 1
            OverlayGestion.ActiveModules(i) = ModulesCheckedListBox.GetItemChecked(i)
        Next
    End Sub

    Private Sub GeneralTabButton_Click(sender As Object, e As EventArgs) Handles GeneralTabButton.MouseDown
        GeneralTabButton.FlatAppearance.BorderSize = 2
        ModulesTabButton.FlatAppearance.BorderSize = 1
        OverlaysTabButton.FlatAppearance.BorderSize = 1
        GeneralTabPanel.Visible = True
        ModulesTabPanel.Visible = False
        OverlaysTabPanel.Visible = False
    End Sub

    Private Sub ModulesTabButton_Click(sender As Object, e As EventArgs) Handles ModulesTabButton.MouseDown
        ModulesTabButton.FlatAppearance.BorderSize = 2
        GeneralTabButton.FlatAppearance.BorderSize = 1
        OverlaysTabButton.FlatAppearance.BorderSize = 1
        ModulesTabPanel.Visible = True
        GeneralTabPanel.Visible = False
        OverlaysTabPanel.Visible = False
    End Sub

    Private Sub OverlaysTabButton_Click(sender As Object, e As EventArgs) Handles OverlaysTabButton.MouseDown
        OverlaysTabButton.FlatAppearance.BorderSize = 2
        ModulesTabButton.FlatAppearance.BorderSize = 1
        GeneralTabButton.FlatAppearance.BorderSize = 1
        OverlaysTabPanel.Visible = True
        ModulesTabPanel.Visible = False
        GeneralTabPanel.Visible = False
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OverlaysCheckedListBox.SelectedIndex = -1
        ModulesCheckedListBox.SelectedIndex = -1
        Timer1_Tick(sender, e)
        VersionLabel.Text = "Version " & OverlayGestion.Version
        ForceTopmostCheckBox.Checked = OverlayGestion.ForceTopMost
        BetaCodeTextBox.Text = OverlayGestion.Betacode
        UpdateCanalComboBox.SelectedIndex = OverlayGestion.UpdateCanal
        Activate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        'If Not OverlaysCheckedListBox.Items.Count = OverlayGestion.OverlaysList.Count Then
        'Dim old_selected_index = OverlaysCheckedListBox.SelectedIndex
        'OverlaysCheckedListBox.Items.Clear()
        Dim selected_value = False
        If OverlaysCheckedListBox.SelectedIndex <> -1 Then
            selected_value = OverlaysCheckedListBox.GetItemChecked(OverlaysCheckedListBox.SelectedIndex)
            OverlayGestion.ActiveOverlays(OverlaysCheckedListBox.SelectedIndex) = OverlaysCheckedListBox.GetItemChecked(OverlaysCheckedListBox.SelectedIndex)
        End If

        For i = 0 To OverlayGestion.OverlaysList.Count - 1
            If OverlaysCheckedListBox.Items.Count <= i Then
                OverlaysCheckedListBox.Items.Add(OverlayGestion.OverlaysList(i).Name)
            Else
                If Not OverlaysCheckedListBox.Items.Item(i) = OverlayGestion.OverlaysList(i).Name Then OverlaysCheckedListBox.Items.Item(i) = OverlayGestion.OverlaysList(i).Name
            End If
            If Not OverlaysCheckedListBox.GetItemChecked(i) = OverlayGestion.ActiveOverlays(i) Then OverlaysCheckedListBox.SetItemChecked(i, OverlayGestion.ActiveOverlays(i))
        Next
        If OverlaysCheckedListBox.SelectedIndex <> -1 Then OverlaysCheckedListBox.SetItemChecked(OverlaysCheckedListBox.SelectedIndex, selected_value)

        'OverlaysCheckedListBox.SelectedIndex = old_selected_index
        'OverlaysCheckedListBox.Size = New Size(139, OverlaysCheckedListBox.Items.Count * 15)
        'End If
        For i = 0 To OverlayGestion.ActiveModules.Count - 1
            If ModulesCheckedListBox.Items.Count <= i Then
                ModulesCheckedListBox.Items.Add(OverlayGestion.ModulesName(i))
            Else
                If Not ModulesCheckedListBox.Items.Item(i) = OverlayGestion.ModulesName(i) Then ModulesCheckedListBox.Items.Item(i) = OverlayGestion.ModulesName(i)
            End If
            If Not ModulesCheckedListBox.GetItemChecked(i) = OverlayGestion.ActiveModules(i) Then ModulesCheckedListBox.SetItemChecked(i, OverlayGestion.ActiveModules(i))
        Next

        If OverlayGestion.WaitForBetacode > 0 Then
            OverlayGestion.WaitForBetacode += -1
            If OverlayGestion.WaitForBetacode <= 0 Then
                BetaCodeButton.Text = "Use"
            Else
                BetaCodeButton.Text = "Use (" & OverlayGestion.WaitForBetacode & ")"
            End If
        End If
    End Sub

    Private Sub AddOverlayButton_Click(sender As Object, e As EventArgs) Handles AddOverlayButton.Click
        NewOverlayContextMenuStrip.Show(AddOverlayButton, 0, 0)
        'OverlayGestion.OverlaysType.Add("MusicTitle")
        'OverlayGestion.ActiveOverlays.Add(True)
        'OverlayGestion.OverlaysPosition.Add(New Point(0, My.Computer.Screen.WorkingArea.Height / 4 * 1))

        'OverlayGestion.OverlaysControl.Add(OverlayGestion.CreateOverlayControl(OverlayGestion.OverlaysName.IndexOf(OverlayGestion.OverlaysType(nei))))
        'OverlayGestion.OverlaysControl(nei).Name = "Overlay" & nei

        'OverlayGestion.OverlaysList(nei).Name = "Form" & nei
        'OverlayGestion.OverlaysList(nei).Text = "Overlay" & nei
        'OverlayGestion.OverlaysList(nei).Opacity = 0.7
        'OverlayGestion.OverlaysList(nei).Controls.Add(OverlayGestion.OverlaysControl(nei))
        'OverlayGestion.OverlaysList(nei).Controls.Item(0).Dock = DockStyle.Fill
        'OverlayGestion.OverlaysList(nei).FormBorderStyle = FormBorderStyle.None
        'OverlayGestion.OverlaysList(nei).Size = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height / 4)
        'OverlayGestion.OverlaysList(nei).TransparencyKey = Color.FromKnownColor(KnownColor.Control)
        'OverlayGestion.SetWindowLong(OverlayGestion.OverlaysList(nei).Handle, -20, OverlayGestion.GetWindowLong(OverlayGestion.OverlaysList(nei).Handle, -20) Or &H80000 Or &H20)

    End Sub
    Sub AddOverlay(sender As Object, e As EventArgs) Handles MusicFrequenciesToolStripMenuItem.Click, CustomToolStripMenuItem.Click, ProgressbarToolStripMenuItem.Click, MusicThumbnailsToolStripMenuItem.Click, RectangleToolStripMenuItem.Click, ImageToolStripMenuItem.Click
        Dim nei = OverlayGestion.OverlaysList.Count

        OverlayGestion.OverlaysList.Add(New Overlay(sender.Tag, sender.Text))
        OverlayGestion.ActiveOverlays.Add(True)
        OverlaysCheckedListBox.Items.Add(OverlayGestion.OverlaysList(nei).Name)
        OverlaysCheckedListBox.SetItemChecked(nei, OverlayGestion.ActiveOverlays(nei))
    End Sub

    Private Sub OverlaysCheckedListBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles OverlaysCheckedListBox.SelectedValueChanged
        If OverlaysCheckedListBox.SelectedIndex > -1 Then
            Dim refresh = False
            For i = 0 To OverlaysCheckedListBox.Items.Count - 1
                OverlayGestion.OverlaysList(i).Form.Hide()
                If Not OverlayGestion.ActiveOverlays(i) = OverlaysCheckedListBox.GetItemChecked(i) Then
                    OverlayGestion.ActiveOverlays(i) = OverlaysCheckedListBox.GetItemChecked(i)
                    If Not OverlayGestion.OverlaysList(i).UseOldSystem Then CType(OverlayGestion.OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.Hide()

                    refresh = True
                    Timer1_Tick(sender, e)
                    Dim si = OverlaysCheckedListBox.SelectedIndex
                    OverlaysCheckedListBox.SelectedIndex = -1
                    OverlaysCheckedListBox.SelectedIndex = si
                    OverlayGestion.old_hwnd_equal_count = 0
                    'OverlayGestion.Timer3_Tick(sender, e)
                End If
                'OverlayGestion.OverlaysList(i).Form.Visible = OverlayGestion.ActiveOverlays(i)
                'If Not OverlayGestion.OverlaysList(i).UseOldSystem Then CType(OverlayGestion.OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.Visible = OverlayGestion.ActiveOverlays(i)

            Next
            'OverlayGestion.old_hwnd = IntPtr.Zero
            'Timer1_Tick(sender, e)
            If refresh Then
            End If
        End If
    End Sub
    Dim LastSelectedOverlay As Int32 = -1
    Private Sub OverlaysCheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OverlaysCheckedListBox.SelectedIndexChanged
        If OverlaysCheckedListBox.SelectedIndex > -1 And Not OverlaysCheckedListBox.SelectedIndex = LastSelectedOverlay And Not overlay_in_move Then
            LastSelectedOverlay = OverlaysCheckedListBox.SelectedIndex
            SplitContainer2.Panel2.Controls.Clear()
            'SplitContainer2.Panel2.Controls.Add(OverlayGestion.OverlaysSettings(OverlayGestion.OverlaysName.IndexOf(OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).Type)))
            'OverlayGestion.OverlaysSettings(OverlayGestion.OverlaysName.IndexOf(OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).Type)).SyncSettings()
            Dim i = OverlaysCheckedListBox.SelectedIndex
            SplitContainer2.Panel2.Tag = i
            Dim control = CreateControl(ControlType.TextBox, New Point(12, 12), {OverlayGestion.OverlaysList(i).Name})
            AddHandler control.TextChanged, AddressOf ChangedOverlayName
            SplitContainer2.Panel2.Controls.Add(control)
            control = CreateControl(ControlType.Button, New Point(12, 42), {"Configure size and position"})
            AddHandler control.Click, AddressOf ShowResizer
            SplitContainer2.Panel2.Controls.Add(control)
            control = CreateControl(ControlType.Label, New Point(12, 84), {"Opacity"})
            SplitContainer2.Panel2.Controls.Add(control)
            control = CreateControl(ControlType.Trackbar, New Point(55, 80), {0, 100, OverlayGestion.OverlaysList(i).Form.Opacity * 100, 10})
            AddHandler CType(control, TrackBar).ValueChanged, AddressOf ChangedOverlayOpacity
            SplitContainer2.Panel2.Controls.Add(control)
            Dim CSettings = OverlayGestion.OverlaysList(i).Overlay.ClientSettings
            For j = 0 To CSettings.Count - 1
                Select Case CSettings(j).Type
                    Case Overlay.Setting.SettingType.TextBox
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                        control = CreateControl(ControlType.TextBox, New Point(12 + control.Width, 110 + j * 30), {CallByName(OverlayGestion.OverlaysList(i).Overlay.Settings, CSettings(j).Reference, CallType.Get)})
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, TextBox).TextChanged, AddressOf ChangedTextOverlaySetting
                        'AddHandler CType(control, TextBox).Leave, AddressOf ComboBox1_Leave
                        'AddHandler CType(control, TextBox).Enter, AddressOf ComboBox1_Enter
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Overlay.Setting.SettingType.Trackbar
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                        control = CreateControl(ControlType.Trackbar, New Point(12 + control.Width, 110 + j * 30), {CSettings(j).Min, CSettings(j).Max, CallByName(OverlayGestion.OverlaysList(i).Overlay.Settings, CSettings(j).Reference, CallType.Get), (CSettings(j).Max - CSettings(j).Min) / 10})
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, TrackBar).ValueChanged, AddressOf ChangedValueOverlaySetting
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Overlay.Setting.SettingType.ComboBox
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                        control = CreateControl(ControlType.ComboBox, New Point(12 + control.Width, 110 + j * 30), CSettings(j).Values, SelectedIndex:=CallByName(OverlayGestion.OverlaysList(i).Overlay.Settings, CSettings(j).Reference, CallType.Get))
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, ComboBox).SelectedIndexChanged, AddressOf ChangedSelectedIndexOverlaySetting
                        'AddHandler CType(control, ComboBox).DropDownClosed, AddressOf ComboBox1_Leave
                        'AddHandler CType(control, ComboBox).DropDown, AddressOf ComboBox1_Enter
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Overlay.Setting.SettingType.Checkbox
                        control = CreateControl(ControlType.Checkbox, New Point(12, 110 + j * 30), {CSettings(j).Name, CallByName(OverlayGestion.OverlaysList(i).Overlay.Settings, CSettings(j).Reference, CallType.Get), (CSettings(j).Max - CSettings(j).Min) / 10})
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, CheckBox).CheckedChanged, AddressOf ChangedCheckedOverlaySetting
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Overlay.Setting.SettingType.Color
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                        control = CreateControl(ControlType.Button, New Point(12 + control.Width, 110 + j * 30), {""})
                        control.Size = New Size(23, 23)
                        control.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                        control.BackColor = CallByName(OverlayGestion.OverlaysList(i).Overlay.Settings, CSettings(j).Reference, CallType.Get)
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, Button).Click, AddressOf ChangeColorOverlaySetting
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Overlay.Setting.SettingType.Font
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                        control = CreateControl(ControlType.Button, New Point(12 + control.Width, 110 + j * 30), {"Change font..."})
                        control.Size = New Size(90, 23)
                        control.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                        control.Tag = CSettings(j).Reference
                        control.Name = j
                        AddHandler CType(control, Button).Click, AddressOf ChangeFontOverlaySetting
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                    Case Else
                        control = CreateControl(ControlType.Label, New Point(12, 114 + j * 30), {CSettings(j).Name})
                        SplitContainer2.Panel2.Controls.Add(control)
                        control.BringToFront()
                End Select
            Next
            If OverlayGestion.OverlaysList(i).Type = "Custom" Then
                control = CreateControl(ControlType.Button, New Point(12, 114 + CSettings.Count * 30), {"View Custom Arguments List"})
                AddHandler control.Click, AddressOf ShowCustomArgumentsList
                SplitContainer2.Panel2.Controls.Add(control)
            End If
            UseOldOverlaySystemToolStripMenuItem.Checked = OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).UseOldSystem
        End If
    End Sub
    Enum ControlType
        Label = 0
        TextBox = 1
        Trackbar = 2
        ComboBox = 3
        Checkbox = 4
        Button = 5
    End Enum
    Overloads Function CreateControl(Type As ControlType, Location As Point, Optional Values As String() = Nothing, Optional FontSize As Single = 8, Optional SelectedIndex As Int32 = -1) As Control
        Select Case Type
            Case 1
                Dim control As New TextBox
                control.BorderStyle = BorderStyle.FixedSingle
                control.BackColor = Color.FromArgb(50, 50, 54)
                control.ForeColor = Color.White
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                control.Size = New Size(SplitContainer2.Panel2.Size.Width - (Location.X + 12), 20)
                control.Location = Location
                control.Text = Values(0)
                control.Multiline = True
                Return control
            Case 2
                Dim control As New TrackBar
                control.BackColor = Color.FromArgb(55, 55, 59)
                control.ForeColor = Color.White
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                control.Size = New Size(SplitContainer2.Panel2.Size.Width - (Location.X + 12), 20)
                control.Location = Location
                control.Minimum = Values(0)
                control.Maximum = Values(1)
                control.Value = Values(2)
                If Values.Count >= 4 Then control.TickFrequency = Values(3)
                Return control
            Case 3
                Dim control As New ComboBox
                control.DropDownStyle = ComboBoxStyle.DropDownList
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                control.Size = New Size(SplitContainer2.Panel2.Size.Width - (Location.X + 12), 20)
                control.Location = Location
                control.Items.AddRange(Values)
                control.SelectedIndex = SelectedIndex
                Return control
            Case 4
                Dim control As New CheckBox
                control.BackColor = Color.FromArgb(55, 55, 59)
                control.ForeColor = Color.White
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                control.AutoSize = True
                control.Font = New Font("Microsoft Sans Serif", FontSize)
                control.Location = Location
                control.Text = Values(0)
                control.Checked = Values(1)
                Return control
            Case 5
                Dim control As New Button
                control.FlatStyle = FlatStyle.Flat
                control.FlatAppearance.BorderSize = 1
                control.BackColor = Color.FromArgb(55, 55, 59)
                control.ForeColor = Color.White
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                control.Size = New Size(SplitContainer2.Panel2.Size.Width - (Location.X + 12), 23)
                control.Location = Location
                control.Text = Values(0)
                Return control
            Case Else
                Dim control As New Label
                control.BackColor = Color.FromArgb(55, 55, 59)
                control.ForeColor = Color.White
                control.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                control.AutoSize = True
                control.Font = New Font("Microsoft Sans Serif", FontSize)
                control.Location = Location
                control.Text = Values(0)
                Return control
        End Select
    End Function
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you sure, you want to delete this overlay ?", 4, "Are-you sure ?") = MsgBoxResult.Yes Then
            Dim selected_index = OverlaysCheckedListBox.SelectedIndex
            OverlayGestion.ActiveOverlays.RemoveAt(selected_index)
            OverlayGestion.OverlaysList(selected_index).Form.Dispose()
            If Not OverlayGestion.OverlaysList(selected_index).UseOldSystem Then CType(OverlayGestion.OverlaysList(selected_index).Form, DefaultOverlay).m_layeredWnd.Dispose()
            OverlayGestion.OverlaysList.RemoveAt(selected_index)
                OverlaysCheckedListBox.Items.RemoveAt(selected_index)
                OverlaysCheckedListBox.SelectedIndex = Math.Min(selected_index, OverlaysCheckedListBox.Items.Count - 1)
                Timer1_Tick(sender, e)
            End If
    End Sub
    Public before_overlay_resize_size As Size
    Public before_overlay_resize_location As Point
    Sub ShowResizer()
        Dim selected_overlay As Form = OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).Form
        before_overlay_resize_size = selected_overlay.Size
        before_overlay_resize_location = selected_overlay.Location
        IgnoreActiveForm = True
        OverlayGestion.StartIgnoreTopMost()
        ZoneConfig.ShowDialog()
        OverlayGestion.StopIgnoreTopMost()
        IgnoreActiveForm = False
    End Sub
    Sub ShowCustomArgumentsList()
        IgnoreActiveForm = True
        OverlayGestion.StartIgnoreTopMost()
        CustomArgumentsList.ShowDialog()
        OverlayGestion.StopIgnoreTopMost()
        IgnoreActiveForm = False
    End Sub
    Sub ChangedOverlayName(sender As Object, e As EventArgs)
        OverlayGestion.OverlaysList(sender.Parent.Tag).Name = sender.Text
        OverlayGestion.OverlaysList(sender.Parent.Tag).Form.Text = sender.Text
        Dim si = OverlaysCheckedListBox.SelectedIndex
        OverlaysCheckedListBox.Items.Item(sender.Parent.Tag) = sender.Text
        OverlaysCheckedListBox.SelectedIndex = si
    End Sub
    Sub ChangedOverlayOpacity(sender As Object, e As EventArgs)
        OverlayGestion.OverlaysList(sender.Parent.Tag).Form.Opacity = sender.Value / 100
    End Sub
    Sub ChangedTextOverlaySetting(sender As Object, e As EventArgs)
        CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, sender.Text)
    End Sub
    Sub ChangedValueOverlaySetting(sender As Object, e As EventArgs)
        CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, sender.Value)
    End Sub
    Sub ChangedSelectedIndexOverlaySetting(sender As Object, e As EventArgs)
        CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, sender.SelectedIndex)
    End Sub
    Sub ChangedCheckedOverlaySetting(sender As Object, e As EventArgs)
        CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, sender.Checked)
    End Sub
    Sub ChangeColorOverlaySetting(sender As Object, e As EventArgs)
        Dim dialog As New ColorDialog
        dialog.AllowFullOpen = True
        dialog.Color = CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Get)
        dialog.FullOpen = True
        OverlayGestion.StartIgnoreTopMost()
        IgnoreActiveForm = True
        If dialog.ShowDialog() = DialogResult.OK Then
            sender.BackColor = dialog.Color
            CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, dialog.Color)
        End If
        IgnoreActiveForm = False
        OverlayGestion.StopIgnoreTopMost()
        Activate()
    End Sub
    Sub ChangeFontOverlaySetting(sender As Object, e As EventArgs)
        Dim dialog As New FontDialog
        dialog.Font = CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Get)
        OverlayGestion.StartIgnoreTopMost()
        IgnoreActiveForm = True
        If dialog.ShowDialog() = DialogResult.OK Then
            CallByName(OverlayGestion.OverlaysList(sender.Parent.Tag).Overlay.Settings, sender.Tag, CallType.Set, dialog.Font)
        End If
        IgnoreActiveForm = False
        OverlayGestion.StopIgnoreTopMost()
        Activate()
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
    Public Sub SaveSettings()
        Dim xDoc As New XDocument
        xDoc.Add(
            New XElement("settings",
                    New XElement("Version", 0.202),
                    New XElement("ForceTopMost", OverlayGestion.ForceTopMost),
                    New XElement("UpdateCanal", OverlayGestion.UpdateCanal),
                    New XElement("BetaCode", OverlayGestion.Betacode),
                    New XElement("modules"), New XElement("overlays")
                )
            )
        For i = 0 To OverlayGestion.ModulesID.Count - 1
            Dim custom As XElement = New XElement("settings")
            Select Case OverlayGestion.ModulesID(i)
                Case "MusicModule"
                    custom = MusicModule.Save
                Case "HardwareInfosModule"
                    custom = HardwareInfosModule.Save
            End Select
            xDoc.Element("settings").Element("modules").Add(New XElement(OverlayGestion.ModulesID(i),
                                                                         New XElement("enabled", OverlayGestion.ActiveModules(i)),
                                                                         New XElement("custom", custom)
))
        Next
        For i = 0 To OverlayGestion.OverlaysList.Count - 1
            xDoc.Element("settings").Element("overlays").Add(New XElement("overlay",
                                                                         New XElement("enabled", OverlayGestion.ActiveOverlays(i)),
                                                                         New XElement("use_old", OverlayGestion.OverlaysList(i).UseOldSystem),
                                                                         New XElement("name", OverlayGestion.OverlaysList(i).Name),
                                                                         New XElement("type", OverlayGestion.OverlaysList(i).Type),
                                                                         New XElement("location_x", OverlayGestion.OverlaysList(i).Location.X),
                                                                         New XElement("location_y", OverlayGestion.OverlaysList(i).Location.Y),
                                                                         New XElement("size_w", OverlayGestion.OverlaysList(i).Form.Size.Width),
                                                                         New XElement("size_h", OverlayGestion.OverlaysList(i).Form.Size.Height),
                                                                         New XElement("opacity", OverlayGestion.OverlaysList(i).Form.Opacity),
                                                                         New XElement("custom", OverlayGestion.OverlaysList(i).Overlay.Save())
                                                                         ))
        Next
        xDoc.Save(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MAP/config"))
    End Sub
    Public Sub LoadSettings()
        Dim xDoc = XDocument.Load(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MAP/config"))
        Dim Version As Double = 0.2
        Try
            Version = xDoc.Element("settings").Element("Version").Value.Replace(".", ",")
        Catch
        End Try
        OverlayGestion.ForceTopMost = xDoc.Element("settings").Element("ForceTopMost")
        If Version >= 0.202 Then
            OverlayGestion.UpdateCanal = xDoc.Element("settings").Element("UpdateCanal")
            OverlayGestion.Betacode = xDoc.Element("settings").Element("BetaCode")
        End If
        If Version >= 0.201 Then
            For Each x In xDoc.Element("settings").Element("modules").Elements
                OverlayGestion.ActiveModules(OverlayGestion.ModulesID.ToList().IndexOf(x.Name.LocalName)) = x.Element("enabled")
                Select Case x.Name.LocalName
                    Case "MusicModule"
                        MusicModule.Load(x.Element("custom"))
                    Case "HardwareInfosModule"
                        HardwareInfosModule.Load(x.Element("custom"))
                End Select
            Next
        Else
            For Each x In xDoc.Element("settings").Element("modules").Elements
                OverlayGestion.ActiveModules(OverlayGestion.ModulesID.ToList().IndexOf(x.Name.LocalName)) = x.Value
            Next
        End If
        OverlayGestion.OverlaysList.Clear()
        OverlayGestion.ActiveOverlays.Clear()
        For Each x In xDoc.Element("settings").Element("overlays").Elements
            OverlayGestion.OverlaysList.Add(New Overlay(x.Elements("type").Value, x.Element("name").Value, x.Element("custom")))
            OverlayGestion.ActiveOverlays.Add(x.Element("enabled").Value)
            If Version >= 0.201 Then OverlayGestion.OverlaysList.Last.UseOldSystem = x.Element("use_old").Value
            OverlayGestion.OverlaysList.Last.Location = New Point(x.Element("location_x").Value, x.Element("location_y").Value)
            OverlayGestion.OverlaysList.Last.Form.Location = New Point(x.Element("location_x").Value, x.Element("location_y").Value)
            OverlayGestion.OverlaysList.Last.Form.Size = New Size(x.Element("size_w").Value, x.Element("size_h").Value)
            OverlayGestion.OverlaysList.Last.Form.Opacity = x.Element("opacity").Value.Replace(".", ",")
        Next
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveSettings()
    End Sub

    Private Sub ForceTopmostCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ForceTopmostCheckBox.CheckedChanged
        OverlayGestion.ForceTopMost = ForceTopmostCheckBox.Checked
    End Sub

    Private Sub DuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateToolStripMenuItem.Click
        Dim selected_index = OverlaysCheckedListBox.SelectedIndex
        OverlayGestion.ActiveOverlays.Insert(selected_index + 1, OverlayGestion.ActiveOverlays(selected_index))
        OverlayGestion.OverlaysList.Insert(selected_index + 1, New Overlay(OverlayGestion.OverlaysList(selected_index).Type, OverlayGestion.OverlaysList(selected_index).Name, New XElement("custom", OverlayGestion.OverlaysList(selected_index).Overlay.Save())))
        OverlayGestion.OverlaysList(selected_index + 1).Location = OverlayGestion.OverlaysList(selected_index).Location
        OverlayGestion.OverlaysList(selected_index + 1).Form.Location = OverlayGestion.OverlaysList(selected_index).Form.Location
        OverlayGestion.OverlaysList(selected_index + 1).Form.Size = OverlayGestion.OverlaysList(selected_index).Form.Size
        OverlayGestion.OverlaysList(selected_index + 1).Form.Opacity = OverlayGestion.OverlaysList(selected_index).Form.Opacity
        Timer1_Tick(sender, e)
    End Sub
    Dim overlay_in_move As Boolean = False
    Private Sub BringUpALevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BringUpALevelToolStripMenuItem.Click
        Dim selected_index = OverlaysCheckedListBox.SelectedIndex
        If selected_index >= 1 Then
            overlay_in_move = True
            Dim ActiveOverlay = OverlayGestion.ActiveOverlays(selected_index)
            Dim ActiveOverlay_ = OverlayGestion.ActiveOverlays(selected_index - 1)
            Dim Overlay = OverlayGestion.OverlaysList(selected_index)
            'OverlayGestion.ActiveOverlays.RemoveAt(selected_index)
            OverlayGestion.OverlaysList.RemoveAt(selected_index)
            'OverlayGestion.ActiveOverlays.Insert(Math.Max(0, selected_index - 1), ActiveOverlay)
            OverlayGestion.OverlaysList.Insert(Math.Max(0, selected_index - 1), Overlay)
            OverlayGestion.ActiveOverlays(selected_index) = ActiveOverlay_
            OverlayGestion.ActiveOverlays(selected_index - 1) = ActiveOverlay
            OverlaysCheckedListBox.SetItemChecked(selected_index, ActiveOverlay_)
            OverlaysCheckedListBox.SetItemChecked(selected_index - 1, ActiveOverlay)
            'Dim hwnd = OverlayGestion.GetActiveWindow()
            'OverlayGestion.OverlaysList(selected_index).Form.BringToFront()
            'OverlayGestion.SetActiveWindow(hwnd)
            OverlayGestion.old_hwnd_equal_count = 1
            OverlayGestion.OverlaysList(selected_index).Form.Hide()
            OverlaysCheckedListBox.SelectedIndex -= 1
            Timer1_Tick(sender, e)
            OverlayGestion.Timer3_Tick(sender, e)
            overlay_in_move = False
        End If
    End Sub

    Private Sub ComeDownFromALevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComeDownFromALevelToolStripMenuItem.Click
        Dim selected_index = OverlaysCheckedListBox.SelectedIndex
        If selected_index <= OverlaysCheckedListBox.Items.Count - 2 Then
            overlay_in_move = True
            Dim ActiveOverlay = OverlayGestion.ActiveOverlays(selected_index)
            Dim ActiveOverlay_ = OverlayGestion.ActiveOverlays(selected_index + 1)
            Dim Overlay = OverlayGestion.OverlaysList(selected_index)
            'OverlayGestion.ActiveOverlays.RemoveAt(selected_index)
            OverlayGestion.OverlaysList.RemoveAt(selected_index)
            'OverlayGestion.ActiveOverlays.Insert(Math.Min(OverlayGestion.ActiveOverlays.Count, selected_index + 1), ActiveOverlay)
            OverlayGestion.OverlaysList.Insert(Math.Min(OverlayGestion.OverlaysList.Count, selected_index + 1), Overlay)
            OverlayGestion.ActiveOverlays(selected_index) = ActiveOverlay_
            OverlayGestion.ActiveOverlays(selected_index + 1) = ActiveOverlay
            OverlaysCheckedListBox.SetItemChecked(selected_index, ActiveOverlay_)
            OverlaysCheckedListBox.SetItemChecked(selected_index + 1, ActiveOverlay)
            'Dim hwnd = OverlayGestion.GetActiveWindow()
            'OverlayGestion.OverlaysList(selected_index).Form.SendToBack()
            'OverlayGestion.SetActiveWindow(hwnd)
            OverlayGestion.old_hwnd_equal_count = 1
            OverlayGestion.OverlaysList(selected_index).Form.Hide()
            OverlaysCheckedListBox.SelectedIndex += 1
            Timer1_Tick(sender, e)
            OverlayGestion.Timer3_Tick(sender, e)
            overlay_in_move = False
        End If
    End Sub

    Private Sub OverlaysCheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles OverlaysCheckedListBox.KeyDown
        If e.Control And e.KeyCode = Keys.Up Then
            BringUpALevelToolStripMenuItem_Click(sender, e)
            'OverlaysCheckedListBox.SelectedIndex += 1
            e.Handled = True
            e.SuppressKeyPress = True
        ElseIf e.Control And e.KeyCode = Keys.Down Then
            ComeDownFromALevelToolStripMenuItem_Click(sender, e)
            'OverlaysCheckedListBox.SelectedIndex -= 1
            e.Handled = True
            e.SuppressKeyPress = True
        ElseIf e.Control And e.KeyCode = Keys.D Then
            DuplicateToolStripMenuItem_Click(sender, e)
            'OverlaysCheckedListBox.SelectedIndex -= 1
            e.Handled = True
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete Then

            Dim selected_index = OverlaysCheckedListBox.SelectedIndex
            OverlayGestion.ActiveOverlays.RemoveAt(selected_index)
            OverlayGestion.OverlaysList(selected_index).Form.Dispose()
            OverlayGestion.OverlaysList.RemoveAt(selected_index)
            OverlaysCheckedListBox.Items.RemoveAt(selected_index)
            OverlaysCheckedListBox.SelectedIndex = Math.Min(selected_index, OverlaysCheckedListBox.Items.Count - 1)
            Timer1_Tick(sender, e)

            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub OverlaysTabButton_Click(sender As Object, e As MouseEventArgs) Handles OverlaysTabButton.MouseDown

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim dlg As New ReadonlyTextboxDialog
        dlg.Text = "MAP License"
        dlg.ReadOnlyText = "MAP License :

[libzplay]

libZPlay is released under GNU GPL license.

GNU GENERAL PUBLIC LICENSE

 Version 2, June 1991

Copyright (C) 1989, 1991 Free Software Foundation, Inc.  
51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA

Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.

 
Preamble

 

The licenses for most software are designed to take away your freedom to share and change it. By contrast, the GNU General Public License is intended to guarantee your freedom to share and change free software--to make sure the software is free for all its users. This General Public License applies to most of the Free Software Foundation's software and to any other program whose authors commit to using it. (Some other Free Software Foundation software is covered by the GNU Lesser General Public License instead.) You can apply it to your programs, too.  

When we speak of free software, we are referring to freedom, not price. Our General Public Licenses are designed to make sure that you have the freedom to distribute copies of free software (and charge for this service if you wish), that you receive source code or can get it if you want it, that you can change the software or use pieces of it in new free programs; and that you know you can do these things.  

To protect your rights, we need to make restrictions that forbid anyone to deny you these rights or to ask you to surrender the rights. These restrictions translate to certain responsibilities for you if you distribute copies of the software, or if you modify it.  

For example, if you distribute copies of such a program, whether gratis or for a fee, you must give the recipients all the rights that you have. You must make sure that they, too, receive or can get the source code. And you must show them these terms so they know their rights.  

We protect your rights with two steps: (1) copyright the software, and (2) offer you this license which gives you legal permission to copy, distribute and/or modify the software.  

Also, for each author's protection and ours, we want to make certain that everyone understands that there is no warranty for this free software. If the software is modified by someone else and passed on, we want its recipients to know that what they have is not the original, so that any problems introduced by others will not reflect on the original authors' reputations.  

Finally, any free program is threatened constantly by software patents. We wish to avoid the danger that redistributors of a free program will individually obtain patent licenses, in effect making the program proprietary. To prevent this, we have made it clear that any patent must be licensed for everyone's free use or not licensed at all.  

The precise terms and conditions for copying, distribution and modification follow.  

 
TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION

 

0. This License applies to any program or other work which contains a notice placed by the copyright holder saying it may be distributed under the terms of this General Public License. The ""Program"", below, refers to any such program or work, and a ""work based on the Program"" means either the Program or any derivative work under copyright law: that is to say, a work containing the Program or a portion of it, either verbatim or with modifications and/or translated into another language. (Hereinafter, translation is included without limitation in the term ""modification"".) Each licensee is addressed as ""you"".  

Activities other than copying, distribution and modification are not covered by this License; they are outside its scope. The act of running the Program is not restricted, and the output from the Program is covered only if its contents constitute a work based on the Program (independent of having been made by running the Program). Whether that is true depends on what the Program does.  

1. You may copy and distribute verbatim copies of the Program's source code as you receive it, in any medium, provided that you conspicuously and appropriately publish on each copy an appropriate copyright notice and disclaimer of warranty; keep intact all the notices that refer to this License and to the absence of any warranty; and give any other recipients of the Program a copy of this License along with the Program.  

You may charge a fee for the physical act of transferring a copy, and you may at your option offer warranty protection in exchange for a fee.  

2. You may modify your copy or copies of the Program or any portion of it, thus forming a work based on the Program, and copy and distribute such modifications or work under the terms of Section 1 above, provided that you also meet all of these conditions: 

    a) You must cause the modified files to carry prominent notices stating that you changed the files and the date of any change.
    b) You must cause any work that you distribute or publish, that in whole or in part contains or is derived from the Program or any part thereof, to be licensed as a whole at no charge to all third parties under the terms of this License.
    c) If the modified program normally reads commands interactively when run, you must cause it, when started running for such interactive use in the most ordinary way, to print or display an announcement including an appropriate copyright notice and a notice that there is no warranty (or else, saying that you provide a warranty) and that users may redistribute the program under these conditions, and telling the user how to view a copy of this License. (Exception: if the Program itself is interactive but does not normally print such an announcement, your work based on the Program is not required to print an announcement.)

These requirements apply to the modified work as a whole. If identifiable sections of that work are not derived from the Program, and can be reasonably considered independent and separate works in themselves, then this License, and its terms, do not apply to those sections when you distribute them as separate works. But when you distribute the same sections as part of a whole which is a work based on the Program, the distribution of the whole must be on the terms of this License, whose permissions for other licensees extend to the entire whole, and thus to each and every part regardless of who wrote it.  

Thus, it is not the intent of this section to claim rights or contest your rights to work written entirely by you; rather, the intent is to exercise the right to control the distribution of derivative or collective works based on the Program.  

In addition, mere aggregation of another work not based on the Program with the Program (or with a work based on the Program) on a volume of a storage or distribution medium does not bring the other work under the scope of this License.  

3. You may copy and distribute the Program (or a work based on it, under Section 2) in object code or executable form under the terms of Sections 1 and 2 above provided that you also do one of the following: 

    a) Accompany it with the complete corresponding machine-readable source code, which must be distributed under the terms of Sections 1 and 2 above on a medium customarily used for software interchange; or,
    b) Accompany it with a written offer, valid for at least three years, to give any third party, for a charge no more than your cost of physically performing source distribution, a complete machine-readable copy of the corresponding source code, to be distributed under the terms of Sections 1 and 2 above on a medium customarily used for software interchange; or,
    c) Accompany it with the information you received as to the offer to distribute corresponding source code. (This alternative is allowed only for noncommercial distribution and only if you received the program in object code or executable form with such an offer, in accord with Subsection b above.)

The source code for a work means the preferred form of the work for making modifications to it. For an executable work, complete source code means all the source code for all modules it contains, plus any associated interface definition files, plus the scripts used to control compilation and installation of the executable. However, as a special exception, the source code distributed need not include anything that is normally distributed (in either source or binary form) with the major components (compiler, kernel, and so on) of the operating system on which the executable runs, unless that component itself accompanies the executable.  

If distribution of executable or object code is made by offering access to copy from a designated place, then offering equivalent access to copy the source code from the same place counts as distribution of the source code, even though third parties are not compelled to copy the source along with the object code.  

4. You may not copy, modify, sublicense, or distribute the Program except as expressly provided under this License. Any attempt otherwise to copy, modify, sublicense or distribute the Program is void, and will automatically terminate your rights under this License. However, parties who have received copies, or rights, from you under this License will not have their licenses terminated so long as such parties remain in full compliance.  

5. You are not required to accept this License, since you have not signed it. However, nothing else grants you permission to modify or distribute the Program or its derivative works. These actions are prohibited by law if you do not accept this License. Therefore, by modifying or distributing the Program (or any work based on the Program), you indicate your acceptance of this License to do so, and all its terms and conditions for copying, distributing or modifying the Program or works based on it.  

6. Each time you redistribute the Program (or any work based on the Program), the recipient automatically receives a license from the original licensor to copy, distribute or modify the Program subject to these terms and conditions. You may not impose any further restrictions on the recipients' exercise of the rights granted herein. You are not responsible for enforcing compliance by third parties to this License.  

7. If, as a consequence of a court judgment or allegation of patent infringement or for any other reason (not limited to patent issues), conditions are imposed on you (whether by court order, agreement or otherwise) that contradict the conditions of this License, they do not excuse you from the conditions of this License. If you cannot distribute so as to satisfy simultaneously your obligations under this License and any other pertinent obligations, then as a consequence you may not distribute the Program at all. For example, if a patent license would not permit royalty-free redistribution of the Program by all those who receive copies directly or indirectly through you, then the only way you could satisfy both it and this License would be to refrain entirely from distribution of the Program.  

If any portion of this section is held invalid or unenforceable under any particular circumstance, the balance of the section is intended to apply and the section as a whole is intended to apply in other circumstances.  

It is not the purpose of this section to induce you to infringe any patents or other property right claims or to contest validity of any such claims; this section has the sole purpose of protecting the integrity of the free software distribution system, which is implemented by public license practices. Many people have made generous contributions to the wide range of software distributed through that system in reliance on consistent application of that system; it is up to the author/donor to decide if he or she is willing to distribute software through any other system and a licensee cannot impose that choice.  

This section is intended to make thoroughly clear what is believed to be a consequence of the rest of this License.  

8. If the distribution and/or use of the Program is restricted in certain countries either by patents or by copyrighted interfaces, the original copyright holder who places the Program under this License may add an explicit geographical distribution limitation excluding those countries, so that distribution is permitted only in or among countries not thus excluded. In such case, this License incorporates the limitation as if written in the body of this License.  

9. The Free Software Foundation may publish revised and/or new versions of the General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.  

Each version is given a distinguishing version number. If the Program specifies a version number of this License which applies to it and ""any later version"", you have the option of following the terms and conditions either of that version or of any later version published by the Free Software Foundation. If the Program does not specify a version number of this License, you may choose any version ever published by the Free Software Foundation.  

10. If you wish to incorporate parts of the Program into other free programs whose distribution conditions are different, write to the author to ask for permission. For software which is copyrighted by the Free Software Foundation, write to the Free Software Foundation; we sometimes make exceptions for this. Our decision will be guided by the two goals of preserving the free status of all derivatives of our free software and of promoting the sharing and reuse of software generally.  

NO WARRANTY  

11. BECAUSE THE PROGRAM IS LICENSED FREE OF CHARGE, THERE IS NO WARRANTY FOR THE PROGRAM, TO THE EXTENT PERMITTED BY APPLICABLE LAW. EXCEPT WHEN OTHERWISE STATED IN WRITING THE COPYRIGHT HOLDERS AND/OR OTHER PARTIES PROVIDE THE PROGRAM ""AS IS"" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE ENTIRE RISK AS TO THE QUALITY AND PERFORMANCE OF THE PROGRAM IS WITH YOU. SHOULD THE PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF ALL NECESSARY SERVICING, REPAIR OR CORRECTION.  

12. IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MAY MODIFY AND/OR REDISTRIBUTE THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED TO LOSS OF DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS), EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
END OF TERMS AND CONDITIONS

 
How to Apply These Terms to Your New Programs

 

If you develop a new program, and you want it to be of the greatest possible use to the public, the best way to achieve this is to make it free software which everyone can redistribute and change under these terms.  

To do so, attach the following notices to the program. It is safest to attach them to the start of each source file to most effectively convey the exclusion of warranty; and each file should have at least the ""copyright"" line and a pointer to where the full notice is found.

one line to give the program's name and an idea of what it does.
Copyright (C) yyyy  name of author

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

 

Also add information on how to contact you by electronic and paper mail.  

If the program is interactive, make it output a short notice like this when it starts in an interactive mode:

Gnomovision version 69, Copyright (C) year name of author
Gnomovision comes with ABSOLUTELY NO WARRANTY; for details
type `show w'.  This is free software, and you are welcome
to redistribute it under certain conditions; type `show c' 
for details.

 

The hypothetical commands `show w' and `show c' should show the appropriate parts of the General Public License. Of course, the commands you use may be called something other than `show w' and `show c'; they could even be mouse-clicks or menu items--whatever suits your program.  

You should also get your employer (if you work as a programmer) or your school, if any, to sign a ""copyright disclaimer"" for the program, if necessary. Here is a sample; alter the names:

Yoyodyne, Inc., hereby disclaims all copyright
interest in the program `Gnomovision'
(which makes passes at compilers) written 
by James Hacker.

signature of Ty Coon, 1 April 1989
Ty Coon, President of Vice

 

This General Public License does not permit incorporating your program into proprietary programs. If your program is a subroutine library, you may consider it more useful to permit linking proprietary applications with the library. If this is what you want to do, use the GNU Lesser General Public License instead of this License.  


[perrybutler/id3taglibrary]

id3taglibrary is released under MIT license.

The MIT License (MIT)

Copyright (c) 2014 Perry Butler

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
"
        IgnoreActiveForm = True
        OverlayGestion.StartIgnoreTopMost()
        dlg.ShowDialog()
        OverlayGestion.StopIgnoreTopMost()
        IgnoreActiveForm = False
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim dlg As New ReadonlyTextboxDialog
        dlg.Text = "MAP Changelog (" & OverlayGestion.Version & ")"
        dlg.ReadOnlyText = "MAP Changelog :

--------------------------------------------------
    Version : 0.2.0.17
    Date : 29/03/2021

        Features :

            + Update canals.
            + Beta codes.


--------------------------------------------------
    Version : 0.2.0.16
    Date : 25/03/2021

        Features :

            + Image overlay.

 
    Sorry, this version is very lite, but I had another project to finish.

--------------------------------------------------
    Version : 0.2.0.15
    Date : 18/03/2021

        Features :

            + New format arg for the Custom overlay ""{url:https://pastebin.com/raw/3Z92pFn3}"".
            + Rectangle overlay.
            + [Music Module] Thumbnails are displayed.
            + [Music Module] Music Thumbnails overlay.

        Minor Features :

            + [Music Module] ID3v2 is now supported.

        Changes :
            
            + Progress bars are more beautiful.
            + Progress bars Rounding Level max is now at 97.

        Bugfixes :

            - Bug #2 (Error when starting MAP without internet)
            - Bug #3 (Settings are not auto-focused)

--------------------------------------------------
    Version : 0.2.0.14
    Date : 12/03/2021

        Major Feature :

            + Alpha color channel for overlays. And a way to restore the old overlays alpha.

        Features :

            + New progress bar style : ""Horizontal Full Rounded"".
            + Open two sessions of MAP is now impossible. (It opens the settings)
            + [Music Module] New play modes.
            + [Music Module] Audio file opening is now possible directely with the executable.
            + [Music Module] M3U files can be read. (Experimental)

        Minor Features :

            + Settings version. (To convert better for the future versions)
            + The overlays are now hidden in the ""Alt+Tab"".
            + [Music Module] The music volume is now synchronised with the Windows app volume.
            + [Music Module] Non-audio files can no longer be opened.

        Changes :
            
            + The FPS counter is slower.
            + The MAP Assembly is now signed.

        Bugfixes :

            - Bug #1 (We can close the overlays with ""Alt+F4"" and it crashes MAP)

--------------------------------------------------
    Version : 0.2.0.13
    Date : 27/02/2021

        Feature :

            + New progress bar overlay style to use all progress bar's parameters.

        Minor Features :

            + The ""Delete"" key can now remove overlays.
            + New shortcut key to duplicate overlays with ""Ctrl+D"".

        Change :

            + The Feedback link is now a Github link.

        Bugfixes :

            - Bug #-1 (We can edit the text in the changelog and licence)
            - Bug #-2 (Music Frequencies make continuous error)

--------------------------------------------------
    Version : 0.2.0.12
    Date : 23/02/2021

        Major Features :
            
            + Progress bar overlay. With the ""Value"" parameter as the same as ""Format"" of the custom overlay.
            + New context menu button to duplicate an overlay.
            + Added a way to change the overlay's level when using ""Ctrl+Up"" and ""Ctrl+Down"" or with the right click context menu.

        Features :

            + New values for the progress bar overlay value : ""{musicmodule:total_ms}"" and ""{musicmodule:current_ms}"".
            + License window.
            + Changelog window.
            + [Music Module] Music frequencies overlay with the spline drawing mode, remove reference points in function of the frequency rounding level.

        Minor Features :
            
            + Added a scrollbar to the overlay settings.
            + [Music Module] The keyboard shortcut to remove a music of the playlist is now show.

        Changes :
            
            + Changed the color of the ""Feedback"" link when it is active.
            + [Music Module] The playlist have now the ""Segoes UI"" font.
            + [Music Module] Frequency rounding level, parameter of the music frequencies overlay, is now a trackbar.

--------------------------------------------------
    0.2.0.11 and earlier do not have changelog.
        "
        IgnoreActiveForm = True
        OverlayGestion.StartIgnoreTopMost()
        dlg.ShowDialog()
        OverlayGestion.StopIgnoreTopMost()
        IgnoreActiveForm = False
    End Sub

    Private Sub UseOldOverlaySystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseOldOverlaySystemToolStripMenuItem.Click
        OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).UseOldSystem = Not OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).UseOldSystem
        UseOldOverlaySystemToolStripMenuItem.Checked = OverlayGestion.OverlaysList(OverlaysCheckedListBox.SelectedIndex).UseOldSystem
    End Sub

    Private Sub ModulesTabButton_Click(sender As Object, e As MouseEventArgs) Handles ModulesTabButton.MouseDown

    End Sub

    Private Sub UpdateCanalComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UpdateCanalComboBox.SelectedIndexChanged
        If UpdateCanalComboBox.SelectedIndex = 0 Then
            BetaCodeButton.Enabled = False
            BetaCodeTextBox.Enabled = False
            OverlayGestion.UpdateCanal = 0
        ElseIf UpdateCanalComboBox.SelectedIndex = 1 Then
            BetaCodeButton.Enabled = True
            BetaCodeTextBox.Enabled = True
            OverlayGestion.UpdateCanal = 1
        End If
        Dim context = TaskScheduler.FromCurrentSynchronizationContext
#Disable Warning BC42358 ' Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        Task.Run(Sub() OverlayGestion.CheckUpdate(context))
#Enable Warning BC42358 ' Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
    End Sub
    Private Sub BetaCodeButton_Click(sender As Object, e As EventArgs) Handles BetaCodeButton.Click
        If OverlayGestion.WaitForBetacode <= 0 Then
            If OverlayGestion.CheckBetaCode(BetaCodeTextBox.Text) Then
                OverlayGestion.Betacode = BetaCodeTextBox.Text
            Else
                OverlayGestion.WaitForBetacode = 30
                BetaCodeButton.Text = "Use (30)"
            End If
        End If
    End Sub
End Class