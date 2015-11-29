Public Class Variables

#Region "General"
    Private _DeleteEmptyInvoice As Boolean = True
    Private _SelectMultipleGroups As Boolean = True
    Private _InvoiceName As String = ""
    Private _InvoiceNumber As Integer = 1

    Private _OverbookWarning As Integer = 0
    Private _ShowAllLessonTypes As Boolean = False
    Private _RequireLessontype As Boolean = True

    Public Property DeleteEmptyInvoice() As Boolean
        Get
            Return _DeleteEmptyInvoice
        End Get
        Set(ByVal Value As Boolean)
            _DeleteEmptyInvoice = Value
        End Set
    End Property

    Public Property SelectMultipleGroups() As Boolean
        Get
            Return _SelectMultipleGroups
        End Get
        Set(ByVal Value As Boolean)
            _SelectMultipleGroups = Value
        End Set
    End Property

    Public Property InvoiceName() As String
        Get
            Return _InvoiceName
        End Get
        Set(ByVal Value As String)
            _InvoiceName = Value
        End Set
    End Property

    Public Property InvoiceNumber() As Integer
        Get
            Return _InvoiceNumber
        End Get
        Set(ByVal Value As Integer)
            _InvoiceNumber = Value
        End Set
    End Property

    Public Property OverbookWarning() As Integer
        Get
            Return _OverbookWarning
        End Get
        Set(ByVal Value As Integer)
            _OverbookWarning = Value
        End Set
    End Property

    Public Property ShowAllLessonTypes() As Boolean
        Get
            Return _ShowAllLessonTypes
        End Get
        Set(ByVal Value As Boolean)
            _ShowAllLessonTypes = Value
        End Set
    End Property

    Public Property RequireLessontype() As Boolean
        Get
            Return _RequireLessontype
        End Get
        Set(ByVal Value As Boolean)
            _RequireLessontype = Value
        End Set
    End Property

#End Region

#Region "Interface"
    Private _ApplicationName As String = "TrackManager"

    Private _TrackBoxWidth As Integer = 50
    Private _TrackBoxHeight As Integer = 1
    Private _ClientsPerTrack As Integer = 4
    Private _TeachersPerTrack As Integer = 1
    Private _BarsPerTrack As Integer = 1
    Private _ClientsPerGroup As Integer = 4
    Private _OpeningHour As Integer = 600
    'Private _OpeningHours As Date = Today
    Private _ClosingHour As Integer = 1320
    'Private _ClosingHours As Date = Today
    Private _TimeFrame As Integer = 60
    Private _BuildMargin As Integer = 5
    Private _PayLines As Integer = 4
    Private _ShowTeacher As Boolean = True
    Private _ShowOffHours As Boolean = False
    Private _Language As String = "EN"
    Private _ShowTimeWithTrack As Boolean = False
    Private _UseFadingColors As Boolean = False

    Private _SeasonStart As Date = Today
    Private _SeasonLength As String = "Year"
    Private _SeasonMonths As Integer = 0
    Private _SeasonEnd As Date = Today.AddMonths(12)
    Private _LogDelete As String = ""
    Private _LogDeleteAuto As Boolean = False
    Private _DeleteMax1Client As Boolean = True

    Private _ShowAge As Boolean = False
    Private _ShowAgeAfter As Boolean = False
    Private _ShowAgeMax As Integer = 10
    Private _ShowMoney As Integer = 0
    Private _ShowLastAppointment As Boolean = False

    Private _DateFormat As String = "yyyy-mm-dd"

    Public Property ApplicationName() As String
        Get
            Return _ApplicationName
        End Get
        Set(ByVal Value As String)
            _ApplicationName = Value
        End Set
    End Property

    Public Property TrackBoxWidth() As Integer
        Get
            Return _TrackBoxWidth
        End Get
        Set(ByVal Value As Integer)
            _TrackBoxWidth = Value
        End Set
    End Property

    Public Property TrackBoxHeight() As Integer
        Get
            Return _TrackBoxHeight
        End Get
        Set(ByVal Value As Integer)
            _TrackBoxHeight = Value
        End Set
    End Property

    Public Property ClientsPerTrack() As Integer
        Get
            Return _ClientsPerTrack
        End Get
        Set(ByVal Value As Integer)
            _ClientsPerTrack = Value
        End Set
    End Property

    Public Property TeachersPerTrack() As Integer
        Get
            Return _TeachersPerTrack
        End Get
        Set(ByVal Value As Integer)
            _TeachersPerTrack = Value
        End Set
    End Property

    Public Property BarsPerTrack() As Integer
        Get
            Return _BarsPerTrack
        End Get
        Set(ByVal Value As Integer)
            _BarsPerTrack = Value
        End Set
    End Property

    Public Property ClientsPerGroup() As Integer
        Get
            Return _ClientsPerGroup
        End Get
        Set(ByVal Value As Integer)
            _ClientsPerGroup = Value
        End Set
    End Property

    Public Property OpeningHour() As Integer
        Get
            Return _OpeningHour
        End Get
        Set(ByVal Value As Integer)
            _OpeningHour = Value
        End Set
    End Property

    'Public Property OpeningHours() As Date
    '    Get
    '        Return _OpeningHours
    '    End Get
    '    Set(ByVal Value As Date)
    '        _OpeningHours = Value
    '    End Set
    'End Property

    Public Property ClosingHour() As Integer
        Get
            Return _ClosingHour
        End Get
        Set(ByVal Value As Integer)
            _ClosingHour = Value
        End Set
    End Property

    'Public Property ClosingHours() As Date
    '    Get
    '        Return _ClosingHours
    '    End Get
    '    Set(ByVal Value As Date)
    '        _ClosingHours = Value
    '    End Set
    'End Property

    Public Property TimeFrame() As Integer
        Get
            Return _TimeFrame
        End Get
        Set(ByVal Value As Integer)
            _TimeFrame = Value
        End Set
    End Property

    Public Property BuildMargin() As Integer
        Get
            Return _BuildMargin
        End Get
        Set(ByVal Value As Integer)
            _BuildMargin = Value
        End Set
    End Property

    Public Property PayLines() As Integer
        Get
            Return _PayLines
        End Get
        Set(ByVal Value As Integer)
            _PayLines = Value
        End Set
    End Property

    Public Property ShowTeacher() As Boolean
        Get
            Return _ShowTeacher
        End Get
        Set(ByVal Value As Boolean)
            _ShowTeacher = Value
        End Set
    End Property

    Public Property ShowOffHours() As Boolean
        Get
            Return _ShowOffHours
        End Get
        Set(ByVal Value As Boolean)
            _ShowOffHours = Value
        End Set
    End Property

    Public Property Language() As String
        Get
            Return _Language
        End Get
        Set(ByVal Value As String)
            _Language = Value
        End Set
    End Property

    Public Property ShowTimeWithTrack() As Boolean
        Get
            Return _ShowTimeWithTrack
        End Get
        Set(ByVal Value As Boolean)
            _ShowTimeWithTrack = Value
        End Set
    End Property

    Public Property UseFadingColors() As Boolean
        Get
            Return _UseFadingColors
        End Get
        Set(ByVal Value As Boolean)
            _UseFadingColors = Value
        End Set
    End Property

    Public Property SeasonStart() As Date
        Get
            Return _SeasonStart
        End Get
        Set(ByVal Value As Date)
            _SeasonStart = Value
        End Set
    End Property

    Public Property SeasonLength() As String
        Get
            Return _SeasonLength
        End Get
        Set(ByVal Value As String)
            _SeasonLength = Value
        End Set
    End Property

    Public Property SeasonMonths() As Integer
        Get
            Return _SeasonMonths
        End Get
        Set(ByVal Value As Integer)
            _SeasonMonths = Value
        End Set
    End Property

    Public Property SeasonEnd() As Date
        Get
            Return _SeasonEnd
        End Get
        Set(ByVal Value As Date)
            _SeasonEnd = Value
        End Set
    End Property

    Public Property LogDelete() As String
        Get
            Return _LogDelete
        End Get
        Set(ByVal Value As String)
            _LogDelete = Value
        End Set
    End Property

    Public Property LogDeleteAuto() As Boolean
        Get
            Return _LogDeleteAuto
        End Get
        Set(ByVal Value As Boolean)
            _LogDeleteAuto = Value
        End Set
    End Property

    Public Property DeleteMax1Client() As Boolean
        Get
            Return _DeleteMax1Client
        End Get
        Set(ByVal Value As Boolean)
            _DeleteMax1Client = Value
        End Set
    End Property

    Public Property ShowAge() As Boolean
        Get
            Return _ShowAge
        End Get
        Set(ByVal Value As Boolean)
            _ShowAge = Value
        End Set
    End Property

    Public Property ShowAgeAfter() As Boolean
        Get
            Return _ShowAgeAfter
        End Get
        Set(ByVal Value As Boolean)
            _ShowAgeAfter = Value
        End Set
    End Property

    Public Property ShowAgeMax() As Integer
        Get
            Return _ShowAgeMax
        End Get
        Set(ByVal Value As Integer)
            _ShowAgeMax = Value
        End Set
    End Property

    Public Property ShowMoney() As Integer
        Get
            Return _ShowMoney
        End Get
        Set(ByVal Value As Integer)
            _ShowMoney = Value
        End Set
    End Property

    Public Property ShowLastAppointment() As Boolean
        Get
            Return _ShowLastAppointment
        End Get
        Set(ByVal Value As Boolean)
            _ShowLastAppointment = Value
        End Set
    End Property

    Public Property DateFormat() As String
        Get
            Return _DateFormat
        End Get
        Set(ByVal Value As String)
            _DateFormat = Value
        End Set
    End Property

#End Region

#Region "Screen"
    Private _ScreenName As String
	Private _ScreenTop As Integer = 32
	Private _ScreenLeft As Integer = 32
	Private _ScreenWidth As Integer = 950
	Private _ScreenHeight As Integer = 720
    Private _ScreenState As Integer = 0
    Private _CallSplash As Boolean = False

    Private _btnAppRemoveSortOrder As Integer = 1
    Private _btnAppCreateSortOrder As Integer = 2
    Private _btnAppMoveSortOrder As Integer = 3
    Private _btnAppDeleteSortOrder As Integer = 4
    Private _btnAppClearSortOrder As Integer = 5

	Public Property ScreenName() As String
		Get
			Return _ScreenName
		End Get
		Set(ByVal Value As String)
			_ScreenName = Value
		End Set
	End Property

	Public Property ScreenTop() As Integer
		Get
			Return _ScreenTop
		End Get
		Set(ByVal Value As Integer)
			_ScreenTop = Value
		End Set
	End Property

	Public Property ScreenLeft() As Integer
		Get
			Return _ScreenLeft
		End Get
		Set(ByVal Value As Integer)
			_ScreenLeft = Value
		End Set
	End Property

	Public Property ScreenWidth() As Integer
		Get
			Return _ScreenWidth
		End Get
		Set(ByVal Value As Integer)
			_ScreenWidth = Value
		End Set
	End Property

	Public Property ScreenHeight() As Integer
		Get
			Return _ScreenHeight
		End Get
		Set(ByVal Value As Integer)
			_ScreenHeight = Value
		End Set
	End Property

	Public Property ScreenState() As Integer
		Get
			Return _ScreenState
		End Get
		Set(ByVal Value As Integer)
			_ScreenState = Value
		End Set
	End Property

    Public Property CallSplash() As Boolean
        Get
            Return _CallSplash
        End Get
        Set(ByVal Value As Boolean)
            _CallSplash = Value
        End Set
    End Property

    Public Property btnAppRemoveSortOrder() As Integer
        Get
            Return _btnAppRemoveSortOrder
        End Get
        Set(ByVal Value As Integer)
            _btnAppRemoveSortOrder = Value
        End Set
    End Property

    Public Property btnAppCreateSortOrder() As Integer
        Get
            Return _btnAppCreateSortOrder
        End Get
        Set(ByVal Value As Integer)
            _btnAppCreateSortOrder = Value
        End Set
    End Property

    Public Property btnAppMoveSortOrder() As Integer
        Get
            Return _btnAppMoveSortOrder
        End Get
        Set(ByVal Value As Integer)
            _btnAppMoveSortOrder = Value
        End Set
    End Property

    Public Property btnAppDeleteSortOrder() As Integer
        Get
            Return _btnAppDeleteSortOrder
        End Get
        Set(ByVal Value As Integer)
            _btnAppDeleteSortOrder = Value
        End Set
    End Property

    Public Property btnAppClearSortOrder() As Integer
        Get
            Return _btnAppClearSortOrder
        End Get
        Set(ByVal Value As Integer)
            _btnAppClearSortOrder = Value
        End Set
    End Property

#End Region

#Region "Colors"
	Private _OnHoursColor As System.Drawing.Color = System.Drawing.Color.White
    Private _OffHoursColor As System.Drawing.Color = System.Drawing.Color.LightGray
	Private _DisabledColor As System.Drawing.Color = System.Drawing.Color.LightYellow
	Private _ReadOnlyBackcolor As System.Drawing.Color = System.Drawing.Color.WhiteSmoke
	Private _ChangedColor As System.Drawing.Color = System.Drawing.Color.IndianRed
    Private _ChangedTextColor As System.Drawing.Color = System.Drawing.Color.LightBlue
    Private _BaseColor As System.Drawing.Color = System.Drawing.SystemColors.Control
    Private _SelectedColor As System.Drawing.Color = System.Drawing.Color.LightSkyBlue
    Private _UnSelectedColor As System.Drawing.Color = System.Drawing.SystemColors.Window

	Public Property OnHoursColor() As System.Drawing.Color
		Get
			Return _OnHoursColor
		End Get
		Set(ByVal Value As System.Drawing.Color)
			_OnHoursColor = Value
		End Set
	End Property

	Public Property OffHoursColor() As System.Drawing.Color
		Get
			Return _OffHoursColor
		End Get
		Set(ByVal Value As System.Drawing.Color)
			_OffHoursColor = Value
		End Set
	End Property

	Public Property DisabledColor() As System.Drawing.Color
		Get
			Return _DisabledColor
		End Get
		Set(ByVal Value As System.Drawing.Color)
			_DisabledColor = Value
		End Set
	End Property

	Public Property ReadOnlyBackColor() As System.Drawing.Color
		Get
			Return _ReadOnlyBackcolor
		End Get
		Set(ByVal Value As System.Drawing.Color)
			_ReadOnlyBackcolor = Value
		End Set
	End Property

	Public Property ChangedColor() As System.Drawing.Color
		Get
			Return _ChangedColor
		End Get
		Set(ByVal Value As System.Drawing.Color)
			_ChangedColor = Value
		End Set
	End Property

    Public Property ChangedTextColor() As System.Drawing.Color
        Get
            Return _ChangedTextColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _ChangedTextColor = Value
        End Set
    End Property

    Public Property BaseColor() As System.Drawing.Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _BaseColor = Value
        End Set
    End Property

    Public Property SelectedColor() As System.Drawing.Color
        Get
            Return _SelectedColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _SelectedColor = Value
        End Set
    End Property

    Public Property UnSelectedColor() As System.Drawing.Color
        Get
            Return _UnSelectedColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _UnSelectedColor = Value
        End Set
    End Property

#End Region

#Region "Email"
    Private _EmailMethod As String = ""
    Private _SmtpServer As String = ""
    Private _SmtpCredentials As Boolean = 1
    Private _SmtpUser As String = ""
    Private _SmtpPassword As String = ""
    Private _SmtpReply As String = ""
    Private _SmtpSsl As Boolean = 1
    Private _SmtpPort As Integer = 25

    Public Property EmailMethod() As String
        Get
            Return _EmailMethod
        End Get
        Set(ByVal Value As String)
            _EmailMethod = Value
        End Set
    End Property

    Public Property SmtpServer() As String
        Get
            Return _SmtpServer
        End Get
        Set(ByVal Value As String)
            _SmtpServer = Value
        End Set
    End Property

    Public Property SmtpCredentials() As Boolean
        Get
            Return _SmtpCredentials
        End Get
        Set(ByVal Value As Boolean)
            _SmtpCredentials = Value
        End Set
    End Property

    Public Property SmtpUser() As String
        Get
            Return _SmtpUser
        End Get
        Set(ByVal Value As String)
            _SmtpUser = Value
        End Set
    End Property

    Public Property SmtpPassword() As String
        Get
            Return _SmtpPassword
        End Get
        Set(ByVal Value As String)
            _SmtpPassword = Value
        End Set
    End Property

    Public Property SmtpReply() As String
        Get
            Return _SmtpReply
        End Get
        Set(ByVal Value As String)
            _SmtpReply = Value
        End Set
    End Property

    Public Property SmtpSsl() As Boolean
        Get
            Return _SmtpSsl
        End Get
        Set(ByVal Value As Boolean)
            _SmtpSsl = Value
        End Set
    End Property

    Public Property SmtpPort() As Integer
        Get
            Return _SmtpPort
        End Get
        Set(ByVal Value As Integer)
            _SmtpPort = Value
        End Set
    End Property
#End Region

End Class
