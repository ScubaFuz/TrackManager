Public Class Clients
	Inherits System.Collections.CollectionBase

    Public Overloads Sub Add(ByVal dblClientId As Double)
        Dim aNewClient As New Client
        Me.List.Add(aNewClient)
        aNewClient.ID = dblClientId
    End Sub

    Public Overloads Sub Add(ByVal AddClient As Client)
        Me.List.Add(AddClient)
    End Sub

    Public Sub Remove(ByVal removeClient As Client)
        Me.List.Remove(removeClient)
    End Sub

	Default Public Property Item(ByVal index As Double) As Client
		Get
			Return Me.List.Item(index)
		End Get
		Set(ByVal Value As Client)
			Me.List.Item(index) = Value
		End Set
	End Property

End Class
