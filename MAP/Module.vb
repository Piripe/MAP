Public Class OverlayModule
    Interface IOverlayModule
        Sub TickFrame()
        Sub TickMS100()
        Sub TickMS1000()
        Function Save() As XElement
        Sub Load(code As XElement)
        Property Settings As Object
        Property ClientSettings As List(Of Overlay.Setting)
        ReadOnly Property PublicValues As String()
        ReadOnly Property Values As Object()
        ReadOnly Property Id As String
        ReadOnly Property Name As String
        ReadOnly Property Description As String
        ReadOnly Property Icon As Image
    End Interface
End Class
