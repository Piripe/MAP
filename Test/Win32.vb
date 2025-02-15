Imports System.Runtime.InteropServices
Imports System.Text

Public Module Win32
	' Token: 0x06000001 RID: 1
	Public Declare Function SendMessage Lib "user32.dll" (hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

	' Token: 0x06000002 RID: 2
	Public Declare Function ReleaseCapture Lib "user32.dll" () As Boolean

	' Token: 0x06000003 RID: 3
	Public Declare Sub SetCapture Lib "user32.dll" (hWnd As IntPtr)

	' Token: 0x06000004 RID: 4
	Public Declare Function GetCapture Lib "user32.dll" () As IntPtr

	' Token: 0x06000005 RID: 5
	Public Declare Function SetWindowPos Lib "user32.dll" (hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, uFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean

	' Token: 0x06000006 RID: 6
	Public Declare Function SetParent Lib "user32.dll" (hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr

	' Token: 0x06000007 RID: 7
	<DllImport("user32.dll", EntryPoint:="SetWindowLong")>
	Public Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, flags As Long) As IntPtr
	End Function

	' Token: 0x06000008 RID: 8
	<DllImport("user32.dll", EntryPoint:="SetWindowLong")>
	Public Function SetWindowLong(hWnd As IntPtr, nIndex As UInteger, newProc As Win32.Win32WndProc) As IntPtr
	End Function

	' Token: 0x06000009 RID: 9
	<DllImport("user32.dll", EntryPoint:="CallWindowProc")>
	Public Function CallWindowProc(lpPrevWndFunc As IntPtr, hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
	End Function

	' Token: 0x0600000A RID: 10
	Public Declare Function LockWindowUpdate Lib "user32.dll" (hWndLock As IntPtr) As Boolean

	' Token: 0x0600000B RID: 11
	Public Declare Function ShowWindow Lib "user32.dll" (hWnd As IntPtr, nCmdShow As Integer) As Boolean

	' Token: 0x0600000C RID: 12
	Public Declare Function GetWindowLong Lib "user32.dll" (hWnd As IntPtr, nIndex As UInteger) As Long

	' Token: 0x0600000D RID: 13
	Public Declare Function BeginDeferWindowPos Lib "user32.dll" (nNumWindows As Integer) As IntPtr

	' Token: 0x0600000E RID: 14
	Public Declare Function DeferWindowPos Lib "user32.dll" (hWinPosInfo As IntPtr, hWnd As IntPtr, hWndInsertAfter As IntPtr, x As Integer, y As Integer, cx As Integer, cy As Integer, uFlags As UInteger) As IntPtr

	' Token: 0x0600000F RID: 15
	Public Declare Function EndDeferWindowPos Lib "user32.dll" (hWinPosInfo As IntPtr) As Boolean

	' Token: 0x06000010 RID: 16
	Public Declare Function GetWindow Lib "user32.dll" (hWnd As IntPtr, uCmd As Win32.GetWindow_Cmd) As IntPtr

	' Token: 0x06000011 RID: 17
	Public Declare Function EnableWindow Lib "user32.dll" (hWnd As IntPtr, bEnable As Boolean) As Boolean

	' Token: 0x06000012 RID: 18
	Public Declare Function SetFocus Lib "user32.dll" (hWnd As IntPtr) As IntPtr

	' Token: 0x06000013 RID: 19
	<DllImport("user32.dll")>
	Public Function SetCursor(hcur As IntPtr) As IntPtr
	End Function

	' Token: 0x06000014 RID: 20
	<DllImport("user32.dll")>
	Public Function LoadCursor(hInstcance As IntPtr, hcur As Win32.SystemCursor) As IntPtr
	End Function

	' Token: 0x06000015 RID: 21
	Public Declare Function GetDC Lib "user32.dll" (hWnd As IntPtr) As IntPtr

	' Token: 0x06000016 RID: 22
	Public Declare Function CreateCompatibleDC Lib "gdi32.dll" (hDC As IntPtr) As IntPtr

	' Token: 0x06000017 RID: 23
	Public Declare Function SelectObject Lib "gdi32.dll" (hDC As IntPtr, hObject As IntPtr) As IntPtr

	' Token: 0x06000018 RID: 24
	Public Declare Function DeleteObject Lib "gdi32.dll" (hObject As IntPtr) As Boolean

	' Token: 0x06000019 RID: 25
	Public Declare Function DeleteDC Lib "gdi32.dll" (hdc As IntPtr) As Boolean

	' Token: 0x0600001A RID: 26
	Public Declare Function ReleaseDC Lib "user32.dll" (hWnd As IntPtr, hDC As IntPtr) As Integer

	' Token: 0x0600001B RID: 27
	Public Declare Auto Function GetWindowTextLength Lib "user32.dll" (hWnd As IntPtr) As Integer

	' Token: 0x0600001C RID: 28
	Public Declare Auto Function GetWindowText Lib "user32.dll" (hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer) As Integer

	' Token: 0x0600001D RID: 29
	Public Declare Function IsWindowVisible Lib "user32.dll" (hWnd As IntPtr) As Boolean

	' Token: 0x0600001E RID: 30
	Public Declare Function UpdateLayeredWindow Lib "user32.dll" (hwnd As IntPtr, hdcDst As IntPtr, ByRef pptDst As Point, ByRef psize As Size, hdcSrc As IntPtr, ByRef pprSrc As Point, crKey As Integer, ByRef pblend As Win32.BLENDFUNCTION, dwFlags As Win32.BlendFlags) As Boolean

	' Token: 0x0600001F RID: 31
	Public Declare Function GetWindowDC Lib "user32.dll" (hWnd As IntPtr) As IntPtr

	' Token: 0x06000020 RID: 32
	Public Declare Function BitBlt Lib "gdi32.dll" (hdc As IntPtr, nXDest As Integer, nYDest As Integer, nWidth As Integer, nHeight As Integer, hdcSrc As IntPtr, nXSrc As Integer, nYSrc As Integer, dwRop As Win32.TernaryRasterOperations) As <MarshalAs(UnmanagedType.Bool)> Boolean

	' Token: 0x06000021 RID: 33
	Public Declare Function CreateCompatibleBitmap Lib "gdi32.dll" (hdc As IntPtr, nWidth As Integer, nHeight As Integer) As IntPtr

	' Token: 0x06000022 RID: 34
	Public Declare Function CreateBitmap Lib "gdi32.dll" (nWidth As Integer, nHeight As Integer, cPlanes As UInteger, cBitsPerPel As UInteger, lpvBits As IntPtr) As IntPtr

	' Token: 0x06000023 RID: 35
	Public Declare Function SetBkColor Lib "gdi32.dll" (hdc As IntPtr, crColor As UInteger) As UInteger

	' Token: 0x06000024 RID: 36
	Public Declare Function CreateSolidBrush Lib "gdi32.dll" (crColor As UInteger) As IntPtr

	' Token: 0x06000025 RID: 37
	Public Declare Function GetPixel Lib "gdi32.dll" (hdc As IntPtr, nXPos As Integer, nYPos As Integer) As UInteger

	' Token: 0x06000026 RID: 38
	Public Declare Function MaskBlt Lib "gdi32.dll" (hdcDest As IntPtr, nXDest As Integer, nYDest As Integer, nWidth As Integer, nHeight As Integer, hdcSrc As IntPtr, nXSrc As Integer, nYSrc As Integer, hbmMask As IntPtr, xMask As Integer, yMask As Integer, dwRop As UInteger) As Boolean

	' Token: 0x02000005 RID: 5
	Public Enum Message As UInteger
		' Token: 0x04000017 RID: 23
		WM_NCHITTEST = 132UI
		' Token: 0x04000018 RID: 24
		HTTRANSPARENT = 4294967295UI
		' Token: 0x04000019 RID: 25
		HTCLIENT = 1UI
		' Token: 0x0400001A RID: 26
		HTCAPTION
		' Token: 0x0400001B RID: 27
		WM_NCMOUSEMOVE = 160UI
		' Token: 0x0400001C RID: 28
		WM_NCLBUTTONDOWN
		' Token: 0x0400001D RID: 29
		WM_NCLBUTTONUP
		' Token: 0x0400001E RID: 30
		WM_NCLBUTTONDBLCLK
		' Token: 0x0400001F RID: 31
		WM_WINDOWPOSCHANGING = 70UI
		' Token: 0x04000020 RID: 32
		WM_ENTERSIZEMOVE = 561UI
		' Token: 0x04000021 RID: 33
		WM_EXITSIZEMOVE
		' Token: 0x04000022 RID: 34
		WM_SYSCOMMAND = 274UI
		' Token: 0x04000023 RID: 35
		WM_PAINT = 15UI
		' Token: 0x04000024 RID: 36
		HWND_TOP = 0UI
		' Token: 0x04000025 RID: 37
		SC_MINIMIZE = 61472UI
		' Token: 0x04000026 RID: 38
		SC_RESTORE = 61728UI
		' Token: 0x04000027 RID: 39
		SC_MAXIMIZE = 61488UI
		' Token: 0x04000028 RID: 40
		WM_SIZE = 5UI
		' Token: 0x04000029 RID: 41
		WM_ACTIVATE
		' Token: 0x0400002A RID: 42
		WM_SETFOCUS
		' Token: 0x0400002B RID: 43
		WM_SETCURSOR = 32UI
		' Token: 0x0400002C RID: 44
		WM_MOUSEMOVE = 512UI
		' Token: 0x0400002D RID: 45
		WM_LBUTTONDOWN
		' Token: 0x0400002E RID: 46
		WM_LBUTTONUP
		' Token: 0x0400002F RID: 47
		WM_LBUTTONDBLCLK
		' Token: 0x04000030 RID: 48
		WM_RBUTTONDOWN
		' Token: 0x04000031 RID: 49
		WM_RBUTTONUP
		' Token: 0x04000032 RID: 50
		WM_RBUTTONDBLCLK
		' Token: 0x04000033 RID: 51
		WM_MBUTTONDOWN
		' Token: 0x04000034 RID: 52
		WM_MBUTTONUP
		' Token: 0x04000035 RID: 53
		WM_MBUTTONDBLCLK
		' Token: 0x04000036 RID: 54
		WM_MOUSEWHEEL
		' Token: 0x04000037 RID: 55
		WM_XBUTTONDOWN
		' Token: 0x04000038 RID: 56
		WM_XBUTTONUP
		' Token: 0x04000039 RID: 57
		WM_XBUTTONDBLCLK
		' Token: 0x0400003A RID: 58
		WM_MOUSELEAVE = 675UI
		' Token: 0x0400003B RID: 59
		WM_WINDOWPOSCHANGED = 71UI
		' Token: 0x0400003C RID: 60
		WM_NCACTIVATE = 134UI
		' Token: 0x0400003D RID: 61
		GWL_WNDPROC = 4294967292UI
		' Token: 0x0400003E RID: 62
		GWL_EXSTYLE = 4294967276UI
	End Enum

	' Token: 0x02000006 RID: 6
	Public Structure WINDOWPOS
		' Token: 0x0400003F RID: 63
		Public hwnd As IntPtr

		' Token: 0x04000040 RID: 64
		Public hwndInsertAfter As IntPtr

		' Token: 0x04000041 RID: 65
		Public x As Integer

		' Token: 0x04000042 RID: 66
		Public y As Integer

		' Token: 0x04000043 RID: 67
		Public cx As Integer

		' Token: 0x04000044 RID: 68
		Public cy As Integer

		' Token: 0x04000045 RID: 69
		Public flags As Win32.WindowPosFlags
	End Structure

	' Token: 0x02000007 RID: 7
	<Flags()>
	Public Enum WindowPosFlags As UInteger
		' Token: 0x04000047 RID: 71
		NONE = 0UI
		' Token: 0x04000048 RID: 72
		SWP_NOSIZE = 1UI
		' Token: 0x04000049 RID: 73
		SWP_NOMOVE = 2UI
		' Token: 0x0400004A RID: 74
		SWP_NOZORDER = 4UI
		' Token: 0x0400004B RID: 75
		SWP_NOREDRAW = 8UI
		' Token: 0x0400004C RID: 76
		SWP_NOACTIVATE = 16UI
		' Token: 0x0400004D RID: 77
		SWP_FRAMECHANGED = 32UI
		' Token: 0x0400004E RID: 78
		SWP_SHOWWINDOW = 64UI
		' Token: 0x0400004F RID: 79
		SWP_HIDEWINDOW = 128UI
		' Token: 0x04000050 RID: 80
		SWP_NOCOPYBITS = 256UI
		' Token: 0x04000051 RID: 81
		SWP_NOOWNERZORDER = 512UI
		' Token: 0x04000052 RID: 82
		SWP_NOSENDCHANGING = 1024UI
		' Token: 0x04000053 RID: 83
		SWP_DEFERERASE = 8192UI
		' Token: 0x04000054 RID: 84
		SWP_ASYNCWINDOWPOS = 16384UI
		' Token: 0x04000055 RID: 85
		SWP_CUSTOMFLAG = 32768UI
	End Enum

	' Token: 0x02000008 RID: 8
	Public Enum WindowStyles
		' Token: 0x04000057 RID: 87
		WS_EX_LAYERED = 524288
		WS_EX_NOACTIVATE = 134217728
		WS_EX_TOOLWINDOW = 128
		WS_EX_TRANSPARENT = &H20
	End Enum

	' Token: 0x02000009 RID: 9
	Public Enum GetWindow_Cmd As UInteger
		' Token: 0x04000059 RID: 89
		GW_HWNDFIRST
		' Token: 0x0400005A RID: 90
		GW_HWNDLAST
		' Token: 0x0400005B RID: 91
		GW_HWNDNEXT
		' Token: 0x0400005C RID: 92
		GW_HWNDPREV
		' Token: 0x0400005D RID: 93
		GW_OWNER
		' Token: 0x0400005E RID: 94
		GW_CHILD
		' Token: 0x0400005F RID: 95
		GW_ENABLEDPOPUP
	End Enum

	' Token: 0x0200000A RID: 10
	Public Enum SystemCursor
		' Token: 0x04000061 RID: 97
		IDC_APPSTARTING = 32650
		' Token: 0x04000062 RID: 98
		IDC_NORMAL = 32512
		' Token: 0x04000063 RID: 99
		IDC_CROSS = 32515
		' Token: 0x04000064 RID: 100
		IDC_HAND = 32649
		' Token: 0x04000065 RID: 101
		IDC_HELP = 32651
		' Token: 0x04000066 RID: 102
		IDC_IBEAM = 32513
		' Token: 0x04000067 RID: 103
		IDC_NO = 32648
		' Token: 0x04000068 RID: 104
		IDC_SIZEALL = 32646
		' Token: 0x04000069 RID: 105
		IDC_SIZENESW = 32643
		' Token: 0x0400006A RID: 106
		IDC_SIZENS = 32645
		' Token: 0x0400006B RID: 107
		IDC_SIZENWSE = 32642
		' Token: 0x0400006C RID: 108
		IDC_SIZEWE = 32644
		' Token: 0x0400006D RID: 109
		IDC_UP = 32516
		' Token: 0x0400006E RID: 110
		IDC_WAIT = 32514
	End Enum

	' Token: 0x0200000B RID: 11
	<StructLayout(LayoutKind.Sequential, Pack:=1)>
	Public Structure BLENDFUNCTION
		' Token: 0x0400006F RID: 111
		Public BlendOp As Byte

		' Token: 0x04000070 RID: 112
		Public BlendFlags As Byte

		' Token: 0x04000071 RID: 113
		Public SourceConstantAlpha As Byte

		' Token: 0x04000072 RID: 114
		Public AlphaFormat As Byte
	End Structure

	' Token: 0x0200000C RID: 12
	Public Enum BlendOps As Byte
		' Token: 0x04000074 RID: 116
		AC_SRC_OVER
		' Token: 0x04000075 RID: 117
		AC_SRC_ALPHA
		' Token: 0x04000076 RID: 118
		AC_SRC_NO_PREMULT_ALPHA = 1
		' Token: 0x04000077 RID: 119
		AC_SRC_NO_ALPHA
		' Token: 0x04000078 RID: 120
		AC_DST_NO_PREMULT_ALPHA = 16
		' Token: 0x04000079 RID: 121
		AC_DST_NO_ALPHA = 32
	End Enum

	' Token: 0x0200000D RID: 13
	Public Enum BlendFlags As UInteger
		' Token: 0x0400007B RID: 123
		None
		' Token: 0x0400007C RID: 124
		ULW_COLORKEY
		' Token: 0x0400007D RID: 125
		ULW_ALPHA
		' Token: 0x0400007E RID: 126
		ULW_OPAQUE = 4UI
	End Enum

	' Token: 0x0200000E RID: 14
	Public Enum TernaryRasterOperations As UInteger
		' Token: 0x04000080 RID: 128
		SRCCOPY = 13369376UI
		' Token: 0x04000081 RID: 129
		SRCPAINT = 15597702UI
		' Token: 0x04000082 RID: 130
		SRCAND = 8913094UI
		' Token: 0x04000083 RID: 131
		SRCINVERT = 6684742UI
		' Token: 0x04000084 RID: 132
		SRCERASE = 4457256UI
		' Token: 0x04000085 RID: 133
		NOTSRCCOPY = 3342344UI
		' Token: 0x04000086 RID: 134
		NOTSRCERASE = 1114278UI
		' Token: 0x04000087 RID: 135
		MERGECOPY = 12583114UI
		' Token: 0x04000088 RID: 136
		MERGEPAINT = 12255782UI
		' Token: 0x04000089 RID: 137
		PATCOPY = 15728673UI
		' Token: 0x0400008A RID: 138
		PATPAINT = 16452105UI
		' Token: 0x0400008B RID: 139
		PATINVERT = 5898313UI
		' Token: 0x0400008C RID: 140
		DSTINVERT = 5570569UI
		' Token: 0x0400008D RID: 141
		BLACKNESS = 66UI
		' Token: 0x0400008E RID: 142
		WHITENESS = 16711778UI
	End Enum

	' Token: 0x0200000F RID: 15
	' (Invoke) Token: 0x06000047 RID: 71
	Public Delegate Function Win32WndProc(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
End Module