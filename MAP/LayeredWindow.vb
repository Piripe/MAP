Namespace AlphaForms
	Friend Class LayeredWindow
		Inherits Form

		' Token: 0x17000005 RID: 5
		' (get) Token: 0x0600003F RID: 63 RVA: 0x00003830 File Offset: 0x00001A30
		' (set) Token: 0x06000040 RID: 64 RVA: 0x0000384D File Offset: 0x00001A4D
		Public Property LayeredPos As Point
			Get
				Return Me.m_rect.Location
			End Get
			Set(value As Point)
				Me.m_rect.Location = value
			End Set
		End Property

		' Token: 0x17000006 RID: 6
		' (get) Token: 0x06000041 RID: 65 RVA: 0x00003860 File Offset: 0x00001A60
		Public ReadOnly Property LayeredSize As Size
			Get
				Return Me.m_rect.Size
			End Get
		End Property

		' Token: 0x06000042 RID: 66 RVA: 0x0000387D File Offset: 0x00001A7D
		Public Sub New(Name As String)
			MyBase.ShowInTaskbar = False
			MyBase.FormBorderStyle = FormBorderStyle.None
			MyBase.Name = Name
			MyBase.Text = Name
		End Sub

		' Token: 0x06000043 RID: 67 RVA: 0x00003897 File Offset: 0x00001A97
		Public Sub UpdateWindow(image As Bitmap, opacity As Byte)
			Me.UpdateWindow(image, opacity, -1, -1, Me.LayeredPos)
		End Sub

		' Token: 0x06000044 RID: 68 RVA: 0x000038AC File Offset: 0x00001AAC
		Public Sub UpdateWindow(image As Bitmap, opacity As Byte, width As Integer, height As Integer, pos As Point)
			Dim hdcWindow As IntPtr = Win32.GetWindowDC(MyBase.Handle)
			Dim hDC As IntPtr = Win32.CreateCompatibleDC(hdcWindow)
			Dim hBitmap As IntPtr = image.GetHbitmap(Color.FromArgb(0))
			Dim hOld As IntPtr = Win32.SelectObject(hDC, hBitmap)
			Dim size As Size = New Size(0, 0)
			Dim zero As Point = New Point(0, 0)
			Dim flag As Boolean = width = -1 OrElse height = -1
			If flag Then
				size.Width = image.Width
				size.Height = image.Height
			Else
				size.Width = Math.Min(image.Width, width)
				size.Height = Math.Min(image.Height, height)
			End If
			Me.m_rect.Size = size
			Me.m_rect.Location = pos
			Dim blend As Win32.BLENDFUNCTION = Nothing
			blend.BlendOp = 0
			blend.SourceConstantAlpha = opacity
			blend.AlphaFormat = 1
			blend.BlendFlags = 0
			Win32.UpdateLayeredWindow(MyBase.Handle, hdcWindow, pos, size, hDC, zero, 0, blend, Win32.BlendFlags.ULW_ALPHA)
			Win32.SelectObject(hDC, hOld)
			Win32.DeleteObject(hBitmap)
			Win32.DeleteDC(hDC)
			Win32.ReleaseDC(MyBase.Handle, hdcWindow)
		End Sub

		' Token: 0x17000007 RID: 7
		' (get) Token: 0x06000045 RID: 69 RVA: 0x000039D0 File Offset: 0x00001BD0
		Protected Overrides ReadOnly Property CreateParams As CreateParams
			Get
				Dim cp As CreateParams = MyBase.CreateParams
				cp.ExStyle = cp.ExStyle Or WindowStyles.WS_EX_LAYERED Or (Win32.WindowStyles.WS_EX_NOACTIVATE Or WindowStyles.WS_EX_TOOLWINDOW) Or WindowStyles.WS_EX_TRANSPARENT
				Return cp
			End Get
		End Property
		Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
			Get
				Return True
			End Get
		End Property

		' Token: 0x04000015 RID: 21
		Private m_rect As Rectangle

		Private Sub InitializeComponent()
			Me.SuspendLayout()
			'
			'LayeredWindow
			'
			Me.ClientSize = New System.Drawing.Size(284, 261)
			Me.Name = "LayeredWindow"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
			Me.ResumeLayout(False)

		End Sub

		Private Sub LayeredWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
			e.Cancel = True
		End Sub
	End Class
End Namespace