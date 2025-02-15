Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class Form1
    Inherits AlphaForms.AlphaForm

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BackColor = System.Drawing.Color.Black
        'TransparencyKey = System.Drawing.Color.Black
        'Label1.BackColor = System.Drawing.Color.Transparent
        'Label1.ForeColor = System.Drawing.Color.White
        'SetOpacity(0.5)
        'BackColor = Color.Transparent
        'BackgroundImage = x
        'UpdateLayeredBackground()
        'Dim hwnd = GetWindowLong(Handle, -20)
        'SetWindowLong(Handle, -20, hwnd Or &H80000 Or &H20)


    End Sub
    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        'e.Graphics.Clear(Color.Empty)
        'MyBase.OnPaintBackground(e)
    End Sub
    Public Function Tick(Size As Size) As Image

        'Dim g = e.Graphics
        Dim flag As New Bitmap(Size.Width, Size.Height)
        'flag.MakeTransparent()
        Using g = Graphics.FromImage(flag)
            g.Clear(Color.Transparent)
            'g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            'g.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
            'g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            'g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Dim texts = Regex.Split(CStr("Coucou {time:HH:mm:ss}"), "\{([^}]*)\}")

            For i = 1 To texts.Length - 1 Step 2
                Try
                    Dim splited = texts(i).Split(":")
                    Select Case splited(0)
                        Case "time"
                            texts(i) = Date.Now.ToString(texts(i).Remove(0, 5))
                    End Select
                Catch ex As Exception
                    texts(i) &= "ERROR [" & ex.Message & "]"
                End Try
            Next
            'g.CopyFromScreen(New Point(10, 10), New Point(0, 0), Size)
            g.DrawString(String.Join("", texts), New Font("Segoe UI", 20), Brushes.White, 5, 5)
            'g.FillEllipse(Brushes.Black, 0, 0, 100, 100)
        End Using

        Return flag
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim x = Tick(Size)
        'If BlendedBackground IsNot Nothing Then BlendedBackground.Dispose()
        'BlendedBackground = x

    End Sub
End Class
