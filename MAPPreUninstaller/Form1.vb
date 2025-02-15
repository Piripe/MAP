Public Class Form1
    Private Sub UninstallPanel_Resize(sender As Object, e As EventArgs) Handles UninstallPanel.Resize
        UninstallButton.Location = New Point((UninstallPanel.Size.Width - 144) / 2, (Size.Height - 49) / 2 - 90)
    End Sub

    Private Sub UninstallButton_Click(sender As Object, e As EventArgs) Handles UninstallButton.Click
        IO.File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUninstaller.exe", My.Resources.MAPUninstaller)
        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "/MAPUninstaller.exe")
        Close()
    End Sub
End Class
