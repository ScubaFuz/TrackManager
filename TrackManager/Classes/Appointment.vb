Public Class Appointment
    Private _Name As String = ""
    Private _ID As Integer = 0

    Private _Day As Date = Today
    Private _Time As DateTime = Now.Hour & ":" & Now.Minute
    Private _TrackID As Integer = 0
    Private _TrackName As String = Nothing
    Private _TrackIndex As Integer = 0

    Private _DayPrev As Date = Today
    Private _TimePrev As DateTime = Now.Hour & ":" & Now.Minute
    Private _TrackIDPrev As Integer = 0
    Private _TrackIndexPrev As Integer = 0

    Private mClients As New Clients

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Public Property Day() As Date
        Get
            Return _Day
        End Get
        Set(ByVal value As Date)
            _Day = value
        End Set
    End Property

    Public Property Time() As DateTime
        Get
            Return _Time
        End Get
        Set(ByVal value As DateTime)
            _Time = value
        End Set
    End Property

    Public Property TrackId() As Integer
        Get
            Return _TrackID
        End Get
        Set(ByVal value As Integer)
            _TrackID = value
        End Set
    End Property

    Public Property TrackName() As String
        Get
            Return _TrackName
        End Get
        Set(ByVal value As String)
            _TrackName = value
        End Set
    End Property

    Public Property TrackIndex() As Integer
        Get
            Return _TrackIndex
        End Get
        Set(ByVal value As Integer)
            _TrackIndex = value
        End Set
    End Property

    Public Property DayPrev() As Date
        Get
            Return _DayPrev
        End Get
        Set(ByVal value As Date)
            _DayPrev = value
        End Set
    End Property

    Public Property TimePrev() As DateTime
        Get
            Return _TimePrev
        End Get
        Set(ByVal value As DateTime)
            _TimePrev = value
        End Set
    End Property

    Public Property TrackIdPrev() As Integer
        Get
            Return _TrackIDPrev
        End Get
        Set(ByVal value As Integer)
            _TrackIDPrev = value
        End Set
    End Property

    Public Property TrackIndexPrev() As Integer
        Get
            Return _TrackIndexPrev
        End Get
        Set(ByVal value As Integer)
            _TrackIndexPrev = value
        End Set
    End Property

    Friend ReadOnly Property Clients() As Clients
        Get
            Clients = mClients
        End Get
    End Property

End Class
