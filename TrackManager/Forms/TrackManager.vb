Imports System.IO
Imports System.Drawing.Printing
Imports TrackManager.CPrintReportString
Imports DGVPrinterHelper
Imports System.Text
Imports System.Deployment.Application

Public Class frmTrackManager
    Private ClientBoxArray As New TrackBoxArray(Me, "ClientBoxArray")
    Private BarBoxArray As New TrackBoxArray(Me, "BarBoxArray")
    Private TimeBoxArray As New TrackBoxArray(Me, "TimeBoxArray")
    Private TeacherBoxArray As New TrackBoxArray(Me, "TeacherBoxArray")
    Private GroupChkArray As New Collection
    Private GroupClientArray As New Collection
    Private GroupLessonTypeArray As New Collection
    Private GroupLessonCountArray As New Collection
    Private GroupExtraCountArray As New Collection
    Private GroupLevelArray As New Collection
    Private FinanceChkArray As New Collection
    Private FinanceDateArray As New Collection
    Private FinanceClientArray As New Collection
    Private FinanceBookedByArray As New Collection
    Private FinanceDescriptionArray As New Collection
    Private FinanceCountArray As New Collection
    Private FinanceBilledArray As New Collection
    Private FinancePayedArray As New Collection
    Private FinanceGroupChkArray As New Collection
    Private FinanceGroupClientArray As New Collection
    Private WithEvents docToPrint As New Printing.PrintDocument
    Private previouslvwAppClients As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwFinanceGroups As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwFinanceClients As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwProduct As ListViewItem 'To hold reference to previously selected TreeNode

    Private Sub frmTrackManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ParseCommands()
        Me.Hide()
        frmSplash.Show()
        Me.Text = CurVar.ApplicationName
        If DebugMode Then
            TestEnable()
        Else
            'hide stuff clients shouldn't see
        End If
        'Me.Hide()

        SetDefaults()
        LoadLicense()
        'While blnLicenseValidated = False
        '    If blnLicenseValidated = False Then
        '        'MessageBox.Show(lanStrings.strLicenseError)
        '        frmSettings.ShowDialog(Me)
        '    End If
        'End While
        lblLicenseName.Text = strLicenseName
        'LoadXmlSettings()
        While blnDatabaseOnLine = False
            DatabaseSettingsLoad()
            DatabaseTest()
            If blnDatabaseOnLine = False Then
                MessageBox.Show(lanStrings.strDataError)
                frmSettings.ShowDialog(Me)
            End If
        End While

        LoadLogSettings()
        frmLoginForm.ShowDialog(Me)
        SecuritySet()
        LoadVersion()
        LoadViewSettings()
        LoadGeneralSettings()
        LoadButtonSettings()
        VariablesViewGet()
        VariablesScreenGet()
        ButtonOrderSet()

        'LoadXmlLanguage()
        Dim Properties As New Label
        Properties.Name = "Properties"
        SetLanguage(Properties)
        Properties.Dispose()
        'LoadScreenSettings()
        SetScreenSettings()
        SetOpeningHours()
        SetSeasonMonths()
        SetSeasonDates(Today)
        ClearOldLogs()
        BuildHandlers()
        SetLanguage(Me)
        BuildEnvironment()
        loadGroupItems()
        ProductsGet()
        ReportsGet()

        Me.Show()
        frmSplash.Hide()

        DateChanged()
    End Sub

    Private Sub TrackManager_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            ShowCurStat()
            If CurStatus.ReloadDay Then
                DayLoad()
                'If CurStatus.GroupID = 0 Then
                '	CurStatus.RefreshGroup = False
                'End If
                CurStatus.ReloadDay = False
            End If
            If CurStatus.ReloadGroups Then
                GroupsGet()
                'If CurStatus.GroupID = 0 Then
                '	CurStatus.RefreshGroup = False
                'End If
                CurStatus.ReloadGroups = False
            End If
            'If CurStatus.ReloadClients Then
            '	ClientsGet()
            'End If
            If tabTrackManager.SelectedTab.Name Is tpgGroups.Name Then
                GroupSelect(CurStatus.GroupID)
                If CurStatus.ReloadClients Then
                    ClientsGet()
                End If
            ElseIf tabTrackManager.SelectedTab.Name Is tpgFinance.Name Then
                FinanceGroupSelect(CurStatus.GroupID)
                FinanceClientSelect(CurStatus.ClientID)
                FinanceInvoicesGet()
            End If
        Catch ex As Exception
            WriteLog(ex.Message, 1)
            MessageBox.Show(lanStrings.strGeneralError & vbCrLf & lanStrings.strCheckLog)
        End Try
    End Sub

#Region "Main"

    Private Sub TrackManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeTrackPanel()
    End Sub

    Private Sub tabTrackManager_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTrackManager.SelectedIndexChanged
        MemoLoad()
        ButtonsHandle()
        If tabTrackManager.SelectedTab.Name Is tpgGroups.Name Then
            GroupSelect(CurStatus.GroupID)
            If CurStatus.RefreshGroup Then
                lvwGroups_SelectedIndexChanged(Nothing, Nothing)
                'If CurStatus.GroupID = 0 Then
                '	CurStatus.RefreshGroup = False
                'End If
                CurStatus.RefreshGroup = False
            End If
        ElseIf tabTrackManager.SelectedTab.Name Is tpgFinance.Name Then
            FinanceGroupSelect(CurStatus.GroupID)
            FinanceClientSelect(CurStatus.ClientID)
        End If
        'If CurStatus.RefreshClient Then
        '	ClientsGet()
        '	CurStatus.RefreshClient = False
        'End If
    End Sub

    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        If blnDatabaseOnLine = True And CurUser.LoginID > 0 Then
            MemoSave()
            DateChanged()
        End If
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        If CurApp.ID = 1 Then '=delete
            AppUnDelete()
        End If
        If CurApp.ID = 2 Then '=move
            AppUnMove()
        End If
        btnUndo.Enabled = False
    End Sub

#End Region

#Region "MenuItems"
    Private Sub mnuMainFileLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainFileLogoff.Click
        Logoff()
        Dim frmLogin As New frmLoginForm
        frmLogin.ShowDialog(Me)
        SecuritySet()
    End Sub

    Private Sub mnuMainFileReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainFileReload.Click
        Reload()
    End Sub

    Private Sub mnuMainFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainFileExit.Click
        Application.Exit()
        Me.Close()
    End Sub

    Private Sub mnuMainEditDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainEditDay.Click
        AppointmentsHandle("Smt", 0, calTrackMan.SelectionStart, "Lock", 0, 0, 0, 0, 0, 0, 0, CurUser.LoginID)
        DayLoad()
    End Sub

    Private Sub mnuMainEditTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainEditTrack.Click
        AppointmentsHandle("Smt", 0, calTrackMan.SelectionStart, "Lock", 0, CurStatus.TrackID, 0, 0, 0, 0, 0, CurUser.LoginID)
        DayLoad()
    End Sub

    Private Sub mnuMainEditHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainEditHour.Click
        AppointmentsHandle("Smt", 0, calTrackMan.SelectionStart.AddMinutes(CurApp.Day.Hour * 60 + CurApp.Day.Minute), "Lock", 0, CurStatus.TrackID, 0, 0, 0, 0, 0, CurUser.LoginID)
        DayLoad()
    End Sub

    Private Sub mnuMainEditClearAllLocks_Click(sender As Object, e As EventArgs) Handles mnuMainEditClearAllLocks.Click
        AppointmentsHandle("Del", 0, calTrackMan.SelectionStart, "Lock", 0, 0, 0, 0, 0, 0, 0, CurUser.LoginID)
        DayLoad()
    End Sub

    Private Sub mnuMainEditScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainEditScreen.Click
        'If Me.WindowState = 2 Then
        '	SaveConfigSetting("ScreenPosition", "ScreenState", Me.WindowState)
        'Else
        CurVar.ScreenTop = Me.Top
        CurVar.ScreenLeft = Me.Left
        CurVar.ScreenHeight = Me.Height
        CurVar.ScreenWidth = Me.Width
        CurVar.ScreenState = Me.WindowState
        VariablesScreenSave()
        'SaveConfigSetting("ScreenPosition", "ScreenTop", Me.Top)
        'SaveConfigSetting("ScreenPosition", "ScreenLeft", Me.Left)
        'SaveConfigSetting("ScreenPosition", "ScreenWidth", Me.Width)
        'SaveConfigSetting("ScreenPosition", "ScreenHeight", Me.Height)
        'SaveConfigSetting("ScreenPosition", "ScreenState", Me.WindowState)
        'End If
    End Sub

    Private Sub mnuMainWindowSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainWindowSettings.Click
        ShowSettingsForm()
    End Sub

    Private Sub mnuMainWindowSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainWindowSecurity.Click
        ShowLoginsForm()
    End Sub

    Private Sub mnuMainWindowGroups_Click(sender As Object, e As EventArgs) Handles mnuMainWindowGroups.Click
        ShowGroupsForm()
    End Sub

    Private Sub mnuMainWindowClients_Click(sender As Object, e As EventArgs) Handles mnuMainWindowClients.Click
        ShowClientsForm()
    End Sub

    Private Sub mnuMainWindowFinance_Click(sender As Object, e As EventArgs) Handles mnuMainWindowFinance.Click
        ShowFinanceForm()
    End Sub

    Private Sub mnuMainHelpManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainHelpManual.Click
        System.Diagnostics.Process.Start("http://trackmanager.nl/manual")
        'MessageBox.Show("Manual is not yet available.")
    End Sub

    Private Sub mnuMainHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainHelpAbout.Click
        ShowSplashForm()
    End Sub

    Private Sub ShowSettingsForm()
        Dim frmSettingsForm As New frmSettings
        frmSettingsForm.ShowDialog(Me)
    End Sub

    Private Sub ShowLoginsForm()
        Dim frmLoginsForm As New frmLogins
        frmLoginsForm.ShowDialog(Me)
    End Sub

    Private Sub ShowFinanceForm()
        Dim frmFinanceForm As New frmFinance
        frmFinanceForm.ShowDialog(Me)
    End Sub

    Private Sub ShowSplashForm()
        CurVar.CallSplash = True
        Dim frmSplashForm As New frmSplash
        frmSplashForm.Show(Me)
    End Sub

    Private Sub ShowAppointmentForm()
        Dim frmAppoinmentChangeForm As New frmAppointmentChange
        frmAppoinmentChangeForm.ShowDialog(Me)
    End Sub

#End Region

#Region "Startup"

    Private Sub SetScreenSettings()
        Me.Top = CurVar.ScreenTop
        Me.Left = CurVar.ScreenLeft
        Me.Width = CurVar.ScreenWidth
        Me.Height = CurVar.ScreenHeight
        Me.WindowState = CurVar.ScreenState

        pnlMain.Width = calTrackMan.Width
        'If calTrackMan.Width > pnlMain.Width Then
        '    pnlMain.Width = calTrackMan.Width
        '    calTrackMan.Left = 0
        'Else
        '    calTrackMan.Left = (pnlMain.Width - calTrackMan.Width) / 2
        'End If
        grpCalButtons.Left = (pnlMain.Width - grpCalButtons.Width) / 2
        grpAppButtons.Left = (pnlMain.Width - grpAppButtons.Width) / 2
        btnMemoSave.Left = (pnlMain.Width - btnMemoSave.Width) / 2
        lvwAppClients.Columns(0).Width = (lvwAppClients.Width - 30) / 100 * 40
        lvwAppClients.Columns(1).Width = (lvwAppClients.Width - 30) / 100 * 55
        lvwAppClients.Columns(2).Width = (lvwAppClients.Width - 30) / 100 * 15

        sptTrackManager.Left = pnlMain.Left + pnlMain.Width + (CurVar.BuildMargin * 2)
        sptTrackManager.Width = Me.Width - pnlMain.Width - (CurVar.BuildMargin * 8)
        lblDate.Left = pnlMain.Left + pnlMain.Width + (CurVar.BuildMargin * 2)

        txtCurrentSelectionGroup.BackColor = CurVar.ReadOnlyBackColor
        txtCurrentSelectionClient.BackColor = CurVar.ReadOnlyBackColor
        txtAppDetailsDate.BackColor = CurVar.ReadOnlyBackColor
        txtAppDetailsTime.BackColor = CurVar.ReadOnlyBackColor
        txtAppDetailsTrack.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactName.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactAddress.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactCity.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactEmail.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactPhone.BackColor = CurVar.ReadOnlyBackColor
        txtMainContactMobile.BackColor = CurVar.ReadOnlyBackColor
    End Sub

    Private Sub BuildHandlers()
        AddHandler Me.lvwGroups.ColumnClick, AddressOf lvwGroups_ColumnClick
        lvwGroups.Columns.Add(New ColHeader("Group Name", "colGroupName", 100, HorizontalAlignment.Left, True))
        lvwGroups.Columns.Add(New ColHeader("Group Number", "colGroupNumber", 100, HorizontalAlignment.Left, True))
        AddHandler Me.lvwFinanceGroups.ColumnClick, AddressOf lvwFinanceGroups_ColumnClick
        lvwFinanceGroups.Columns.Add(New ColHeader("Group Name", "colGroupName", 100, HorizontalAlignment.Left, True))
        lvwFinanceGroups.Columns.Add(New ColHeader("Group Number", "colGroupNumber", 100, HorizontalAlignment.Left, True))
        AddHandler Me.lvwFinanceClients.ColumnClick, AddressOf lvwFinanceClients_ColumnClick
        lvwFinanceClients.Columns.Add(New ColHeader("First Name", "colFirstName", 80, HorizontalAlignment.Left, True))
        lvwFinanceClients.Columns.Add(New ColHeader("Middle Name", "colMiddleName", 40, HorizontalAlignment.Left, True))
        lvwFinanceClients.Columns.Add(New ColHeader("Family Name", "colFamilyName", 80, HorizontalAlignment.Left, True))

    End Sub

    Private Sub LoadVersion()
        Dim strVersion As String, strTarget As String
        strVersion = LoadConfigSetting("Database", "Version")

        Dim MydbRef As New TMDB.DBRef
        strTarget = MydbRef.GetVersion(strVersion)
        Dim verDatabase As New Version(strVersion)
        If DebugMode Then MessageBox.Show("strVersion = " & strVersion & vbCrLf & "strTarget = " & strTarget & vbCrLf _
            & "Application Version: " & My.Application.Info.Version.ToString & vbCrLf _
            & "Database compared to Application version: " & verDatabase.CompareTo(My.Application.Info.Version))
        If Not (strTarget = Nothing Or strTarget = "") Then
            ShowSettingsForm()
        End If

    End Sub

#End Region

#Region "Build Environment"
    Private Sub BuildEnvironment()
        If mnuMainFile.Width + mnuMainEdit.Width + mnuMainWindow.Width + mnuMainHelp.Width + (3 * CurVar.BuildMargin) > lblDate.Left Then
            lblDate.Left = mnuMainFile.Width + mnuMainEdit.Width + mnuMainWindow.Width + mnuMainHelp.Width + (3 * CurVar.BuildMargin)
        End If
        BuildBar()
        If CurVar.ShowTimeWithTrack = False Then
            BuildTime(0, 0)
        End If
        BuildTracks()
        BuildGroupsTab(CurVar.ClientsPerGroup)
        AlignFinanceTotals()
        'BuildFinanceTab(CurVar.PayLines)
        'BuildFinanceGroup(CurVar.ClientsPerGroup)
    End Sub

    Private Sub BuildInterfaceCols(ByVal intMaxRows As Integer, ByVal strType As String, ByVal strParent As String, ByVal arrTarget As Collection, ByVal intLeft As Integer, ByVal intwidth As Integer)
        Dim intRowCount As Integer = 0
        If intMaxRows > arrTarget.Count Then
            For intRowCount = arrTarget.Count To intMaxRows
                If strType = "TextBox" Then
                    Dim txtControl As New TextBox
                    arrTarget.Add(txtControl)
                    If strParent = "grpGroupClients" Then
                        grpGroupClients.Controls.Add(txtControl)
                    End If
                    txtControl.Tag = intRowCount + 1
                    txtControl.Top = (CurVar.BuildMargin * 2) + (21 * (arrTarget.Count - 1))
                    txtControl.Left = intLeft
                    txtControl.TabIndex = 0
                    txtControl.TabStop = False
                    txtControl.Width = intwidth
                    txtControl.Enabled = False
                    If Not arrTarget Is GroupExtraCountArray Then
                        txtControl.BackColor = CurVar.ReadOnlyBackColor
                    End If
                    If arrTarget Is GroupClientArray Then
                        AddHandler txtControl.Click, AddressOf GroupClientClick
                    End If
                ElseIf strType = "CheckBox" Then
                    Dim chkControl As New CheckBox
                    arrTarget.Add(chkControl)
                    If strParent = "grpGroupClients" Then
                        grpGroupClients.Controls.Add(chkControl)
                    End If
                    chkControl.Tag = intRowCount + 1
                    chkControl.Top = (CurVar.BuildMargin * 2) + (21 * (arrTarget.Count - 1))
                    chkControl.Left = intLeft
                    chkControl.TabIndex = 0
                    chkControl.TabStop = False
                    chkControl.Width = intwidth
                    chkControl.Enabled = False
                    If arrTarget Is GroupChkArray Then
                        AddHandler chkControl.CheckedChanged, AddressOf GroupCheckChange
                    End If
                ElseIf strType = "ComboBox" Then
                    Dim cbxControl As New ComboBox
                    arrTarget.Add(cbxControl)
                    If strParent = "grpGroupClients" Then
                        grpGroupClients.Controls.Add(cbxControl)
                    End If
                    If arrTarget Is GroupLessonTypeArray Then
                        AddHandler cbxControl.SelectedIndexChanged, AddressOf GroupLessonTypeChange
                    End If
                    cbxControl.Tag = intRowCount + 1
                    cbxControl.Top = (CurVar.BuildMargin * 2) + (21 * (arrTarget.Count - 1))
                    cbxControl.Left = intLeft
                    cbxControl.TabIndex = 0
                    cbxControl.TabStop = False
                    cbxControl.Width = intwidth
                    cbxControl.Enabled = False
                End If
            Next intRowCount
        End If
    End Sub

#Region "Tracks"

    Private Sub BuildBar()
        'Create the Bar column
        Dim intIndexNumber As Integer = 0
        Dim intTop As Integer = 0
        'Dim dtmStart As Date = dtmTimeStart
        Dim intStart As Integer = intTimeStart
        'Dim dtmStop As Date = dtmTimeStop
        Dim intStop As Integer = intTimeStop

        lblTracksBar.Left = CurVar.BuildMargin
        lblTracksBar.Width = CurVar.TrackBoxWidth
        lblTracksBar.TextAlign = ContentAlignment.MiddleCenter

        'Do While dtmStart < dtmStop
        Do While intStart < intStop
            'intIndexNumber = "1" & "0000" & Format(dtmStart.Hour, "00") & Format(dtmStart.Minute, "00")
            intIndexNumber = "1" & "0000" & Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
            If Not (intStart = intTimeStart And TimeBoxArray.Count = 1) Then
                BarBoxArray.AddNewTrackBox()
            End If

            pnlTracks.Controls.Add(BarBoxArray(BarBoxArray.Count - 1))
            'BarBoxArray(BarBoxArray.Count - 1).Tag = Format(dtmStart.Hour, "00") & Format(dtmStart.Minute, "00")
            BarBoxArray(BarBoxArray.Count - 1).Tag = Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
            BarBoxArray(BarBoxArray.Count - 1).IndexNumber = intIndexNumber
            If BarBoxArray.Count = 1 Then
                BarBoxArray(BarBoxArray.Count - 1).Top = lblTracksBar.Top + lblTracksBar.Height + CurVar.BuildMargin
            Else
                BarBoxArray(BarBoxArray.Count - 1).Top = BarBoxArray(BarBoxArray.Count - 2).Top + BarBoxArray(BarBoxArray.Count - 2).Height - 1
            End If
            BarBoxArray(BarBoxArray.Count - 1).Left = lblTracksBar.Left
            BarBoxArray(BarBoxArray.Count - 1).Width = CurVar.TrackBoxWidth
            BarBoxArray(BarBoxArray.Count - 1).Height = Math.Ceiling(20 + ((CurVar.TrackBoxHeight - 1) * 12.5))
            If CurVar.TrackBoxHeight > 1 Then BarBoxArray(BarBoxArray.Count - 1).Multiline = True
            BarBoxArray(BarBoxArray.Count - 1).BorderStyle = BorderStyle.FixedSingle
            BarBoxArray(BarBoxArray.Count - 1).TextAlign = HorizontalAlignment.Center
            'BarBoxArray(BarBoxArray.Count - 1).BackColor = ChooseBackColors(dtmStart)
            BarBoxArray(BarBoxArray.Count - 1).BackColor = ChooseBackColor(intStart)
            'BarBoxArray(BarBoxArray.Count - 1).TabStop = False
            BarBoxArray(BarBoxArray.Count - 1).Visible = True
            BarBoxArray(BarBoxArray.Count - 1).ReadOnly = True
            'dtmStart = dtmStart.AddMinutes(CurVar.TimeFrame)
            intStart = intStart + CurVar.TimeFrame
        Loop
    End Sub

    Private Sub BuildTime(ByVal intTrackId As Integer, ByVal intTimeOffset As Integer, Optional ByVal grpTrack As GroupBox = Nothing)
        'Build the time Column
        Dim intIndexNumber As Integer = 0
        Dim intTop As Integer = 0
        'Dim dtmStart As Date = dtmTimeStart
        Dim intStart As Integer = intTimeStart
        'Dim dtmStop As Date = dtmTimeStop
        Dim intStop As Integer = intTimeStop

        'dtmStart = dtmStart.AddMinutes(intTimeOffset)
        intStart += intTimeOffset

        Dim lblTrackTime As New Label
        lblTrackTime.Name = "lblTrackTime"
        lblTrackTime.Text = lanStrings.strTime
        lblTrackTime.Height = lblTracksBar.Height
        lblTrackTime.Width = 45
        lblTrackTime.TextAlign = ContentAlignment.MiddleCenter
        'lblTrackTime.Tag = intIndex
        If grpTrack Is Nothing Then
            pnlTracks.Controls.Add(lblTrackTime)
            lblTrackTime.Top = lblTracksBar.Top
            lblTrackTime.Left = lblTracksBar.Left + CurVar.TrackBoxWidth + CurVar.BuildMargin
        Else
            grpTrack.Controls.Add(lblTrackTime)
            lblTrackTime.Top = 16
            lblTrackTime.Left = CurVar.BuildMargin
        End If

        'Do While dtmStart < dtmStop
        Do While intStart < intStop
            'Dim dtmDisplay As Date = dtmStart.AddMinutes(intTimeOffset)
            'intIndexNumber = "2" & Format(intTrackId, "00") & "00" & Format(dtmDisplay.Hour, "00") & Format(dtmDisplay.Minute, "00")
            intIndexNumber = "2" & Format(intTrackId, "00") & "00" & Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")

            'If Not (dtmStart = dtmTimeStart And TimeBoxArray.Count = 1) Then
            If Not ((intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset) And TimeBoxArray.Count = 1) Then
                TimeBoxArray.AddNewTrackBox()
            End If
            
            If grpTrack Is Nothing Then
                pnlTracks.Controls.Add(TimeBoxArray(TimeBoxArray.Count - 1))
            Else
                grpTrack.Controls.Add(TimeBoxArray(TimeBoxArray.Count - 1))
            End If

            'TimeBoxArray(TimeBoxArray.Count - 1).Tag = Format(dtmDisplay.Hour, "00") & Format(dtmDisplay.Minute, "00")
            TimeBoxArray(TimeBoxArray.Count - 1).Tag = Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
            TimeBoxArray(TimeBoxArray.Count - 1).IndexNumber = intIndexNumber
            'If dtmStart = dtmTimeStart Then
            If intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset Then
                TimeBoxArray(TimeBoxArray.Count - 1).Top = lblTrackTime.Top + lblTrackTime.Height + CurVar.BuildMargin
            Else
                TimeBoxArray(TimeBoxArray.Count - 1).Top = TimeBoxArray(TimeBoxArray.Count - 2).Top + TimeBoxArray(TimeBoxArray.Count - 2).Height - 1
            End If
            TimeBoxArray(TimeBoxArray.Count - 1).Left = lblTrackTime.Left
            TimeBoxArray(TimeBoxArray.Count - 1).Width = 45
            TimeBoxArray(TimeBoxArray.Count - 1).Height = Math.Ceiling(20 + ((CurVar.TrackBoxHeight - 1) * 12.5))
            If CurVar.TrackBoxHeight > 1 Then TimeBoxArray(TimeBoxArray.Count - 1).Multiline = True
            TimeBoxArray(TimeBoxArray.Count - 1).BorderStyle = BorderStyle.FixedSingle
            TimeBoxArray(TimeBoxArray.Count - 1).TextAlign = HorizontalAlignment.Center
            'TimeBoxArray(TimeBoxArray.Count - 1).BackColor = ChooseBackColors(dtmDisplay)
            TimeBoxArray(TimeBoxArray.Count - 1).BackColor = ChooseBackColor(intStart)
            TimeBoxArray(TimeBoxArray.Count - 1).TabStop = False
            TimeBoxArray(TimeBoxArray.Count - 1).Visible = True
            TimeBoxArray(TimeBoxArray.Count - 1).Text = Format(Math.Truncate(intStart / 60), "00") & ":" & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
            TimeBoxArray(TimeBoxArray.Count - 1).ReadOnly = True
            'dtmStart = dtmStart.AddMinutes(CurVar.TimeFrame)
            intStart = intStart + CurVar.TimeFrame
        Loop
        'grpTrack.Height = TimeBoxArray(TimeBoxArray.Count - 1).Top + TimeBoxArray(TimeBoxArray.Count - 1).Height + (2 * CurVar.BuildMargin)

    End Sub

    Private Sub BuildTracks()
        Dim intTrackSize As Integer 'size of the grpTrack control
        Dim intTrackPerTab As Integer 'number of tracks per tabpage
        Dim intTabSize As Integer 'usable size of the tabpage
        Dim intTrackPosition As Integer 'position of the track on the tab

        intTrackSize = (CurVar.BuildMargin * 2) + (CurVar.ClientsPerTrack * CurVar.TrackBoxWidth)
        If CurVar.ShowTeacher Then
            intTrackSize += CurVar.BuildMargin + (CurVar.TrackBoxWidth)
        End If
        If CurVar.ShowTimeWithTrack = False Then
            tabTracks.Left = lblTracksBar.Left + (CurVar.TrackBoxWidth) + (2 * CurVar.BuildMargin) + 45
        Else
            intTrackSize += CurVar.BuildMargin + (45)
            tabTracks.Left = lblTracksBar.Left + CurVar.TrackBoxWidth + CurVar.BuildMargin
        End If
        tabTracks.Width = vsbTracks.Left - tabTracks.Left - (2 * CurVar.BuildMargin)
        intTabSize = tabTracks.Width - CurVar.BuildMargin
        intTrackPerTab = Math.Floor((intTabSize - (2 * CurVar.BuildMargin)) / intTrackSize)
        If intTrackPerTab < 1 Then intTrackPerTab = 1

        tabTracks.TabPages.Clear()
        Dim objData As DataSet
        objData = TracksHandle("Get")
        If objData.Tables.Count = 0 Then Exit Sub
        If objData.Tables(0).Rows.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                intTrackPosition = intRowCount - (intTrackPerTab * (Math.Floor(intRowCount / intTrackPerTab)))
                If intTrackPosition = 0 Then 'Add a new tab
                    Dim tabItem As New TabPage
                    tabItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                    tabTracks.TabPages.Add(tabItem)
                Else 'use existing tab
                    tabTracks.TabPages.Item(tabTracks.TabPages.Count - 1).Text &= " & " & objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                End If

                Dim grpTrack As New GroupBox
                grpTrack.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_TrackId")
                grpTrack.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                tabTracks.TabPages.Item(tabTracks.TabPages.Count - 1).Controls.Add(grpTrack)

                grpTrack.Left = CurVar.BuildMargin + intTrackSize + ((intTrackPosition - 1) * intTrackSize)
                grpTrack.Top = CurVar.BuildMargin
                grpTrack.Width = intTrackSize
                grpTrack.Name = "grpTrack" & intRowCount + 1

                BuildTrack(grpTrack, objData.Tables.Item(0).Rows(intRowCount).Item("PK_TrackId"), objData.Tables.Item(0).Rows(intRowCount).Item("TrackOffset"))
                If CurVar.ShowTeacher Then
                    BuildTeacher(grpTrack, objData.Tables.Item(0).Rows(intRowCount).Item("TrackOffset"))
                End If
            End If
        Next
        ResizeTrackPanel()
    End Sub

    Private Sub BuildTrack(ByVal grpTrack As GroupBox, ByVal intTrackId As Integer, ByVal intTimeOffset As Integer)
        'Build the Client columns in the given grpTrack
        Dim intColcount As Integer = 0
        Dim intIndexNumber As Integer = 0
        Dim intTop As Integer = 0

        'Dim dtmStart As Date = dtmTimeStart
        Dim intStart As Integer = intTimeStart
        'Dim dtmStop As Date = dtmTimeStop
        Dim intStop As Integer = intTimeStop

        If CurVar.ShowTimeWithTrack = True Then
            BuildTime(intTrackId, intTimeOffset, grpTrack)
        End If

        Dim lblTrackClient As New Label
        lblTrackClient.Name = "lblTrackClient"
        lblTrackClient.Text = lanStrings.strClient
        lblTrackClient.Height = lblTracksBar.Height
        lblTrackClient.Width = CurVar.TrackBoxWidth
        lblTrackClient.TextAlign = ContentAlignment.MiddleCenter
        'lblTrackClient.Tag = intIndex
        grpTrack.Controls.Add(lblTrackClient)
        lblTrackClient.Top = 16
        If CurVar.ShowTimeWithTrack Then
            lblTrackClient.Left = (2 * CurVar.BuildMargin) + 45
        Else
            lblTrackClient.Left = CurVar.BuildMargin
        End If


        For intColcount = 1 To CurVar.ClientsPerTrack
            'dtmStart = dtmTimeStart
            intStart = intTimeStart + intTimeOffset
            'Do While dtmStart < dtmStop
            Do While intStart < intStop
                'Dim dtmDisplay As Date = dtmStart.AddMinutes(intTimeOffset)
                intIndexNumber = "3" & Format(intTrackId, "00") & Format(intColcount, "00") & Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
                If Not ((intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset) And ClientBoxArray.Count = 1) Then
                    'If Not (dtmStart = dtmTimeStart And ClientBoxArray.Count = 1) Then
                    ClientBoxArray.AddNewTrackBox()
                End If

                grpTrack.Controls.Add(ClientBoxArray(ClientBoxArray.Count - 1))

                ClientBoxArray(ClientBoxArray.Count - 1).Tag = Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
                ClientBoxArray(ClientBoxArray.Count - 1).IndexNumber = intIndexNumber
                If intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset Then
                    ClientBoxArray(ClientBoxArray.Count - 1).Top = lblTrackClient.Top + lblTrackClient.Height + CurVar.BuildMargin
                Else
                    ClientBoxArray(ClientBoxArray.Count - 1).Top = ClientBoxArray(ClientBoxArray.Count - 2).Top + ClientBoxArray(ClientBoxArray.Count - 2).Height - 1
                End If

                ClientBoxArray(ClientBoxArray.Count - 1).Left = ((intColcount - 1) * CurVar.TrackBoxWidth) + (CurVar.BuildMargin) - (intColcount - 1)
                If CurVar.ShowTimeWithTrack Then
                    ClientBoxArray(ClientBoxArray.Count - 1).Left += 45 + CurVar.BuildMargin
                End If

                ClientBoxArray(ClientBoxArray.Count - 1).Width = CurVar.TrackBoxWidth
                ClientBoxArray(ClientBoxArray.Count - 1).Height = Math.Ceiling(20 + ((CurVar.TrackBoxHeight - 1) * 12.5))
                If CurVar.TrackBoxHeight > 1 Then ClientBoxArray(ClientBoxArray.Count - 1).Multiline = True
                ClientBoxArray(ClientBoxArray.Count - 1).BorderStyle = BorderStyle.FixedSingle
                ClientBoxArray(ClientBoxArray.Count - 1).TextAlign = HorizontalAlignment.Center
                ClientBoxArray(ClientBoxArray.Count - 1).BackColor = ChooseBackColor(intStart)
                ClientBoxArray(ClientBoxArray.Count - 1).TabStop = False
                ClientBoxArray(ClientBoxArray.Count - 1).Visible = True
                ClientBoxArray(ClientBoxArray.Count - 1).ReadOnly = True
                intStart = intStart + CurVar.TimeFrame
            Loop
        Next
        grpTrack.Height = ClientBoxArray(ClientBoxArray.Count - 1).Top + ClientBoxArray(ClientBoxArray.Count - 1).Height + (2 * CurVar.BuildMargin)
        tabTracks.Height = grpTrack.Height + grpTrack.Top + (2 * CurVar.BuildMargin) + 20
    End Sub

    Private Sub BuildTeacher(ByVal grpTrack As GroupBox, ByVal intTimeOffset As Integer)
        'Build the Teacher column in the given grpTrack
        Dim intIndexNumber As Integer = 0
        Dim intTop As Integer = 0

        'Dim dtmStart As Date = dtmTimeStart
        Dim intStart As Integer = intTimeStart
        'Dim dtmStop As Date = dtmTimeStop
        Dim intStop As Integer = intTimeStop

        'dtmStart = dtmStart.AddMinutes(intTimeOffset)
        intStart += intTimeOffset

        Dim lblTrackTeacher As New Label
        lblTrackTeacher.Name = "lblTrackTeacher"
        lblTrackTeacher.Text = lanStrings.strTeacher
        lblTrackTeacher.Height = lblTracksBar.Height
        lblTrackTeacher.Width = CurVar.TrackBoxWidth
        lblTrackTeacher.TextAlign = ContentAlignment.MiddleCenter
        'lblTrackTime.Tag = intIndex
        grpTrack.Controls.Add(lblTrackTeacher)
        lblTrackTeacher.Top = 16
        lblTrackTeacher.Left = ClientBoxArray(ClientBoxArray.Count - 1).Left + CurVar.TrackBoxWidth + CurVar.BuildMargin

        'Do While dtmStart < dtmStop
        Do While intStart < intStop
            'Dim dtmDisplay As Date = dtmStart.AddMinutes(intTimeOffset)
            intIndexNumber = "4" & Format(grpTrack.Tag, "00") & "00" & Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")

            'If Not (dtmStart = dtmTimeStart And TeacherBoxArray.Count = 1) Then
            If Not ((intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset) And TeacherBoxArray.Count = 1) Then
                TeacherBoxArray.AddNewTrackBox()
            End If

            grpTrack.Controls.Add(TeacherBoxArray(TeacherBoxArray.Count - 1))

            TeacherBoxArray(TeacherBoxArray.Count - 1).Tag = Format(Math.Truncate(intStart / 60), "00") & Format(intStart - (Math.Truncate(intStart / 60) * 60), "00")
            TeacherBoxArray(TeacherBoxArray.Count - 1).IndexNumber = intIndexNumber
            'If dtmStart = dtmTimeStart Then
            If intStart = intTimeStart Or intStart = intTimeStart + intTimeOffset Then
                TeacherBoxArray(TeacherBoxArray.Count - 1).Top = lblTrackTeacher.Top + lblTrackTeacher.Height + CurVar.BuildMargin
            Else
                TeacherBoxArray(TeacherBoxArray.Count - 1).Top = TeacherBoxArray(TeacherBoxArray.Count - 2).Top + TeacherBoxArray(TeacherBoxArray.Count - 2).Height - 1
            End If
            TeacherBoxArray(TeacherBoxArray.Count - 1).Left = lblTrackTeacher.Left
            TeacherBoxArray(TeacherBoxArray.Count - 1).Width = CurVar.TrackBoxWidth
            TeacherBoxArray(TeacherBoxArray.Count - 1).Height = Math.Ceiling(20 + ((CurVar.TrackBoxHeight - 1) * 12.5))
            If CurVar.TrackBoxHeight > 1 Then TeacherBoxArray(TeacherBoxArray.Count - 1).Multiline = True
            TeacherBoxArray(TeacherBoxArray.Count - 1).BorderStyle = BorderStyle.FixedSingle
            TeacherBoxArray(TeacherBoxArray.Count - 1).TextAlign = HorizontalAlignment.Center
            TeacherBoxArray(TeacherBoxArray.Count - 1).BackColor = ChooseBackColor(intStart)
            TeacherBoxArray(TeacherBoxArray.Count - 1).TabStop = False
            TeacherBoxArray(TeacherBoxArray.Count - 1).Visible = True
            TeacherBoxArray(TeacherBoxArray.Count - 1).ReadOnly = True
            TeacherBoxArray(TeacherBoxArray.Count - 1).Text = intIndexNumber

            intStart = intStart + CurVar.TimeFrame
        Loop
    End Sub

    Private Sub Reload()
        'clear bar
        Application.Restart()
    End Sub

#End Region

#Region "Groups"

    Private Sub BuildGroupsTab(ByVal intMaxRows As Integer)
        BuildInterfaceCols(intMaxRows, "CheckBox", "grpGroupClients", GroupChkArray, chkGroupHeader.Left, lblGroupsFullName.Left - chkGroupHeader.Left - CurVar.BuildMargin)
        BuildInterfaceCols(intMaxRows, "TextBox", "grpGroupClients", GroupClientArray, lblGroupsFullName.Left, lblGroupLessonType.Left - lblGroupsFullName.Left - CurVar.BuildMargin)
        BuildInterfaceCols(intMaxRows, "ComboBox", "grpGroupClients", GroupLessonTypeArray, lblGroupLessonType.Left, lblGroupLessonCount.Left - lblGroupLessonType.Left - CurVar.BuildMargin)
        BuildInterfaceCols(intMaxRows, "TextBox", "grpGroupClients", GroupLessonCountArray, lblGroupLessonCount.Left, lblGroupExtraCount.Left - lblGroupLessonCount.Left - CurVar.BuildMargin)
        BuildInterfaceCols(intMaxRows, "TextBox", "grpGroupClients", GroupExtraCountArray, lblGroupExtraCount.Left, lblGroupClientLevel.Left - lblGroupExtraCount.Left - CurVar.BuildMargin)
        BuildInterfaceCols(intMaxRows, "ComboBox", "grpGroupClients", GroupLevelArray, lblGroupClientLevel.Left, lblGroupLessonCount.Left - lblGroupLessonType.Left - CurVar.BuildMargin)
        AlignGroupTotals()
    End Sub

    Private Sub AlignGroupTotals()
        txtGroupLessonsTotal.Left = lblGroupLessonCount.Left
        txtGroupLessonsTotal.Width = lblGroupExtraCount.Left - lblGroupLessonCount.Left - CurVar.BuildMargin
        lblGroupLessonsTotal.Left = txtGroupLessonsTotal.Left - lblGroupLessonsTotal.Width - CurVar.BuildMargin
        txtGroupLessonsBilled.Width = txtGroupLessonsTotal.Width
        txtGroupLessonsBilled.Left = grpGroupClients.Left + grpGroupClients.Width - txtGroupLessonsBilled.Width - CurVar.BuildMargin
        lblGroupLessonsBilled.Left = txtGroupLessonsBilled.Left - lblGroupLessonsBilled.Width - CurVar.BuildMargin
        grpGroupClients.Height = GroupChkArray(GroupChkArray.Count).Top + GroupChkArray(GroupChkArray.Count).Height + CurVar.BuildMargin
        vsbGroupClients.Maximum = grpGroupClients.Height
    End Sub

#End Region

#Region "Finance"

    Private Sub AlignFinanceTotals()
        lblFinancePayDue.Left = lvwFinance.Left + lvwFinance.Columns.Item(0).Width + CurVar.BuildMargin
        lblFinancePayDue.Width = lvwFinance.Columns.Item(1).Width - CurVar.BuildMargin
        txtFinancePayDue.Left = lblFinancePayDue.Left + lblFinancePayDue.Width + CurVar.BuildMargin
        txtFinancePayDue.Width = lvwFinance.Columns.Item(2).Width - CurVar.BuildMargin
        lblFinancePayTotal.Left = txtFinancePayDue.Left + txtFinancePayDue.Width + CurVar.BuildMargin
        lblFinancePayTotal.Width = lvwFinance.Columns.Item(3).Width - CurVar.BuildMargin
        txtFinancePayCount.Left = lblFinancePayTotal.Left + lblFinancePayTotal.Width + CurVar.BuildMargin
        txtFinancePayCount.Width = lvwFinance.Columns.Item(4).Width - CurVar.BuildMargin
        txtFinancePayBilled.Left = txtFinancePayCount.Left + txtFinancePayCount.Width + CurVar.BuildMargin
        txtFinancePayBilled.Width = lvwFinance.Columns.Item(5).Width - CurVar.BuildMargin
        txtFinancePayPayed.Left = txtFinancePayBilled.Left + txtFinancePayBilled.Width + CurVar.BuildMargin
        txtFinancePayPayed.Width = lvwFinance.Columns.Item(6).Width - CurVar.BuildMargin
    End Sub

#End Region

#Region "Buttons"
    Private Sub ButtonOrderSet()
        'btnAppRemove.Top = 13
        btnAppRemove.Top = 13 + ((CurVar.btnAppRemoveSortOrder - 1) * 25)
        btnAppCreate.Top = 13 + ((CurVar.btnAppCreateSortOrder - 1) * 25)
        btnAppMove.Top = 13 + ((CurVar.btnAppMoveSortOrder - 1) * 25)
        btnAppDelete.Top = 13 + ((CurVar.btnAppDeleteSortOrder - 1) * 25)
        btnAppClear.Top = 13 + ((CurVar.btnAppClearSortOrder - 1) * 25)
    End Sub
#End Region

#End Region

#Region "ShowCurrent"

    Private Sub ShowCurStat()
        If CurStatus.GroupID > 0 Then
            txtCurrentSelectionGroup.Tag = CurStatus.GroupID
            txtCurrentSelectionGroup.Text = GroupNameGet(CurStatus.GroupID)
        Else
            txtCurrentSelectionGroup.Tag = 0
            txtCurrentSelectionGroup.Text = ""
        End If
        If CurStatus.ClientID > 0 Then
            txtCurrentSelectionClient.Tag = CurStatus.ClientID
            txtCurrentSelectionClient.Text = ClientNameGet(CurStatus.ClientID)
        Else
            txtCurrentSelectionClient.Tag = 0
            txtCurrentSelectionClient.Text = ""
        End If
    End Sub

    Private Sub AppointmentClientsShow()
        lvwAppClients.Items.Clear()
        If CurApp.Clients.Count > 0 Then
            Dim appClient As Client
            For Each appClient In CurApp.Clients
                With appClient
                    Try
                        lvwAppClients.Items.Add(.Name)
                        lvwAppClients.Items(lvwAppClients.Items.Count - 1).Tag = .ID
                        lvwAppClients.Items(lvwAppClients.Items.Count - 1).Checked = .Checked
                        lvwAppClients.Items(lvwAppClients.Items.Count - 1).SubItems.Add(.LessonTypeName)
                        lvwAppClients.Items(lvwAppClients.Items.Count - 1).SubItems.Add(.LessonCount + .ExtraCount)
                    Catch ex As Exception
                        MessageBox.Show(lanStrings.strGeneralError & vbCrLf & lanStrings.strCheckLog)
                        WriteLog(ex.Message, 1)
                        lvwAppClients.Items.Clear()
                        CurApp.Clients.Clear()
                        Exit Sub
                    End Try
                End With
            Next appClient
        End If
    End Sub

    Private Sub btnClientProps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientProps.Click
        tabTrackManager.SelectedTab = tabTrackManager.TabPages.Item("tpgReports")
        rbnRepLimitSeason.Select()
        chkRepLimitClient.Checked = True
        btnRep1_Click(Nothing, Nothing)
        MemoLoad()

    End Sub

    Private Sub SetStatus(Optional ByVal strStatus As String = Nothing)
        If strStatus Is Nothing Then
            txtStatus.Text = ""
            txtStatus.BackColor = Color.LightGray
        Else
            txtStatus.Text = strStatus
            If txtStatus.BackColor = Color.Coral Then
                txtStatus.BackColor = Color.Goldenrod
            Else
                txtStatus.BackColor = Color.Coral
            End If
        End If
    End Sub

#End Region

#Region "Appointment"

    Private Sub lvwAppClients_DoubleClick(sender As Object, e As EventArgs) Handles lvwAppClients.DoubleClick
        If lvwAppClients.SelectedItems.Count > 0 Then
            If lvwAppClients.SelectedItems(0).Checked = False Then
                lvwAppClients.SelectedItems(0).Checked = True
            Else
                lvwAppClients.SelectedItems(0).Checked = False
            End If
        End If
    End Sub

    Private Sub chkListClient_CheckedChanged(sender As Object, e As EventArgs) Handles chkListClient.CheckedChanged
        'For i = 0 To CurApp.Clients.Count - 1
        '    CurApp.Clients(i).Checked = chkListClient.Checked
        'Next
        For Each cltItem In lvwAppClients.Items
            cltItem.Checked = chkListClient.Checked
        Next
    End Sub

    Private Sub lvwAppClients_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvwAppClients.ItemChecked
        For i = 0 To CurApp.Clients.Count - 1
            If CurApp.Clients(i).ID = e.Item.Tag Then
                CurApp.Clients(i).Checked = e.Item.Checked
            End If
        Next
        ButtonsHandle()
    End Sub

    Private Sub lvwAppClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwAppClients.SelectedIndexChanged
        If Not previouslvwAppClients Is Nothing Then
            previouslvwAppClients.BackColor = lvwAppClients.BackColor
            'previouslvwAppClients.ForeColor = lvwAppClients.ForeColor
        End If

        If lvwAppClients.SelectedItems.Count = 1 Then
            btnAppRemove.Enabled = True
        Else
            btnAppRemove.Enabled = False
        End If
    End Sub

    Private Sub lvwAppClients_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lvwAppClients.Validating
        If lvwAppClients.SelectedItems.Count > 0 Then
            lvwAppClients.SelectedItems(0).BackColor = Color.LightBlue
            'lvwAppClients.SelectedItems(0).ForeColor = Color.White
            previouslvwAppClients = lvwAppClients.SelectedItems(0)
        End If
    End Sub


    Private Sub btnAppRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppRemove.Click
        Dim intClientsCount As Integer = CurApp.Clients.Count - 1
        For intClientCount = 0 To intClientsCount
            If CurApp.Clients(intClientCount).Checked Then
                AppClientRemove(CurApp.Clients(intClientCount).ID)
                intClientCount -= 1
                intClientsCount -= 1
            End If
            If intClientCount = intClientsCount Then Exit For
        Next
        AppointmentClientsShow()

        'If lvwAppClients.SelectedItems.Count = 1 Then
        '    AppClientRemove(lvwAppClients.SelectedItems(0).Tag)
        '    AppointmentClientsShow()
        'End If
        'btnAppRemove.Enabled = False
        ButtonsHandle()
    End Sub

    Private Sub btnAppCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppCreate.Click
        'select the correct kind of appointment
        Dim intClientCount As Integer = 0
        Dim strType As String = CurApp.Name.Replace("BoxArray", "")
        strType = strType.Replace("Client", "Track")
        For Each cltClient In CurApp.Clients
            If cltClient.Checked Then
                If (strType = "Track" Or strType = "Teacher") And cltClient.LessonTypeID = 0 Then
                    MessageBox.Show(lanStrings.strMissingLessontype)
                    Exit Sub
                End If
                If strType = "Track" Then
                    If AppointmentFinanceGet(cltClient.GroupID, cltClient.ID) > -1 Then
                        If MessageBox.Show(lanStrings.strOverbookClient & vbCrLf & lanStrings.strClient & ": " & ClientNameGet(cltClient.ID) & "; " & lanStrings.strGroup & ": " & GroupNameGet(cltClient.GroupID) & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    End If
                End If
                AppointmentCreate(CurApp.Day, strType, cltClient.ID, CurApp.TrackId, CurApp.TrackIndex, cltClient.LessonTypeID, cltClient.LevelID, cltClient.LessonCount, cltClient.ExtraCount, CurUser.LoginID)
                cltClient.LessonCount += 1
                cltClient.TrackIndex = CurApp.TrackIndex
                intClientCount += 1
            End If
        Next
        If intClientCount > 0 Then
            CurApp.DayPrev = CurApp.Day
            CurApp.TrackIdPrev = CurApp.TrackId
            CurStatus.RefreshClient = True
            AppointmentClientsShow()
            DayLoad()
            ButtonsHandle()
        End If
    End Sub

    Private Sub btnAppMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppMove.Click
        Dim intClientCount As Integer = 0
        Dim intClientChecked As Integer = CheckedClientCount(CurApp)
        CurApp.ID = 2 '=move
        UndoAppClear()
        AppSync()

        Dim strType As String = CurApp.Name.Replace("BoxArray", "")
        strType = strType.Replace("Client", "Track")
        For Each cltClient In CurApp.Clients
            If CurApp.Day = CurApp.DayPrev And CurApp.TrackId = CurApp.TrackIdPrev Then
                If cltClient.ID = CurStatus.ClientID Then
                    AppointmentMove(CurApp.Day, CurApp.DayPrev, strType, cltClient.ID, CurApp.TrackId, CurApp.TrackIdPrev, CurApp.TrackIndex, cltClient.TrackIndex, cltClient.LessonTypeID, cltClient.LevelID, cltClient.LessonCount, cltClient.ExtraCount, CurUser.LoginID)
                    cltClient.TrackIndex = CurApp.TrackIndex
                    intClientCount += 1
                    'only 1 move allowed within slot
                    Exit For
                End If
            Else
                If cltClient.Checked Then
                    If intClientChecked = 1 Then
                        AppointmentMove(CurApp.Day, CurApp.DayPrev, strType, cltClient.ID, CurApp.TrackId, CurApp.TrackIdPrev, CurApp.TrackIndex, CurApp.TrackIndexPrev, cltClient.LessonTypeID, cltClient.LevelID, cltClient.LessonCount, cltClient.ExtraCount, CurUser.LoginID)
                        cltClient.TrackIndex = CurApp.TrackIndex
                    Else
                        AppointmentMove(CurApp.Day, CurApp.DayPrev, strType, cltClient.ID, CurApp.TrackId, CurApp.TrackIdPrev, cltClient.TrackIndex, cltClient.TrackIndex, cltClient.LessonTypeID, cltClient.LevelID, cltClient.LessonCount, cltClient.ExtraCount, CurUser.LoginID)
                    End If
                    'cltClient.TrackIndex = CurApp.TrackIndex
                    intClientCount += 1
                End If
            End If
        Next
        If intClientCount > 0 Then
            CurApp.DayPrev = CurApp.Day
            CurApp.TrackIdPrev = CurApp.TrackId
            DayLoad()
            ButtonsHandle()
            SetStatus(intClientCount & "x " & lanStrings.strClient & " moved")
            btnUndo.Enabled = True
        End If
    End Sub

    Private Sub btnAppDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppDelete.Click
        Dim intClientCount As Integer = 0
        CurApp.ID = 1 '=delete
        UndoAppClear()
        AppSync()

        Dim strType As String = CurApp.Name.Replace("BoxArray", "")
        strType = strType.Replace("Client", "Track")

        If CurVar.DeleteMax1Client = True Then
            For Each inputClient In CurApp.Clients
                If inputClient.Checked Then
                    intClientCount += 1
                End If
            Next
            If intClientCount > 1 Then
                MessageBox.Show(lanStrings.strDeleteMax1Client, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
        End If
        intClientCount = 0
        For Each inputClient In CurApp.Clients
            If inputClient.Checked Then
                AppointmentDelete(CurApp.Day, strType, inputClient.ID, CurStatus.TrackID, CurApp.TrackIndex, inputClient.LessonTypeID, inputClient.LevelID, inputClient.LessonCount, inputClient.ExtraCount)
                inputClient.LessonCount -= 1
                intClientCount += 1
            End If
        Next
        If intClientCount > 0 Then
            CurStatus.RefreshClient = True
            CurApp.Name = ""
            CurApp.Day = calTrackMan.SelectionStart
            txtAppDetailsTime.Tag = Nothing
            AppointmentClientsShow()
            DayClear()
            DayLoad()
            ButtonsHandle()
            SetStatus(intClientCount & "x " & lanStrings.strClient & " deleted")
            btnUndo.Enabled = True
        End If
    End Sub

    Private Sub btnAppClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppClear.Click
        AppointmentClear()
    End Sub

    Private Sub ButtonsHandle()
        Dim intClientsFound As Integer = 0
        Dim intClientsChecked As Integer = 0
        Dim blnClientFound As Boolean = False
        Dim blnTargetFree As Boolean = True
        'Dim blnSameTarget As Boolean = False
        Dim blnSameBoxArray As Boolean = False
        Dim dblClientId As Double = 0
        Dim strBoxArray As String = ""
        Dim intMaxApps As Integer = 0
        Dim strButton As String = ""

        btnAppCreate.Enabled = False
        btnAppCreate.Text = btnAppCreate.Tag
        btnAppMove.Enabled = False
        btnAppDelete.Enabled = False
        btnAppRemove.Enabled = False
        btnAppClear.Enabled = False

        mnuMainEditDay.Enabled = False
        mnuMainEditTrack.Enabled = False
        mnuMainEditHour.Enabled = False

        btnFinanceAdd.Enabled = False
        btnFinanceDelete.Enabled = False
        btnFinancePay.Enabled = False

        If tabTrackManager.SelectedTab.Name Is tpgFinance.Name Then
            If CurStatus.ClientID > 0 And lvwProduct.SelectedItems.Count = 1 Then
                btnFinanceAdd.Enabled = True
            End If
            If lvwFinance.SelectedItems.Count = 1 Then
                If CurUser.FinanceDelete = True Then
                    btnFinanceDelete.Enabled = True
                End If
                If CurStatus.ClientID > 0 Then
                    If lvwFinance.SelectedItems(0).SubItems(9).Text = lanStrings.strNo Then
                        btnFinancePay.Enabled = True
                    End If
                End If
            End If
        End If

        If tabTrackManager.SelectedTab.Name = tpgTracks.Name Then
            mnuMainEditDay.Enabled = True 'If tracks Is selected, enable (de)block the day
            If CurStatus.TrackID > 0 Then 'If a track is selected, enable (de)block the track
                mnuMainEditTrack.Enabled = True
            End If
            If CurApp.Day.Hour > 0 Or CurApp.Day.Minute > 0 Then 'If a time is selected, enable (de)block the time
                mnuMainEditHour.Enabled = True
            End If
        End If

        If CurApp.Clients.Count > 0 Then 'Check if clients are in the list
            btnAppClear.Enabled = True 'Enable the Clear button
            For Each clnClient In CurApp.Clients
                If clnClient.Checked = True Then
                    intClientsChecked += 1 'check if clients are checked
                    If dblClientId = 0 Then dblClientId = clnClient.ID 'If there is no currect client, select the first client checked.
                End If
            Next
        Else 'If there are no clients in the list, we are done
            Exit Sub
        End If

        If intClientsChecked > 0 Then 'Check if a minimum of 1 client is checked
            btnAppRemove.Enabled = True 'enable remove of the client
        Else 'If no client is checked, we are done
            Exit Sub
        End If
        If tabTrackManager.SelectedTab.Name <> tpgTracks.Name Then Exit Sub 'If tracks is not selected, we are done

        ' Check to see if Source and Target are the same Track and Time
        'If CurApp.DayPrev = CurApp.Day And CurApp.TrackIdPrev = CurApp.TrackId Then blnSameTarget = True

        If txtAppDetailsTime.Tag > 0 Then 'Check if time and track are selected
            Dim tbaButtons As TrackBoxArray = Nothing
            Select Case txtAppDetailsTime.Tag.ToString.Substring(0, 1)
                Case 1
                    tbaButtons = BarBoxArray
                    strBoxArray = "BarBoxArray"
                    intMaxApps = CurVar.BarsPerTrack
                    strButton = lanStrings.strBar
                Case 3
                    tbaButtons = ClientBoxArray
                    strBoxArray = "ClientBoxArray"
                    intMaxApps = CurVar.ClientsPerTrack
                    strButton = lanStrings.strClient
                Case 4
                    tbaButtons = TeacherBoxArray
                    strBoxArray = "TeacherBoxArray"
                    intMaxApps = CurVar.TeachersPerTrack
                    strButton = lanStrings.strTeacher
            End Select
            ' intIndex = 301011015
            '  3 = ClientBox (1 = BarBox; 4 = TeacherBox)
            ' 01 = TrackId
            ' 01 = ColId
            ' 10 = Hour
            ' 15 = Minute
            If CurApp.Name = strBoxArray Then blnSameBoxArray = True

            For Each Trackbox In tbaButtons
                'Check to see if you have the clicked Track and Time
                If Trackbox.IndexNumber.ToString.Substring(1, 2) = txtAppDetailsTime.Tag.ToString.Substring(1, 2) And Trackbox.IndexNumber.ToString.Substring(5, 4) = txtAppDetailsTime.Tag.ToString.Substring(5, 4) Then
                    If Trackbox.ClientId > 0 Then 'See if the Track and Time have appointments (Clients)
                        intClientsFound += 1 'Count the Clients
                        If Trackbox.IndexNumber.ToString.Substring(3, 2) = txtAppDetailsTime.Tag.ToString.Substring(3, 2) Then 'Check if clicked box is free
                            blnTargetFree = False
                        End If
                        For Each cltClient In CurApp.Clients
                            If cltClient.Checked = True Then 'Check if the Clients are checked
                                If Trackbox.ClientId = cltClient.ID Then 'check if the Checked Client(s) exist on the Target Track and Time
                                    btnAppDelete.Enabled = True And CurApp.Name <> "" 'If 1 or more Clients exist enable Delete
                                    blnClientFound = True
                                End If
                            End If
                        Next
                    End If
                End If
            Next

            If intClientsFound + intClientsChecked <= intMaxApps Then
                btnAppCreate.Enabled = True
                If blnClientFound = False Then
                    btnAppCreate.Text = strButton & ": " & btnAppCreate.Tag
                    If blnSameBoxArray = True Then 'Check to see if we have stayed on the same BoxArray
                        btnAppMove.Enabled = True
                    End If
                Else
                    btnAppCreate.Text = "! " & strButton & ": " & btnAppCreate.Tag & " !"
                    If blnSameBoxArray = True And blnTargetFree = True Then 'Check to see if we have stayed on the same BoxArray and the target Box is free
                        btnAppMove.Enabled = True
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub AppointmentClear()
        CurApp.Clients.Clear()
        CurApp.TrackIdPrev = 0
        CurApp.Name = ""
        CurApp.DayPrev = Today
        AppointmentClientsShow()
        ButtonsHandle()
    End Sub

    Private Sub AppUnDelete()
        Dim intClientCount As Integer = 0
        Dim strTrackBoxIndex As String = Nothing

        Dim strType As String = UndoApp.Name.Replace("BoxArray", "")
        strType = strType.Replace("Client", "Track")

        For Each inputClient In UndoApp.Clients
            If inputClient.Checked Then
                AppointmentUnDelete(UndoApp.Day, strType, inputClient.ID, UndoApp.TrackId, UndoApp.TrackIndex, inputClient.LessonTypeID, inputClient.LevelID, inputClient.LessonCount, inputClient.ExtraCount)
                inputClient.LessonCount += 1
                intClientCount += 1
            End If
        Next
        If intClientCount > 0 Then
            Select Case UndoApp.Name.Replace("BoxArray", "")
                Case "Bar"
                    strTrackBoxIndex = 1
                Case "Client"
                    strTrackBoxIndex = 3
                Case "Teacher"
                    strTrackBoxIndex = 4
            End Select
            strTrackBoxIndex &= UndoApp.TrackId.ToString("00")
            strTrackBoxIndex &= UndoApp.TrackIndex.ToString("00")
            strTrackBoxIndex &= UndoApp.Day.Hour.ToString("00")
            strTrackBoxIndex &= UndoApp.Day.Minute.ToString("00")

            CurStatus.RefreshClient = True
            CurApp.Name = UndoApp.Name
            CurApp.Day = UndoApp.Day
            txtAppDetailsTime.Tag = strTrackBoxIndex
            AppointmentClientsShow()
            DayClear()
            DayLoad()
            ButtonsHandle()
            SetStatus(intClientCount & "x " & lanStrings.strClient & " restored")
        End If
    End Sub

    Private Sub AppUnMove()
        Dim intClientCount As Integer = 0
        Dim intClientChecked As Integer = CheckedClientCount(UndoApp)
        Dim strType As String = UndoApp.Name.Replace("BoxArray", "")
        strType = strType.Replace("Client", "Track")

        For Each undoClient In UndoApp.Clients
            If UndoApp.Day = UndoApp.DayPrev And UndoApp.TrackId = UndoApp.TrackIdPrev Then
                If undoClient.ID = CurStatus.ClientID Then
                    AppointmentMove(UndoApp.DayPrev, UndoApp.Day, strType, undoClient.ID, UndoApp.TrackIdPrev, UndoApp.TrackId, undoClient.TrackIndex, UndoApp.TrackIndex, undoClient.LessonTypeID, undoClient.LevelID, undoClient.LessonCount, undoClient.ExtraCount, CurUser.LoginID)
                    'only 1 move allowed within slot
                    intClientCount += 1
                    For Each cltClient In CurApp.Clients
                        If cltClient.id = undoClient.id Then
                            cltClient.TrackIndex = undoClient.TrackIndex
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Else
                If undoClient.Checked Then
                    If intClientChecked = 1 Then
                        AppointmentMove(UndoApp.DayPrev, UndoApp.Day, strType, undoClient.ID, UndoApp.TrackIdPrev, UndoApp.TrackId, undoClient.TrackIndex, UndoApp.TrackIndexPrev, undoClient.LessonTypeID, undoClient.LevelID, undoClient.LessonCount, undoClient.ExtraCount, CurUser.LoginID)
                        For Each cltClient In CurApp.Clients
                            If cltClient.id = undoClient.id Then
                                cltClient.TrackIndex = undoClient.TrackIndex
                                Exit For
                            End If
                        Next
                    Else
                        AppointmentMove(UndoApp.DayPrev, UndoApp.Day, strType, undoClient.ID, UndoApp.TrackIdPrev, UndoApp.TrackId, undoClient.TrackIndex, undoClient.TrackIndex, undoClient.LessonTypeID, undoClient.LevelID, undoClient.LessonCount, undoClient.ExtraCount, CurUser.LoginID)
                        For Each cltClient In CurApp.Clients
                            If cltClient.id = undoClient.id Then
                                cltClient.TrackIndex = undoClient.TrackIndex
                                Exit For
                            End If
                        Next
                    End If

                    intClientCount += 1
                End If
            End If
        Next
        If intClientCount > 0 Then
            CurApp.Day = UndoApp.Day
            CurApp.DayPrev = UndoApp.DayPrev
            CurApp.TrackId = UndoApp.TrackId
            CurApp.TrackIdPrev = UndoApp.TrackIdPrev
            DayClear()
            DayLoad()
            ButtonsHandle()
            SetStatus(intClientCount & "x " & lanStrings.strClient & " restored")
        End If
    End Sub
#End Region

#Region "Date"
    Private Sub calTrackMan_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles calTrackMan.DateChanged
        DateChanged()
    End Sub

    Private Sub btnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToday.Click
        calTrackMan.SelectionStart = Today
    End Sub

    Private Sub btnNextDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextDay.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddDays(1)
    End Sub

    Private Sub btnNextWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextWeek.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddDays(7)
    End Sub

    Private Sub btnNextMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextMonth.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddMonths(1)
    End Sub

    Private Sub btnPrevDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevDay.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddDays(-1)
    End Sub

    Private Sub btnPrevWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevWeek.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddDays(-7)
    End Sub

    Private Sub btnPrevMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevMonth.Click
        calTrackMan.SelectionStart = calTrackMan.SelectionStart.AddMonths(-1)
    End Sub

    Private Sub DateChanged()
        lblDate.Text = calTrackMan.SelectionStart.Date.ToLongDateString
        txtAppDetailsDate.Text = calTrackMan.SelectionStart.Date.ToShortDateString
        'CurApp.DayPrev = CurApp.Day
        CurApp.Day = calTrackMan.SelectionStart.AddMinutes((CurApp.Day.Hour * 60) + CurApp.Day.Minute)
        If calTrackMan.SelectionStart < CurVar.SeasonStart Or calTrackMan.SelectionStart > CurVar.SeasonEnd Then
            SetSeasonDates(calTrackMan.SelectionStart)
        End If
        WriteLog("Date Changed to: " & calTrackMan.SelectionStart, 4)
        DayLoad()
        ButtonsHandle()
        MemoLoad()
        SetStatus()
    End Sub
#End Region

#Region "Memo"
    Private Sub txtMemo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemo.TextChanged
        If (tabTrackManager.SelectedTab.Name Is tpgGroups.Name Or tabTrackManager.SelectedTab.Name Is tpgFinance.Name) And CurStatus.GroupID = 0 Then
            Exit Sub
        ElseIf (tabTrackManager.SelectedTab.Name Is tpgReports.Name) And CurStatus.ClientID = 0 Then
            Exit Sub
        End If
        btnMemoSave.Enabled = True
    End Sub

    Private Sub btnMemoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemoSave.Click
        MemoSave()
    End Sub

    Private Sub MemoSave()
        'Save Memo
        If tabTrackManager.SelectedTab.Name Is tpgTracks.Name Then
            'use date and track to save the memo
            MemosHandle("Smt", txtMemo.Tag, "Track", Nothing, calTrackMan.SelectionStart, txtMemo.Text)
        ElseIf tabTrackManager.SelectedTab.Name Is tpgGroups.Name Or tabTrackManager.SelectedTab.Name Is tpgFinance.Name Then
            'use groupid to save the memo
            MemosHandle("Smt", txtMemo.Tag, "Group", CurStatus.GroupID, calTrackMan.SelectionStart, txtMemo.Text)
        ElseIf tabTrackManager.SelectedTab.Name Is tpgReports.Name Then
            'use ClientID to save the memo
            MemosHandle("Smt", txtMemo.Tag, "Client", CurStatus.ClientID, calTrackMan.SelectionStart, txtMemo.Text)
        End If
        btnMemoSave.Enabled = False
    End Sub

    Private Sub MemoLoad()
        txtMemo.Text = ""
        Dim objData As DataSet = Nothing
        If tabTrackManager.SelectedTab.Name Is tpgTracks.Name Then
            'use date and track to load the memo
            objData = MemosHandle("Get", 0, "Track", 0, calTrackMan.SelectionStart, Nothing)
        ElseIf tabTrackManager.SelectedTab.Name Is tpgGroups.Name Or tabTrackManager.SelectedTab.Name Is tpgFinance.Name Then
            'use groupid and group to load the memo
            objData = MemosHandle("Get", 0, "Group", CurStatus.GroupID, calTrackMan.SelectionStart, Nothing)
        ElseIf tabTrackManager.SelectedTab.Name Is tpgReports.Name Then
            'use ClientID to load memo
            objData = MemosHandle("Get", 0, "Client", CurStatus.ClientID, calTrackMan.SelectionStart, Nothing)
        End If
        If objData Is Nothing Then Exit Sub
        'nothing to process...
        If objData.Tables.Count = 0 Then Exit Sub

        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                txtMemo.Text = objData.Tables.Item(0).Rows(intRowCount).Item("MemoText")
            End If
        Next

        btnMemoSave.Enabled = False

    End Sub

#End Region

#Region "TracksTab"

    Friend Sub BoxClickHandler(ByVal intTag As Integer, ByVal intIndex As Integer, ByVal dblClientID As Integer, ByVal dblGroupId As Double, ByVal intLessonTypeId As Integer, ByVal intLevelId As Integer, ByVal strCollection As String, ByVal strBackColor As String, ByVal strForeColor As String, ByVal intLessonCount As Integer, ByVal intExtraCount As Integer)
        ' intIndex = 301011015
        '  3 = ClientBox
        ' 01 = TrackId
        ' 01 = ColId
        ' 10 = Hour
        ' 15 = Minute

        'If DebugMode Then
        '    MessageBox.Show("intTag = " & intTag & vbCrLf & _
        '    "intIndex =  " & intIndex & vbCrLf & _
        '    "dblClientId =  " & dblClientID & vbCrLf & _
        '    "dblGroupId = " & dblGroupId & vbCrLf & _
        '    "strCollection =  " & strCollection & vbCrLf & _
        '    "strBackColor = " & strBackColor & vbCrLf & _
        '    "strForeColor = " & strForeColor & vbCrLf & _
        '    "intLessonCount = " & intLessonCount)

        '    MessageBox.Show("LockDay = " & mnuMainEditDay.Tag & vbCrLf & _
        '     "locktrack = " & mnuMainEditTrack.Tag & vbCrLf & _
        '     "LockHour = " & mnuMainEditHour.Tag)
        'End If

        CurApp.TrackIndex = Int(intIndex.ToString.Substring(3, 2))
        If txtAppDetailsTime.Tag <> intIndex Then
            If CurStatus.TrackID <> Int(intIndex.ToString.Substring(1, 2)) Then
                CurStatus.TrackID = Int(intIndex.ToString.Substring(1, 2))
                CurApp.TrackId = CurStatus.TrackID
                txtAppDetailsTrack.Text = TrackNameGet(CurStatus.TrackID)
            End If
            If CurApp.Day <> calTrackMan.SelectionStart.AddMinutes((intIndex.ToString.Substring(5, 2) * 60) + intIndex.ToString.Substring(7, 2)) Then
                CurApp.Day = calTrackMan.SelectionStart.AddMinutes((intIndex.ToString.Substring(5, 2) * 60) + intIndex.ToString.Substring(7, 2))
                txtAppDetailsTime.Text = Format(CurApp.Day.Hour, "00") & ":" & Format(CurApp.Day.Minute, "00")
            End If
            txtAppDetailsTime.Tag = intIndex
        Else

        End If

        If dblClientID > 0 Then
            If CurApp.TrackId <> CurApp.TrackIdPrev Or CurApp.Day <> CurApp.DayPrev = True Then
                AppointmentClear()
            End If
            If CurStatus.ClientID <> dblClientID Then CurStatus.RefreshClient = True
            CurStatus.ClientID = dblClientID
            If CurStatus.GroupID = dblGroupId Then CurStatus.RefreshGroup = True
            CurStatus.GroupID = dblGroupId
            ShowCurStat()
            Dim AppClient As Client = AppClientCheck(dblClientID)
            If AppClient Is Nothing Then
                Dim intClientIndex As Double = AppClientAdd(dblClientID)
                CurApp.Clients(intClientIndex).Name = txtCurrentSelectionClient.Text
                CurApp.Clients(intClientIndex).ID = dblClientID
                CurApp.Clients(intClientIndex).Checked = True
                CurApp.Clients(intClientIndex).GroupID = dblGroupId
                CurApp.Clients(intClientIndex).LessonTypeID = intLessonTypeId
                CurApp.Clients(intClientIndex).LessonTypeName = LessonTypeNameGet(intLessonTypeId)
                CurApp.Clients(intClientIndex).LevelID = intLevelId
                CurApp.Clients(intClientIndex).LevelName = LevelNameGet(intLevelId)
                CurApp.Clients(intClientIndex).LessonCount = intLessonCount
                CurApp.Clients(intClientIndex).ExtraCount = intExtraCount
                CurApp.Clients(intClientIndex).TrackIndex = Int(intIndex.ToString.Substring(3, 2))
                CurApp.DayPrev = CurApp.Day
                CurApp.TrackIdPrev = CurApp.TrackId
                CurApp.TrackIndexPrev = CurApp.TrackIndex
            Else
                AppClient.Checked = True
                AppClient.LessonTypeID = intLessonTypeId
                AppClient.LessonTypeName = LessonTypeNameGet(intLessonTypeId)
                AppClient.LevelID = intLevelId
                AppClient.LevelName = LevelNameGet(intLevelId)
                AppClient.LessonCount = intLessonCount
                AppClient.ExtraCount = intExtraCount
                AppClient.TrackIndex = Int(intIndex.ToString.Substring(3, 2))
                CurApp.DayPrev = CurApp.Day
                CurApp.TrackIdPrev = CurApp.TrackId
                CurApp.TrackIndexPrev = CurApp.TrackIndex
            End If
            'Else
            '	If blnTrackChanged = True Or blnTimeChanged = True Then

            '	End If
        End If
        CurApp.Name = strCollection

        AppointmentClientsShow()
        ButtonsHandle()
        BoxGroupShow(dblGroupId)
        SetStatus()
    End Sub

    Friend Sub BoxDoubleClickHandler(ByVal intTag As String, ByVal intIndex As Integer, ByVal dblClientId As Double, dblGroupId As Double, intLessonTypeId As Integer, intLevelId As Integer, ByVal strCollection As String, ByVal clrBackColor As System.Drawing.Color, ByVal clrForeColor As System.Drawing.Color, intLessonCount As Integer, intExtraCount As Integer)
        'If DebugMode Then
        '    MessageBox.Show("DoubleClick detected" & vbCrLf _
        '                    & "intTag = " & intTag & vbCrLf _
        '                    & "intIndex = " & intIndex & vbCrLf _
        '                    & "dblClientID = " & dblClientID & vbCrLf _
        '                    & "dblGroupId" & dblGroupId & vbCrLf _
        '                    & "intLessonTypeId" & intLessonTypeId & vbCrLf _
        '                    & "intLevelId" & intLevelId & vbCrLf _
        '                    & "strCollection" & strCollection & vbCrLf _
        '                    & "clrBackColor = " & clrBackColor.ToString & vbCrLf _
        '                    & "clrForeColor = " & clrForeColor.ToString & vbCrLf _
        '                    & "intLessonCount = " & intLessonCount & vbCrLf _
        '                    & "intExtraCount = " & intExtraCount)
        'End If

        If dblClientID > 0 Then
            If CurApp.TrackId <> CurApp.TrackIdPrev Or CurApp.Day <> CurApp.DayPrev = True Then
                AppointmentClear()
            End If
            If CurStatus.ClientID <> dblClientID Then CurStatus.RefreshClient = True
            CurStatus.ClientID = dblClientID
            If CurStatus.GroupID = dblGroupId Then CurStatus.RefreshGroup = True
            CurStatus.GroupID = dblGroupId
            ShowCurStat()

            Dim AppClient As Client = AppClientCheck(dblClientId)
            If AppClient Is Nothing Then
                Dim intClientIndex As Double = AppClientAdd(dblClientId)
                CurApp.Clients(intClientIndex).Name = txtCurrentSelectionClient.Text
                CurApp.Clients(intClientIndex).ID = dblClientId
                CurApp.Clients(intClientIndex).Checked = True
                CurApp.Clients(intClientIndex).GroupID = dblGroupId
                CurApp.Clients(intClientIndex).LessonTypeID = intLessonTypeId
                CurApp.Clients(intClientIndex).LessonTypeName = LessonTypeNameGet(intLessonTypeId)
                CurApp.Clients(intClientIndex).LevelID = intLevelId
                CurApp.Clients(intClientIndex).LevelName = LevelNameGet(intLevelId)
                CurApp.Clients(intClientIndex).LessonCount = intLessonCount
                CurApp.Clients(intClientIndex).ExtraCount = intExtraCount
                CurApp.Clients(intClientIndex).TrackIndex = Int(intIndex.ToString.Substring(3, 2))
                CurApp.DayPrev = CurApp.Day
                CurApp.TrackIdPrev = CurApp.TrackId
                CurApp.TrackIndexPrev = CurApp.TrackIndex
            Else
                AppClient.LessonTypeID = intLessonTypeId
                AppClient.LessonTypeName = LessonTypeNameGet(intLessonTypeId)
                AppClient.LevelID = intLevelId
                AppClient.LevelName = LevelNameGet(intLevelId)
                AppClient.LessonCount = intLessonCount
                AppClient.ExtraCount = intExtraCount
                AppClient.TrackIndex = Int(intIndex.ToString.Substring(3, 2))
            End If
            'Else
            '	If blnTrackChanged = True Or blnTimeChanged = True Then

            '	End If
        End If
        CurApp.Name = strCollection

        If strCollection = "ClientBoxArray" And dblClientId > 0 Then
            ShowAppointmentForm()
        End If

    End Sub

    Private Sub BoxGroupShow(ByVal dblGroupId As Double)
        If dblGroupId = 0 Then
            For Each TrackBox In ClientBoxArray
                TrackBox.BorderStyle = BorderStyle.FixedSingle
            Next
        Else
            For Each TrackBox In ClientBoxArray
                If TrackBox.GroupId = dblGroupId Then
                    TrackBox.BorderStyle = BorderStyle.Fixed3D
                Else
                    TrackBox.BorderStyle = BorderStyle.FixedSingle
                End If
            Next
        End If

    End Sub

    Private Sub DayClear()
        mnuMainEditDay.Tag = 0
        mnuMainEditTrack.Tag = 0
        mnuMainEditHour.Tag = 0

        If ClientBoxArray.Count < 2 Then Exit Sub
        Dim dtmTime As DateTime
        For Each TrackBox In ClientBoxArray
            Try
                TrackBox.Text = ""
                TrackBox.AppointmentId = 0
                TrackBox.ClientId = 0
                TrackBox.GroupId = 0
                TrackBox.BorderStyle = BorderStyle.FixedSingle
                If Date.TryParse(TrackBox.IndexNumber.ToString.Substring(5, 2) & ":" & TrackBox.IndexNumber.ToString.Substring(7, 2), dtmTime) Then
                    TrackBox.BackColor = ChooseBackColor((dtmTime.Hour * 60) + dtmTime.Minute)
                End If
                TrackBox.ForeColor = System.Drawing.Color.Black
                TrackBox.LessonCount = 0
                TrackBox.ExtraCount = 0
                TrackBox.LessonTypeId = 0
                TrackBox.LevelId = 0
                TrackBox.Enabled = True
                Dim newSize As Single = TrackBox.Font.Size
                Dim newName As String = TrackBox.Font.Name
                Dim newFont As New Font(newName, newSize, FontStyle.Regular)
                TrackBox.Font = newFont
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        If CurVar.ShowTeacher = True Then
            For Each TrackBox In TeacherBoxArray
                TrackBox.Text = ""
                TrackBox.AppointmentId = 0
                TrackBox.ClientId = 0
                TrackBox.GroupId = 0
                If Date.TryParse(TrackBox.IndexNumber.ToString.Substring(5, 2) & ":" & TrackBox.IndexNumber.ToString.Substring(7, 2), dtmTime) Then
                    TrackBox.BackColor = ChooseBackColor((dtmTime.Hour * 60) + dtmTime.Minute)
                End If
                TrackBox.ForeColor = System.Drawing.Color.Black
                TrackBox.LessonCount = 0
                TrackBox.ExtraCount = 0
                TrackBox.LessonTypeId = 0
                TrackBox.LevelId = 0
                TrackBox.Enabled = True
            Next
        End If
        For Each TrackBox In BarBoxArray
            TrackBox.Text = ""
            TrackBox.AppointmentId = 0
            TrackBox.ClientId = 0
            TrackBox.GroupId = 0
            If Date.TryParse(TrackBox.IndexNumber.ToString.Substring(5, 2) & ":" & TrackBox.IndexNumber.ToString.Substring(7, 2), dtmTime) Then
                TrackBox.BackColor = ChooseBackColor((dtmTime.Hour * 60) + dtmTime.Minute)
            End If
            TrackBox.ForeColor = System.Drawing.Color.Black
            TrackBox.LessonCount = 0
            TrackBox.ExtraCount = 0
            TrackBox.LessonTypeId = 0
            TrackBox.LevelId = 0
            TrackBox.Enabled = True
        Next
        TimerReset()

        WriteLog("Day Cleared", 4)
    End Sub

    Private Sub DayLoad()
        DayClear()
        'Load appointments for the day
        Dim objData As DataSet = DayAppGet(calTrackMan.SelectionStart)
        If objData Is Nothing Then Exit Sub
        If objData.Tables.Count = 0 Then Exit Sub
        If objData.Tables(0).Rows.Count > 0 Then
            For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    Select Case objData.Tables.Item(0).Rows(intRowCount).Item("AppType")
                        Case "Bar"
                            AppointmentWrite(BarBoxArray, objData.Tables.Item(0).Rows(intRowCount))
                        Case "Track"
                            AppointmentWrite(ClientBoxArray, objData.Tables.Item(0).Rows(intRowCount))
                        Case "Lock"
                            AppointmentLock(ClientBoxArray, objData.Tables.Item(0).Rows(intRowCount))
                        Case "Teacher"
                            If CurVar.ShowTeacher Then
                                AppointmentWrite(TeacherBoxArray, objData.Tables.Item(0).Rows(intRowCount))
                            End If
                    End Select
                End If
            Next
        End If
    End Sub

    Private Sub AppointmentWrite(ByVal strArray As TrackBoxArray, ByVal objDataRow As DataRow)
        Dim strName As String
        Dim intStartTime As Integer

        strName = objDataRow.Item("FirstName")
        If Not objDataRow.Item("MiddleName").GetType().ToString = "System.DBNull" Then strName &= " " & objDataRow.Item("MiddleName")
        If Not objDataRow.Item("FamilyName").GetType().ToString = "System.DBNull" Then strName &= " " & objDataRow.Item("FamilyName")
        Dim dtmDate As DateTime = objDataRow.Item("AppDate")
        For Each TrackBox In strArray
            If Int(TrackBox.IndexNumber.ToString.Substring(1, 2)) = Int(objDataRow.Item("FK_TrackId")) Then
                intStartTime = Int(Format(dtmDate.Hour, "00") & Format(dtmDate.Minute, "00"))
                'If Int(TrackBox.indexnumber.ToString.Substring(5, 4)) = intStartTime Then
                If intStartTime >= Int(TrackBox.indexnumber.ToString.Substring(5, 4)) And intStartTime < (Int(TrackBox.indexnumber.ToString.Substring(5, 4)) + (CurVar.TimeFrame / 60 * 100)) Then
                    If TrackBox.clientid = 0 And (Int(TrackBox.indexnumber.ToString.Substring(3, 2)) = Int(objDataRow.Item("TrackIndex")) Or Int(objDataRow.Item("TrackIndex")) = 0) Then
                        'write appointment
                        TrackBox.AppointmentId = objDataRow.Item("PK_AppointmentId")
                        TrackBox.Text = strName
                        TrackBox.ClientId = objDataRow.Item("FK_ClientId")
                        If CurVar.UseFadingColors = True Then
                            TrackBox.BackColor = ColorBackSet(System.Drawing.Color.FromName(objDataRow.Item("LessonTypeColor")), objDataRow.Item("LessonCount") + objDataRow.Item("ExtraCount"))
                            TrackBox.ForeColor = ColorFrontSet(TrackBox.BackColor)
                        Else
                            If objDataRow.Item("LessonTypeColor").GetType().ToString = "System.DBNull" Then
                                'TrackBox.BackColor = System.Drawing.Color.FromName(objDataRow.Item("LessonTypeColor"))
                            Else
                                TrackBox.BackColor = System.Drawing.Color.FromName(objDataRow.Item("LessonTypeColor"))

                            End If

                            TrackBox.ForeColor = System.Drawing.Color.FromName(objDataRow.Item("LevelColor"))
                        End If
                        TrackBox.LessonCount = objDataRow.Item("LessonCount")
                        TrackBox.ExtraCount = objDataRow.Item("ExtraCount")
                        If objDataRow.Item("FK_LessonTypeId").GetType().ToString = "System.DBNull" Then
                            'TrackBox.LessonTypeId = objDataRow.Item("FK_LessonTypeId")
                        Else
                            TrackBox.LessonTypeId = objDataRow.Item("FK_LessonTypeId")
                        End If
                        TrackBox.LevelId = objDataRow.Item("FK_LevelId")
                        TrackBox.GroupId = objDataRow.Item("FK_GroupID")
                        If objDataRow.Item("Payed") = 0 Then
                            Dim newSize As Single = TrackBox.Font.Size
                            Dim newName As String = TrackBox.Font.Name
                            Dim newFont As New Font(newName, newSize, FontStyle.Underline)
                            TrackBox.Font = newFont
                        End If
                        TrackBox.Enabled = True
                        Exit For
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub AppointmentLock(ByVal strArray As TrackBoxArray, ByVal objDataRow As DataRow)
        Dim dtmDate As DateTime = objDataRow.Item("AppDate")
        Dim intStartTime As Integer

        If Int(objDataRow.Item("FK_TrackId")) = 0 And dtmDate.Hour = 0 And dtmDate.Minute = 0 Then
            'Lock Day
            mnuMainEditDay.Tag = objDataRow.Item("PK_AppointmentId")
        ElseIf Int(objDataRow.Item("FK_TrackId")) <> 0 And dtmDate.Hour = 0 And dtmDate.Minute = 0 Then
            'Lock track
            mnuMainEditTrack.Tag = objDataRow.Item("PK_AppointmentId")
        ElseIf Int(objDataRow.Item("FK_TrackId")) <> 0 And Not (dtmDate.Hour = 0 And dtmDate.Minute = 0) Then
            'Lock Hour
            mnuMainEditHour.Tag = objDataRow.Item("PK_AppointmentId")
        Else
            Exit Sub
        End If
        For Each TrackBox In strArray
            If Int(objDataRow.Item("FK_TrackId")) = 0 Then
                'Lock Day
                If TrackBox.clientid = 0 Then
                    'write appointment
                    TrackBox.Text = "<--->"
                    TrackBox.Enabled = False
                End If
            ElseIf dtmDate.Hour = 0 And dtmDate.Minute = 0 Then
                'Lock track
                If Int(TrackBox.IndexNumber.ToString.Substring(1, 2)) = Int(objDataRow.Item("FK_TrackId")) Then
                    If TrackBox.clientid = 0 Then
                        'write appointment
                        TrackBox.Text = "<--->"
                        TrackBox.Enabled = False
                    End If
                End If
            Else
                'Lock Hour
                If Int(TrackBox.IndexNumber.ToString.Substring(1, 2)) = Int(objDataRow.Item("FK_TrackId")) Then
                    intStartTime = Int(Format(dtmDate.Hour, "00") & Format(dtmDate.Minute, "00"))
                    'If Int(TrackBox.indexnumber.ToString.Substring(5, 4)) = intStartTime Then
                    If intStartTime >= Int(TrackBox.indexnumber.ToString.Substring(5, 4)) And intStartTime < (Int(TrackBox.indexnumber.ToString.Substring(5, 4)) + CurVar.TimeFrame) Then
                        If TrackBox.clientid = 0 Then
                            'write appointment
                            TrackBox.Text = "<--->"
                            TrackBox.Enabled = False
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub TimerReset()
        tmrRefresh.Stop()
        tmrRefresh.Enabled = False
        tmrRefresh.Enabled = True
        tmrRefresh.Start()
    End Sub

#End Region

#Region "GroupsTab"

    Private Sub btnGroupManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupManage.Click
        ShowGroupsForm()
    End Sub

    Private Sub btnGroupEditClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEditClient.Click
        ShowClientsForm()
    End Sub

    Private Sub btnGroupsMainContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupsMainContact.Click
        For intRowcount = 1 To GroupChkArray.Count
            If GroupChkArray.Item(intRowcount).Checked Then
                CurStatus.ClientID = GroupClientArray.Item(intRowcount).Tag
                PrimaryContactSet(CurStatus.GroupID, CurStatus.ClientID)
                Dim objData As DataSet = ClientsHandle("Get", 0, GroupClientArray.Item(intRowcount).Tag)
                For intRowcount1 = 0 To objData.Tables(0).Rows.Count - 1
                    If objData.Tables.Item(0).Rows(intRowcount1).Item(0).GetType().ToString = "System.DBNull" Then
                        'MessageBox.Show("Cell Must be empty")
                    Else
                        WriteMainContact(objData.Tables.Item(0).Rows(intRowcount1))
                    End If
                Next
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnGroupUpdateLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupUpdateLevel.Click
        For intRowcount = 1 To GroupChkArray.Count
            If GroupChkArray.Item(intRowcount).Checked Then
                If GroupLessonTypeArray.Item(intRowcount).SelectedIndex > -1 And GroupLevelArray.Item(intRowcount).SelectedIndex > -1 Then
                    CurStatus.ClientID = GroupClientArray.Item(intRowcount).Tag
                    Dim intLessonType As Integer = LessonTypeIdGet(GroupLessonTypeArray.Item(intRowcount).SelectedItem)
                    Dim intLevel As Integer = LevelIdGet(GroupLevelArray.Item(intRowcount).SelectedItem)
                    Dim intLessonCount As Integer = 0
                    If IsNumeric(GroupLessonCountArray.Item(intRowcount).Text) Then intLessonCount = GroupLessonCountArray.Item(intRowcount).Text
                    Dim intExtraCount As Integer = 0
                    If IsNumeric(GroupExtraCountArray.Item(intRowcount).Text) Then intExtraCount = GroupExtraCountArray.Item(intRowcount).Text
                    ClientLessonsHandle("Smt", 0, CurStatus.ClientID, 0, intLessonType, intLevel, intExtraCount, intLessonCount, True)
                Else
                    MessageBox.Show(lanStrings.strAllData)
                End If
            End If
        Next
        ShowCurStat()
    End Sub

    Private Sub btnGrpAppAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpAppAdd.Click
        Dim intClientIndexNumber As Double

        'Loop through all checkboxes
        For intRowcount = 1 To GroupChkArray.Count
            'Check to see if the box is checked
            If GroupChkArray.Item(intRowcount).Checked Then
                If GroupLevelArray.Item(intRowcount).SelectedIndex > -1 And (GroupLessonTypeArray.Item(intRowcount).SelectedIndex > -1 Or CurVar.RequireLessontype = False) Then
                    intClientIndexNumber = AppClientAdd(GroupClientArray(intRowcount).Tag)
                    CurStatus.ClientID = GroupClientArray.Item(intRowcount).Tag
                    Dim intLessonType As Integer = LessonTypeIdGet(GroupLessonTypeArray.Item(intRowcount).SelectedItem)
                    Dim intLevel As Integer = LevelIdGet(GroupLevelArray.Item(intRowcount).SelectedItem)
                    Dim intLessonCount As Integer = 0
                    If IsNumeric(GroupLessonCountArray.Item(intRowcount).Text) Then intLessonCount += GroupLessonCountArray.Item(intRowcount).Text
                    Dim intExtraCount As Integer = 0
                    If IsNumeric(GroupExtraCountArray.Item(intRowcount).Text) Then intExtraCount += GroupExtraCountArray.Item(intRowcount).Text

                    CurApp.Clients(intClientIndexNumber).Name = GroupClientArray.Item(intRowcount).Text
                    CurApp.Clients(intClientIndexNumber).ID = CurStatus.ClientID
                    CurApp.Clients(intClientIndexNumber).Checked = True
                    CurApp.Clients(intClientIndexNumber).GroupID = CurStatus.GroupID
                    CurApp.Clients(intClientIndexNumber).LessonTypeID = intLessonType
                    CurApp.Clients(intClientIndexNumber).LessonTypeName = GroupLessonTypeArray.Item(intRowcount).SelectedItem
                    CurApp.Clients(intClientIndexNumber).LevelID = intLevel
                    CurApp.Clients(intClientIndexNumber).LevelName = GroupLevelArray.Item(intRowcount).SelectedItem
                    CurApp.Clients(intClientIndexNumber).LessonCount = intLessonCount
                    CurApp.Clients(intClientIndexNumber).ExtraCount = intExtraCount
                    GroupChkArray.Item(intRowcount).Checked = False
                Else
                    MessageBox.Show(lanStrings.strAllData)
                End If
            End If
        Next
        AppointmentClientsShow()
        ShowCurStat()
        ButtonsHandle()
    End Sub

    Private Sub btnGrpAppRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpAppRemove.Click
        'Loop through all checkboxes
        For intRowcount = 1 To GroupChkArray.Count
            'Check to see if the box is checked
            If GroupChkArray.Item(intRowcount).Checked Then
                CurStatus.ClientID = GroupClientArray.Item(intRowcount).Tag
                AppClientRemove(CurStatus.ClientID)
            End If
        Next
        AppointmentClientsShow()
        ShowCurStat()
        ButtonsHandle()
    End Sub

    Private Sub chkGroupHeader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGroupHeader.CheckedChanged
        Dim blnSetting As Boolean = False
        If chkGroupHeader.Checked Then blnSetting = True
        For intRowcount = 1 To GroupChkArray.Count
            If GroupChkArray.Item(intRowcount).Enabled Then GroupChkArray.Item(intRowcount).Checked = blnSetting
        Next
    End Sub

    Private Sub lvwGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwGroups.SelectedIndexChanged
        If lvwGroups.SelectedItems.Count = 1 Then
            CurStatus.GroupID = lvwGroups.SelectedItems.Item(0).Tag
            'CurStatus.ClientID = 0
            'ClientsClear()
            ClientsGet()
            ShowCurStat()
        End If
        MemoLoad()
    End Sub

    Private Sub vsbTracks_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsbTracks.Scroll
        pnlTracks.Top = -vsbTracks.Value
    End Sub

    Private Sub vsbGroupClients_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsbGroupClients.Scroll
        grpGroupClients.Top = -vsbGroupClients.Value - 6
    End Sub

    Private Sub lvwGroups_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvwGroups.ColumnClick
        Dim clickedCol As ColHeader = CType(Me.lvwGroups.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvwGroups.Items.Count
        Me.lvwGroups.BeginUpdate()
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvwGroups.Items(i), e.Column))
        Next i
        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        Me.lvwGroups.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvwGroups.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        Me.lvwGroups.EndUpdate()
    End Sub

    Private Sub lvwFinanceGroups_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvwFinanceGroups.ColumnClick
        Dim clickedCol As ColHeader = CType(Me.lvwFinanceGroups.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvwFinanceGroups.Items.Count
        Me.lvwFinanceGroups.BeginUpdate()
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvwFinanceGroups.Items(i), e.Column))
        Next i
        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        Me.lvwFinanceGroups.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvwFinanceGroups.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        Me.lvwFinanceGroups.EndUpdate()
    End Sub

    Private Sub lvwFinanceClients_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvwFinanceClients.ColumnClick
        Dim clickedCol As ColHeader = CType(Me.lvwFinanceClients.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvwFinanceClients.Items.Count
        Me.lvwFinanceClients.BeginUpdate()
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvwFinanceClients.Items(i), e.Column))
        Next i

        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))
        Me.lvwFinanceClients.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvwFinanceClients.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        Me.lvwFinanceClients.EndUpdate()
    End Sub

    Private Sub lvwFinance_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) 'Handles lvwFinance.ColumnClick
        Dim clickedCol As ColHeader = CType(Me.lvwFinance.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvwFinance.Items.Count
        Me.lvwFinance.BeginUpdate()
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvwFinance.Items(i), e.Column))
        Next i
        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        Me.lvwFinance.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvwFinance.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        Me.lvwFinance.EndUpdate()
    End Sub

    Private Sub loadGroupItems()
        GroupsGet()
        ReportGroupSelectFill()
        ReportClientSelectFill()
        LevelsGet()
        LessonTypesGet()
        TracksGet()
    End Sub

    Private Sub GroupCheckChange()
        Dim blnChecked As Boolean = False
        For intRowcount = 1 To GroupChkArray.Count
            If GroupChkArray.Item(intRowcount).Checked Then
                blnChecked = True
            End If
        Next
        If blnChecked = True Then
            btnGroupUpdateLevel.Enabled = True
            btnGroupsMainContact.Enabled = True
            btnGrpAppAdd.Enabled = True
            btnGrpAppRemove.Enabled = True
        Else
            btnGroupUpdateLevel.Enabled = False
            btnGroupsMainContact.Enabled = False
            btnGrpAppAdd.Enabled = False
            btnGrpAppRemove.Enabled = False
        End If
    End Sub

    Private Sub GroupLessonTypeChange(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim intRow As Integer, strType As String
        intRow = sender.Tag
        strType = sender.Text
        CurStatus.ClientID = GroupClientArray.Item(intRow).Tag
        ShowCurStat()

        GroupExtraCountArray.Item(intRow).Text = ""
        GroupLevelArray.Item(intRow).SelectedItem = -1
        GroupLessonCountArray.Item(intRow).Text = ""

        Dim objData As DataSet = ClientLessonLevelGet2(CurStatus.ClientID, strType)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount").GetType().ToString = "System.DBNull" Then
                    GroupLessonCountArray.Item(intRow).Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                    'intBooked += objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                End If
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("ExtraCount").GetType().ToString = "System.DBNull" Then
                    GroupExtraCountArray.Item(intRow).Text = objData.Tables.Item(0).Rows(intRowCount).Item("ExtraCount")
                End If
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("LevelName").GetType().ToString = "System.DBNull" Then
                    GroupLevelArray.Item(intRow).SelectedItem = objData.Tables.Item(0).Rows(intRowCount).Item("LevelName")
                Else
                    GroupLevelArray.Item(intRow).SelectedItem = "Automatic"
                End If
            End If
        Next
        objData.Dispose()
        'MessageBox.Show("selection = " & intSelection)
    End Sub

    Private Sub GroupClientClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        CurStatus.ClientID = sender.Tag
        ShowCurStat()
    End Sub

    Private Sub ShowGroupsForm()
        Dim frmGroupsForm As New frmGroups
        frmGroupsForm.ShowDialog(Me)
    End Sub

    Private Sub ShowClientsForm()
        Dim frmClientsForm As New frmClients
        frmClientsForm.ShowDialog(Me)
    End Sub

    Private Sub GroupsGet()
        CurStatus.ReloadGroups = False
        lvwGroups.Items.Clear()
        lvwFinance.Items.Clear()
        Dim objData As DataSet = GroupsHandle("Get")
        If objData.Tables.Count = 0 Then Exit Sub
        lvwGroups.BeginUpdate()
        lvwFinance.BeginUpdate()
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("GroupName")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId"))
                lvwGroups.Items.Add(lsvItem)
                lvwFinanceGroups.Items.Add(lsvItem.Clone)
            End If
        Next
        lvwFinance.EndUpdate()
        lvwGroups.EndUpdate()
        PrimarySelect()
    End Sub

    Private Sub ReportGroupSelectFill()
        cbxRepGroup.Items.Clear()
        cbxRepGroup.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim lsvItem0 As New ListViewItem
        lsvItem0.Tag = 0
        lsvItem0.Text = chkRepLimitGroup.Text
        cbxRepGroup.Items.Add(lsvItem0)
        cbxRepGroup.Text = chkRepLimitGroup.Text

        Dim lsvItem1 As New ListViewItem
        lsvItem1.Tag = -1
        lsvItem1.Text = lanStrings.strAll
        cbxRepGroup.Items.Add(lsvItem1)

    End Sub

    Private Sub ReportClientSelectFill()
        cbxRepClient.Items.Clear()
        cbxRepClient.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim lsvItem0 As New ListViewItem
        lsvItem0.Tag = 0
        lsvItem0.Text = chkRepLimitClient.Text
        cbxRepClient.Items.Add(lsvItem0)
        cbxRepClient.Text = chkRepLimitClient.Text

        Dim lsvItem1 As New ListViewItem
        lsvItem1.Tag = -1
        lsvItem1.Text = lanStrings.strAll
        cbxRepClient.Items.Add(lsvItem1)

    End Sub

    Friend Sub GroupRemove(ByVal dblGroupID As Double)
        Try
            For intCount As Integer = 0 To lvwGroups.Items.Count - 1
                If lvwGroups.Items(intCount).Tag = dblGroupID Then
                    lvwGroups.Items(intCount).Remove()
                    Exit For
                End If
            Next
            For intCount As Integer = 0 To lvwFinanceGroups.Items.Count - 1
                If lvwFinanceGroups.Items(intCount).Tag = dblGroupID Then
                    lvwFinanceGroups.Items(intCount).Remove()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Friend Sub GroupAdd(ByVal dblGroupID As Double, ByVal strGroupName As String)
        Dim lsvItem As New ListViewItem
        lsvItem.Tag = dblGroupID
        lsvItem.Text = strGroupName
        lsvItem.SubItems.Add(dblGroupID)
        lvwGroups.Items.Add(lsvItem)
        lvwFinanceGroups.Items.Add(lsvItem.Clone)
    End Sub

    Friend Sub GroupUpdate(ByVal dblGroupID As Double, ByVal strGroupName As String)
        For intCount As Integer = 0 To lvwGroups.Items.Count - 1
            If lvwGroups.Items(intCount).Tag = dblGroupID Then
                lvwGroups.Items(intCount).Text = strGroupName
                Exit For
            End If
        Next
        For intCount As Integer = 0 To lvwFinanceGroups.Items.Count - 1
            If lvwFinanceGroups.Items(intCount).Tag = dblGroupID Then
                lvwFinanceGroups.Items(intCount).Text = strGroupName
                Exit For
            End If
        Next
    End Sub

    Private Sub ClientsGet()
        If CurStatus.GroupID > 0 Then
            Dim intBooked As Integer = 0
            Dim intBilled As Integer = 0
            Dim blnClientFound As Boolean = False
            Dim dblClientId As Double = 0

            ClientsClear()
            Dim objData As DataSet
            objData = ClientLessonLevelGet(0, CurStatus.GroupID)
            If Not objData Is Nothing Then

                If objData.Tables(0).Rows.Count > GroupChkArray.Count Then
                    Dim intStartpoint As Integer = GroupChkArray.Count
                    BuildGroupsTab(objData.Tables(0).Rows.Count)
                    LessonTypesGet(intStartpoint)
                    LevelsGet(intStartpoint)
                End If
                For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                    If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                        'MessageBox.Show("Cell Must be empty")
                    Else
                        'MessageBox.Show(objData.Tables.Item(0).Rows(intRowCount).Item("PrimaryType"))
                        If objData.Tables.Item(0).Rows(intRowCount).Item("PrimaryType") = True Or CurVar.ShowAllLessonTypes = True Then


                            GroupChkArray.Item(intRowCount + 1).Enabled = True
                            GroupClientArray.Item(intRowCount + 1).Enabled = True
                            GroupClientArray.Item(intRowCount + 1).ReadOnly = True
                            GroupLessonTypeArray.Item(intRowCount + 1).Enabled = True
                            GroupExtraCountArray.Item(intRowCount + 1).Enabled = True
                            GroupLevelArray.Item(intRowCount + 1).Enabled = True

                            GroupClientArray.Item(intRowCount + 1).Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                            If objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId") = CurStatus.ClientID Then blnClientFound = True

                            GroupClientArray.Item(intRowCount + 1).Text = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then
                                GroupClientArray.Item(intRowCount + 1).text &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then
                                GroupClientArray.Item(intRowCount + 1).text &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName").GetType().ToString = "System.DBNull" Then
                                Dim cbxControl As ComboBox = GroupLessonTypeArray.Item(intRowCount + 1)
                                RemoveHandler cbxControl.SelectedIndexChanged, AddressOf GroupLessonTypeChange
                                GroupLessonTypeArray.Item(intRowCount + 1).SelectedItem = objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName")
                                AddHandler cbxControl.SelectedIndexChanged, AddressOf GroupLessonTypeChange
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount").GetType().ToString = "System.DBNull" Then
                                GroupLessonCountArray.Item(intRowCount + 1).Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                                'intBooked += objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("ExtraCount").GetType().ToString = "System.DBNull" Then
                                GroupExtraCountArray.Item(intRowCount + 1).Text = objData.Tables.Item(0).Rows(intRowCount).Item("ExtraCount")
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("LevelName").GetType().ToString = "System.DBNull" Then
                                GroupLevelArray.Item(intRowCount + 1).SelectedItem = objData.Tables.Item(0).Rows(intRowCount).Item("LevelName")
                            Else
                                GroupLevelArray.Item(intRowCount + 1).SelectedItem = "Automatic"
                            End If
                            If objData.Tables.Item(0).Rows(intRowCount).Item("PrimaryContact") = True Then
                                WriteMainContact(objData.Tables.Item(0).Rows(intRowCount))
                                dblClientId = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                            End If
                            If Not objData.Tables.Item(0).Rows(intRowCount).Item("ivlCount").GetType().ToString = "System.DBNull" Then
                                intBilled += objData.Tables.Item(0).Rows(intRowCount).Item("ivlCount")
                            End If
                        End If
                        If Not objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount").GetType().ToString = "System.DBNull" Then
                            'GroupLessonCountArray.Item(intRowCount + 1).Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                            intBooked += objData.Tables.Item(0).Rows(intRowCount).Item("LessonCount")
                        End If

                        End If
                Next
                txtGroupLessonsTotal.Text = intBooked
                txtGroupLessonsBilled.Text = intBilled
                If intBooked > intBilled Then txtGroupLessonsBilled.BackColor = Color.LightCoral
                If blnClientFound = False Then CurStatus.ClientID = dblClientId
            End If
        End If
    End Sub

    Private Sub PrimarySelect()
        If CurStatus.GroupID > 0 Then
            Dim objData2 As DataSet = ClientsHandle("Pri", CurStatus.GroupID, CurStatus.ClientID)
            For intRowCount = 0 To objData2.Tables(0).Rows.Count - 1
                If objData2.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    CurStatus.ClientID = objData2.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                End If
            Next
        End If
    End Sub

    Private Sub GroupSelect(ByVal dblGroupId)
        If dblGroupId > 0 Then
            For Each item As ListViewItem In lvwGroups.Items
                item.Selected = (CDbl(item.Tag) = dblGroupId)
            Next
            If lvwGroups.SelectedItems.Count = 1 Then
                lvwGroups.TopItem = lvwGroups.SelectedItems.Item(0)
                lvwGroups.Select()
            End If
        End If
    End Sub

    Private Sub ClientsClear()
        'clear all client data fields
        For intRowCount = 1 To GroupChkArray.Count
            GroupChkArray.Item(intRowCount).Checked = False
            GroupClientArray.Item(intRowCount).Text = ""
            GroupLessonTypeArray.Item(intRowCount).SelectedIndex = -1
            GroupLessonCountArray.Item(intRowCount).Text = ""
            GroupExtraCountArray.Item(intRowCount).Text = ""
            GroupLevelArray.Item(intRowCount).SelectedIndex = -1

            GroupChkArray.Item(intRowCount).Enabled = False
            GroupLessonTypeArray.Item(intRowCount).Enabled = False
            GroupExtraCountArray.Item(intRowCount).Enabled = False
            GroupLevelArray.Item(intRowCount).Enabled = False

            txtMainContactName.Text = ""
            txtMainContactAddress.Text = ""
            txtMainContactCity.Text = ""
            txtMainContactEmail.Text = ""
            txtMainContactPhone.Text = ""
            txtMainContactMobile.Text = ""

            txtGroupLessonsTotal.Text = ""
            txtGroupLessonsBilled.Text = ""
            txtGroupLessonsBilled.BackColor = TextBox.DefaultBackColor

        Next
    End Sub

    Private Sub LevelsGet(Optional ByVal intRows As Integer = 1)
        Dim objData As DataSet
        objData = LevelsHandle("Get")
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = intRows To GroupLevelArray.Count
            For intLevelCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intLevelCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    GroupLevelArray.Item(intRowCount).Items.Add(objData.Tables.Item(0).Rows(intLevelCount).Item("LevelName"))
                End If
            Next intLevelCount
        Next intRowCount
    End Sub

    Private Sub LessonTypesGet(Optional ByVal intRows As Integer = 1)

        cbxRepLessonType.Items.Clear()
        cbxRepLessonType.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim lsvItem0 As New ListViewItem
        lsvItem0.Tag = 0
        lsvItem0.Text = chkRepLimitLessonType.Text
        cbxRepLessonType.Items.Add(lsvItem0)
        cbxRepLessonType.Text = chkRepLimitLessonType.Text

        Dim objData As DataSet = LessonTypesHandle("Get")
        If objData Is Nothing Then Exit Sub
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LessonTypeId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName")
                cbxRepLessonType.Items.Add(lsvItem)
            End If
        Next
        Dim lsvItem1 As New ListViewItem
        lsvItem1.Tag = -1
        lsvItem1.Text = lanStrings.strAll
        cbxRepLessonType.Items.Add(lsvItem1)

        'Dim objData As DataSet
        'objData = LessonTypesHandle("Get")
        'If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = intRows To GroupLessonTypeArray.Count
            For intTypeCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intTypeCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    GroupLessonTypeArray.Item(intRowCount).Items.Add(objData.Tables.Item(0).Rows(intTypeCount).Item("LessonTypeName"))
                End If
            Next intTypeCount
        Next intRowCount
    End Sub

    Private Sub ResizeTrackPanel()
        pnlTracks.Height = tabTracks.Height + tabTracks.Top + (2 * CurVar.BuildMargin)
        If pnlTracks.Height + pnlTracks.Top > tabTrackManager.Height - (2 * CurVar.BuildMargin) Then
            vsbTracks.Maximum = pnlTracks.Height
            vsbTracks.LargeChange = tabTrackManager.Height - (4 * CurVar.BuildMargin)
        End If
    End Sub

    Private Sub WriteMainContact(ByVal dtrInput As DataRow)
        txtMainContactName.Text = ""
        txtMainContactAddress.Text = ""
        txtMainContactCity.Text = ""
        txtMainContactEmail.Text = ""
        txtMainContactPhone.Text = ""
        txtMainContactMobile.Text = ""

        txtMainContactName.Text = dtrInput.Item("FirstName")
        If Not dtrInput.Item("MiddleName").GetType().ToString = "System.DBNull" Then txtMainContactName.Text &= " " & dtrInput.Item("MiddleName")
        If Not dtrInput.Item("FamilyName").GetType().ToString = "System.DBNull" Then txtMainContactName.Text &= " " & dtrInput.Item("FamilyName")
        If Not dtrInput.Item("Street").GetType().ToString = "System.DBNull" Then txtMainContactAddress.Text = dtrInput.Item("Street") & " " & dtrInput.Item("HouseNumber")
        If Not dtrInput.Item("PostalCode").GetType().ToString = "System.DBNull" Then txtMainContactCity.Text = dtrInput.Item("PostalCode") & " " & dtrInput.Item("City")
        If Not dtrInput.Item("Email").GetType().ToString = "System.DBNull" Then txtMainContactEmail.Text = dtrInput.Item("Email")
        If Not dtrInput.Item("Telephone").GetType().ToString = "System.DBNull" Then txtMainContactPhone.Text = dtrInput.Item("Telephone")
        If Not dtrInput.Item("Mobile").GetType().ToString = "System.DBNull" Then txtMainContactMobile.Text = dtrInput.Item("Mobile")
    End Sub

    Private Sub btnCorrectLessonCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrectLessonCount.Click
        Dim blnChanged As Boolean = False
        btnCorrectLessonCount.BackColor = Color.IndianRed
        Select Case cbxCorrectLessonCount.SelectedItem
            Case "All"
                CorrectLessonCount(CurVar.SeasonStart, CurVar.SeasonEnd, 0, 0)
                blnChanged = True
            Case "Group"
                CorrectLessonCount(CurVar.SeasonStart, CurVar.SeasonEnd, CurStatus.GroupID, 0)
                blnChanged = True
            Case "Client"
                CorrectLessonCount(CurVar.SeasonStart, CurVar.SeasonEnd, CurStatus.GroupID, CurStatus.ClientID)
                blnChanged = True
        End Select
        If blnChanged = True Then
            ClientsClear()
            ClientsGet()
            ShowCurStat()
        End If
        btnCorrectLessonCount.BackColor = Color.Transparent
    End Sub

    Private Sub txtGroupSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupSearch.TextChanged
        ' Call FindItemWithText with the contents of the textbox. 
        Dim foundItem As ListViewItem = _
            lvwGroups.FindItemWithText(txtGroupSearch.Text, False, 0, True)

        If (foundItem IsNot Nothing) Then
            lvwGroups.TopItem = foundItem
        End If

    End Sub

#End Region

#Region "FinanceTab"

    Private Sub btnFinanceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinanceAdd.Click
        Dim dtmDate As DateTime = Today
        If DebugMode Then
            dtmDate = calTrackMan.SelectionStart
        End If
        InvoiceNumberGet()
        FinancesHandle("Add", 0, CurVar.InvoiceName, FormatString(CurVar.InvoiceNumber, 3), 0, dtmDate, CurStatus.GroupID, CurStatus.ClientID, CurUser.LoginID, 0, lvwProduct.SelectedItems(0).Text, lvwProduct.SelectedItems(0).SubItems(1).Text, lvwProduct.SelectedItems(0).SubItems(2).Text, lvwProduct.SelectedItems(0).SubItems(3).Text)
        btnFinanceAdd.Enabled = False
        FinanceInvoicesGet()
        CurStatus.RefreshGroup = True
    End Sub

    'Private Sub lvwFinance_ColumnClick1(sender As Object, e As ColumnClickEventArgs) Handles lvwFinance.ColumnClick

    'End Sub

    Private Sub lvwFinance_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvwFinance.ColumnWidthChanged
        AlignFinanceTotals()
    End Sub

    Private Sub lvwFinanceGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFinanceGroups.SelectedIndexChanged
        If Not previouslvwFinanceGroups Is Nothing Then
            previouslvwFinanceGroups.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceGroups.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwFinanceGroups.SelectedItems.Count = 1 Then
            CurStatus.GroupID = lvwFinanceGroups.SelectedItems.Item(0).Tag
            'CurStatus.ClientID = 0
            FinanceClientsGet()
            'FinanceClientSelect(CurStatus.ClientID)
            ShowCurStat()
            FinanceInvoicesGet()
        End If
        MemoLoad()
        ButtonsHandle()
    End Sub

    Private Sub lvwFinanceGroups_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lvwFinanceGroups.Validating
        If lvwFinanceGroups.SelectedItems.Count = 1 Then
            lvwFinanceGroups.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceGroups.SelectedItems(0).ForeColor = Color.White
            previouslvwFinanceGroups = lvwFinanceGroups.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwFinanceClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFinanceClients.SelectedIndexChanged
        If Not previouslvwFinanceClients Is Nothing Then
            previouslvwFinanceClients.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceClients.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwFinanceClients.SelectedItems.Count = 1 Then
            CurStatus.ClientID = lvwFinanceClients.SelectedItems.Item(0).Tag
            ShowCurStat()
        End If
        ButtonsHandle()
    End Sub

    Private Sub lvwFinanceClients_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lvwFinanceClients.Validating
        If lvwFinanceClients.SelectedItems.Count = 1 Then
            lvwFinanceClients.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceClients.SelectedItems(0).ForeColor = Color.White
            previouslvwFinanceClients = lvwFinanceClients.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProduct.Click
        ButtonsHandle()
    End Sub

    Private Sub lvwProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwProduct.SelectedIndexChanged
        If Not previouslvwProduct Is Nothing Then
            previouslvwProduct.BackColor = CurVar.UnSelectedColor
            'previouslvwProduct.ForeColor = lvwAppClients.ForeColor
        End If

    End Sub

    Private Sub lvwProduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lvwProduct.Validating
        If lvwProduct.SelectedItems.Count = 1 Then
            lvwProduct.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwProduct.SelectedItems(0).ForeColor = Color.White
            previouslvwProduct = lvwProduct.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwFinance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwFinance.Click
        If lvwFinance.SelectedItems.Count = 1 Then
            CurStatus.InvoiceID = lvwFinance.SelectedItems.Item(0).Tag
        End If
        ButtonsHandle()
    End Sub

    Private Sub FinanceClientsGet()
        If CurStatus.GroupID > 0 Then
            Dim blnClientFound As Boolean = False
            Dim dblClientId As Double = 0

            lvwFinanceClients.Items.Clear()
            Dim objData As DataSet
            objData = ClientsHandle("Get", CurStatus.GroupID)
            For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    Dim lsvItem As New ListViewItem
                    lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                    If objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId") = CurStatus.ClientID Then blnClientFound = True
                    If objData.Tables.Item(0).Rows(intRowCount).Item("PrimaryContact") = True Then
                        dblClientID = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                    End If

                    lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then
                        lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName"))
                    Else
                        lsvItem.SubItems.Add("")
                    End If
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then
                        lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName"))
                    Else
                        lsvItem.SubItems.Add("")
                    End If
                    lvwFinanceClients.Items.Add(lsvItem)
                End If
            Next
            If blnClientFound = False Then CurStatus.ClientID = dblClientID
        End If

    End Sub

    Private Sub ProductsGet()
        lvwProduct.Items.Clear()
        Dim objData As DataSet
        objData = ProductsHandle("Get")
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ProductId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ProductText")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ProductCount"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ProductAmount"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Tax"))
                lvwProduct.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub FinanceGroupSelect(ByVal dblGroupId)
        If dblGroupId > 0 Then
            'If lvwFinanceGroups.SelectedItems.Count = 1 Then
            '	If lvwFinanceGroups.SelectedItems(0).Tag <> dblGroupId Or CurStatus.RefreshGroup = True Then
            '		For Each item As ListViewItem In lvwFinanceGroups.Items
            '			item.Selected = (CDbl(item.Tag) = dblGroupId)
            '		Next
            '		If lvwFinanceGroups.SelectedItems.Count = 1 Then
            '			lvwFinanceGroups.TopItem = lvwFinanceGroups.SelectedItems.Item(0)
            '			lvwFinanceGroups.Select()
            '		End If
            '		CurStatus.RefreshGroup = False
            '	End If
            'Else
            For Each item As ListViewItem In lvwFinanceGroups.Items
                item.Selected = (CDbl(item.Tag) = dblGroupId)
            Next
            If lvwFinanceGroups.SelectedItems.Count = 1 Then
                lvwFinanceGroups.TopItem = lvwFinanceGroups.SelectedItems.Item(0)
                lvwFinanceGroups.Select()
            End If
            CurStatus.RefreshGroup = False
            'End If
        End If
    End Sub

    Private Sub FinanceClientSelect(ByVal dblClientId As Double)
        If dblClientID > 0 Then
            For Each item As ListViewItem In lvwFinanceClients.Items
                item.Selected = (CDbl(item.Tag) = dblClientID)
            Next
            If lvwFinanceClients.SelectedItems.Count = 1 Then
                lvwFinanceClients.TopItem = lvwFinanceClients.SelectedItems.Item(0)
                lvwFinanceClients.Select()
            End If
        End If
    End Sub

    Private Sub FinanceInvoicesGet()
        lvwFinance.Items.Clear()
        txtFinancePayDue.Text = ""
        txtFinancePayCount.Text = ""
        txtFinancePayBilled.Text = ""
        txtFinancePayPayed.Text = ""

        If CurStatus.GroupID > 0 Then
            Dim intPayCount As Integer = 0
            Dim sinPayBilled As Single = 0
            Dim sinPayPayed As Single = 0
            Dim sinPayTotal As Single = 0

            Dim objData As DataSet = FinancesHandle("Get", 0, Nothing, Nothing, 0, Nothing, CurStatus.GroupID)
            For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    Dim lsvItem As New ListViewItem
                    lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_InvoiceId")
                    lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("InvoiceDate")

                    Dim strName As String = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then
                        strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
                    End If
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then
                        strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
                    End If
                    lsvItem.SubItems.Add(strName)
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("LoginName"))
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ilnDescription"))
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ilnCount"))
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ilnAmount"))
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ipyAmount"))
                    lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("opnAmount"))
                    Dim strPayed As String = lanStrings.strNo
                    If objData.Tables.Item(0).Rows(intRowCount).Item("Payed") = 1 Or objData.Tables.Item(0).Rows(intRowCount).Item("Payed") = "True" Then
                        strPayed = lanStrings.strYes
                    End If
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("ipyPayDate").GetType().ToString = "System.DBNull" Then
                        lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ipyPayDate"))
                    Else
                        lsvItem.SubItems.Add("")
                    End If
                    lsvItem.SubItems.Add(strPayed)
                    lvwFinance.Items.Add(lsvItem)
                    intPayCount += objData.Tables.Item(0).Rows(intRowCount).Item("ilnCount")
                    sinPayBilled += objData.Tables.Item(0).Rows(intRowCount).Item("ilnAmount")
                    sinPayPayed += objData.Tables.Item(0).Rows(intRowCount).Item("ipyAmount")

                End If
            Next
            txtFinancePayDue.Text = Format(sinPayBilled - sinPayPayed, "#.00")
            txtFinancePayCount.Text = intPayCount
            txtFinancePayBilled.Text = Format(sinPayBilled, "#.00")
            txtFinancePayPayed.Text = Format(sinPayPayed, "#.00")

        End If
    End Sub

    Private Sub btnFinancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinancePay.Click
        If lvwFinance.SelectedItems.Count = 1 Then
            If lvwFinance.SelectedItems(0).SubItems(5).Text - lvwFinance.SelectedItems(0).SubItems(6).Text <> 0 Then
                InvoicePaymentsHandle("Add", 0, lvwFinance.SelectedItems(0).Tag, Today, CurStatus.ClientID, CurUser.LoginID, lvwFinance.SelectedItems(0).SubItems(5).Text - lvwFinance.SelectedItems(0).SubItems(6).Text)
            End If
            InvoicesHandle("Pay", lvwFinance.SelectedItems(0).Tag, Nothing, Nothing, 0, 0, 1)
            FinanceInvoicesGet()
            ButtonsHandle()
        End If
    End Sub

    Private Sub btnFinanceDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinanceDelete.Click
        If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtsPayment As DataSet = InvoicePaymentsHandle("Get", 0, CurStatus.InvoiceID)
                If dtsPayment.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show(lanStrings.strInvoicePayment)
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            If CurVar.DeleteEmptyInvoice = True Then
                Try
                    Dim objData As DataSet = InvoiceLinesHandle("Get", 0, CurStatus.InvoiceID)
                    If objData.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show(lanStrings.strInvoiceNotEmpty)
                        Exit Sub
                    Else
                        InvoicesHandle("Del", CurStatus.InvoiceID)
                    End If
                Catch ex As Exception
                    MessageBox.Show(lanStrings.strInvoiceNotEmpty)
                    Exit Sub
                End Try
            Else
                FinancesHandle("Del", CurStatus.InvoiceID)
            End If
            FinanceInvoicesGet()
        End If
        CurStatus.RefreshGroup = True
    End Sub

    Private Sub btnFinanceEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinanceEdit.Click
        ShowFinanceForm()
    End Sub

    Private Sub txtFinanceGroupSearch_TextChanged(sender As Object, e As EventArgs) Handles txtFinanceGroupSearch.TextChanged
        Dim foundItem As ListViewItem = lvwFinanceGroups.FindItemWithText(txtFinanceGroupSearch.Text, False, 0, True)
        If (foundItem IsNot Nothing) Then
            lvwFinanceGroups.TopItem = foundItem
        End If
    End Sub

#End Region

#Region "ReportsTab"

    Private Sub btnRep1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep1.Click
        CurStatus.ReportID = btnRep1.Tag
        CurStatus.ReportName = btnRep1.Text
        CreateStandardReport(CurStatus.ReportID)
    End Sub

    Private Sub btnRep2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep2.Click
        CurStatus.ReportID = btnRep2.Tag
        CurStatus.ReportName = btnRep2.Text
        CreateStandardReport(CurStatus.ReportID)
    End Sub

    Private Sub btnRep3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep3.Click
        CurStatus.ReportID = btnRep3.Tag
        CurStatus.ReportName = btnRep3.Text
        CreateStandardReport(CurStatus.ReportID)
    End Sub

    Private Sub btnRep4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep4.Click
        CurStatus.ReportID = btnRep4.Tag
        CurStatus.ReportName = btnRep4.Text
        CreateStandardReport(CurStatus.ReportID)
    End Sub

    Private Sub btnRep5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep5.Click
        CurStatus.ReportID = btnRep5.Tag
        CurStatus.ReportName = btnRep5.Text
        CreateStandardReport(CurStatus.ReportID)
    End Sub

    Private Sub cbxRepLessons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRepLessons.SelectedIndexChanged
        If cbxRepLessons.Focused = True Then
            If cbxRepLessons.SelectedIndex <> -1 Then
                cbxRepFinance.SelectedIndex = -1
                cbxRepClients.SelectedIndex = -1
                cbxRepOther.SelectedIndex = -1
                ReportGet((Val(DirectCast(cbxRepLessons.SelectedItem, ListViewItem).Tag)))
            End If
        End If
    End Sub

    Private Sub cbxRepFinance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRepFinance.SelectedIndexChanged
        If cbxRepFinance.Focused = True Then
            If cbxRepFinance.SelectedIndex <> -1 Then
                cbxRepLessons.SelectedIndex = -1
                cbxRepClients.SelectedIndex = -1
                cbxRepOther.SelectedIndex = -1
                ReportGet((Val(DirectCast(cbxRepFinance.SelectedItem, ListViewItem).Tag)))
            End If
        End If
    End Sub

    Private Sub cbxRepClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRepClients.SelectedIndexChanged
        If cbxRepClients.Focused = True Then
            If cbxRepClients.SelectedIndex <> -1 Then
                cbxRepFinance.SelectedIndex = -1
                cbxRepLessons.SelectedIndex = -1
                cbxRepOther.SelectedIndex = -1
                ReportGet((Val(DirectCast(cbxRepClients.SelectedItem, ListViewItem).Tag)))
            End If
        End If
    End Sub

    Private Sub cbxRepOther_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRepOther.SelectedIndexChanged
        If cbxRepOther.Focused = True Then
            If cbxRepOther.SelectedIndex <> -1 Then
                cbxRepLessons.SelectedIndex = -1
                cbxRepFinance.SelectedIndex = -1
                cbxRepClients.SelectedIndex = -1
                ReportGet((Val(DirectCast(cbxRepOther.SelectedItem, ListViewItem).Tag)))
            End If
        End If
    End Sub

    Private Sub btnRepReportCreate_Click(sender As Object, e As EventArgs) Handles btnRepReportCreate.Click
        If cbxRepFinance.SelectedIndex <> -1 Then
            CurStatus.ReportType = "Finance"
            CurStatus.ReportID = (Val(DirectCast(cbxRepFinance.SelectedItem, ListViewItem).Tag))
            CreateStandardReport(CurStatus.ReportID)
        End If
        If cbxRepLessons.SelectedIndex <> -1 Then
            CurStatus.ReportType = "Lessons"
            CurStatus.ReportID = (Val(DirectCast(cbxRepLessons.SelectedItem, ListViewItem).Tag))
            CreateStandardReport(CurStatus.ReportID)
        End If
        If cbxRepClients.SelectedIndex <> -1 Then
            CurStatus.ReportType = "Clients"
            CurStatus.ReportID = (Val(DirectCast(cbxRepClients.SelectedItem, ListViewItem).Tag))
            CreateStandardReport(CurStatus.ReportID)
        End If
        If cbxRepOther.SelectedIndex <> -1 Then
            CurStatus.ReportType = "Other"
            CurStatus.ReportID = (Val(DirectCast(cbxRepOther.SelectedItem, ListViewItem).Tag))
            CreateStandardReport(CurStatus.ReportID)
        End If
    End Sub

    Private Sub btnFav1_Click(sender As Object, e As EventArgs) Handles btnFav1.Click
        SetFavorite(btnRep1)
    End Sub

    Private Sub btnFav2_Click(sender As Object, e As EventArgs) Handles btnFav2.Click
        SetFavorite(btnRep2)
    End Sub

    Private Sub btnFav3_Click(sender As Object, e As EventArgs) Handles btnFav3.Click
        SetFavorite(btnRep3)
    End Sub

    Private Sub btnFav4_Click(sender As Object, e As EventArgs) Handles btnFav4.Click
        SetFavorite(btnRep4)
    End Sub

    Private Sub btnFav5_Click(sender As Object, e As EventArgs) Handles btnFav5.Click
        SetFavorite(btnRep5)
    End Sub

    Private Sub SetFavorite(btnFavorite As Button)
        If MessageBox.Show("This will set the report as a favorite under this button. Do you wish to continue?", lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            btnFavorite.Tag = CurStatus.ReportID
            btnFavorite.Text = Translate(CurVar.Language, "Reports", CurStatus.ReportName)
            'MessageBox.Show(btnFavorite.Name.Substring(btnFavorite.Name.Length - 1, 1))
            ReportsHandle("Sec", CurStatus.ReportID, Nothing, Nothing, Nothing, btnFavorite.Name.Substring(btnFavorite.Name.Length - 1, 1), Nothing, Nothing)
        End If
    End Sub

    Private Sub CreateStandardReport(ByVal intReportID As Integer)
        ReportCheck(intReportID)
        If CurStatus.ReportID = 0 Then Exit Sub
        CurStatus.ReportWidth = 0

        Dim dtmDateStart As DateTime = Nothing
        Dim dtmDateStop As DateTime = Nothing
        Dim dblClientId As Double = 0
        Dim dblGroupId As Double = 0
        Dim intTrackId As Integer = 0
        Dim intInvoiceId As Integer = 0
        Dim intLessonTypeId As Integer = 0
        Dim intLevelId As Integer = 0
        Dim strAppType As String = Nothing
        Dim strReportText As String = ""
        Dim strFieldName As String = Nothing
        Dim strFieldAlias As String = Nothing
        Dim strFieldType As String = Nothing
        Dim intFieldWidth As Integer = 0
        Dim sinIlnAmount As Single = 0
        Dim sinIpyAmount As Single = 0
        Dim sinOpnAmount As Single = 0
        Dim strTotalAmount1 As String = Nothing
        Dim strTotalAmount2 As String = Nothing
        Dim strTotalAmount3 As String = Nothing
        Dim strReportTitle As String = ""
        Dim strReportTitle2 As String = ""

        strReportTitle = lanStrings.strReport & " " & CurStatus.ReportName & ": "

        If rbnRepLimitSeason.Checked = True Then
            dtmDateStart = CurVar.SeasonStart
            dtmDateStop = CurVar.SeasonEnd
            strReportTitle &= rbnRepLimitSeason.Text
        ElseIf rbnRepLimitDay.Checked = True Then
            dtmDateStart = calTrackMan.SelectionStart
            strReportTitle &= rbnRepLimitDay.Text
        ElseIf rbnRepLimitWeek.Checked = True Then
            dtmDateStart = calTrackMan.SelectionStart
            dtmDateStop = calTrackMan.SelectionStart.AddDays(7)
            dtmDateStop = dtmDateStop.AddMinutes(-1)
            strReportTitle &= rbnRepLimitWeek.Text
        ElseIf rbnRepLimitMonth.Checked = True Then
            dtmDateStart = calTrackMan.SelectionStart
            dtmDateStop = calTrackMan.SelectionStart.AddMonths(1)
            dtmDateStop = dtmDateStop.AddMinutes(-1)
            strReportTitle &= rbnRepLimitMonth.Text
        End If

        If rbnRepLimitTypeClient.Checked = True Then
            strAppType = "Track"
            strReportTitle &= ", " & rbnRepLimitTypeClient.Text
        ElseIf rbnRepLimitTypeTeacher.Checked = True Then
            strAppType = "Teacher"
            strReportTitle &= ", " & rbnRepLimitTypeTeacher.Text
        ElseIf rbnRepLimitTypeBar.Checked = True Then
            strAppType = "Bar"
            strReportTitle &= ", " & rbnRepLimitTypeBar.Text
        End If

        If chkRepLimitLessonType.Checked = True Then
            intLessonTypeId = Val(DirectCast(cbxRepLessonType.SelectedItem, ListViewItem).Tag)
            strReportTitle2 = ", " & cbxRepLessonType.Text
        End If

        If chkRepLimitInvoice.Checked = True Then
            intInvoiceId = CurStatus.InvoiceID
            strReportTitle2 = ", " & chkRepLimitInvoice.Text
        End If

        If chkRepLimitTrack.Checked = True Then
            intTrackId = Val(DirectCast(cbxRepTrack.SelectedItem, ListViewItem).Tag)
            If intTrackId = 0 Then
                intTrackId = CurStatus.TrackID
                strReportTitle2 = ", " & txtAppDetailsTrack.Text
            Else
                strReportTitle2 = ", " & chkRepLimitTrack.Text & ": " & cbxRepTrack.Text
            End If
        End If

        If chkRepLimitGroup.Checked = True Then
            dblGroupId = Val(DirectCast(cbxRepGroup.SelectedItem, ListViewItem).Tag)
            If dblGroupId = 0 Then
                dblGroupId = CurStatus.GroupID
                strReportTitle2 = ", " & txtCurrentSelectionGroup.Text
            Else
                strReportTitle2 = ", " & chkRepLimitGroup.Text & ": " & cbxRepGroup.Text
            End If
        End If

        If chkRepLimitClient.Checked = True Then
            dblClientId = Val(DirectCast(cbxRepClient.SelectedItem, ListViewItem).Tag)
            If dblClientId = 0 Then
                dblClientId = CurStatus.ClientID
                strReportTitle2 = ", " & txtCurrentSelectionClient.Text
            Else
                strReportTitle2 = ", " & chkRepLimitClient.Text & ": " & cbxRepClient.Text
            End If
        End If

        If rbnRepLimitSeason.Checked = True And dblClientId = 0 And dblGroupId = 0 And CurStatus.ReportType <> "Season" Then
            If MessageBox.Show(lanStrings.strLongWait & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        rtbRepReportHeader.Text = strReportTitle & strReportTitle2

        dtsRepReport = Nothing
        dtsRepReport = ReportFieldsGet(CurStatus.ReportID)

        Dim objData As DataSet = ReportCreate(CurStatus.ReportID, dtmDateStart, dtmDateStop, dblClientId, dblGroupId, strAppType, intTrackId, intInvoiceId, intLessonTypeId, intLevelId)
        'Dim objDataFields As DataSet = ReportFieldsGet(strReport)

        'strReportText = strReport & vbCrLf
        'strReportText &= "Report created: " & Date.Now & vbTab & "By " & strLicenseName & vbCrLf
        'strReportText &= "" & vbCrLf

        dgvRepReport.Columns.Clear()

        If dtsRepReport.Tables(0).Rows.Count = 0 Then Exit Sub
        For intRowCount0 As Integer = 0 To dtsRepReport.Tables(0).Rows.Count - 1
            If dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldShow") = True Then
                    strFieldName = dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldName")
                    strFieldAlias = dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldAlias")
                    intFieldWidth = dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldWidth")
                    CurStatus.ReportWidth += intFieldWidth
                    strFieldType = dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldType")
                    'strReportText &= FormatLenght(strFieldAlias, intFieldWidth, "String") & vbTab
                    dgvRepReport.Columns.Add(strFieldName, strFieldAlias)
                    dgvRepReport.Columns.Item(dgvRepReport.Columns.Count - 1).Width = intFieldWidth * 8
                End If
            End If
        Next

        'strReportText &= vbCrLf
        If objData Is Nothing Then Exit Sub
        If objData.Tables.Count > 0 Then
            If objData.Tables(0).Rows.Count = 0 Then Exit Sub
            For intRowCount1 As Integer = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount1).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    'strReportText &= vbCrLf
                    Dim dgvRow As New DataGridViewRow
                    dgvRow.CreateCells(dgvRepReport)
                    For intRowCount2 As Integer = 0 To dtsRepReport.Tables(0).Rows.Count - 1
                        If dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item(0).GetType().ToString = "System.DBNull" Then
                            'MessageBox.Show("Cell Must be empty")
                        Else
                            Try
                                If dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldShow") = True Then
                                    strFieldName = dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldName")
                                    If strFieldName = "ilnAmount" Then
                                        sinIlnAmount += objData.Tables.Item(0).Rows(intRowCount1).Item(strFieldName)
                                        strTotalAmount1 = lanStrings.strTotal & " " & dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldAlias")
                                    End If
                                    If strFieldName = "ipyAmount" Then
                                        sinIpyAmount += objData.Tables.Item(0).Rows(intRowCount1).Item(strFieldName)
                                        strTotalAmount2 = lanStrings.strTotal & " " & dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldAlias")
                                    End If
                                    If strFieldName = "opnAmount" Then
                                        sinOpnAmount += objData.Tables.Item(0).Rows(intRowCount1).Item(strFieldName)
                                        strTotalAmount3 = lanStrings.strTotal & " " & dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldAlias")
                                    End If
                                    intFieldWidth = dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldWidth")
                                    strFieldType = dtsRepReport.Tables.Item(0).Rows(intRowCount2).Item("FieldType")
                                    'strReportText &= FormatLenght(objData.Tables.Item(0).Rows(intRowCount1).Item(strFieldName), intFieldWidth, strFieldType) & vbTab
                                    dgvRow.Cells.Item(dgvRepReport.Columns.Item(strFieldName).Index).Value = objData.Tables.Item(0).Rows(intRowCount1).Item(strFieldName)
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    dgvRepReport.Rows.Add(dgvRow)
                End If
            Next
        End If
        'rtbRepReports.Text &= vbCrLf

        If sinIlnAmount > 0 Or sinIpyAmount > 0 Or sinOpnAmount > 0 Then
            Dim dgvRow2 As New DataGridViewRow
            dgvRow2.CreateCells(dgvRepReport)
            dgvRow2.Cells.Item(dgvRepReport.Columns.Item(0).Index).Value = lanStrings.strTotal
            If sinIlnAmount > 0 Then
                strReportText &= strTotalAmount1 & ":    " & FormatMoney(sinIlnAmount) & vbCrLf
                '                dgvRow2.Cells.Item(dgvRepReport.Columns.Item("ilnAmount").Index).Value = Math.Round(sinIlnAmount, 2)
                dgvRow2.Cells.Item(dgvRepReport.Columns.Item("ilnAmount").Index).Value = FormatDecimalFromSingle(sinIlnAmount)
            End If
            If sinIpyAmount > 0 Then
                strReportText &= strTotalAmount2 & ":    " & FormatMoney(sinIpyAmount) & vbCrLf
                '               dgvRow2.Cells.Item(dgvRepReport.Columns.Item("ipyAmount").Index).Value = Math.Round(sinIpyAmount, 2)
                dgvRow2.Cells.Item(dgvRepReport.Columns.Item("ipyAmount").Index).Value = FormatDecimalFromSingle(sinIpyAmount)
            End If
            If sinOpnAmount > 0 Then
                strReportText &= strTotalAmount3 & ":    " & FormatMoney(sinOpnAmount)
                '              dgvRow2.Cells.Item(dgvRepReport.Columns.Item("opnAmount").Index).Value = Math.Round(sinOpnAmount, 2)
                dgvRow2.Cells.Item(dgvRepReport.Columns.Item("opnAmount").Index).Value = FormatDecimalFromSingle(sinOpnAmount)
            End If
            dgvRepReport.Rows.Add(dgvRow2)
        End If

        rtbRepReportFooter.Text = strReportText
    End Sub

    Private Sub chkRepLimitTrack_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepLimitTrack.CheckedChanged
        If chkRepLimitTrack.Checked = False Then cbxRepTrack.SelectedIndex = 0
    End Sub

    Private Sub chkRepLimitGroup_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepLimitGroup.CheckedChanged
        If chkRepLimitGroup.Checked = False Then cbxRepGroup.SelectedIndex = 0
    End Sub

    Private Sub chkRepLimitClient_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepLimitClient.CheckedChanged
        If chkRepLimitClient.Checked = False Then cbxRepClient.SelectedIndex = 0
    End Sub

    Private Sub chkRepLimitLessonType_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepLimitLessonType.CheckedChanged
        If chkRepLimitLessonType.Checked = False Then cbxRepLessonType.SelectedIndex = 0
    End Sub

    Private Sub chkRepReportWidth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepReportWidth.CheckedChanged
        If chkRepReportWidth.Checked = True Then
            trbRepReportWidth.Enabled = False
            trbRepReportWidth.Value = 6
            txtRepReportWidth.Text = ""
        Else
            trbRepReportWidth.Enabled = True
            txtRepReportWidth.Text = trbRepReportWidth.Value
        End If
    End Sub

    Private Sub trbRepReportWidth_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbRepReportWidth.Scroll
        txtRepReportWidth.Text = trbRepReportWidth.Value
    End Sub

    Private Sub tbnRepPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnRepPrint.Click
        tbnRepPrint.Enabled = False
        PrintReport(Me.dgvRepReport)
        tbnRepPrint.Enabled = True
    End Sub

    Private Sub PrintReport(dgvReport As DataGridView)
        Dim sinMultiply As Single

        Dim Printer = New DGVPrinter
        Printer.Title = rtbRepReportHeader.Text
        Printer.SubTitle = "Report " & CurStatus.ReportName & ", Startdate: " & calTrackMan.SelectionStart.Date.ToLongDateString
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.PorportionalColumns = True
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "Report created: " & Date.Now & vbTab & " By " & strLicenseName
        Printer.FooterSpacing = 15
        'Printer.PrintPreviewDataGridView(Me.dgvRepReport)

        Dim strReport As String = rtbRepReportFooter.Text
        dgvReport.Rows.Add(strReport)

        If chkRepReportWidth.Checked = True Then
            sinMultiply = 706.9 / CurStatus.ReportWidth
        Else
            sinMultiply = trbRepReportWidth.Value
        End If

        For intRowCount0 As Integer = 0 To dtsRepReport.Tables(0).Rows.Count - 1
            If dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else

                If dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldShow") = True Then
                    Printer.ColumnWidths.Add(dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldName"), dtsRepReport.Tables.Item(0).Rows(intRowCount0).Item("FieldWidth") * sinMultiply)
                    '    strFieldName = dtsRepReport1.Tables.Item(0).Rows(intRowCount0).Item("FieldName")
                    '    strFieldAlias = dtsRepReport1.Tables.Item(0).Rows(intRowCount0).Item("FieldAlias")
                    '    intFieldWidth = dtsRepReport1.Tables.Item(0).Rows(intRowCount0).Item("FieldWidth")
                    '    strFieldType = objDataFields.Tables.Item(0).Rows(intRowCount0).Item("FieldType")
                End If
            End If
        Next
        Printer.PrintDataGridView(dgvReport)

    End Sub

    Private Sub btnRepEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepEmail.Click
        btnRepEmail.Enabled = False
        Try
            SendEmail(dgvRepReport, rtbRepReportHeader, rtbRepReportFooter)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        btnRepEmail.Enabled = True
    End Sub

    Private Sub SendEmail(ByRef dvgReport As DataGridView, ByRef rtbReportHeader As RichTextBox, ByRef rtbReportFooter As RichTextBox)
        'retrieve the selected client's email address
        Dim strEmail As String = Nothing

        Dim objData As DataSet
        If CurStatus.ClientID > 0 Then
            objData = ClientsHandle("Get", 0, CurStatus.ClientID)
            For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("Email").GetType().ToString = "System.DBNull" Then
                        strEmail = objData.Tables.Item(0).Rows(intRowCount).Item("Email")
                        'Else
                        '    MessageBox.Show("The client has no email address")
                        '    Exit Sub
                    End If
                End If
            Next
        End If

        If strEmail = Nothing Then strEmail = CurVar.SmtpReply
        strEmail = InputBox(lanStrings.strEnterEmailAddress, "Email", strEmail)
        If strEmail = "" Then
            SetStatus("Email not send")
            Exit Sub
        End If
        If EmailAddressCheck(strEmail) = False Then
            MessageBox.Show(lanStrings.strInvalidEmailAddress, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Information)
            SetStatus("Email not send")
            Exit Sub
        End If
        Dim strRecepientName As String = strEmail.Substring(0, strEmail.IndexOf("@"))
        Dim strHTML As New StringBuilder
        Try
            strHTML = DgvToHtml(dvgReport)
        Catch ex As Exception
            strHTML.Append("Unable to convert Report")
        End Try
        Dim strBody As String = ""
        strBody &= strHTML.ToString & vbCrLf
        strBody = Replace(strBody, "<body>", "<body>" & rtbReportHeader.Text & "<br>" & vbCrLf)
        If rtbReportFooter.Text.Length > 0 Then
            strBody = Replace(strBody, "</body>", "<br>" & Replace(rtbReportFooter.Text, Chr(10), "<br>") & vbCrLf & "</body>")
        End If
        strBody = Replace(strBody, "</body>", "<br>" & "Report " & CurStatus.ReportName & ", Startdate: " & calTrackMan.SelectionStart.Date.ToLongDateString & "</body>" & vbCrLf)

        Try
            If CurVar.EmailMethod = "SMTP" Then
                SendSMTP(CurVar.SmtpReply, _
                         strLicenseName, _
                         strEmail, _
                         strRecepientName, _
                         CurVar.SmtpReply, _
                         strLicenseName, _
                         CurStatus.ReportName, _
                         strBody, _
                         "")

            Else
                SendOutlook(strEmail, _
                         strRecepientName, _
                         CurStatus.ReportName, _
                         strBody, _
                         "")

            End If
            SetStatus("Mail Message Sent to: " & strEmail)
        Catch ex As Exception
            SetStatus("Mail Message Failed")
            MessageBox.Show("An error has occured sending the email: " & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ReportsGet()
        cbxRepLessons.Items.Clear()
        cbxRepFinance.Items.Clear()
        cbxRepClients.Items.Clear()
        cbxRepOther.Items.Clear()
        cbxRepLessons.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        cbxRepFinance.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        cbxRepClients.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        cbxRepOther.DisplayMember = "Text" 'Make sure the Text property is used to display the item

        Dim objData As DataSet = ReportsHandle("Get", 0, Nothing, Nothing, Nothing, Nothing, Nothing, True, CurVar.Language)
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If objData.Tables.Item(0).Rows(intRowCount).Item("Visible") = True Then

                    Dim lsvItem As New ListViewItem
                    lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                    lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                    If objData.Tables.Item(0).Rows(intRowCount).Item("SecondaryMenu") <> 0 Then
                        Select Case objData.Tables.Item(0).Rows(intRowCount).Item("SecondaryMenu")
                            Case 1
                                btnRep1.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                                btnRep1.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                            Case 2
                                btnRep2.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                                btnRep2.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                            Case 3
                                btnRep3.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                                btnRep3.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                            Case 4
                                btnRep4.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                                btnRep4.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                            Case 5
                                btnRep5.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                                btnRep5.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ReportName")
                        End Select
                    End If

                    Select Case objData.Tables.Item(0).Rows(intRowCount).Item("PrimaryMenu")
                        Case "Lessons"
                            cbxRepLessons.Items.Add(lsvItem)
                            'cbxRepLessons.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ReportName"))
                            'cbxRepLessons.Items(cbxRepLessons.Items.Count - 1).tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                        Case "Finance"
                            cbxRepFinance.Items.Add(lsvItem)
                            'cbxRepFinance.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ReportName"))
                            'cbxRepFinance.Items(cbxRepFinance.Items.Count - 1).tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                        Case "Clients"
                            cbxRepClients.Items.Add(lsvItem)
                            'cbxRepClients.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ReportName"))
                            'cbxRepClients.Items(cbxRepClients.Items.Count - 1).tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                        Case "Other"
                            cbxRepOther.Items.Add(lsvItem)
                            'cbxRepOther.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("ReportName"))
                            'cbxRepOther.Items(cbxRepOther.Items.Count - 1).tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ReportId")
                    End Select
                End If
            End If
        Next

    End Sub

    Private Sub ReportGet(ByVal intReportID As Integer)

        chkRepLimitTrack.Checked = False
        chkRepLimitGroup.Checked = False
        chkRepLimitClient.Checked = False
        rbnRepLimitTypeAll.Checked = False
        rbnRepLimitTypeClient.Checked = False
        rbnRepLimitTypeTeacher.Checked = False
        rbnRepLimitTypeBar.Checked = False
        chkRepLimitInvoice.Checked = False

        CurStatus.ReportID = intReportID
        'CurStatus.ReportType = strPrimaryMenu

        Dim objData As DataSet = ReportArgumentsHandle("Get", 0, intReportID, 0, 0, 0)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                CurStatus.ReportName = Translate(CurVar.Language, "Reports", objData.Tables.Item(0).Rows(intRowCount).Item("ReportName"))
                Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ArgumentName")
                    Case "@DateStart"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            'chkRepLimitDay.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitDay.Enabled = True
                        End If
                    Case "@DateStop"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            'chkRepLimitSeason.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitSeason.Enabled = True
                        End If
                    Case "@ClientId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            chkRepLimitClient.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitClient.Enabled = True
                        End If
                    Case "@GroupId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            chkRepLimitGroup.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitGroup.Enabled = True
                        End If
                    Case "@AppType"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            rbnRepLimitTypeClient.Checked = True
                        Else
                            rbnRepLimitTypeAll.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'rbnRepLimitTypeAll.Enabled = True
                        End If
                        rbnRepLimitTypeClient.Enabled = True
                        rbnRepLimitTypeTeacher.Enabled = True
                        rbnRepLimitTypeBar.Enabled = True
                    Case "@TrackId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            chkRepLimitTrack.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitTrack.Enabled = True
                        End If
                    Case "@InvoiceId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            chkRepLimitInvoice.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitInvoice.Enabled = True
                        End If
                    Case "@LessonTypeId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            'chkRepLimitLessonType.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitLessonType.Enabled = True
                        End If
                    Case "@LevelId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsSelected") = True Then
                            'chkRepLimitLevel.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = True Then
                            'chkRepLimitLevel.Enabled = True
                        End If
                End Select

            End If
        Next

    End Sub

    Private Sub ReportCheck(ByVal intReportID As Integer)
        Dim objData As DataSet = ReportArgumentsHandle("Chk", 0, intReportID, 0, 0, 0)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                'If intRowCount = 0 Then CurStatus.ReportID = objData.Tables.Item(0).Rows(intRowCount).Item("FK_ReportId")
                Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ArgumentName")
                    Case "@DateStart"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            'chkRepLimitDay.Checked = False
                        End If
                    Case "@DateStop"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            rbnRepLimitSeason.Checked = True
                        End If
                        If objData.Tables.Item(0).Rows(intRowCount).Item("IsOptional") = 0 Then
                            CurStatus.ReportType = "Season"
                        Else
                            CurStatus.ReportType = "Day"
                        End If
                    Case "@ClientId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            chkRepLimitClient.Checked = False
                        End If
                    Case "@GroupId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            chkRepLimitGroup.Checked = False
                        End If
                    Case "@AppType"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            rbnRepLimitTypeAll.Checked = True
                        End If
                    Case "@TrackId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            chkRepLimitTrack.Checked = False
                        End If
                    Case "@InvoiceId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            chkRepLimitInvoice.Checked = False
                        End If
                    Case "@LessonTypeId"
                        If objData.Tables.Item(0).Rows(intRowCount).Item("Allowed") = 0 Then
                            chkRepLimitLessonType.Checked = False
                        End If

                End Select

            End If
        Next

    End Sub

    Private Sub TracksGet()
        cbxRepTrack.Items.Clear()
        cbxRepTrack.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim lsvItem0 As New ListViewItem
        lsvItem0.Tag = 0
        lsvItem0.Text = chkRepLimitTrack.Text
        cbxRepTrack.Items.Add(lsvItem0)
        cbxRepTrack.Text = chkRepLimitTrack.Text

        Dim objData As DataSet = TracksHandle("Get")
        If objData Is Nothing Then Exit Sub
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_TrackId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                cbxRepTrack.Items.Add(lsvItem)
            End If
        Next
        Dim lsvItem1 As New ListViewItem
        lsvItem1.Tag = -1
        lsvItem1.Text = lanStrings.strAll
        cbxRepTrack.Items.Add(lsvItem1)
    End Sub

#End Region

#Region "SearchTab"

    Private Sub btnSearchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClear.Click
        txtSearchFirstName.Text = ""
        txtSearchLastName.Text = ""
        txtSearchPostalCode.Text = ""
        txtSearchCity.Text = ""
        txtSearchGroupName.Text = ""
        txtSearchEmail.Text = ""
        txtSearchPhone.Text = ""
        dtpSearchDayOfBirth.Value = "1900-01-01"
        rbnPartialMatchLeft.Checked = True
        rbnMatchAll.Checked = True
        txtSearchMaximum.Text = "25"
        lvwSearchResult.Items.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lvwSearchResult.Items.Clear()
        Dim strSearchFirstName As String = Nothing
        Dim strSearchLastName As String = Nothing
        Dim strSearchPostalcode As String = Nothing
        Dim strSearchCity As String = Nothing
        Dim strSearchGroupName As String = Nothing
        Dim strSearchEmail As String = Nothing
        Dim strSearchPhone As String = Nothing
        Dim strSearchDateOfBirth As String = Nothing
        Dim intSearchPartialMatch As Integer = 1
        Dim booSearchMatchAll As Boolean = True
        Dim intSearchMaximum As Integer = 25

        If rbnPartialMatchAny.Checked Then intSearchPartialMatch = 2
        If rbnExactMatch.Checked Then intSearchPartialMatch = 3
        If rbnMatchAny.Checked Then booSearchMatchAll = False
        If IsNumeric(txtSearchMaximum.Text) Then intSearchMaximum = txtSearchMaximum.Text
        If Len(txtSearchFirstName.Text) > 1 Then strSearchFirstName = txtSearchFirstName.Text
        If Len(txtSearchLastName.Text) > 1 Then strSearchLastName = txtSearchLastName.Text
        If Len(txtSearchPostalCode.Text) > 1 Then strSearchPostalcode = txtSearchPostalCode.Text
        If Len(txtSearchCity.Text) > 1 Then strSearchCity = txtSearchCity.Text
        If Len(txtSearchGroupName.Text) > 1 Then strSearchGroupName = txtSearchGroupName.Text
        If Len(txtSearchEmail.Text) > 1 Then strSearchEmail = txtSearchEmail.Text
        If Len(txtSearchPhone.Text) > 1 Then strSearchPhone = txtSearchPhone.Text
        If dtpSearchDayOfBirth.Value <> "1900-01-01" Then strSearchDateOfBirth = dtpSearchDayOfBirth.Value.Year & Format(dtpSearchDayOfBirth.Value.Month, "00") & Format(dtpSearchDayOfBirth.Value.Day, "00")

        Dim objData As DataSet = Search(intSearchPartialMatch, booSearchMatchAll, intSearchMaximum, strSearchFirstName, strSearchLastName, strSearchPostalcode, strSearchCity, strSearchGroupName, strSearchEmail, strSearchPhone, strSearchDateOfBirth)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("ClName")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Street") & " " & objData.Tables.Item(0).Rows(intRowCount).Item("HouseNumber"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("PostalCode"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("City"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("TelePhone"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Mobile"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Email"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("DayOfBirth"))

                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("GroupName"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Country"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("FK_GroupID"))

                lvwSearchResult.Items.Add(lsvItem)
            End If
        Next

    End Sub

    Private Sub lvwSearchResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSearchResult.SelectedIndexChanged
        If lvwSearchResult.SelectedItems.Count = 1 Then
            CurStatus.ClientID = lvwSearchResult.SelectedItems.Item(0).Tag
            CurStatus.GroupID = lvwSearchResult.SelectedItems.Item(0).SubItems(10).Text
            ShowCurStat()
        End If

    End Sub


#End Region

#Region "Security"
    Private Sub SecuritySet()
        mnuMainWindowSecurity.Enabled = False
        mnuMainWindowSettings.Enabled = False
        If CurUser.SecurityAdd Or CurUser.SecurityChange Or CurUser.SecurityDelete Then mnuMainWindowSecurity.Enabled = True
        If CurUser.SettingsAdd Or CurUser.SettingsChange Or CurUser.SettingsDelete Then mnuMainWindowSettings.Enabled = True

        tabTrackManager.TabPages("tpgFinance").Enabled = False
        btnFinanceEdit.Enabled = False
        btnFinanceDelete.Enabled = False
        If CurUser.FinanceAdd Or CurUser.FinanceChange Or CurUser.FinanceDelete Then
            tabTrackManager.TabPages("tpgFinance").Enabled = True
        End If
        If CurUser.FinanceChange Then btnFinanceEdit.Enabled = True
        If CurUser.FinanceDelete Then btnFinanceDelete.Enabled = True

        btnCorrectLessonCount.Enabled = False
        If CurUser.SettingsDelete Then btnCorrectLessonCount.Enabled = True
    End Sub
#End Region

#Region "Updates"

    Private Sub mnuMainHelpUpdates_Click(sender As Object, e As EventArgs) Handles mnuMainHelpUpdates.Click
        InstallUpdateSyncWithInfo()
    End Sub

    Private Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " & _
                        "version to version " & info.MinimumRequiredVersion.ToString() & _
                        ". The application will now install the update and restart.", _
                        "Update Available", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            Else
                MessageBox.Show("You are running the latest version.")
            End If
        End If
    End Sub

#End Region

#Region "Test"

    Private Sub TestEnable()
        btnTest1.Visible = True
        btnTest2.Visible = True
        btnTest3.Visible = True
        txtTest1.Visible = True
    End Sub

    Private Sub btnTest1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest1.Click
        For Each cltClient In CurApp.Clients
            MessageBox.Show(cltClient.LessonTypeID)
        Next

    End Sub

    Private Sub btnTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest2.Click
        ShowApp(UndoApp)
    End Sub

    Private Sub btnTest3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest3.Click
        Dim strEmail As String = Nothing
        strEmail = InputBox(lanStrings.strEnterEmailAddress, "Email")
        MessageBox.Show(EmailAddressCheck(strEmail))
    End Sub

    Friend Sub CreateDatabase2()

        Dim MydbRef As New TMDB.DBRef
        'Dim intcounter As Integer
        'intcounter = MydbRef.GetList()
        Dim arrScripts(100) As String
        arrScripts = MydbRef.GetList()
        MessageBox.Show(arrScripts.GetUpperBound(0))
        MessageBox.Show(arrScripts(4))
        MessageBox.Show(MydbRef.GetScript(arrScripts(4)))

    End Sub


#End Region

    'Private Function ParseVersion(ByVal strVersion As String) As Version
    '    'Dim dbMajor As String = "0"
    '    'Dim dbMinor As String = "0"
    '    'Dim dbBuild As String = "0"
    '    'Dim dbRevision As String = "0"
    '    'Dim intpoint0 As Integer
    '    'Dim intPoint1 As Integer
    '    'Dim intPoint2 As Integer

    '    'intpoint0 = strVersion.LastIndexOf(".")
    '    'MessageBox.Show(intpoint0)

    '    'intPoint1 = 0
    '    'intPoint2 = strVersion.IndexOf(".", intPoint1)
    '    'If intPoint2 = -1 Then intPoint2 = strVersion.Length
    '    'dbMajor = strVersion.Substring(intPoint1, intPoint2 - intPoint1)

    '    'intPoint1 = intPoint2 + 1
    '    'If intPoint1 < strVersion.Length Then
    '    '    intPoint2 = strVersion.IndexOf(".", intPoint1)
    '    '    If intPoint2 = -1 Then intPoint2 = strVersion.Length
    '    '    dbMinor = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
    '    'End If

    '    'intPoint1 = intPoint2 + 1
    '    'If intPoint1 < strVersion.Length Then
    '    '    intPoint2 = strVersion.IndexOf(".", intPoint1)
    '    '    If intPoint2 = -1 Then intPoint2 = strVersion.Length
    '    '    dbBuild = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
    '    'End If

    '    'intPoint1 = intPoint2 + 1
    '    'If intPoint1 < strVersion.Length Then
    '    '    intPoint2 = strVersion.Length
    '    '    If intPoint2 = -1 Then intPoint2 = strVersion.Length
    '    '    dbRevision = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
    '    'End If

    '    'Dim verDatabase As New Version(dbMajor, dbMinor, dbBuild, dbRevision)

    '    Dim verDatabase As New Version(strVersion)
    '    Return verDatabase
    'End Function

End Class
