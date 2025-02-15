<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MusicFrequenciesOverlay
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
        Me.MFPictureBox = New System.Windows.Forms.PictureBox()
        Me.MFTickTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.MFPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MFPictureBox
        '
        Me.MFPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MFPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.MFPictureBox.Name = "MFPictureBox"
        Me.MFPictureBox.Size = New System.Drawing.Size(271, 230)
        Me.MFPictureBox.TabIndex = 1
        Me.MFPictureBox.TabStop = False
        '
        'MFTickTimer
        '
        Me.MFTickTimer.Enabled = True
        Me.MFTickTimer.Interval = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Coucou"
        '
        'MusicFrequenciesOverlay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 230)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MFPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MusicFrequenciesOverlay"
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        CType(Me.MFPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MFPictureBox As PictureBox
    Friend WithEvents MFTickTimer As Timer
    Friend WithEvents Label1 As Label
End Class
