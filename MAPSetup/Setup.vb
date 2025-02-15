Public Class Setup
Const version As String = "0.2.0.17"
    Dim files_list As String() = {"MAP.exe", "Uninstall.exe", "lib/libzplay.dll"}
    Dim mode As Int32 = 0

    Private Async Sub Setup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Print("MAP Setup v" & version)
        PathTextBox.Text = If(My.Application.CommandLineArgs.Contains("/D") Or My.Application.CommandLineArgs.Contains("/DIR"), My.Application.CommandLineArgs(My.Application.CommandLineArgs.ToList.FindIndex(Function(x) (x = "/D") Or (x = "/DIR")) + 1), IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "MAP"))
        AddDesktopCheckBox.Checked = Not (My.Application.CommandLineArgs.Contains("/L") Or My.Application.CommandLineArgs.Contains("/NOLINKS"))

        If My.Application.CommandLineArgs.Contains("/S") Or My.Application.CommandLineArgs.Contains("/SILENT") Then
            Await Task.Delay(1)
            Hide()
            Print("SILENT Install")
            Install(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "MAP"), Not (My.Application.CommandLineArgs.Contains("/R") Or My.Application.CommandLineArgs.Contains("/NOREGISTERY")), Not (My.Application.CommandLineArgs.Contains("/L") Or My.Application.CommandLineArgs.Contains("/NOLINKS")))
            While Not IO.File.Exists(PathTextBox.Text & "\MAP.exe")
                MsgBox(PathTextBox.Text & "\MAP.exe | " & IO.File.Exists(PathTextBox.Text & "\MAP.exe"))
            End While
            Close()
        End If
        If My.Application.CommandLineArgs.Contains("/H") Or My.Application.CommandLineArgs.Contains("/?") Or My.Application.CommandLineArgs.Contains("/HELP") Then
            mode = 1
            MsgBox("MAP Setup HELP :
-------------------
/S : Silent Install.
/U : Silent Uninstall.
/R : Don't add the programm to the registery.
/L : Don't add shortcuts on the Desktop.
/D ""path"" : Change the installation path.")
            Close()
        End If
        If My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", True) Is Nothing Then
            InstallPanel.Visible = True
        Else
            mode = 1
            UninstallPanel.Visible = True
            If My.Application.CommandLineArgs.Contains("/U") Or My.Application.CommandLineArgs.Contains("/UNINSTALL") Then
                Await Task.Delay(1)
                Hide()
                Print("SILENT Uninstall")
                Uninstall(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "MAP"))
            End If
        End If
    End Sub
    Sub Install(path As String, AddInRegistery As Boolean, AddShortcuts As Boolean, Optional context As TaskScheduler = Nothing)
        Print("Force Closing MAP...", context)

        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "MAP" Then
                prog.Kill()
                prog.WaitForExit()
                Print("Killed Process!", context)
            End If
        Next

        Print("Installing...", context)
        Dim tmp_path = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "MAPSetup.zip")

        If IO.File.Exists(tmp_path) Then
            Print("Deleting old MAP installation files...", context)
            IO.File.Delete(tmp_path)
        End If

        Print("Copying MAP...", context)
        IO.File.WriteAllBytes(tmp_path, My.Resources.MAPzip)
        'Print("Creating Directory...", context)
        'Dim path_part = ""
        'For Each x In IO.Path.GetFullPath(path).Split(IO.Path.DirectorySeparatorChar)
        ' path_part &= IO.Path.DirectorySeparatorChar & x
        'If Not IO.Directory.Exists(x) Then
        'Print("Creating Directory : """ & path_part & """...", context)
        'IO.Directory.CreateDirectory(x)
        'End If
        'Next
        Print("Verifying ...", context)
        For Each x In files_list
            If IO.File.Exists(IO.Path.Combine(path, x)) Then
                Print("Deleting file : """ & IO.Path.Combine(path, x) & """...", context)
                IO.File.Delete(IO.Path.Combine(path, x))
            End If
        Next
        Print("Exctracting MAP...", context)
        IO.Compression.ZipFile.ExtractToDirectory(tmp_path, path)
        Print("Deleting MAP installation files...", context)
        IO.File.Delete(tmp_path)
        If AddInRegistery Then
            Print("Adding MAP to Registery...", context)
            With My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall", True)

                Dim MAPKey As Microsoft.Win32.RegistryKey = Nothing
                If My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", True) Is Nothing Then
                    MAPKey = .CreateSubKey("MAP")
                Else
                    MAPKey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", True)
                End If
                MAPKey.SetValue("DisplayName", "MAP", Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("DisplayVersion", version, Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("DisplayIcon", IO.Path.Combine(IO.Path.GetFullPath(path), "MAP.exe"), Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("Publisher", "Piripe", Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("UninstallString", IO.Path.Combine(IO.Path.GetFullPath(path), "Uninstall.exe"), Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("UninstallPath", IO.Path.Combine(IO.Path.GetFullPath(path), "Uninstall.exe"), Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("InstallLocation", IO.Path.GetFullPath(path), Microsoft.Win32.RegistryValueKind.String)
                MAPKey.SetValue("EstimatedSize", DirectorySize(path, True) / 1024, Microsoft.Win32.RegistryValueKind.DWord)
            End With
        End If
        If Not IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) & "\MAP.lnk") Then
            Print("Adding MAP to the Start Menu...", context)
            Dim oShell As Object
            Dim oLink As Object
            Try
                oShell = CreateObject("WScript.Shell")
                oLink = oShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) & "\MAP.lnk")

                oLink.TargetPath = IO.Path.Combine(IO.Path.GetFullPath(path), "MAP.exe")
                oLink.WorkingDirectory = IO.Path.GetFullPath(path)
                oLink.WindowStyle = 1
                oLink.Save()
            Catch
                MsgBox("Can't add MAP to the Start Menu.")
            End Try
        End If
        If AddShortcuts Then
            If Not IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) & "\MAP.lnk") Then
                Print("Adding MAP on the Desktop...", context)
                Dim oShell As Object
                Dim oLink As Object
                Try
                    oShell = CreateObject("WScript.Shell")
                    oLink = oShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\MAP.lnk")

                    oLink.TargetPath = IO.Path.Combine(IO.Path.GetFullPath(path), "MAP.exe")
                    oLink.WorkingDirectory = IO.Path.GetFullPath(path)
                    oLink.WindowStyle = 1
                    oLink.Save()
                Catch
                    MsgBox("Can't add MAP on the Desktop.")
                End Try
            End If
        End If
        Print("Installed", context)
        If context IsNot Nothing Then
            Task.Factory.StartNew(Sub() CloseButton.Visible = True, Threading.CancellationToken.None, TaskCreationOptions.None, context)
            Task.Factory.StartNew(Sub() RunMAPCheckBox.Visible = True, Threading.CancellationToken.None, TaskCreationOptions.None, context)
        End If
    End Sub
    Sub Uninstall(path As String, Optional context As TaskScheduler = Nothing)
        Print("Force Closing MAP...", context)

        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "MAP" Then
                prog.Kill()
                prog.WaitForExit()
                Print("Killed Process!", context)
            End If
        Next

        Print("Uninstalling...", context)

        Print("Deleting Directory...", context)

        With My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall", True)
            Dim MAPKey As Microsoft.Win32.RegistryKey = Nothing
            If My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", True) IsNot Nothing Then
                MAPKey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\MAP", True)
                If IO.Directory.Exists(MAPKey.GetValue("InstallLocation", path)) Then IO.Directory.Delete(IO.Path.GetFullPath(MAPKey.GetValue("InstallLocation", path)), True)
                Print("Removing MAP from the Registery...", context)
                .DeleteSubKey("MAP")
            End If
        End With
        Print("Uninstalled", context)
        If context IsNot Nothing Then
            Task.Factory.StartNew(Sub() CloseButton.Visible = True, Threading.CancellationToken.None, TaskCreationOptions.None, context)
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As EventArgs) Handles LinkLabel1.LinkClicked, PictureBox2.Click
        Process.Start("http://creativecommons.org/licenses/by-nd/4.0/")
    End Sub
    Private Overloads Function DirectorySize(ByVal sPath As String, ByVal bRecursive As Boolean) As Long

        Dim Size As Long = 0
        Dim diDir As New IO.DirectoryInfo(sPath)

        Try

            Dim fil As IO.FileInfo

            For Each fil In diDir.GetFiles()

                Size += fil.Length

            Next fil

            If bRecursive = True Then
                Dim diSubDir As IO.DirectoryInfo
                Dim lngNumberOfDirectories = 0
                For Each diSubDir In diDir.GetDirectories()
                    Size += DirectorySize(diSubDir.FullName, True)
                    lngNumberOfDirectories += 1
                Next diSubDir
            End If
            Return Size
        Catch ex As System.IO.FileNotFoundException
            ' File not found. Take no action
            Return 0
        Catch exx As Exception
            ' Another error occurred
            Return 0
        End Try
    End Function
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            InstallButton.FlatAppearance.BorderColor = Color.White
            InstallButton.FlatAppearance.BorderSize = 2
            InstallButton.Enabled = True
        Else
            InstallButton.FlatAppearance.BorderColor = Color.Silver
            InstallButton.FlatAppearance.BorderSize = 1
            InstallButton.Enabled = False
        End If
    End Sub

    Private Sub InstallButton_Click(sender As Object, e As EventArgs) Handles InstallButton.Click
        Dim context As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext
        LoadingPanel.Visible = True
        Task.Run(Sub() Install(PathTextBox.Text, Not (My.Application.CommandLineArgs.Contains("/R") Or My.Application.CommandLineArgs.Contains("/NOREGISTERY")), AddDesktopCheckBox.Checked, context))
    End Sub
    Sub Print(str As String, Optional context As TaskScheduler = Nothing)
        Console.WriteLine(Date.Now.ToString("[HH:mm:ss] ") & str)
        If context IsNot Nothing Then
            Task.Factory.StartNew(Sub() LoadingLabel.Text = str, Threading.CancellationToken.None, TaskCreationOptions.None, context)
        End If
    End Sub

    Private Sub SelectPathButton_Click(sender As Object, e As EventArgs) Handles SelectPathButton.Click
        Dim path_dlg As New FolderBrowserDialog()
        path_dlg.SelectedPath = PathTextBox.Text
        If path_dlg.ShowDialog = DialogResult.OK Then
            PathTextBox.Text = path_dlg.SelectedPath
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub UninstallPanel_Resize(sender As Object, e As EventArgs) Handles UninstallPanel.Resize
        If UninstallPanel.Visible Then
            UninstallButton.Location = New Point((UninstallPanel.Size.Width - 144) / 2, (Size.Height - 49) / 2 - 90)
        End If
    End Sub

    Private Sub UninstallButton_Click(sender As Object, e As EventArgs) Handles UninstallButton.Click
        Dim context As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext
        LoadingPanel.Visible = True
        Task.Run(Sub() Uninstall(PathTextBox.Text, context))
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub Setup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If RunMAPCheckBox.Checked And mode = 0 Then
            Dim SI = New ProcessStartInfo(PathTextBox.Text & "\MAP.exe")
            SI.WorkingDirectory = PathTextBox.Text
            Process.Start(SI)
        End If
    End Sub
End Class
