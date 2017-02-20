<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Track1", "0"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Beginner", "LightBlue"}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Automatic", "BlueViolet", "0"}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Tryout Lesson", "1", "50.00"}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Internet")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"0", "Tax Free"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("TrackManager", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Settings", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Clients", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Groups", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Logins", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("AppointmentChange", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Finance", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Properties", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup9 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Reports", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"TrackManager", "TrackManager", "Form"}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Report1", "0"}, -1)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Report1", "0"}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Report1", "0"}, -1)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Remove From List")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Create Appointment")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Appointment")
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Delete Appointment")
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Clear List")
        Me.btnSaveSettingsLog = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tpgGeneral = New System.Windows.Forms.TabPage()
        Me.chkDeleteMax1Client = New System.Windows.Forms.CheckBox()
        Me.chkRequireLessontype = New System.Windows.Forms.CheckBox()
        Me.chkShowAllLessonTypes = New System.Windows.Forms.CheckBox()
        Me.lblDateFormat = New System.Windows.Forms.Label()
        Me.cbxDateFormat = New System.Windows.Forms.ComboBox()
        Me.chkShowLastAppointment = New System.Windows.Forms.CheckBox()
        Me.grpShowOpenBills = New System.Windows.Forms.GroupBox()
        Me.rbnShowOpenBillsGroup = New System.Windows.Forms.RadioButton()
        Me.rbnShowOpenBillsClient = New System.Windows.Forms.RadioButton()
        Me.rbnShowOpenBillsNone = New System.Windows.Forms.RadioButton()
        Me.grpDisplayWarningOverbooked = New System.Windows.Forms.GroupBox()
        Me.rbnOverbookingClient = New System.Windows.Forms.RadioButton()
        Me.rbnOverbookingGroup = New System.Windows.Forms.RadioButton()
        Me.rbnOverbookingNone = New System.Windows.Forms.RadioButton()
        Me.btnSaveSettingsGeneral = New System.Windows.Forms.Button()
        Me.chkSelectMultipleGroups = New System.Windows.Forms.CheckBox()
        Me.chkDeleteEmptyInvoice = New System.Windows.Forms.CheckBox()
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.lblInvoiceNumber = New System.Windows.Forms.Label()
        Me.txtInvoiceName = New System.Windows.Forms.TextBox()
        Me.lblInvoiceName = New System.Windows.Forms.Label()
        Me.tpgTracks = New System.Windows.Forms.TabPage()
        Me.btnClearTrack = New System.Windows.Forms.Button()
        Me.btnAddTrack = New System.Windows.Forms.Button()
        Me.txtTrackOffset = New System.Windows.Forms.TextBox()
        Me.txtTrackName = New System.Windows.Forms.TextBox()
        Me.btnDeleteTrack = New System.Windows.Forms.Button()
        Me.btnEditTrack = New System.Windows.Forms.Button()
        Me.lvwTracks = New System.Windows.Forms.ListView()
        Me.colTrackName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTrackOffset = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgLessonTypes = New System.Windows.Forms.TabPage()
        Me.cbxLessonTypeColor = New System.Windows.Forms.ComboBox()
        Me.btnClearLessonType = New System.Windows.Forms.Button()
        Me.btnAddLessonType = New System.Windows.Forms.Button()
        Me.txtLessonTypeName = New System.Windows.Forms.TextBox()
        Me.btnDeleteLessonType = New System.Windows.Forms.Button()
        Me.btnEditLessonType = New System.Windows.Forms.Button()
        Me.lvwLessonTypes = New System.Windows.Forms.ListView()
        Me.colLessonTypeName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLessonTypeColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgLevels = New System.Windows.Forms.TabPage()
        Me.txtLevelCount = New System.Windows.Forms.TextBox()
        Me.cbxLevelColor = New System.Windows.Forms.ComboBox()
        Me.btnClearLevel = New System.Windows.Forms.Button()
        Me.btnAddLevel = New System.Windows.Forms.Button()
        Me.txtLevelName = New System.Windows.Forms.TextBox()
        Me.btnDeleteLevel = New System.Windows.Forms.Button()
        Me.btnEditLevel = New System.Windows.Forms.Button()
        Me.lvwLevels = New System.Windows.Forms.ListView()
        Me.colLevelName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLevelColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLevelCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgProducts = New System.Windows.Forms.TabPage()
        Me.txtProductSort = New System.Windows.Forms.TextBox()
        Me.cbxProductTax = New System.Windows.Forms.ComboBox()
        Me.txtProductAmount = New System.Windows.Forms.TextBox()
        Me.txtProductCount = New System.Windows.Forms.TextBox()
        Me.btnClearProduct = New System.Windows.Forms.Button()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.btnDeleteProduct = New System.Windows.Forms.Button()
        Me.btnEditProduct = New System.Windows.Forms.Button()
        Me.lvwProducts = New System.Windows.Forms.ListView()
        Me.colProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductTax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductSort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgPrContacts = New System.Windows.Forms.TabPage()
        Me.btnClearPrContact = New System.Windows.Forms.Button()
        Me.btnAddPrContact = New System.Windows.Forms.Button()
        Me.txtPrContact = New System.Windows.Forms.TextBox()
        Me.btnDeletePrContact = New System.Windows.Forms.Button()
        Me.btnEditPrContact = New System.Windows.Forms.Button()
        Me.lvwPrContacts = New System.Windows.Forms.ListView()
        Me.colPrContacts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgTax = New System.Windows.Forms.TabPage()
        Me.btnClearTax = New System.Windows.Forms.Button()
        Me.btnAddTax = New System.Windows.Forms.Button()
        Me.txtTaxDescription = New System.Windows.Forms.TextBox()
        Me.txtTaxValue = New System.Windows.Forms.TextBox()
        Me.btnDeleteTax = New System.Windows.Forms.Button()
        Me.btnEditTax = New System.Windows.Forms.Button()
        Me.lvwTax = New System.Windows.Forms.ListView()
        Me.colTaxValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTaxDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgLogging = New System.Windows.Forms.TabPage()
        Me.btnLogToDatabase = New System.Windows.Forms.Button()
        Me.grpLogsToKeep = New System.Windows.Forms.GroupBox()
        Me.chkAutoDeleteOldLogs = New System.Windows.Forms.CheckBox()
        Me.btnClearOldLogs = New System.Windows.Forms.Button()
        Me.rbtKeepLogMonth = New System.Windows.Forms.RadioButton()
        Me.rbtKeepLogWeek = New System.Windows.Forms.RadioButton()
        Me.rbtKeepLogDay = New System.Windows.Forms.RadioButton()
        Me.txtLogfileLocation = New System.Windows.Forms.TextBox()
        Me.txtLogfileName = New System.Windows.Forms.TextBox()
        Me.lblLogfileName = New System.Windows.Forms.Label()
        Me.lblLogfileLocation = New System.Windows.Forms.Label()
        Me.rbtLoggingLevel5 = New System.Windows.Forms.RadioButton()
        Me.lblLoggingLevel = New System.Windows.Forms.Label()
        Me.rbtLoggingLevel1 = New System.Windows.Forms.RadioButton()
        Me.rbtLoggingLevel2 = New System.Windows.Forms.RadioButton()
        Me.rbtLoggingLevel3 = New System.Windows.Forms.RadioButton()
        Me.rbtLoggingLevel4 = New System.Windows.Forms.RadioButton()
        Me.rbtLoggingLevel0 = New System.Windows.Forms.RadioButton()
        Me.tpgView = New System.Windows.Forms.TabPage()
        Me.cbxClientFieldHeight = New System.Windows.Forms.ComboBox()
        Me.lblClientFieldHeight = New System.Windows.Forms.Label()
        Me.chkShowAgeAfter = New System.Windows.Forms.CheckBox()
        Me.txtShowAgeMax = New System.Windows.Forms.TextBox()
        Me.chkShowAge = New System.Windows.Forms.CheckBox()
        Me.cbxUseFadingColors = New System.Windows.Forms.ComboBox()
        Me.lblUseFadingColors = New System.Windows.Forms.Label()
        Me.dtmSeasonStart = New System.Windows.Forms.DateTimePicker()
        Me.cbxSeasonLength = New System.Windows.Forms.ComboBox()
        Me.lblSeasonStart = New System.Windows.Forms.Label()
        Me.lblSeasonLength = New System.Windows.Forms.Label()
        Me.lblReadOnlyBackColor = New System.Windows.Forms.Label()
        Me.cbxReadOnlyBackColor = New System.Windows.Forms.ComboBox()
        Me.txtTimeFrame = New System.Windows.Forms.TextBox()
        Me.dtpClosingHour = New System.Windows.Forms.DateTimePicker()
        Me.dtpOpeningHour = New System.Windows.Forms.DateTimePicker()
        Me.lblTimeFrame = New System.Windows.Forms.Label()
        Me.txtDefFinanceRows = New System.Windows.Forms.TextBox()
        Me.lblDefFinanceRows = New System.Windows.Forms.Label()
        Me.cbxShowTimeWithTrack = New System.Windows.Forms.ComboBox()
        Me.lblShowTimeWithTrack = New System.Windows.Forms.Label()
        Me.btnSaveSettingsView = New System.Windows.Forms.Button()
        Me.cbxOnHoursColor = New System.Windows.Forms.ComboBox()
        Me.cbxOffHoursColor = New System.Windows.Forms.ComboBox()
        Me.cbxShowTeacherColumn = New System.Windows.Forms.ComboBox()
        Me.cbxShowClosedHours = New System.Windows.Forms.ComboBox()
        Me.txtClientsPerTrack = New System.Windows.Forms.TextBox()
        Me.txtClientsPerGroup = New System.Windows.Forms.TextBox()
        Me.txtClientFieldWidth = New System.Windows.Forms.TextBox()
        Me.lblClientsPerTrack = New System.Windows.Forms.Label()
        Me.lblClientsPerGroup = New System.Windows.Forms.Label()
        Me.lblOpeningHour = New System.Windows.Forms.Label()
        Me.lblClosingHour = New System.Windows.Forms.Label()
        Me.lblShowClosedHours = New System.Windows.Forms.Label()
        Me.lblOnHoursColor = New System.Windows.Forms.Label()
        Me.lblOffHoursColor = New System.Windows.Forms.Label()
        Me.lblShowTeacherColumn = New System.Windows.Forms.Label()
        Me.lblClientFieldWidth = New System.Windows.Forms.Label()
        Me.tpgDatabase = New System.Windows.Forms.TabPage()
        Me.btnRefreshDatabase = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.lblBackupPath = New System.Windows.Forms.Label()
        Me.txtBackupDatabase = New System.Windows.Forms.TextBox()
        Me.lblBackupDatabase = New System.Windows.Forms.Label()
        Me.btnBackupDatabase = New System.Windows.Forms.Button()
        Me.txtUpgradeDatabase = New System.Windows.Forms.TextBox()
        Me.lblDatabaseVersion = New System.Windows.Forms.Label()
        Me.btnUpgradeDatabase = New System.Windows.Forms.Button()
        Me.prbCreateDatabase = New System.Windows.Forms.ProgressBar()
        Me.btnCreateDemoData = New System.Windows.Forms.Button()
        Me.btnCreateDatabase = New System.Windows.Forms.Button()
        Me.btnSaveSettingsDatabase = New System.Windows.Forms.Button()
        Me.btnUseDefaults = New System.Windows.Forms.Button()
        Me.lblLoginMethod = New System.Windows.Forms.Label()
        Me.lblLoginName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cbxLoginMethod = New System.Windows.Forms.ComboBox()
        Me.txtLoginName = New System.Windows.Forms.TextBox()
        Me.lblDatabaseName = New System.Windows.Forms.Label()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.lblDatabaseLocation = New System.Windows.Forms.Label()
        Me.cbxDataProvider = New System.Windows.Forms.ComboBox()
        Me.txtDatabaseLocation = New System.Windows.Forms.TextBox()
        Me.lblDataProvider = New System.Windows.Forms.Label()
        Me.lblStatusDatabase = New System.Windows.Forms.Label()
        Me.tpgEmail = New System.Windows.Forms.TabPage()
        Me.grpEmailSmtp = New System.Windows.Forms.GroupBox()
        Me.lblSmtpPortNumber = New System.Windows.Forms.Label()
        Me.txtSmtpPortNumber = New System.Windows.Forms.TextBox()
        Me.chkUseSslEncryption = New System.Windows.Forms.CheckBox()
        Me.lblSmtpReply = New System.Windows.Forms.Label()
        Me.txtSmtpReply = New System.Windows.Forms.TextBox()
        Me.chkSmtpCredentials = New System.Windows.Forms.CheckBox()
        Me.lblSmtpServerPassword = New System.Windows.Forms.Label()
        Me.txtSmtpServerPassword = New System.Windows.Forms.TextBox()
        Me.lblSmtpServerUsername = New System.Windows.Forms.Label()
        Me.txtSmtpServerUsername = New System.Windows.Forms.TextBox()
        Me.lblSmtpServer = New System.Windows.Forms.Label()
        Me.txtSmtpServer = New System.Windows.Forms.TextBox()
        Me.rbtEmailUseOutlook = New System.Windows.Forms.RadioButton()
        Me.rbtEmailUseSmtp = New System.Windows.Forms.RadioButton()
        Me.btnSaveSettingsEmail = New System.Windows.Forms.Button()
        Me.tpgLicense = New System.Windows.Forms.TabPage()
        Me.btnExitTrackManager = New System.Windows.Forms.Button()
        Me.lblInstallKey = New System.Windows.Forms.Label()
        Me.txtInstallKey = New System.Windows.Forms.TextBox()
        Me.lblLicenseKey = New System.Windows.Forms.Label()
        Me.txtLicenseKey = New System.Windows.Forms.TextBox()
        Me.lblExpireDate = New System.Windows.Forms.Label()
        Me.txtExpiryDate = New System.Windows.Forms.TextBox()
        Me.btnSaveLicense = New System.Windows.Forms.Button()
        Me.lblLicenseName = New System.Windows.Forms.Label()
        Me.txtLicenseName = New System.Windows.Forms.TextBox()
        Me.btnValidateLicense = New System.Windows.Forms.Button()
        Me.tpgPaymentMethod = New System.Windows.Forms.TabPage()
        Me.tpgLanguage = New System.Windows.Forms.TabPage()
        Me.lblLanguageType = New System.Windows.Forms.Label()
        Me.lblLanguageText = New System.Windows.Forms.Label()
        Me.lblLanguageItem = New System.Windows.Forms.Label()
        Me.lblLanguageForm = New System.Windows.Forms.Label()
        Me.cbxLanguageForm = New System.Windows.Forms.ComboBox()
        Me.cbxLanguageType = New System.Windows.Forms.ComboBox()
        Me.btnLanguageExport = New System.Windows.Forms.Button()
        Me.cbxLanguage = New System.Windows.Forms.ComboBox()
        Me.btnLanguageLoad = New System.Windows.Forms.Button()
        Me.lblLanguageDefault = New System.Windows.Forms.Label()
        Me.lbxLanguage = New System.Windows.Forms.ListBox()
        Me.btnAddLanguage = New System.Windows.Forms.Button()
        Me.btnDeleteLanguage = New System.Windows.Forms.Button()
        Me.lblCurrentLanguage = New System.Windows.Forms.Label()
        Me.btnLanguageSaveAll = New System.Windows.Forms.Button()
        Me.btnClearLanguage = New System.Windows.Forms.Button()
        Me.btnSaveSettingsLanguage = New System.Windows.Forms.Button()
        Me.TxtLanguageText = New System.Windows.Forms.TextBox()
        Me.txtLanguageItem = New System.Windows.Forms.TextBox()
        Me.btnLanguageImport = New System.Windows.Forms.Button()
        Me.btnEditLanguage = New System.Windows.Forms.Button()
        Me.lvwLanguage = New System.Windows.Forms.ListView()
        Me.colItemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgReports = New System.Windows.Forms.TabPage()
        Me.lblReportLessons = New System.Windows.Forms.Label()
        Me.lblReportFinance = New System.Windows.Forms.Label()
        Me.lblReportClients = New System.Windows.Forms.Label()
        Me.tbnSaveReportClients = New System.Windows.Forms.Button()
        Me.tbnSaveReportFinance = New System.Windows.Forms.Button()
        Me.lvwReportsClients = New System.Windows.Forms.ListView()
        Me.colReportClients = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvwReportsFinance = New System.Windows.Forms.ListView()
        Me.colReportFinance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSaveReportLessons = New System.Windows.Forms.Button()
        Me.lvwReportsLessons = New System.Windows.Forms.ListView()
        Me.colReportLessons = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpgButtons = New System.Windows.Forms.TabPage()
        Me.btnButtonOrderSave = New System.Windows.Forms.Button()
        Me.lvwButtons = New System.Windows.Forms.ListView()
        Me.btnButtonDown = New System.Windows.Forms.Button()
        Me.btnButtonUp = New System.Windows.Forms.Button()
        Me.ofdScript = New System.Windows.Forms.OpenFileDialog()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkArchiveEmail = New System.Windows.Forms.CheckBox()
        Me.txtArchiveEmail = New System.Windows.Forms.TextBox()
        Me.tabSettings.SuspendLayout()
        Me.tpgGeneral.SuspendLayout()
        Me.grpShowOpenBills.SuspendLayout()
        Me.grpDisplayWarningOverbooked.SuspendLayout()
        Me.tpgTracks.SuspendLayout()
        Me.tpgLessonTypes.SuspendLayout()
        Me.tpgLevels.SuspendLayout()
        Me.tpgProducts.SuspendLayout()
        Me.tpgPrContacts.SuspendLayout()
        Me.tpgTax.SuspendLayout()
        Me.tpgLogging.SuspendLayout()
        Me.grpLogsToKeep.SuspendLayout()
        Me.tpgView.SuspendLayout()
        Me.tpgDatabase.SuspendLayout()
        Me.tpgEmail.SuspendLayout()
        Me.grpEmailSmtp.SuspendLayout()
        Me.tpgLicense.SuspendLayout()
        Me.tpgLanguage.SuspendLayout()
        Me.tpgReports.SuspendLayout()
        Me.tpgButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveSettingsLog
        '
        Me.btnSaveSettingsLog.Enabled = False
        Me.btnSaveSettingsLog.Location = New System.Drawing.Point(442, 18)
        Me.btnSaveSettingsLog.Name = "btnSaveSettingsLog"
        Me.btnSaveSettingsLog.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveSettingsLog.TabIndex = 48
        Me.btnSaveSettingsLog.Text = "Save Settings"
        Me.btnSaveSettingsLog.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(504, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabSettings
        '
        Me.tabSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSettings.Controls.Add(Me.tpgGeneral)
        Me.tabSettings.Controls.Add(Me.tpgTracks)
        Me.tabSettings.Controls.Add(Me.tpgLessonTypes)
        Me.tabSettings.Controls.Add(Me.tpgLevels)
        Me.tabSettings.Controls.Add(Me.tpgProducts)
        Me.tabSettings.Controls.Add(Me.tpgPrContacts)
        Me.tabSettings.Controls.Add(Me.tpgTax)
        Me.tabSettings.Controls.Add(Me.tpgLogging)
        Me.tabSettings.Controls.Add(Me.tpgView)
        Me.tabSettings.Controls.Add(Me.tpgDatabase)
        Me.tabSettings.Controls.Add(Me.tpgEmail)
        Me.tabSettings.Controls.Add(Me.tpgLicense)
        Me.tabSettings.Controls.Add(Me.tpgPaymentMethod)
        Me.tabSettings.Controls.Add(Me.tpgLanguage)
        Me.tabSettings.Controls.Add(Me.tpgReports)
        Me.tabSettings.Controls.Add(Me.tpgButtons)
        Me.tabSettings.Location = New System.Drawing.Point(12, 41)
        Me.tabSettings.Multiline = True
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(596, 381)
        Me.tabSettings.TabIndex = 2
        '
        'tpgGeneral
        '
        Me.tpgGeneral.Controls.Add(Me.chkDeleteMax1Client)
        Me.tpgGeneral.Controls.Add(Me.chkRequireLessontype)
        Me.tpgGeneral.Controls.Add(Me.chkShowAllLessonTypes)
        Me.tpgGeneral.Controls.Add(Me.lblDateFormat)
        Me.tpgGeneral.Controls.Add(Me.cbxDateFormat)
        Me.tpgGeneral.Controls.Add(Me.chkShowLastAppointment)
        Me.tpgGeneral.Controls.Add(Me.grpShowOpenBills)
        Me.tpgGeneral.Controls.Add(Me.grpDisplayWarningOverbooked)
        Me.tpgGeneral.Controls.Add(Me.btnSaveSettingsGeneral)
        Me.tpgGeneral.Controls.Add(Me.chkSelectMultipleGroups)
        Me.tpgGeneral.Controls.Add(Me.chkDeleteEmptyInvoice)
        Me.tpgGeneral.Controls.Add(Me.txtInvoiceNumber)
        Me.tpgGeneral.Controls.Add(Me.lblInvoiceNumber)
        Me.tpgGeneral.Controls.Add(Me.txtInvoiceName)
        Me.tpgGeneral.Controls.Add(Me.lblInvoiceName)
        Me.tpgGeneral.Location = New System.Drawing.Point(4, 40)
        Me.tpgGeneral.Name = "tpgGeneral"
        Me.tpgGeneral.Size = New System.Drawing.Size(588, 337)
        Me.tpgGeneral.TabIndex = 15
        Me.tpgGeneral.Text = "General"
        Me.tpgGeneral.UseVisualStyleBackColor = True
        '
        'chkDeleteMax1Client
        '
        Me.chkDeleteMax1Client.AutoSize = True
        Me.chkDeleteMax1Client.Checked = True
        Me.chkDeleteMax1Client.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDeleteMax1Client.Location = New System.Drawing.Point(310, 81)
        Me.chkDeleteMax1Client.Name = "chkDeleteMax1Client"
        Me.chkDeleteMax1Client.Size = New System.Drawing.Size(188, 17)
        Me.chkDeleteMax1Client.TabIndex = 88
        Me.chkDeleteMax1Client.Text = "Delete max 1 appointment at once"
        Me.chkDeleteMax1Client.UseVisualStyleBackColor = True
        '
        'chkRequireLessontype
        '
        Me.chkRequireLessontype.AutoSize = True
        Me.chkRequireLessontype.Location = New System.Drawing.Point(30, 287)
        Me.chkRequireLessontype.Name = "chkRequireLessontype"
        Me.chkRequireLessontype.Size = New System.Drawing.Size(180, 17)
        Me.chkRequireLessontype.TabIndex = 87
        Me.chkRequireLessontype.Text = "Require a lessontype  for the Bar"
        Me.chkRequireLessontype.UseVisualStyleBackColor = True
        '
        'chkShowAllLessonTypes
        '
        Me.chkShowAllLessonTypes.AutoSize = True
        Me.chkShowAllLessonTypes.Location = New System.Drawing.Point(30, 264)
        Me.chkShowAllLessonTypes.Name = "chkShowAllLessonTypes"
        Me.chkShowAllLessonTypes.Size = New System.Drawing.Size(194, 17)
        Me.chkShowAllLessonTypes.TabIndex = 86
        Me.chkShowAllLessonTypes.Text = "Show all lessontypes for each client"
        Me.chkShowAllLessonTypes.UseVisualStyleBackColor = True
        '
        'lblDateFormat
        '
        Me.lblDateFormat.AutoSize = True
        Me.lblDateFormat.Location = New System.Drawing.Point(315, 242)
        Me.lblDateFormat.Name = "lblDateFormat"
        Me.lblDateFormat.Size = New System.Drawing.Size(65, 13)
        Me.lblDateFormat.TabIndex = 85
        Me.lblDateFormat.Text = "Date Format"
        '
        'cbxDateFormat
        '
        Me.cbxDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDateFormat.FormattingEnabled = True
        Me.cbxDateFormat.Items.AddRange(New Object() {"yyyy-mm-dd", "dd-mm-yyyy", "mm/dd/yyyy"})
        Me.cbxDateFormat.Location = New System.Drawing.Point(425, 239)
        Me.cbxDateFormat.Name = "cbxDateFormat"
        Me.cbxDateFormat.Size = New System.Drawing.Size(137, 21)
        Me.cbxDateFormat.TabIndex = 84
        '
        'chkShowLastAppointment
        '
        Me.chkShowLastAppointment.AutoSize = True
        Me.chkShowLastAppointment.Location = New System.Drawing.Point(30, 241)
        Me.chkShowLastAppointment.Name = "chkShowLastAppointment"
        Me.chkShowLastAppointment.Size = New System.Drawing.Size(212, 17)
        Me.chkShowLastAppointment.TabIndex = 83
        Me.chkShowLastAppointment.Text = "Show an ""!"" on clients last appointment"
        Me.chkShowLastAppointment.UseVisualStyleBackColor = True
        '
        'grpShowOpenBills
        '
        Me.grpShowOpenBills.Controls.Add(Me.rbnShowOpenBillsGroup)
        Me.grpShowOpenBills.Controls.Add(Me.rbnShowOpenBillsClient)
        Me.grpShowOpenBills.Controls.Add(Me.rbnShowOpenBillsNone)
        Me.grpShowOpenBills.Location = New System.Drawing.Point(22, 133)
        Me.grpShowOpenBills.Margin = New System.Windows.Forms.Padding(2)
        Me.grpShowOpenBills.Name = "grpShowOpenBills"
        Me.grpShowOpenBills.Padding = New System.Windows.Forms.Padding(2)
        Me.grpShowOpenBills.Size = New System.Drawing.Size(284, 94)
        Me.grpShowOpenBills.TabIndex = 82
        Me.grpShowOpenBills.TabStop = False
        Me.grpShowOpenBills.Text = "Show Open Bills on Calendar using Underline"
        '
        'rbnShowOpenBillsGroup
        '
        Me.rbnShowOpenBillsGroup.AutoSize = True
        Me.rbnShowOpenBillsGroup.Location = New System.Drawing.Point(8, 63)
        Me.rbnShowOpenBillsGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnShowOpenBillsGroup.Name = "rbnShowOpenBillsGroup"
        Me.rbnShowOpenBillsGroup.Size = New System.Drawing.Size(178, 17)
        Me.rbnShowOpenBillsGroup.TabIndex = 58
        Me.rbnShowOpenBillsGroup.Text = "Show Open Bills on Group Level"
        Me.rbnShowOpenBillsGroup.UseVisualStyleBackColor = True
        '
        'rbnShowOpenBillsClient
        '
        Me.rbnShowOpenBillsClient.AutoSize = True
        Me.rbnShowOpenBillsClient.Location = New System.Drawing.Point(8, 41)
        Me.rbnShowOpenBillsClient.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnShowOpenBillsClient.Name = "rbnShowOpenBillsClient"
        Me.rbnShowOpenBillsClient.Size = New System.Drawing.Size(178, 17)
        Me.rbnShowOpenBillsClient.TabIndex = 59
        Me.rbnShowOpenBillsClient.Text = "Show Open Bills on Client Level "
        Me.rbnShowOpenBillsClient.UseVisualStyleBackColor = True
        '
        'rbnShowOpenBillsNone
        '
        Me.rbnShowOpenBillsNone.AutoSize = True
        Me.rbnShowOpenBillsNone.Checked = True
        Me.rbnShowOpenBillsNone.Location = New System.Drawing.Point(8, 20)
        Me.rbnShowOpenBillsNone.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnShowOpenBillsNone.Name = "rbnShowOpenBillsNone"
        Me.rbnShowOpenBillsNone.Size = New System.Drawing.Size(128, 17)
        Me.rbnShowOpenBillsNone.TabIndex = 60
        Me.rbnShowOpenBillsNone.TabStop = True
        Me.rbnShowOpenBillsNone.Text = "Don't show Open Bills"
        Me.rbnShowOpenBillsNone.UseVisualStyleBackColor = True
        '
        'grpDisplayWarningOverbooked
        '
        Me.grpDisplayWarningOverbooked.Controls.Add(Me.rbnOverbookingClient)
        Me.grpDisplayWarningOverbooked.Controls.Add(Me.rbnOverbookingGroup)
        Me.grpDisplayWarningOverbooked.Controls.Add(Me.rbnOverbookingNone)
        Me.grpDisplayWarningOverbooked.Location = New System.Drawing.Point(310, 133)
        Me.grpDisplayWarningOverbooked.Margin = New System.Windows.Forms.Padding(2)
        Me.grpDisplayWarningOverbooked.Name = "grpDisplayWarningOverbooked"
        Me.grpDisplayWarningOverbooked.Padding = New System.Windows.Forms.Padding(2)
        Me.grpDisplayWarningOverbooked.Size = New System.Drawing.Size(252, 94)
        Me.grpDisplayWarningOverbooked.TabIndex = 81
        Me.grpDisplayWarningOverbooked.TabStop = False
        Me.grpDisplayWarningOverbooked.Text = "Display a warning when overbooking"
        '
        'rbnOverbookingClient
        '
        Me.rbnOverbookingClient.AutoSize = True
        Me.rbnOverbookingClient.Location = New System.Drawing.Point(8, 63)
        Me.rbnOverbookingClient.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnOverbookingClient.Name = "rbnOverbookingClient"
        Me.rbnOverbookingClient.Size = New System.Drawing.Size(185, 17)
        Me.rbnOverbookingClient.TabIndex = 58
        Me.rbnOverbookingClient.Text = "Display a warning on a client level"
        Me.rbnOverbookingClient.UseVisualStyleBackColor = True
        '
        'rbnOverbookingGroup
        '
        Me.rbnOverbookingGroup.AutoSize = True
        Me.rbnOverbookingGroup.Location = New System.Drawing.Point(8, 41)
        Me.rbnOverbookingGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnOverbookingGroup.Name = "rbnOverbookingGroup"
        Me.rbnOverbookingGroup.Size = New System.Drawing.Size(187, 17)
        Me.rbnOverbookingGroup.TabIndex = 59
        Me.rbnOverbookingGroup.Text = "Display a warning on a group level"
        Me.rbnOverbookingGroup.UseVisualStyleBackColor = True
        '
        'rbnOverbookingNone
        '
        Me.rbnOverbookingNone.AutoSize = True
        Me.rbnOverbookingNone.Checked = True
        Me.rbnOverbookingNone.Location = New System.Drawing.Point(8, 20)
        Me.rbnOverbookingNone.Margin = New System.Windows.Forms.Padding(2)
        Me.rbnOverbookingNone.Name = "rbnOverbookingNone"
        Me.rbnOverbookingNone.Size = New System.Drawing.Size(134, 17)
        Me.rbnOverbookingNone.TabIndex = 60
        Me.rbnOverbookingNone.TabStop = True
        Me.rbnOverbookingNone.Text = "Don't display a warning"
        Me.rbnOverbookingNone.UseVisualStyleBackColor = True
        '
        'btnSaveSettingsGeneral
        '
        Me.btnSaveSettingsGeneral.Enabled = False
        Me.btnSaveSettingsGeneral.Location = New System.Drawing.Point(442, 18)
        Me.btnSaveSettingsGeneral.Name = "btnSaveSettingsGeneral"
        Me.btnSaveSettingsGeneral.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveSettingsGeneral.TabIndex = 80
        Me.btnSaveSettingsGeneral.Text = "Save Settings"
        Me.btnSaveSettingsGeneral.UseVisualStyleBackColor = True
        '
        'chkSelectMultipleGroups
        '
        Me.chkSelectMultipleGroups.AutoSize = True
        Me.chkSelectMultipleGroups.Checked = True
        Me.chkSelectMultipleGroups.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSelectMultipleGroups.Enabled = False
        Me.chkSelectMultipleGroups.Location = New System.Drawing.Point(310, 105)
        Me.chkSelectMultipleGroups.Name = "chkSelectMultipleGroups"
        Me.chkSelectMultipleGroups.Size = New System.Drawing.Size(185, 17)
        Me.chkSelectMultipleGroups.TabIndex = 79
        Me.chkSelectMultipleGroups.Text = "Select clients from multiple groups"
        Me.chkSelectMultipleGroups.UseVisualStyleBackColor = True
        Me.chkSelectMultipleGroups.Visible = False
        '
        'chkDeleteEmptyInvoice
        '
        Me.chkDeleteEmptyInvoice.AutoSize = True
        Me.chkDeleteEmptyInvoice.Checked = True
        Me.chkDeleteEmptyInvoice.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDeleteEmptyInvoice.Location = New System.Drawing.Point(310, 58)
        Me.chkDeleteEmptyInvoice.Name = "chkDeleteEmptyInvoice"
        Me.chkDeleteEmptyInvoice.Size = New System.Drawing.Size(155, 17)
        Me.chkDeleteEmptyInvoice.TabIndex = 78
        Me.chkDeleteEmptyInvoice.Text = "Only delete empty invoices "
        Me.chkDeleteEmptyInvoice.UseVisualStyleBackColor = True
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(160, 80)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(50, 20)
        Me.txtInvoiceNumber.TabIndex = 77
        Me.txtInvoiceNumber.Text = "1"
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.AutoSize = True
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(19, 83)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(107, 13)
        Me.lblInvoiceNumber.TabIndex = 76
        Me.lblInvoiceNumber.Text = "Invoice Start Number"
        '
        'txtInvoiceName
        '
        Me.txtInvoiceName.Location = New System.Drawing.Point(160, 55)
        Me.txtInvoiceName.MaxLength = 15
        Me.txtInvoiceName.Name = "txtInvoiceName"
        Me.txtInvoiceName.Size = New System.Drawing.Size(128, 20)
        Me.txtInvoiceName.TabIndex = 75
        Me.txtInvoiceName.Text = "Invoice"
        '
        'lblInvoiceName
        '
        Me.lblInvoiceName.AutoSize = True
        Me.lblInvoiceName.Location = New System.Drawing.Point(19, 58)
        Me.lblInvoiceName.Name = "lblInvoiceName"
        Me.lblInvoiceName.Size = New System.Drawing.Size(73, 13)
        Me.lblInvoiceName.TabIndex = 74
        Me.lblInvoiceName.Text = "Invoice Name"
        '
        'tpgTracks
        '
        Me.tpgTracks.Controls.Add(Me.btnClearTrack)
        Me.tpgTracks.Controls.Add(Me.btnAddTrack)
        Me.tpgTracks.Controls.Add(Me.txtTrackOffset)
        Me.tpgTracks.Controls.Add(Me.txtTrackName)
        Me.tpgTracks.Controls.Add(Me.btnDeleteTrack)
        Me.tpgTracks.Controls.Add(Me.btnEditTrack)
        Me.tpgTracks.Controls.Add(Me.lvwTracks)
        Me.tpgTracks.Location = New System.Drawing.Point(4, 40)
        Me.tpgTracks.Name = "tpgTracks"
        Me.tpgTracks.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTracks.Size = New System.Drawing.Size(588, 337)
        Me.tpgTracks.TabIndex = 0
        Me.tpgTracks.Tag = "tpgTracks"
        Me.tpgTracks.Text = "Tracks"
        Me.tpgTracks.UseVisualStyleBackColor = True
        '
        'btnClearTrack
        '
        Me.btnClearTrack.Location = New System.Drawing.Point(130, 243)
        Me.btnClearTrack.Name = "btnClearTrack"
        Me.btnClearTrack.Size = New System.Drawing.Size(100, 23)
        Me.btnClearTrack.TabIndex = 9
        Me.btnClearTrack.Text = "Clear"
        Me.btnClearTrack.UseVisualStyleBackColor = True
        '
        'btnAddTrack
        '
        Me.btnAddTrack.Location = New System.Drawing.Point(24, 243)
        Me.btnAddTrack.Name = "btnAddTrack"
        Me.btnAddTrack.Size = New System.Drawing.Size(100, 23)
        Me.btnAddTrack.TabIndex = 8
        Me.btnAddTrack.Text = "Add"
        Me.btnAddTrack.UseVisualStyleBackColor = True
        '
        'txtTrackOffset
        '
        Me.txtTrackOffset.Location = New System.Drawing.Point(131, 217)
        Me.txtTrackOffset.Name = "txtTrackOffset"
        Me.txtTrackOffset.Size = New System.Drawing.Size(100, 20)
        Me.txtTrackOffset.TabIndex = 7
        '
        'txtTrackName
        '
        Me.txtTrackName.Location = New System.Drawing.Point(24, 217)
        Me.txtTrackName.Name = "txtTrackName"
        Me.txtTrackName.Size = New System.Drawing.Size(100, 20)
        Me.txtTrackName.TabIndex = 6
        Me.txtTrackName.Tag = "0"
        '
        'btnDeleteTrack
        '
        Me.btnDeleteTrack.Enabled = False
        Me.btnDeleteTrack.Location = New System.Drawing.Point(130, 180)
        Me.btnDeleteTrack.Name = "btnDeleteTrack"
        Me.btnDeleteTrack.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteTrack.TabIndex = 5
        Me.btnDeleteTrack.Text = "Delete"
        Me.btnDeleteTrack.UseVisualStyleBackColor = True
        '
        'btnEditTrack
        '
        Me.btnEditTrack.Enabled = False
        Me.btnEditTrack.Location = New System.Drawing.Point(24, 180)
        Me.btnEditTrack.Name = "btnEditTrack"
        Me.btnEditTrack.Size = New System.Drawing.Size(100, 23)
        Me.btnEditTrack.TabIndex = 4
        Me.btnEditTrack.Text = "Edit"
        Me.btnEditTrack.UseVisualStyleBackColor = True
        '
        'lvwTracks
        '
        Me.lvwTracks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTrackName, Me.colTrackOffset})
        Me.lvwTracks.FullRowSelect = True
        Me.lvwTracks.GridLines = True
        Me.lvwTracks.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.lvwTracks.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvwTracks.Location = New System.Drawing.Point(24, 24)
        Me.lvwTracks.MultiSelect = False
        Me.lvwTracks.Name = "lvwTracks"
        Me.lvwTracks.Size = New System.Drawing.Size(400, 150)
        Me.lvwTracks.TabIndex = 3
        Me.lvwTracks.UseCompatibleStateImageBehavior = False
        Me.lvwTracks.View = System.Windows.Forms.View.Details
        '
        'colTrackName
        '
        Me.colTrackName.Tag = "colTrackName"
        Me.colTrackName.Text = "Track Name"
        Me.colTrackName.Width = 131
        '
        'colTrackOffset
        '
        Me.colTrackOffset.Tag = "colTrackOffset"
        Me.colTrackOffset.Text = "Track Offset"
        Me.colTrackOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTrackOffset.Width = 140
        '
        'tpgLessonTypes
        '
        Me.tpgLessonTypes.Controls.Add(Me.cbxLessonTypeColor)
        Me.tpgLessonTypes.Controls.Add(Me.btnClearLessonType)
        Me.tpgLessonTypes.Controls.Add(Me.btnAddLessonType)
        Me.tpgLessonTypes.Controls.Add(Me.txtLessonTypeName)
        Me.tpgLessonTypes.Controls.Add(Me.btnDeleteLessonType)
        Me.tpgLessonTypes.Controls.Add(Me.btnEditLessonType)
        Me.tpgLessonTypes.Controls.Add(Me.lvwLessonTypes)
        Me.tpgLessonTypes.Location = New System.Drawing.Point(4, 40)
        Me.tpgLessonTypes.Name = "tpgLessonTypes"
        Me.tpgLessonTypes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgLessonTypes.Size = New System.Drawing.Size(588, 337)
        Me.tpgLessonTypes.TabIndex = 1
        Me.tpgLessonTypes.Tag = "tpgLessonTypes"
        Me.tpgLessonTypes.Text = "Lesson Types"
        Me.tpgLessonTypes.UseVisualStyleBackColor = True
        '
        'cbxLessonTypeColor
        '
        Me.cbxLessonTypeColor.FormattingEnabled = True
        Me.cbxLessonTypeColor.Location = New System.Drawing.Point(130, 218)
        Me.cbxLessonTypeColor.Name = "cbxLessonTypeColor"
        Me.cbxLessonTypeColor.Size = New System.Drawing.Size(100, 21)
        Me.cbxLessonTypeColor.TabIndex = 14
        '
        'btnClearLessonType
        '
        Me.btnClearLessonType.Location = New System.Drawing.Point(130, 243)
        Me.btnClearLessonType.Name = "btnClearLessonType"
        Me.btnClearLessonType.Size = New System.Drawing.Size(100, 23)
        Me.btnClearLessonType.TabIndex = 16
        Me.btnClearLessonType.Text = "Clear"
        Me.btnClearLessonType.UseVisualStyleBackColor = True
        '
        'btnAddLessonType
        '
        Me.btnAddLessonType.Location = New System.Drawing.Point(24, 243)
        Me.btnAddLessonType.Name = "btnAddLessonType"
        Me.btnAddLessonType.Size = New System.Drawing.Size(100, 23)
        Me.btnAddLessonType.TabIndex = 15
        Me.btnAddLessonType.Text = "Add"
        Me.btnAddLessonType.UseVisualStyleBackColor = True
        '
        'txtLessonTypeName
        '
        Me.txtLessonTypeName.Location = New System.Drawing.Point(24, 218)
        Me.txtLessonTypeName.Name = "txtLessonTypeName"
        Me.txtLessonTypeName.Size = New System.Drawing.Size(100, 20)
        Me.txtLessonTypeName.TabIndex = 13
        Me.txtLessonTypeName.Tag = "0"
        '
        'btnDeleteLessonType
        '
        Me.btnDeleteLessonType.Enabled = False
        Me.btnDeleteLessonType.Location = New System.Drawing.Point(130, 180)
        Me.btnDeleteLessonType.Name = "btnDeleteLessonType"
        Me.btnDeleteLessonType.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteLessonType.TabIndex = 12
        Me.btnDeleteLessonType.Text = "Delete"
        Me.btnDeleteLessonType.UseVisualStyleBackColor = True
        '
        'btnEditLessonType
        '
        Me.btnEditLessonType.Enabled = False
        Me.btnEditLessonType.Location = New System.Drawing.Point(24, 180)
        Me.btnEditLessonType.Name = "btnEditLessonType"
        Me.btnEditLessonType.Size = New System.Drawing.Size(100, 23)
        Me.btnEditLessonType.TabIndex = 11
        Me.btnEditLessonType.Text = "Edit"
        Me.btnEditLessonType.UseVisualStyleBackColor = True
        '
        'lvwLessonTypes
        '
        Me.lvwLessonTypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLessonTypeName, Me.colLessonTypeColor})
        Me.lvwLessonTypes.FullRowSelect = True
        Me.lvwLessonTypes.GridLines = True
        Me.lvwLessonTypes.HideSelection = False
        ListViewItem2.Tag = ""
        Me.lvwLessonTypes.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.lvwLessonTypes.Location = New System.Drawing.Point(24, 24)
        Me.lvwLessonTypes.MultiSelect = False
        Me.lvwLessonTypes.Name = "lvwLessonTypes"
        Me.lvwLessonTypes.Size = New System.Drawing.Size(400, 150)
        Me.lvwLessonTypes.TabIndex = 10
        Me.lvwLessonTypes.UseCompatibleStateImageBehavior = False
        Me.lvwLessonTypes.View = System.Windows.Forms.View.Details
        '
        'colLessonTypeName
        '
        Me.colLessonTypeName.Tag = "colLessonTypeName"
        Me.colLessonTypeName.Text = "Lesson Type"
        Me.colLessonTypeName.Width = 132
        '
        'colLessonTypeColor
        '
        Me.colLessonTypeColor.Tag = "colLessonTypeColor"
        Me.colLessonTypeColor.Text = "Lesson Type Color"
        Me.colLessonTypeColor.Width = 141
        '
        'tpgLevels
        '
        Me.tpgLevels.Controls.Add(Me.txtLevelCount)
        Me.tpgLevels.Controls.Add(Me.cbxLevelColor)
        Me.tpgLevels.Controls.Add(Me.btnClearLevel)
        Me.tpgLevels.Controls.Add(Me.btnAddLevel)
        Me.tpgLevels.Controls.Add(Me.txtLevelName)
        Me.tpgLevels.Controls.Add(Me.btnDeleteLevel)
        Me.tpgLevels.Controls.Add(Me.btnEditLevel)
        Me.tpgLevels.Controls.Add(Me.lvwLevels)
        Me.tpgLevels.Location = New System.Drawing.Point(4, 40)
        Me.tpgLevels.Name = "tpgLevels"
        Me.tpgLevels.Size = New System.Drawing.Size(588, 337)
        Me.tpgLevels.TabIndex = 2
        Me.tpgLevels.Tag = "tpgLevels"
        Me.tpgLevels.Text = "Levels"
        Me.tpgLevels.UseVisualStyleBackColor = True
        '
        'txtLevelCount
        '
        Me.txtLevelCount.Location = New System.Drawing.Point(231, 218)
        Me.txtLevelCount.Name = "txtLevelCount"
        Me.txtLevelCount.Size = New System.Drawing.Size(45, 20)
        Me.txtLevelCount.TabIndex = 22
        '
        'cbxLevelColor
        '
        Me.cbxLevelColor.FormattingEnabled = True
        Me.cbxLevelColor.Location = New System.Drawing.Point(130, 218)
        Me.cbxLevelColor.Name = "cbxLevelColor"
        Me.cbxLevelColor.Size = New System.Drawing.Size(95, 21)
        Me.cbxLevelColor.TabIndex = 21
        '
        'btnClearLevel
        '
        Me.btnClearLevel.Location = New System.Drawing.Point(130, 243)
        Me.btnClearLevel.Name = "btnClearLevel"
        Me.btnClearLevel.Size = New System.Drawing.Size(100, 23)
        Me.btnClearLevel.TabIndex = 24
        Me.btnClearLevel.Text = "Clear"
        Me.btnClearLevel.UseVisualStyleBackColor = True
        '
        'btnAddLevel
        '
        Me.btnAddLevel.Location = New System.Drawing.Point(24, 243)
        Me.btnAddLevel.Name = "btnAddLevel"
        Me.btnAddLevel.Size = New System.Drawing.Size(100, 23)
        Me.btnAddLevel.TabIndex = 23
        Me.btnAddLevel.Text = "Add"
        Me.btnAddLevel.UseVisualStyleBackColor = True
        '
        'txtLevelName
        '
        Me.txtLevelName.Location = New System.Drawing.Point(24, 218)
        Me.txtLevelName.Name = "txtLevelName"
        Me.txtLevelName.Size = New System.Drawing.Size(100, 20)
        Me.txtLevelName.TabIndex = 20
        Me.txtLevelName.Tag = "0"
        '
        'btnDeleteLevel
        '
        Me.btnDeleteLevel.Enabled = False
        Me.btnDeleteLevel.Location = New System.Drawing.Point(130, 180)
        Me.btnDeleteLevel.Name = "btnDeleteLevel"
        Me.btnDeleteLevel.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteLevel.TabIndex = 19
        Me.btnDeleteLevel.Text = "Delete"
        Me.btnDeleteLevel.UseVisualStyleBackColor = True
        '
        'btnEditLevel
        '
        Me.btnEditLevel.Enabled = False
        Me.btnEditLevel.Location = New System.Drawing.Point(24, 180)
        Me.btnEditLevel.Name = "btnEditLevel"
        Me.btnEditLevel.Size = New System.Drawing.Size(100, 23)
        Me.btnEditLevel.TabIndex = 18
        Me.btnEditLevel.Text = "Edit"
        Me.btnEditLevel.UseVisualStyleBackColor = True
        '
        'lvwLevels
        '
        Me.lvwLevels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLevelName, Me.colLevelColor, Me.colLevelCount})
        Me.lvwLevels.FullRowSelect = True
        Me.lvwLevels.GridLines = True
        Me.lvwLevels.HideSelection = False
        Me.lvwLevels.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
        Me.lvwLevels.Location = New System.Drawing.Point(24, 24)
        Me.lvwLevels.MultiSelect = False
        Me.lvwLevels.Name = "lvwLevels"
        Me.lvwLevels.Size = New System.Drawing.Size(400, 150)
        Me.lvwLevels.TabIndex = 17
        Me.lvwLevels.UseCompatibleStateImageBehavior = False
        Me.lvwLevels.View = System.Windows.Forms.View.Details
        '
        'colLevelName
        '
        Me.colLevelName.Tag = "colLevelName"
        Me.colLevelName.Text = "Level"
        Me.colLevelName.Width = 141
        '
        'colLevelColor
        '
        Me.colLevelColor.Tag = "colLevelColor"
        Me.colLevelColor.Text = "Level Color"
        Me.colLevelColor.Width = 120
        '
        'colLevelCount
        '
        Me.colLevelCount.Tag = "colLevelCount"
        Me.colLevelCount.Text = "Count"
        Me.colLevelCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLevelCount.Width = 67
        '
        'tpgProducts
        '
        Me.tpgProducts.Controls.Add(Me.txtProductSort)
        Me.tpgProducts.Controls.Add(Me.cbxProductTax)
        Me.tpgProducts.Controls.Add(Me.txtProductAmount)
        Me.tpgProducts.Controls.Add(Me.txtProductCount)
        Me.tpgProducts.Controls.Add(Me.btnClearProduct)
        Me.tpgProducts.Controls.Add(Me.btnAddProduct)
        Me.tpgProducts.Controls.Add(Me.txtProduct)
        Me.tpgProducts.Controls.Add(Me.btnDeleteProduct)
        Me.tpgProducts.Controls.Add(Me.btnEditProduct)
        Me.tpgProducts.Controls.Add(Me.lvwProducts)
        Me.tpgProducts.Location = New System.Drawing.Point(4, 40)
        Me.tpgProducts.Name = "tpgProducts"
        Me.tpgProducts.Size = New System.Drawing.Size(588, 337)
        Me.tpgProducts.TabIndex = 3
        Me.tpgProducts.Tag = "tpgProducts"
        Me.tpgProducts.Text = "Products"
        Me.tpgProducts.UseVisualStyleBackColor = True
        '
        'txtProductSort
        '
        Me.txtProductSort.Location = New System.Drawing.Point(411, 218)
        Me.txtProductSort.Name = "txtProductSort"
        Me.txtProductSort.Size = New System.Drawing.Size(48, 20)
        Me.txtProductSort.TabIndex = 34
        '
        'cbxProductTax
        '
        Me.cbxProductTax.FormattingEnabled = True
        Me.cbxProductTax.Items.AddRange(New Object() {"0", "6", "21"})
        Me.cbxProductTax.Location = New System.Drawing.Point(356, 218)
        Me.cbxProductTax.Name = "cbxProductTax"
        Me.cbxProductTax.Size = New System.Drawing.Size(49, 21)
        Me.cbxProductTax.TabIndex = 31
        '
        'txtProductAmount
        '
        Me.txtProductAmount.Location = New System.Drawing.Point(302, 218)
        Me.txtProductAmount.Name = "txtProductAmount"
        Me.txtProductAmount.Size = New System.Drawing.Size(48, 20)
        Me.txtProductAmount.TabIndex = 30
        '
        'txtProductCount
        '
        Me.txtProductCount.Location = New System.Drawing.Point(248, 218)
        Me.txtProductCount.Name = "txtProductCount"
        Me.txtProductCount.Size = New System.Drawing.Size(48, 20)
        Me.txtProductCount.TabIndex = 29
        '
        'btnClearProduct
        '
        Me.btnClearProduct.Location = New System.Drawing.Point(130, 243)
        Me.btnClearProduct.Name = "btnClearProduct"
        Me.btnClearProduct.Size = New System.Drawing.Size(100, 23)
        Me.btnClearProduct.TabIndex = 33
        Me.btnClearProduct.Text = "Clear"
        Me.btnClearProduct.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Location = New System.Drawing.Point(24, 243)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(100, 23)
        Me.btnAddProduct.TabIndex = 32
        Me.btnAddProduct.Text = "Add"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'txtProduct
        '
        Me.txtProduct.Location = New System.Drawing.Point(24, 218)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(218, 20)
        Me.txtProduct.TabIndex = 28
        Me.txtProduct.Tag = "0"
        '
        'btnDeleteProduct
        '
        Me.btnDeleteProduct.Enabled = False
        Me.btnDeleteProduct.Location = New System.Drawing.Point(130, 180)
        Me.btnDeleteProduct.Name = "btnDeleteProduct"
        Me.btnDeleteProduct.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteProduct.TabIndex = 27
        Me.btnDeleteProduct.Text = "Delete"
        Me.btnDeleteProduct.UseVisualStyleBackColor = True
        '
        'btnEditProduct
        '
        Me.btnEditProduct.Enabled = False
        Me.btnEditProduct.Location = New System.Drawing.Point(24, 180)
        Me.btnEditProduct.Name = "btnEditProduct"
        Me.btnEditProduct.Size = New System.Drawing.Size(100, 23)
        Me.btnEditProduct.TabIndex = 26
        Me.btnEditProduct.Text = "Edit"
        Me.btnEditProduct.UseVisualStyleBackColor = True
        '
        'lvwProducts
        '
        Me.lvwProducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProduct, Me.colProductCount, Me.colProductAmount, Me.colProductTax, Me.colProductSort})
        Me.lvwProducts.FullRowSelect = True
        Me.lvwProducts.GridLines = True
        Me.lvwProducts.HideSelection = False
        Me.lvwProducts.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4})
        Me.lvwProducts.Location = New System.Drawing.Point(24, 24)
        Me.lvwProducts.MultiSelect = False
        Me.lvwProducts.Name = "lvwProducts"
        Me.lvwProducts.Size = New System.Drawing.Size(459, 150)
        Me.lvwProducts.TabIndex = 25
        Me.lvwProducts.UseCompatibleStateImageBehavior = False
        Me.lvwProducts.View = System.Windows.Forms.View.Details
        '
        'colProduct
        '
        Me.colProduct.Tag = "colProduct"
        Me.colProduct.Text = "Product"
        Me.colProduct.Width = 290
        '
        'colProductCount
        '
        Me.colProductCount.Tag = "colProductCount"
        Me.colProductCount.Text = "Count"
        Me.colProductCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colProductCount.Width = 74
        '
        'colProductAmount
        '
        Me.colProductAmount.Tag = "colProductAmount"
        Me.colProductAmount.Text = "Amount"
        Me.colProductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colProductAmount.Width = 69
        '
        'colProductTax
        '
        Me.colProductTax.Tag = "colProductTax"
        Me.colProductTax.Text = "Tax"
        Me.colProductTax.Width = 71
        '
        'colProductSort
        '
        Me.colProductSort.Tag = "colProductSort"
        Me.colProductSort.Text = "Sort Order"
        Me.colProductSort.Width = 79
        '
        'tpgPrContacts
        '
        Me.tpgPrContacts.Controls.Add(Me.btnClearPrContact)
        Me.tpgPrContacts.Controls.Add(Me.btnAddPrContact)
        Me.tpgPrContacts.Controls.Add(Me.txtPrContact)
        Me.tpgPrContacts.Controls.Add(Me.btnDeletePrContact)
        Me.tpgPrContacts.Controls.Add(Me.btnEditPrContact)
        Me.tpgPrContacts.Controls.Add(Me.lvwPrContacts)
        Me.tpgPrContacts.Location = New System.Drawing.Point(4, 40)
        Me.tpgPrContacts.Name = "tpgPrContacts"
        Me.tpgPrContacts.Size = New System.Drawing.Size(588, 337)
        Me.tpgPrContacts.TabIndex = 4
        Me.tpgPrContacts.Tag = "tpgPrContacts"
        Me.tpgPrContacts.Text = "Pr. Contacts"
        Me.tpgPrContacts.UseVisualStyleBackColor = True
        '
        'btnClearPrContact
        '
        Me.btnClearPrContact.Location = New System.Drawing.Point(130, 243)
        Me.btnClearPrContact.Name = "btnClearPrContact"
        Me.btnClearPrContact.Size = New System.Drawing.Size(100, 23)
        Me.btnClearPrContact.TabIndex = 39
        Me.btnClearPrContact.Text = "Clear"
        Me.btnClearPrContact.UseVisualStyleBackColor = True
        '
        'btnAddPrContact
        '
        Me.btnAddPrContact.Location = New System.Drawing.Point(24, 243)
        Me.btnAddPrContact.Name = "btnAddPrContact"
        Me.btnAddPrContact.Size = New System.Drawing.Size(100, 23)
        Me.btnAddPrContact.TabIndex = 38
        Me.btnAddPrContact.Text = "Add"
        Me.btnAddPrContact.UseVisualStyleBackColor = True
        '
        'txtPrContact
        '
        Me.txtPrContact.Location = New System.Drawing.Point(24, 218)
        Me.txtPrContact.Name = "txtPrContact"
        Me.txtPrContact.Size = New System.Drawing.Size(206, 20)
        Me.txtPrContact.TabIndex = 37
        Me.txtPrContact.Tag = "0"
        '
        'btnDeletePrContact
        '
        Me.btnDeletePrContact.Enabled = False
        Me.btnDeletePrContact.Location = New System.Drawing.Point(130, 180)
        Me.btnDeletePrContact.Name = "btnDeletePrContact"
        Me.btnDeletePrContact.Size = New System.Drawing.Size(100, 23)
        Me.btnDeletePrContact.TabIndex = 36
        Me.btnDeletePrContact.Text = "Delete"
        Me.btnDeletePrContact.UseVisualStyleBackColor = True
        '
        'btnEditPrContact
        '
        Me.btnEditPrContact.Enabled = False
        Me.btnEditPrContact.Location = New System.Drawing.Point(24, 180)
        Me.btnEditPrContact.Name = "btnEditPrContact"
        Me.btnEditPrContact.Size = New System.Drawing.Size(100, 23)
        Me.btnEditPrContact.TabIndex = 35
        Me.btnEditPrContact.Text = "Edit"
        Me.btnEditPrContact.UseVisualStyleBackColor = True
        '
        'lvwPrContacts
        '
        Me.lvwPrContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPrContacts})
        Me.lvwPrContacts.FullRowSelect = True
        Me.lvwPrContacts.GridLines = True
        Me.lvwPrContacts.HideSelection = False
        Me.lvwPrContacts.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5})
        Me.lvwPrContacts.Location = New System.Drawing.Point(24, 24)
        Me.lvwPrContacts.MultiSelect = False
        Me.lvwPrContacts.Name = "lvwPrContacts"
        Me.lvwPrContacts.Size = New System.Drawing.Size(400, 150)
        Me.lvwPrContacts.TabIndex = 34
        Me.lvwPrContacts.UseCompatibleStateImageBehavior = False
        Me.lvwPrContacts.View = System.Windows.Forms.View.Details
        '
        'colPrContacts
        '
        Me.colPrContacts.Tag = "colPrContacts"
        Me.colPrContacts.Text = "Pr. Contact"
        Me.colPrContacts.Width = 370
        '
        'tpgTax
        '
        Me.tpgTax.Controls.Add(Me.btnClearTax)
        Me.tpgTax.Controls.Add(Me.btnAddTax)
        Me.tpgTax.Controls.Add(Me.txtTaxDescription)
        Me.tpgTax.Controls.Add(Me.txtTaxValue)
        Me.tpgTax.Controls.Add(Me.btnDeleteTax)
        Me.tpgTax.Controls.Add(Me.btnEditTax)
        Me.tpgTax.Controls.Add(Me.lvwTax)
        Me.tpgTax.Location = New System.Drawing.Point(4, 40)
        Me.tpgTax.Margin = New System.Windows.Forms.Padding(2)
        Me.tpgTax.Name = "tpgTax"
        Me.tpgTax.Size = New System.Drawing.Size(588, 337)
        Me.tpgTax.TabIndex = 9
        Me.tpgTax.Tag = "tpgTax"
        Me.tpgTax.Text = "Tax"
        Me.tpgTax.UseVisualStyleBackColor = True
        '
        'btnClearTax
        '
        Me.btnClearTax.Location = New System.Drawing.Point(130, 243)
        Me.btnClearTax.Name = "btnClearTax"
        Me.btnClearTax.Size = New System.Drawing.Size(100, 23)
        Me.btnClearTax.TabIndex = 16
        Me.btnClearTax.Text = "Clear"
        Me.btnClearTax.UseVisualStyleBackColor = True
        '
        'btnAddTax
        '
        Me.btnAddTax.Location = New System.Drawing.Point(24, 243)
        Me.btnAddTax.Name = "btnAddTax"
        Me.btnAddTax.Size = New System.Drawing.Size(100, 23)
        Me.btnAddTax.TabIndex = 15
        Me.btnAddTax.Text = "Add"
        Me.btnAddTax.UseVisualStyleBackColor = True
        '
        'txtTaxDescription
        '
        Me.txtTaxDescription.Location = New System.Drawing.Point(131, 217)
        Me.txtTaxDescription.Name = "txtTaxDescription"
        Me.txtTaxDescription.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxDescription.TabIndex = 14
        '
        'txtTaxValue
        '
        Me.txtTaxValue.Location = New System.Drawing.Point(24, 217)
        Me.txtTaxValue.Name = "txtTaxValue"
        Me.txtTaxValue.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxValue.TabIndex = 13
        Me.txtTaxValue.Tag = "0"
        '
        'btnDeleteTax
        '
        Me.btnDeleteTax.Enabled = False
        Me.btnDeleteTax.Location = New System.Drawing.Point(130, 180)
        Me.btnDeleteTax.Name = "btnDeleteTax"
        Me.btnDeleteTax.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteTax.TabIndex = 12
        Me.btnDeleteTax.Text = "Delete"
        Me.btnDeleteTax.UseVisualStyleBackColor = True
        '
        'btnEditTax
        '
        Me.btnEditTax.Enabled = False
        Me.btnEditTax.Location = New System.Drawing.Point(24, 180)
        Me.btnEditTax.Name = "btnEditTax"
        Me.btnEditTax.Size = New System.Drawing.Size(100, 23)
        Me.btnEditTax.TabIndex = 11
        Me.btnEditTax.Text = "Edit"
        Me.btnEditTax.UseVisualStyleBackColor = True
        '
        'lvwTax
        '
        Me.lvwTax.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTaxValue, Me.colTaxDescription})
        Me.lvwTax.FullRowSelect = True
        Me.lvwTax.GridLines = True
        Me.lvwTax.HideSelection = False
        Me.lvwTax.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem6})
        Me.lvwTax.Location = New System.Drawing.Point(24, 24)
        Me.lvwTax.MultiSelect = False
        Me.lvwTax.Name = "lvwTax"
        Me.lvwTax.Size = New System.Drawing.Size(400, 150)
        Me.lvwTax.TabIndex = 10
        Me.lvwTax.UseCompatibleStateImageBehavior = False
        Me.lvwTax.View = System.Windows.Forms.View.Details
        '
        'colTaxValue
        '
        Me.colTaxValue.Tag = "colTaxValue"
        Me.colTaxValue.Text = "Tax Value"
        Me.colTaxValue.Width = 131
        '
        'colTaxDescription
        '
        Me.colTaxDescription.Tag = "colTaxDescription"
        Me.colTaxDescription.Text = "Tax Description"
        Me.colTaxDescription.Width = 140
        '
        'tpgLogging
        '
        Me.tpgLogging.Controls.Add(Me.btnLogToDatabase)
        Me.tpgLogging.Controls.Add(Me.grpLogsToKeep)
        Me.tpgLogging.Controls.Add(Me.txtLogfileLocation)
        Me.tpgLogging.Controls.Add(Me.txtLogfileName)
        Me.tpgLogging.Controls.Add(Me.btnSaveSettingsLog)
        Me.tpgLogging.Controls.Add(Me.lblLogfileName)
        Me.tpgLogging.Controls.Add(Me.lblLogfileLocation)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel5)
        Me.tpgLogging.Controls.Add(Me.lblLoggingLevel)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel1)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel2)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel3)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel4)
        Me.tpgLogging.Controls.Add(Me.rbtLoggingLevel0)
        Me.tpgLogging.Location = New System.Drawing.Point(4, 40)
        Me.tpgLogging.Name = "tpgLogging"
        Me.tpgLogging.Size = New System.Drawing.Size(588, 337)
        Me.tpgLogging.TabIndex = 6
        Me.tpgLogging.Tag = "tpgLogging"
        Me.tpgLogging.Text = "Logging"
        Me.tpgLogging.UseVisualStyleBackColor = True
        '
        'btnLogToDatabase
        '
        Me.btnLogToDatabase.Location = New System.Drawing.Point(165, 251)
        Me.btnLogToDatabase.Name = "btnLogToDatabase"
        Me.btnLogToDatabase.Size = New System.Drawing.Size(140, 23)
        Me.btnLogToDatabase.TabIndex = 62
        Me.btnLogToDatabase.Text = "Log to Database"
        Me.btnLogToDatabase.UseVisualStyleBackColor = True
        '
        'grpLogsToKeep
        '
        Me.grpLogsToKeep.Controls.Add(Me.chkAutoDeleteOldLogs)
        Me.grpLogsToKeep.Controls.Add(Me.btnClearOldLogs)
        Me.grpLogsToKeep.Controls.Add(Me.rbtKeepLogMonth)
        Me.grpLogsToKeep.Controls.Add(Me.rbtKeepLogWeek)
        Me.grpLogsToKeep.Controls.Add(Me.rbtKeepLogDay)
        Me.grpLogsToKeep.Location = New System.Drawing.Point(389, 94)
        Me.grpLogsToKeep.Margin = New System.Windows.Forms.Padding(2)
        Me.grpLogsToKeep.Name = "grpLogsToKeep"
        Me.grpLogsToKeep.Padding = New System.Windows.Forms.Padding(2)
        Me.grpLogsToKeep.Size = New System.Drawing.Size(152, 149)
        Me.grpLogsToKeep.TabIndex = 55
        Me.grpLogsToKeep.TabStop = False
        Me.grpLogsToKeep.Text = "Remove Logs older than:"
        Me.grpLogsToKeep.Visible = False
        '
        'chkAutoDeleteOldLogs
        '
        Me.chkAutoDeleteOldLogs.AutoSize = True
        Me.chkAutoDeleteOldLogs.Location = New System.Drawing.Point(8, 119)
        Me.chkAutoDeleteOldLogs.Name = "chkAutoDeleteOldLogs"
        Me.chkAutoDeleteOldLogs.Size = New System.Drawing.Size(119, 17)
        Me.chkAutoDeleteOldLogs.TabIndex = 61
        Me.chkAutoDeleteOldLogs.Text = "Auto delete old logs"
        Me.chkAutoDeleteOldLogs.UseVisualStyleBackColor = True
        '
        'btnClearOldLogs
        '
        Me.btnClearOldLogs.Location = New System.Drawing.Point(8, 86)
        Me.btnClearOldLogs.Name = "btnClearOldLogs"
        Me.btnClearOldLogs.Size = New System.Drawing.Size(140, 23)
        Me.btnClearOldLogs.TabIndex = 57
        Me.btnClearOldLogs.Text = "Clear Old Logs"
        Me.btnClearOldLogs.UseVisualStyleBackColor = True
        '
        'rbtKeepLogMonth
        '
        Me.rbtKeepLogMonth.AutoSize = True
        Me.rbtKeepLogMonth.Checked = True
        Me.rbtKeepLogMonth.Location = New System.Drawing.Point(8, 63)
        Me.rbtKeepLogMonth.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtKeepLogMonth.Name = "rbtKeepLogMonth"
        Me.rbtKeepLogMonth.Size = New System.Drawing.Size(55, 17)
        Me.rbtKeepLogMonth.TabIndex = 58
        Me.rbtKeepLogMonth.TabStop = True
        Me.rbtKeepLogMonth.Text = "Month"
        Me.rbtKeepLogMonth.UseVisualStyleBackColor = True
        '
        'rbtKeepLogWeek
        '
        Me.rbtKeepLogWeek.AutoSize = True
        Me.rbtKeepLogWeek.Location = New System.Drawing.Point(8, 41)
        Me.rbtKeepLogWeek.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtKeepLogWeek.Name = "rbtKeepLogWeek"
        Me.rbtKeepLogWeek.Size = New System.Drawing.Size(54, 17)
        Me.rbtKeepLogWeek.TabIndex = 59
        Me.rbtKeepLogWeek.Text = "Week"
        Me.rbtKeepLogWeek.UseVisualStyleBackColor = True
        '
        'rbtKeepLogDay
        '
        Me.rbtKeepLogDay.AutoSize = True
        Me.rbtKeepLogDay.Location = New System.Drawing.Point(8, 20)
        Me.rbtKeepLogDay.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtKeepLogDay.Name = "rbtKeepLogDay"
        Me.rbtKeepLogDay.Size = New System.Drawing.Size(44, 17)
        Me.rbtKeepLogDay.TabIndex = 60
        Me.rbtKeepLogDay.Text = "Day"
        Me.rbtKeepLogDay.UseVisualStyleBackColor = True
        '
        'txtLogfileLocation
        '
        Me.txtLogfileLocation.Location = New System.Drawing.Point(165, 225)
        Me.txtLogfileLocation.Name = "txtLogfileLocation"
        Me.txtLogfileLocation.Size = New System.Drawing.Size(190, 20)
        Me.txtLogfileLocation.TabIndex = 47
        '
        'txtLogfileName
        '
        Me.txtLogfileName.Location = New System.Drawing.Point(165, 199)
        Me.txtLogfileName.Name = "txtLogfileName"
        Me.txtLogfileName.Size = New System.Drawing.Size(190, 20)
        Me.txtLogfileName.TabIndex = 46
        Me.txtLogfileName.Text = "TrackManData.log"
        '
        'lblLogfileName
        '
        Me.lblLogfileName.AutoSize = True
        Me.lblLogfileName.Location = New System.Drawing.Point(24, 202)
        Me.lblLogfileName.Name = "lblLogfileName"
        Me.lblLogfileName.Size = New System.Drawing.Size(69, 13)
        Me.lblLogfileName.TabIndex = 8
        Me.lblLogfileName.Text = "Logfile Name"
        '
        'lblLogfileLocation
        '
        Me.lblLogfileLocation.AutoSize = True
        Me.lblLogfileLocation.Location = New System.Drawing.Point(24, 228)
        Me.lblLogfileLocation.Name = "lblLogfileLocation"
        Me.lblLogfileLocation.Size = New System.Drawing.Size(82, 13)
        Me.lblLogfileLocation.TabIndex = 7
        Me.lblLogfileLocation.Text = "Logfile Location"
        '
        'rbtLoggingLevel5
        '
        Me.rbtLoggingLevel5.AutoSize = True
        Me.rbtLoggingLevel5.Location = New System.Drawing.Point(27, 163)
        Me.rbtLoggingLevel5.Name = "rbtLoggingLevel5"
        Me.rbtLoggingLevel5.Size = New System.Drawing.Size(172, 17)
        Me.rbtLoggingLevel5.TabIndex = 45
        Me.rbtLoggingLevel5.Text = "All (includes Database Queries)"
        Me.rbtLoggingLevel5.UseVisualStyleBackColor = True
        '
        'lblLoggingLevel
        '
        Me.lblLoggingLevel.AutoSize = True
        Me.lblLoggingLevel.Location = New System.Drawing.Point(24, 24)
        Me.lblLoggingLevel.Name = "lblLoggingLevel"
        Me.lblLoggingLevel.Size = New System.Drawing.Size(74, 13)
        Me.lblLoggingLevel.TabIndex = 5
        Me.lblLoggingLevel.Text = "Logging Level"
        '
        'rbtLoggingLevel1
        '
        Me.rbtLoggingLevel1.AutoSize = True
        Me.rbtLoggingLevel1.Checked = True
        Me.rbtLoggingLevel1.Location = New System.Drawing.Point(27, 71)
        Me.rbtLoggingLevel1.Name = "rbtLoggingLevel1"
        Me.rbtLoggingLevel1.Size = New System.Drawing.Size(102, 17)
        Me.rbtLoggingLevel1.TabIndex = 41
        Me.rbtLoggingLevel1.TabStop = True
        Me.rbtLoggingLevel1.Text = "Low (errors only)"
        Me.rbtLoggingLevel1.UseVisualStyleBackColor = True
        '
        'rbtLoggingLevel2
        '
        Me.rbtLoggingLevel2.AutoSize = True
        Me.rbtLoggingLevel2.Location = New System.Drawing.Point(27, 94)
        Me.rbtLoggingLevel2.Name = "rbtLoggingLevel2"
        Me.rbtLoggingLevel2.Size = New System.Drawing.Size(186, 17)
        Me.rbtLoggingLevel2.TabIndex = 42
        Me.rbtLoggingLevel2.Text = "Medium (includes program events)"
        Me.rbtLoggingLevel2.UseVisualStyleBackColor = True
        '
        'rbtLoggingLevel3
        '
        Me.rbtLoggingLevel3.AutoSize = True
        Me.rbtLoggingLevel3.Location = New System.Drawing.Point(27, 117)
        Me.rbtLoggingLevel3.Name = "rbtLoggingLevel3"
        Me.rbtLoggingLevel3.Size = New System.Drawing.Size(194, 17)
        Me.rbtLoggingLevel3.TabIndex = 43
        Me.rbtLoggingLevel3.Text = "Medium-High (Includes user events)"
        Me.rbtLoggingLevel3.UseVisualStyleBackColor = True
        '
        'rbtLoggingLevel4
        '
        Me.rbtLoggingLevel4.AutoSize = True
        Me.rbtLoggingLevel4.Location = New System.Drawing.Point(27, 140)
        Me.rbtLoggingLevel4.Name = "rbtLoggingLevel4"
        Me.rbtLoggingLevel4.Size = New System.Drawing.Size(229, 17)
        Me.rbtLoggingLevel4.TabIndex = 44
        Me.rbtLoggingLevel4.Text = "High (Everything except Database Queries)"
        Me.rbtLoggingLevel4.UseVisualStyleBackColor = True
        '
        'rbtLoggingLevel0
        '
        Me.rbtLoggingLevel0.AutoSize = True
        Me.rbtLoggingLevel0.Location = New System.Drawing.Point(27, 48)
        Me.rbtLoggingLevel0.Name = "rbtLoggingLevel0"
        Me.rbtLoggingLevel0.Size = New System.Drawing.Size(196, 17)
        Me.rbtLoggingLevel0.TabIndex = 40
        Me.rbtLoggingLevel0.Text = "Off (Program Startup && Security only)"
        Me.rbtLoggingLevel0.UseVisualStyleBackColor = True
        '
        'tpgView
        '
        Me.tpgView.Controls.Add(Me.cbxClientFieldHeight)
        Me.tpgView.Controls.Add(Me.lblClientFieldHeight)
        Me.tpgView.Controls.Add(Me.chkShowAgeAfter)
        Me.tpgView.Controls.Add(Me.txtShowAgeMax)
        Me.tpgView.Controls.Add(Me.chkShowAge)
        Me.tpgView.Controls.Add(Me.cbxUseFadingColors)
        Me.tpgView.Controls.Add(Me.lblUseFadingColors)
        Me.tpgView.Controls.Add(Me.dtmSeasonStart)
        Me.tpgView.Controls.Add(Me.cbxSeasonLength)
        Me.tpgView.Controls.Add(Me.lblSeasonStart)
        Me.tpgView.Controls.Add(Me.lblSeasonLength)
        Me.tpgView.Controls.Add(Me.lblReadOnlyBackColor)
        Me.tpgView.Controls.Add(Me.cbxReadOnlyBackColor)
        Me.tpgView.Controls.Add(Me.txtTimeFrame)
        Me.tpgView.Controls.Add(Me.dtpClosingHour)
        Me.tpgView.Controls.Add(Me.dtpOpeningHour)
        Me.tpgView.Controls.Add(Me.lblTimeFrame)
        Me.tpgView.Controls.Add(Me.txtDefFinanceRows)
        Me.tpgView.Controls.Add(Me.lblDefFinanceRows)
        Me.tpgView.Controls.Add(Me.cbxShowTimeWithTrack)
        Me.tpgView.Controls.Add(Me.lblShowTimeWithTrack)
        Me.tpgView.Controls.Add(Me.btnSaveSettingsView)
        Me.tpgView.Controls.Add(Me.cbxOnHoursColor)
        Me.tpgView.Controls.Add(Me.cbxOffHoursColor)
        Me.tpgView.Controls.Add(Me.cbxShowTeacherColumn)
        Me.tpgView.Controls.Add(Me.cbxShowClosedHours)
        Me.tpgView.Controls.Add(Me.txtClientsPerTrack)
        Me.tpgView.Controls.Add(Me.txtClientsPerGroup)
        Me.tpgView.Controls.Add(Me.txtClientFieldWidth)
        Me.tpgView.Controls.Add(Me.lblClientsPerTrack)
        Me.tpgView.Controls.Add(Me.lblClientsPerGroup)
        Me.tpgView.Controls.Add(Me.lblOpeningHour)
        Me.tpgView.Controls.Add(Me.lblClosingHour)
        Me.tpgView.Controls.Add(Me.lblShowClosedHours)
        Me.tpgView.Controls.Add(Me.lblOnHoursColor)
        Me.tpgView.Controls.Add(Me.lblOffHoursColor)
        Me.tpgView.Controls.Add(Me.lblShowTeacherColumn)
        Me.tpgView.Controls.Add(Me.lblClientFieldWidth)
        Me.tpgView.Location = New System.Drawing.Point(4, 40)
        Me.tpgView.Name = "tpgView"
        Me.tpgView.Size = New System.Drawing.Size(588, 337)
        Me.tpgView.TabIndex = 5
        Me.tpgView.Tag = "tpgView"
        Me.tpgView.Text = "View"
        Me.tpgView.UseVisualStyleBackColor = True
        '
        'cbxClientFieldHeight
        '
        Me.cbxClientFieldHeight.FormattingEnabled = True
        Me.cbxClientFieldHeight.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbxClientFieldHeight.Location = New System.Drawing.Point(157, 111)
        Me.cbxClientFieldHeight.Name = "cbxClientFieldHeight"
        Me.cbxClientFieldHeight.Size = New System.Drawing.Size(54, 21)
        Me.cbxClientFieldHeight.TabIndex = 78
        Me.cbxClientFieldHeight.Text = "1"
        Me.cbxClientFieldHeight.UseWaitCursor = True
        '
        'lblClientFieldHeight
        '
        Me.lblClientFieldHeight.AutoSize = True
        Me.lblClientFieldHeight.Location = New System.Drawing.Point(16, 114)
        Me.lblClientFieldHeight.Name = "lblClientFieldHeight"
        Me.lblClientFieldHeight.Size = New System.Drawing.Size(92, 13)
        Me.lblClientFieldHeight.TabIndex = 77
        Me.lblClientFieldHeight.Text = "Client Field Height"
        '
        'chkShowAgeAfter
        '
        Me.chkShowAgeAfter.AutoSize = True
        Me.chkShowAgeAfter.Enabled = False
        Me.chkShowAgeAfter.Location = New System.Drawing.Point(290, 135)
        Me.chkShowAgeAfter.Name = "chkShowAgeAfter"
        Me.chkShowAgeAfter.Size = New System.Drawing.Size(248, 17)
        Me.chkShowAgeAfter.TabIndex = 76
        Me.chkShowAgeAfter.Text = "Show Client Age after Appointment i.s.o. before"
        Me.chkShowAgeAfter.UseVisualStyleBackColor = True
        '
        'txtShowAgeMax
        '
        Me.txtShowAgeMax.Enabled = False
        Me.txtShowAgeMax.Location = New System.Drawing.Point(518, 110)
        Me.txtShowAgeMax.Name = "txtShowAgeMax"
        Me.txtShowAgeMax.Size = New System.Drawing.Size(43, 20)
        Me.txtShowAgeMax.TabIndex = 75
        Me.txtShowAgeMax.Text = "10"
        '
        'chkShowAge
        '
        Me.chkShowAge.AutoSize = True
        Me.chkShowAge.Location = New System.Drawing.Point(290, 110)
        Me.chkShowAge.Name = "chkShowAge"
        Me.chkShowAge.Size = New System.Drawing.Size(226, 17)
        Me.chkShowAge.TabIndex = 74
        Me.chkShowAge.Text = "Show Client age on Appointment until age:"
        Me.chkShowAge.UseVisualStyleBackColor = True
        '
        'cbxUseFadingColors
        '
        Me.cbxUseFadingColors.FormattingEnabled = True
        Me.cbxUseFadingColors.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbxUseFadingColors.Location = New System.Drawing.Point(434, 231)
        Me.cbxUseFadingColors.Name = "cbxUseFadingColors"
        Me.cbxUseFadingColors.Size = New System.Drawing.Size(50, 21)
        Me.cbxUseFadingColors.TabIndex = 69
        Me.cbxUseFadingColors.Text = "No"
        '
        'lblUseFadingColors
        '
        Me.lblUseFadingColors.AutoSize = True
        Me.lblUseFadingColors.Location = New System.Drawing.Point(283, 234)
        Me.lblUseFadingColors.Name = "lblUseFadingColors"
        Me.lblUseFadingColors.Size = New System.Drawing.Size(93, 13)
        Me.lblUseFadingColors.TabIndex = 68
        Me.lblUseFadingColors.Text = "Use Fading Colors"
        '
        'dtmSeasonStart
        '
        Me.dtmSeasonStart.CustomFormat = "dd MMM yyyy"
        Me.dtmSeasonStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtmSeasonStart.Location = New System.Drawing.Point(157, 280)
        Me.dtmSeasonStart.Name = "dtmSeasonStart"
        Me.dtmSeasonStart.Size = New System.Drawing.Size(101, 20)
        Me.dtmSeasonStart.TabIndex = 59
        '
        'cbxSeasonLength
        '
        Me.cbxSeasonLength.FormattingEnabled = True
        Me.cbxSeasonLength.Items.AddRange(New Object() {"Year", "6 Months", "Quarter", "Month"})
        Me.cbxSeasonLength.Location = New System.Drawing.Point(157, 304)
        Me.cbxSeasonLength.Name = "cbxSeasonLength"
        Me.cbxSeasonLength.Size = New System.Drawing.Size(101, 21)
        Me.cbxSeasonLength.TabIndex = 60
        Me.cbxSeasonLength.Text = "Year"
        '
        'lblSeasonStart
        '
        Me.lblSeasonStart.AutoSize = True
        Me.lblSeasonStart.Location = New System.Drawing.Point(16, 286)
        Me.lblSeasonStart.Name = "lblSeasonStart"
        Me.lblSeasonStart.Size = New System.Drawing.Size(68, 13)
        Me.lblSeasonStart.TabIndex = 42
        Me.lblSeasonStart.Text = "Season Start"
        '
        'lblSeasonLength
        '
        Me.lblSeasonLength.AutoSize = True
        Me.lblSeasonLength.Location = New System.Drawing.Point(16, 307)
        Me.lblSeasonLength.Name = "lblSeasonLength"
        Me.lblSeasonLength.Size = New System.Drawing.Size(79, 13)
        Me.lblSeasonLength.TabIndex = 41
        Me.lblSeasonLength.Text = "Season Length"
        '
        'lblReadOnlyBackColor
        '
        Me.lblReadOnlyBackColor.AutoSize = True
        Me.lblReadOnlyBackColor.Location = New System.Drawing.Point(284, 307)
        Me.lblReadOnlyBackColor.Name = "lblReadOnlyBackColor"
        Me.lblReadOnlyBackColor.Size = New System.Drawing.Size(118, 13)
        Me.lblReadOnlyBackColor.TabIndex = 34
        Me.lblReadOnlyBackColor.Text = "Read Only Background"
        '
        'cbxReadOnlyBackColor
        '
        Me.cbxReadOnlyBackColor.FormattingEnabled = True
        Me.cbxReadOnlyBackColor.Items.AddRange(New Object() {"PowderBlue"})
        Me.cbxReadOnlyBackColor.Location = New System.Drawing.Point(434, 304)
        Me.cbxReadOnlyBackColor.Name = "cbxReadOnlyBackColor"
        Me.cbxReadOnlyBackColor.Size = New System.Drawing.Size(128, 21)
        Me.cbxReadOnlyBackColor.TabIndex = 58
        Me.cbxReadOnlyBackColor.Text = "WhiteSmoke"
        '
        'txtTimeFrame
        '
        Me.txtTimeFrame.Location = New System.Drawing.Point(157, 256)
        Me.txtTimeFrame.Name = "txtTimeFrame"
        Me.txtTimeFrame.Size = New System.Drawing.Size(54, 20)
        Me.txtTimeFrame.TabIndex = 55
        Me.txtTimeFrame.Text = "60"
        '
        'dtpClosingHour
        '
        Me.dtpClosingHour.CustomFormat = "HH:mm"
        Me.dtpClosingHour.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpClosingHour.Location = New System.Drawing.Point(157, 232)
        Me.dtpClosingHour.Name = "dtpClosingHour"
        Me.dtpClosingHour.ShowUpDown = True
        Me.dtpClosingHour.Size = New System.Drawing.Size(54, 20)
        Me.dtpClosingHour.TabIndex = 54
        Me.dtpClosingHour.Value = New Date(2008, 1, 1, 0, 0, 0, 0)
        '
        'dtpOpeningHour
        '
        Me.dtpOpeningHour.CustomFormat = "HH:mm"
        Me.dtpOpeningHour.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOpeningHour.Location = New System.Drawing.Point(157, 208)
        Me.dtpOpeningHour.Name = "dtpOpeningHour"
        Me.dtpOpeningHour.ShowUpDown = True
        Me.dtpOpeningHour.Size = New System.Drawing.Size(54, 20)
        Me.dtpOpeningHour.TabIndex = 53
        Me.dtpOpeningHour.Value = New Date(2008, 1, 1, 0, 0, 0, 0)
        '
        'lblTimeFrame
        '
        Me.lblTimeFrame.AutoSize = True
        Me.lblTimeFrame.Location = New System.Drawing.Point(16, 259)
        Me.lblTimeFrame.Name = "lblTimeFrame"
        Me.lblTimeFrame.Size = New System.Drawing.Size(107, 13)
        Me.lblTimeFrame.TabIndex = 28
        Me.lblTimeFrame.Text = "Time Frame (minutes)"
        '
        'txtDefFinanceRows
        '
        Me.txtDefFinanceRows.Location = New System.Drawing.Point(157, 184)
        Me.txtDefFinanceRows.Name = "txtDefFinanceRows"
        Me.txtDefFinanceRows.Size = New System.Drawing.Size(54, 20)
        Me.txtDefFinanceRows.TabIndex = 52
        Me.txtDefFinanceRows.Text = "20"
        '
        'lblDefFinanceRows
        '
        Me.lblDefFinanceRows.AutoSize = True
        Me.lblDefFinanceRows.Location = New System.Drawing.Point(16, 187)
        Me.lblDefFinanceRows.Name = "lblDefFinanceRows"
        Me.lblDefFinanceRows.Size = New System.Drawing.Size(107, 13)
        Me.lblDefFinanceRows.TabIndex = 26
        Me.lblDefFinanceRows.Text = "Default Finance rows"
        '
        'cbxShowTimeWithTrack
        '
        Me.cbxShowTimeWithTrack.FormattingEnabled = True
        Me.cbxShowTimeWithTrack.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbxShowTimeWithTrack.Location = New System.Drawing.Point(434, 207)
        Me.cbxShowTimeWithTrack.Name = "cbxShowTimeWithTrack"
        Me.cbxShowTimeWithTrack.Size = New System.Drawing.Size(50, 21)
        Me.cbxShowTimeWithTrack.TabIndex = 66
        Me.cbxShowTimeWithTrack.Text = "Yes"
        '
        'lblShowTimeWithTrack
        '
        Me.lblShowTimeWithTrack.AutoSize = True
        Me.lblShowTimeWithTrack.Location = New System.Drawing.Point(284, 210)
        Me.lblShowTimeWithTrack.Name = "lblShowTimeWithTrack"
        Me.lblShowTimeWithTrack.Size = New System.Drawing.Size(116, 13)
        Me.lblShowTimeWithTrack.TabIndex = 24
        Me.lblShowTimeWithTrack.Text = "Show Time With Track"
        '
        'btnSaveSettingsView
        '
        Me.btnSaveSettingsView.Enabled = False
        Me.btnSaveSettingsView.Location = New System.Drawing.Point(442, 18)
        Me.btnSaveSettingsView.Name = "btnSaveSettingsView"
        Me.btnSaveSettingsView.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveSettingsView.TabIndex = 67
        Me.btnSaveSettingsView.Text = "Save Settings"
        Me.btnSaveSettingsView.UseVisualStyleBackColor = True
        '
        'cbxOnHoursColor
        '
        Me.cbxOnHoursColor.FormattingEnabled = True
        Me.cbxOnHoursColor.Items.AddRange(New Object() {"White"})
        Me.cbxOnHoursColor.Location = New System.Drawing.Point(433, 256)
        Me.cbxOnHoursColor.Name = "cbxOnHoursColor"
        Me.cbxOnHoursColor.Size = New System.Drawing.Size(128, 21)
        Me.cbxOnHoursColor.TabIndex = 56
        Me.cbxOnHoursColor.Text = "White"
        '
        'cbxOffHoursColor
        '
        Me.cbxOffHoursColor.FormattingEnabled = True
        Me.cbxOffHoursColor.Items.AddRange(New Object() {"PowderBlue"})
        Me.cbxOffHoursColor.Location = New System.Drawing.Point(433, 283)
        Me.cbxOffHoursColor.Name = "cbxOffHoursColor"
        Me.cbxOffHoursColor.Size = New System.Drawing.Size(128, 21)
        Me.cbxOffHoursColor.TabIndex = 57
        Me.cbxOffHoursColor.Text = "PowderBlue"
        '
        'cbxShowTeacherColumn
        '
        Me.cbxShowTeacherColumn.FormattingEnabled = True
        Me.cbxShowTeacherColumn.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbxShowTeacherColumn.Location = New System.Drawing.Point(433, 183)
        Me.cbxShowTeacherColumn.Name = "cbxShowTeacherColumn"
        Me.cbxShowTeacherColumn.Size = New System.Drawing.Size(50, 21)
        Me.cbxShowTeacherColumn.TabIndex = 65
        Me.cbxShowTeacherColumn.Text = "Yes"
        '
        'cbxShowClosedHours
        '
        Me.cbxShowClosedHours.FormattingEnabled = True
        Me.cbxShowClosedHours.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbxShowClosedHours.Location = New System.Drawing.Point(433, 159)
        Me.cbxShowClosedHours.Name = "cbxShowClosedHours"
        Me.cbxShowClosedHours.Size = New System.Drawing.Size(50, 21)
        Me.cbxShowClosedHours.TabIndex = 64
        Me.cbxShowClosedHours.Text = "No"
        '
        'txtClientsPerTrack
        '
        Me.txtClientsPerTrack.Location = New System.Drawing.Point(157, 136)
        Me.txtClientsPerTrack.Name = "txtClientsPerTrack"
        Me.txtClientsPerTrack.Size = New System.Drawing.Size(54, 20)
        Me.txtClientsPerTrack.TabIndex = 50
        Me.txtClientsPerTrack.Text = "4"
        '
        'txtClientsPerGroup
        '
        Me.txtClientsPerGroup.Location = New System.Drawing.Point(157, 160)
        Me.txtClientsPerGroup.Name = "txtClientsPerGroup"
        Me.txtClientsPerGroup.Size = New System.Drawing.Size(54, 20)
        Me.txtClientsPerGroup.TabIndex = 51
        Me.txtClientsPerGroup.Text = "20"
        '
        'txtClientFieldWidth
        '
        Me.txtClientFieldWidth.Location = New System.Drawing.Point(157, 87)
        Me.txtClientFieldWidth.Name = "txtClientFieldWidth"
        Me.txtClientFieldWidth.Size = New System.Drawing.Size(54, 20)
        Me.txtClientFieldWidth.TabIndex = 49
        Me.txtClientFieldWidth.Text = "50"
        '
        'lblClientsPerTrack
        '
        Me.lblClientsPerTrack.AutoSize = True
        Me.lblClientsPerTrack.Location = New System.Drawing.Point(16, 139)
        Me.lblClientsPerTrack.Name = "lblClientsPerTrack"
        Me.lblClientsPerTrack.Size = New System.Drawing.Size(88, 13)
        Me.lblClientsPerTrack.TabIndex = 10
        Me.lblClientsPerTrack.Text = "Clients Per Track"
        '
        'lblClientsPerGroup
        '
        Me.lblClientsPerGroup.AutoSize = True
        Me.lblClientsPerGroup.Location = New System.Drawing.Point(16, 163)
        Me.lblClientsPerGroup.Name = "lblClientsPerGroup"
        Me.lblClientsPerGroup.Size = New System.Drawing.Size(125, 13)
        Me.lblClientsPerGroup.TabIndex = 9
        Me.lblClientsPerGroup.Text = "Default Clients per Group"
        '
        'lblOpeningHour
        '
        Me.lblOpeningHour.AutoSize = True
        Me.lblOpeningHour.Location = New System.Drawing.Point(16, 214)
        Me.lblOpeningHour.Name = "lblOpeningHour"
        Me.lblOpeningHour.Size = New System.Drawing.Size(73, 13)
        Me.lblOpeningHour.TabIndex = 8
        Me.lblOpeningHour.Text = "Opening Hour"
        '
        'lblClosingHour
        '
        Me.lblClosingHour.AutoSize = True
        Me.lblClosingHour.Location = New System.Drawing.Point(17, 238)
        Me.lblClosingHour.Name = "lblClosingHour"
        Me.lblClosingHour.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingHour.TabIndex = 7
        Me.lblClosingHour.Text = "Closing Hour"
        '
        'lblShowClosedHours
        '
        Me.lblShowClosedHours.AutoSize = True
        Me.lblShowClosedHours.Location = New System.Drawing.Point(287, 162)
        Me.lblShowClosedHours.Name = "lblShowClosedHours"
        Me.lblShowClosedHours.Size = New System.Drawing.Size(100, 13)
        Me.lblShowClosedHours.TabIndex = 6
        Me.lblShowClosedHours.Text = "Show Closed Hours"
        '
        'lblOnHoursColor
        '
        Me.lblOnHoursColor.AutoSize = True
        Me.lblOnHoursColor.Location = New System.Drawing.Point(284, 259)
        Me.lblOnHoursColor.Name = "lblOnHoursColor"
        Me.lblOnHoursColor.Size = New System.Drawing.Size(78, 13)
        Me.lblOnHoursColor.TabIndex = 5
        Me.lblOnHoursColor.Text = "On Hours color"
        '
        'lblOffHoursColor
        '
        Me.lblOffHoursColor.AutoSize = True
        Me.lblOffHoursColor.Location = New System.Drawing.Point(284, 286)
        Me.lblOffHoursColor.Name = "lblOffHoursColor"
        Me.lblOffHoursColor.Size = New System.Drawing.Size(79, 13)
        Me.lblOffHoursColor.TabIndex = 4
        Me.lblOffHoursColor.Text = "Off Hours Color"
        '
        'lblShowTeacherColumn
        '
        Me.lblShowTeacherColumn.AutoSize = True
        Me.lblShowTeacherColumn.Location = New System.Drawing.Point(287, 186)
        Me.lblShowTeacherColumn.Name = "lblShowTeacherColumn"
        Me.lblShowTeacherColumn.Size = New System.Drawing.Size(115, 13)
        Me.lblShowTeacherColumn.TabIndex = 2
        Me.lblShowTeacherColumn.Text = "Show Teacher Column"
        '
        'lblClientFieldWidth
        '
        Me.lblClientFieldWidth.AutoSize = True
        Me.lblClientFieldWidth.Location = New System.Drawing.Point(17, 90)
        Me.lblClientFieldWidth.Name = "lblClientFieldWidth"
        Me.lblClientFieldWidth.Size = New System.Drawing.Size(89, 13)
        Me.lblClientFieldWidth.TabIndex = 0
        Me.lblClientFieldWidth.Text = "Client Field Width"
        '
        'tpgDatabase
        '
        Me.tpgDatabase.Controls.Add(Me.btnRefreshDatabase)
        Me.tpgDatabase.Controls.Add(Me.Button1)
        Me.tpgDatabase.Controls.Add(Me.btnTestConnection)
        Me.tpgDatabase.Controls.Add(Me.lblBackupPath)
        Me.tpgDatabase.Controls.Add(Me.txtBackupDatabase)
        Me.tpgDatabase.Controls.Add(Me.lblBackupDatabase)
        Me.tpgDatabase.Controls.Add(Me.btnBackupDatabase)
        Me.tpgDatabase.Controls.Add(Me.txtUpgradeDatabase)
        Me.tpgDatabase.Controls.Add(Me.lblDatabaseVersion)
        Me.tpgDatabase.Controls.Add(Me.btnUpgradeDatabase)
        Me.tpgDatabase.Controls.Add(Me.prbCreateDatabase)
        Me.tpgDatabase.Controls.Add(Me.btnCreateDemoData)
        Me.tpgDatabase.Controls.Add(Me.btnCreateDatabase)
        Me.tpgDatabase.Controls.Add(Me.btnSaveSettingsDatabase)
        Me.tpgDatabase.Controls.Add(Me.btnUseDefaults)
        Me.tpgDatabase.Controls.Add(Me.lblLoginMethod)
        Me.tpgDatabase.Controls.Add(Me.lblLoginName)
        Me.tpgDatabase.Controls.Add(Me.lblPassword)
        Me.tpgDatabase.Controls.Add(Me.txtPassword)
        Me.tpgDatabase.Controls.Add(Me.cbxLoginMethod)
        Me.tpgDatabase.Controls.Add(Me.txtLoginName)
        Me.tpgDatabase.Controls.Add(Me.lblDatabaseName)
        Me.tpgDatabase.Controls.Add(Me.txtDatabaseName)
        Me.tpgDatabase.Controls.Add(Me.lblDatabaseLocation)
        Me.tpgDatabase.Controls.Add(Me.cbxDataProvider)
        Me.tpgDatabase.Controls.Add(Me.txtDatabaseLocation)
        Me.tpgDatabase.Controls.Add(Me.lblDataProvider)
        Me.tpgDatabase.Controls.Add(Me.lblStatusDatabase)
        Me.tpgDatabase.Location = New System.Drawing.Point(4, 40)
        Me.tpgDatabase.Name = "tpgDatabase"
        Me.tpgDatabase.Size = New System.Drawing.Size(588, 337)
        Me.tpgDatabase.TabIndex = 7
        Me.tpgDatabase.Tag = "tpgDatabase"
        Me.tpgDatabase.Text = "Database"
        Me.tpgDatabase.UseVisualStyleBackColor = True
        '
        'btnRefreshDatabase
        '
        Me.btnRefreshDatabase.Location = New System.Drawing.Point(442, 229)
        Me.btnRefreshDatabase.Name = "btnRefreshDatabase"
        Me.btnRefreshDatabase.Size = New System.Drawing.Size(120, 23)
        Me.btnRefreshDatabase.TabIndex = 89
        Me.btnRefreshDatabase.Text = "Refresh Database"
        Me.btnRefreshDatabase.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(360, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 88
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(442, 47)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(120, 23)
        Me.btnTestConnection.TabIndex = 87
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'lblBackupPath
        '
        Me.lblBackupPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackupPath.Location = New System.Drawing.Point(26, 280)
        Me.lblBackupPath.Name = "lblBackupPath"
        Me.lblBackupPath.Size = New System.Drawing.Size(328, 31)
        Me.lblBackupPath.TabIndex = 86
        Me.lblBackupPath.Text = "This must be a valid location on the PC or Server where the database resides"
        '
        'txtBackupDatabase
        '
        Me.txtBackupDatabase.Location = New System.Drawing.Point(165, 260)
        Me.txtBackupDatabase.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBackupDatabase.Name = "txtBackupDatabase"
        Me.txtBackupDatabase.Size = New System.Drawing.Size(190, 20)
        Me.txtBackupDatabase.TabIndex = 85
        '
        'lblBackupDatabase
        '
        Me.lblBackupDatabase.AutoSize = True
        Me.lblBackupDatabase.Location = New System.Drawing.Point(24, 262)
        Me.lblBackupDatabase.Name = "lblBackupDatabase"
        Me.lblBackupDatabase.Size = New System.Drawing.Size(125, 13)
        Me.lblBackupDatabase.TabIndex = 84
        Me.lblBackupDatabase.Text = "Backup Database Folder"
        '
        'btnBackupDatabase
        '
        Me.btnBackupDatabase.Location = New System.Drawing.Point(442, 258)
        Me.btnBackupDatabase.Name = "btnBackupDatabase"
        Me.btnBackupDatabase.Size = New System.Drawing.Size(120, 23)
        Me.btnBackupDatabase.TabIndex = 83
        Me.btnBackupDatabase.Text = "Backup Database"
        Me.btnBackupDatabase.UseVisualStyleBackColor = True
        '
        'txtUpgradeDatabase
        '
        Me.txtUpgradeDatabase.Location = New System.Drawing.Point(165, 202)
        Me.txtUpgradeDatabase.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUpgradeDatabase.Name = "txtUpgradeDatabase"
        Me.txtUpgradeDatabase.ReadOnly = True
        Me.txtUpgradeDatabase.Size = New System.Drawing.Size(190, 20)
        Me.txtUpgradeDatabase.TabIndex = 82
        '
        'lblDatabaseVersion
        '
        Me.lblDatabaseVersion.AutoSize = True
        Me.lblDatabaseVersion.Location = New System.Drawing.Point(24, 203)
        Me.lblDatabaseVersion.Name = "lblDatabaseVersion"
        Me.lblDatabaseVersion.Size = New System.Drawing.Size(91, 13)
        Me.lblDatabaseVersion.TabIndex = 81
        Me.lblDatabaseVersion.Text = "Database Version"
        '
        'btnUpgradeDatabase
        '
        Me.btnUpgradeDatabase.Enabled = False
        Me.btnUpgradeDatabase.Location = New System.Drawing.Point(442, 200)
        Me.btnUpgradeDatabase.Name = "btnUpgradeDatabase"
        Me.btnUpgradeDatabase.Size = New System.Drawing.Size(120, 23)
        Me.btnUpgradeDatabase.TabIndex = 80
        Me.btnUpgradeDatabase.Text = "Update Database"
        Me.btnUpgradeDatabase.UseVisualStyleBackColor = True
        '
        'prbCreateDatabase
        '
        Me.prbCreateDatabase.Location = New System.Drawing.Point(442, 125)
        Me.prbCreateDatabase.Margin = New System.Windows.Forms.Padding(2)
        Me.prbCreateDatabase.Name = "prbCreateDatabase"
        Me.prbCreateDatabase.Size = New System.Drawing.Size(120, 19)
        Me.prbCreateDatabase.Step = 1
        Me.prbCreateDatabase.TabIndex = 79
        Me.prbCreateDatabase.Visible = False
        '
        'btnCreateDemoData
        '
        Me.btnCreateDemoData.Location = New System.Drawing.Point(442, 99)
        Me.btnCreateDemoData.Name = "btnCreateDemoData"
        Me.btnCreateDemoData.Size = New System.Drawing.Size(120, 23)
        Me.btnCreateDemoData.TabIndex = 77
        Me.btnCreateDemoData.Text = "Create Demo Data"
        Me.btnCreateDemoData.UseVisualStyleBackColor = True
        Me.btnCreateDemoData.Visible = False
        '
        'btnCreateDatabase
        '
        Me.btnCreateDatabase.Location = New System.Drawing.Point(442, 73)
        Me.btnCreateDatabase.Name = "btnCreateDatabase"
        Me.btnCreateDatabase.Size = New System.Drawing.Size(120, 23)
        Me.btnCreateDatabase.TabIndex = 76
        Me.btnCreateDatabase.Text = "Create Database"
        Me.btnCreateDatabase.UseVisualStyleBackColor = True
        '
        'btnSaveSettingsDatabase
        '
        Me.btnSaveSettingsDatabase.Enabled = False
        Me.btnSaveSettingsDatabase.Location = New System.Drawing.Point(442, 18)
        Me.btnSaveSettingsDatabase.Name = "btnSaveSettingsDatabase"
        Me.btnSaveSettingsDatabase.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveSettingsDatabase.TabIndex = 74
        Me.btnSaveSettingsDatabase.Text = "Save Settings"
        Me.btnSaveSettingsDatabase.UseVisualStyleBackColor = True
        '
        'btnUseDefaults
        '
        Me.btnUseDefaults.Location = New System.Drawing.Point(442, 147)
        Me.btnUseDefaults.Name = "btnUseDefaults"
        Me.btnUseDefaults.Size = New System.Drawing.Size(120, 23)
        Me.btnUseDefaults.TabIndex = 75
        Me.btnUseDefaults.Text = "Use Defaults"
        Me.btnUseDefaults.UseVisualStyleBackColor = True
        '
        'lblLoginMethod
        '
        Me.lblLoginMethod.AutoSize = True
        Me.lblLoginMethod.Location = New System.Drawing.Point(24, 103)
        Me.lblLoginMethod.Name = "lblLoginMethod"
        Me.lblLoginMethod.Size = New System.Drawing.Size(114, 13)
        Me.lblLoginMethod.TabIndex = 11
        Me.lblLoginMethod.Text = "Authentication Method"
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoSize = True
        Me.lblLoginName.Location = New System.Drawing.Point(24, 130)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(64, 13)
        Me.lblLoginName.TabIndex = 10
        Me.lblLoginName.Text = "Login Name"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(24, 156)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 9
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(165, 153)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 73
        '
        'cbxLoginMethod
        '
        Me.cbxLoginMethod.FormattingEnabled = True
        Me.cbxLoginMethod.Items.AddRange(New Object() {"Windows", "SQL"})
        Me.cbxLoginMethod.Location = New System.Drawing.Point(165, 100)
        Me.cbxLoginMethod.Name = "cbxLoginMethod"
        Me.cbxLoginMethod.Size = New System.Drawing.Size(100, 21)
        Me.cbxLoginMethod.TabIndex = 71
        Me.cbxLoginMethod.Text = "Windows"
        '
        'txtLoginName
        '
        Me.txtLoginName.Enabled = False
        Me.txtLoginName.Location = New System.Drawing.Point(165, 127)
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(100, 20)
        Me.txtLoginName.TabIndex = 72
        '
        'lblDatabaseName
        '
        Me.lblDatabaseName.AutoSize = True
        Me.lblDatabaseName.Location = New System.Drawing.Point(24, 77)
        Me.lblDatabaseName.Name = "lblDatabaseName"
        Me.lblDatabaseName.Size = New System.Drawing.Size(84, 13)
        Me.lblDatabaseName.TabIndex = 5
        Me.lblDatabaseName.Text = "Database Name"
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(165, 74)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(100, 20)
        Me.txtDatabaseName.TabIndex = 70
        Me.txtDatabaseName.Text = "TrackManager"
        '
        'lblDatabaseLocation
        '
        Me.lblDatabaseLocation.AutoSize = True
        Me.lblDatabaseLocation.Location = New System.Drawing.Point(24, 51)
        Me.lblDatabaseLocation.Name = "lblDatabaseLocation"
        Me.lblDatabaseLocation.Size = New System.Drawing.Size(97, 13)
        Me.lblDatabaseLocation.TabIndex = 3
        Me.lblDatabaseLocation.Text = "Database Location"
        '
        'cbxDataProvider
        '
        Me.cbxDataProvider.FormattingEnabled = True
        Me.cbxDataProvider.Items.AddRange(New Object() {"SQL"})
        Me.cbxDataProvider.Location = New System.Drawing.Point(165, 21)
        Me.cbxDataProvider.Name = "cbxDataProvider"
        Me.cbxDataProvider.Size = New System.Drawing.Size(100, 21)
        Me.cbxDataProvider.TabIndex = 68
        Me.cbxDataProvider.Text = "SQL"
        '
        'txtDatabaseLocation
        '
        Me.txtDatabaseLocation.Location = New System.Drawing.Point(165, 48)
        Me.txtDatabaseLocation.Name = "txtDatabaseLocation"
        Me.txtDatabaseLocation.Size = New System.Drawing.Size(190, 20)
        Me.txtDatabaseLocation.TabIndex = 69
        '
        'lblDataProvider
        '
        Me.lblDataProvider.AutoSize = True
        Me.lblDataProvider.Location = New System.Drawing.Point(24, 24)
        Me.lblDataProvider.Name = "lblDataProvider"
        Me.lblDataProvider.Size = New System.Drawing.Size(72, 13)
        Me.lblDataProvider.TabIndex = 0
        Me.lblDataProvider.Text = "Data Provider"
        '
        'lblStatusDatabase
        '
        Me.lblStatusDatabase.AutoSize = True
        Me.lblStatusDatabase.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusDatabase.Location = New System.Drawing.Point(445, 104)
        Me.lblStatusDatabase.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatusDatabase.Name = "lblStatusDatabase"
        Me.lblStatusDatabase.Size = New System.Drawing.Size(110, 13)
        Me.lblStatusDatabase.TabIndex = 78
        Me.lblStatusDatabase.Text = "Working. Please wait."
        Me.lblStatusDatabase.Visible = False
        '
        'tpgEmail
        '
        Me.tpgEmail.Controls.Add(Me.txtArchiveEmail)
        Me.tpgEmail.Controls.Add(Me.chkArchiveEmail)
        Me.tpgEmail.Controls.Add(Me.grpEmailSmtp)
        Me.tpgEmail.Controls.Add(Me.rbtEmailUseOutlook)
        Me.tpgEmail.Controls.Add(Me.rbtEmailUseSmtp)
        Me.tpgEmail.Controls.Add(Me.btnSaveSettingsEmail)
        Me.tpgEmail.Location = New System.Drawing.Point(4, 40)
        Me.tpgEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.tpgEmail.Name = "tpgEmail"
        Me.tpgEmail.Size = New System.Drawing.Size(588, 337)
        Me.tpgEmail.TabIndex = 8
        Me.tpgEmail.Tag = "tpgEmail"
        Me.tpgEmail.Text = "Email"
        Me.tpgEmail.UseVisualStyleBackColor = True
        '
        'grpEmailSmtp
        '
        Me.grpEmailSmtp.Controls.Add(Me.lblSmtpPortNumber)
        Me.grpEmailSmtp.Controls.Add(Me.txtSmtpPortNumber)
        Me.grpEmailSmtp.Controls.Add(Me.chkUseSslEncryption)
        Me.grpEmailSmtp.Controls.Add(Me.lblSmtpReply)
        Me.grpEmailSmtp.Controls.Add(Me.txtSmtpReply)
        Me.grpEmailSmtp.Controls.Add(Me.chkSmtpCredentials)
        Me.grpEmailSmtp.Controls.Add(Me.lblSmtpServerPassword)
        Me.grpEmailSmtp.Controls.Add(Me.txtSmtpServerPassword)
        Me.grpEmailSmtp.Controls.Add(Me.lblSmtpServerUsername)
        Me.grpEmailSmtp.Controls.Add(Me.txtSmtpServerUsername)
        Me.grpEmailSmtp.Controls.Add(Me.lblSmtpServer)
        Me.grpEmailSmtp.Controls.Add(Me.txtSmtpServer)
        Me.grpEmailSmtp.Location = New System.Drawing.Point(20, 53)
        Me.grpEmailSmtp.Margin = New System.Windows.Forms.Padding(2)
        Me.grpEmailSmtp.Name = "grpEmailSmtp"
        Me.grpEmailSmtp.Padding = New System.Windows.Forms.Padding(2)
        Me.grpEmailSmtp.Size = New System.Drawing.Size(350, 200)
        Me.grpEmailSmtp.TabIndex = 85
        Me.grpEmailSmtp.TabStop = False
        Me.grpEmailSmtp.Text = "SMTP Settings"
        '
        'lblSmtpPortNumber
        '
        Me.lblSmtpPortNumber.AutoSize = True
        Me.lblSmtpPortNumber.Location = New System.Drawing.Point(6, 142)
        Me.lblSmtpPortNumber.Name = "lblSmtpPortNumber"
        Me.lblSmtpPortNumber.Size = New System.Drawing.Size(99, 13)
        Me.lblSmtpPortNumber.TabIndex = 93
        Me.lblSmtpPortNumber.Text = "SMTP Port Number"
        '
        'txtSmtpPortNumber
        '
        Me.txtSmtpPortNumber.Location = New System.Drawing.Point(147, 139)
        Me.txtSmtpPortNumber.Name = "txtSmtpPortNumber"
        Me.txtSmtpPortNumber.Size = New System.Drawing.Size(43, 20)
        Me.txtSmtpPortNumber.TabIndex = 94
        '
        'chkUseSslEncryption
        '
        Me.chkUseSslEncryption.AutoSize = True
        Me.chkUseSslEncryption.Location = New System.Drawing.Point(8, 121)
        Me.chkUseSslEncryption.Name = "chkUseSslEncryption"
        Me.chkUseSslEncryption.Size = New System.Drawing.Size(146, 17)
        Me.chkUseSslEncryption.TabIndex = 92
        Me.chkUseSslEncryption.Text = "Use SSL/TLS Encryption"
        Me.chkUseSslEncryption.UseVisualStyleBackColor = True
        '
        'lblSmtpReply
        '
        Me.lblSmtpReply.AutoSize = True
        Me.lblSmtpReply.Location = New System.Drawing.Point(6, 176)
        Me.lblSmtpReply.Name = "lblSmtpReply"
        Me.lblSmtpReply.Size = New System.Drawing.Size(91, 13)
        Me.lblSmtpReply.TabIndex = 90
        Me.lblSmtpReply.Text = "Reply To Address"
        '
        'txtSmtpReply
        '
        Me.txtSmtpReply.Location = New System.Drawing.Point(147, 172)
        Me.txtSmtpReply.Name = "txtSmtpReply"
        Me.txtSmtpReply.Size = New System.Drawing.Size(190, 20)
        Me.txtSmtpReply.TabIndex = 91
        '
        'chkSmtpCredentials
        '
        Me.chkSmtpCredentials.AutoSize = True
        Me.chkSmtpCredentials.Checked = True
        Me.chkSmtpCredentials.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSmtpCredentials.Location = New System.Drawing.Point(8, 47)
        Me.chkSmtpCredentials.Name = "chkSmtpCredentials"
        Me.chkSmtpCredentials.Size = New System.Drawing.Size(141, 17)
        Me.chkSmtpCredentials.TabIndex = 89
        Me.chkSmtpCredentials.Text = "use Network Credentials"
        Me.chkSmtpCredentials.UseVisualStyleBackColor = True
        '
        'lblSmtpServerPassword
        '
        Me.lblSmtpServerPassword.AutoSize = True
        Me.lblSmtpServerPassword.Location = New System.Drawing.Point(6, 94)
        Me.lblSmtpServerPassword.Name = "lblSmtpServerPassword"
        Me.lblSmtpServerPassword.Size = New System.Drawing.Size(120, 13)
        Me.lblSmtpServerPassword.TabIndex = 87
        Me.lblSmtpServerPassword.Text = "SMTP Server Password"
        '
        'txtSmtpServerPassword
        '
        Me.txtSmtpServerPassword.Enabled = False
        Me.txtSmtpServerPassword.Location = New System.Drawing.Point(147, 91)
        Me.txtSmtpServerPassword.Name = "txtSmtpServerPassword"
        Me.txtSmtpServerPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSmtpServerPassword.Size = New System.Drawing.Size(190, 20)
        Me.txtSmtpServerPassword.TabIndex = 88
        '
        'lblSmtpServerUsername
        '
        Me.lblSmtpServerUsername.AutoSize = True
        Me.lblSmtpServerUsername.Location = New System.Drawing.Point(6, 70)
        Me.lblSmtpServerUsername.Name = "lblSmtpServerUsername"
        Me.lblSmtpServerUsername.Size = New System.Drawing.Size(122, 13)
        Me.lblSmtpServerUsername.TabIndex = 85
        Me.lblSmtpServerUsername.Text = "SMTP Server Username"
        '
        'txtSmtpServerUsername
        '
        Me.txtSmtpServerUsername.Enabled = False
        Me.txtSmtpServerUsername.Location = New System.Drawing.Point(147, 67)
        Me.txtSmtpServerUsername.Name = "txtSmtpServerUsername"
        Me.txtSmtpServerUsername.Size = New System.Drawing.Size(190, 20)
        Me.txtSmtpServerUsername.TabIndex = 86
        '
        'lblSmtpServer
        '
        Me.lblSmtpServer.AutoSize = True
        Me.lblSmtpServer.Location = New System.Drawing.Point(6, 20)
        Me.lblSmtpServer.Name = "lblSmtpServer"
        Me.lblSmtpServer.Size = New System.Drawing.Size(71, 13)
        Me.lblSmtpServer.TabIndex = 83
        Me.lblSmtpServer.Text = "SMTP Server"
        '
        'txtSmtpServer
        '
        Me.txtSmtpServer.Location = New System.Drawing.Point(147, 17)
        Me.txtSmtpServer.Name = "txtSmtpServer"
        Me.txtSmtpServer.Size = New System.Drawing.Size(190, 20)
        Me.txtSmtpServer.TabIndex = 84
        '
        'rbtEmailUseOutlook
        '
        Me.rbtEmailUseOutlook.AutoSize = True
        Me.rbtEmailUseOutlook.Location = New System.Drawing.Point(165, 18)
        Me.rbtEmailUseOutlook.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtEmailUseOutlook.Name = "rbtEmailUseOutlook"
        Me.rbtEmailUseOutlook.Size = New System.Drawing.Size(111, 17)
        Me.rbtEmailUseOutlook.TabIndex = 84
        Me.rbtEmailUseOutlook.TabStop = True
        Me.rbtEmailUseOutlook.Text = "Use Outlook 2007"
        Me.rbtEmailUseOutlook.UseVisualStyleBackColor = True
        '
        'rbtEmailUseSmtp
        '
        Me.rbtEmailUseSmtp.AutoSize = True
        Me.rbtEmailUseSmtp.Location = New System.Drawing.Point(26, 18)
        Me.rbtEmailUseSmtp.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtEmailUseSmtp.Name = "rbtEmailUseSmtp"
        Me.rbtEmailUseSmtp.Size = New System.Drawing.Size(77, 17)
        Me.rbtEmailUseSmtp.TabIndex = 83
        Me.rbtEmailUseSmtp.TabStop = True
        Me.rbtEmailUseSmtp.Text = "Use SMTP"
        Me.rbtEmailUseSmtp.UseVisualStyleBackColor = True
        '
        'btnSaveSettingsEmail
        '
        Me.btnSaveSettingsEmail.Enabled = False
        Me.btnSaveSettingsEmail.Location = New System.Drawing.Point(442, 18)
        Me.btnSaveSettingsEmail.Name = "btnSaveSettingsEmail"
        Me.btnSaveSettingsEmail.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveSettingsEmail.TabIndex = 72
        Me.btnSaveSettingsEmail.Text = "Save Settings"
        Me.btnSaveSettingsEmail.UseVisualStyleBackColor = True
        '
        'tpgLicense
        '
        Me.tpgLicense.Controls.Add(Me.btnExitTrackManager)
        Me.tpgLicense.Controls.Add(Me.lblInstallKey)
        Me.tpgLicense.Controls.Add(Me.txtInstallKey)
        Me.tpgLicense.Controls.Add(Me.lblLicenseKey)
        Me.tpgLicense.Controls.Add(Me.txtLicenseKey)
        Me.tpgLicense.Controls.Add(Me.lblExpireDate)
        Me.tpgLicense.Controls.Add(Me.txtExpiryDate)
        Me.tpgLicense.Controls.Add(Me.btnSaveLicense)
        Me.tpgLicense.Controls.Add(Me.lblLicenseName)
        Me.tpgLicense.Controls.Add(Me.txtLicenseName)
        Me.tpgLicense.Controls.Add(Me.btnValidateLicense)
        Me.tpgLicense.Location = New System.Drawing.Point(4, 40)
        Me.tpgLicense.Name = "tpgLicense"
        Me.tpgLicense.Size = New System.Drawing.Size(588, 337)
        Me.tpgLicense.TabIndex = 10
        Me.tpgLicense.Tag = "tpgLicense"
        Me.tpgLicense.Text = "License"
        Me.tpgLicense.UseVisualStyleBackColor = True
        '
        'btnExitTrackManager
        '
        Me.btnExitTrackManager.Location = New System.Drawing.Point(390, 261)
        Me.btnExitTrackManager.Name = "btnExitTrackManager"
        Me.btnExitTrackManager.Size = New System.Drawing.Size(127, 23)
        Me.btnExitTrackManager.TabIndex = 10
        Me.btnExitTrackManager.Text = "Exit TrackManager"
        Me.btnExitTrackManager.UseVisualStyleBackColor = True
        Me.btnExitTrackManager.Visible = False
        '
        'lblInstallKey
        '
        Me.lblInstallKey.AutoSize = True
        Me.lblInstallKey.Location = New System.Drawing.Point(46, 133)
        Me.lblInstallKey.Name = "lblInstallKey"
        Me.lblInstallKey.Size = New System.Drawing.Size(55, 13)
        Me.lblInstallKey.TabIndex = 9
        Me.lblInstallKey.Text = "Install Key"
        Me.lblInstallKey.Visible = False
        '
        'txtInstallKey
        '
        Me.txtInstallKey.Location = New System.Drawing.Point(136, 130)
        Me.txtInstallKey.Name = "txtInstallKey"
        Me.txtInstallKey.Size = New System.Drawing.Size(204, 20)
        Me.txtInstallKey.TabIndex = 8
        Me.txtInstallKey.Visible = False
        '
        'lblLicenseKey
        '
        Me.lblLicenseKey.AutoSize = True
        Me.lblLicenseKey.Location = New System.Drawing.Point(46, 107)
        Me.lblLicenseKey.Name = "lblLicenseKey"
        Me.lblLicenseKey.Size = New System.Drawing.Size(65, 13)
        Me.lblLicenseKey.TabIndex = 7
        Me.lblLicenseKey.Text = "License Key"
        '
        'txtLicenseKey
        '
        Me.txtLicenseKey.Location = New System.Drawing.Point(136, 104)
        Me.txtLicenseKey.Name = "txtLicenseKey"
        Me.txtLicenseKey.Size = New System.Drawing.Size(204, 20)
        Me.txtLicenseKey.TabIndex = 6
        '
        'lblExpireDate
        '
        Me.lblExpireDate.AutoSize = True
        Me.lblExpireDate.Location = New System.Drawing.Point(46, 81)
        Me.lblExpireDate.Name = "lblExpireDate"
        Me.lblExpireDate.Size = New System.Drawing.Size(61, 13)
        Me.lblExpireDate.TabIndex = 5
        Me.lblExpireDate.Text = "Expiry Date"
        Me.lblExpireDate.Visible = False
        '
        'txtExpiryDate
        '
        Me.txtExpiryDate.Location = New System.Drawing.Point(136, 78)
        Me.txtExpiryDate.Name = "txtExpiryDate"
        Me.txtExpiryDate.Size = New System.Drawing.Size(100, 20)
        Me.txtExpiryDate.TabIndex = 4
        Me.txtExpiryDate.Visible = False
        '
        'btnSaveLicense
        '
        Me.btnSaveLicense.Location = New System.Drawing.Point(390, 232)
        Me.btnSaveLicense.Name = "btnSaveLicense"
        Me.btnSaveLicense.Size = New System.Drawing.Size(127, 23)
        Me.btnSaveLicense.TabIndex = 3
        Me.btnSaveLicense.Text = "Save"
        Me.btnSaveLicense.UseVisualStyleBackColor = True
        '
        'lblLicenseName
        '
        Me.lblLicenseName.AutoSize = True
        Me.lblLicenseName.Location = New System.Drawing.Point(46, 54)
        Me.lblLicenseName.Name = "lblLicenseName"
        Me.lblLicenseName.Size = New System.Drawing.Size(75, 13)
        Me.lblLicenseName.TabIndex = 2
        Me.lblLicenseName.Text = "License Name"
        '
        'txtLicenseName
        '
        Me.txtLicenseName.Location = New System.Drawing.Point(136, 51)
        Me.txtLicenseName.Name = "txtLicenseName"
        Me.txtLicenseName.Size = New System.Drawing.Size(204, 20)
        Me.txtLicenseName.TabIndex = 1
        '
        'btnValidateLicense
        '
        Me.btnValidateLicense.Location = New System.Drawing.Point(390, 203)
        Me.btnValidateLicense.Name = "btnValidateLicense"
        Me.btnValidateLicense.Size = New System.Drawing.Size(127, 23)
        Me.btnValidateLicense.TabIndex = 0
        Me.btnValidateLicense.Text = "Validate"
        Me.btnValidateLicense.UseVisualStyleBackColor = True
        '
        'tpgPaymentMethod
        '
        Me.tpgPaymentMethod.Location = New System.Drawing.Point(4, 40)
        Me.tpgPaymentMethod.Name = "tpgPaymentMethod"
        Me.tpgPaymentMethod.Size = New System.Drawing.Size(588, 337)
        Me.tpgPaymentMethod.TabIndex = 11
        Me.tpgPaymentMethod.Tag = "tpgPaymentMethod"
        Me.tpgPaymentMethod.Text = "Payment"
        Me.tpgPaymentMethod.UseVisualStyleBackColor = True
        '
        'tpgLanguage
        '
        Me.tpgLanguage.Controls.Add(Me.lblLanguageType)
        Me.tpgLanguage.Controls.Add(Me.lblLanguageText)
        Me.tpgLanguage.Controls.Add(Me.lblLanguageItem)
        Me.tpgLanguage.Controls.Add(Me.lblLanguageForm)
        Me.tpgLanguage.Controls.Add(Me.cbxLanguageForm)
        Me.tpgLanguage.Controls.Add(Me.cbxLanguageType)
        Me.tpgLanguage.Controls.Add(Me.btnLanguageExport)
        Me.tpgLanguage.Controls.Add(Me.cbxLanguage)
        Me.tpgLanguage.Controls.Add(Me.btnLanguageLoad)
        Me.tpgLanguage.Controls.Add(Me.lblLanguageDefault)
        Me.tpgLanguage.Controls.Add(Me.lbxLanguage)
        Me.tpgLanguage.Controls.Add(Me.btnAddLanguage)
        Me.tpgLanguage.Controls.Add(Me.btnDeleteLanguage)
        Me.tpgLanguage.Controls.Add(Me.lblCurrentLanguage)
        Me.tpgLanguage.Controls.Add(Me.btnLanguageSaveAll)
        Me.tpgLanguage.Controls.Add(Me.btnClearLanguage)
        Me.tpgLanguage.Controls.Add(Me.btnSaveSettingsLanguage)
        Me.tpgLanguage.Controls.Add(Me.TxtLanguageText)
        Me.tpgLanguage.Controls.Add(Me.txtLanguageItem)
        Me.tpgLanguage.Controls.Add(Me.btnLanguageImport)
        Me.tpgLanguage.Controls.Add(Me.btnEditLanguage)
        Me.tpgLanguage.Controls.Add(Me.lvwLanguage)
        Me.tpgLanguage.Location = New System.Drawing.Point(4, 40)
        Me.tpgLanguage.Name = "tpgLanguage"
        Me.tpgLanguage.Size = New System.Drawing.Size(588, 337)
        Me.tpgLanguage.TabIndex = 12
        Me.tpgLanguage.Tag = "tpgLanguage"
        Me.tpgLanguage.Text = "Language"
        Me.tpgLanguage.UseVisualStyleBackColor = True
        '
        'lblLanguageType
        '
        Me.lblLanguageType.AutoSize = True
        Me.lblLanguageType.Location = New System.Drawing.Point(339, 258)
        Me.lblLanguageType.Name = "lblLanguageType"
        Me.lblLanguageType.Size = New System.Drawing.Size(31, 13)
        Me.lblLanguageType.TabIndex = 79
        Me.lblLanguageType.Text = "Type"
        '
        'lblLanguageText
        '
        Me.lblLanguageText.AutoSize = True
        Me.lblLanguageText.Location = New System.Drawing.Point(233, 258)
        Me.lblLanguageText.Name = "lblLanguageText"
        Me.lblLanguageText.Size = New System.Drawing.Size(28, 13)
        Me.lblLanguageText.TabIndex = 78
        Me.lblLanguageText.Text = "Text"
        '
        'lblLanguageItem
        '
        Me.lblLanguageItem.AutoSize = True
        Me.lblLanguageItem.Location = New System.Drawing.Point(127, 258)
        Me.lblLanguageItem.Name = "lblLanguageItem"
        Me.lblLanguageItem.Size = New System.Drawing.Size(58, 13)
        Me.lblLanguageItem.TabIndex = 77
        Me.lblLanguageItem.Text = "Item Name"
        '
        'lblLanguageForm
        '
        Me.lblLanguageForm.AutoSize = True
        Me.lblLanguageForm.Location = New System.Drawing.Point(24, 258)
        Me.lblLanguageForm.Name = "lblLanguageForm"
        Me.lblLanguageForm.Size = New System.Drawing.Size(68, 13)
        Me.lblLanguageForm.TabIndex = 76
        Me.lblLanguageForm.Text = "Form (Group)"
        '
        'cbxLanguageForm
        '
        Me.cbxLanguageForm.FormattingEnabled = True
        Me.cbxLanguageForm.Items.AddRange(New Object() {"TrackManager", "Settings", "Clients", "Groups", "Logins", "AppointmentChange", "Finance", "Properties", "Reports"})
        Me.cbxLanguageForm.Location = New System.Drawing.Point(24, 277)
        Me.cbxLanguageForm.Name = "cbxLanguageForm"
        Me.cbxLanguageForm.Size = New System.Drawing.Size(100, 21)
        Me.cbxLanguageForm.TabIndex = 75
        '
        'cbxLanguageType
        '
        Me.cbxLanguageType.FormattingEnabled = True
        Me.cbxLanguageType.Items.AddRange(New Object() {"Menu", "Text", "List", "ListItem", "Prop", "Report"})
        Me.cbxLanguageType.Location = New System.Drawing.Point(342, 276)
        Me.cbxLanguageType.Name = "cbxLanguageType"
        Me.cbxLanguageType.Size = New System.Drawing.Size(100, 21)
        Me.cbxLanguageType.TabIndex = 74
        '
        'btnLanguageExport
        '
        Me.btnLanguageExport.Location = New System.Drawing.Point(476, 303)
        Me.btnLanguageExport.Name = "btnLanguageExport"
        Me.btnLanguageExport.Size = New System.Drawing.Size(100, 23)
        Me.btnLanguageExport.TabIndex = 72
        Me.btnLanguageExport.Text = "Export Language"
        Me.btnLanguageExport.UseVisualStyleBackColor = True
        '
        'cbxLanguage
        '
        Me.cbxLanguage.FormattingEnabled = True
        Me.cbxLanguage.Items.AddRange(New Object() {"EN"})
        Me.cbxLanguage.Location = New System.Drawing.Point(162, 19)
        Me.cbxLanguage.Name = "cbxLanguage"
        Me.cbxLanguage.Size = New System.Drawing.Size(96, 21)
        Me.cbxLanguage.TabIndex = 71
        Me.cbxLanguage.Text = "EN"
        '
        'btnLanguageLoad
        '
        Me.btnLanguageLoad.Location = New System.Drawing.Point(476, 227)
        Me.btnLanguageLoad.Name = "btnLanguageLoad"
        Me.btnLanguageLoad.Size = New System.Drawing.Size(100, 23)
        Me.btnLanguageLoad.TabIndex = 70
        Me.btnLanguageLoad.Text = "Load Language"
        Me.btnLanguageLoad.UseVisualStyleBackColor = True
        '
        'lblLanguageDefault
        '
        Me.lblLanguageDefault.AutoSize = True
        Me.lblLanguageDefault.Location = New System.Drawing.Point(473, 22)
        Me.lblLanguageDefault.Name = "lblLanguageDefault"
        Me.lblLanguageDefault.Size = New System.Drawing.Size(97, 13)
        Me.lblLanguageDefault.TabIndex = 69
        Me.lblLanguageDefault.Text = "Default Languages"
        '
        'lbxLanguage
        '
        Me.lbxLanguage.FormattingEnabled = True
        Me.lbxLanguage.Items.AddRange(New Object() {"EN (English)", "NL (Nederlands)"})
        Me.lbxLanguage.Location = New System.Drawing.Point(476, 46)
        Me.lbxLanguage.Name = "lbxLanguage"
        Me.lbxLanguage.Size = New System.Drawing.Size(100, 173)
        Me.lbxLanguage.TabIndex = 68
        '
        'btnAddLanguage
        '
        Me.btnAddLanguage.Location = New System.Drawing.Point(24, 303)
        Me.btnAddLanguage.Name = "btnAddLanguage"
        Me.btnAddLanguage.Size = New System.Drawing.Size(100, 23)
        Me.btnAddLanguage.TabIndex = 67
        Me.btnAddLanguage.Text = "Add"
        Me.btnAddLanguage.UseVisualStyleBackColor = True
        '
        'btnDeleteLanguage
        '
        Me.btnDeleteLanguage.Enabled = False
        Me.btnDeleteLanguage.Location = New System.Drawing.Point(130, 227)
        Me.btnDeleteLanguage.Name = "btnDeleteLanguage"
        Me.btnDeleteLanguage.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteLanguage.TabIndex = 66
        Me.btnDeleteLanguage.Text = "Delete"
        Me.btnDeleteLanguage.UseVisualStyleBackColor = True
        '
        'lblCurrentLanguage
        '
        Me.lblCurrentLanguage.AutoSize = True
        Me.lblCurrentLanguage.Location = New System.Drawing.Point(25, 22)
        Me.lblCurrentLanguage.Name = "lblCurrentLanguage"
        Me.lblCurrentLanguage.Size = New System.Drawing.Size(92, 13)
        Me.lblCurrentLanguage.TabIndex = 64
        Me.lblCurrentLanguage.Text = "Current Language"
        '
        'btnLanguageSaveAll
        '
        Me.btnLanguageSaveAll.Location = New System.Drawing.Point(236, 303)
        Me.btnLanguageSaveAll.Name = "btnLanguageSaveAll"
        Me.btnLanguageSaveAll.Size = New System.Drawing.Size(100, 23)
        Me.btnLanguageSaveAll.TabIndex = 18
        Me.btnLanguageSaveAll.Text = "Save language"
        Me.btnLanguageSaveAll.UseVisualStyleBackColor = True
        '
        'btnClearLanguage
        '
        Me.btnClearLanguage.Location = New System.Drawing.Point(130, 303)
        Me.btnClearLanguage.Name = "btnClearLanguage"
        Me.btnClearLanguage.Size = New System.Drawing.Size(100, 23)
        Me.btnClearLanguage.TabIndex = 16
        Me.btnClearLanguage.Text = "Clear"
        Me.btnClearLanguage.UseVisualStyleBackColor = True
        '
        'btnSaveSettingsLanguage
        '
        Me.btnSaveSettingsLanguage.Location = New System.Drawing.Point(275, 17)
        Me.btnSaveSettingsLanguage.Name = "btnSaveSettingsLanguage"
        Me.btnSaveSettingsLanguage.Size = New System.Drawing.Size(100, 23)
        Me.btnSaveSettingsLanguage.TabIndex = 15
        Me.btnSaveSettingsLanguage.Text = "Save"
        Me.btnSaveSettingsLanguage.UseVisualStyleBackColor = True
        '
        'TxtLanguageText
        '
        Me.TxtLanguageText.Location = New System.Drawing.Point(236, 277)
        Me.TxtLanguageText.Name = "TxtLanguageText"
        Me.TxtLanguageText.Size = New System.Drawing.Size(100, 20)
        Me.TxtLanguageText.TabIndex = 14
        '
        'txtLanguageItem
        '
        Me.txtLanguageItem.Location = New System.Drawing.Point(130, 277)
        Me.txtLanguageItem.Name = "txtLanguageItem"
        Me.txtLanguageItem.Size = New System.Drawing.Size(100, 20)
        Me.txtLanguageItem.TabIndex = 13
        Me.txtLanguageItem.Tag = "0"
        '
        'btnLanguageImport
        '
        Me.btnLanguageImport.Location = New System.Drawing.Point(476, 275)
        Me.btnLanguageImport.Name = "btnLanguageImport"
        Me.btnLanguageImport.Size = New System.Drawing.Size(100, 23)
        Me.btnLanguageImport.TabIndex = 12
        Me.btnLanguageImport.Text = "Import Language"
        Me.btnLanguageImport.UseVisualStyleBackColor = True
        '
        'btnEditLanguage
        '
        Me.btnEditLanguage.Enabled = False
        Me.btnEditLanguage.Location = New System.Drawing.Point(24, 227)
        Me.btnEditLanguage.Name = "btnEditLanguage"
        Me.btnEditLanguage.Size = New System.Drawing.Size(100, 23)
        Me.btnEditLanguage.TabIndex = 11
        Me.btnEditLanguage.Text = "Edit"
        Me.btnEditLanguage.UseVisualStyleBackColor = True
        '
        'lvwLanguage
        '
        Me.lvwLanguage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colItemName, Me.colItemText, Me.colItemType})
        Me.lvwLanguage.FullRowSelect = True
        Me.lvwLanguage.GridLines = True
        ListViewGroup1.Header = "TrackManager"
        ListViewGroup1.Name = "lvgTrackManager"
        ListViewGroup1.Tag = "TrackManager"
        ListViewGroup2.Header = "Settings"
        ListViewGroup2.Name = "lvgSettings"
        ListViewGroup2.Tag = "Settings"
        ListViewGroup3.Header = "Clients"
        ListViewGroup3.Name = "lvgClients"
        ListViewGroup3.Tag = "Clients"
        ListViewGroup4.Header = "Groups"
        ListViewGroup4.Name = "lvgGroups"
        ListViewGroup4.Tag = "Groups"
        ListViewGroup5.Header = "Logins"
        ListViewGroup5.Name = "lvgLogins"
        ListViewGroup5.Tag = "Logins"
        ListViewGroup6.Header = "AppointmentChange"
        ListViewGroup6.Name = "lvgAppointmentChange"
        ListViewGroup6.Tag = "AppointmentChange"
        ListViewGroup7.Header = "Finance"
        ListViewGroup7.Name = "lvgFinance"
        ListViewGroup7.Tag = "Finance"
        ListViewGroup8.Header = "Properties"
        ListViewGroup8.Name = "lvgProperties"
        ListViewGroup8.Tag = "Properties"
        ListViewGroup9.Header = "Reports"
        ListViewGroup9.Name = "lvgReports"
        ListViewGroup9.Tag = "Reports"
        Me.lvwLanguage.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9})
        Me.lvwLanguage.HideSelection = False
        ListViewItem7.Group = ListViewGroup1
        ListViewItem7.StateImageIndex = 0
        Me.lvwLanguage.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem7})
        Me.lvwLanguage.Location = New System.Drawing.Point(24, 46)
        Me.lvwLanguage.MultiSelect = False
        Me.lvwLanguage.Name = "lvwLanguage"
        Me.lvwLanguage.Size = New System.Drawing.Size(446, 173)
        Me.lvwLanguage.TabIndex = 10
        Me.lvwLanguage.UseCompatibleStateImageBehavior = False
        Me.lvwLanguage.View = System.Windows.Forms.View.Details
        '
        'colItemName
        '
        Me.colItemName.Tag = "colItemName"
        Me.colItemName.Text = "Item Name"
        Me.colItemName.Width = 131
        '
        'colItemText
        '
        Me.colItemText.Tag = "colItemText"
        Me.colItemText.Text = "Item Text"
        Me.colItemText.Width = 227
        '
        'colItemType
        '
        Me.colItemType.Tag = "colItemType"
        Me.colItemType.Text = "Item Type"
        Me.colItemType.Width = 80
        '
        'tpgReports
        '
        Me.tpgReports.Controls.Add(Me.lblReportLessons)
        Me.tpgReports.Controls.Add(Me.lblReportFinance)
        Me.tpgReports.Controls.Add(Me.lblReportClients)
        Me.tpgReports.Controls.Add(Me.tbnSaveReportClients)
        Me.tpgReports.Controls.Add(Me.tbnSaveReportFinance)
        Me.tpgReports.Controls.Add(Me.lvwReportsClients)
        Me.tpgReports.Controls.Add(Me.lvwReportsFinance)
        Me.tpgReports.Controls.Add(Me.btnSaveReportLessons)
        Me.tpgReports.Controls.Add(Me.lvwReportsLessons)
        Me.tpgReports.Location = New System.Drawing.Point(4, 40)
        Me.tpgReports.Name = "tpgReports"
        Me.tpgReports.Size = New System.Drawing.Size(588, 337)
        Me.tpgReports.TabIndex = 13
        Me.tpgReports.Tag = "tpgReports"
        Me.tpgReports.Text = "Reports"
        Me.tpgReports.UseVisualStyleBackColor = True
        '
        'lblReportLessons
        '
        Me.lblReportLessons.AutoSize = True
        Me.lblReportLessons.Location = New System.Drawing.Point(21, 16)
        Me.lblReportLessons.Name = "lblReportLessons"
        Me.lblReportLessons.Size = New System.Drawing.Size(81, 13)
        Me.lblReportLessons.TabIndex = 23
        Me.lblReportLessons.Text = "Lesson Reports"
        '
        'lblReportFinance
        '
        Me.lblReportFinance.AutoSize = True
        Me.lblReportFinance.Location = New System.Drawing.Point(201, 16)
        Me.lblReportFinance.Name = "lblReportFinance"
        Me.lblReportFinance.Size = New System.Drawing.Size(85, 13)
        Me.lblReportFinance.TabIndex = 22
        Me.lblReportFinance.Text = "Finance Reports"
        '
        'lblReportClients
        '
        Me.lblReportClients.AutoSize = True
        Me.lblReportClients.Location = New System.Drawing.Point(384, 16)
        Me.lblReportClients.Name = "lblReportClients"
        Me.lblReportClients.Size = New System.Drawing.Size(73, 13)
        Me.lblReportClients.TabIndex = 21
        Me.lblReportClients.Text = "Client Reports"
        '
        'tbnSaveReportClients
        '
        Me.tbnSaveReportClients.Enabled = False
        Me.tbnSaveReportClients.Location = New System.Drawing.Point(384, 287)
        Me.tbnSaveReportClients.Name = "tbnSaveReportClients"
        Me.tbnSaveReportClients.Size = New System.Drawing.Size(175, 23)
        Me.tbnSaveReportClients.TabIndex = 20
        Me.tbnSaveReportClients.Text = "Save"
        Me.tbnSaveReportClients.UseVisualStyleBackColor = True
        '
        'tbnSaveReportFinance
        '
        Me.tbnSaveReportFinance.Enabled = False
        Me.tbnSaveReportFinance.Location = New System.Drawing.Point(204, 287)
        Me.tbnSaveReportFinance.Name = "tbnSaveReportFinance"
        Me.tbnSaveReportFinance.Size = New System.Drawing.Size(175, 23)
        Me.tbnSaveReportFinance.TabIndex = 19
        Me.tbnSaveReportFinance.Text = "Save"
        Me.tbnSaveReportFinance.UseVisualStyleBackColor = True
        '
        'lvwReportsClients
        '
        Me.lvwReportsClients.CheckBoxes = True
        Me.lvwReportsClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colReportClients})
        Me.lvwReportsClients.FullRowSelect = True
        Me.lvwReportsClients.GridLines = True
        Me.lvwReportsClients.HideSelection = False
        ListViewItem8.StateImageIndex = 0
        Me.lvwReportsClients.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem8})
        Me.lvwReportsClients.Location = New System.Drawing.Point(384, 32)
        Me.lvwReportsClients.MultiSelect = False
        Me.lvwReportsClients.Name = "lvwReportsClients"
        Me.lvwReportsClients.Size = New System.Drawing.Size(175, 249)
        Me.lvwReportsClients.TabIndex = 18
        Me.lvwReportsClients.Tag = "lvwReportsClients"
        Me.lvwReportsClients.UseCompatibleStateImageBehavior = False
        Me.lvwReportsClients.View = System.Windows.Forms.View.List
        '
        'colReportClients
        '
        Me.colReportClients.Tag = "colReportClients"
        Me.colReportClients.Text = "Client Reports"
        Me.colReportClients.Width = 170
        '
        'lvwReportsFinance
        '
        Me.lvwReportsFinance.CheckBoxes = True
        Me.lvwReportsFinance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colReportFinance})
        Me.lvwReportsFinance.FullRowSelect = True
        Me.lvwReportsFinance.GridLines = True
        Me.lvwReportsFinance.HideSelection = False
        ListViewItem9.StateImageIndex = 0
        Me.lvwReportsFinance.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem9})
        Me.lvwReportsFinance.Location = New System.Drawing.Point(204, 32)
        Me.lvwReportsFinance.MultiSelect = False
        Me.lvwReportsFinance.Name = "lvwReportsFinance"
        Me.lvwReportsFinance.Size = New System.Drawing.Size(175, 249)
        Me.lvwReportsFinance.TabIndex = 17
        Me.lvwReportsFinance.Tag = "lvwReportsFinance"
        Me.lvwReportsFinance.UseCompatibleStateImageBehavior = False
        Me.lvwReportsFinance.View = System.Windows.Forms.View.List
        '
        'colReportFinance
        '
        Me.colReportFinance.Tag = "colReportFinance"
        Me.colReportFinance.Text = "Finance Reports"
        Me.colReportFinance.Width = 170
        '
        'btnSaveReportLessons
        '
        Me.btnSaveReportLessons.Enabled = False
        Me.btnSaveReportLessons.Location = New System.Drawing.Point(24, 287)
        Me.btnSaveReportLessons.Name = "btnSaveReportLessons"
        Me.btnSaveReportLessons.Size = New System.Drawing.Size(175, 23)
        Me.btnSaveReportLessons.TabIndex = 11
        Me.btnSaveReportLessons.Text = "Save"
        Me.btnSaveReportLessons.UseVisualStyleBackColor = True
        '
        'lvwReportsLessons
        '
        Me.lvwReportsLessons.CheckBoxes = True
        Me.lvwReportsLessons.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colReportLessons})
        Me.lvwReportsLessons.FullRowSelect = True
        Me.lvwReportsLessons.GridLines = True
        Me.lvwReportsLessons.HideSelection = False
        ListViewItem10.StateImageIndex = 0
        Me.lvwReportsLessons.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem10})
        Me.lvwReportsLessons.Location = New System.Drawing.Point(24, 32)
        Me.lvwReportsLessons.MultiSelect = False
        Me.lvwReportsLessons.Name = "lvwReportsLessons"
        Me.lvwReportsLessons.Size = New System.Drawing.Size(175, 249)
        Me.lvwReportsLessons.TabIndex = 10
        Me.lvwReportsLessons.Tag = "lvwReportsLessons"
        Me.lvwReportsLessons.UseCompatibleStateImageBehavior = False
        Me.lvwReportsLessons.View = System.Windows.Forms.View.List
        '
        'colReportLessons
        '
        Me.colReportLessons.Tag = "colReportLessons"
        Me.colReportLessons.Text = "Lesson Reports"
        Me.colReportLessons.Width = 170
        '
        'tpgButtons
        '
        Me.tpgButtons.Controls.Add(Me.btnButtonOrderSave)
        Me.tpgButtons.Controls.Add(Me.lvwButtons)
        Me.tpgButtons.Controls.Add(Me.btnButtonDown)
        Me.tpgButtons.Controls.Add(Me.btnButtonUp)
        Me.tpgButtons.Location = New System.Drawing.Point(4, 40)
        Me.tpgButtons.Name = "tpgButtons"
        Me.tpgButtons.Size = New System.Drawing.Size(588, 337)
        Me.tpgButtons.TabIndex = 14
        Me.tpgButtons.Text = "Buttons"
        Me.tpgButtons.UseVisualStyleBackColor = True
        '
        'btnButtonOrderSave
        '
        Me.btnButtonOrderSave.Location = New System.Drawing.Point(166, 89)
        Me.btnButtonOrderSave.Name = "btnButtonOrderSave"
        Me.btnButtonOrderSave.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonOrderSave.TabIndex = 4
        Me.btnButtonOrderSave.Text = "Save"
        Me.btnButtonOrderSave.UseVisualStyleBackColor = True
        '
        'lvwButtons
        '
        Me.lvwButtons.FullRowSelect = True
        Me.lvwButtons.HideSelection = False
        ListViewItem11.Tag = "btnAppRemove"
        ListViewItem12.Tag = "btnAppCreate"
        ListViewItem13.Tag = "btnAppMove"
        ListViewItem14.Tag = "btnAppDelete"
        ListViewItem15.Tag = "btnAppClear"
        Me.lvwButtons.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15})
        Me.lvwButtons.Location = New System.Drawing.Point(17, 18)
        Me.lvwButtons.MultiSelect = False
        Me.lvwButtons.Name = "lvwButtons"
        Me.lvwButtons.ShowGroups = False
        Me.lvwButtons.Size = New System.Drawing.Size(122, 94)
        Me.lvwButtons.TabIndex = 3
        Me.lvwButtons.UseCompatibleStateImageBehavior = False
        Me.lvwButtons.View = System.Windows.Forms.View.List
        '
        'btnButtonDown
        '
        Me.btnButtonDown.Location = New System.Drawing.Point(166, 47)
        Me.btnButtonDown.Name = "btnButtonDown"
        Me.btnButtonDown.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonDown.TabIndex = 2
        Me.btnButtonDown.Text = "Down"
        Me.btnButtonDown.UseVisualStyleBackColor = True
        '
        'btnButtonUp
        '
        Me.btnButtonUp.Location = New System.Drawing.Point(166, 18)
        Me.btnButtonUp.Name = "btnButtonUp"
        Me.btnButtonUp.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonUp.TabIndex = 1
        Me.btnButtonUp.Text = "Up"
        Me.btnButtonUp.UseVisualStyleBackColor = True
        '
        'ofdScript
        '
        Me.ofdScript.FileName = "Script.sql"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Tag = "colTrackName"
        Me.ColumnHeader1.Text = "Track Name"
        Me.ColumnHeader1.Width = 131
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Tag = "colTrackOffset"
        Me.ColumnHeader2.Text = "Track Offset"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 140
        '
        'chkArchiveEmail
        '
        Me.chkArchiveEmail.AutoSize = True
        Me.chkArchiveEmail.Location = New System.Drawing.Point(29, 267)
        Me.chkArchiveEmail.Name = "chkArchiveEmail"
        Me.chkArchiveEmail.Size = New System.Drawing.Size(293, 17)
        Me.chkArchiveEmail.TabIndex = 95
        Me.chkArchiveEmail.Text = "Send a copy of all email to the following archive address:"
        Me.chkArchiveEmail.UseVisualStyleBackColor = True
        '
        'txtArchiveEmail
        '
        Me.txtArchiveEmail.Location = New System.Drawing.Point(372, 265)
        Me.txtArchiveEmail.Name = "txtArchiveEmail"
        Me.txtArchiveEmail.Size = New System.Drawing.Size(190, 20)
        Me.txtArchiveEmail.TabIndex = 95
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TrackManager Settings"
        Me.TopMost = True
        Me.tabSettings.ResumeLayout(False)
        Me.tpgGeneral.ResumeLayout(False)
        Me.tpgGeneral.PerformLayout()
        Me.grpShowOpenBills.ResumeLayout(False)
        Me.grpShowOpenBills.PerformLayout()
        Me.grpDisplayWarningOverbooked.ResumeLayout(False)
        Me.grpDisplayWarningOverbooked.PerformLayout()
        Me.tpgTracks.ResumeLayout(False)
        Me.tpgTracks.PerformLayout()
        Me.tpgLessonTypes.ResumeLayout(False)
        Me.tpgLessonTypes.PerformLayout()
        Me.tpgLevels.ResumeLayout(False)
        Me.tpgLevels.PerformLayout()
        Me.tpgProducts.ResumeLayout(False)
        Me.tpgProducts.PerformLayout()
        Me.tpgPrContacts.ResumeLayout(False)
        Me.tpgPrContacts.PerformLayout()
        Me.tpgTax.ResumeLayout(False)
        Me.tpgTax.PerformLayout()
        Me.tpgLogging.ResumeLayout(False)
        Me.tpgLogging.PerformLayout()
        Me.grpLogsToKeep.ResumeLayout(False)
        Me.grpLogsToKeep.PerformLayout()
        Me.tpgView.ResumeLayout(False)
        Me.tpgView.PerformLayout()
        Me.tpgDatabase.ResumeLayout(False)
        Me.tpgDatabase.PerformLayout()
        Me.tpgEmail.ResumeLayout(False)
        Me.tpgEmail.PerformLayout()
        Me.grpEmailSmtp.ResumeLayout(False)
        Me.grpEmailSmtp.PerformLayout()
        Me.tpgLicense.ResumeLayout(False)
        Me.tpgLicense.PerformLayout()
        Me.tpgLanguage.ResumeLayout(False)
        Me.tpgLanguage.PerformLayout()
        Me.tpgReports.ResumeLayout(False)
        Me.tpgReports.PerformLayout()
        Me.tpgButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSaveSettingsLog As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents tpgTracks As System.Windows.Forms.TabPage
    Friend WithEvents tpgLessonTypes As System.Windows.Forms.TabPage
    Friend WithEvents tpgLevels As System.Windows.Forms.TabPage
    Friend WithEvents tpgProducts As System.Windows.Forms.TabPage
    Friend WithEvents tpgPrContacts As System.Windows.Forms.TabPage
    Friend WithEvents tpgView As System.Windows.Forms.TabPage
    Friend WithEvents tpgLogging As System.Windows.Forms.TabPage
    Friend WithEvents tpgDatabase As System.Windows.Forms.TabPage
    Friend WithEvents lvwTracks As System.Windows.Forms.ListView
    Friend WithEvents colTrackName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTrackOffset As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTrackName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteTrack As System.Windows.Forms.Button
    Friend WithEvents btnEditTrack As System.Windows.Forms.Button
    Friend WithEvents txtTrackOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnClearTrack As System.Windows.Forms.Button
    Friend WithEvents btnAddTrack As System.Windows.Forms.Button
    Friend WithEvents btnClearLessonType As System.Windows.Forms.Button
    Friend WithEvents btnAddLessonType As System.Windows.Forms.Button
    Friend WithEvents txtLessonTypeName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteLessonType As System.Windows.Forms.Button
    Friend WithEvents btnEditLessonType As System.Windows.Forms.Button
    Friend WithEvents lvwLessonTypes As System.Windows.Forms.ListView
    Friend WithEvents colLessonTypeName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLessonTypeColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClearLevel As System.Windows.Forms.Button
    Friend WithEvents btnAddLevel As System.Windows.Forms.Button
    Friend WithEvents txtLevelName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteLevel As System.Windows.Forms.Button
    Friend WithEvents btnEditLevel As System.Windows.Forms.Button
    Friend WithEvents lvwLevels As System.Windows.Forms.ListView
    Friend WithEvents colLevelName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLevelColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClearProduct As System.Windows.Forms.Button
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteProduct As System.Windows.Forms.Button
    Friend WithEvents btnEditProduct As System.Windows.Forms.Button
    Friend WithEvents lvwProducts As System.Windows.Forms.ListView
    Friend WithEvents colProduct As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbxLessonTypeColor As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLevelColor As System.Windows.Forms.ComboBox
    Friend WithEvents btnClearPrContact As System.Windows.Forms.Button
    Friend WithEvents btnAddPrContact As System.Windows.Forms.Button
    Friend WithEvents txtPrContact As System.Windows.Forms.TextBox
    Friend WithEvents btnDeletePrContact As System.Windows.Forms.Button
    Friend WithEvents btnEditPrContact As System.Windows.Forms.Button
    Friend WithEvents lvwPrContacts As System.Windows.Forms.ListView
    Friend WithEvents colPrContacts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLevelCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtProductAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCount As System.Windows.Forms.TextBox
    Friend WithEvents colProductCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProductAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLevelCount As System.Windows.Forms.TextBox
    Friend WithEvents txtClientsPerTrack As System.Windows.Forms.TextBox
    Friend WithEvents txtClientsPerGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtClientFieldWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblClientsPerTrack As System.Windows.Forms.Label
    Friend WithEvents lblClientsPerGroup As System.Windows.Forms.Label
    Friend WithEvents lblOpeningHour As System.Windows.Forms.Label
    Friend WithEvents lblClosingHour As System.Windows.Forms.Label
    Friend WithEvents lblShowClosedHours As System.Windows.Forms.Label
    Friend WithEvents lblOnHoursColor As System.Windows.Forms.Label
    Friend WithEvents lblOffHoursColor As System.Windows.Forms.Label
    Friend WithEvents lblShowTeacherColumn As System.Windows.Forms.Label
    Friend WithEvents lblClientFieldWidth As System.Windows.Forms.Label
    Friend WithEvents cbxOnHoursColor As System.Windows.Forms.ComboBox
    Friend WithEvents cbxOffHoursColor As System.Windows.Forms.ComboBox
    Friend WithEvents cbxShowTeacherColumn As System.Windows.Forms.ComboBox
    Friend WithEvents cbxShowClosedHours As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoggingLevel As System.Windows.Forms.Label
    Friend WithEvents rbtLoggingLevel1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLoggingLevel2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLoggingLevel3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLoggingLevel4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLoggingLevel0 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLoggingLevel5 As System.Windows.Forms.RadioButton
    Friend WithEvents txtLogfileLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtLogfileName As System.Windows.Forms.TextBox
    Friend WithEvents lblLogfileName As System.Windows.Forms.Label
    Friend WithEvents lblLogfileLocation As System.Windows.Forms.Label
    Friend WithEvents cbxDataProvider As System.Windows.Forms.ComboBox
    Friend WithEvents txtDatabaseLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblDataProvider As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseLocation As System.Windows.Forms.Label
    Friend WithEvents lblLoginMethod As System.Windows.Forms.Label
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cbxLoginMethod As System.Windows.Forms.ComboBox
    Friend WithEvents txtLoginName As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabaseName As System.Windows.Forms.Label
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents btnUseDefaults As System.Windows.Forms.Button
    Friend WithEvents btnSaveSettingsView As System.Windows.Forms.Button
    Friend WithEvents btnSaveSettingsDatabase As System.Windows.Forms.Button
    Friend WithEvents cbxShowTimeWithTrack As System.Windows.Forms.ComboBox
    Friend WithEvents lblShowTimeWithTrack As System.Windows.Forms.Label
    Friend WithEvents txtDefFinanceRows As System.Windows.Forms.TextBox
    Friend WithEvents lblDefFinanceRows As System.Windows.Forms.Label
    Friend WithEvents lblTimeFrame As System.Windows.Forms.Label
    Friend WithEvents dtpOpeningHour As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTimeFrame As System.Windows.Forms.TextBox
    Friend WithEvents lblReadOnlyBackColor As System.Windows.Forms.Label
    Friend WithEvents cbxReadOnlyBackColor As System.Windows.Forms.ComboBox
    Friend WithEvents colProductTax As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbxProductTax As System.Windows.Forms.ComboBox
    Friend WithEvents dtmSeasonStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxSeasonLength As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeasonStart As System.Windows.Forms.Label
    Friend WithEvents lblSeasonLength As System.Windows.Forms.Label
    Friend WithEvents cbxUseFadingColors As System.Windows.Forms.ComboBox
    Friend WithEvents lblUseFadingColors As System.Windows.Forms.Label
    Friend WithEvents colProductSort As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtProductSort As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateDatabase As System.Windows.Forms.Button
    Friend WithEvents btnCreateDemoData As System.Windows.Forms.Button
    Friend WithEvents lblStatusDatabase As System.Windows.Forms.Label
    Friend WithEvents prbCreateDatabase As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDatabaseVersion As System.Windows.Forms.Label
    Friend WithEvents btnUpgradeDatabase As System.Windows.Forms.Button
    Friend WithEvents ofdScript As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtUpgradeDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtBackupDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblBackupDatabase As System.Windows.Forms.Label
    Friend WithEvents btnBackupDatabase As System.Windows.Forms.Button
    Friend WithEvents lblBackupPath As System.Windows.Forms.Label
    Friend WithEvents grpLogsToKeep As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearOldLogs As System.Windows.Forms.Button
    Friend WithEvents rbtKeepLogMonth As System.Windows.Forms.RadioButton
    Friend WithEvents rbtKeepLogWeek As System.Windows.Forms.RadioButton
    Friend WithEvents rbtKeepLogDay As System.Windows.Forms.RadioButton
    Friend WithEvents tpgEmail As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveSettingsEmail As System.Windows.Forms.Button
    Friend WithEvents grpEmailSmtp As System.Windows.Forms.GroupBox
    Friend WithEvents lblSmtpPortNumber As System.Windows.Forms.Label
    Friend WithEvents txtSmtpPortNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkUseSslEncryption As System.Windows.Forms.CheckBox
    Friend WithEvents lblSmtpReply As System.Windows.Forms.Label
    Friend WithEvents txtSmtpReply As System.Windows.Forms.TextBox
    Friend WithEvents chkSmtpCredentials As System.Windows.Forms.CheckBox
    Friend WithEvents lblSmtpServerPassword As System.Windows.Forms.Label
    Friend WithEvents txtSmtpServerPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblSmtpServerUsername As System.Windows.Forms.Label
    Friend WithEvents txtSmtpServerUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblSmtpServer As System.Windows.Forms.Label
    Friend WithEvents txtSmtpServer As System.Windows.Forms.TextBox
    Friend WithEvents rbtEmailUseOutlook As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEmailUseSmtp As System.Windows.Forms.RadioButton
    Friend WithEvents tpgTax As System.Windows.Forms.TabPage
    Friend WithEvents btnClearTax As System.Windows.Forms.Button
    Friend WithEvents btnAddTax As System.Windows.Forms.Button
    Friend WithEvents txtTaxDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxValue As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteTax As System.Windows.Forms.Button
    Friend WithEvents btnEditTax As System.Windows.Forms.Button
    Friend WithEvents lvwTax As System.Windows.Forms.ListView
    Friend WithEvents colTaxValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTaxDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpgLicense As System.Windows.Forms.TabPage
    Friend WithEvents lblInstallKey As System.Windows.Forms.Label
    Friend WithEvents txtInstallKey As System.Windows.Forms.TextBox
    Friend WithEvents lblLicenseKey As System.Windows.Forms.Label
    Friend WithEvents txtLicenseKey As System.Windows.Forms.TextBox
    Friend WithEvents lblExpireDate As System.Windows.Forms.Label
    Friend WithEvents txtExpiryDate As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveLicense As System.Windows.Forms.Button
    Friend WithEvents lblLicenseName As System.Windows.Forms.Label
    Friend WithEvents txtLicenseName As System.Windows.Forms.TextBox
    Friend WithEvents btnValidateLicense As System.Windows.Forms.Button
    Friend WithEvents btnExitTrackManager As System.Windows.Forms.Button
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents chkAutoDeleteOldLogs As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogToDatabase As System.Windows.Forms.Button
    Friend WithEvents chkShowAgeAfter As System.Windows.Forms.CheckBox
    Friend WithEvents txtShowAgeMax As System.Windows.Forms.TextBox
    Friend WithEvents chkShowAge As System.Windows.Forms.CheckBox
    Friend WithEvents tpgPaymentMethod As System.Windows.Forms.TabPage
    Friend WithEvents tpgLanguage As System.Windows.Forms.TabPage
    Friend WithEvents tpgReports As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveReportLessons As System.Windows.Forms.Button
    Friend WithEvents lvwReportsLessons As System.Windows.Forms.ListView
    Friend WithEvents colReportLessons As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwReportsClients As System.Windows.Forms.ListView
    Friend WithEvents colReportClients As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwReportsFinance As System.Windows.Forms.ListView
    Friend WithEvents colReportFinance As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblReportLessons As System.Windows.Forms.Label
    Friend WithEvents lblReportFinance As System.Windows.Forms.Label
    Friend WithEvents lblReportClients As System.Windows.Forms.Label
    Friend WithEvents tbnSaveReportClients As System.Windows.Forms.Button
    Friend WithEvents tbnSaveReportFinance As System.Windows.Forms.Button
    Friend WithEvents btnClearLanguage As System.Windows.Forms.Button
    Friend WithEvents btnSaveSettingsLanguage As System.Windows.Forms.Button
    Friend WithEvents TxtLanguageText As System.Windows.Forms.TextBox
    Friend WithEvents txtLanguageItem As System.Windows.Forms.TextBox
    Friend WithEvents btnLanguageImport As System.Windows.Forms.Button
    Friend WithEvents btnEditLanguage As System.Windows.Forms.Button
    Friend WithEvents lvwLanguage As System.Windows.Forms.ListView
    Friend WithEvents colItemName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItemText As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItemType As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLanguageSaveAll As System.Windows.Forms.Button
    Friend WithEvents lblCurrentLanguage As System.Windows.Forms.Label
    Friend WithEvents btnAddLanguage As System.Windows.Forms.Button
    Friend WithEvents btnDeleteLanguage As System.Windows.Forms.Button
    Friend WithEvents lblLanguageDefault As System.Windows.Forms.Label
    Friend WithEvents lbxLanguage As System.Windows.Forms.ListBox
    Friend WithEvents btnLanguageLoad As System.Windows.Forms.Button
    Friend WithEvents cbxLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents btnLanguageExport As System.Windows.Forms.Button
    Friend WithEvents cbxLanguageType As System.Windows.Forms.ComboBox
    Friend WithEvents lblLanguageType As System.Windows.Forms.Label
    Friend WithEvents lblLanguageText As System.Windows.Forms.Label
    Friend WithEvents lblLanguageItem As System.Windows.Forms.Label
    Friend WithEvents lblLanguageForm As System.Windows.Forms.Label
    Friend WithEvents cbxLanguageForm As System.Windows.Forms.ComboBox
    Friend WithEvents tpgButtons As System.Windows.Forms.TabPage
    Friend WithEvents btnButtonDown As System.Windows.Forms.Button
    Friend WithEvents btnButtonUp As System.Windows.Forms.Button
    Friend WithEvents lvwButtons As System.Windows.Forms.ListView
    Friend WithEvents btnButtonOrderSave As System.Windows.Forms.Button
    Friend WithEvents tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents grpDisplayWarningOverbooked As System.Windows.Forms.GroupBox
    Friend WithEvents rbnOverbookingClient As System.Windows.Forms.RadioButton
    Friend WithEvents rbnOverbookingGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbnOverbookingNone As System.Windows.Forms.RadioButton
    Friend WithEvents btnSaveSettingsGeneral As System.Windows.Forms.Button
    Friend WithEvents chkSelectMultipleGroups As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeleteEmptyInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceNumber As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceName As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceName As System.Windows.Forms.Label
    Friend WithEvents grpShowOpenBills As System.Windows.Forms.GroupBox
    Friend WithEvents rbnShowOpenBillsGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbnShowOpenBillsClient As System.Windows.Forms.RadioButton
    Friend WithEvents rbnShowOpenBillsNone As System.Windows.Forms.RadioButton
    Friend WithEvents chkShowLastAppointment As System.Windows.Forms.CheckBox
    Friend WithEvents lblDateFormat As System.Windows.Forms.Label
    Friend WithEvents cbxDateFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkShowAllLessonTypes As System.Windows.Forms.CheckBox
    Friend WithEvents chkRequireLessontype As System.Windows.Forms.CheckBox
    Friend WithEvents cbxClientFieldHeight As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientFieldHeight As System.Windows.Forms.Label
    Friend WithEvents dtpClosingHour As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRefreshDatabase As System.Windows.Forms.Button
    Friend WithEvents chkDeleteMax1Client As System.Windows.Forms.CheckBox
    Friend WithEvents txtArchiveEmail As TextBox
    Friend WithEvents chkArchiveEmail As CheckBox
End Class
