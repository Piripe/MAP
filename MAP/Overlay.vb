Public Class Overlay
    Private _UseOldSystem As Boolean

    Interface IOverlay
        Function Tick(Size As Size, Quality As Overlay.Quality) As Image
        Function Save() As XElement
        Sub Load(code As XElement)
        Property Settings As Object
        Property ClientSettings As List(Of Setting)
        Property RefreshDelay As RefreshDelay
        ReadOnly Property Dependences As String()
        ReadOnly Property Icon As Icon
    End Interface
    Property Overlay As IOverlay
    Property Form As Form
    Property Control As PictureBox
    Property Location As Point
    Property Type As String
    Property Name As String
    Property UseOldSystem As Boolean
        Get
            Return _UseOldSystem
        End Get
        Set
            _UseOldSystem = Value
            NewOverlay(Type, Name, resetall:=False)
        End Set
    End Property

    Property Graphics As Graphics
    Property Flag As Bitmap
    Sub New(Type_ As String, Name_ As String, Optional code As XElement = Nothing, Optional resetall As Boolean = True)
        NewOverlay(Type_, Name_, code, resetall)
    End Sub
    Sub NewOverlay(Type_ As String, Name_ As String, Optional code As XElement = Nothing, Optional resetall As Boolean = True)
        Dim size_ = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height / 4)
        Dim opacity_ = 0.7
        If Not resetall Then
            size_ = Form.Size
            opacity_ = Form.Opacity
        End If
        Try
            If Form IsNot Nothing Then
                Form.Close()
                CType(Form, DefaultOverlay).m_layeredWnd.Close()
            End If
        Catch
        End Try

        If UseOldSystem Then
            Form = New OldDefaultOverlay()
            Control = New PictureBox ' CreateOverlayControl(Type_)
            Control.Dock = DockStyle.Fill
            Form.Controls.Add(Control)
            Form.Controls.Item(0).Dock = DockStyle.Fill
        Else
            Form = New DefaultOverlay(Name_)
            'CType(Form, DefaultOverlay).m_layeredWnd.Name = Name_
            'CType(Form, DefaultOverlay).m_layeredWnd.Text = Name_
        End If
        'MsgBox(OverlaysControl(0).ToString)
        If resetall Then
            Location = New Point(0, My.Computer.Screen.WorkingArea.Height / 4 * 3)
            Type = Type_
            Name = Name_

            Overlay = Activator.CreateInstance(System.Type.GetType("MAP." & Type)) 'New MusicFrequencies 'Sub() control.Tick()
            Try
                Overlay.Load(code)
            Catch
            End Try
        End If
        Form.Size = size_
        Form.Name = Name_
        Form.Text = Name_
        Form.Opacity = opacity_
        Form.FormBorderStyle = FormBorderStyle.None
        'MsgBox(My.Computer.Screen.WorkingArea.Height / 4 * 3 & " , " & Form.Location.Y)
        Form.TransparencyKey = Color.FromKnownColor(KnownColor.Control)
        Form.ShowInTaskbar = False
        'Form.TopLevel = False
        Form.TopMost = True
        Form.Enabled = False
        'Dim hwnd = OverlayGestion.GetWindowLong(Form.Handle, -20) Or &H80000 Or &H20
        'OverlayGestion.SetWindowLongA(Form.Handle, -8, hwnd)
        'OverlayGestion.SetWindowLong(Form.Handle, -20, hwnd)
        'OverlayGestion.SetForegroundWindow(hwnd)
        Form.Icon = Overlay.Icon
        Form.Show()
        Form.Location = Location
        Try
            CType(Form, DefaultOverlay).m_layeredWnd.Location = Location
        Catch
        End Try
    End Sub

    Enum RefreshDelay
        Frame = 0
        Ms100 = 1
        Ms1000 = 2
    End Enum
    Enum Quality
        High = 0
        Low = 1
    End Enum
    Class Setting
        Enum SettingType
            Label = 0
            TextBox = 1
            Trackbar = 2
            ComboBox = 3
            Checkbox = 4
            Color = 5
            Font = 6
        End Enum
        Property Name As String
        Property Type As SettingType
        Property Reference As String
        Property Values As String()
        Property Min As Int32
        Property Max As Int32
        Sub New(Name_ As String, Type_ As SettingType, Optional Reference_ As String = Nothing, Optional Values_ As String() = Nothing, Optional Min_ As Int32 = 0, Optional Max_ As Int32 = 255)
            Name = Name_
            Type = Type_
            Reference = Reference_
            Values = Values_
            Min = Min_
            Max = Max_
        End Sub
    End Class
End Class
