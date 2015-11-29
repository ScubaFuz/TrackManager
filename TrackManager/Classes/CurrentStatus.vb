Public Class CurrentStatus

	Private _TrackID As Integer = 0
	Private _GroupID As Double = 0
	Private _ClientID As Integer = 0
	Private _InvoiceId As Integer = 0
	Private _ReportId As Integer = 0
	Private _ReportName As String = ""
    Private _ReportType As String = ""
    Private _ReportWidth As Integer = 0

	Private _RefreshGroup As Boolean = False
	Private _RefreshClient As Boolean = False
	Private _ReloadTracks As Boolean = False
	Private _ReloadGroups As Boolean = False
	Private _ReloadClients As Boolean = False
    Private _ReloadFinance As Boolean = False
    Private _ReloadDay As Boolean = False

	Public Property TrackID() As Integer
		Get
			Return _TrackID
		End Get
		Set(ByVal Value As Integer)
			_TrackID = Value
		End Set
	End Property

	Public Property GroupID() As Double
		Get
			Return _GroupID
		End Get
		Set(ByVal Value As Double)
			_GroupID = Value
		End Set
	End Property

	Public Property ClientID() As Integer
		Get
			Return _ClientID
		End Get
		Set(ByVal Value As Integer)
			_ClientID = Value
		End Set
	End Property

	Public Property InvoiceID() As Integer
		Get
			Return _InvoiceId
		End Get
		Set(ByVal Value As Integer)
			_InvoiceId = Value
		End Set
	End Property

	Public Property ReportID() As Integer
		Get
			Return _ReportId
		End Get
		Set(ByVal Value As Integer)
			_ReportId = Value
		End Set
	End Property

	Public Property ReportName() As String
		Get
			Return _ReportName
		End Get
		Set(ByVal Value As String)
			_ReportName = Value
		End Set
	End Property

	Public Property ReportType() As String
		Get
			Return _ReportType
		End Get
		Set(ByVal Value As String)
			_ReportType = Value
		End Set
	End Property

    Public Property ReportWidth() As Integer
        Get
            Return _ReportWidth
        End Get
        Set(ByVal Value As Integer)
            _ReportWidth = Value
        End Set
    End Property

	Public Property RefreshGroup() As Boolean
		Get
			Return _RefreshGroup
		End Get
		Set(ByVal Value As Boolean)
			_RefreshGroup = Value
		End Set
	End Property

	Public Property RefreshClient() As Boolean
		Get
			Return _RefreshClient
		End Get
		Set(ByVal Value As Boolean)
			_RefreshClient = Value
		End Set
	End Property

	Public Property ReloadTracks() As Boolean
		Get
			Return _ReloadTracks
		End Get
		Set(ByVal Value As Boolean)
			_ReloadTracks = Value
		End Set
	End Property

	Public Property ReloadGroups() As Boolean
		Get
			Return _ReloadGroups
		End Get
		Set(ByVal Value As Boolean)
			_ReloadGroups = Value
		End Set
	End Property

	Public Property ReloadClients() As Boolean
		Get
			Return _ReloadClients
		End Get
		Set(ByVal Value As Boolean)
			_ReloadClients = Value
		End Set
	End Property

	Public Property ReloadFinance() As Boolean
		Get
			Return _ReloadFinance
		End Get
		Set(ByVal Value As Boolean)
			_ReloadFinance = Value
		End Set
	End Property

    Public Property ReloadDay() As Boolean
        Get
            Return _ReloadDay
        End Get
        Set(ByVal Value As Boolean)
            _ReloadDay = Value
        End Set
    End Property
End Class
