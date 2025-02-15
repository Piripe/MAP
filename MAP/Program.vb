Module Program
    <Obsolete>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        AppDomain.CurrentDomain.AppendPrivatePath("lib")
        Application.Run(New OverlayGestion)
    End Sub
End Module
