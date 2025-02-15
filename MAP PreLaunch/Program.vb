Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("MAP Prelaunch...")
        Console.WriteLine("Create Overlay directory...")
        IO.Directory.CreateDirectory("../../../../MAP/bin/Debug/overlays")
        Console.WriteLine("Delete MusicFrequenciesOverlay...")
        IO.File.Delete("../../../../MAP/bin/Debug/overlays/MusicFrequenciesOverlay.exe")
        Console.WriteLine("Copy MusicFrequenciesOverlay...")
        IO.File.Copy("../../../../MusicFrequenciesOverlay/bin/Debug/MusicFrequenciesOverlay.exe", "../../../../MAP/bin/Debug/overlays/MusicFrequenciesOverlay.exe")
    End Sub
End Module
