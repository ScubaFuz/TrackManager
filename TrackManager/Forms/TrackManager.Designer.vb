<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrackManager
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrackManager))
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuMainFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainFileLogoff = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainFileReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEditDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEditTrack = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEditHour = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEditClearAllLocks = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainEditScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindowSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindowSecurity = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindowGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindowClients = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainWindowFinance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainHelpManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainHelpUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMemoSave = New System.Windows.Forms.Button()
        Me.btnTest1 = New System.Windows.Forms.Button()
        Me.btnTest2 = New System.Windows.Forms.Button()
        Me.sptTrackManager = New System.Windows.Forms.SplitContainer()
        Me.tabTrackManager = New System.Windows.Forms.TabControl()
        Me.tpgTracks = New System.Windows.Forms.TabPage()
        Me.vsbTracks = New System.Windows.Forms.VScrollBar()
        Me.pnlTracks = New System.Windows.Forms.Panel()
        Me.lblTracksBar = New System.Windows.Forms.Label()
        Me.tabTracks = New System.Windows.Forms.TabControl()
        Me.tpgTrack1 = New System.Windows.Forms.TabPage()
        Me.grpTrack2 = New System.Windows.Forms.GroupBox()
        Me.grpTrack1 = New System.Windows.Forms.GroupBox()
        Me.lblTrackTeacher = New System.Windows.Forms.Label()
        Me.lblTrackClient = New System.Windows.Forms.Label()
        Me.tpgGroups = New System.Windows.Forms.TabPage()
        Me.spcGroups = New System.Windows.Forms.SplitContainer()
        Me.grpGroupApp = New System.Windows.Forms.GroupBox()
        Me.btnGrpAppRemove = New System.Windows.Forms.Button()
        Me.btnGrpAppAdd = New System.Windows.Forms.Button()
        Me.btnGroupUpdateLevel = New System.Windows.Forms.Button()
        Me.grpMainContact = New System.Windows.Forms.GroupBox()
        Me.btnGroupsMainContact = New System.Windows.Forms.Button()
        Me.txtMainContactMobile = New System.Windows.Forms.TextBox()
        Me.txtMainContactPhone = New System.Windows.Forms.TextBox()
        Me.txtMainContactEmail = New System.Windows.Forms.TextBox()
        Me.txtMainContactCity = New System.Windows.Forms.TextBox()
        Me.txtMainContactAddress = New System.Windows.Forms.TextBox()
        Me.txtMainContactName = New System.Windows.Forms.TextBox()
        Me.grpGroupDetails = New System.Windows.Forms.GroupBox()
        Me.txtGroupSearch = New System.Windows.Forms.TextBox()
        Me.lvwGroups = New System.Windows.Forms.ListView()
        Me.btnGroupEditClient = New System.Windows.Forms.Button()
        Me.btnGroupManage = New System.Windows.Forms.Button()
        Me.grpGroupMembers = New System.Windows.Forms.GroupBox()
        Me.cbxCorrectLessonCount = New System.Windows.Forms.ComboBox()
        Me.btnCorrectLessonCount = New System.Windows.Forms.Button()
        Me.grpGroupClientsView = New System.Windows.Forms.GroupBox()
        Me.pnlGroupsView = New System.Windows.Forms.Panel()
        Me.grpGroupClients = New System.Windows.Forms.GroupBox()
        Me.lblGroupLessonsTotal = New System.Windows.Forms.Label()
        Me.lblGroupLessonsBilled = New System.Windows.Forms.Label()
        Me.txtGroupLessonsBilled = New System.Windows.Forms.TextBox()
        Me.txtGroupLessonsTotal = New System.Windows.Forms.TextBox()
        Me.vsbGroupClients = New System.Windows.Forms.VScrollBar()
        Me.chkGroupHeader = New System.Windows.Forms.CheckBox()
        Me.lblGroupClientLevel = New System.Windows.Forms.Label()
        Me.lblGroupExtraCount = New System.Windows.Forms.Label()
        Me.lblGroupLessonCount = New System.Windows.Forms.Label()
        Me.lblGroupLessonType = New System.Windows.Forms.Label()
        Me.lblGroupsFullName = New System.Windows.Forms.Label()
        Me.tpgFinance = New System.Windows.Forms.TabPage()
        Me.spcFinance = New System.Windows.Forms.SplitContainer()
        Me.txtFinanceGroupSearch = New System.Windows.Forms.TextBox()
        Me.btnFinancePay = New System.Windows.Forms.Button()
        Me.btnFinanceDelete = New System.Windows.Forms.Button()
        Me.lvwProduct = New System.Windows.Forms.ListView()
        Me.colProducts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductCounts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductAmounts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductTax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblFinanceProduct = New System.Windows.Forms.Label()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.lblGroupName = New System.Windows.Forms.Label()
        Me.lvwFinanceClients = New System.Windows.Forms.ListView()
        Me.lvwFinanceGroups = New System.Windows.Forms.ListView()
        Me.btnFinanceAdd = New System.Windows.Forms.Button()
        Me.btnFinanceEdit = New System.Windows.Forms.Button()
        Me.grpFinanceGroupPayments = New System.Windows.Forms.GroupBox()
        Me.lvwFinance = New System.Windows.Forms.ListView()
        Me.colDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLogin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBilledAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayedAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOpenAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFinancePayDue = New System.Windows.Forms.TextBox()
        Me.lblFinancePayDue = New System.Windows.Forms.Label()
        Me.txtFinancePayCount = New System.Windows.Forms.TextBox()
        Me.txtFinancePayPayed = New System.Windows.Forms.TextBox()
        Me.txtFinancePayBilled = New System.Windows.Forms.TextBox()
        Me.lblFinancePayTotal = New System.Windows.Forms.Label()
        Me.tpgReports = New System.Windows.Forms.TabPage()
        Me.cbxRepGroup = New System.Windows.Forms.ComboBox()
        Me.cbxRepClient = New System.Windows.Forms.ComboBox()
        Me.cbxRepLessonType = New System.Windows.Forms.ComboBox()
        Me.chkRepLimitLessonType = New System.Windows.Forms.CheckBox()
        Me.cbxRepTrack = New System.Windows.Forms.ComboBox()
        Me.btnFav5 = New System.Windows.Forms.Button()
        Me.btnFav4 = New System.Windows.Forms.Button()
        Me.btnFav3 = New System.Windows.Forms.Button()
        Me.btnFav2 = New System.Windows.Forms.Button()
        Me.btnFav1 = New System.Windows.Forms.Button()
        Me.cbxRepOther = New System.Windows.Forms.ComboBox()
        Me.lblRepOther = New System.Windows.Forms.Label()
        Me.btnRepReportCreate = New System.Windows.Forms.Button()
        Me.cbxRepClients = New System.Windows.Forms.ComboBox()
        Me.cbxRepFinance = New System.Windows.Forms.ComboBox()
        Me.cbxRepLessons = New System.Windows.Forms.ComboBox()
        Me.lblRepClients = New System.Windows.Forms.Label()
        Me.lblRepFinance = New System.Windows.Forms.Label()
        Me.lblRepLessons = New System.Windows.Forms.Label()
        Me.btnRep2 = New System.Windows.Forms.Button()
        Me.rtbRepReportFooter = New System.Windows.Forms.RichTextBox()
        Me.rtbRepReportHeader = New System.Windows.Forms.RichTextBox()
        Me.grpRepReportWidth = New System.Windows.Forms.GroupBox()
        Me.txtRepReportWidth = New System.Windows.Forms.TextBox()
        Me.trbRepReportWidth = New System.Windows.Forms.TrackBar()
        Me.chkRepReportWidth = New System.Windows.Forms.CheckBox()
        Me.dgvRepReport = New System.Windows.Forms.DataGridView()
        Me.btnRepEmail = New System.Windows.Forms.Button()
        Me.grpRepLimitType = New System.Windows.Forms.GroupBox()
        Me.rbnRepLimitTypeBar = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitTypeTeacher = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitTypeClient = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitTypeAll = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitMonth = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitWeek = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitDay = New System.Windows.Forms.RadioButton()
        Me.rbnRepLimitSeason = New System.Windows.Forms.RadioButton()
        Me.btnRep4 = New System.Windows.Forms.Button()
        Me.btnRep5 = New System.Windows.Forms.Button()
        Me.btnRep3 = New System.Windows.Forms.Button()
        Me.btnRep1 = New System.Windows.Forms.Button()
        Me.tstReports = New System.Windows.Forms.ToolStrip()
        Me.tbnRepNew = New System.Windows.Forms.ToolStripButton()
        Me.tbnRepOpen = New System.Windows.Forms.ToolStripButton()
        Me.tbnRepSave = New System.Windows.Forms.ToolStripButton()
        Me.tbnRepPrint = New System.Windows.Forms.ToolStripButton()
        Me.tbnRepFont = New System.Windows.Forms.ToolStripButton()
        Me.chkRepLimitInvoice = New System.Windows.Forms.CheckBox()
        Me.lblRepLimitSelection = New System.Windows.Forms.Label()
        Me.chkRepLimitClient = New System.Windows.Forms.CheckBox()
        Me.chkRepLimitGroup = New System.Windows.Forms.CheckBox()
        Me.chkRepLimitTrack = New System.Windows.Forms.CheckBox()
        Me.mnuReports = New System.Windows.Forms.MenuStrip()
        Me.mnuRepFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepFilePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepFileRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepEditFont = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgSearch = New System.Windows.Forms.TabPage()
        Me.txtSearchPhone = New System.Windows.Forms.TextBox()
        Me.lblSearchPhone = New System.Windows.Forms.Label()
        Me.txtSearchMaximum = New System.Windows.Forms.TextBox()
        Me.lblSearchMaximum = New System.Windows.Forms.Label()
        Me.lbl2CharacterMinimum = New System.Windows.Forms.Label()
        Me.grpMatchNumber = New System.Windows.Forms.GroupBox()
        Me.rbnMatchAll = New System.Windows.Forms.RadioButton()
        Me.rbnMatchAny = New System.Windows.Forms.RadioButton()
        Me.grpMatchPerItem = New System.Windows.Forms.GroupBox()
        Me.rbnPartialMatchAny = New System.Windows.Forms.RadioButton()
        Me.rbnExactMatch = New System.Windows.Forms.RadioButton()
        Me.rbnPartialMatchLeft = New System.Windows.Forms.RadioButton()
        Me.btnSearchClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lvwSearchResult = New System.Windows.Forms.ListView()
        Me.colSearchName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchPostalCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchCity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchTelephone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchMobile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchEmail = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchDayOfBirth = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchGroupName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchCountry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSearchGroupId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpSearchDayOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchDayOfBirth = New System.Windows.Forms.Label()
        Me.txtSearchEmail = New System.Windows.Forms.TextBox()
        Me.lblSearchEmail = New System.Windows.Forms.Label()
        Me.txtSearchGroupName = New System.Windows.Forms.TextBox()
        Me.lblSearchGroupName = New System.Windows.Forms.Label()
        Me.txtSearchPostalCode = New System.Windows.Forms.TextBox()
        Me.lblSearchPostalCode = New System.Windows.Forms.Label()
        Me.txtSearchCity = New System.Windows.Forms.TextBox()
        Me.lblSearchCity = New System.Windows.Forms.Label()
        Me.txtSearchLastName = New System.Windows.Forms.TextBox()
        Me.lblSearchLastName = New System.Windows.Forms.Label()
        Me.txtSearchFirstName = New System.Windows.Forms.TextBox()
        Me.lblSearchFirstName = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.opnReport = New System.Windows.Forms.OpenFileDialog()
        Me.savReport = New System.Windows.Forms.SaveFileDialog()
        Me.fntReport = New System.Windows.Forms.FontDialog()
        Me.prnReport = New System.Windows.Forms.PrintDialog()
        Me.btnTest3 = New System.Windows.Forms.Button()
        Me.txtTest1 = New System.Windows.Forms.TextBox()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.lblLicenseName = New System.Windows.Forms.Label()
        Me.dtsRepReport = New System.Data.DataSet()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.calTrackMan = New System.Windows.Forms.MonthCalendar()
        Me.grpCalButtons = New System.Windows.Forms.GroupBox()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnNextWeek = New System.Windows.Forms.Button()
        Me.btnNextDay = New System.Windows.Forms.Button()
        Me.btnToday = New System.Windows.Forms.Button()
        Me.btnPrevDay = New System.Windows.Forms.Button()
        Me.btnPrevWeek = New System.Windows.Forms.Button()
        Me.btnPrevMonth = New System.Windows.Forms.Button()
        Me.grpAppDetails = New System.Windows.Forms.GroupBox()
        Me.chkListClient = New System.Windows.Forms.CheckBox()
        Me.lvwAppClients = New System.Windows.Forms.ListView()
        Me.colAppClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAppLessonType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAppLessonCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblAppDetailsTrack = New System.Windows.Forms.Label()
        Me.txtAppDetailsTrack = New System.Windows.Forms.TextBox()
        Me.lblAppDetailsTime = New System.Windows.Forms.Label()
        Me.txtAppDetailsTime = New System.Windows.Forms.TextBox()
        Me.lblAppDetailsDate = New System.Windows.Forms.Label()
        Me.txtAppDetailsDate = New System.Windows.Forms.TextBox()
        Me.grpAppButtons = New System.Windows.Forms.GroupBox()
        Me.btnAppRemove = New System.Windows.Forms.Button()
        Me.btnAppClear = New System.Windows.Forms.Button()
        Me.btnAppDelete = New System.Windows.Forms.Button()
        Me.btnAppMove = New System.Windows.Forms.Button()
        Me.btnAppCreate = New System.Windows.Forms.Button()
        Me.grpCurrentSelection = New System.Windows.Forms.GroupBox()
        Me.btnClientProps = New System.Windows.Forms.Button()
        Me.lblCurrentSelectionClient = New System.Windows.Forms.Label()
        Me.txtCurrentSelectionClient = New System.Windows.Forms.TextBox()
        Me.lblCurrentSelectionGroup = New System.Windows.Forms.Label()
        Me.txtCurrentSelectionGroup = New System.Windows.Forms.TextBox()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.mnuMain.SuspendLayout()
        CType(Me.sptTrackManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sptTrackManager.Panel1.SuspendLayout()
        Me.sptTrackManager.Panel2.SuspendLayout()
        Me.sptTrackManager.SuspendLayout()
        Me.tabTrackManager.SuspendLayout()
        Me.tpgTracks.SuspendLayout()
        Me.pnlTracks.SuspendLayout()
        Me.tabTracks.SuspendLayout()
        Me.tpgTrack1.SuspendLayout()
        Me.grpTrack1.SuspendLayout()
        Me.tpgGroups.SuspendLayout()
        CType(Me.spcGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcGroups.Panel1.SuspendLayout()
        Me.spcGroups.Panel2.SuspendLayout()
        Me.spcGroups.SuspendLayout()
        Me.grpGroupApp.SuspendLayout()
        Me.grpMainContact.SuspendLayout()
        Me.grpGroupDetails.SuspendLayout()
        Me.grpGroupMembers.SuspendLayout()
        Me.grpGroupClientsView.SuspendLayout()
        Me.pnlGroupsView.SuspendLayout()
        Me.tpgFinance.SuspendLayout()
        CType(Me.spcFinance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcFinance.Panel1.SuspendLayout()
        Me.spcFinance.Panel2.SuspendLayout()
        Me.spcFinance.SuspendLayout()
        Me.grpFinanceGroupPayments.SuspendLayout()
        Me.tpgReports.SuspendLayout()
        Me.grpRepReportWidth.SuspendLayout()
        CType(Me.trbRepReportWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRepReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRepLimitType.SuspendLayout()
        Me.tstReports.SuspendLayout()
        Me.mnuReports.SuspendLayout()
        Me.tpgSearch.SuspendLayout()
        Me.grpMatchNumber.SuspendLayout()
        Me.grpMatchPerItem.SuspendLayout()
        CType(Me.dtsRepReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.grpCalButtons.SuspendLayout()
        Me.grpAppDetails.SuspendLayout()
        Me.grpAppButtons.SuspendLayout()
        Me.grpCurrentSelection.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(16, 707)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(51, 16)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(76, 708)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(900, 20)
        Me.txtStatus.TabIndex = 12
        Me.txtStatus.TabStop = False
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainFile, Me.mnuMainEdit, Me.mnuMainWindow, Me.mnuMainHelp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(1104, 24)
        Me.mnuMain.TabIndex = 13
        '
        'mnuMainFile
        '
        Me.mnuMainFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainFileLogoff, Me.mnuMainFileReload, Me.mnuMainFileExit})
        Me.mnuMainFile.Name = "mnuMainFile"
        Me.mnuMainFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuMainFile.Text = "&File"
        '
        'mnuMainFileLogoff
        '
        Me.mnuMainFileLogoff.Name = "mnuMainFileLogoff"
        Me.mnuMainFileLogoff.Size = New System.Drawing.Size(170, 22)
        Me.mnuMainFileLogoff.Text = "&Log off"
        '
        'mnuMainFileReload
        '
        Me.mnuMainFileReload.Name = "mnuMainFileReload"
        Me.mnuMainFileReload.Size = New System.Drawing.Size(170, 22)
        Me.mnuMainFileReload.Text = "&Reload"
        '
        'mnuMainFileExit
        '
        Me.mnuMainFileExit.Name = "mnuMainFileExit"
        Me.mnuMainFileExit.Size = New System.Drawing.Size(170, 22)
        Me.mnuMainFileExit.Text = "E&xit TrackManager"
        '
        'mnuMainEdit
        '
        Me.mnuMainEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainEditDay, Me.mnuMainEditTrack, Me.mnuMainEditHour, Me.mnuMainEditClearAllLocks, Me.mnuMainEditScreen})
        Me.mnuMainEdit.Name = "mnuMainEdit"
        Me.mnuMainEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuMainEdit.Text = "&Edit"
        '
        'mnuMainEditDay
        '
        Me.mnuMainEditDay.Name = "mnuMainEditDay"
        Me.mnuMainEditDay.Size = New System.Drawing.Size(214, 22)
        Me.mnuMainEditDay.Text = "Lock / Unlock &Day"
        '
        'mnuMainEditTrack
        '
        Me.mnuMainEditTrack.Enabled = False
        Me.mnuMainEditTrack.Name = "mnuMainEditTrack"
        Me.mnuMainEditTrack.Size = New System.Drawing.Size(214, 22)
        Me.mnuMainEditTrack.Text = "Lock / Unlock &Track"
        '
        'mnuMainEditHour
        '
        Me.mnuMainEditHour.Enabled = False
        Me.mnuMainEditHour.Name = "mnuMainEditHour"
        Me.mnuMainEditHour.Size = New System.Drawing.Size(214, 22)
        Me.mnuMainEditHour.Text = "Lock / Unlock &Hour"
        '
        'mnuMainEditClearAllLocks
        '
        Me.mnuMainEditClearAllLocks.Name = "mnuMainEditClearAllLocks"
        Me.mnuMainEditClearAllLocks.Size = New System.Drawing.Size(214, 22)
        Me.mnuMainEditClearAllLocks.Text = "&Clear All Locks"
        '
        'mnuMainEditScreen
        '
        Me.mnuMainEditScreen.Name = "mnuMainEditScreen"
        Me.mnuMainEditScreen.Size = New System.Drawing.Size(214, 22)
        Me.mnuMainEditScreen.Text = "Save &Screensize && position"
        '
        'mnuMainWindow
        '
        Me.mnuMainWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainWindowSettings, Me.mnuMainWindowSecurity, Me.mnuMainWindowGroups, Me.mnuMainWindowClients, Me.mnuMainWindowFinance})
        Me.mnuMainWindow.Name = "mnuMainWindow"
        Me.mnuMainWindow.Size = New System.Drawing.Size(63, 20)
        Me.mnuMainWindow.Text = "&Window"
        '
        'mnuMainWindowSettings
        '
        Me.mnuMainWindowSettings.Enabled = False
        Me.mnuMainWindowSettings.Name = "mnuMainWindowSettings"
        Me.mnuMainWindowSettings.Size = New System.Drawing.Size(116, 22)
        Me.mnuMainWindowSettings.Text = "&Settings"
        '
        'mnuMainWindowSecurity
        '
        Me.mnuMainWindowSecurity.Enabled = False
        Me.mnuMainWindowSecurity.Name = "mnuMainWindowSecurity"
        Me.mnuMainWindowSecurity.Size = New System.Drawing.Size(116, 22)
        Me.mnuMainWindowSecurity.Text = "Se&curity"
        '
        'mnuMainWindowGroups
        '
        Me.mnuMainWindowGroups.Name = "mnuMainWindowGroups"
        Me.mnuMainWindowGroups.Size = New System.Drawing.Size(116, 22)
        Me.mnuMainWindowGroups.Text = "&Groups"
        '
        'mnuMainWindowClients
        '
        Me.mnuMainWindowClients.Name = "mnuMainWindowClients"
        Me.mnuMainWindowClients.Size = New System.Drawing.Size(116, 22)
        Me.mnuMainWindowClients.Text = "&Clients"
        '
        'mnuMainWindowFinance
        '
        Me.mnuMainWindowFinance.Name = "mnuMainWindowFinance"
        Me.mnuMainWindowFinance.Size = New System.Drawing.Size(116, 22)
        Me.mnuMainWindowFinance.Text = "&Finance"
        '
        'mnuMainHelp
        '
        Me.mnuMainHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainHelpManual, Me.mnuMainHelpAbout, Me.mnuMainHelpUpdates})
        Me.mnuMainHelp.Name = "mnuMainHelp"
        Me.mnuMainHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuMainHelp.Text = "&Help"
        '
        'mnuMainHelpManual
        '
        Me.mnuMainHelpManual.Name = "mnuMainHelpManual"
        Me.mnuMainHelpManual.Size = New System.Drawing.Size(171, 22)
        Me.mnuMainHelpManual.Text = "&Manual"
        '
        'mnuMainHelpAbout
        '
        Me.mnuMainHelpAbout.Name = "mnuMainHelpAbout"
        Me.mnuMainHelpAbout.Size = New System.Drawing.Size(171, 22)
        Me.mnuMainHelpAbout.Text = "&About"
        '
        'mnuMainHelpUpdates
        '
        Me.mnuMainHelpUpdates.Name = "mnuMainHelpUpdates"
        Me.mnuMainHelpUpdates.Size = New System.Drawing.Size(171, 22)
        Me.mnuMainHelpUpdates.Text = "Check for &Updates"
        '
        'btnMemoSave
        '
        Me.btnMemoSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMemoSave.Enabled = False
        Me.btnMemoSave.Location = New System.Drawing.Point(10, 637)
        Me.btnMemoSave.Name = "btnMemoSave"
        Me.btnMemoSave.Size = New System.Drawing.Size(181, 23)
        Me.btnMemoSave.TabIndex = 12
        Me.btnMemoSave.Text = "Save Memo"
        Me.btnMemoSave.UseVisualStyleBackColor = True
        '
        'btnTest1
        '
        Me.btnTest1.Location = New System.Drawing.Point(619, 1)
        Me.btnTest1.Name = "btnTest1"
        Me.btnTest1.Size = New System.Drawing.Size(75, 23)
        Me.btnTest1.TabIndex = 16
        Me.btnTest1.Text = "Test1"
        Me.btnTest1.UseVisualStyleBackColor = True
        Me.btnTest1.Visible = False
        '
        'btnTest2
        '
        Me.btnTest2.Location = New System.Drawing.Point(700, 1)
        Me.btnTest2.Name = "btnTest2"
        Me.btnTest2.Size = New System.Drawing.Size(75, 23)
        Me.btnTest2.TabIndex = 17
        Me.btnTest2.Text = "Test2"
        Me.btnTest2.UseVisualStyleBackColor = True
        Me.btnTest2.Visible = False
        '
        'sptTrackManager
        '
        Me.sptTrackManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sptTrackManager.Location = New System.Drawing.Point(207, 27)
        Me.sptTrackManager.Name = "sptTrackManager"
        Me.sptTrackManager.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'sptTrackManager.Panel1
        '
        Me.sptTrackManager.Panel1.Controls.Add(Me.tabTrackManager)
        '
        'sptTrackManager.Panel2
        '
        Me.sptTrackManager.Panel2.Controls.Add(Me.txtMemo)
        Me.sptTrackManager.Size = New System.Drawing.Size(876, 670)
        Me.sptTrackManager.SplitterDistance = 603
        Me.sptTrackManager.TabIndex = 18
        '
        'tabTrackManager
        '
        Me.tabTrackManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTrackManager.Controls.Add(Me.tpgTracks)
        Me.tabTrackManager.Controls.Add(Me.tpgGroups)
        Me.tabTrackManager.Controls.Add(Me.tpgFinance)
        Me.tabTrackManager.Controls.Add(Me.tpgReports)
        Me.tabTrackManager.Controls.Add(Me.tpgSearch)
        Me.tabTrackManager.Location = New System.Drawing.Point(1, 1)
        Me.tabTrackManager.Name = "tabTrackManager"
        Me.tabTrackManager.SelectedIndex = 0
        Me.tabTrackManager.Size = New System.Drawing.Size(872, 599)
        Me.tabTrackManager.TabIndex = 12
        '
        'tpgTracks
        '
        Me.tpgTracks.Controls.Add(Me.vsbTracks)
        Me.tpgTracks.Controls.Add(Me.pnlTracks)
        Me.tpgTracks.Location = New System.Drawing.Point(4, 22)
        Me.tpgTracks.Name = "tpgTracks"
        Me.tpgTracks.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTracks.Size = New System.Drawing.Size(864, 573)
        Me.tpgTracks.TabIndex = 0
        Me.tpgTracks.Text = "Tracks"
        Me.tpgTracks.UseVisualStyleBackColor = True
        '
        'vsbTracks
        '
        Me.vsbTracks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsbTracks.LargeChange = 420
        Me.vsbTracks.Location = New System.Drawing.Point(844, 6)
        Me.vsbTracks.Maximum = 420
        Me.vsbTracks.Name = "vsbTracks"
        Me.vsbTracks.Size = New System.Drawing.Size(17, 563)
        Me.vsbTracks.SmallChange = 21
        Me.vsbTracks.TabIndex = 4
        '
        'pnlTracks
        '
        Me.pnlTracks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTracks.Controls.Add(Me.lblTracksBar)
        Me.pnlTracks.Controls.Add(Me.tabTracks)
        Me.pnlTracks.Location = New System.Drawing.Point(6, 6)
        Me.pnlTracks.Name = "pnlTracks"
        Me.pnlTracks.Size = New System.Drawing.Size(835, 486)
        Me.pnlTracks.TabIndex = 3
        '
        'lblTracksBar
        '
        Me.lblTracksBar.Location = New System.Drawing.Point(3, 47)
        Me.lblTracksBar.Name = "lblTracksBar"
        Me.lblTracksBar.Size = New System.Drawing.Size(23, 13)
        Me.lblTracksBar.TabIndex = 1
        Me.lblTracksBar.Text = "Bar"
        '
        'tabTracks
        '
        Me.tabTracks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTracks.Controls.Add(Me.tpgTrack1)
        Me.tabTracks.Location = New System.Drawing.Point(103, 3)
        Me.tabTracks.Name = "tabTracks"
        Me.tabTracks.SelectedIndex = 0
        Me.tabTracks.Size = New System.Drawing.Size(729, 480)
        Me.tabTracks.TabIndex = 2
        '
        'tpgTrack1
        '
        Me.tpgTrack1.Controls.Add(Me.grpTrack2)
        Me.tpgTrack1.Controls.Add(Me.grpTrack1)
        Me.tpgTrack1.Location = New System.Drawing.Point(4, 22)
        Me.tpgTrack1.Name = "tpgTrack1"
        Me.tpgTrack1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTrack1.Size = New System.Drawing.Size(721, 454)
        Me.tpgTrack1.TabIndex = 0
        Me.tpgTrack1.Text = "Track1 && Track2"
        Me.tpgTrack1.UseVisualStyleBackColor = True
        '
        'grpTrack2
        '
        Me.grpTrack2.Location = New System.Drawing.Point(268, 6)
        Me.grpTrack2.Name = "grpTrack2"
        Me.grpTrack2.Size = New System.Drawing.Size(256, 449)
        Me.grpTrack2.TabIndex = 1
        Me.grpTrack2.TabStop = False
        Me.grpTrack2.Text = "Track2"
        '
        'grpTrack1
        '
        Me.grpTrack1.Controls.Add(Me.lblTrackTeacher)
        Me.grpTrack1.Controls.Add(Me.lblTrackClient)
        Me.grpTrack1.Location = New System.Drawing.Point(6, 6)
        Me.grpTrack1.Name = "grpTrack1"
        Me.grpTrack1.Size = New System.Drawing.Size(256, 449)
        Me.grpTrack1.TabIndex = 0
        Me.grpTrack1.TabStop = False
        Me.grpTrack1.Text = "Track1"
        '
        'lblTrackTeacher
        '
        Me.lblTrackTeacher.AutoSize = True
        Me.lblTrackTeacher.Location = New System.Drawing.Point(203, 16)
        Me.lblTrackTeacher.Name = "lblTrackTeacher"
        Me.lblTrackTeacher.Size = New System.Drawing.Size(47, 13)
        Me.lblTrackTeacher.TabIndex = 3
        Me.lblTrackTeacher.Text = "Teacher"
        '
        'lblTrackClient
        '
        Me.lblTrackClient.AutoSize = True
        Me.lblTrackClient.Location = New System.Drawing.Point(6, 16)
        Me.lblTrackClient.Name = "lblTrackClient"
        Me.lblTrackClient.Size = New System.Drawing.Size(33, 13)
        Me.lblTrackClient.TabIndex = 2
        Me.lblTrackClient.Text = "Client"
        '
        'tpgGroups
        '
        Me.tpgGroups.Controls.Add(Me.spcGroups)
        Me.tpgGroups.Location = New System.Drawing.Point(4, 22)
        Me.tpgGroups.Name = "tpgGroups"
        Me.tpgGroups.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgGroups.Size = New System.Drawing.Size(864, 573)
        Me.tpgGroups.TabIndex = 1
        Me.tpgGroups.Text = "Groups"
        Me.tpgGroups.UseVisualStyleBackColor = True
        '
        'spcGroups
        '
        Me.spcGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spcGroups.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.spcGroups.Location = New System.Drawing.Point(3, 3)
        Me.spcGroups.Name = "spcGroups"
        '
        'spcGroups.Panel1
        '
        Me.spcGroups.Panel1.Controls.Add(Me.grpGroupApp)
        Me.spcGroups.Panel1.Controls.Add(Me.btnGroupUpdateLevel)
        Me.spcGroups.Panel1.Controls.Add(Me.grpMainContact)
        Me.spcGroups.Panel1.Controls.Add(Me.grpGroupDetails)
        Me.spcGroups.Panel1MinSize = 230
        '
        'spcGroups.Panel2
        '
        Me.spcGroups.Panel2.Controls.Add(Me.grpGroupMembers)
        Me.spcGroups.Size = New System.Drawing.Size(858, 570)
        Me.spcGroups.SplitterDistance = 230
        Me.spcGroups.TabIndex = 13
        '
        'grpGroupApp
        '
        Me.grpGroupApp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGroupApp.Controls.Add(Me.btnGrpAppRemove)
        Me.grpGroupApp.Controls.Add(Me.btnGrpAppAdd)
        Me.grpGroupApp.Location = New System.Drawing.Point(6, 281)
        Me.grpGroupApp.Name = "grpGroupApp"
        Me.grpGroupApp.Size = New System.Drawing.Size(218, 70)
        Me.grpGroupApp.TabIndex = 16
        Me.grpGroupApp.TabStop = False
        '
        'btnGrpAppRemove
        '
        Me.btnGrpAppRemove.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrpAppRemove.Enabled = False
        Me.btnGrpAppRemove.Location = New System.Drawing.Point(6, 40)
        Me.btnGrpAppRemove.Name = "btnGrpAppRemove"
        Me.btnGrpAppRemove.Size = New System.Drawing.Size(206, 23)
        Me.btnGrpAppRemove.TabIndex = 6
        Me.btnGrpAppRemove.Text = "Remove from Appointment"
        Me.btnGrpAppRemove.UseVisualStyleBackColor = True
        '
        'btnGrpAppAdd
        '
        Me.btnGrpAppAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrpAppAdd.Enabled = False
        Me.btnGrpAppAdd.Location = New System.Drawing.Point(6, 14)
        Me.btnGrpAppAdd.Name = "btnGrpAppAdd"
        Me.btnGrpAppAdd.Size = New System.Drawing.Size(206, 23)
        Me.btnGrpAppAdd.TabIndex = 5
        Me.btnGrpAppAdd.Text = "Add to Appointment"
        Me.btnGrpAppAdd.UseVisualStyleBackColor = True
        '
        'btnGroupUpdateLevel
        '
        Me.btnGroupUpdateLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGroupUpdateLevel.Enabled = False
        Me.btnGroupUpdateLevel.Location = New System.Drawing.Point(12, 357)
        Me.btnGroupUpdateLevel.Name = "btnGroupUpdateLevel"
        Me.btnGroupUpdateLevel.Size = New System.Drawing.Size(206, 23)
        Me.btnGroupUpdateLevel.TabIndex = 13
        Me.btnGroupUpdateLevel.Text = "Save Client Settings"
        Me.btnGroupUpdateLevel.UseVisualStyleBackColor = True
        '
        'grpMainContact
        '
        Me.grpMainContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMainContact.Controls.Add(Me.btnGroupsMainContact)
        Me.grpMainContact.Controls.Add(Me.txtMainContactMobile)
        Me.grpMainContact.Controls.Add(Me.txtMainContactPhone)
        Me.grpMainContact.Controls.Add(Me.txtMainContactEmail)
        Me.grpMainContact.Controls.Add(Me.txtMainContactCity)
        Me.grpMainContact.Controls.Add(Me.txtMainContactAddress)
        Me.grpMainContact.Controls.Add(Me.txtMainContactName)
        Me.grpMainContact.Location = New System.Drawing.Point(6, 386)
        Me.grpMainContact.Name = "grpMainContact"
        Me.grpMainContact.Size = New System.Drawing.Size(218, 181)
        Me.grpMainContact.TabIndex = 15
        Me.grpMainContact.TabStop = False
        Me.grpMainContact.Text = "Main Contact"
        '
        'btnGroupsMainContact
        '
        Me.btnGroupsMainContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGroupsMainContact.Enabled = False
        Me.btnGroupsMainContact.Location = New System.Drawing.Point(6, 149)
        Me.btnGroupsMainContact.Name = "btnGroupsMainContact"
        Me.btnGroupsMainContact.Size = New System.Drawing.Size(206, 23)
        Me.btnGroupsMainContact.TabIndex = 4
        Me.btnGroupsMainContact.Text = "Set as Main Contact"
        Me.btnGroupsMainContact.UseVisualStyleBackColor = True
        '
        'txtMainContactMobile
        '
        Me.txtMainContactMobile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainContactMobile.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactMobile.Enabled = False
        Me.txtMainContactMobile.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactMobile.Location = New System.Drawing.Point(112, 123)
        Me.txtMainContactMobile.Name = "txtMainContactMobile"
        Me.txtMainContactMobile.ReadOnly = True
        Me.txtMainContactMobile.Size = New System.Drawing.Size(100, 20)
        Me.txtMainContactMobile.TabIndex = 5
        '
        'txtMainContactPhone
        '
        Me.txtMainContactPhone.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactPhone.Enabled = False
        Me.txtMainContactPhone.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactPhone.Location = New System.Drawing.Point(6, 123)
        Me.txtMainContactPhone.Name = "txtMainContactPhone"
        Me.txtMainContactPhone.ReadOnly = True
        Me.txtMainContactPhone.Size = New System.Drawing.Size(100, 20)
        Me.txtMainContactPhone.TabIndex = 4
        '
        'txtMainContactEmail
        '
        Me.txtMainContactEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainContactEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactEmail.Enabled = False
        Me.txtMainContactEmail.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactEmail.Location = New System.Drawing.Point(6, 97)
        Me.txtMainContactEmail.Name = "txtMainContactEmail"
        Me.txtMainContactEmail.ReadOnly = True
        Me.txtMainContactEmail.Size = New System.Drawing.Size(206, 20)
        Me.txtMainContactEmail.TabIndex = 3
        '
        'txtMainContactCity
        '
        Me.txtMainContactCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainContactCity.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactCity.Enabled = False
        Me.txtMainContactCity.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactCity.Location = New System.Drawing.Point(6, 71)
        Me.txtMainContactCity.Name = "txtMainContactCity"
        Me.txtMainContactCity.ReadOnly = True
        Me.txtMainContactCity.Size = New System.Drawing.Size(206, 20)
        Me.txtMainContactCity.TabIndex = 2
        '
        'txtMainContactAddress
        '
        Me.txtMainContactAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainContactAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactAddress.Enabled = False
        Me.txtMainContactAddress.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactAddress.Location = New System.Drawing.Point(6, 45)
        Me.txtMainContactAddress.Name = "txtMainContactAddress"
        Me.txtMainContactAddress.ReadOnly = True
        Me.txtMainContactAddress.Size = New System.Drawing.Size(206, 20)
        Me.txtMainContactAddress.TabIndex = 1
        '
        'txtMainContactName
        '
        Me.txtMainContactName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainContactName.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainContactName.Enabled = False
        Me.txtMainContactName.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMainContactName.Location = New System.Drawing.Point(6, 19)
        Me.txtMainContactName.Name = "txtMainContactName"
        Me.txtMainContactName.ReadOnly = True
        Me.txtMainContactName.Size = New System.Drawing.Size(206, 20)
        Me.txtMainContactName.TabIndex = 0
        '
        'grpGroupDetails
        '
        Me.grpGroupDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGroupDetails.Controls.Add(Me.txtGroupSearch)
        Me.grpGroupDetails.Controls.Add(Me.lvwGroups)
        Me.grpGroupDetails.Controls.Add(Me.btnGroupEditClient)
        Me.grpGroupDetails.Controls.Add(Me.btnGroupManage)
        Me.grpGroupDetails.Location = New System.Drawing.Point(6, 3)
        Me.grpGroupDetails.Name = "grpGroupDetails"
        Me.grpGroupDetails.Size = New System.Drawing.Size(218, 272)
        Me.grpGroupDetails.TabIndex = 14
        Me.grpGroupDetails.TabStop = False
        '
        'txtGroupSearch
        '
        Me.txtGroupSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGroupSearch.Location = New System.Drawing.Point(6, 16)
        Me.txtGroupSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGroupSearch.Name = "txtGroupSearch"
        Me.txtGroupSearch.Size = New System.Drawing.Size(206, 20)
        Me.txtGroupSearch.TabIndex = 25
        '
        'lvwGroups
        '
        Me.lvwGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwGroups.FullRowSelect = True
        Me.lvwGroups.GridLines = True
        Me.lvwGroups.HideSelection = False
        Me.lvwGroups.Location = New System.Drawing.Point(6, 42)
        Me.lvwGroups.MultiSelect = False
        Me.lvwGroups.Name = "lvwGroups"
        Me.lvwGroups.Size = New System.Drawing.Size(206, 192)
        Me.lvwGroups.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwGroups.TabIndex = 24
        Me.lvwGroups.UseCompatibleStateImageBehavior = False
        Me.lvwGroups.View = System.Windows.Forms.View.Details
        '
        'btnGroupEditClient
        '
        Me.btnGroupEditClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGroupEditClient.Location = New System.Drawing.Point(112, 240)
        Me.btnGroupEditClient.Name = "btnGroupEditClient"
        Me.btnGroupEditClient.Size = New System.Drawing.Size(100, 23)
        Me.btnGroupEditClient.TabIndex = 2
        Me.btnGroupEditClient.Text = "Clients"
        Me.btnGroupEditClient.UseVisualStyleBackColor = True
        '
        'btnGroupManage
        '
        Me.btnGroupManage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGroupManage.Location = New System.Drawing.Point(6, 240)
        Me.btnGroupManage.Name = "btnGroupManage"
        Me.btnGroupManage.Size = New System.Drawing.Size(100, 23)
        Me.btnGroupManage.TabIndex = 1
        Me.btnGroupManage.Text = "Groups"
        Me.btnGroupManage.UseVisualStyleBackColor = True
        '
        'grpGroupMembers
        '
        Me.grpGroupMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGroupMembers.Controls.Add(Me.cbxCorrectLessonCount)
        Me.grpGroupMembers.Controls.Add(Me.btnCorrectLessonCount)
        Me.grpGroupMembers.Controls.Add(Me.grpGroupClientsView)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupLessonsTotal)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupLessonsBilled)
        Me.grpGroupMembers.Controls.Add(Me.txtGroupLessonsBilled)
        Me.grpGroupMembers.Controls.Add(Me.txtGroupLessonsTotal)
        Me.grpGroupMembers.Controls.Add(Me.vsbGroupClients)
        Me.grpGroupMembers.Controls.Add(Me.chkGroupHeader)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupClientLevel)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupExtraCount)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupLessonCount)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupLessonType)
        Me.grpGroupMembers.Controls.Add(Me.lblGroupsFullName)
        Me.grpGroupMembers.Location = New System.Drawing.Point(3, 3)
        Me.grpGroupMembers.Name = "grpGroupMembers"
        Me.grpGroupMembers.Size = New System.Drawing.Size(621, 564)
        Me.grpGroupMembers.TabIndex = 12
        Me.grpGroupMembers.TabStop = False
        Me.grpGroupMembers.Text = "Group Members"
        '
        'cbxCorrectLessonCount
        '
        Me.cbxCorrectLessonCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxCorrectLessonCount.FormattingEnabled = True
        Me.cbxCorrectLessonCount.Items.AddRange(New Object() {"All", "Group", "Client"})
        Me.cbxCorrectLessonCount.Location = New System.Drawing.Point(133, 534)
        Me.cbxCorrectLessonCount.Margin = New System.Windows.Forms.Padding(2)
        Me.cbxCorrectLessonCount.Name = "cbxCorrectLessonCount"
        Me.cbxCorrectLessonCount.Size = New System.Drawing.Size(56, 21)
        Me.cbxCorrectLessonCount.TabIndex = 18
        '
        'btnCorrectLessonCount
        '
        Me.btnCorrectLessonCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCorrectLessonCount.Enabled = False
        Me.btnCorrectLessonCount.Location = New System.Drawing.Point(9, 533)
        Me.btnCorrectLessonCount.Name = "btnCorrectLessonCount"
        Me.btnCorrectLessonCount.Size = New System.Drawing.Size(120, 23)
        Me.btnCorrectLessonCount.TabIndex = 13
        Me.btnCorrectLessonCount.Text = "Correct Lesson Count"
        Me.btnCorrectLessonCount.UseVisualStyleBackColor = True
        '
        'grpGroupClientsView
        '
        Me.grpGroupClientsView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGroupClientsView.Controls.Add(Me.pnlGroupsView)
        Me.grpGroupClientsView.Location = New System.Drawing.Point(0, 42)
        Me.grpGroupClientsView.Name = "grpGroupClientsView"
        Me.grpGroupClientsView.Size = New System.Drawing.Size(584, 487)
        Me.grpGroupClientsView.TabIndex = 17
        Me.grpGroupClientsView.TabStop = False
        '
        'pnlGroupsView
        '
        Me.pnlGroupsView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlGroupsView.Controls.Add(Me.grpGroupClients)
        Me.pnlGroupsView.Location = New System.Drawing.Point(0, 7)
        Me.pnlGroupsView.Name = "pnlGroupsView"
        Me.pnlGroupsView.Size = New System.Drawing.Size(584, 348)
        Me.pnlGroupsView.TabIndex = 18
        '
        'grpGroupClients
        '
        Me.grpGroupClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGroupClients.Location = New System.Drawing.Point(0, -7)
        Me.grpGroupClients.Name = "grpGroupClients"
        Me.grpGroupClients.Size = New System.Drawing.Size(584, 401)
        Me.grpGroupClients.TabIndex = 8
        Me.grpGroupClients.TabStop = False
        '
        'lblGroupLessonsTotal
        '
        Me.lblGroupLessonsTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGroupLessonsTotal.Location = New System.Drawing.Point(197, 538)
        Me.lblGroupLessonsTotal.Name = "lblGroupLessonsTotal"
        Me.lblGroupLessonsTotal.Size = New System.Drawing.Size(62, 13)
        Me.lblGroupLessonsTotal.TabIndex = 12
        Me.lblGroupLessonsTotal.Text = "Total Count"
        '
        'lblGroupLessonsBilled
        '
        Me.lblGroupLessonsBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGroupLessonsBilled.Location = New System.Drawing.Point(355, 538)
        Me.lblGroupLessonsBilled.Name = "lblGroupLessonsBilled"
        Me.lblGroupLessonsBilled.Size = New System.Drawing.Size(85, 13)
        Me.lblGroupLessonsBilled.TabIndex = 15
        Me.lblGroupLessonsBilled.Text = "Billed"
        '
        'txtGroupLessonsBilled
        '
        Me.txtGroupLessonsBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGroupLessonsBilled.Location = New System.Drawing.Point(446, 535)
        Me.txtGroupLessonsBilled.Name = "txtGroupLessonsBilled"
        Me.txtGroupLessonsBilled.ReadOnly = True
        Me.txtGroupLessonsBilled.Size = New System.Drawing.Size(69, 20)
        Me.txtGroupLessonsBilled.TabIndex = 14
        '
        'txtGroupLessonsTotal
        '
        Me.txtGroupLessonsTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGroupLessonsTotal.Location = New System.Drawing.Point(266, 535)
        Me.txtGroupLessonsTotal.Name = "txtGroupLessonsTotal"
        Me.txtGroupLessonsTotal.ReadOnly = True
        Me.txtGroupLessonsTotal.Size = New System.Drawing.Size(69, 20)
        Me.txtGroupLessonsTotal.TabIndex = 13
        '
        'vsbGroupClients
        '
        Me.vsbGroupClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsbGroupClients.LargeChange = 210
        Me.vsbGroupClients.Location = New System.Drawing.Point(598, 49)
        Me.vsbGroupClients.Maximum = 410
        Me.vsbGroupClients.Minimum = 1
        Me.vsbGroupClients.Name = "vsbGroupClients"
        Me.vsbGroupClients.Size = New System.Drawing.Size(17, 479)
        Me.vsbGroupClients.SmallChange = 21
        Me.vsbGroupClients.TabIndex = 6
        Me.vsbGroupClients.Value = 1
        '
        'chkGroupHeader
        '
        Me.chkGroupHeader.AutoSize = True
        Me.chkGroupHeader.Location = New System.Drawing.Point(10, 22)
        Me.chkGroupHeader.Name = "chkGroupHeader"
        Me.chkGroupHeader.Size = New System.Drawing.Size(15, 14)
        Me.chkGroupHeader.TabIndex = 5
        Me.chkGroupHeader.UseVisualStyleBackColor = True
        '
        'lblGroupClientLevel
        '
        Me.lblGroupClientLevel.AutoSize = True
        Me.lblGroupClientLevel.Location = New System.Drawing.Point(399, 23)
        Me.lblGroupClientLevel.Name = "lblGroupClientLevel"
        Me.lblGroupClientLevel.Size = New System.Drawing.Size(66, 13)
        Me.lblGroupClientLevel.TabIndex = 4
        Me.lblGroupClientLevel.Text = "Client Level*"
        '
        'lblGroupExtraCount
        '
        Me.lblGroupExtraCount.Location = New System.Drawing.Point(348, 10)
        Me.lblGroupExtraCount.Name = "lblGroupExtraCount"
        Me.lblGroupExtraCount.Size = New System.Drawing.Size(45, 31)
        Me.lblGroupExtraCount.TabIndex = 3
        Me.lblGroupExtraCount.Text = "Extra Count"
        Me.lblGroupExtraCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGroupLessonCount
        '
        Me.lblGroupLessonCount.Location = New System.Drawing.Point(297, 10)
        Me.lblGroupLessonCount.Name = "lblGroupLessonCount"
        Me.lblGroupLessonCount.Size = New System.Drawing.Size(45, 31)
        Me.lblGroupLessonCount.TabIndex = 2
        Me.lblGroupLessonCount.Text = "Lesson Count"
        Me.lblGroupLessonCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGroupLessonType
        '
        Me.lblGroupLessonType.AutoSize = True
        Me.lblGroupLessonType.Location = New System.Drawing.Point(181, 22)
        Me.lblGroupLessonType.Name = "lblGroupLessonType"
        Me.lblGroupLessonType.Size = New System.Drawing.Size(72, 13)
        Me.lblGroupLessonType.TabIndex = 1
        Me.lblGroupLessonType.Text = "Lesson Type*"
        '
        'lblGroupsFullName
        '
        Me.lblGroupsFullName.AutoSize = True
        Me.lblGroupsFullName.Location = New System.Drawing.Point(31, 23)
        Me.lblGroupsFullName.Name = "lblGroupsFullName"
        Me.lblGroupsFullName.Size = New System.Drawing.Size(64, 13)
        Me.lblGroupsFullName.TabIndex = 0
        Me.lblGroupsFullName.Text = "Client Name"
        '
        'tpgFinance
        '
        Me.tpgFinance.Controls.Add(Me.spcFinance)
        Me.tpgFinance.Location = New System.Drawing.Point(4, 22)
        Me.tpgFinance.Name = "tpgFinance"
        Me.tpgFinance.Size = New System.Drawing.Size(864, 573)
        Me.tpgFinance.TabIndex = 2
        Me.tpgFinance.Text = "Finance"
        Me.tpgFinance.UseVisualStyleBackColor = True
        '
        'spcFinance
        '
        Me.spcFinance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spcFinance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spcFinance.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.spcFinance.Location = New System.Drawing.Point(3, 9)
        Me.spcFinance.Name = "spcFinance"
        '
        'spcFinance.Panel1
        '
        Me.spcFinance.Panel1.Controls.Add(Me.txtFinanceGroupSearch)
        Me.spcFinance.Panel1.Controls.Add(Me.btnFinancePay)
        Me.spcFinance.Panel1.Controls.Add(Me.btnFinanceDelete)
        Me.spcFinance.Panel1.Controls.Add(Me.lvwProduct)
        Me.spcFinance.Panel1.Controls.Add(Me.lblFinanceProduct)
        Me.spcFinance.Panel1.Controls.Add(Me.lblClientName)
        Me.spcFinance.Panel1.Controls.Add(Me.lblGroupName)
        Me.spcFinance.Panel1.Controls.Add(Me.lvwFinanceClients)
        Me.spcFinance.Panel1.Controls.Add(Me.lvwFinanceGroups)
        Me.spcFinance.Panel1.Controls.Add(Me.btnFinanceAdd)
        Me.spcFinance.Panel1.Controls.Add(Me.btnFinanceEdit)
        '
        'spcFinance.Panel2
        '
        Me.spcFinance.Panel2.Controls.Add(Me.grpFinanceGroupPayments)
        Me.spcFinance.Size = New System.Drawing.Size(861, 561)
        Me.spcFinance.SplitterDistance = 246
        Me.spcFinance.TabIndex = 97
        '
        'txtFinanceGroupSearch
        '
        Me.txtFinanceGroupSearch.Location = New System.Drawing.Point(5, 23)
        Me.txtFinanceGroupSearch.Name = "txtFinanceGroupSearch"
        Me.txtFinanceGroupSearch.Size = New System.Drawing.Size(236, 20)
        Me.txtFinanceGroupSearch.TabIndex = 107
        '
        'btnFinancePay
        '
        Me.btnFinancePay.Enabled = False
        Me.btnFinancePay.Location = New System.Drawing.Point(5, 458)
        Me.btnFinancePay.Name = "btnFinancePay"
        Me.btnFinancePay.Size = New System.Drawing.Size(100, 23)
        Me.btnFinancePay.TabIndex = 98
        Me.btnFinancePay.Text = "Pay Invoice"
        Me.btnFinancePay.UseVisualStyleBackColor = True
        '
        'btnFinanceDelete
        '
        Me.btnFinanceDelete.Enabled = False
        Me.btnFinanceDelete.Location = New System.Drawing.Point(127, 458)
        Me.btnFinanceDelete.Name = "btnFinanceDelete"
        Me.btnFinanceDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnFinanceDelete.TabIndex = 100
        Me.btnFinanceDelete.Text = "Delete Invoice"
        Me.btnFinanceDelete.UseVisualStyleBackColor = True
        '
        'lvwProduct
        '
        Me.lvwProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwProduct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProducts, Me.colProductCounts, Me.colProductAmounts, Me.colProductTax})
        Me.lvwProduct.FullRowSelect = True
        Me.lvwProduct.GridLines = True
        Me.lvwProduct.Location = New System.Drawing.Point(5, 306)
        Me.lvwProduct.MultiSelect = False
        Me.lvwProduct.Name = "lvwProduct"
        Me.lvwProduct.Size = New System.Drawing.Size(236, 121)
        Me.lvwProduct.TabIndex = 106
        Me.lvwProduct.UseCompatibleStateImageBehavior = False
        Me.lvwProduct.View = System.Windows.Forms.View.Details
        '
        'colProducts
        '
        Me.colProducts.Tag = "colProducts"
        Me.colProducts.Text = "Product"
        Me.colProducts.Width = 76
        '
        'colProductCounts
        '
        Me.colProductCounts.Tag = "colProductCounts"
        Me.colProductCounts.Text = "Count"
        Me.colProductCounts.Width = 40
        '
        'colProductAmounts
        '
        Me.colProductAmounts.Tag = "colProductAmounts"
        Me.colProductAmounts.Text = "Amount"
        Me.colProductAmounts.Width = 48
        '
        'colProductTax
        '
        Me.colProductTax.Tag = "colProductTax"
        Me.colProductTax.Text = "Tax"
        Me.colProductTax.Width = 30
        '
        'lblFinanceProduct
        '
        Me.lblFinanceProduct.AutoSize = True
        Me.lblFinanceProduct.Location = New System.Drawing.Point(5, 290)
        Me.lblFinanceProduct.Name = "lblFinanceProduct"
        Me.lblFinanceProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblFinanceProduct.TabIndex = 105
        Me.lblFinanceProduct.Text = "Product"
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Location = New System.Drawing.Point(5, 166)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(64, 13)
        Me.lblClientName.TabIndex = 104
        Me.lblClientName.Text = "Client Name"
        '
        'lblGroupName
        '
        Me.lblGroupName.AutoSize = True
        Me.lblGroupName.Location = New System.Drawing.Point(5, 2)
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.Size = New System.Drawing.Size(67, 13)
        Me.lblGroupName.TabIndex = 103
        Me.lblGroupName.Text = "Group Name"
        '
        'lvwFinanceClients
        '
        Me.lvwFinanceClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFinanceClients.FullRowSelect = True
        Me.lvwFinanceClients.GridLines = True
        Me.lvwFinanceClients.Location = New System.Drawing.Point(5, 183)
        Me.lvwFinanceClients.MultiSelect = False
        Me.lvwFinanceClients.Name = "lvwFinanceClients"
        Me.lvwFinanceClients.Size = New System.Drawing.Size(236, 100)
        Me.lvwFinanceClients.TabIndex = 102
        Me.lvwFinanceClients.UseCompatibleStateImageBehavior = False
        Me.lvwFinanceClients.View = System.Windows.Forms.View.Details
        '
        'lvwFinanceGroups
        '
        Me.lvwFinanceGroups.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFinanceGroups.FullRowSelect = True
        Me.lvwFinanceGroups.GridLines = True
        Me.lvwFinanceGroups.Location = New System.Drawing.Point(5, 49)
        Me.lvwFinanceGroups.MultiSelect = False
        Me.lvwFinanceGroups.Name = "lvwFinanceGroups"
        Me.lvwFinanceGroups.Size = New System.Drawing.Size(236, 109)
        Me.lvwFinanceGroups.TabIndex = 101
        Me.lvwFinanceGroups.UseCompatibleStateImageBehavior = False
        Me.lvwFinanceGroups.View = System.Windows.Forms.View.Details
        '
        'btnFinanceAdd
        '
        Me.btnFinanceAdd.Enabled = False
        Me.btnFinanceAdd.Location = New System.Drawing.Point(5, 432)
        Me.btnFinanceAdd.Name = "btnFinanceAdd"
        Me.btnFinanceAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnFinanceAdd.TabIndex = 97
        Me.btnFinanceAdd.Text = "Add Invoice"
        Me.btnFinanceAdd.UseVisualStyleBackColor = True
        '
        'btnFinanceEdit
        '
        Me.btnFinanceEdit.Enabled = False
        Me.btnFinanceEdit.Location = New System.Drawing.Point(127, 432)
        Me.btnFinanceEdit.Name = "btnFinanceEdit"
        Me.btnFinanceEdit.Size = New System.Drawing.Size(100, 23)
        Me.btnFinanceEdit.TabIndex = 99
        Me.btnFinanceEdit.Text = "Manage Invoices"
        Me.btnFinanceEdit.UseVisualStyleBackColor = True
        '
        'grpFinanceGroupPayments
        '
        Me.grpFinanceGroupPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFinanceGroupPayments.Controls.Add(Me.lvwFinance)
        Me.grpFinanceGroupPayments.Controls.Add(Me.txtFinancePayDue)
        Me.grpFinanceGroupPayments.Controls.Add(Me.lblFinancePayDue)
        Me.grpFinanceGroupPayments.Controls.Add(Me.txtFinancePayCount)
        Me.grpFinanceGroupPayments.Controls.Add(Me.txtFinancePayPayed)
        Me.grpFinanceGroupPayments.Controls.Add(Me.txtFinancePayBilled)
        Me.grpFinanceGroupPayments.Controls.Add(Me.lblFinancePayTotal)
        Me.grpFinanceGroupPayments.Location = New System.Drawing.Point(3, 0)
        Me.grpFinanceGroupPayments.Name = "grpFinanceGroupPayments"
        Me.grpFinanceGroupPayments.Size = New System.Drawing.Size(603, 559)
        Me.grpFinanceGroupPayments.TabIndex = 12
        Me.grpFinanceGroupPayments.TabStop = False
        Me.grpFinanceGroupPayments.Text = "Invoices"
        '
        'lvwFinance
        '
        Me.lvwFinance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFinance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDate, Me.colClient, Me.colLogin, Me.colProduct, Me.colCount, Me.colBilledAmount, Me.colPayedAmount, Me.colOpenAmount, Me.colPayDate, Me.colPayed})
        Me.lvwFinance.FullRowSelect = True
        Me.lvwFinance.GridLines = True
        Me.lvwFinance.HideSelection = False
        Me.lvwFinance.Location = New System.Drawing.Point(8, 19)
        Me.lvwFinance.MultiSelect = False
        Me.lvwFinance.Name = "lvwFinance"
        Me.lvwFinance.Size = New System.Drawing.Size(589, 468)
        Me.lvwFinance.TabIndex = 24
        Me.lvwFinance.UseCompatibleStateImageBehavior = False
        Me.lvwFinance.View = System.Windows.Forms.View.Details
        '
        'colDate
        '
        Me.colDate.Tag = "colDate"
        Me.colDate.Text = "Date"
        Me.colDate.Width = 70
        '
        'colClient
        '
        Me.colClient.Tag = "colClient"
        Me.colClient.Text = "Client"
        Me.colClient.Width = 80
        '
        'colLogin
        '
        Me.colLogin.Tag = "colLogin"
        Me.colLogin.Text = "BookedBy"
        Me.colLogin.Width = 70
        '
        'colProduct
        '
        Me.colProduct.Tag = "colProduct"
        Me.colProduct.Text = "Product"
        Me.colProduct.Width = 95
        '
        'colCount
        '
        Me.colCount.Tag = "colCount"
        Me.colCount.Text = "Count"
        Me.colCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colBilledAmount
        '
        Me.colBilledAmount.Tag = "colBilledAmount"
        Me.colBilledAmount.Text = "Billed"
        Me.colBilledAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colPayedAmount
        '
        Me.colPayedAmount.Tag = "colPayedAmount"
        Me.colPayedAmount.Text = "Paid"
        Me.colPayedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colOpenAmount
        '
        Me.colOpenAmount.Tag = "colOpenAmount"
        Me.colOpenAmount.Text = "Open"
        Me.colOpenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colPayDate
        '
        Me.colPayDate.Tag = "colPayDate"
        Me.colPayDate.Text = "Last Pay Date"
        Me.colPayDate.Width = 77
        '
        'colPayed
        '
        Me.colPayed.Tag = "colPayed"
        Me.colPayed.Text = "Paid y/n"
        Me.colPayed.Width = 77
        '
        'txtFinancePayDue
        '
        Me.txtFinancePayDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFinancePayDue.Location = New System.Drawing.Point(159, 533)
        Me.txtFinancePayDue.Name = "txtFinancePayDue"
        Me.txtFinancePayDue.Size = New System.Drawing.Size(55, 20)
        Me.txtFinancePayDue.TabIndex = 21
        Me.txtFinancePayDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFinancePayDue
        '
        Me.lblFinancePayDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFinancePayDue.Location = New System.Drawing.Point(75, 537)
        Me.lblFinancePayDue.Name = "lblFinancePayDue"
        Me.lblFinancePayDue.Size = New System.Drawing.Size(66, 13)
        Me.lblFinancePayDue.TabIndex = 20
        Me.lblFinancePayDue.Text = "Amount Due"
        Me.lblFinancePayDue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtFinancePayCount
        '
        Me.txtFinancePayCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFinancePayCount.Enabled = False
        Me.txtFinancePayCount.Location = New System.Drawing.Point(356, 533)
        Me.txtFinancePayCount.Name = "txtFinancePayCount"
        Me.txtFinancePayCount.Size = New System.Drawing.Size(55, 20)
        Me.txtFinancePayCount.TabIndex = 19
        Me.txtFinancePayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinancePayPayed
        '
        Me.txtFinancePayPayed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFinancePayPayed.Enabled = False
        Me.txtFinancePayPayed.Location = New System.Drawing.Point(478, 533)
        Me.txtFinancePayPayed.Name = "txtFinancePayPayed"
        Me.txtFinancePayPayed.Size = New System.Drawing.Size(55, 20)
        Me.txtFinancePayPayed.TabIndex = 18
        Me.txtFinancePayPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinancePayBilled
        '
        Me.txtFinancePayBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFinancePayBilled.Enabled = False
        Me.txtFinancePayBilled.Location = New System.Drawing.Point(417, 533)
        Me.txtFinancePayBilled.Name = "txtFinancePayBilled"
        Me.txtFinancePayBilled.Size = New System.Drawing.Size(55, 20)
        Me.txtFinancePayBilled.TabIndex = 17
        Me.txtFinancePayBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFinancePayTotal
        '
        Me.lblFinancePayTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFinancePayTotal.Location = New System.Drawing.Point(220, 536)
        Me.lblFinancePayTotal.Name = "lblFinancePayTotal"
        Me.lblFinancePayTotal.Size = New System.Drawing.Size(130, 13)
        Me.lblFinancePayTotal.TabIndex = 16
        Me.lblFinancePayTotal.Text = "Total"
        Me.lblFinancePayTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tpgReports
        '
        Me.tpgReports.Controls.Add(Me.cbxRepGroup)
        Me.tpgReports.Controls.Add(Me.cbxRepClient)
        Me.tpgReports.Controls.Add(Me.cbxRepLessonType)
        Me.tpgReports.Controls.Add(Me.chkRepLimitLessonType)
        Me.tpgReports.Controls.Add(Me.cbxRepTrack)
        Me.tpgReports.Controls.Add(Me.btnFav5)
        Me.tpgReports.Controls.Add(Me.btnFav4)
        Me.tpgReports.Controls.Add(Me.btnFav3)
        Me.tpgReports.Controls.Add(Me.btnFav2)
        Me.tpgReports.Controls.Add(Me.btnFav1)
        Me.tpgReports.Controls.Add(Me.cbxRepOther)
        Me.tpgReports.Controls.Add(Me.lblRepOther)
        Me.tpgReports.Controls.Add(Me.btnRepReportCreate)
        Me.tpgReports.Controls.Add(Me.cbxRepClients)
        Me.tpgReports.Controls.Add(Me.cbxRepFinance)
        Me.tpgReports.Controls.Add(Me.cbxRepLessons)
        Me.tpgReports.Controls.Add(Me.lblRepClients)
        Me.tpgReports.Controls.Add(Me.lblRepFinance)
        Me.tpgReports.Controls.Add(Me.lblRepLessons)
        Me.tpgReports.Controls.Add(Me.btnRep2)
        Me.tpgReports.Controls.Add(Me.rtbRepReportFooter)
        Me.tpgReports.Controls.Add(Me.rtbRepReportHeader)
        Me.tpgReports.Controls.Add(Me.grpRepReportWidth)
        Me.tpgReports.Controls.Add(Me.dgvRepReport)
        Me.tpgReports.Controls.Add(Me.btnRepEmail)
        Me.tpgReports.Controls.Add(Me.grpRepLimitType)
        Me.tpgReports.Controls.Add(Me.rbnRepLimitMonth)
        Me.tpgReports.Controls.Add(Me.rbnRepLimitWeek)
        Me.tpgReports.Controls.Add(Me.rbnRepLimitDay)
        Me.tpgReports.Controls.Add(Me.rbnRepLimitSeason)
        Me.tpgReports.Controls.Add(Me.btnRep4)
        Me.tpgReports.Controls.Add(Me.btnRep5)
        Me.tpgReports.Controls.Add(Me.btnRep3)
        Me.tpgReports.Controls.Add(Me.btnRep1)
        Me.tpgReports.Controls.Add(Me.tstReports)
        Me.tpgReports.Controls.Add(Me.chkRepLimitInvoice)
        Me.tpgReports.Controls.Add(Me.lblRepLimitSelection)
        Me.tpgReports.Controls.Add(Me.chkRepLimitClient)
        Me.tpgReports.Controls.Add(Me.chkRepLimitGroup)
        Me.tpgReports.Controls.Add(Me.chkRepLimitTrack)
        Me.tpgReports.Controls.Add(Me.mnuReports)
        Me.tpgReports.Location = New System.Drawing.Point(4, 22)
        Me.tpgReports.Name = "tpgReports"
        Me.tpgReports.Size = New System.Drawing.Size(864, 573)
        Me.tpgReports.TabIndex = 4
        Me.tpgReports.Text = " Reports"
        Me.tpgReports.UseVisualStyleBackColor = True
        '
        'cbxRepGroup
        '
        Me.cbxRepGroup.FormattingEnabled = True
        Me.cbxRepGroup.Items.AddRange(New Object() {"Group", "All"})
        Me.cbxRepGroup.Location = New System.Drawing.Point(26, 163)
        Me.cbxRepGroup.Name = "cbxRepGroup"
        Me.cbxRepGroup.Size = New System.Drawing.Size(97, 21)
        Me.cbxRepGroup.TabIndex = 76
        Me.cbxRepGroup.Text = "Group"
        '
        'cbxRepClient
        '
        Me.cbxRepClient.FormattingEnabled = True
        Me.cbxRepClient.Items.AddRange(New Object() {"Client", "All"})
        Me.cbxRepClient.Location = New System.Drawing.Point(26, 187)
        Me.cbxRepClient.Name = "cbxRepClient"
        Me.cbxRepClient.Size = New System.Drawing.Size(97, 21)
        Me.cbxRepClient.TabIndex = 75
        Me.cbxRepClient.Text = "Client"
        '
        'cbxRepLessonType
        '
        Me.cbxRepLessonType.FormattingEnabled = True
        Me.cbxRepLessonType.Location = New System.Drawing.Point(26, 232)
        Me.cbxRepLessonType.Name = "cbxRepLessonType"
        Me.cbxRepLessonType.Size = New System.Drawing.Size(97, 21)
        Me.cbxRepLessonType.TabIndex = 74
        Me.cbxRepLessonType.Text = "LessonType"
        '
        'chkRepLimitLessonType
        '
        Me.chkRepLimitLessonType.AutoSize = True
        Me.chkRepLimitLessonType.Location = New System.Drawing.Point(7, 234)
        Me.chkRepLimitLessonType.Name = "chkRepLimitLessonType"
        Me.chkRepLimitLessonType.Size = New System.Drawing.Size(84, 17)
        Me.chkRepLimitLessonType.TabIndex = 73
        Me.chkRepLimitLessonType.Text = "LessonType"
        Me.chkRepLimitLessonType.UseVisualStyleBackColor = True
        '
        'cbxRepTrack
        '
        Me.cbxRepTrack.FormattingEnabled = True
        Me.cbxRepTrack.Items.AddRange(New Object() {"Baan Dag", "Baan Avond"})
        Me.cbxRepTrack.Location = New System.Drawing.Point(26, 140)
        Me.cbxRepTrack.Name = "cbxRepTrack"
        Me.cbxRepTrack.Size = New System.Drawing.Size(97, 21)
        Me.cbxRepTrack.TabIndex = 72
        Me.cbxRepTrack.Text = "Track"
        '
        'btnFav5
        '
        Me.btnFav5.Image = Global.TrackManager.My.Resources.Resources.Star
        Me.btnFav5.Location = New System.Drawing.Point(104, 474)
        Me.btnFav5.Name = "btnFav5"
        Me.btnFav5.Size = New System.Drawing.Size(18, 23)
        Me.btnFav5.TabIndex = 71
        Me.btnFav5.Tag = "btnFav5"
        Me.btnFav5.UseVisualStyleBackColor = True
        '
        'btnFav4
        '
        Me.btnFav4.Image = Global.TrackManager.My.Resources.Resources.Star
        Me.btnFav4.Location = New System.Drawing.Point(104, 447)
        Me.btnFav4.Name = "btnFav4"
        Me.btnFav4.Size = New System.Drawing.Size(18, 23)
        Me.btnFav4.TabIndex = 70
        Me.btnFav4.Tag = "btnFav4"
        Me.btnFav4.UseVisualStyleBackColor = True
        '
        'btnFav3
        '
        Me.btnFav3.Image = Global.TrackManager.My.Resources.Resources.Star
        Me.btnFav3.Location = New System.Drawing.Point(104, 421)
        Me.btnFav3.Name = "btnFav3"
        Me.btnFav3.Size = New System.Drawing.Size(18, 23)
        Me.btnFav3.TabIndex = 69
        Me.btnFav3.Tag = "btnFav3"
        Me.btnFav3.UseVisualStyleBackColor = True
        '
        'btnFav2
        '
        Me.btnFav2.Image = Global.TrackManager.My.Resources.Resources.Star
        Me.btnFav2.Location = New System.Drawing.Point(104, 395)
        Me.btnFav2.Name = "btnFav2"
        Me.btnFav2.Size = New System.Drawing.Size(18, 23)
        Me.btnFav2.TabIndex = 68
        Me.btnFav2.Tag = "btnFav2"
        Me.btnFav2.UseVisualStyleBackColor = True
        '
        'btnFav1
        '
        Me.btnFav1.Image = Global.TrackManager.My.Resources.Resources.Star
        Me.btnFav1.Location = New System.Drawing.Point(104, 369)
        Me.btnFav1.Name = "btnFav1"
        Me.btnFav1.Size = New System.Drawing.Size(18, 23)
        Me.btnFav1.TabIndex = 67
        Me.btnFav1.Tag = "btnFav1"
        Me.btnFav1.UseVisualStyleBackColor = True
        '
        'cbxRepOther
        '
        Me.cbxRepOther.FormattingEnabled = True
        Me.cbxRepOther.Location = New System.Drawing.Point(508, 51)
        Me.cbxRepOther.Name = "cbxRepOther"
        Me.cbxRepOther.Size = New System.Drawing.Size(121, 21)
        Me.cbxRepOther.TabIndex = 65
        '
        'lblRepOther
        '
        Me.lblRepOther.AutoSize = True
        Me.lblRepOther.Location = New System.Drawing.Point(505, 33)
        Me.lblRepOther.Name = "lblRepOther"
        Me.lblRepOther.Size = New System.Drawing.Size(33, 13)
        Me.lblRepOther.TabIndex = 66
        Me.lblRepOther.Text = "Other"
        '
        'btnRepReportCreate
        '
        Me.btnRepReportCreate.Location = New System.Drawing.Point(635, 49)
        Me.btnRepReportCreate.Name = "btnRepReportCreate"
        Me.btnRepReportCreate.Size = New System.Drawing.Size(101, 23)
        Me.btnRepReportCreate.TabIndex = 62
        Me.btnRepReportCreate.Text = "Create Report"
        Me.btnRepReportCreate.UseVisualStyleBackColor = True
        '
        'cbxRepClients
        '
        Me.cbxRepClients.FormattingEnabled = True
        Me.cbxRepClients.Location = New System.Drawing.Point(381, 51)
        Me.cbxRepClients.Name = "cbxRepClients"
        Me.cbxRepClients.Size = New System.Drawing.Size(121, 21)
        Me.cbxRepClients.TabIndex = 60
        '
        'cbxRepFinance
        '
        Me.cbxRepFinance.FormattingEnabled = True
        Me.cbxRepFinance.Location = New System.Drawing.Point(254, 51)
        Me.cbxRepFinance.Name = "cbxRepFinance"
        Me.cbxRepFinance.Size = New System.Drawing.Size(121, 21)
        Me.cbxRepFinance.TabIndex = 59
        '
        'cbxRepLessons
        '
        Me.cbxRepLessons.FormattingEnabled = True
        Me.cbxRepLessons.Location = New System.Drawing.Point(127, 51)
        Me.cbxRepLessons.Name = "cbxRepLessons"
        Me.cbxRepLessons.Size = New System.Drawing.Size(121, 21)
        Me.cbxRepLessons.TabIndex = 58
        '
        'lblRepClients
        '
        Me.lblRepClients.AutoSize = True
        Me.lblRepClients.Location = New System.Drawing.Point(378, 33)
        Me.lblRepClients.Name = "lblRepClients"
        Me.lblRepClients.Size = New System.Drawing.Size(38, 13)
        Me.lblRepClients.TabIndex = 64
        Me.lblRepClients.Text = "Clients"
        '
        'lblRepFinance
        '
        Me.lblRepFinance.AutoSize = True
        Me.lblRepFinance.Location = New System.Drawing.Point(251, 33)
        Me.lblRepFinance.Name = "lblRepFinance"
        Me.lblRepFinance.Size = New System.Drawing.Size(45, 13)
        Me.lblRepFinance.TabIndex = 63
        Me.lblRepFinance.Text = "Finance"
        '
        'lblRepLessons
        '
        Me.lblRepLessons.AutoSize = True
        Me.lblRepLessons.Location = New System.Drawing.Point(124, 33)
        Me.lblRepLessons.Name = "lblRepLessons"
        Me.lblRepLessons.Size = New System.Drawing.Size(46, 13)
        Me.lblRepLessons.TabIndex = 61
        Me.lblRepLessons.Text = "Lessons"
        '
        'btnRep2
        '
        Me.btnRep2.Location = New System.Drawing.Point(7, 395)
        Me.btnRep2.Name = "btnRep2"
        Me.btnRep2.Size = New System.Drawing.Size(99, 23)
        Me.btnRep2.TabIndex = 57
        Me.btnRep2.Text = "Report2"
        Me.btnRep2.UseVisualStyleBackColor = True
        '
        'rtbRepReportFooter
        '
        Me.rtbRepReportFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbRepReportFooter.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rtbRepReportFooter.Location = New System.Drawing.Point(127, 515)
        Me.rtbRepReportFooter.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbRepReportFooter.Name = "rtbRepReportFooter"
        Me.rtbRepReportFooter.Size = New System.Drawing.Size(731, 57)
        Me.rtbRepReportFooter.TabIndex = 56
        Me.rtbRepReportFooter.Text = ""
        '
        'rtbRepReportHeader
        '
        Me.rtbRepReportHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbRepReportHeader.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbRepReportHeader.Location = New System.Drawing.Point(127, 82)
        Me.rtbRepReportHeader.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbRepReportHeader.Name = "rtbRepReportHeader"
        Me.rtbRepReportHeader.Size = New System.Drawing.Size(731, 28)
        Me.rtbRepReportHeader.TabIndex = 55
        Me.rtbRepReportHeader.Text = ""
        '
        'grpRepReportWidth
        '
        Me.grpRepReportWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpRepReportWidth.Controls.Add(Me.txtRepReportWidth)
        Me.grpRepReportWidth.Controls.Add(Me.trbRepReportWidth)
        Me.grpRepReportWidth.Controls.Add(Me.chkRepReportWidth)
        Me.grpRepReportWidth.Location = New System.Drawing.Point(8, 509)
        Me.grpRepReportWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.grpRepReportWidth.Name = "grpRepReportWidth"
        Me.grpRepReportWidth.Padding = New System.Windows.Forms.Padding(2)
        Me.grpRepReportWidth.Size = New System.Drawing.Size(115, 67)
        Me.grpRepReportWidth.TabIndex = 54
        Me.grpRepReportWidth.TabStop = False
        Me.grpRepReportWidth.Text = "Report Print Width"
        '
        'txtRepReportWidth
        '
        Me.txtRepReportWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRepReportWidth.Location = New System.Drawing.Point(10, 44)
        Me.txtRepReportWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRepReportWidth.Name = "txtRepReportWidth"
        Me.txtRepReportWidth.ReadOnly = True
        Me.txtRepReportWidth.Size = New System.Drawing.Size(23, 20)
        Me.txtRepReportWidth.TabIndex = 54
        Me.txtRepReportWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'trbRepReportWidth
        '
        Me.trbRepReportWidth.AutoSize = False
        Me.trbRepReportWidth.Enabled = False
        Me.trbRepReportWidth.LargeChange = 3
        Me.trbRepReportWidth.Location = New System.Drawing.Point(4, 17)
        Me.trbRepReportWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.trbRepReportWidth.Maximum = 11
        Me.trbRepReportWidth.Minimum = 1
        Me.trbRepReportWidth.Name = "trbRepReportWidth"
        Me.trbRepReportWidth.Size = New System.Drawing.Size(106, 28)
        Me.trbRepReportWidth.TabIndex = 51
        Me.trbRepReportWidth.Value = 6
        '
        'chkRepReportWidth
        '
        Me.chkRepReportWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRepReportWidth.AutoSize = True
        Me.chkRepReportWidth.Checked = True
        Me.chkRepReportWidth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRepReportWidth.Location = New System.Drawing.Point(35, 46)
        Me.chkRepReportWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.chkRepReportWidth.Name = "chkRepReportWidth"
        Me.chkRepReportWidth.Size = New System.Drawing.Size(73, 17)
        Me.chkRepReportWidth.TabIndex = 53
        Me.chkRepReportWidth.Text = "Automatic"
        Me.chkRepReportWidth.UseVisualStyleBackColor = True
        '
        'dgvRepReport
        '
        Me.dgvRepReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRepReport.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRepReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRepReport.Location = New System.Drawing.Point(127, 115)
        Me.dgvRepReport.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvRepReport.Name = "dgvRepReport"
        Me.dgvRepReport.RowTemplate.Height = 24
        Me.dgvRepReport.Size = New System.Drawing.Size(730, 395)
        Me.dgvRepReport.TabIndex = 50
        '
        'btnRepEmail
        '
        Me.btnRepEmail.Location = New System.Drawing.Point(742, 49)
        Me.btnRepEmail.Name = "btnRepEmail"
        Me.btnRepEmail.Size = New System.Drawing.Size(115, 23)
        Me.btnRepEmail.TabIndex = 49
        Me.btnRepEmail.Text = "Email Report"
        Me.btnRepEmail.UseVisualStyleBackColor = True
        '
        'grpRepLimitType
        '
        Me.grpRepLimitType.Controls.Add(Me.rbnRepLimitTypeBar)
        Me.grpRepLimitType.Controls.Add(Me.rbnRepLimitTypeTeacher)
        Me.grpRepLimitType.Controls.Add(Me.rbnRepLimitTypeClient)
        Me.grpRepLimitType.Controls.Add(Me.rbnRepLimitTypeAll)
        Me.grpRepLimitType.Location = New System.Drawing.Point(7, 254)
        Me.grpRepLimitType.Name = "grpRepLimitType"
        Me.grpRepLimitType.Size = New System.Drawing.Size(112, 110)
        Me.grpRepLimitType.TabIndex = 48
        Me.grpRepLimitType.TabStop = False
        Me.grpRepLimitType.Text = "Limit to Type"
        '
        'rbnRepLimitTypeBar
        '
        Me.rbnRepLimitTypeBar.AutoSize = True
        Me.rbnRepLimitTypeBar.Location = New System.Drawing.Point(6, 88)
        Me.rbnRepLimitTypeBar.Name = "rbnRepLimitTypeBar"
        Me.rbnRepLimitTypeBar.Size = New System.Drawing.Size(41, 17)
        Me.rbnRepLimitTypeBar.TabIndex = 38
        Me.rbnRepLimitTypeBar.Text = "Bar"
        Me.rbnRepLimitTypeBar.UseVisualStyleBackColor = True
        '
        'rbnRepLimitTypeTeacher
        '
        Me.rbnRepLimitTypeTeacher.AutoSize = True
        Me.rbnRepLimitTypeTeacher.Location = New System.Drawing.Point(6, 65)
        Me.rbnRepLimitTypeTeacher.Name = "rbnRepLimitTypeTeacher"
        Me.rbnRepLimitTypeTeacher.Size = New System.Drawing.Size(65, 17)
        Me.rbnRepLimitTypeTeacher.TabIndex = 37
        Me.rbnRepLimitTypeTeacher.Text = "Teacher"
        Me.rbnRepLimitTypeTeacher.UseVisualStyleBackColor = True
        '
        'rbnRepLimitTypeClient
        '
        Me.rbnRepLimitTypeClient.AutoSize = True
        Me.rbnRepLimitTypeClient.Location = New System.Drawing.Point(6, 42)
        Me.rbnRepLimitTypeClient.Name = "rbnRepLimitTypeClient"
        Me.rbnRepLimitTypeClient.Size = New System.Drawing.Size(51, 17)
        Me.rbnRepLimitTypeClient.TabIndex = 36
        Me.rbnRepLimitTypeClient.Text = "Client"
        Me.rbnRepLimitTypeClient.UseVisualStyleBackColor = True
        '
        'rbnRepLimitTypeAll
        '
        Me.rbnRepLimitTypeAll.AutoSize = True
        Me.rbnRepLimitTypeAll.Checked = True
        Me.rbnRepLimitTypeAll.Location = New System.Drawing.Point(6, 19)
        Me.rbnRepLimitTypeAll.Name = "rbnRepLimitTypeAll"
        Me.rbnRepLimitTypeAll.Size = New System.Drawing.Size(36, 17)
        Me.rbnRepLimitTypeAll.TabIndex = 35
        Me.rbnRepLimitTypeAll.TabStop = True
        Me.rbnRepLimitTypeAll.Text = "All"
        Me.rbnRepLimitTypeAll.UseVisualStyleBackColor = True
        '
        'rbnRepLimitMonth
        '
        Me.rbnRepLimitMonth.AutoSize = True
        Me.rbnRepLimitMonth.Location = New System.Drawing.Point(7, 117)
        Me.rbnRepLimitMonth.Name = "rbnRepLimitMonth"
        Me.rbnRepLimitMonth.Size = New System.Drawing.Size(116, 17)
        Me.rbnRepLimitMonth.TabIndex = 47
        Me.rbnRepLimitMonth.Text = "Month ( from today)"
        Me.rbnRepLimitMonth.UseVisualStyleBackColor = True
        '
        'rbnRepLimitWeek
        '
        Me.rbnRepLimitWeek.AutoSize = True
        Me.rbnRepLimitWeek.Location = New System.Drawing.Point(7, 94)
        Me.rbnRepLimitWeek.Name = "rbnRepLimitWeek"
        Me.rbnRepLimitWeek.Size = New System.Drawing.Size(115, 17)
        Me.rbnRepLimitWeek.TabIndex = 46
        Me.rbnRepLimitWeek.Text = "Week ( from today)"
        Me.rbnRepLimitWeek.UseVisualStyleBackColor = True
        '
        'rbnRepLimitDay
        '
        Me.rbnRepLimitDay.AutoSize = True
        Me.rbnRepLimitDay.Checked = True
        Me.rbnRepLimitDay.Location = New System.Drawing.Point(7, 72)
        Me.rbnRepLimitDay.Name = "rbnRepLimitDay"
        Me.rbnRepLimitDay.Size = New System.Drawing.Size(44, 17)
        Me.rbnRepLimitDay.TabIndex = 45
        Me.rbnRepLimitDay.TabStop = True
        Me.rbnRepLimitDay.Text = "Day"
        Me.rbnRepLimitDay.UseVisualStyleBackColor = True
        '
        'rbnRepLimitSeason
        '
        Me.rbnRepLimitSeason.AutoSize = True
        Me.rbnRepLimitSeason.Location = New System.Drawing.Point(7, 49)
        Me.rbnRepLimitSeason.Name = "rbnRepLimitSeason"
        Me.rbnRepLimitSeason.Size = New System.Drawing.Size(61, 17)
        Me.rbnRepLimitSeason.TabIndex = 44
        Me.rbnRepLimitSeason.Text = "Season"
        Me.rbnRepLimitSeason.UseVisualStyleBackColor = True
        '
        'btnRep4
        '
        Me.btnRep4.Location = New System.Drawing.Point(7, 447)
        Me.btnRep4.Name = "btnRep4"
        Me.btnRep4.Size = New System.Drawing.Size(99, 23)
        Me.btnRep4.TabIndex = 43
        Me.btnRep4.Text = "Report4"
        Me.btnRep4.UseVisualStyleBackColor = True
        '
        'btnRep5
        '
        Me.btnRep5.Location = New System.Drawing.Point(7, 474)
        Me.btnRep5.Name = "btnRep5"
        Me.btnRep5.Size = New System.Drawing.Size(99, 23)
        Me.btnRep5.TabIndex = 41
        Me.btnRep5.Text = "Report5"
        Me.btnRep5.UseVisualStyleBackColor = True
        '
        'btnRep3
        '
        Me.btnRep3.Location = New System.Drawing.Point(7, 421)
        Me.btnRep3.Name = "btnRep3"
        Me.btnRep3.Size = New System.Drawing.Size(99, 23)
        Me.btnRep3.TabIndex = 42
        Me.btnRep3.Text = "Report3"
        Me.btnRep3.UseVisualStyleBackColor = True
        '
        'btnRep1
        '
        Me.btnRep1.Location = New System.Drawing.Point(7, 369)
        Me.btnRep1.Name = "btnRep1"
        Me.btnRep1.Size = New System.Drawing.Size(99, 23)
        Me.btnRep1.TabIndex = 40
        Me.btnRep1.Text = "Report1"
        Me.btnRep1.UseVisualStyleBackColor = True
        '
        'tstReports
        '
        Me.tstReports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnRepNew, Me.tbnRepOpen, Me.tbnRepSave, Me.tbnRepPrint, Me.tbnRepFont})
        Me.tstReports.Location = New System.Drawing.Point(0, 0)
        Me.tstReports.Name = "tstReports"
        Me.tstReports.Size = New System.Drawing.Size(864, 25)
        Me.tstReports.TabIndex = 38
        Me.tstReports.Text = "tstReports"
        '
        'tbnRepNew
        '
        Me.tbnRepNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbnRepNew.Enabled = False
        Me.tbnRepNew.Image = CType(resources.GetObject("tbnRepNew.Image"), System.Drawing.Image)
        Me.tbnRepNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbnRepNew.Name = "tbnRepNew"
        Me.tbnRepNew.Size = New System.Drawing.Size(23, 22)
        Me.tbnRepNew.Text = "New"
        '
        'tbnRepOpen
        '
        Me.tbnRepOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbnRepOpen.Enabled = False
        Me.tbnRepOpen.Image = CType(resources.GetObject("tbnRepOpen.Image"), System.Drawing.Image)
        Me.tbnRepOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbnRepOpen.Name = "tbnRepOpen"
        Me.tbnRepOpen.Size = New System.Drawing.Size(23, 22)
        Me.tbnRepOpen.Text = "Open"
        '
        'tbnRepSave
        '
        Me.tbnRepSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbnRepSave.Enabled = False
        Me.tbnRepSave.Image = CType(resources.GetObject("tbnRepSave.Image"), System.Drawing.Image)
        Me.tbnRepSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbnRepSave.Name = "tbnRepSave"
        Me.tbnRepSave.Size = New System.Drawing.Size(23, 22)
        Me.tbnRepSave.Text = "Save"
        '
        'tbnRepPrint
        '
        Me.tbnRepPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbnRepPrint.Image = CType(resources.GetObject("tbnRepPrint.Image"), System.Drawing.Image)
        Me.tbnRepPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbnRepPrint.Name = "tbnRepPrint"
        Me.tbnRepPrint.Size = New System.Drawing.Size(23, 22)
        Me.tbnRepPrint.Text = "Print"
        '
        'tbnRepFont
        '
        Me.tbnRepFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbnRepFont.Enabled = False
        Me.tbnRepFont.Image = CType(resources.GetObject("tbnRepFont.Image"), System.Drawing.Image)
        Me.tbnRepFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbnRepFont.Name = "tbnRepFont"
        Me.tbnRepFont.Size = New System.Drawing.Size(23, 22)
        Me.tbnRepFont.Text = "Change Font"
        '
        'chkRepLimitInvoice
        '
        Me.chkRepLimitInvoice.AutoSize = True
        Me.chkRepLimitInvoice.Location = New System.Drawing.Point(7, 211)
        Me.chkRepLimitInvoice.Name = "chkRepLimitInvoice"
        Me.chkRepLimitInvoice.Size = New System.Drawing.Size(61, 17)
        Me.chkRepLimitInvoice.TabIndex = 27
        Me.chkRepLimitInvoice.Text = "Invoice"
        Me.chkRepLimitInvoice.UseVisualStyleBackColor = True
        '
        'lblRepLimitSelection
        '
        Me.lblRepLimitSelection.AutoSize = True
        Me.lblRepLimitSelection.Location = New System.Drawing.Point(4, 33)
        Me.lblRepLimitSelection.Name = "lblRepLimitSelection"
        Me.lblRepLimitSelection.Size = New System.Drawing.Size(86, 13)
        Me.lblRepLimitSelection.TabIndex = 29
        Me.lblRepLimitSelection.Text = "Limit to selected:"
        '
        'chkRepLimitClient
        '
        Me.chkRepLimitClient.AutoSize = True
        Me.chkRepLimitClient.Location = New System.Drawing.Point(7, 189)
        Me.chkRepLimitClient.Name = "chkRepLimitClient"
        Me.chkRepLimitClient.Size = New System.Drawing.Size(52, 17)
        Me.chkRepLimitClient.TabIndex = 26
        Me.chkRepLimitClient.Text = "Client"
        Me.chkRepLimitClient.UseVisualStyleBackColor = True
        '
        'chkRepLimitGroup
        '
        Me.chkRepLimitGroup.AutoSize = True
        Me.chkRepLimitGroup.Checked = True
        Me.chkRepLimitGroup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRepLimitGroup.Location = New System.Drawing.Point(7, 165)
        Me.chkRepLimitGroup.Name = "chkRepLimitGroup"
        Me.chkRepLimitGroup.Size = New System.Drawing.Size(55, 17)
        Me.chkRepLimitGroup.TabIndex = 25
        Me.chkRepLimitGroup.Text = "Group"
        Me.chkRepLimitGroup.UseVisualStyleBackColor = True
        '
        'chkRepLimitTrack
        '
        Me.chkRepLimitTrack.AutoSize = True
        Me.chkRepLimitTrack.Location = New System.Drawing.Point(7, 142)
        Me.chkRepLimitTrack.Name = "chkRepLimitTrack"
        Me.chkRepLimitTrack.Size = New System.Drawing.Size(54, 17)
        Me.chkRepLimitTrack.TabIndex = 24
        Me.chkRepLimitTrack.Text = "Track"
        Me.chkRepLimitTrack.UseVisualStyleBackColor = True
        '
        'mnuReports
        '
        Me.mnuReports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepFile, Me.mnuRepEdit})
        Me.mnuReports.Location = New System.Drawing.Point(0, 0)
        Me.mnuReports.Name = "mnuReports"
        Me.mnuReports.Size = New System.Drawing.Size(864, 24)
        Me.mnuReports.TabIndex = 37
        Me.mnuReports.Text = "Reports"
        Me.mnuReports.Visible = False
        '
        'mnuRepFile
        '
        Me.mnuRepFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepFileOpen, Me.mnuRepFileSave, Me.mnuRepFilePrint, Me.mnuRepFileNew, Me.mnuRepFileRefresh})
        Me.mnuRepFile.Name = "mnuRepFile"
        Me.mnuRepFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuRepFile.Text = "Fi&le"
        '
        'mnuRepFileOpen
        '
        Me.mnuRepFileOpen.Name = "mnuRepFileOpen"
        Me.mnuRepFileOpen.Size = New System.Drawing.Size(113, 22)
        Me.mnuRepFileOpen.Text = "&Open"
        '
        'mnuRepFileSave
        '
        Me.mnuRepFileSave.Name = "mnuRepFileSave"
        Me.mnuRepFileSave.Size = New System.Drawing.Size(113, 22)
        Me.mnuRepFileSave.Text = "&Save"
        '
        'mnuRepFilePrint
        '
        Me.mnuRepFilePrint.Name = "mnuRepFilePrint"
        Me.mnuRepFilePrint.Size = New System.Drawing.Size(113, 22)
        Me.mnuRepFilePrint.Text = "&Print"
        '
        'mnuRepFileNew
        '
        Me.mnuRepFileNew.Name = "mnuRepFileNew"
        Me.mnuRepFileNew.Size = New System.Drawing.Size(113, 22)
        Me.mnuRepFileNew.Text = "&New"
        '
        'mnuRepFileRefresh
        '
        Me.mnuRepFileRefresh.Name = "mnuRepFileRefresh"
        Me.mnuRepFileRefresh.Size = New System.Drawing.Size(113, 22)
        Me.mnuRepFileRefresh.Text = "&Refresh"
        '
        'mnuRepEdit
        '
        Me.mnuRepEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepEditFont})
        Me.mnuRepEdit.Name = "mnuRepEdit"
        Me.mnuRepEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuRepEdit.Text = "E&dit"
        '
        'mnuRepEditFont
        '
        Me.mnuRepEditFont.Name = "mnuRepEditFont"
        Me.mnuRepEditFont.Size = New System.Drawing.Size(98, 22)
        Me.mnuRepEditFont.Text = "F&ont"
        '
        'tpgSearch
        '
        Me.tpgSearch.Controls.Add(Me.txtSearchPhone)
        Me.tpgSearch.Controls.Add(Me.lblSearchPhone)
        Me.tpgSearch.Controls.Add(Me.txtSearchMaximum)
        Me.tpgSearch.Controls.Add(Me.lblSearchMaximum)
        Me.tpgSearch.Controls.Add(Me.lbl2CharacterMinimum)
        Me.tpgSearch.Controls.Add(Me.grpMatchNumber)
        Me.tpgSearch.Controls.Add(Me.grpMatchPerItem)
        Me.tpgSearch.Controls.Add(Me.btnSearchClear)
        Me.tpgSearch.Controls.Add(Me.btnSearch)
        Me.tpgSearch.Controls.Add(Me.lvwSearchResult)
        Me.tpgSearch.Controls.Add(Me.dtpSearchDayOfBirth)
        Me.tpgSearch.Controls.Add(Me.lblSearchDayOfBirth)
        Me.tpgSearch.Controls.Add(Me.txtSearchEmail)
        Me.tpgSearch.Controls.Add(Me.lblSearchEmail)
        Me.tpgSearch.Controls.Add(Me.txtSearchGroupName)
        Me.tpgSearch.Controls.Add(Me.lblSearchGroupName)
        Me.tpgSearch.Controls.Add(Me.txtSearchPostalCode)
        Me.tpgSearch.Controls.Add(Me.lblSearchPostalCode)
        Me.tpgSearch.Controls.Add(Me.txtSearchCity)
        Me.tpgSearch.Controls.Add(Me.lblSearchCity)
        Me.tpgSearch.Controls.Add(Me.txtSearchLastName)
        Me.tpgSearch.Controls.Add(Me.lblSearchLastName)
        Me.tpgSearch.Controls.Add(Me.txtSearchFirstName)
        Me.tpgSearch.Controls.Add(Me.lblSearchFirstName)
        Me.tpgSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpgSearch.Name = "tpgSearch"
        Me.tpgSearch.Size = New System.Drawing.Size(864, 573)
        Me.tpgSearch.TabIndex = 5
        Me.tpgSearch.Text = "Search"
        Me.tpgSearch.UseVisualStyleBackColor = True
        '
        'txtSearchPhone
        '
        Me.txtSearchPhone.Location = New System.Drawing.Point(98, 198)
        Me.txtSearchPhone.Name = "txtSearchPhone"
        Me.txtSearchPhone.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchPhone.TabIndex = 32
        '
        'lblSearchPhone
        '
        Me.lblSearchPhone.AutoSize = True
        Me.lblSearchPhone.Location = New System.Drawing.Point(3, 201)
        Me.lblSearchPhone.Name = "lblSearchPhone"
        Me.lblSearchPhone.Size = New System.Drawing.Size(78, 13)
        Me.lblSearchPhone.TabIndex = 31
        Me.lblSearchPhone.Text = "Phone Number"
        '
        'txtSearchMaximum
        '
        Me.txtSearchMaximum.Location = New System.Drawing.Point(142, 415)
        Me.txtSearchMaximum.Name = "txtSearchMaximum"
        Me.txtSearchMaximum.Size = New System.Drawing.Size(49, 20)
        Me.txtSearchMaximum.TabIndex = 30
        Me.txtSearchMaximum.Text = "25"
        '
        'lblSearchMaximum
        '
        Me.lblSearchMaximum.AutoSize = True
        Me.lblSearchMaximum.Location = New System.Drawing.Point(27, 418)
        Me.lblSearchMaximum.Name = "lblSearchMaximum"
        Me.lblSearchMaximum.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchMaximum.TabIndex = 29
        Me.lblSearchMaximum.Text = "Maximum Hits"
        '
        'lbl2CharacterMinimum
        '
        Me.lbl2CharacterMinimum.Location = New System.Drawing.Point(95, 19)
        Me.lbl2CharacterMinimum.Name = "lbl2CharacterMinimum"
        Me.lbl2CharacterMinimum.Size = New System.Drawing.Size(124, 20)
        Me.lbl2CharacterMinimum.TabIndex = 28
        Me.lbl2CharacterMinimum.Text = "2 character minimum"
        '
        'grpMatchNumber
        '
        Me.grpMatchNumber.Controls.Add(Me.rbnMatchAll)
        Me.grpMatchNumber.Controls.Add(Me.rbnMatchAny)
        Me.grpMatchNumber.Location = New System.Drawing.Point(6, 346)
        Me.grpMatchNumber.Name = "grpMatchNumber"
        Me.grpMatchNumber.Size = New System.Drawing.Size(213, 64)
        Me.grpMatchNumber.TabIndex = 27
        Me.grpMatchNumber.TabStop = False
        Me.grpMatchNumber.Text = "Number of Matches"
        '
        'rbnMatchAll
        '
        Me.rbnMatchAll.AutoSize = True
        Me.rbnMatchAll.Checked = True
        Me.rbnMatchAll.Location = New System.Drawing.Point(24, 19)
        Me.rbnMatchAll.Name = "rbnMatchAll"
        Me.rbnMatchAll.Size = New System.Drawing.Size(69, 17)
        Me.rbnMatchAll.TabIndex = 1
        Me.rbnMatchAll.TabStop = True
        Me.rbnMatchAll.Text = "Match All"
        Me.rbnMatchAll.UseVisualStyleBackColor = True
        '
        'rbnMatchAny
        '
        Me.rbnMatchAny.AutoSize = True
        Me.rbnMatchAny.Location = New System.Drawing.Point(24, 42)
        Me.rbnMatchAny.Name = "rbnMatchAny"
        Me.rbnMatchAny.Size = New System.Drawing.Size(76, 17)
        Me.rbnMatchAny.TabIndex = 0
        Me.rbnMatchAny.Text = "Match Any"
        Me.rbnMatchAny.UseVisualStyleBackColor = True
        '
        'grpMatchPerItem
        '
        Me.grpMatchPerItem.Controls.Add(Me.rbnPartialMatchAny)
        Me.grpMatchPerItem.Controls.Add(Me.rbnExactMatch)
        Me.grpMatchPerItem.Controls.Add(Me.rbnPartialMatchLeft)
        Me.grpMatchPerItem.Location = New System.Drawing.Point(6, 253)
        Me.grpMatchPerItem.Name = "grpMatchPerItem"
        Me.grpMatchPerItem.Size = New System.Drawing.Size(213, 90)
        Me.grpMatchPerItem.TabIndex = 26
        Me.grpMatchPerItem.TabStop = False
        Me.grpMatchPerItem.Text = "Match per Item"
        '
        'rbnPartialMatchAny
        '
        Me.rbnPartialMatchAny.AutoSize = True
        Me.rbnPartialMatchAny.Location = New System.Drawing.Point(24, 42)
        Me.rbnPartialMatchAny.Name = "rbnPartialMatchAny"
        Me.rbnPartialMatchAny.Size = New System.Drawing.Size(137, 17)
        Me.rbnPartialMatchAny.TabIndex = 2
        Me.rbnPartialMatchAny.Text = "Partial Match Anywhere"
        Me.rbnPartialMatchAny.UseVisualStyleBackColor = True
        '
        'rbnExactMatch
        '
        Me.rbnExactMatch.AutoSize = True
        Me.rbnExactMatch.Location = New System.Drawing.Point(24, 65)
        Me.rbnExactMatch.Name = "rbnExactMatch"
        Me.rbnExactMatch.Size = New System.Drawing.Size(85, 17)
        Me.rbnExactMatch.TabIndex = 1
        Me.rbnExactMatch.Text = "Exact Match"
        Me.rbnExactMatch.UseVisualStyleBackColor = True
        '
        'rbnPartialMatchLeft
        '
        Me.rbnPartialMatchLeft.AutoSize = True
        Me.rbnPartialMatchLeft.Checked = True
        Me.rbnPartialMatchLeft.Location = New System.Drawing.Point(24, 19)
        Me.rbnPartialMatchLeft.Name = "rbnPartialMatchLeft"
        Me.rbnPartialMatchLeft.Size = New System.Drawing.Size(108, 17)
        Me.rbnPartialMatchLeft.TabIndex = 0
        Me.rbnPartialMatchLeft.TabStop = True
        Me.rbnPartialMatchLeft.Text = "Partial Match Left"
        Me.rbnPartialMatchLeft.UseVisualStyleBackColor = True
        '
        'btnSearchClear
        '
        Me.btnSearchClear.Location = New System.Drawing.Point(53, 471)
        Me.btnSearchClear.Name = "btnSearchClear"
        Me.btnSearchClear.Size = New System.Drawing.Size(122, 23)
        Me.btnSearchClear.TabIndex = 25
        Me.btnSearchClear.Text = "Clear"
        Me.btnSearchClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(53, 442)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(122, 23)
        Me.btnSearch.TabIndex = 24
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lvwSearchResult
        '
        Me.lvwSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSearchName, Me.colSearchAddress, Me.colSearchPostalCode, Me.colSearchCity, Me.colSearchTelephone, Me.colSearchMobile, Me.colSearchEmail, Me.colSearchDayOfBirth, Me.colSearchGroupName, Me.colSearchCountry, Me.colSearchGroupId})
        Me.lvwSearchResult.FullRowSelect = True
        Me.lvwSearchResult.GridLines = True
        Me.lvwSearchResult.HideSelection = False
        Me.lvwSearchResult.Location = New System.Drawing.Point(225, 19)
        Me.lvwSearchResult.MultiSelect = False
        Me.lvwSearchResult.Name = "lvwSearchResult"
        Me.lvwSearchResult.Size = New System.Drawing.Size(628, 540)
        Me.lvwSearchResult.TabIndex = 23
        Me.lvwSearchResult.UseCompatibleStateImageBehavior = False
        Me.lvwSearchResult.View = System.Windows.Forms.View.Details
        '
        'colSearchName
        '
        Me.colSearchName.Tag = "colSearchName"
        Me.colSearchName.Text = "Name"
        Me.colSearchName.Width = 90
        '
        'colSearchAddress
        '
        Me.colSearchAddress.Tag = "colSearchAddress"
        Me.colSearchAddress.Text = "Address"
        Me.colSearchAddress.Width = 90
        '
        'colSearchPostalCode
        '
        Me.colSearchPostalCode.Tag = "colSearchPostalCode"
        Me.colSearchPostalCode.Text = "Postal Code"
        '
        'colSearchCity
        '
        Me.colSearchCity.Tag = "colSearchCity"
        Me.colSearchCity.Text = "City"
        Me.colSearchCity.Width = 90
        '
        'colSearchTelephone
        '
        Me.colSearchTelephone.Tag = "colSearchTelephone"
        Me.colSearchTelephone.Text = "Telephone"
        Me.colSearchTelephone.Width = 75
        '
        'colSearchMobile
        '
        Me.colSearchMobile.Tag = "colSearchMobile"
        Me.colSearchMobile.Text = "Mobile"
        Me.colSearchMobile.Width = 75
        '
        'colSearchEmail
        '
        Me.colSearchEmail.Tag = "colSearchEmail"
        Me.colSearchEmail.Text = "Email Address"
        Me.colSearchEmail.Width = 90
        '
        'colSearchDayOfBirth
        '
        Me.colSearchDayOfBirth.Tag = "colSearchDayOfBirth"
        Me.colSearchDayOfBirth.Text = "Day Of Birth"
        '
        'colSearchGroupName
        '
        Me.colSearchGroupName.Tag = "colSearchGroupName"
        Me.colSearchGroupName.Text = "Group Name"
        Me.colSearchGroupName.Width = 90
        '
        'colSearchCountry
        '
        Me.colSearchCountry.Tag = "colSearchCountry"
        Me.colSearchCountry.Text = "Country"
        Me.colSearchCountry.Width = 90
        '
        'colSearchGroupId
        '
        Me.colSearchGroupId.Tag = "colSearchGroupId"
        Me.colSearchGroupId.Text = "Group Number"
        Me.colSearchGroupId.Width = 90
        '
        'dtpSearchDayOfBirth
        '
        Me.dtpSearchDayOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSearchDayOfBirth.Location = New System.Drawing.Point(98, 224)
        Me.dtpSearchDayOfBirth.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpSearchDayOfBirth.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpSearchDayOfBirth.Name = "dtpSearchDayOfBirth"
        Me.dtpSearchDayOfBirth.Size = New System.Drawing.Size(121, 20)
        Me.dtpSearchDayOfBirth.TabIndex = 22
        Me.dtpSearchDayOfBirth.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'lblSearchDayOfBirth
        '
        Me.lblSearchDayOfBirth.AutoSize = True
        Me.lblSearchDayOfBirth.Location = New System.Drawing.Point(3, 230)
        Me.lblSearchDayOfBirth.Name = "lblSearchDayOfBirth"
        Me.lblSearchDayOfBirth.Size = New System.Drawing.Size(64, 13)
        Me.lblSearchDayOfBirth.TabIndex = 12
        Me.lblSearchDayOfBirth.Text = "Day Of Birth"
        '
        'txtSearchEmail
        '
        Me.txtSearchEmail.Location = New System.Drawing.Point(98, 172)
        Me.txtSearchEmail.Name = "txtSearchEmail"
        Me.txtSearchEmail.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchEmail.TabIndex = 11
        '
        'lblSearchEmail
        '
        Me.lblSearchEmail.AutoSize = True
        Me.lblSearchEmail.Location = New System.Drawing.Point(3, 175)
        Me.lblSearchEmail.Name = "lblSearchEmail"
        Me.lblSearchEmail.Size = New System.Drawing.Size(73, 13)
        Me.lblSearchEmail.TabIndex = 10
        Me.lblSearchEmail.Text = "Email Address"
        '
        'txtSearchGroupName
        '
        Me.txtSearchGroupName.Location = New System.Drawing.Point(98, 146)
        Me.txtSearchGroupName.Name = "txtSearchGroupName"
        Me.txtSearchGroupName.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchGroupName.TabIndex = 9
        '
        'lblSearchGroupName
        '
        Me.lblSearchGroupName.AutoSize = True
        Me.lblSearchGroupName.Location = New System.Drawing.Point(3, 149)
        Me.lblSearchGroupName.Name = "lblSearchGroupName"
        Me.lblSearchGroupName.Size = New System.Drawing.Size(89, 13)
        Me.lblSearchGroupName.TabIndex = 8
        Me.lblSearchGroupName.Text = "Group Name / Nr"
        '
        'txtSearchPostalCode
        '
        Me.txtSearchPostalCode.Location = New System.Drawing.Point(98, 94)
        Me.txtSearchPostalCode.Name = "txtSearchPostalCode"
        Me.txtSearchPostalCode.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchPostalCode.TabIndex = 7
        '
        'lblSearchPostalCode
        '
        Me.lblSearchPostalCode.AutoSize = True
        Me.lblSearchPostalCode.Location = New System.Drawing.Point(3, 97)
        Me.lblSearchPostalCode.Name = "lblSearchPostalCode"
        Me.lblSearchPostalCode.Size = New System.Drawing.Size(64, 13)
        Me.lblSearchPostalCode.TabIndex = 6
        Me.lblSearchPostalCode.Text = "Postal Code"
        '
        'txtSearchCity
        '
        Me.txtSearchCity.Location = New System.Drawing.Point(98, 120)
        Me.txtSearchCity.Name = "txtSearchCity"
        Me.txtSearchCity.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCity.TabIndex = 5
        '
        'lblSearchCity
        '
        Me.lblSearchCity.AutoSize = True
        Me.lblSearchCity.Location = New System.Drawing.Point(3, 123)
        Me.lblSearchCity.Name = "lblSearchCity"
        Me.lblSearchCity.Size = New System.Drawing.Size(24, 13)
        Me.lblSearchCity.TabIndex = 4
        Me.lblSearchCity.Text = "City"
        '
        'txtSearchLastName
        '
        Me.txtSearchLastName.Location = New System.Drawing.Point(98, 68)
        Me.txtSearchLastName.Name = "txtSearchLastName"
        Me.txtSearchLastName.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchLastName.TabIndex = 3
        '
        'lblSearchLastName
        '
        Me.lblSearchLastName.AutoSize = True
        Me.lblSearchLastName.Location = New System.Drawing.Point(3, 71)
        Me.lblSearchLastName.Name = "lblSearchLastName"
        Me.lblSearchLastName.Size = New System.Drawing.Size(58, 13)
        Me.lblSearchLastName.TabIndex = 2
        Me.lblSearchLastName.Text = "Last Name"
        '
        'txtSearchFirstName
        '
        Me.txtSearchFirstName.Location = New System.Drawing.Point(98, 42)
        Me.txtSearchFirstName.Name = "txtSearchFirstName"
        Me.txtSearchFirstName.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchFirstName.TabIndex = 1
        '
        'lblSearchFirstName
        '
        Me.lblSearchFirstName.AutoSize = True
        Me.lblSearchFirstName.Location = New System.Drawing.Point(3, 45)
        Me.lblSearchFirstName.Name = "lblSearchFirstName"
        Me.lblSearchFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblSearchFirstName.TabIndex = 0
        Me.lblSearchFirstName.Text = "First Name"
        '
        'txtMemo
        '
        Me.txtMemo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemo.Location = New System.Drawing.Point(1, 3)
        Me.txtMemo.Multiline = True
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(872, 57)
        Me.txtMemo.TabIndex = 15
        Me.txtMemo.Tag = "0"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(207, 1)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(233, 20)
        Me.lblDate.TabIndex = 19
        Me.lblDate.Text = "zaterdag 16 november 2008"
        '
        'opnReport
        '
        Me.opnReport.FileName = "Report.txt"
        '
        'savReport
        '
        Me.savReport.FileName = "Report.txt"
        '
        'prnReport
        '
        Me.prnReport.UseEXDialog = True
        '
        'btnTest3
        '
        Me.btnTest3.Location = New System.Drawing.Point(781, 1)
        Me.btnTest3.Name = "btnTest3"
        Me.btnTest3.Size = New System.Drawing.Size(75, 23)
        Me.btnTest3.TabIndex = 20
        Me.btnTest3.Text = "Test3"
        Me.btnTest3.UseVisualStyleBackColor = True
        Me.btnTest3.Visible = False
        '
        'txtTest1
        '
        Me.txtTest1.Location = New System.Drawing.Point(537, 4)
        Me.txtTest1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTest1.Name = "txtTest1"
        Me.txtTest1.Size = New System.Drawing.Size(76, 20)
        Me.txtTest1.TabIndex = 21
        Me.txtTest1.Visible = False
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        Me.tmrRefresh.Interval = 120000
        '
        'lblLicenseName
        '
        Me.lblLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLicenseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseName.Location = New System.Drawing.Point(692, 1)
        Me.lblLicenseName.Name = "lblLicenseName"
        Me.lblLicenseName.Size = New System.Drawing.Size(396, 20)
        Me.lblLicenseName.TabIndex = 22
        Me.lblLicenseName.Text = "Thicor Services Demo License"
        Me.lblLicenseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtsRepReport
        '
        Me.dtsRepReport.DataSetName = "dtsRepReport"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.calTrackMan)
        Me.pnlMain.Controls.Add(Me.grpCalButtons)
        Me.pnlMain.Controls.Add(Me.grpAppDetails)
        Me.pnlMain.Controls.Add(Me.grpCurrentSelection)
        Me.pnlMain.Controls.Add(Me.btnMemoSave)
        Me.pnlMain.Location = New System.Drawing.Point(8, 26)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMain.MinimumSize = New System.Drawing.Size(192, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(200, 671)
        Me.pnlMain.TabIndex = 23
        '
        'calTrackMan
        '
        Me.calTrackMan.Location = New System.Drawing.Point(0, 0)
        Me.calTrackMan.MaxDate = New Date(2098, 12, 31, 0, 0, 0, 0)
        Me.calTrackMan.MaxSelectionCount = 1
        Me.calTrackMan.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.calTrackMan.Name = "calTrackMan"
        Me.calTrackMan.ShowWeekNumbers = True
        Me.calTrackMan.TabIndex = 1
        '
        'grpCalButtons
        '
        Me.grpCalButtons.Controls.Add(Me.btnNextMonth)
        Me.grpCalButtons.Controls.Add(Me.btnNextWeek)
        Me.grpCalButtons.Controls.Add(Me.btnNextDay)
        Me.grpCalButtons.Controls.Add(Me.btnToday)
        Me.grpCalButtons.Controls.Add(Me.btnPrevDay)
        Me.grpCalButtons.Controls.Add(Me.btnPrevWeek)
        Me.grpCalButtons.Controls.Add(Me.btnPrevMonth)
        Me.grpCalButtons.Location = New System.Drawing.Point(0, 156)
        Me.grpCalButtons.Name = "grpCalButtons"
        Me.grpCalButtons.Size = New System.Drawing.Size(200, 35)
        Me.grpCalButtons.TabIndex = 18
        Me.grpCalButtons.TabStop = False
        '
        'btnNextMonth
        '
        Me.btnNextMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextMonth.Image = CType(resources.GetObject("btnNextMonth.Image"), System.Drawing.Image)
        Me.btnNextMonth.Location = New System.Drawing.Point(168, 11)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(28, 20)
        Me.btnNextMonth.TabIndex = 21
        Me.btnNextMonth.UseVisualStyleBackColor = True
        '
        'btnNextWeek
        '
        Me.btnNextWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextWeek.Image = CType(resources.GetObject("btnNextWeek.Image"), System.Drawing.Image)
        Me.btnNextWeek.Location = New System.Drawing.Point(140, 11)
        Me.btnNextWeek.Name = "btnNextWeek"
        Me.btnNextWeek.Size = New System.Drawing.Size(26, 20)
        Me.btnNextWeek.TabIndex = 20
        Me.btnNextWeek.UseVisualStyleBackColor = True
        '
        'btnNextDay
        '
        Me.btnNextDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextDay.Image = CType(resources.GetObject("btnNextDay.Image"), System.Drawing.Image)
        Me.btnNextDay.Location = New System.Drawing.Point(114, 11)
        Me.btnNextDay.Name = "btnNextDay"
        Me.btnNextDay.Size = New System.Drawing.Size(26, 20)
        Me.btnNextDay.TabIndex = 19
        Me.btnNextDay.UseVisualStyleBackColor = True
        '
        'btnToday
        '
        Me.btnToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToday.Image = CType(resources.GetObject("btnToday.Image"), System.Drawing.Image)
        Me.btnToday.Location = New System.Drawing.Point(86, 11)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.Size = New System.Drawing.Size(26, 20)
        Me.btnToday.TabIndex = 18
        Me.btnToday.UseVisualStyleBackColor = True
        '
        'btnPrevDay
        '
        Me.btnPrevDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevDay.Image = CType(resources.GetObject("btnPrevDay.Image"), System.Drawing.Image)
        Me.btnPrevDay.Location = New System.Drawing.Point(60, 11)
        Me.btnPrevDay.Name = "btnPrevDay"
        Me.btnPrevDay.Size = New System.Drawing.Size(26, 20)
        Me.btnPrevDay.TabIndex = 17
        Me.btnPrevDay.UseVisualStyleBackColor = True
        '
        'btnPrevWeek
        '
        Me.btnPrevWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevWeek.Image = CType(resources.GetObject("btnPrevWeek.Image"), System.Drawing.Image)
        Me.btnPrevWeek.Location = New System.Drawing.Point(32, 11)
        Me.btnPrevWeek.Name = "btnPrevWeek"
        Me.btnPrevWeek.Size = New System.Drawing.Size(26, 20)
        Me.btnPrevWeek.TabIndex = 16
        Me.btnPrevWeek.UseVisualStyleBackColor = True
        '
        'btnPrevMonth
        '
        Me.btnPrevMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevMonth.Image = CType(resources.GetObject("btnPrevMonth.Image"), System.Drawing.Image)
        Me.btnPrevMonth.Location = New System.Drawing.Point(4, 11)
        Me.btnPrevMonth.Name = "btnPrevMonth"
        Me.btnPrevMonth.Size = New System.Drawing.Size(28, 20)
        Me.btnPrevMonth.TabIndex = 15
        Me.btnPrevMonth.UseVisualStyleBackColor = True
        '
        'grpAppDetails
        '
        Me.grpAppDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAppDetails.Controls.Add(Me.chkListClient)
        Me.grpAppDetails.Controls.Add(Me.lvwAppClients)
        Me.grpAppDetails.Controls.Add(Me.lblAppDetailsTrack)
        Me.grpAppDetails.Controls.Add(Me.txtAppDetailsTrack)
        Me.grpAppDetails.Controls.Add(Me.lblAppDetailsTime)
        Me.grpAppDetails.Controls.Add(Me.txtAppDetailsTime)
        Me.grpAppDetails.Controls.Add(Me.lblAppDetailsDate)
        Me.grpAppDetails.Controls.Add(Me.txtAppDetailsDate)
        Me.grpAppDetails.Controls.Add(Me.grpAppButtons)
        Me.grpAppDetails.Location = New System.Drawing.Point(0, 278)
        Me.grpAppDetails.Name = "grpAppDetails"
        Me.grpAppDetails.Size = New System.Drawing.Size(200, 319)
        Me.grpAppDetails.TabIndex = 16
        Me.grpAppDetails.TabStop = False
        Me.grpAppDetails.Text = "Appointment Details"
        '
        'chkListClient
        '
        Me.chkListClient.AutoSize = True
        Me.chkListClient.Location = New System.Drawing.Point(11, 98)
        Me.chkListClient.Name = "chkListClient"
        Me.chkListClient.Size = New System.Drawing.Size(52, 17)
        Me.chkListClient.TabIndex = 21
        Me.chkListClient.Text = "Client"
        Me.chkListClient.UseVisualStyleBackColor = True
        '
        'lvwAppClients
        '
        Me.lvwAppClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwAppClients.CheckBoxes = True
        Me.lvwAppClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAppClient, Me.colAppLessonType, Me.colAppLessonCount})
        Me.lvwAppClients.FullRowSelect = True
        Me.lvwAppClients.GridLines = True
        Me.lvwAppClients.Location = New System.Drawing.Point(5, 93)
        Me.lvwAppClients.MultiSelect = False
        Me.lvwAppClients.Name = "lvwAppClients"
        Me.lvwAppClients.Size = New System.Drawing.Size(189, 82)
        Me.lvwAppClients.TabIndex = 18
        Me.lvwAppClients.Tag = "lvwAppClients"
        Me.lvwAppClients.UseCompatibleStateImageBehavior = False
        Me.lvwAppClients.View = System.Windows.Forms.View.Details
        '
        'colAppClient
        '
        Me.colAppClient.Tag = "colAppClient"
        Me.colAppClient.Text = "Client"
        Me.colAppClient.Width = 62
        '
        'colAppLessonType
        '
        Me.colAppLessonType.Tag = "colAppLessonType"
        Me.colAppLessonType.Text = "Lesson Type"
        Me.colAppLessonType.Width = 75
        '
        'colAppLessonCount
        '
        Me.colAppLessonCount.Tag = "colAppLessonCount"
        Me.colAppLessonCount.Text = "Count"
        Me.colAppLessonCount.Width = 40
        '
        'lblAppDetailsTrack
        '
        Me.lblAppDetailsTrack.AutoSize = True
        Me.lblAppDetailsTrack.Location = New System.Drawing.Point(4, 70)
        Me.lblAppDetailsTrack.Name = "lblAppDetailsTrack"
        Me.lblAppDetailsTrack.Size = New System.Drawing.Size(35, 13)
        Me.lblAppDetailsTrack.TabIndex = 7
        Me.lblAppDetailsTrack.Text = "Track"
        '
        'txtAppDetailsTrack
        '
        Me.txtAppDetailsTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAppDetailsTrack.Enabled = False
        Me.txtAppDetailsTrack.Location = New System.Drawing.Point(64, 67)
        Me.txtAppDetailsTrack.Name = "txtAppDetailsTrack"
        Me.txtAppDetailsTrack.ReadOnly = True
        Me.txtAppDetailsTrack.Size = New System.Drawing.Size(130, 20)
        Me.txtAppDetailsTrack.TabIndex = 6
        '
        'lblAppDetailsTime
        '
        Me.lblAppDetailsTime.AutoSize = True
        Me.lblAppDetailsTime.Location = New System.Drawing.Point(4, 45)
        Me.lblAppDetailsTime.Name = "lblAppDetailsTime"
        Me.lblAppDetailsTime.Size = New System.Drawing.Size(30, 13)
        Me.lblAppDetailsTime.TabIndex = 5
        Me.lblAppDetailsTime.Text = "Time"
        '
        'txtAppDetailsTime
        '
        Me.txtAppDetailsTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAppDetailsTime.Enabled = False
        Me.txtAppDetailsTime.Location = New System.Drawing.Point(64, 42)
        Me.txtAppDetailsTime.Name = "txtAppDetailsTime"
        Me.txtAppDetailsTime.ReadOnly = True
        Me.txtAppDetailsTime.Size = New System.Drawing.Size(130, 20)
        Me.txtAppDetailsTime.TabIndex = 4
        '
        'lblAppDetailsDate
        '
        Me.lblAppDetailsDate.AutoSize = True
        Me.lblAppDetailsDate.Location = New System.Drawing.Point(4, 21)
        Me.lblAppDetailsDate.Name = "lblAppDetailsDate"
        Me.lblAppDetailsDate.Size = New System.Drawing.Size(30, 13)
        Me.lblAppDetailsDate.TabIndex = 3
        Me.lblAppDetailsDate.Text = "Date"
        '
        'txtAppDetailsDate
        '
        Me.txtAppDetailsDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAppDetailsDate.Enabled = False
        Me.txtAppDetailsDate.Location = New System.Drawing.Point(64, 18)
        Me.txtAppDetailsDate.Name = "txtAppDetailsDate"
        Me.txtAppDetailsDate.ReadOnly = True
        Me.txtAppDetailsDate.Size = New System.Drawing.Size(130, 20)
        Me.txtAppDetailsDate.TabIndex = 2
        '
        'grpAppButtons
        '
        Me.grpAppButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpAppButtons.Controls.Add(Me.btnAppRemove)
        Me.grpAppButtons.Controls.Add(Me.btnAppClear)
        Me.grpAppButtons.Controls.Add(Me.btnAppDelete)
        Me.grpAppButtons.Controls.Add(Me.btnAppMove)
        Me.grpAppButtons.Controls.Add(Me.btnAppCreate)
        Me.grpAppButtons.Location = New System.Drawing.Point(0, 172)
        Me.grpAppButtons.Name = "grpAppButtons"
        Me.grpAppButtons.Size = New System.Drawing.Size(200, 141)
        Me.grpAppButtons.TabIndex = 20
        Me.grpAppButtons.TabStop = False
        '
        'btnAppRemove
        '
        Me.btnAppRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAppRemove.Enabled = False
        Me.btnAppRemove.Location = New System.Drawing.Point(10, 13)
        Me.btnAppRemove.Name = "btnAppRemove"
        Me.btnAppRemove.Size = New System.Drawing.Size(181, 23)
        Me.btnAppRemove.TabIndex = 24
        Me.btnAppRemove.Tag = "Remove From List"
        Me.btnAppRemove.Text = "Remove From List"
        Me.btnAppRemove.UseVisualStyleBackColor = True
        '
        'btnAppClear
        '
        Me.btnAppClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAppClear.Enabled = False
        Me.btnAppClear.Location = New System.Drawing.Point(10, 114)
        Me.btnAppClear.Name = "btnAppClear"
        Me.btnAppClear.Size = New System.Drawing.Size(181, 23)
        Me.btnAppClear.TabIndex = 23
        Me.btnAppClear.Tag = "Clear Appointment"
        Me.btnAppClear.Text = "Clear List"
        Me.btnAppClear.UseVisualStyleBackColor = True
        '
        'btnAppDelete
        '
        Me.btnAppDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAppDelete.Enabled = False
        Me.btnAppDelete.Location = New System.Drawing.Point(10, 88)
        Me.btnAppDelete.Name = "btnAppDelete"
        Me.btnAppDelete.Size = New System.Drawing.Size(181, 23)
        Me.btnAppDelete.TabIndex = 22
        Me.btnAppDelete.Tag = "Delete Appointment"
        Me.btnAppDelete.Text = "Delete Appointment"
        Me.btnAppDelete.UseVisualStyleBackColor = True
        '
        'btnAppMove
        '
        Me.btnAppMove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAppMove.Enabled = False
        Me.btnAppMove.Location = New System.Drawing.Point(10, 63)
        Me.btnAppMove.Name = "btnAppMove"
        Me.btnAppMove.Size = New System.Drawing.Size(181, 23)
        Me.btnAppMove.TabIndex = 21
        Me.btnAppMove.Tag = "Move Appointment"
        Me.btnAppMove.Text = "Move Appointment"
        Me.btnAppMove.UseVisualStyleBackColor = True
        '
        'btnAppCreate
        '
        Me.btnAppCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAppCreate.Enabled = False
        Me.btnAppCreate.Location = New System.Drawing.Point(10, 39)
        Me.btnAppCreate.Name = "btnAppCreate"
        Me.btnAppCreate.Size = New System.Drawing.Size(181, 23)
        Me.btnAppCreate.TabIndex = 20
        Me.btnAppCreate.Tag = "Create Appointment"
        Me.btnAppCreate.Text = "Create Appointment"
        Me.btnAppCreate.UseVisualStyleBackColor = True
        '
        'grpCurrentSelection
        '
        Me.grpCurrentSelection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCurrentSelection.Controls.Add(Me.btnClientProps)
        Me.grpCurrentSelection.Controls.Add(Me.lblCurrentSelectionClient)
        Me.grpCurrentSelection.Controls.Add(Me.txtCurrentSelectionClient)
        Me.grpCurrentSelection.Controls.Add(Me.lblCurrentSelectionGroup)
        Me.grpCurrentSelection.Controls.Add(Me.txtCurrentSelectionGroup)
        Me.grpCurrentSelection.Location = New System.Drawing.Point(0, 200)
        Me.grpCurrentSelection.Name = "grpCurrentSelection"
        Me.grpCurrentSelection.Size = New System.Drawing.Size(200, 67)
        Me.grpCurrentSelection.TabIndex = 15
        Me.grpCurrentSelection.TabStop = False
        Me.grpCurrentSelection.Text = "Current Selection"
        '
        'btnClientProps
        '
        Me.btnClientProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClientProps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientProps.Image = CType(resources.GetObject("btnClientProps.Image"), System.Drawing.Image)
        Me.btnClientProps.Location = New System.Drawing.Point(174, 41)
        Me.btnClientProps.Name = "btnClientProps"
        Me.btnClientProps.Size = New System.Drawing.Size(20, 20)
        Me.btnClientProps.TabIndex = 21
        Me.btnClientProps.UseVisualStyleBackColor = True
        '
        'lblCurrentSelectionClient
        '
        Me.lblCurrentSelectionClient.AutoSize = True
        Me.lblCurrentSelectionClient.Location = New System.Drawing.Point(4, 44)
        Me.lblCurrentSelectionClient.Name = "lblCurrentSelectionClient"
        Me.lblCurrentSelectionClient.Size = New System.Drawing.Size(33, 13)
        Me.lblCurrentSelectionClient.TabIndex = 3
        Me.lblCurrentSelectionClient.Text = "Client"
        '
        'txtCurrentSelectionClient
        '
        Me.txtCurrentSelectionClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentSelectionClient.Enabled = False
        Me.txtCurrentSelectionClient.Location = New System.Drawing.Point(64, 41)
        Me.txtCurrentSelectionClient.Name = "txtCurrentSelectionClient"
        Me.txtCurrentSelectionClient.ReadOnly = True
        Me.txtCurrentSelectionClient.Size = New System.Drawing.Size(108, 20)
        Me.txtCurrentSelectionClient.TabIndex = 2
        '
        'lblCurrentSelectionGroup
        '
        Me.lblCurrentSelectionGroup.AutoSize = True
        Me.lblCurrentSelectionGroup.Location = New System.Drawing.Point(5, 20)
        Me.lblCurrentSelectionGroup.Name = "lblCurrentSelectionGroup"
        Me.lblCurrentSelectionGroup.Size = New System.Drawing.Size(36, 13)
        Me.lblCurrentSelectionGroup.TabIndex = 1
        Me.lblCurrentSelectionGroup.Text = "Group"
        '
        'txtCurrentSelectionGroup
        '
        Me.txtCurrentSelectionGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentSelectionGroup.Enabled = False
        Me.txtCurrentSelectionGroup.Location = New System.Drawing.Point(65, 17)
        Me.txtCurrentSelectionGroup.Name = "txtCurrentSelectionGroup"
        Me.txtCurrentSelectionGroup.ReadOnly = True
        Me.txtCurrentSelectionGroup.Size = New System.Drawing.Size(130, 20)
        Me.txtCurrentSelectionGroup.TabIndex = 0
        '
        'btnUndo
        '
        Me.btnUndo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUndo.Enabled = False
        Me.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUndo.Location = New System.Drawing.Point(982, 707)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(103, 23)
        Me.btnUndo.TabIndex = 24
        Me.btnUndo.Text = "Undo"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'frmTrackManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 742)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.btnTest1)
        Me.Controls.Add(Me.btnTest2)
        Me.Controls.Add(Me.btnTest3)
        Me.Controls.Add(Me.lblLicenseName)
        Me.Controls.Add(Me.txtTest1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.sptTrackManager)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(929, 780)
        Me.Name = "frmTrackManager"
        Me.Text = "TrackManager"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.sptTrackManager.Panel1.ResumeLayout(False)
        Me.sptTrackManager.Panel2.ResumeLayout(False)
        Me.sptTrackManager.Panel2.PerformLayout()
        CType(Me.sptTrackManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sptTrackManager.ResumeLayout(False)
        Me.tabTrackManager.ResumeLayout(False)
        Me.tpgTracks.ResumeLayout(False)
        Me.pnlTracks.ResumeLayout(False)
        Me.tabTracks.ResumeLayout(False)
        Me.tpgTrack1.ResumeLayout(False)
        Me.grpTrack1.ResumeLayout(False)
        Me.grpTrack1.PerformLayout()
        Me.tpgGroups.ResumeLayout(False)
        Me.spcGroups.Panel1.ResumeLayout(False)
        Me.spcGroups.Panel2.ResumeLayout(False)
        CType(Me.spcGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcGroups.ResumeLayout(False)
        Me.grpGroupApp.ResumeLayout(False)
        Me.grpMainContact.ResumeLayout(False)
        Me.grpMainContact.PerformLayout()
        Me.grpGroupDetails.ResumeLayout(False)
        Me.grpGroupDetails.PerformLayout()
        Me.grpGroupMembers.ResumeLayout(False)
        Me.grpGroupMembers.PerformLayout()
        Me.grpGroupClientsView.ResumeLayout(False)
        Me.pnlGroupsView.ResumeLayout(False)
        Me.tpgFinance.ResumeLayout(False)
        Me.spcFinance.Panel1.ResumeLayout(False)
        Me.spcFinance.Panel1.PerformLayout()
        Me.spcFinance.Panel2.ResumeLayout(False)
        CType(Me.spcFinance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcFinance.ResumeLayout(False)
        Me.grpFinanceGroupPayments.ResumeLayout(False)
        Me.grpFinanceGroupPayments.PerformLayout()
        Me.tpgReports.ResumeLayout(False)
        Me.tpgReports.PerformLayout()
        Me.grpRepReportWidth.ResumeLayout(False)
        Me.grpRepReportWidth.PerformLayout()
        CType(Me.trbRepReportWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRepReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRepLimitType.ResumeLayout(False)
        Me.grpRepLimitType.PerformLayout()
        Me.tstReports.ResumeLayout(False)
        Me.tstReports.PerformLayout()
        Me.mnuReports.ResumeLayout(False)
        Me.mnuReports.PerformLayout()
        Me.tpgSearch.ResumeLayout(False)
        Me.tpgSearch.PerformLayout()
        Me.grpMatchNumber.ResumeLayout(False)
        Me.grpMatchNumber.PerformLayout()
        Me.grpMatchPerItem.ResumeLayout(False)
        Me.grpMatchPerItem.PerformLayout()
        CType(Me.dtsRepReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.grpCalButtons.ResumeLayout(False)
        Me.grpAppDetails.ResumeLayout(False)
        Me.grpAppDetails.PerformLayout()
        Me.grpAppButtons.ResumeLayout(False)
        Me.grpCurrentSelection.ResumeLayout(False)
        Me.grpCurrentSelection.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMainFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainFileLogoff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainFileReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainEditDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainEditTrack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainEditHour As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindowSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindowSecurity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainHelpManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMemoSave As System.Windows.Forms.Button
    Friend WithEvents mnuMainEditScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTest1 As System.Windows.Forms.Button
    Friend WithEvents btnTest2 As System.Windows.Forms.Button
    Friend WithEvents sptTrackManager As System.Windows.Forms.SplitContainer
    Friend WithEvents tabTrackManager As System.Windows.Forms.TabControl
    Friend WithEvents tpgTracks As System.Windows.Forms.TabPage
    Friend WithEvents vsbTracks As System.Windows.Forms.VScrollBar
    Friend WithEvents pnlTracks As System.Windows.Forms.Panel
    Friend WithEvents lblTracksBar As System.Windows.Forms.Label
    Friend WithEvents tabTracks As System.Windows.Forms.TabControl
    Friend WithEvents tpgTrack1 As System.Windows.Forms.TabPage
    Friend WithEvents grpTrack2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpTrack1 As System.Windows.Forms.GroupBox
    Friend WithEvents tpgFinance As System.Windows.Forms.TabPage
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblTrackTeacher As System.Windows.Forms.Label
    Friend WithEvents lblTrackClient As System.Windows.Forms.Label
    Friend WithEvents opnReport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents savReport As System.Windows.Forms.SaveFileDialog
    Friend WithEvents fntReport As System.Windows.Forms.FontDialog
    Friend WithEvents prnReport As System.Windows.Forms.PrintDialog
    Friend WithEvents btnTest3 As System.Windows.Forms.Button
    Friend WithEvents spcFinance As System.Windows.Forms.SplitContainer
    Friend WithEvents btnFinancePay As System.Windows.Forms.Button
    Friend WithEvents btnFinanceDelete As System.Windows.Forms.Button
    Friend WithEvents lvwProduct As System.Windows.Forms.ListView
    Friend WithEvents colProducts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProductCounts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProductAmounts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProductTax As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblFinanceProduct As System.Windows.Forms.Label
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents lblGroupName As System.Windows.Forms.Label
    Friend WithEvents lvwFinanceClients As System.Windows.Forms.ListView
    Friend WithEvents lvwFinanceGroups As System.Windows.Forms.ListView
    Friend WithEvents btnFinanceAdd As System.Windows.Forms.Button
    Friend WithEvents btnFinanceEdit As System.Windows.Forms.Button
    Friend WithEvents grpFinanceGroupPayments As System.Windows.Forms.GroupBox
    Friend WithEvents lvwFinance As System.Windows.Forms.ListView
    Friend WithEvents colDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents colClient As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLogin As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProduct As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colBilledAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPayedAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPayDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPayed As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFinancePayDue As System.Windows.Forms.TextBox
    Friend WithEvents lblFinancePayDue As System.Windows.Forms.Label
    Friend WithEvents txtFinancePayCount As System.Windows.Forms.TextBox
    Friend WithEvents txtFinancePayPayed As System.Windows.Forms.TextBox
    Friend WithEvents txtFinancePayBilled As System.Windows.Forms.TextBox
    Friend WithEvents lblFinancePayTotal As System.Windows.Forms.Label
    Friend WithEvents tpgReports As System.Windows.Forms.TabPage
    Friend WithEvents tstReports As System.Windows.Forms.ToolStrip
    Friend WithEvents tbnRepNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbnRepOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbnRepSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbnRepPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbnRepFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRep1 As System.Windows.Forms.Button
    Friend WithEvents btnRep4 As System.Windows.Forms.Button
    Friend WithEvents btnRep3 As System.Windows.Forms.Button
    Friend WithEvents btnRep5 As System.Windows.Forms.Button
    Friend WithEvents tpgSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtSearchLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchLastName As System.Windows.Forms.Label
    Friend WithEvents txtSearchFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchFirstName As System.Windows.Forms.Label
    Friend WithEvents txtSearchGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchGroupName As System.Windows.Forms.Label
    Friend WithEvents txtSearchPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchPostalCode As System.Windows.Forms.Label
    Friend WithEvents txtSearchCity As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchCity As System.Windows.Forms.Label
    Friend WithEvents txtSearchEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchEmail As System.Windows.Forms.Label
    Friend WithEvents lblSearchDayOfBirth As System.Windows.Forms.Label
    Friend WithEvents dtpSearchDayOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvwSearchResult As System.Windows.Forms.ListView
    Friend WithEvents colSearchName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchPostalCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents colSearchCity As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchGroupName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchDayOfBirth As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpMatchNumber As System.Windows.Forms.GroupBox
    Friend WithEvents rbnMatchAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbnMatchAny As System.Windows.Forms.RadioButton
    Friend WithEvents grpMatchPerItem As System.Windows.Forms.GroupBox
    Friend WithEvents rbnExactMatch As System.Windows.Forms.RadioButton
    Friend WithEvents rbnPartialMatchLeft As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearchClear As System.Windows.Forms.Button
    Friend WithEvents lbl2CharacterMinimum As System.Windows.Forms.Label
    Friend WithEvents colSearchCountry As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchTelephone As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchMobile As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSearchGroupId As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearchMaximum As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchMaximum As System.Windows.Forms.Label
    Friend WithEvents rbnPartialMatchAny As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearchPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchPhone As System.Windows.Forms.Label
    Friend WithEvents btnRepEmail As System.Windows.Forms.Button
    Friend WithEvents txtTest1 As System.Windows.Forms.TextBox
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents lblLicenseName As System.Windows.Forms.Label
    Friend WithEvents dgvRepReport As System.Windows.Forms.DataGridView
    Friend WithEvents dtsRepReport As System.Data.DataSet
    Friend WithEvents trbRepReportWidth As System.Windows.Forms.TrackBar
    Friend WithEvents grpRepReportWidth As System.Windows.Forms.GroupBox
    Friend WithEvents chkRepReportWidth As System.Windows.Forms.CheckBox
    Friend WithEvents txtRepReportWidth As System.Windows.Forms.TextBox
    Friend WithEvents rtbRepReportHeader As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbRepReportFooter As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents calTrackMan As System.Windows.Forms.MonthCalendar
    Friend WithEvents grpAppDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lvwAppClients As System.Windows.Forms.ListView
    Friend WithEvents colAppClient As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAppLessonType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAppLessonCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblAppDetailsTrack As System.Windows.Forms.Label
    Friend WithEvents txtAppDetailsTrack As System.Windows.Forms.TextBox
    Friend WithEvents lblAppDetailsTime As System.Windows.Forms.Label
    Friend WithEvents txtAppDetailsTime As System.Windows.Forms.TextBox
    Friend WithEvents lblAppDetailsDate As System.Windows.Forms.Label
    Friend WithEvents txtAppDetailsDate As System.Windows.Forms.TextBox
    Friend WithEvents grpCurrentSelection As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientProps As System.Windows.Forms.Button
    Friend WithEvents lblCurrentSelectionClient As System.Windows.Forms.Label
    Friend WithEvents txtCurrentSelectionClient As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentSelectionGroup As System.Windows.Forms.Label
    Friend WithEvents txtCurrentSelectionGroup As System.Windows.Forms.TextBox
    Friend WithEvents mnuMainHelpUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindowGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindowClients As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainWindowFinance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colOpenAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRep2 As System.Windows.Forms.Button
    Friend WithEvents grpCalButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnNextMonth As System.Windows.Forms.Button
    Friend WithEvents btnNextWeek As System.Windows.Forms.Button
    Friend WithEvents btnNextDay As System.Windows.Forms.Button
    Friend WithEvents btnToday As System.Windows.Forms.Button
    Friend WithEvents btnPrevDay As System.Windows.Forms.Button
    Friend WithEvents btnPrevWeek As System.Windows.Forms.Button
    Friend WithEvents btnPrevMonth As System.Windows.Forms.Button
    Friend WithEvents grpAppButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnAppRemove As System.Windows.Forms.Button
    Friend WithEvents btnAppClear As System.Windows.Forms.Button
    Friend WithEvents btnAppDelete As System.Windows.Forms.Button
    Friend WithEvents btnAppMove As System.Windows.Forms.Button
    Friend WithEvents btnAppCreate As System.Windows.Forms.Button
    Friend WithEvents tpgGroups As System.Windows.Forms.TabPage
    Friend WithEvents spcGroups As System.Windows.Forms.SplitContainer
    Friend WithEvents grpGroupApp As System.Windows.Forms.GroupBox
    Friend WithEvents btnGrpAppRemove As System.Windows.Forms.Button
    Friend WithEvents btnGrpAppAdd As System.Windows.Forms.Button
    Friend WithEvents btnGroupUpdateLevel As System.Windows.Forms.Button
    Friend WithEvents grpMainContact As System.Windows.Forms.GroupBox
    Friend WithEvents btnGroupsMainContact As System.Windows.Forms.Button
    Friend WithEvents txtMainContactMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtMainContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtMainContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMainContactCity As System.Windows.Forms.TextBox
    Friend WithEvents txtMainContactAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtMainContactName As System.Windows.Forms.TextBox
    Friend WithEvents grpGroupDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lvwGroups As System.Windows.Forms.ListView
    Friend WithEvents btnGroupEditClient As System.Windows.Forms.Button
    Friend WithEvents btnGroupManage As System.Windows.Forms.Button
    Friend WithEvents grpGroupMembers As System.Windows.Forms.GroupBox
    Friend WithEvents cbxCorrectLessonCount As System.Windows.Forms.ComboBox
    Friend WithEvents btnCorrectLessonCount As System.Windows.Forms.Button
    Friend WithEvents grpGroupClientsView As System.Windows.Forms.GroupBox
    Friend WithEvents pnlGroupsView As System.Windows.Forms.Panel
    Friend WithEvents grpGroupClients As System.Windows.Forms.GroupBox
    Friend WithEvents lblGroupLessonsTotal As System.Windows.Forms.Label
    Friend WithEvents lblGroupLessonsBilled As System.Windows.Forms.Label
    Friend WithEvents txtGroupLessonsBilled As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupLessonsTotal As System.Windows.Forms.TextBox
    Friend WithEvents vsbGroupClients As System.Windows.Forms.VScrollBar
    Friend WithEvents chkGroupHeader As System.Windows.Forms.CheckBox
    Friend WithEvents lblGroupClientLevel As System.Windows.Forms.Label
    Friend WithEvents lblGroupExtraCount As System.Windows.Forms.Label
    Friend WithEvents lblGroupLessonCount As System.Windows.Forms.Label
    Friend WithEvents lblGroupLessonType As System.Windows.Forms.Label
    Friend WithEvents lblGroupsFullName As System.Windows.Forms.Label
    Friend WithEvents txtGroupSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnRepReportCreate As System.Windows.Forms.Button
    Friend WithEvents cbxRepClients As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRepFinance As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRepLessons As System.Windows.Forms.ComboBox
    Friend WithEvents lblRepClients As System.Windows.Forms.Label
    Friend WithEvents lblRepFinance As System.Windows.Forms.Label
    Friend WithEvents lblRepLessons As System.Windows.Forms.Label
    Friend WithEvents grpRepLimitType As System.Windows.Forms.GroupBox
    Friend WithEvents rbnRepLimitTypeBar As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitTypeTeacher As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitTypeClient As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitTypeAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitMonth As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitWeek As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitDay As System.Windows.Forms.RadioButton
    Friend WithEvents rbnRepLimitSeason As System.Windows.Forms.RadioButton
    Friend WithEvents chkRepLimitInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents lblRepLimitSelection As System.Windows.Forms.Label
    Friend WithEvents chkRepLimitClient As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepLimitGroup As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepLimitTrack As System.Windows.Forms.CheckBox
    Friend WithEvents btnFav1 As System.Windows.Forms.Button
    Friend WithEvents cbxRepOther As System.Windows.Forms.ComboBox
    Friend WithEvents lblRepOther As System.Windows.Forms.Label
    Friend WithEvents btnFav5 As System.Windows.Forms.Button
    Friend WithEvents btnFav4 As System.Windows.Forms.Button
    Friend WithEvents btnFav3 As System.Windows.Forms.Button
    Friend WithEvents btnFav2 As System.Windows.Forms.Button
    Friend WithEvents mnuReports As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuRepFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepFileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepFilePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepFileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepFileRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepEditFont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFinanceGroupSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbxRepTrack As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRepLessonType As System.Windows.Forms.ComboBox
    Friend WithEvents chkRepLimitLessonType As System.Windows.Forms.CheckBox
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents cbxRepGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRepClient As System.Windows.Forms.ComboBox
    Friend WithEvents mnuMainEditClearAllLocks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkListClient As System.Windows.Forms.CheckBox

End Class
