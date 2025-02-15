Imports System.Runtime.CompilerServices
Module GraphicsExtensions

    <Extension()>
    Sub FillRoundedRectangle(g As Graphics, brush As Drawing.Brush, rect As Rectangle, RoundLevel As Single)
        g.FillPath(brush, g.GetRoundedRectangleGraphicPath(rect, RoundLevel))
    End Sub
    <Extension()>
    Sub SetClipAsRoundedRectangle(g As Graphics, rect As Rectangle, RoundLevel As Single)
        g.SetClip(g.GetRoundedRectangleGraphicPath(rect, RoundLevel))
    End Sub
    <Extension()>
    Function GetRoundedRectangleGraphicPath(g As Graphics, rect As Rectangle, RoundLevel As Single) As Drawing2D.GraphicsPath
        Dim graphicPath As New Drawing2D.GraphicsPath
        graphicPath.FillMode = Drawing2D.FillMode.Winding
        graphicPath.AddEllipse(New Rectangle(rect.X, rect.Y + 0.5, RoundLevel, RoundLevel))
        graphicPath.AddEllipse(New Rectangle(rect.X + rect.Width - RoundLevel, rect.Y + 0.5, RoundLevel, RoundLevel))
        graphicPath.AddEllipse(New Rectangle(rect.X + rect.Width - RoundLevel, rect.Y + rect.Height - RoundLevel - 0.5, RoundLevel, RoundLevel))
        graphicPath.AddEllipse(New Rectangle(rect.X, rect.Y + rect.Height - RoundLevel - 0.5, RoundLevel, RoundLevel))
        graphicPath.AddRectangle(New Rectangle(rect.X + RoundLevel / 2, rect.Y, rect.Width - RoundLevel, rect.Height))
        graphicPath.AddRectangle(New Rectangle(rect.X, rect.Y + RoundLevel / 2, rect.Width, rect.Height - RoundLevel))
        Return graphicPath
    End Function

End Module
