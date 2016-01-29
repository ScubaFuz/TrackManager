Public Class Language
	Private _strGeneralError As String = "There was an undefined error."
	Private _strCheckLog As String = "Check the logfile for more information."
	Private _strCheckSettings As String = "please check your settings."
	Private _strWarning As String = "Warning"
	Private _strContinue As String = "Do you want to continue?"
	Private _strAreYouSure As String = "Are you sure?"

	Private _strLogError As String = "There were errors connecting to the logfile."
    Private _strDataError As String = "The database was not found. Please check your settings."
    Private _strXmlError As String = "There were errors connecting to the XML datafile."
    Private _strLicenseNotFound As String = "Your license info is not found. Please enter a correct license"
    Private _strLicenseError As String = "Your license info is not correct. Please enter a correct license"
    Private _strLicenseExpired As String = "Your license has expired. Please enter a new license"
    Private _strLicenseValidated As String = "Your license has been validated correctly"

	Private _strPreconfigured As String = "Only preconfigured values are allowed for dropdown lists"
	Private _strNumeric As String = "Only numeric values are allowed"
	Private _strPermanentDelete As String = "This will delete the selected item (and subitems) permanently."
	Private _strDelete1 As String = "You can only delete 1 item at the time."
	Private _strAllData As String = "Please enter all required data before pressing this button"
    Private _strSettingReload As String = "For most of these settings you need to reload TrackManager."
    Private _strLongWait As String = "Due to few selection criteria, this report may take a long time."

    Private _strAll As String = "All"
    Private _strTime As String = "Time"
    Private _strBar As String = "Bar"
	Private _strClient As String = "Client"
    Private _strGroup As String = "Group"
    Private _strTeacher As String = "Teacher"
	Private _strAdd As String = "Add"
	Private _strUpdate As String = "Update"
    Private _strTotal As String = "Total"
	Private _strYes As String = "Yes"
    Private _strNo As String = "No"
    Private _strLanguage As String = "Language"
    Private _strReport As String = "Report"

	Private _strGroupNotEmpty As String = "You can only delete a group that has no client members"
    Private _strDeleteMax1Client As String = "You can only delete one appointment at a time"
    Private _strInvoiceNotEmpty As String = "You can only delete an invoice that has no data"
    Private _strInvoicePayment As String = "You can only delete an invoice that has no payments"
    Private _strWarningDemoData As String = "This will add demo data to your currently active database"
    Private _strUpdateDatabase As String = "There is an update available for your database"
    Private _strEnterEmailAddress As String = "Please enter a valid Email Address"
    Private _strinvalidEmailAddress As String = "The Email Address is not valid"

    Private _strOverbookClient As String = "You are about to overbook a client"
    Private _strMissingLessontype As String = "You need a Lessontype to make this type of appointment"

	Public Property strGeneralError() As String
		Get
			Return _strGeneralError
		End Get
		Set(ByVal value As String)
			_strGeneralError = value
		End Set
	End Property

	Public Property strCheckLog() As String
		Get
			Return _strCheckLog
		End Get
		Set(ByVal value As String)
			_strCheckLog = value
		End Set
	End Property

	Public Property strCheckSettings() As String
		Get
			Return _strCheckSettings
		End Get
		Set(ByVal value As String)
			_strCheckSettings = value
		End Set
	End Property

	Public Property strWarning() As String
		Get
			Return _strWarning
		End Get
		Set(ByVal value As String)
			_strWarning = value
		End Set
	End Property

	Public Property strContinue() As String
		Get
			Return _strContinue
		End Get
		Set(ByVal value As String)
			_strContinue = value
		End Set
	End Property

	Public Property strAreYouSure() As String
		Get
			Return _strAreYouSure
		End Get
		Set(ByVal value As String)
			_strAreYouSure = value
		End Set
	End Property

	Public Property strLogError() As String
		Get
			Return _strLogError
		End Get
		Set(ByVal value As String)
			_strLogError = value
		End Set
	End Property

	Public Property strDataError() As String
		Get
			Return _strDataError
		End Get
		Set(ByVal value As String)
			_strDataError = value
		End Set
	End Property

	Public Property strXmlError() As String
		Get
			Return _strXmlError
		End Get
		Set(ByVal value As String)
			_strXmlError = value
		End Set
	End Property

    Public Property strLicenseNotFound() As String
        Get
            Return _strLicenseNotFound
        End Get
        Set(ByVal value As String)
            _strLicenseNotFound = value
        End Set
    End Property

    Public Property strLicenseError() As String
        Get
            Return _strLicenseError
        End Get
        Set(ByVal value As String)
            _strLicenseError = value
        End Set
    End Property

    Public Property strLicenseExpired() As String
        Get
            Return _strLicenseExpired
        End Get
        Set(ByVal value As String)
            _strLicenseExpired = value
        End Set
    End Property

    Public Property strLicenseValidated() As String
        Get
            Return _strLicenseValidated
        End Get
        Set(ByVal value As String)
            _strLicenseValidated = value
        End Set
    End Property

	Public Property strPreconfigured() As String
		Get
			Return _strPreconfigured
		End Get
		Set(ByVal value As String)
			_strPreconfigured = value
		End Set
	End Property

	Public Property strNumeric() As String
		Get
			Return _strNumeric
		End Get
		Set(ByVal value As String)
			_strNumeric = value
		End Set
	End Property

	Public Property strPermanentDelete() As String
		Get
			Return _strPermanentDelete
		End Get
		Set(ByVal value As String)
			_strPermanentDelete = value
		End Set
	End Property

	Public Property strDelete1() As String
		Get
			Return _strDelete1
		End Get
		Set(ByVal value As String)
			_strDelete1 = value
		End Set
	End Property

	Public Property strAllData() As String
		Get
			Return _strAllData
		End Get
		Set(ByVal value As String)
			_strAllData = value
		End Set
	End Property

	Public Property strSettingReload() As String
		Get
			Return _strSettingReload
		End Get
		Set(ByVal value As String)
			_strSettingReload = value
		End Set
	End Property

    Public Property strLongWait() As String
        Get
            Return _strLongWait
        End Get
        Set(ByVal value As String)
            _strLongWait = value
        End Set
    End Property

    Public Property strAll() As String
        Get
            Return _strAll
        End Get
        Set(ByVal value As String)
            _strAll = value
        End Set
    End Property

    Public Property strTime() As String
        Get
            Return _strTime
        End Get
        Set(ByVal value As String)
            _strTime = value
        End Set
    End Property

    Public Property strBar() As String
        Get
            Return _strBar
        End Get
        Set(ByVal value As String)
            _strBar = value
        End Set
    End Property

	Public Property strClient() As String
		Get
			Return _strClient
		End Get
		Set(ByVal value As String)
			_strClient = value
		End Set
	End Property

    Public Property strGroup() As String
        Get
            Return _strGroup
        End Get
        Set(ByVal value As String)
            _strGroup = value
        End Set
    End Property

    Public Property strTeacher() As String
        Get
            Return _strTeacher
        End Get
        Set(ByVal value As String)
            _strTeacher = value
        End Set
    End Property

	Public Property strAdd() As String
		Get
			Return _strAdd
		End Get
		Set(ByVal value As String)
			_strAdd = value
		End Set
	End Property

	Public Property strUpdate() As String
		Get
			Return _strUpdate
		End Get
		Set(ByVal value As String)
			_strUpdate = value
		End Set
	End Property

    Public Property strTotal() As String
        Get
            Return _strTotal
        End Get
        Set(ByVal value As String)
            _strTotal = value
        End Set
    End Property

    Public Property strYes() As String
        Get
            Return _strYes
        End Get
        Set(ByVal value As String)
            _strYes = value
        End Set
    End Property

	Public Property strNo() As String
		Get
			Return _strNo
		End Get
		Set(ByVal value As String)
			_strNo = value
		End Set
	End Property

    Public Property strLanguage() As String
        Get
            Return _strLanguage
        End Get
        Set(ByVal value As String)
            _strLanguage = value
        End Set
    End Property

    Public Property strReport() As String
        Get
            Return _strReport
        End Get
        Set(ByVal value As String)
            _strReport = value
        End Set
    End Property

    Public Property strGroupNotEmpty() As String
        Get
            Return _strGroupNotEmpty
        End Get
        Set(ByVal value As String)
            _strGroupNotEmpty = value
        End Set
    End Property

    Public Property strDeleteMax1Client() As String
        Get
            Return _strDeleteMax1Client
        End Get
        Set(ByVal value As String)
            _strDeleteMax1Client = value
        End Set
    End Property

    Public Property strInvoiceNotEmpty() As String
        Get
            Return _strInvoiceNotEmpty
        End Get
        Set(ByVal value As String)
            _strInvoiceNotEmpty = value
        End Set
    End Property

    Public Property strInvoicePayment() As String
        Get
            Return _strInvoicePayment
        End Get
        Set(ByVal value As String)
            _strInvoicePayment = value
        End Set
    End Property

    Public Property strWarningDemoData() As String
        Get
            Return _strWarningDemoData
        End Get
        Set(ByVal value As String)
            _strWarningDemoData = value
        End Set
    End Property

    Public Property strUpdateDatabase() As String
        Get
            Return _strUpdateDatabase
        End Get
        Set(ByVal value As String)
            _strUpdateDatabase = value
        End Set
    End Property

    Public Property strEnterEmailAddress() As String
        Get
            Return _strEnterEmailAddress
        End Get
        Set(ByVal value As String)
            _strEnterEmailAddress = value
        End Set
    End Property

    Public Property strInvalidEmailAddress() As String
        Get
            Return _strinvalidEmailAddress
        End Get
        Set(ByVal value As String)
            _strinvalidEmailAddress = value
        End Set
    End Property

    Public Property strOverbookClient() As String
        Get
            Return _strOverbookClient
        End Get
        Set(ByVal value As String)
            _strOverbookClient = value
        End Set
    End Property

    Public Property strMissingLessontype() As String
        Get
            Return _strMissingLessontype
        End Get
        Set(ByVal value As String)
            _strMissingLessontype = value
        End Set
    End Property

End Class
