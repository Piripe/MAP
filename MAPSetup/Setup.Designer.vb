<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setup))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.InstallButton = New System.Windows.Forms.Button()
        Me.InstallPanel = New System.Windows.Forms.Panel()
        Me.AddDesktopCheckBox = New System.Windows.Forms.CheckBox()
        Me.SelectPathButton = New System.Windows.Forms.Button()
        Me.PathTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.UninstallPanel = New System.Windows.Forms.Panel()
        Me.UninstallButton = New System.Windows.Forms.Button()
        Me.LoadingPanel = New System.Windows.Forms.Panel()
        Me.RunMAPCheckBox = New System.Windows.Forms.CheckBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.LoadingLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.InstallPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UninstallPanel.SuspendLayout()
        Me.LoadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(102, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(304, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MAP Setup"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(107, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(299, 51)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "The software YOU need to create and use overlays."
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(12, 159)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(249, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "I accept the terms of the License Agreement"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "This work is licensed under a"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 131)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LinkLabel1.Size = New System.Drawing.Size(266, 26)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Creative Commons" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attribution-NoDerivatives 4.0 International License"
        Me.LinkLabel1.UseWaitCursor = True
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'InstallButton
        '
        Me.InstallButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstallButton.Enabled = False
        Me.InstallButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InstallButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallButton.ForeColor = System.Drawing.Color.White
        Me.InstallButton.Location = New System.Drawing.Point(318, 183)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(88, 23)
        Me.InstallButton.TabIndex = 7
        Me.InstallButton.Text = "Install"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'InstallPanel
        '
        Me.InstallPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstallPanel.Controls.Add(Me.AddDesktopCheckBox)
        Me.InstallPanel.Controls.Add(Me.SelectPathButton)
        Me.InstallPanel.Controls.Add(Me.PathTextBox)
        Me.InstallPanel.Controls.Add(Me.InstallButton)
        Me.InstallPanel.Controls.Add(Me.Label3)
        Me.InstallPanel.Controls.Add(Me.PictureBox2)
        Me.InstallPanel.Controls.Add(Me.CheckBox1)
        Me.InstallPanel.Controls.Add(Me.LinkLabel1)
        Me.InstallPanel.Location = New System.Drawing.Point(0, 111)
        Me.InstallPanel.Name = "InstallPanel"
        Me.InstallPanel.Size = New System.Drawing.Size(418, 218)
        Me.InstallPanel.TabIndex = 8
        Me.InstallPanel.Visible = False
        '
        'AddDesktopCheckBox
        '
        Me.AddDesktopCheckBox.AutoSize = True
        Me.AddDesktopCheckBox.Checked = True
        Me.AddDesktopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AddDesktopCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddDesktopCheckBox.ForeColor = System.Drawing.Color.White
        Me.AddDesktopCheckBox.Location = New System.Drawing.Point(12, 36)
        Me.AddDesktopCheckBox.Name = "AddDesktopCheckBox"
        Me.AddDesktopCheckBox.Size = New System.Drawing.Size(110, 17)
        Me.AddDesktopCheckBox.TabIndex = 10
        Me.AddDesktopCheckBox.Text = "Add on Desktop"
        Me.AddDesktopCheckBox.UseVisualStyleBackColor = True
        '
        'SelectPathButton
        '
        Me.SelectPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectPathButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.SelectPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectPathButton.ForeColor = System.Drawing.Color.White
        Me.SelectPathButton.Location = New System.Drawing.Point(379, 8)
        Me.SelectPathButton.Name = "SelectPathButton"
        Me.SelectPathButton.Size = New System.Drawing.Size(27, 22)
        Me.SelectPathButton.TabIndex = 9
        Me.SelectPathButton.Text = "..."
        Me.SelectPathButton.UseVisualStyleBackColor = True
        '
        'PathTextBox
        '
        Me.PathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PathTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.PathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PathTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PathTextBox.ForeColor = System.Drawing.Color.White
        Me.PathTextBox.Location = New System.Drawing.Point(12, 8)
        Me.PathTextBox.Name = "PathTextBox"
        Me.PathTextBox.Size = New System.Drawing.Size(361, 22)
        Me.PathTextBox.TabIndex = 8
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.MAPSetup.My.Resources.Resources.License
        Me.PictureBox2.Location = New System.Drawing.Point(12, 175)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(88, 31)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'UninstallPanel
        '
        Me.UninstallPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UninstallPanel.Controls.Add(Me.UninstallButton)
        Me.UninstallPanel.Location = New System.Drawing.Point(0, 111)
        Me.UninstallPanel.Name = "UninstallPanel"
        Me.UninstallPanel.Size = New System.Drawing.Size(418, 218)
        Me.UninstallPanel.TabIndex = 10
        Me.UninstallPanel.Visible = False
        '
        'UninstallButton
        '
        Me.UninstallButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.UninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UninstallButton.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UninstallButton.ForeColor = System.Drawing.Color.White
        Me.UninstallButton.Location = New System.Drawing.Point(137, 69)
        Me.UninstallButton.Name = "UninstallButton"
        Me.UninstallButton.Size = New System.Drawing.Size(144, 49)
        Me.UninstallButton.TabIndex = 7
        Me.UninstallButton.Text = "Uninstall"
        Me.UninstallButton.UseVisualStyleBackColor = True
        '
        'LoadingPanel
        '
        Me.LoadingPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadingPanel.Controls.Add(Me.RunMAPCheckBox)
        Me.LoadingPanel.Controls.Add(Me.CloseButton)
        Me.LoadingPanel.Controls.Add(Me.LoadingLabel)
        Me.LoadingPanel.Location = New System.Drawing.Point(0, 111)
        Me.LoadingPanel.Name = "LoadingPanel"
        Me.LoadingPanel.Size = New System.Drawing.Size(418, 218)
        Me.LoadingPanel.TabIndex = 11
        Me.LoadingPanel.Visible = False
        '
        'RunMAPCheckBox
        '
        Me.RunMAPCheckBox.AutoSize = True
        Me.RunMAPCheckBox.Checked = True
        Me.RunMAPCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RunMAPCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RunMAPCheckBox.ForeColor = System.Drawing.Color.White
        Me.RunMAPCheckBox.Location = New System.Drawing.Point(12, 187)
        Me.RunMAPCheckBox.Name = "RunMAPCheckBox"
        Me.RunMAPCheckBox.Size = New System.Drawing.Size(73, 17)
        Me.RunMAPCheckBox.TabIndex = 11
        Me.RunMAPCheckBox.Text = "Run MAP"
        Me.RunMAPCheckBox.UseVisualStyleBackColor = True
        Me.RunMAPCheckBox.Visible = False
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.Color.White
        Me.CloseButton.Location = New System.Drawing.Point(318, 183)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(88, 23)
        Me.CloseButton.TabIndex = 10
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        Me.CloseButton.Visible = False
        '
        'LoadingLabel
        '
        Me.LoadingLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LoadingLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadingLabel.ForeColor = System.Drawing.Color.White
        Me.LoadingLabel.Location = New System.Drawing.Point(0, 0)
        Me.LoadingLabel.Name = "LoadingLabel"
        Me.LoadingLabel.Size = New System.Drawing.Size(418, 218)
        Me.LoadingLabel.TabIndex = 0
        Me.LoadingLabel.Text = "Loading..."
        Me.LoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MAPSetup.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(418, 329)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LoadingPanel)
        Me.Controls.Add(Me.UninstallPanel)
        Me.Controls.Add(Me.InstallPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(300, 275)
        Me.Name = "Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MAP Setup"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.InstallPanel.ResumeLayout(False)
        Me.InstallPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UninstallPanel.ResumeLayout(False)
        Me.LoadingPanel.ResumeLayout(False)
        Me.LoadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents InstallButton As Button
    Friend WithEvents InstallPanel As Panel
    Friend WithEvents SelectPathButton As Button
    Friend WithEvents PathTextBox As TextBox
    Friend WithEvents UninstallPanel As Panel
    Friend WithEvents UninstallButton As Button
    Friend WithEvents LoadingPanel As Panel
    Friend WithEvents LoadingLabel As Label
    Friend WithEvents CloseButton As Button
    Friend WithEvents RunMAPCheckBox As CheckBox
    Friend WithEvents AddDesktopCheckBox As CheckBox
End Class
