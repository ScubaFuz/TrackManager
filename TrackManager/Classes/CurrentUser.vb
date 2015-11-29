Public Class CurrentUser

	Private _LoginID As Integer = 0
	Private _LoginName As String = "NoLogin"
	Private _Password As String = ""
	Private _LogonTime As DateTime = Now
	Private _DateStart As DateTime = Today.AddDays(1)
	Private _DateStop As DateTime = Today.AddDays(-1)
	Private _Enabled As Boolean = False
	Private _SecurityAdd As Boolean = False
	Private _SecurityChange As Boolean = False
	Private _SecurityDelete As Boolean = False
	Private _FinanceAdd As Boolean = False
	Private _FinanceChange As Boolean = False
	Private _FinanceDelete As Boolean = False
	Private _SettingsAdd As Boolean = False
	Private _SettingsChange As Boolean = False
	Private _SettingsDelete As Boolean = False
	Private _GroupsDelete As Boolean = False
	Private _ClientsDelete As Boolean = False


	Public Property LoginID() As Integer
		Get
			Return _LoginID
		End Get
		Set(ByVal Value As Integer)
			_LoginID = Value
		End Set
	End Property

	Public Property LoginName() As String
		Get
			Return _LoginName
		End Get
		Set(ByVal Value As String)
			_LoginName = Value
		End Set
	End Property

	Public Property Password() As String
		Get
			Return _Password
		End Get
		Set(ByVal Value As String)
			_Password = Value
		End Set
	End Property

	Public Property LogonTime() As DateTime
		Get
			Return _LogonTime
		End Get
		Set(ByVal Value As DateTime)
			_LogonTime = Value
		End Set
	End Property

	Public Property DateStart() As DateTime
		Get
			Return _DateStart
		End Get
		Set(ByVal Value As DateTime)
			_DateStart = Value
		End Set
	End Property

	Public Property DateStop() As DateTime
		Get
			Return _DateStop
		End Get
		Set(ByVal Value As DateTime)
			_DateStop = Value
		End Set
	End Property

	Public Property Enabled() As Boolean
		Get
			Return _Enabled
		End Get
		Set(ByVal Value As Boolean)
			_Enabled = Value
		End Set
	End Property

	Public Property SecurityAdd() As Boolean
		Get
			Return _SecurityAdd
		End Get
		Set(ByVal Value As Boolean)
			_SecurityAdd = Value
		End Set
	End Property

	Public Property SecurityChange() As Boolean
		Get
			Return _SecurityChange
		End Get
		Set(ByVal Value As Boolean)
			_SecurityChange = Value
		End Set
	End Property

	Public Property SecurityDelete() As Boolean
		Get
			Return _SecurityDelete
		End Get
		Set(ByVal Value As Boolean)
			_SecurityDelete = Value
		End Set
	End Property

	Public Property FinanceAdd() As Boolean
		Get
			Return _FinanceAdd
		End Get
		Set(ByVal Value As Boolean)
			_FinanceAdd = Value
		End Set
	End Property

	Public Property FinanceChange() As Boolean
		Get
			Return _FinanceChange
		End Get
		Set(ByVal Value As Boolean)
			_FinanceChange = Value
		End Set
	End Property

	Public Property FinanceDelete() As Boolean
		Get
			Return _FinanceDelete
		End Get
		Set(ByVal Value As Boolean)
			_FinanceDelete = Value
		End Set
	End Property

	Public Property SettingsAdd() As Boolean
		Get
			Return _SettingsAdd
		End Get
		Set(ByVal Value As Boolean)
			_SettingsAdd = Value
		End Set
	End Property

	Public Property SettingsChange() As Boolean
		Get
			Return _SettingsChange
		End Get
		Set(ByVal Value As Boolean)
			_SettingsChange = Value
		End Set
	End Property

	Public Property SettingsDelete() As Boolean
		Get
			Return _SettingsDelete
		End Get
		Set(ByVal Value As Boolean)
			_SettingsDelete = Value
		End Set
	End Property

	Public Property GroupsDelete() As Boolean
		Get
			Return _GroupsDelete
		End Get
		Set(ByVal Value As Boolean)
			_GroupsDelete = Value
		End Set
	End Property

	Public Property ClientsDelete() As Boolean
		Get
			Return _ClientsDelete
		End Get
		Set(ByVal Value As Boolean)
			_ClientsDelete = Value
		End Set
	End Property
End Class
