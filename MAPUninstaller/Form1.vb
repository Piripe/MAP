Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim context As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext
        Task.Run(Sub() Uninstall(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "MAP"), context))
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
    Sub Print(str As String, Optional context As TaskScheduler = Nothing)
        Console.WriteLine(Date.Now.ToString("[HH:mm:ss] ") & str)
        If context IsNot Nothing Then
            Task.Factory.StartNew(Sub() LoadingLabel.Text = str, Threading.CancellationToken.None, TaskCreationOptions.None, context)
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub
End Class
