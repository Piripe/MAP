<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Editor))
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.PreviewProjectSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.ProjectTreeView = New System.Windows.Forms.TreeView()
        Me.PreviewPictureBox = New System.Windows.Forms.PictureBox()
        Me.TimeLineObjectsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.ObjectsPictureBox = New System.Windows.Forms.PictureBox()
        Me.TimeLinePictureBox = New System.Windows.Forms.PictureBox()
        Me.GlobalSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TopMenuStrip.SuspendLayout()
        CType(Me.EditionSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EditionSplitContainer.Panel1.SuspendLayout()
        Me.EditionSplitContainer.Panel2.SuspendLayout()
        Me.EditionSplitContainer.SuspendLayout()
        CType(Me.PreviewProjectSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PreviewProjectSplitContainer.Panel1.SuspendLayout()
        Me.PreviewProjectSplitContainer.Panel2.SuspendLayout()
        Me.PreviewProjectSplitContainer.SuspendLayout()
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeLineObjectsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TimeLineObjectsSplitContainer.Panel1.SuspendLayout()
        Me.TimeLineObjectsSplitContainer.Panel2.SuspendLayout()
        Me.TimeLineObjectsSplitContainer.SuspendLayout()
        CType(Me.ObjectsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeLinePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GlobalSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GlobalSplitContainer.Panel1.SuspendLayout()
        Me.GlobalSplitContainer.Panel2.SuspendLayout()
        Me.GlobalSplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ProjectToolStripMenuItem, Me.ObjectToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(800, 24)
        Me.TopMenuStrip.TabIndex = 0
        Me.TopMenuStrip.Text = "TopMenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectSettingsToolStripMenuItem})
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ProjectToolStripMenuItem.Text = "Project"
        '
        'ProjectSettingsToolStripMenuItem
        '
        Me.ProjectSettingsToolStripMenuItem.Name = "ProjectSettingsToolStripMenuItem"
        Me.ProjectSettingsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ProjectSettingsToolStripMenuItem.Text = "Project Settings"
        '
        'ObjectToolStripMenuItem
        '
        Me.ObjectToolStripMenuItem.Name = "ObjectToolStripMenuItem"
        Me.ObjectToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ObjectToolStripMenuItem.Text = "Object"
        '
        'EditionSplitContainer
        '
        Me.EditionSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditionSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditionSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.EditionSplitContainer.Name = "EditionSplitContainer"
        Me.EditionSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'EditionSplitContainer.Panel1
        '
        Me.EditionSplitContainer.Panel1.Controls.Add(Me.PreviewProjectSplitContainer)
        '
        'EditionSplitContainer.Panel2
        '
        Me.EditionSplitContainer.Panel2.Controls.Add(Me.TimeLineObjectsSplitContainer)
        Me.EditionSplitContainer.Size = New System.Drawing.Size(606, 426)
        Me.EditionSplitContainer.SplitterDistance = 266
        Me.EditionSplitContainer.TabIndex = 1
        '
        'PreviewProjectSplitContainer
        '
        Me.PreviewProjectSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewProjectSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewProjectSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.PreviewProjectSplitContainer.Name = "PreviewProjectSplitContainer"
        '
        'PreviewProjectSplitContainer.Panel1
        '
        Me.PreviewProjectSplitContainer.Panel1.Controls.Add(Me.ProjectTreeView)
        '
        'PreviewProjectSplitContainer.Panel2
        '
        Me.PreviewProjectSplitContainer.Panel2.Controls.Add(Me.PreviewPictureBox)
        Me.PreviewProjectSplitContainer.Size = New System.Drawing.Size(606, 266)
        Me.PreviewProjectSplitContainer.SplitterDistance = 202
        Me.PreviewProjectSplitContainer.TabIndex = 0
        '
        'ProjectTreeView
        '
        Me.ProjectTreeView.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ProjectTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ProjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectTreeView.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectTreeView.ForeColor = System.Drawing.Color.White
        Me.ProjectTreeView.Location = New System.Drawing.Point(0, 0)
        Me.ProjectTreeView.Name = "ProjectTreeView"
        Me.ProjectTreeView.Size = New System.Drawing.Size(200, 264)
        Me.ProjectTreeView.TabIndex = 0
        '
        'PreviewPictureBox
        '
        Me.PreviewPictureBox.BackColor = System.Drawing.Color.Black
        Me.PreviewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PreviewPictureBox.Name = "PreviewPictureBox"
        Me.PreviewPictureBox.Size = New System.Drawing.Size(398, 264)
        Me.PreviewPictureBox.TabIndex = 0
        Me.PreviewPictureBox.TabStop = False
        '
        'TimeLineObjectsSplitContainer
        '
        Me.TimeLineObjectsSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimeLineObjectsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeLineObjectsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.TimeLineObjectsSplitContainer.Name = "TimeLineObjectsSplitContainer"
        '
        'TimeLineObjectsSplitContainer.Panel1
        '
        Me.TimeLineObjectsSplitContainer.Panel1.Controls.Add(Me.ObjectsPictureBox)
        '
        'TimeLineObjectsSplitContainer.Panel2
        '
        Me.TimeLineObjectsSplitContainer.Panel2.Controls.Add(Me.TimeLinePictureBox)
        Me.TimeLineObjectsSplitContainer.Size = New System.Drawing.Size(606, 156)
        Me.TimeLineObjectsSplitContainer.SplitterDistance = 202
        Me.TimeLineObjectsSplitContainer.TabIndex = 0
        '
        'ObjectsPictureBox
        '
        Me.ObjectsPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectsPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.ObjectsPictureBox.Name = "ObjectsPictureBox"
        Me.ObjectsPictureBox.Size = New System.Drawing.Size(200, 154)
        Me.ObjectsPictureBox.TabIndex = 0
        Me.ObjectsPictureBox.TabStop = False
        '
        'TimeLinePictureBox
        '
        Me.TimeLinePictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeLinePictureBox.Location = New System.Drawing.Point(0, 0)
        Me.TimeLinePictureBox.Name = "TimeLinePictureBox"
        Me.TimeLinePictureBox.Size = New System.Drawing.Size(398, 154)
        Me.TimeLinePictureBox.TabIndex = 0
        Me.TimeLinePictureBox.TabStop = False
        '
        'GlobalSplitContainer
        '
        Me.GlobalSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GlobalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GlobalSplitContainer.Location = New System.Drawing.Point(0, 24)
        Me.GlobalSplitContainer.Name = "GlobalSplitContainer"
        '
        'GlobalSplitContainer.Panel1
        '
        Me.GlobalSplitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GlobalSplitContainer.Panel1.Controls.Add(Me.EditionSplitContainer)
        '
        'GlobalSplitContainer.Panel2
        '
        Me.GlobalSplitContainer.Panel2.Controls.Add(Me.Label1)
        Me.GlobalSplitContainer.Size = New System.Drawing.Size(800, 426)
        Me.GlobalSplitContainer.SplitterDistance = 606
        Me.GlobalSplitContainer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Useless place"
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 16
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GlobalSplitContainer)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "Editor"
        Me.Text = "Editor"
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.EditionSplitContainer.Panel1.ResumeLayout(False)
        Me.EditionSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.EditionSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EditionSplitContainer.ResumeLayout(False)
        Me.PreviewProjectSplitContainer.Panel1.ResumeLayout(False)
        Me.PreviewProjectSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.PreviewProjectSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PreviewProjectSplitContainer.ResumeLayout(False)
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimeLineObjectsSplitContainer.Panel1.ResumeLayout(False)
        Me.TimeLineObjectsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.TimeLineObjectsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimeLineObjectsSplitContainer.ResumeLayout(False)
        CType(Me.ObjectsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeLinePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GlobalSplitContainer.Panel1.ResumeLayout(False)
        Me.GlobalSplitContainer.Panel2.ResumeLayout(False)
        Me.GlobalSplitContainer.Panel2.PerformLayout()
        CType(Me.GlobalSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GlobalSplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditionSplitContainer As SplitContainer
    Friend WithEvents PreviewProjectSplitContainer As SplitContainer
    Friend WithEvents ProjectTreeView As TreeView
    Friend WithEvents PreviewPictureBox As PictureBox
    Friend WithEvents TimeLineObjectsSplitContainer As SplitContainer
    Friend WithEvents ObjectsPictureBox As PictureBox
    Friend WithEvents TimeLinePictureBox As PictureBox
    Friend WithEvents GlobalSplitContainer As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents ProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProjectSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshTimer As Timer
End Class
