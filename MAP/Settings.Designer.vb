<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.FPSTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ModulesCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.ModuleDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ModuleNameTextBox = New System.Windows.Forms.TextBox()
        Me.ToggleModuleButton = New System.Windows.Forms.Button()
        Me.ModuleIconPictureBox = New System.Windows.Forms.PictureBox()
        Me.GeneralTabButton = New System.Windows.Forms.Button()
        Me.ModulesTabPanel = New System.Windows.Forms.Panel()
        Me.ModulesTabButton = New System.Windows.Forms.Button()
        Me.OverlaysTabButton = New System.Windows.Forms.Button()
        Me.GeneralTabPanel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BetaCodeTextBox = New System.Windows.Forms.TextBox()
        Me.BetaCodeButton = New System.Windows.Forms.Button()
        Me.UpdateCanalComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ForceTopmostCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OverlaysTabPanel = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.AddOverlayButton = New System.Windows.Forms.Button()
        Me.OverlaysPanelList = New System.Windows.Forms.Panel()
        Me.OverlaysCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.OverlayContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UseOldOverlaySystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BringUpALevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComeDownFromALevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DuplicateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NewOverlayContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MusicModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicFrequenciesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicThumbnailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RectangleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ModuleIconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ModulesTabPanel.SuspendLayout()
        Me.GeneralTabPanel.SuspendLayout()
        Me.OverlaysTabPanel.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.OverlaysPanelList.SuspendLayout()
        Me.OverlayContextMenuStrip.SuspendLayout()
        Me.NewOverlayContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "FPS :"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(3, 13)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(45, 13)
        Me.VersionLabel.TabIndex = 40
        Me.VersionLabel.Text = "Version"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 36)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(56, 13)
        Me.LinkLabel1.TabIndex = 42
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Feedback"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'FPSTimer
        '
        Me.FPSTimer.Enabled = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ModulesCheckedListBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ModuleDescriptionTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ModuleNameTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToggleModuleButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ModuleIconPictureBox)
        Me.SplitContainer1.Size = New System.Drawing.Size(662, 291)
        Me.SplitContainer1.SplitterDistance = 125
        Me.SplitContainer1.TabIndex = 44
        '
        'ModulesCheckedListBox
        '
        Me.ModulesCheckedListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ModulesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModulesCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModulesCheckedListBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModulesCheckedListBox.ForeColor = System.Drawing.Color.White
        Me.ModulesCheckedListBox.FormattingEnabled = True
        Me.ModulesCheckedListBox.Location = New System.Drawing.Point(0, 0)
        Me.ModulesCheckedListBox.Name = "ModulesCheckedListBox"
        Me.ModulesCheckedListBox.Size = New System.Drawing.Size(123, 289)
        Me.ModulesCheckedListBox.TabIndex = 44
        '
        'ModuleDescriptionTextBox
        '
        Me.ModuleDescriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModuleDescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ModuleDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModuleDescriptionTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ModuleDescriptionTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModuleDescriptionTextBox.ForeColor = System.Drawing.Color.White
        Me.ModuleDescriptionTextBox.Location = New System.Drawing.Point(110, 33)
        Me.ModuleDescriptionTextBox.Multiline = True
        Me.ModuleDescriptionTextBox.Name = "ModuleDescriptionTextBox"
        Me.ModuleDescriptionTextBox.ReadOnly = True
        Me.ModuleDescriptionTextBox.Size = New System.Drawing.Size(418, 71)
        Me.ModuleDescriptionTextBox.TabIndex = 49
        '
        'ModuleNameTextBox
        '
        Me.ModuleNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModuleNameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ModuleNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModuleNameTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ModuleNameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModuleNameTextBox.ForeColor = System.Drawing.Color.White
        Me.ModuleNameTextBox.Location = New System.Drawing.Point(110, 8)
        Me.ModuleNameTextBox.Name = "ModuleNameTextBox"
        Me.ModuleNameTextBox.ReadOnly = True
        Me.ModuleNameTextBox.Size = New System.Drawing.Size(418, 22)
        Me.ModuleNameTextBox.TabIndex = 48
        '
        'ToggleModuleButton
        '
        Me.ToggleModuleButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToggleModuleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ToggleModuleButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToggleModuleButton.Location = New System.Drawing.Point(8, 257)
        Me.ToggleModuleButton.Name = "ToggleModuleButton"
        Me.ToggleModuleButton.Size = New System.Drawing.Size(96, 23)
        Me.ToggleModuleButton.TabIndex = 47
        Me.ToggleModuleButton.Text = "Toggle Module"
        Me.ToggleModuleButton.UseVisualStyleBackColor = True
        Me.ToggleModuleButton.Visible = False
        '
        'ModuleIconPictureBox
        '
        Me.ModuleIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModuleIconPictureBox.Location = New System.Drawing.Point(8, 8)
        Me.ModuleIconPictureBox.MinimumSize = New System.Drawing.Size(32, 32)
        Me.ModuleIconPictureBox.Name = "ModuleIconPictureBox"
        Me.ModuleIconPictureBox.Size = New System.Drawing.Size(96, 96)
        Me.ModuleIconPictureBox.TabIndex = 0
        Me.ModuleIconPictureBox.TabStop = False
        '
        'GeneralTabButton
        '
        Me.GeneralTabButton.FlatAppearance.BorderSize = 2
        Me.GeneralTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GeneralTabButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralTabButton.Location = New System.Drawing.Point(12, 66)
        Me.GeneralTabButton.Name = "GeneralTabButton"
        Me.GeneralTabButton.Size = New System.Drawing.Size(75, 23)
        Me.GeneralTabButton.TabIndex = 45
        Me.GeneralTabButton.Text = "General"
        Me.GeneralTabButton.UseVisualStyleBackColor = True
        '
        'ModulesTabPanel
        '
        Me.ModulesTabPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModulesTabPanel.AutoSize = True
        Me.ModulesTabPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ModulesTabPanel.Controls.Add(Me.SplitContainer1)
        Me.ModulesTabPanel.Location = New System.Drawing.Point(12, 95)
        Me.ModulesTabPanel.Name = "ModulesTabPanel"
        Me.ModulesTabPanel.Size = New System.Drawing.Size(662, 291)
        Me.ModulesTabPanel.TabIndex = 44
        Me.ModulesTabPanel.Visible = False
        '
        'ModulesTabButton
        '
        Me.ModulesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModulesTabButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModulesTabButton.Location = New System.Drawing.Point(93, 66)
        Me.ModulesTabButton.Name = "ModulesTabButton"
        Me.ModulesTabButton.Size = New System.Drawing.Size(75, 23)
        Me.ModulesTabButton.TabIndex = 46
        Me.ModulesTabButton.Text = "Modules"
        Me.ModulesTabButton.UseVisualStyleBackColor = True
        '
        'OverlaysTabButton
        '
        Me.OverlaysTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OverlaysTabButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverlaysTabButton.Location = New System.Drawing.Point(174, 66)
        Me.OverlaysTabButton.Name = "OverlaysTabButton"
        Me.OverlaysTabButton.Size = New System.Drawing.Size(75, 23)
        Me.OverlaysTabButton.TabIndex = 48
        Me.OverlaysTabButton.Text = "Overlays"
        Me.OverlaysTabButton.UseVisualStyleBackColor = True
        '
        'GeneralTabPanel
        '
        Me.GeneralTabPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneralTabPanel.AutoSize = True
        Me.GeneralTabPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.GeneralTabPanel.Controls.Add(Me.Label6)
        Me.GeneralTabPanel.Controls.Add(Me.BetaCodeTextBox)
        Me.GeneralTabPanel.Controls.Add(Me.BetaCodeButton)
        Me.GeneralTabPanel.Controls.Add(Me.UpdateCanalComboBox)
        Me.GeneralTabPanel.Controls.Add(Me.Label5)
        Me.GeneralTabPanel.Controls.Add(Me.Label4)
        Me.GeneralTabPanel.Controls.Add(Me.ForceTopmostCheckBox)
        Me.GeneralTabPanel.Controls.Add(Me.Label3)
        Me.GeneralTabPanel.Location = New System.Drawing.Point(12, 95)
        Me.GeneralTabPanel.Name = "GeneralTabPanel"
        Me.GeneralTabPanel.Size = New System.Drawing.Size(662, 291)
        Me.GeneralTabPanel.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Use Beta Code"
        '
        'BetaCodeTextBox
        '
        Me.BetaCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetaCodeTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.BetaCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BetaCodeTextBox.Enabled = False
        Me.BetaCodeTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BetaCodeTextBox.ForeColor = System.Drawing.Color.White
        Me.BetaCodeTextBox.Location = New System.Drawing.Point(96, 123)
        Me.BetaCodeTextBox.Name = "BetaCodeTextBox"
        Me.BetaCodeTextBox.Size = New System.Drawing.Size(475, 22)
        Me.BetaCodeTextBox.TabIndex = 48
        '
        'BetaCodeButton
        '
        Me.BetaCodeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetaCodeButton.Enabled = False
        Me.BetaCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BetaCodeButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BetaCodeButton.Location = New System.Drawing.Point(577, 122)
        Me.BetaCodeButton.Name = "BetaCodeButton"
        Me.BetaCodeButton.Size = New System.Drawing.Size(75, 23)
        Me.BetaCodeButton.TabIndex = 47
        Me.BetaCodeButton.Text = "Use"
        Me.BetaCodeButton.UseVisualStyleBackColor = True
        '
        'UpdateCanalComboBox
        '
        Me.UpdateCanalComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdateCanalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UpdateCanalComboBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateCanalComboBox.FormattingEnabled = True
        Me.UpdateCanalComboBox.Items.AddRange(New Object() {"Stable", "Development"})
        Me.UpdateCanalComboBox.Location = New System.Drawing.Point(91, 95)
        Me.UpdateCanalComboBox.Name = "UpdateCanalComboBox"
        Me.UpdateCanalComboBox.Size = New System.Drawing.Size(561, 21)
        Me.UpdateCanalComboBox.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Updates"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Update Canal"
        '
        'ForceTopmostCheckBox
        '
        Me.ForceTopmostCheckBox.AutoSize = True
        Me.ForceTopmostCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForceTopmostCheckBox.Location = New System.Drawing.Point(16, 34)
        Me.ForceTopmostCheckBox.Name = "ForceTopmostCheckBox"
        Me.ForceTopmostCheckBox.Size = New System.Drawing.Size(190, 17)
        Me.ForceTopmostCheckBox.TabIndex = 1
        Me.ForceTopmostCheckBox.Text = "Force Top Most (Recommended)"
        Me.ForceTopmostCheckBox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "General"
        '
        'OverlaysTabPanel
        '
        Me.OverlaysTabPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OverlaysTabPanel.AutoSize = True
        Me.OverlaysTabPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.OverlaysTabPanel.Controls.Add(Me.SplitContainer2)
        Me.OverlaysTabPanel.Location = New System.Drawing.Point(12, 95)
        Me.OverlaysTabPanel.Name = "OverlaysTabPanel"
        Me.OverlaysTabPanel.Size = New System.Drawing.Size(662, 291)
        Me.OverlaysTabPanel.TabIndex = 46
        Me.OverlaysTabPanel.Visible = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.AddOverlayButton)
        Me.SplitContainer2.Panel1.Controls.Add(Me.OverlaysPanelList)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer2.Size = New System.Drawing.Size(662, 291)
        Me.SplitContainer2.SplitterDistance = 165
        Me.SplitContainer2.TabIndex = 0
        '
        'AddOverlayButton
        '
        Me.AddOverlayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddOverlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddOverlayButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddOverlayButton.Location = New System.Drawing.Point(0, 266)
        Me.AddOverlayButton.Name = "AddOverlayButton"
        Me.AddOverlayButton.Size = New System.Drawing.Size(82, 23)
        Me.AddOverlayButton.TabIndex = 49
        Me.AddOverlayButton.Text = "Add overlay"
        Me.AddOverlayButton.UseVisualStyleBackColor = True
        '
        'OverlaysPanelList
        '
        Me.OverlaysPanelList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OverlaysPanelList.AutoScroll = True
        Me.OverlaysPanelList.Controls.Add(Me.OverlaysCheckedListBox)
        Me.OverlaysPanelList.Location = New System.Drawing.Point(0, 0)
        Me.OverlaysPanelList.Name = "OverlaysPanelList"
        Me.OverlaysPanelList.Size = New System.Drawing.Size(160, 263)
        Me.OverlaysPanelList.TabIndex = 1
        '
        'OverlaysCheckedListBox
        '
        Me.OverlaysCheckedListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.OverlaysCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OverlaysCheckedListBox.ContextMenuStrip = Me.OverlayContextMenuStrip
        Me.OverlaysCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OverlaysCheckedListBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverlaysCheckedListBox.ForeColor = System.Drawing.Color.White
        Me.OverlaysCheckedListBox.FormattingEnabled = True
        Me.OverlaysCheckedListBox.Location = New System.Drawing.Point(0, 0)
        Me.OverlaysCheckedListBox.Name = "OverlaysCheckedListBox"
        Me.OverlaysCheckedListBox.Size = New System.Drawing.Size(160, 263)
        Me.OverlaysCheckedListBox.TabIndex = 0
        '
        'OverlayContextMenuStrip
        '
        Me.OverlayContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseOldOverlaySystemToolStripMenuItem, Me.ToolStripSeparator3, Me.BringUpALevelToolStripMenuItem, Me.ComeDownFromALevelToolStripMenuItem, Me.ToolStripSeparator2, Me.DuplicateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.OverlayContextMenuStrip.Name = "ContextMenuStrip1"
        Me.OverlayContextMenuStrip.Size = New System.Drawing.Size(270, 126)
        '
        'UseOldOverlaySystemToolStripMenuItem
        '
        Me.UseOldOverlaySystemToolStripMenuItem.Name = "UseOldOverlaySystemToolStripMenuItem"
        Me.UseOldOverlaySystemToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.UseOldOverlaySystemToolStripMenuItem.Text = "Use old overlay system"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(266, 6)
        '
        'BringUpALevelToolStripMenuItem
        '
        Me.BringUpALevelToolStripMenuItem.Name = "BringUpALevelToolStripMenuItem"
        Me.BringUpALevelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Up"
        Me.BringUpALevelToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.BringUpALevelToolStripMenuItem.Text = "Bring up a level"
        '
        'ComeDownFromALevelToolStripMenuItem
        '
        Me.ComeDownFromALevelToolStripMenuItem.Name = "ComeDownFromALevelToolStripMenuItem"
        Me.ComeDownFromALevelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Down"
        Me.ComeDownFromALevelToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.ComeDownFromALevelToolStripMenuItem.Text = "Come down from a level"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(266, 6)
        '
        'DuplicateToolStripMenuItem
        '
        Me.DuplicateToolStripMenuItem.Name = "DuplicateToolStripMenuItem"
        Me.DuplicateToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + D"
        Me.DuplicateToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.DuplicateToolStripMenuItem.Text = "Duplicate"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Select an overlay"
        Me.Label2.Visible = False
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 1000
        '
        'NewOverlayContextMenuStrip
        '
        Me.NewOverlayContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.MusicModuleToolStripMenuItem, Me.ProgressbarToolStripMenuItem, Me.CustomToolStripMenuItem, Me.RectangleToolStripMenuItem, Me.ImageToolStripMenuItem})
        Me.NewOverlayContextMenuStrip.Name = "NewOverlayContextMenuStrip"
        Me.NewOverlayContextMenuStrip.Size = New System.Drawing.Size(220, 120)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'MusicModuleToolStripMenuItem
        '
        Me.MusicModuleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MusicFrequenciesToolStripMenuItem, Me.MusicThumbnailsToolStripMenuItem})
        Me.MusicModuleToolStripMenuItem.Name = "MusicModuleToolStripMenuItem"
        Me.MusicModuleToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.MusicModuleToolStripMenuItem.Text = "Music Module"
        '
        'MusicFrequenciesToolStripMenuItem
        '
        Me.MusicFrequenciesToolStripMenuItem.Name = "MusicFrequenciesToolStripMenuItem"
        Me.MusicFrequenciesToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.MusicFrequenciesToolStripMenuItem.Tag = "MusicFrequencies"
        Me.MusicFrequenciesToolStripMenuItem.Text = "Music Frequencies"
        '
        'MusicThumbnailsToolStripMenuItem
        '
        Me.MusicThumbnailsToolStripMenuItem.Name = "MusicThumbnailsToolStripMenuItem"
        Me.MusicThumbnailsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.MusicThumbnailsToolStripMenuItem.Tag = "MusicThumbnails"
        Me.MusicThumbnailsToolStripMenuItem.Text = "Music Thumbnails"
        '
        'ProgressbarToolStripMenuItem
        '
        Me.ProgressbarToolStripMenuItem.Name = "ProgressbarToolStripMenuItem"
        Me.ProgressbarToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ProgressbarToolStripMenuItem.Tag = "Progressbar"
        Me.ProgressbarToolStripMenuItem.Text = "Progress bar (Experimental)"
        '
        'CustomToolStripMenuItem
        '
        Me.CustomToolStripMenuItem.Name = "CustomToolStripMenuItem"
        Me.CustomToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.CustomToolStripMenuItem.Tag = "Custom"
        Me.CustomToolStripMenuItem.Text = "Text"
        '
        'RectangleToolStripMenuItem
        '
        Me.RectangleToolStripMenuItem.Name = "RectangleToolStripMenuItem"
        Me.RectangleToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.RectangleToolStripMenuItem.Tag = "RectangleOverlay"
        Me.RectangleToolStripMenuItem.Text = "Rectangle"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ImageToolStripMenuItem.Tag = "ImageOverlay"
        Me.ImageToolStripMenuItem.Text = "Image"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(58, 36)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel2.TabIndex = 49
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "License"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(100, 36)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel3.TabIndex = 50
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Changelog"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(683, 395)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.GeneralTabPanel)
        Me.Controls.Add(Me.OverlaysTabPanel)
        Me.Controls.Add(Me.ModulesTabPanel)
        Me.Controls.Add(Me.OverlaysTabButton)
        Me.Controls.Add(Me.ModulesTabButton)
        Me.Controls.Add(Me.GeneralTabButton)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(312, 287)
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ModuleIconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ModulesTabPanel.ResumeLayout(False)
        Me.GeneralTabPanel.ResumeLayout(False)
        Me.GeneralTabPanel.PerformLayout()
        Me.OverlaysTabPanel.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.OverlaysPanelList.ResumeLayout(False)
        Me.OverlayContextMenuStrip.ResumeLayout(False)
        Me.NewOverlayContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents VersionLabel As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents FPSTimer As Timer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GeneralTabButton As Button
    Friend WithEvents ModuleDescriptionTextBox As TextBox
    Friend WithEvents ModuleNameTextBox As TextBox
    Friend WithEvents ToggleModuleButton As Button
    Friend WithEvents ModuleIconPictureBox As PictureBox
    Friend WithEvents ModulesTabPanel As Panel
    Friend WithEvents ModulesTabButton As Button
    Friend WithEvents ModulesCheckedListBox As CheckedListBox
    Friend WithEvents OverlaysTabButton As Button
    Friend WithEvents GeneralTabPanel As Panel
    Friend WithEvents OverlaysTabPanel As Panel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents OverlaysPanelList As Panel
    Friend WithEvents OverlaysCheckedListBox As CheckedListBox
    Friend WithEvents RefreshTimer As Timer
    Friend WithEvents AddOverlayButton As Button
    Friend WithEvents OverlayContextMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents NewOverlayContextMenuStrip As ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MusicModuleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MusicFrequenciesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents UpdateCanalComboBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ForceTopmostCheckBox As CheckBox
    Friend WithEvents CustomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgressbarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComeDownFromALevelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BringUpALevelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents DuplicateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents UseOldOverlaySystemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MusicThumbnailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RectangleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents BetaCodeTextBox As TextBox
    Friend WithEvents BetaCodeButton As Button
End Class
