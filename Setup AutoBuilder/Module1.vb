Module Module1

    Sub Main()
        Print("MAP Setup Auto-Builder")
        Print("----------------------")
        'Print("Please enter MAP version")
        'Dim x = Console.ReadLine()
        Dim version_txt = IO.File.ReadAllLines("version.txt")
        version_txt(3) += 1
        IO.File.WriteAllLines("version.txt", version_txt)
        Dim x = String.Join(".", version_txt)
        Print("Setup Version : " & x)
        Print("Editing MAP...")
        Dim map_code = IO.File.ReadAllLines("..\..\..\MAP\OverlayGestion.vb")
        map_code(5) = "Public Const Version As String = """ & x & """"
        IO.File.WriteAllLines("..\..\..\MAP\OverlayGestion.vb", map_code)

        Print("Editing MAP Assembly Info...")
        Dim map_assembly = IO.File.ReadAllLines("..\..\..\MAP\My Project\AssemblyInfo.vb").ToList
        map_assembly(map_assembly.FindIndex(Function(y) y.StartsWith("<Assembly: AssemblyVersion"))) = "<Assembly: AssemblyVersion(""" & x & """)>"
        map_assembly(map_assembly.FindIndex(Function(y) y.StartsWith("<Assembly: AssemblyFileVersion"))) = "<Assembly: AssemblyFileVersion(""" & x & """)>"
        IO.File.WriteAllLines("..\..\..\MAP\My Project\AssemblyInfo.vb", map_assembly)
        Print("Rebuilding MAP...")
        Dim SI As New ProcessStartInfo("C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe", "MAP.vbproj -t:rebuild")
        SI.WorkingDirectory = "..\..\..\MAP\"
        Dim Build_process = Process.Start(SI)
        Build_process.WaitForExit()
        Print("Adding MAP to the Setup...")
        Dim zip_setup = IO.Compression.ZipFile.Open("..\..\..\MAPSetup\Resources\MAP v0.2 (in dev).zip", IO.Compression.ZipArchiveMode.Update)
        For Each y In zip_setup.Entries
            If y.Name = "MAP.exe" Then
                y.Delete()
                Exit For
            End If
        Next
        Dim zip_setup_entry = zip_setup.CreateEntry("MAP.exe")
        Dim map_exe = IO.File.ReadAllBytes("..\..\..\MAP\bin\Debug\MAP.exe")
        zip_setup_entry.Open.Write(map_exe, 0, map_exe.Length)
        zip_setup.Dispose()
        Print("Editing MAP Setup...")
        Dim setup_code = IO.File.ReadAllLines("..\..\..\MAPSetup\Setup.vb")
        setup_code(1) = "Const version As String = """ & x & """"
        IO.File.WriteAllLines("..\..\..\MAPSetup\Setup.vb", setup_code)

        Print("Editing MAP Setup Assembly Info...")
        Dim setup_assembly = IO.File.ReadAllLines("..\..\..\MAPSetup\My Project\AssemblyInfo.vb").ToList
        setup_assembly(setup_assembly.FindIndex(Function(y) y.StartsWith("<Assembly: AssemblyVersion"))) = "<Assembly: AssemblyVersion(""" & x & """)>"
        setup_assembly(setup_assembly.FindIndex(Function(y) y.StartsWith("<Assembly: AssemblyFileVersion"))) = "<Assembly: AssemblyFileVersion(""" & x & """)>"
        IO.File.WriteAllLines("..\..\..\MAPSetup\My Project\AssemblyInfo.vb", setup_assembly)
        Print("Rebuilding MAP Setup...")
        SI = New ProcessStartInfo("C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe", "MAPSetup.vbproj -t:rebuild")
        SI.WorkingDirectory = "..\..\..\MAPSetup\"
        Build_process = Process.Start(SI)
        Build_process.WaitForExit()
        Print("Setup re-compiled")
        Print("Open the build directory ? (y/n)")
        x = Console.ReadLine()
        If x = "y" Then
            Process.Start("..\..\..\MAPSetup\bin\Debug\")
        End If
    End Sub

    Sub Print(str As String)
        Console.WriteLine(Date.Now.ToString("[HH:mm:ss] ") & str)
    End Sub
End Module
