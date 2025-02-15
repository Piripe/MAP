Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Text

Namespace AlphaForms
	Public Class AlphaForm
		Inherits Form

		' Token: 0x06000027 RID: 39 RVA: 0x00002050 File Offset: 0x00000250
		Public Sub New()
			Dim flag As Boolean = Not MyBase.DesignMode
			If flag Then
				Me.m_layeredWnd = New LayeredWindow()
			End If
			Me.m_sizeMode = AlphaForm.SizeModes.None
			Me.m_background = Nothing
			Me.m_backgroundEx = Nothing
			Me.m_backgroundFull = Nothing
			Me.m_renderCtrlBG = False
			Me.m_enhanced = False
			Me.m_isDown.Left = False
			Me.m_isDown.Right = False
			Me.m_isDown.Middle = False
			Me.m_isDown.XBtn = False
			Me.m_moving = False
			Me.m_hiddenControls = New List(Of Control)()
			Me.m_controlDict = New Dictionary(Of Control, Boolean)()
			Me.m_initialised = False
			MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
		End Sub

		Protected Overrides ReadOnly Property CreateParams As CreateParams
			Get
				Dim cp = MyBase.CreateParams
				cp.ExStyle = cp.ExStyle Or (Win32.WindowStyles.WS_EX_NOACTIVATE Or WindowStyles.WS_EX_TOOLWINDOW) Or WindowStyles.WS_EX_TRANSPARENT
				Return cp
			End Get
		End Property
		Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
			Get
				Return True
			End Get
		End Property

		' Token: 0x17000001 RID: 1
		' (get) Token: 0x06000028 RID: 40 RVA: 0x00002128 File Offset: 0x00000328
		' (set) Token: 0x06000029 RID: 41 RVA: 0x00002140 File Offset: 0x00000340
		<Category("AlphaForm")>
		Public Property BlendedBackground As Bitmap
			Get
				Return Me.m_background
			End Get
			Set(value As Bitmap)
				Dim flag As Boolean = Me.m_background IsNot value
				If flag Then
					Me.m_background = value
					Me.UpdateLayeredBackground()
				End If
			End Set
		End Property

		' Token: 0x17000002 RID: 2
		' (get) Token: 0x0600002A RID: 42 RVA: 0x00002170 File Offset: 0x00000370
		' (set) Token: 0x0600002B RID: 43 RVA: 0x00002188 File Offset: 0x00000388
		<Category("AlphaForm")>
		Public Property DrawControlBackgrounds As Boolean
			Get
				Return Me.m_renderCtrlBG
			End Get
			Set(value As Boolean)
				Dim flag As Boolean = Me.m_renderCtrlBG <> value
				If flag Then
					Me.m_renderCtrlBG = value
					Me.UpdateLayeredBackground()
				End If
			End Set
		End Property

		' Token: 0x17000003 RID: 3
		' (get) Token: 0x0600002C RID: 44 RVA: 0x000021B8 File Offset: 0x000003B8
		' (set) Token: 0x0600002D RID: 45 RVA: 0x000021D0 File Offset: 0x000003D0
		<Category("AlphaForm")>
		Public Property EnhancedRendering As Boolean
			Get
				Return Me.m_enhanced
			End Get
			Set(value As Boolean)
				Me.m_enhanced = value
			End Set
		End Property

		' Token: 0x17000004 RID: 4
		' (get) Token: 0x0600002E RID: 46 RVA: 0x000021DC File Offset: 0x000003DC
		' (set) Token: 0x0600002F RID: 47 RVA: 0x000021F4 File Offset: 0x000003F4
		<Category("AlphaForm")>
		Public Property SizeMode As AlphaForm.SizeModes
			Get
				Return Me.m_sizeMode
			End Get
			Set(value As AlphaForm.SizeModes)
				Me.m_sizeMode = value
				Me.UpdateLayeredBackground()
			End Set
		End Property

		' Token: 0x06000030 RID: 48 RVA: 0x00002208 File Offset: 0x00000408
		Public Sub SetOpacity(Opacity As Double)
			MyBase.Opacity = Opacity
			Dim flag As Boolean = Me.m_background IsNot Nothing
			If flag Then
				Dim width As Integer = MyBase.ClientSize.Width
				Dim height As Integer = MyBase.ClientSize.Height
				Dim flag2 As Boolean = Me.m_sizeMode = AlphaForm.SizeModes.None
				If flag2 Then
					width = Me.m_background.Width
					height = Me.m_background.Height
				End If
				Dim _opacity As Byte = CByte((MyBase.Opacity * 255.0))
				Dim useBackgroundEx As Boolean = Me.m_useBackgroundEx
				If useBackgroundEx Then
					Me.m_layeredWnd.UpdateWindow(Me.m_backgroundEx, _opacity, width, height, Me.m_layeredWnd.LayeredPos)
				Else
					Me.m_layeredWnd.UpdateWindow(Me.m_background, _opacity, width, height, Me.m_layeredWnd.LayeredPos)
				End If
			End If
		End Sub

		' Token: 0x06000031 RID: 49 RVA: 0x000022E0 File Offset: 0x000004E0
		Public Sub UpdateLayeredBackground()
			Me.updateLayeredBackground(MyBase.ClientSize.Width, MyBase.ClientSize.Height)
		End Sub

		' Token: 0x06000032 RID: 50 RVA: 0x00002314 File Offset: 0x00000514
		Public Sub DrawControlBackground(ctrl As Control, drawBack As Boolean)
			Dim flag As Boolean = Me.m_controlDict.ContainsKey(ctrl)
			If flag Then
				Me.m_controlDict(ctrl) = drawBack
			End If
		End Sub

		' Token: 0x06000033 RID: 51 RVA: 0x00002340 File Offset: 0x00000540
		Protected Overrides Sub OnLoad(e As EventArgs)
			MyBase.OnLoad(e)
			Me.BackColor = Color.Fuchsia
			MyBase.TransparencyKey = Color.Fuchsia
			MyBase.AllowTransparency = True
			Dim screen As Point = New Point(0, 0)
			screen = MyBase.PointToScreen(screen)
			Me.m_offX = screen.X - MyBase.Location.X
			Me.m_offY = screen.Y - MyBase.Location.Y
			Dim flag As Boolean = Not MyBase.DesignMode
			If flag Then
				Dim formLoc As Point = MyBase.Location
				formLoc.X += Me.m_offX
				formLoc.Y += Me.m_offY
				Me.m_layeredWnd.Text = "AlphaForm"
				Me.m_initialised = True
				Me.updateLayeredBackground(MyBase.ClientSize.Width, MyBase.ClientSize.Height, formLoc, True)
				Me.m_layeredWnd.Show()
				Me.m_layeredWnd.Enabled = False
				Me.m_customLayeredWindowProc = AddressOf Me.LayeredWindowWndProc
				Me.m_layeredWindowProc = Win32.SetWindowLong(Me.m_layeredWnd.Handle, 4294967292UI, Me.m_customLayeredWindowProc)
			End If
		End Sub

		' Token: 0x06000034 RID: 52 RVA: 0x0000248C File Offset: 0x0000068C
		Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
			MyBase.OnPaintBackground(e)
			Dim flag As Boolean = Me.m_background IsNot Nothing
			If flag Then
				Dim designMode As Boolean = MyBase.DesignMode
				If designMode Then
					e.Graphics.DrawImage(Me.m_background, 0, 0, Me.m_background.Width, Me.m_background.Height)
				Else
					Dim flag2 As Boolean = Not Me.m_moving AndAlso Me.m_renderCtrlBG
					If flag2 Then
						For Each kvp As KeyValuePair(Of Control, Boolean) In Me.m_controlDict
							Dim ctrl As Control = kvp.Key
							Dim drawBack As Boolean = kvp.Value
							Dim flag3 As Boolean = drawBack AndAlso ctrl.BackColor = Color.Transparent
							If flag3 Then
								Dim rect As Rectangle = ctrl.ClientRectangle
								rect.X = ctrl.Left
								rect.Y = ctrl.Top
								Dim useBackgroundEx As Boolean = Me.m_useBackgroundEx
								If useBackgroundEx Then
									e.Graphics.DrawImage(Me.m_backgroundFull, rect, rect, GraphicsUnit.Pixel)
								Else
									e.Graphics.DrawImage(Me.m_background, rect, rect, GraphicsUnit.Pixel)
								End If
							End If
						Next
					End If
				End If
			End If
		End Sub

		' Token: 0x06000035 RID: 53 RVA: 0x000025E8 File Offset: 0x000007E8
		Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
			MyBase.OnControlAdded(e)
			Dim flag As Boolean = Not Me.m_controlDict.ContainsKey(e.Control)
			If flag Then
				Me.m_controlDict.Add(e.Control, True)
			End If
		End Sub

		' Token: 0x06000036 RID: 54 RVA: 0x0000262C File Offset: 0x0000082C
		Protected Overrides Sub OnControlRemoved(e As ControlEventArgs)
			MyBase.OnControlRemoved(e)
			Dim flag As Boolean = Me.m_controlDict.ContainsKey(e.Control)
			If flag Then
				Me.m_controlDict.Remove(e.Control)
			End If
		End Sub

		' Token: 0x06000037 RID: 55 RVA: 0x00002669 File Offset: 0x00000869
		Private Sub updateLayeredBackground(width As Integer, height As Integer, pos As Point)
			Me.updateLayeredBackground(width, height, pos, True)
		End Sub

		' Token: 0x06000038 RID: 56 RVA: 0x00002677 File Offset: 0x00000877
		Private Sub updateLayeredBackground(width As Integer, height As Integer)
			Me.updateLayeredBackground(width, height, Me.m_layeredWnd.LayeredPos, True)
		End Sub

		' Token: 0x06000039 RID: 57 RVA: 0x00002690 File Offset: 0x00000890
		Private Sub updateLayeredBackground(width As Integer, height As Integer, pos As Point, Render As Boolean)
			Me.m_useBackgroundEx = False
			Dim flag As Boolean = MyBase.DesignMode OrElse Me.m_background Is Nothing OrElse Not Me.m_initialised
			If Not flag Then
				Select Case Me.m_sizeMode
					Case AlphaForm.SizeModes.None
						width = Me.m_background.Width
						height = Me.m_background.Height
					Case AlphaForm.SizeModes.Stretch
						Me.m_useBackgroundEx = True
				End Select
				Dim flag2 As Boolean = (Me.m_renderCtrlBG OrElse Me.m_useBackgroundEx) AndAlso Render
				If flag2 Then
					Dim flag3 As Boolean = Me.m_backgroundEx IsNot Nothing
					If flag3 Then
						Me.m_backgroundEx.Dispose()
						Me.m_backgroundEx = Nothing
					End If
					Dim flag4 As Boolean = Me.m_backgroundFull IsNot Nothing
					If flag4 Then
						Me.m_backgroundFull.Dispose()
						Me.m_backgroundFull = Nothing
					End If
					Dim flag5 As Boolean = Me.m_sizeMode = AlphaForm.SizeModes.Clip
					If flag5 Then
						Me.m_backgroundEx = New Bitmap(Me.m_background)
					Else
						Me.m_backgroundEx = New Bitmap(Me.m_background, width, height)
					End If
					Me.m_backgroundFull = New Bitmap(Me.m_backgroundEx)
				End If
				Dim renderCtrlBG As Boolean = Me.m_renderCtrlBG
				If renderCtrlBG Then
					If Render Then
						Dim g As Graphics = Graphics.FromImage(Me.m_backgroundEx)
						For Each kvp As KeyValuePair(Of Control, Boolean) In Me.m_controlDict
							Dim ctrl As Control = kvp.Key
							Dim drawBack As Boolean = kvp.Value
							Dim flag6 As Boolean = drawBack AndAlso ctrl.BackColor = Color.Transparent
							If flag6 Then
								Dim rect As Rectangle = ctrl.ClientRectangle
								rect.X = ctrl.Left
								rect.Y = ctrl.Top
								g.FillRectangle(Brushes.Fuchsia, rect)
							End If
						Next
						g.Dispose()
						Me.m_backgroundEx.MakeTransparent(Color.Fuchsia)
					End If
					Me.m_useBackgroundEx = True
				End If
				Dim _opacity As Byte = CByte((MyBase.Opacity * 255.0))
				Dim useBackgroundEx As Boolean = Me.m_useBackgroundEx
				If useBackgroundEx Then
					Me.m_layeredWnd.UpdateWindow(Me.m_backgroundEx, _opacity, width, height, pos)
				Else
					Me.m_layeredWnd.UpdateWindow(Me.m_background, _opacity, width, height, pos)
				End If
			End If
		End Sub

		' Token: 0x0600003A RID: 58 RVA: 0x00002904 File Offset: 0x00000B04
		Private Sub updateLayeredSize(width As Integer, height As Integer)
			Me.updateLayeredSize(width, height, False)
		End Sub

		' Token: 0x0600003B RID: 59 RVA: 0x00002914 File Offset: 0x00000B14
		Private Sub updateLayeredSize(width As Integer, height As Integer, forceUpdate As Boolean)
			Dim flag As Boolean = Not Me.m_initialised
			If Not flag Then
				Dim flag2 As Boolean = Not forceUpdate AndAlso width = Me.m_layeredWnd.LayeredSize.Width AndAlso height = Me.m_layeredWnd.LayeredSize.Height
				If Not flag2 Then
					Select Case Me.m_sizeMode
						Case AlphaForm.SizeModes.Stretch
							Me.updateLayeredBackground(width, height)
							MyBase.Invalidate(False)
						Case AlphaForm.SizeModes.Clip
							Dim _opacity As Byte = CByte((MyBase.Opacity * 255.0))
							Dim useBackgroundEx As Boolean = Me.m_useBackgroundEx
							If useBackgroundEx Then
								Me.m_layeredWnd.UpdateWindow(Me.m_backgroundEx, _opacity, width, height, Me.m_layeredWnd.LayeredPos)
							Else
								Me.m_layeredWnd.UpdateWindow(Me.m_background, _opacity, width, height, Me.m_layeredWnd.LayeredPos)
							End If
					End Select
				End If
			End If
		End Sub

		' Token: 0x0600003C RID: 60 RVA: 0x00002A1C File Offset: 0x00000C1C
		Private Function dblClick(pos As Point) As Boolean
			Dim elapsed As TimeSpan = DateTime.Now - Me.m_clickTime
			Dim dist As Size = Nothing
			dist.Width = Math.Abs(Me.m_lockedPoint.X - pos.X)
			dist.Height = Math.Abs(Me.m_lockedPoint.Y - pos.Y)
			Return elapsed.Milliseconds <= SystemInformation.DoubleClickTime AndAlso dist.Width <= SystemInformation.DoubleClickSize.Width AndAlso dist.Height <= SystemInformation.DoubleClickSize.Height
		End Function

		' Token: 0x0600003D RID: 61 RVA: 0x00002AD4 File Offset: 0x00000CD4
		Protected Overrides Sub WndProc(ByRef m As Windows.Forms.Message)
			Dim designMode As Boolean = MyBase.DesignMode
			If designMode Then
				MyBase.WndProc(m)
			Else
				Dim msgId As Win32.Message = CType(m.Msg, Win32.Message)
				Dim UseBase As Boolean = True
				Dim message As Win32.Message = msgId
				Dim message2 As Win32.Message = message
				If message2 <= Win32.Message.WM_WINDOWPOSCHANGING Then
					If message2 <> Win32.Message.WM_SIZE Then
						If message2 <> Win32.Message.WM_ACTIVATE Then
							If message2 = Win32.Message.WM_WINDOWPOSCHANGING Then
								Dim posInfo As Win32.WINDOWPOS = CType(Marshal.PtrToStructure(m.LParam, GetType(Win32.WINDOWPOS)), Win32.WINDOWPOS)
								Dim move_size As Win32.WindowPosFlags = Win32.WindowPosFlags.SWP_NOSIZE Or Win32.WindowPosFlags.SWP_NOMOVE
								Dim flag As Boolean = (posInfo.flags And move_size) <> move_size
								If flag Then
									Dim flag2 As Boolean = posInfo.hwndInsertAfter <> MyBase.Handle
									If flag2 Then
										Dim hwdp As IntPtr = Win32.BeginDeferWindowPos(2)
										Dim flag3 As Boolean = hwdp <> IntPtr.Zero
										If flag3 Then
											hwdp = Win32.DeferWindowPos(hwdp, Me.m_layeredWnd.Handle, MyBase.Handle, posInfo.x + Me.m_offX, posInfo.y + Me.m_offY, 0, 0, CUInt((posInfo.flags Or Win32.WindowPosFlags.SWP_NOSIZE Or Win32.WindowPosFlags.SWP_NOZORDER)))
										End If
										Dim flag4 As Boolean = hwdp <> IntPtr.Zero
										If flag4 Then
											hwdp = Win32.DeferWindowPos(hwdp, MyBase.Handle, MyBase.Handle, posInfo.x, posInfo.y, posInfo.cx, posInfo.cy, CUInt((posInfo.flags Or Win32.WindowPosFlags.SWP_NOZORDER)))
										End If
										Dim flag5 As Boolean = hwdp <> IntPtr.Zero
										If flag5 Then
											Win32.EndDeferWindowPos(hwdp)
										End If
										Me.m_layeredWnd.LayeredPos = New Point(posInfo.x + Me.m_offX, posInfo.y + Me.m_offY)
										posInfo.flags = posInfo.flags Or Win32.WindowPosFlags.SWP_NOMOVE
										Marshal.StructureToPtr(posInfo, m.LParam, True)
									End If
									Dim flag6 As Boolean = (posInfo.flags And Win32.WindowPosFlags.SWP_NOSIZE) = Win32.WindowPosFlags.NONE
									If flag6 Then
										Dim diffX As Integer = posInfo.cx - MyBase.Size.Width
										Dim diffY As Integer = posInfo.cy - MyBase.Size.Height
										Dim flag7 As Boolean = diffX <> 0 OrElse diffY <> 0
										If flag7 Then
											Me.updateLayeredSize(MyBase.ClientSize.Width + diffX, MyBase.ClientSize.Height + diffY)
										End If
									End If
									UseBase = False
								End If
							End If
						Else
							Dim flag8 As Boolean = m.WParam <> IntPtr.Zero
							If flag8 Then
								Dim prevWnd As IntPtr = Win32.GetWindow(Me.m_layeredWnd.Handle, Win32.GetWindow_Cmd.GW_HWNDPREV)
								While prevWnd <> IntPtr.Zero
									Dim flag9 As Boolean = Win32.IsWindowVisible(prevWnd)
									If flag9 Then
										Exit While
									End If
									prevWnd = Win32.GetWindow(prevWnd, Win32.GetWindow_Cmd.GW_HWNDPREV)
								End While
								Dim flag10 As Boolean = prevWnd <> MyBase.Handle
								If flag10 Then
									Win32.SetWindowPos(Me.m_layeredWnd.Handle, MyBase.Handle, 0, 0, 0, 0, 1043UI)
								End If
							End If
						End If
					Else
						Dim width As Integer = m.LParam.ToInt32() And 65535
						Dim height As Integer = m.LParam.ToInt32() >> 16
						Me.updateLayeredSize(width, height)
					End If
				End If
				Dim flag13 As Boolean = UseBase
				If flag13 Then
					MyBase.WndProc(m)
				End If
			End If
		End Sub

		' Token: 0x0600003E RID: 62 RVA: 0x000031C0 File Offset: 0x000013C0
		Private Function LayeredWindowWndProc(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
			Dim mousePos As Point = MyBase.PointToClient(Cursor.Position)
			Dim result As Integer
			If Msg <> 32 Then
				If Msg = 513 Then
					Debugger.Break()
				End If
				result = Win32.CallWindowProc(Me.m_layeredWindowProc, hWnd, Msg, wParam, lParam)
			Else

				result = 0
			End If
			Return result
		End Function

		' Token: 0x04000001 RID: 1
		Private m_background As Bitmap

		' Token: 0x04000002 RID: 2
		Private m_backgroundEx As Bitmap

		' Token: 0x04000003 RID: 3
		Private m_backgroundFull As Bitmap

		' Token: 0x04000004 RID: 4
		Private m_useBackgroundEx As Boolean

		' Token: 0x04000005 RID: 5
		Private m_layeredWnd As LayeredWindow

		' Token: 0x04000006 RID: 6
		Private m_offX As Integer

		' Token: 0x04000007 RID: 7
		Private m_offY As Integer

		' Token: 0x04000008 RID: 8
		Private m_renderCtrlBG As Boolean

		' Token: 0x04000009 RID: 9
		Private m_enhanced As Boolean

		' Token: 0x0400000A RID: 10
		Private m_sizeMode As AlphaForm.SizeModes

		' Token: 0x0400000B RID: 11
		Private m_hiddenControls As List(Of Control)

		' Token: 0x0400000C RID: 12
		Private m_controlDict As Dictionary(Of Control, Boolean)

		' Token: 0x0400000D RID: 13
		Private m_moving As Boolean

		' Token: 0x0400000E RID: 14
		Private m_initialised As Boolean

		' Token: 0x0400000F RID: 15
		Private m_customLayeredWindowProc As Win32.Win32WndProc

		' Token: 0x04000010 RID: 16
		Private m_layeredWindowProc As IntPtr

		' Token: 0x04000011 RID: 17
		Private m_lockedPoint As Point = Nothing

		' Token: 0x04000012 RID: 18
		Private m_clickTime As DateTime = DateTime.Now

		' Token: 0x04000013 RID: 19
		Private m_lastClickMsg As Win32.Message = Win32.Message.HWND_TOP

		' Token: 0x04000014 RID: 20
		Private m_isDown As AlphaForm.HeldButtons

		' Token: 0x02000010 RID: 16
		Public Enum SizeModes
			' Token: 0x04000090 RID: 144
			None
			' Token: 0x04000091 RID: 145
			Stretch
			' Token: 0x04000092 RID: 146
			Clip
		End Enum

		' Token: 0x02000011 RID: 17
		' (Invoke) Token: 0x0600004B RID: 75
		Private Delegate Sub delMouseEvent(e As MouseEventArgs)

		' Token: 0x02000012 RID: 18
		' (Invoke) Token: 0x0600004F RID: 79
		Private Delegate Sub delStdEvent(e As EventArgs)

		' Token: 0x02000013 RID: 19
		Private Structure HeldButtons
			' Token: 0x04000093 RID: 147
			Public Left As Boolean

			' Token: 0x04000094 RID: 148
			Public Middle As Boolean

			' Token: 0x04000095 RID: 149
			Public Right As Boolean

			' Token: 0x04000096 RID: 150
			Public XBtn As Boolean
		End Structure

	End Class

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
		Public Sub New()
			MyBase.ShowInTaskbar = False
			MyBase.FormBorderStyle = FormBorderStyle.None
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
	End Class


End Namespace