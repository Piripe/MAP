Public Class Project
    Private _LastChange As Date = Date.Now
    Private WithEvents _Elements As ProjectElementCollection

    ReadOnly Property LastChange
        Get
            Return New TimeSpan(Date.Now.Ticks - _LastChange.Ticks).TotalSeconds
        End Get
    End Property
    Property Elements As ProjectElementCollection

        Get
            Return _Elements
        End Get
        Set
            _Elements = Value
        End Set
    End Property
    Sub ElementsChanged() Handles _Elements.ElementsChanged

    End Sub
#Region "OtherClasses"
    Interface IProjectElement

    End Interface
    Public Class ProjectElementCollection
        Private List As New List(Of IProjectElement)
        Event ElementsChanged()
        Sub Add(element As IProjectElement)
            List.Add(element)
            RaiseEvent ElementsChanged()
        End Sub
        Sub Remove(element As IProjectElement)
            List.Remove(element)
            RaiseEvent ElementsChanged()
        End Sub
        Sub RemoveAt(index As Int32)
            List.RemoveAt(index)
            RaiseEvent ElementsChanged()
        End Sub
        Function ElementAt(index As Int32) As IProjectElement
            Return List(index)
        End Function
        Function IndexOf(element As IProjectElement) As Int32
            Return List.IndexOf(element)
        End Function
    End Class
#End Region

End Class
