Imports MAP.libZPlay
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Public Class OverlayGestion
Public Const Version As String = "0.2.0.17"

#Region "Win32"
    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property
    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function
    <DllImport("user32.dll")> Public Shared Function BringWindowToTop(ByVal hWnd As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll")> Public Shared Function GetActiveWindow() As IntPtr
    End Function
    <DllImport("user32.dll")> Public Shared Function SetActiveWindow(ByVal hwnd As IntPtr) As IntPtr
    End Function
#End Region

#Region "Modules And Overlays Infos"

    Public ModulesID As String() = {"MusicModule", "HardwareInfosModule"}
    Public ModulesName As String() = {"Music Player", "Hardware Infos"}
    Public ModulesDescription As String() = {"By Piripe
Version 0.2
Add a music player into MAP and display title and frequencies.", "By Piripe
Version 0.1
Add a performance counter and detect harware infos for the custom overlay"}
    Public ModulesIcon As Image() = {My.Resources.music_player, My.Resources.hardware_infos}

    'Public ModulesList As New List(Of OverlayModule.IOverlayModule)
    Public ActiveModules As List(Of Boolean) = {True, False}.ToList
    Public OverlaysList As New List(Of Overlay)
    Public ActiveOverlays As List(Of Boolean) = {True}.ToList
#End Region


    Public FirstStart As Boolean = IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MAP/config"))
    Public IgnoreTopMost As Boolean = False
    Public ForceTopMost As Boolean = True
    Public UpdateCanal As Int32 = 0
    Public WaitForBetacode As Int32 = 1
    Public UpdateSource As Int32 = 0
    Public Betacode As String = ""
    Public context As TaskScheduler

    Public Async Sub Form1_Load() Handles MyBase.Load
        If Not IO.Directory.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MAP")) Then
            IO.Directory.CreateDirectory(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MAP"))
        End If
        'MsgBox(String.Join(vbCr, Regex.Split("Salut {text} texte {test{lol}et non", "\{([^}]*)\}")))
        'MsgBox(Date.Now.ToString("dddd d""'th"" MMMM yyyy ""at"" hh:mm:ss tt"))
        'Dim x As New AlphaFormTransformer.AlphaFormTransformer()
        'x.
        Await Task.Delay(1)
        Hide()
        Dim MAP_count = 0
        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "MAP" Then
                MAP_count += 1
                If MAP_count >= 2 Then
                    Await Task.Delay(150)
                    Close()
                End If
            End If
        Next

        If FirstStart Then
            Settings.LoadSettings()
        Else
            OverlaysList.Add(New Overlay("MusicFrequencies", "Music Frequencies"))
            Settings.SaveSettings()
            Settings.Show()
        End If
        If ActiveModules(1) Then HardwareInfosModule.Load(Nothing)
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        NotifyIcon1.Visible = True
        If ActiveModules(0) Then
            Dim loadMusic As Boolean = False
        For Each x In My.Application.CommandLineArgs
            If MusicModule.SupportedExtensions.Contains(IO.Path.GetExtension(x).ToLower) Then loadMusic = True
        Next
            If loadMusic Then
                MusicModule.AddFile(My.Application.CommandLineArgs.ToArray)
            End If
        End If
        context = TaskScheduler.FromCurrentSynchronizationContext
#Disable Warning BC42358 ' Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        Task.Run(Sub() CheckUpdate(context))
#Enable Warning BC42358 ' Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
    End Sub

    Sub CheckUpdate(context As TaskScheduler)
        Try
            Dim pastebin_versions As String() = {""}
            If UpdateCanal = 0 Then
                pastebin_versions = New Net.WebClient().DownloadString("https://pastebin.com/raw/01K41WU6").Split(vbCr)
            Else
                Dim found_code As Boolean = False
                Dim code = New Net.WebClient().DownloadString("https://pastebin.com/raw/yuYdbBPa").Split(vbCr)
                For Each x In code
                    Try
                        Dim decrypted_str As String = New Simple3Des(Betacode.Replace("-", "")).DecryptData(x)
                        If decrypted_str.StartsWith("§") Then
                            found_code = True
                            pastebin_versions = decrypted_str.Remove(0, 1).Split("§")
                        End If
                    Catch
                    End Try
                Next
                If Not found_code Then
                    found_code = False
                    For Each x In code
                        Try
                            Dim decrypted_str As String = New Simple3Des("").DecryptData(x)
                            If decrypted_str.StartsWith("§") Then
                                found_code = True
                                pastebin_versions = decrypted_str.Remove(0, 1).Split("§")
                            End If
                        Catch
                        End Try
                    Next
                    If Not found_code Then
                        pastebin_versions = New Net.WebClient().DownloadString("https://pastebin.com/raw/01K41WU6").Split(vbCr)
                    End If
                End If
            End If
            If Not pastebin_versions(0) = Version Then
                If MsgBox("Update Available (" & Version & " to " & pastebin_versions(0) & ")" & vbCr & vbCr & "Install ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    For Each prog As Process In Process.GetProcesses
                        If prog.ProcessName = "MAPUpdate" Then
                            prog.Kill()
                            prog.WaitForExit()
                            Print("Killed Process!", context)
                        End If
                    Next

                    If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUpdate.exe") Then IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUpdate.exe")
                    Dim x = New Net.WebClient()
                    x.DownloadFile(pastebin_versions(1), My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUpdate.exe")

                    Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUpdate.exe", "/S /L /D """ & IO.Directory.GetCurrentDirectory & """ " & If(My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", False) Is Nothing, "/R", If(My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", False).GetValue("InstallLocation") = IO.Directory.GetCurrentDirectory(), "", "/R")))
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Function CheckBetaCode(code As String) As Boolean
        Try
            For Each x In New Net.WebClient().DownloadString("https://pastebin.com/raw/yuYdbBPa").Split(vbCr)
                Try
                    Dim decrypted_str As String = New Simple3Des(code.Replace("-", "")).DecryptData(x)
                    If decrypted_str.StartsWith("§") Then
                        Return True
                    End If
                Catch

                End Try
            Next
        Catch ex As Exception
        End Try
        Return False
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            For i = 0 To ActiveModules.Count - 1
                If ActiveModules(i) Then
                    Select Case i
                        Case 0
                            MusicModule.TickFrame()
                        Case 1
                            HardwareInfosModule.TickFrame()
                    End Select
                End If
            Next
            For i = 0 To OverlaysList.Count - 1
                If ActiveOverlays(i) And OverlaysList(i).Overlay.RefreshDelay = Overlay.RefreshDelay.Frame Then
                    Try
                        If OverlaysList(i).UseOldSystem Then
                            If OverlaysList(i).Control IsNot Nothing Then
                                If OverlaysList(i).Control.BackgroundImage IsNot Nothing Then OverlaysList(i).Control.BackgroundImage.Dispose()
                                OverlaysList(i).Control.BackgroundImage = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 1)
                            End If
                        Else
                            If CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground IsNot Nothing Then CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground.Dispose()
                            CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 0)
                        End If
                    Catch
                    End Try
                End If
                'If ActiveOverlays.Count >= 2 Then If ActiveOverlays(1) Then OverlaysList(1).Overlay.Tick() 'context) 'Task.Run(Sub())
            Next 'Task.Run(Sub() )
            RenderTime += RenderSW.ElapsedMilliseconds
            RenderedFrames += 1
            RenderSW.Stop()
            RenderSW.Reset()
            RenderSW.Start()
        Catch
        End Try
    End Sub

    Dim RenderSW As New Stopwatch
    Public RenderTime = 16
    Public RenderedFrames = 1
    Public SkipFrameToGetMaxFPS = 1
    Public SkipedFrameToGetMaxFPS = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            For i = 0 To ActiveModules.Count - 1
                If ActiveModules(i) Then
                    Select Case i
                        Case 0
                            MusicModule.TickMS100()
                        Case 1
                            HardwareInfosModule.TickMS100()
                    End Select
                End If
            Next
            For i = 0 To OverlaysList.Count - 1
                If ActiveOverlays(i) And OverlaysList(i).Overlay.RefreshDelay = Overlay.RefreshDelay.Ms100 Then
                    Try
                        If OverlaysList(i).UseOldSystem Then
                            If OverlaysList(i).Control IsNot Nothing Then
                                If OverlaysList(i).Control.BackgroundImage IsNot Nothing Then OverlaysList(i).Control.BackgroundImage.Dispose()
                                OverlaysList(i).Control.BackgroundImage = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 1)
                            End If
                        Else
                            If CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground IsNot Nothing Then CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground.Dispose()
                            CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 0)
                        End If
                    Catch
                    End Try
                End If
            Next
            Dim processes = Process.GetProcessesByName("MAP")
            Try
                If processes.Count >= 2 Then
                    For Each prog As Process In processes
                        If prog.Id <> Process.GetCurrentProcess.Id Then
                            Dim args As List(Of String) = Win32.CommandLineToArgs(Win32.GetCommandLineOfProcess(prog)).ToList
                            prog.Kill()
                            'MsgBox("{" & String.Join(", ", SupportedExtensions) & "}.Contains(" & IO.Path.GetExtension(args(1).Replace("""", "")).ToLower.Remove(0, 1) & ") = " & MusicModule.SupportedExtensions.Contains(IO.Path.GetExtension(args(1).Replace("""", "")).ToLower.Remove(0, 1)))
                            Dim loadMusic As Boolean = False
                            For Each x In args
                                If MusicModule.SupportedExtensions.Contains(IO.Path.GetExtension(x.Replace("""", "")).ToLower) Then loadMusic = True
                            Next
                            If loadMusic Then
                                For i = 0 To args.Count - 1
                                    args(i) = args(i).Replace("""", "")
                                Next
                                args.RemoveAt(0)
                                MusicModule.AddFile(args.ToArray)
                            Else
                                Settings.Show()
                            End If
                            'MsgBox(String.Join(vbCrLf, args))
                        End If
                    Next
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            For i = 0 To OverlaysList.Count - 1
                If ActiveOverlays(i) Then
                Else
                End If
            Next
        Catch
        End Try
    End Sub


    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Settings.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Settings.SaveSettings()
        For Each x In OverlaysList
            Try
                CType(x.Form, DefaultOverlay).CanClose = True
                x.Form.Close()
            Catch
            End Try
        Next
        Close()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick() Handles NotifyIcon1.MouseDoubleClick, PlaylistToolStripMenuItem1.Click
        My.Forms.MusicModulePlaylist.Show()
    End Sub
    Public old_hwnd = IntPtr.Zero
    Public old_hwnd_equal_count = 0
    Public Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try

            PlaylistToolStripMenuItem1.Visible = ActiveModules(0)
            For i = 0 To ActiveModules.Count - 1
                If ActiveModules(i) Then
                    Select Case i
                        Case 0
                            MusicModule.TickMS1000()
                        Case 1
                            If Not HardwareInfosModule.Loaded Then HardwareInfosModule.Load(Nothing)
                            HardwareInfosModule.TickMS1000()
                    End Select
                End If
            Next
            Dim hwnd = GetActiveWindow()
            'Dim processes_count = Process.GetProcesses().Count
            For i = 0 To OverlaysList.Count - 1
                If ActiveOverlays(i) Then
                    OverlaysList(i).Form.Show()
                    If Not OverlaysList(i).UseOldSystem Then CType(OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.Show()
                    If old_hwnd <> hwnd Or old_hwnd_equal_count < 2 Then
                        If ForceTopMost And Not IgnoreTopMost Then
                            OverlaysList(i).Form.TopMost = False
                            OverlaysList(i).Form.TopMost = True
                            If Not OverlaysList(i).UseOldSystem Then CType(OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.TopMost = False
                            If Not OverlaysList(i).UseOldSystem Then CType(OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.TopMost = True
                        End If
                    End If
                Else
                    OverlaysList(i).Form.Hide()
                    If Not OverlaysList(i).UseOldSystem Then CType(OverlaysList(i).Form, DefaultOverlay).m_layeredWnd.Hide()
                End If
            Next
            If old_hwnd <> hwnd Then
                old_hwnd = hwnd
                old_hwnd_equal_count = 0
            Else
                old_hwnd_equal_count += 1
            End If
            If ForceTopMost And Not IgnoreTopMost Then SetActiveWindow(hwnd)
            For i = 0 To OverlaysList.Count - 1
                If ActiveOverlays(i) And OverlaysList(i).Overlay.RefreshDelay = Overlay.RefreshDelay.Ms1000 Then
                    Try
                        If OverlaysList(i).UseOldSystem Then
                            If OverlaysList(i).Control IsNot Nothing Then
                                If OverlaysList(i).Control.BackgroundImage IsNot Nothing Then OverlaysList(i).Control.BackgroundImage.Dispose()
                                OverlaysList(i).Control.BackgroundImage = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 1)
                            End If
                        Else
                            If CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground IsNot Nothing Then CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground.Dispose()
                            CType(OverlaysList(i).Form, DefaultOverlay).BlendedBackground = OverlaysList(i).Overlay.Tick(OverlaysList(i).Form.Size, 0)
                        End If
                    Catch
                    End Try
                End If
            Next

        Catch
        End Try
    End Sub

    Public Sub StartIgnoreTopMost() Handles ContextMenuStrip1.Opening
        IgnoreTopMost = True
    End Sub

    Public Sub StopIgnoreTopMost() Handles ContextMenuStrip1.Closed
        IgnoreTopMost = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As EventArgs) Handles PlaylistToolStripMenuItem1.Click, NotifyIcon1.MouseDoubleClick

    End Sub
End Class
