Public Class ColHeader
    Inherits System.Windows.Forms.ColumnHeader

        Friend ascending As Boolean

        Friend Sub New(ByVal [text] As String, ByVal [name] As String, ByVal width As Integer, ByVal align As HorizontalAlignment, ByVal asc As Boolean)
            Me.Text = [text]
            Me.Name = [name]
            Me.Tag = [name]
            Me.Width = width
            Me.TextAlign = align
            Me.ascending = asc
        End Sub
End Class
