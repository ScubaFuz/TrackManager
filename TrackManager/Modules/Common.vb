Imports System.Xml
Imports System.Text
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports System.Net.Mail
Imports System.Net
Imports Microsoft.Office.Interop
'Imports System.Text.RegularExpressions

Module Common
	Friend DebugMode As Boolean = False
    'Friend blnLicenseValidated = False
    Friend blnDatabaseOnLine As Boolean = False

	Friend intSeason As Integer = Nothing
	Friend strQuery As String = Nothing
	Friend ErrorMode As Boolean = False
	Friend strLicenseName As String
    Friend strExpiryDate As String
    Friend dtmExpiryDate As Date = Nothing
    Friend strLicenseKey As String

	Friend TxtHandle As New DataHandler.txt
	Friend RegHandle As New DataHandler.reg
	Friend DbHandle As New DataHandler.db
    'Friend xmlDoc As New XmlDocument
	Friend xmlLanguage As New XmlDocument
	Friend lanStrings As New Language

    Friend CurApp As New Appointment
    Friend UndoApp As New Appointment
    Friend CurVar As New Variables
	Friend CurUser As New CurrentUser
	Friend CurStatus As New CurrentStatus

	Friend dtmTimeStart As DateTime
    Friend dtmTimeStop As DateTime
    Friend intTimeStart As Integer
    Friend intTimeStop As Integer

	Friend strReport As String = "Track Manager " & vbTab & " version: " & Application.ProductVersion


    Friend Sub ParseCommands()
        Dim intLength As Integer = 0
        If My.Application.CommandLineArgs.Contains("/debug") Then DebugMode = True
        For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
            intLength = My.Application.CommandLineArgs.Item(i).ToString.Length
            If intLength > 5 Then
                If My.Application.CommandLineArgs.Item(i).ToString.Substring(1, 5) = "name:" Then
                    CurVar.ApplicationName = CurVar.ApplicationName & " " & My.Application.CommandLineArgs.Item(i).ToString.Substring(6, intLength - 6)
                End If

            End If
        Next


    End Sub

	Friend Sub SetDefaults()
        RegHandle.RegistryPath = "Software\Thicor\TrackManager\4.0"

		TxtHandle.InputFile = "TrackManData.xml"
		TxtHandle.LogFileName = "TrackManData.Log"
		TxtHandle.LogLevel = 5
        TxtHandle.LogLocation = Application.StartupPath & "\LOG"
		TxtHandle.OutputFile = Environment.SpecialFolder.MyDocuments

		DbHandle.LoginMethod = "WINDOWS"
        DbHandle.LoginName = "TrackMan"
        DbHandle.Password = "tr@ckm@n"
        DbHandle.DataLocation = Environment.MachineName & "\SQLEXPRESS"
		DbHandle.DatabaseName = "TrackManager"
		DbHandle.DataProvider = "SQL"

    End Sub

    Friend Sub LoadLicense()
        Try
            strLicenseName = RegHandle.ReadAnyRegKey("LicenseName", RegHandle.RegistryPath)
            If strLicenseName = "-1" Then
                WriteLog(RegHandle.RegMessage, 1)
                strLicenseName = "Thicor Services Demo License"
            End If

            strLicenseKey = RegHandle.ReadAnyRegKey("LicenseKey", RegHandle.RegistryPath)
            If strLicenseKey = "-1" Then WriteLog(RegHandle.RegMessage, 1)
        Catch ex As Exception
            If DebugMode = True Then MessageBox.Show(ex.Message)
            WriteLog(ex.Message, 1)
            blnLicenseValidated = False
            strLicenseName = "Thicor Services Demo License"
        End Try

        If strLicenseKey <> "-1" Then
            If CheckLicenseKey(strLicenseKey, strLicenseName, GetVersion("M"), Nothing) = False Then
                'MessageBox.Show(strMessages.strLicenseError)
                blnLicenseValidated = False
            Else
                blnLicenseValidated = True
                'If DebugMode Then MessageBox.Show(lanStrings.strLicenseValidated)
            End If
        Else
            blnLicenseValidated = False
        End If

        strReport = "TrackManager " & vbTab & " version: " & Application.ProductVersion & vbTab & "  Licensed by: " & strLicenseName

    End Sub


    'Public Function GetVersion() As String
    '    If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
    '        Dim ver As Version
    '        ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
    '        Return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision)
    '    Else
    '        Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
    '    End If
    'End Function

    Public Function GetVersion(strPart As String) As String
        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            Dim ver As Version
            ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
            Select Case strPart
                Case "M"
                    Return String.Format("{0}", ver.Major)
                Case "m"
                    Return String.Format("{0}.{1}", ver.Major, ver.Minor)
                Case "B"
                    Return String.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build)
                Case "R"
                    Return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision)
                Case Else
                    Return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision)
            End Select
        Else
            Select Case strPart
                Case "M"
                    Return My.Application.Info.Version.Major
                Case "m"
                    Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
                Case "B"
                    Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
                Case "R"
                    Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
                Case Else
                    Return My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
            End Select
        End If
    End Function

    Friend Sub WriteLog(ByVal strLogtext As String, ByVal intLogLevel As Integer)
        Try
            If TxtHandle.LogLocation.ToLower = "database" Then
                WriteDBLog(strLogtext)
            Else
                TxtHandle.WriteLog(strLogtext, intLogLevel)
            End If
        Catch ex As Exception
            Dim strMyDir As String
            strMyDir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            If TxtHandle.LogLocation = strMyDir & "\Trackmanager\LOG" Then
                TxtHandle.LogLevel = 0
                MessageBox.Show(lanStrings.strLogError & vbCrLf & _
                    lanStrings.strCheckSettings & vbCrLf & _
                    "Logfile location = " & TxtHandle.LogLocation & vbCrLf & _
                    "Logfile Name = " & TxtHandle.LogFileName & vbCrLf & _
                    "Log level = " & TxtHandle.LogLevel & vbCrLf & _
                    ex.Message & vbCrLf & _
                    "Logging has been turned off")
            End If
            MessageBox.Show(lanStrings.strLogError & vbCrLf & _
                lanStrings.strCheckSettings & vbCrLf & _
                "Logfile location = " & TxtHandle.LogLocation & vbCrLf & _
                "Logfile Name = " & TxtHandle.LogFileName & vbCrLf & _
                "Log level = " & TxtHandle.LogLevel & vbCrLf & _
                ex.Message & vbCrLf & _
                "The Logfile has been reset to " & strMyDir & "\Trackmanager\LOG\TrackManData.Log")
            If TxtHandle.CheckDir(strMyDir & "\Trackmanager") = False Then TxtHandle.CreateDir(strMyDir & "\Trackmanager")
            If TxtHandle.CheckDir(strMyDir & "\Trackmanager\LOG") = False Then TxtHandle.CreateDir(strMyDir & "\Trackmanager\LOG")
            TxtHandle.LogFileName = "TrackManData.Log"
            TxtHandle.LogLocation = strMyDir & "\Trackmanager\LOG"
        End Try
    End Sub

    Friend Sub SetOpeningHours()
        If CurVar.ShowOffHours Then
            'dtmTimeStart = Today
            'dtmTimeStop = Today.AddHours(23)
        Else
            If CurVar.OpeningHour < CurVar.ClosingHour Then
                'dtmTimeStart = CurVar.OpeningHours.AddMinutes(-CurVar.TimeFrame)
                intTimeStart = CurVar.OpeningHour - CurVar.TimeFrame
                'dtmTimeStop = CurVar.ClosingHours.AddMinutes(CurVar.TimeFrame)
                intTimeStop = CurVar.ClosingHour + CurVar.TimeFrame
            Else
                'dtmTimeStart = CurVar.OpeningHours.AddMinutes(CurVar.TimeFrame)
                intTimeStart = CurVar.OpeningHour + CurVar.TimeFrame
                'dtmTimeStop = CurVar.ClosingHours.AddMinutes(-CurVar.TimeFrame)
                intTimeStop = CurVar.ClosingHour - CurVar.TimeFrame
                'dtmTimeStop = dtmTimeStop.AddDays(1)
            End If
        End If
    End Sub

    Friend Sub SetSeasonMonths()
        Select Case CurVar.SeasonLength
            Case "Year"
                CurVar.SeasonMonths = 12
            Case "6 Months"
                CurVar.SeasonMonths = 6
            Case "Quarter"
                CurVar.SeasonMonths = 3
            Case "Month"
                CurVar.SeasonMonths = 1
        End Select
    End Sub

    Friend Sub SetSeasonDates(ByVal dtmSelectedDate As Date)
        Dim dtmDateStart As Date
        Dim dtmDateStop As Date
        dtmDateStart = CurVar.SeasonStart
        dtmDateStop = CurVar.SeasonStart.AddMonths(CurVar.SeasonMonths)
        dtmDateStop = dtmDateStop.AddDays(-1)
        'If DebugMode Then MessageBox.Show("dtmDateStart = " & dtmDateStart & " " & vbCrLf & "dtmDateStop = " & dtmDateStop)
        Do Until dtmDateStart <= dtmSelectedDate And dtmDateStop >= dtmSelectedDate
            If dtmDateStart > dtmSelectedDate Then
                dtmDateStart = dtmDateStart.AddMonths(-CurVar.SeasonMonths)
                dtmDateStop = dtmDateStop.AddMonths(-CurVar.SeasonMonths)
            ElseIf dtmDateStop < dtmSelectedDate Then
                dtmDateStart = dtmDateStart.AddMonths(CurVar.SeasonMonths)
                dtmDateStop = dtmDateStop.AddMonths(CurVar.SeasonMonths)
            End If
        Loop
        CurVar.SeasonStart = dtmDateStart
        CurVar.SeasonEnd = dtmDateStop
    End Sub

#Region "Registry"
    Public Sub VariablesViewGet()
        WriteLog("retreiving View Settings from Registry", 2)
        Dim strValue As String = Nothing
        strValue = RegHandle.ReadCURRegKey("TrackBoxWidth", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.TrackBoxWidth = strValue
        End If
        strValue = Nothing
        strValue = RegHandle.ReadCURRegKey("TrackBoxHeight", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.TrackBoxHeight = strValue
        End If
        'CurVar.TrackBoxWidth = RegHandle.ReadLMRegKey("TrackBoxWidth", RegHandle.RegistryPath)
    End Sub

    Public Sub VariablesScreenGet()
        WriteLog("retreiving Screen Settings from Registry", 2)
        Dim strValue As String
        strValue = RegHandle.ReadCURRegKey("Top", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.ScreenTop = strValue
        End If
        strValue = RegHandle.ReadCURRegKey("Left", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.ScreenLeft = strValue
        End If
        strValue = RegHandle.ReadCURRegKey("Width", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.ScreenWidth = strValue
        End If
        strValue = RegHandle.ReadCURRegKey("Height", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.ScreenHeight = strValue
        End If
        strValue = RegHandle.ReadCURRegKey("ScreenState", RegHandle.RegistryPath)
        If RegHandle.ErrorLevel = 0 And strValue <> Nothing Then
            CurVar.ScreenState = strValue
        End If
        'CurVar.ScreenTop = RegHandle.ReadLMRegKey("Top", RegHandle.RegistryPath)
        'CurVar.ScreenLeft = RegHandle.ReadLMRegKey("Left", RegHandle.RegistryPath)
        'CurVar.ScreenWidth = RegHandle.ReadLMRegKey("Width", RegHandle.RegistryPath)
        'CurVar.ScreenHeight = RegHandle.ReadLMRegKey("Height", RegHandle.RegistryPath)
        'CurVar.ScreenState = RegHandle.ReadLMRegKey("ScreenState", RegHandle.RegistryPath)
    End Sub

    Public Sub VariablesScreenSave()
        WriteLog("Writing Screen Settings to Registry", 2)
        RegHandle.AddCURRegKey("Top", CurVar.ScreenTop, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("Left", CurVar.ScreenLeft, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("Width", CurVar.ScreenWidth, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("Height", CurVar.ScreenHeight, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("ScreenState", CurVar.ScreenState, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
    End Sub

    Public Sub DatabaseSettingsLoad()
        Try
            Dim strTemp As String
            strTemp = RegHandle.ReadCURRegKey("DataLocation", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.DataLocation = strTemp
            End If
            strTemp = RegHandle.ReadCURRegKey("DatabaseName", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.DatabaseName = strTemp
            End If
            strTemp = RegHandle.ReadCURRegKey("DataProvider", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.DataProvider = strTemp
            End If
            strTemp = RegHandle.ReadCURRegKey("LoginMethod", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.LoginMethod = strTemp
            End If
            strTemp = RegHandle.ReadCURRegKey("LoginName", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.LoginName = strTemp
            End If
            strTemp = RegHandle.ReadCURRegKey("Password", RegHandle.RegistryPath)
            If strTemp <> "-1" And strTemp <> "" Then
                DbHandle.Password = psDecrypt(strTemp)
            End If
        Catch ex As Exception
            If DebugMode Then MessageBox.Show("Unable to read from registry")
            blnDatabaseOnLine = False
            Exit Sub
        End Try

    End Sub

    Public Sub DatabaseTest()
        If DebugMode Then
            MessageBox.Show("TrackManager v " & Application.ProductVersion & " Database Settings" & vbCrLf _
             & "   DatabaseServer = " & DbHandle.DataLocation & vbCrLf _
             & "   Database Name = " & DbHandle.DatabaseName & vbCrLf _
             & "   DataProvider = " & DbHandle.DataProvider & vbCrLf _
             & "   LoginMethod = " & DbHandle.LoginMethod & vbCrLf _
             & "   LoginName = " & DbHandle.LoginName & vbCrLf _
             & "   Password = " & DbHandle.Password & vbCrLf _
             & "   Running in Debug Mode")
        End If
        Try
            DbHandle.CheckDB()
            blnDatabaseOnLine = DbHandle.DataBaseOnline
        Catch ex As Exception
            MessageBox.Show("While testing the database connection, the following error occured: " & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub DatabaseSettingsSave()
        If DebugMode Then
            MessageBox.Show("TrackManager v " & Application.ProductVersion & " Database Save" & vbCrLf _
             & "   DatabaseServer = " & DbHandle.DataLocation & vbCrLf _
             & "   Database Name = " & DbHandle.DatabaseName & vbCrLf _
             & "   DataProvider = " & DbHandle.DataProvider & vbCrLf _
             & "   LoginMethod = " & DbHandle.LoginMethod & vbCrLf _
             & "   LoginName = " & DbHandle.LoginName & vbCrLf _
             & "   Password = " & DbHandle.Password & vbCrLf _
             & "   Running in Debug Mode")
        End If
        If DebugMode Then MessageBox.Show("(Writing to : " & RegHandle.RegistryPath)
        RegHandle.AddCURRegKey("DataLocation", DbHandle.DataLocation, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("DatabaseName", DbHandle.DatabaseName, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("DataProvider", DbHandle.DataProvider, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("LoginMethod", DbHandle.LoginMethod, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("LoginName", DbHandle.LoginName, RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
        RegHandle.AddCURRegKey("Password", psEncrypt(DbHandle.Password), RegHandle.RegistryPath)
        If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
    End Sub

#End Region

#Region "Appointments"
    Friend Function AppClientAdd(ByVal dblClientId As Double) As Double
        Dim dblClientCount As Double
        For dblClientCount = 0 To CurApp.Clients.Count - 1
            If CurApp.Clients(dblClientCount).ID = dblClientId Then
                'Client already exists in collecton
                AppClientAdd = dblClientCount
                Exit Function
            End If
        Next
        CurApp.Clients.Add(dblClientId)
        AppClientAdd = CurApp.Clients.Count - 1
    End Function

    Friend Function AppClientRemove(ByVal dblClientId As Double) As Boolean
        Dim appClient As Client
        For Each appClient In CurApp.Clients
            With appClient
                If .ID = dblClientID Then
                    CurApp.Clients.Remove(appClient)
                    Return True
                End If
            End With
        Next appClient
        Return False
    End Function

    Friend Function AppClientCheck(ByVal dblClientId As Double) As Client
        Dim appClient As Client
        For Each appClient In CurApp.Clients
            With appClient
                If .ID = dblClientId Then
                    Return appClient
                End If
            End With
        Next appClient
        Return Nothing
    End Function

    Friend Function AppClientHandle(ByVal dblClientId As Double) As Boolean
        If AppClientRemove(dblClientID) = False Then
            AppClientAdd(dblClientID)
            Return True
        End If
        Return False
    End Function

    Public Sub TrackBoxClickHandler(ByVal intTag As String, ByVal intIndex As Integer, ByVal dblClientId As Double, ByVal dblGroupId As Double, ByVal intLessonTypeId As Integer, ByVal intLevelId As Integer, ByVal strCollection As String, ByVal strBackColor As String, ByVal strForeColor As String, ByVal intLessonCount As Integer, ByVal intExtraCount As Integer)
        Select Case strCollection
            Case "ClientBoxArray", "TeacherBoxArray", "BarBoxArray", "TimeBoxArray"
                Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                refFrmTrackManager.BoxClickHandler(intTag, intIndex, dblClientID, dblGroupId, intLessonTypeId, intLevelId, strCollection, strBackColor, strForeColor, intLessonCount, intExtraCount)
                'Case "ClientBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.ClientBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
                'Case "TeacherBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.TeacherBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
                'Case "BarBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.BarBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
        End Select
    End Sub

    Public Sub TrackBoxDoubleClickHandler(ByVal intTag As String, ByVal intIndex As Integer, ByVal dblClientId As Double, dblGroupId As Double, intLessonTypeId As Integer, intLevelId As Integer, ByVal strCollection As String, ByVal clrBackColor As System.Drawing.Color, ByVal clrForeColor As System.Drawing.Color, intLessonCount As Integer, intExtraCount As Integer)
        Select Case strCollection
            Case "ClientBoxArray", "TeacherBoxArray", "BarBoxArray"
                Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                refFrmTrackManager.BoxDoubleClickHandler(intTag, intIndex, dblClientID, dblGroupId, intLessonTypeId, intLevelId, strCollection, clrBackColor, clrForeColor, intLessonCount, intExtraCount)
                'Case "ClientBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.ClientBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
                'Case "TeacherBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.TeacherBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
                'Case "BarBoxArray"
                '	Dim refFrmTrackManager As frmTrackManager = Windows.Forms.Form.ActiveForm
                '	refFrmTrackManager.BarBoxClick(intTag, intIndex, dblClientID, strBackColor, strForeColor, intLessonCount)
        End Select
    End Sub

    Friend Sub UndoAppClear()
        UndoApp.Clients.Clear()
        UndoApp.Name = Nothing
        UndoApp.DayPrev = Today
        UndoApp.Day = Today
        UndoApp.ID = 0
        UndoApp.Time = Now
        UndoApp.TimePrev = Now
        UndoApp.TrackId = 0
        UndoApp.TrackIdPrev = 0
        UndoApp.TrackIndex = 0
        UndoApp.TrackIndexPrev = 0
        UndoApp.TrackName = Nothing
    End Sub

    Friend Sub AppSync()
        UndoApp.ID = CurApp.ID
        UndoApp.Day = CurApp.Day
        UndoApp.DayPrev = CurApp.DayPrev
        UndoApp.Name = CurApp.Name
        UndoApp.Time = CurApp.Time
        UndoApp.TimePrev = CurApp.TimePrev
        UndoApp.TrackId = CurApp.TrackId
        UndoApp.TrackIdPrev = CurApp.TrackIdPrev
        UndoApp.TrackIndex = CurApp.TrackIndex
        UndoApp.TrackIndexPrev = CurApp.TrackIndexPrev
        UndoApp.TrackName = CurApp.TrackName
        For Each inputClient In CurApp.Clients
            If inputClient.Checked Then
                UndoApp.Clients.Add(inputClient.clone)
            End If
        Next
    End Sub

    Friend Sub ShowApp(App As Appointment)
        Dim strMessage As String = "Aantal: " & App.Clients.Count
        strMessage &= vbCrLf & "Day: " & App.Day
        strMessage &= vbCrLf & "DayPrev: " & App.DayPrev
        strMessage &= vbCrLf & "ID: " & App.ID
        strMessage &= vbCrLf & "Name: " & App.Name
        strMessage &= vbCrLf & "Time: " & App.Time
        strMessage &= vbCrLf & "TimePrev: " & App.TimePrev
        strMessage &= vbCrLf & "TrackId: " & App.TrackId
        strMessage &= vbCrLf & "TrackIdPrev: " & App.TrackIdPrev
        strMessage &= vbCrLf & "TrackIndex: " & App.TrackIndex
        strMessage &= vbCrLf & "TrackIndexPrev: " & App.TrackIndexPrev
        strMessage &= vbCrLf & "TrackName: " & App.TrackName
        For Each cltClient In App.Clients
            strMessage &= vbCrLf
            strMessage &= vbCrLf & "Client ID: " & cltClient.ID
            strMessage &= vbCrLf & "Client Checked: " & cltClient.Checked
            strMessage &= vbCrLf & "Client GroupID: " & cltClient.GroupID
            strMessage &= vbCrLf & "Client GroupName: " & cltClient.GroupName
            strMessage &= vbCrLf & "Client LessonTypeID: " & cltClient.LessonTypeID
            strMessage &= vbCrLf & "Client LessonTypeColor: " & cltClient.LessonTypeColor.ToString
            strMessage &= vbCrLf & "Client _LessonTypeColorStr: " & cltClient.LessonTypeColorStr
            strMessage &= vbCrLf & "Client LessonCount: " & cltClient.LessonCount
            strMessage &= vbCrLf & "Client ExtraCount: " & cltClient.ExtraCount
            strMessage &= vbCrLf & "Client LevelID: " & cltClient.LevelID
            strMessage &= vbCrLf & "Client LevelName: " & cltClient.LevelName
            strMessage &= vbCrLf & "Client LevelColor: " & cltClient.LevelColor.ToString
            strMessage &= vbCrLf & "Client LevelColorStr: " & cltClient.LevelColorStr
            strMessage &= vbCrLf & "Client TrackIndex: " & cltClient.TrackIndex
        Next
        MessageBox.Show(strMessage)
    End Sub

    Friend Function CheckedClientCount(App As Appointment) As Integer
        Dim intClientCount As Integer = 0
        For Each cltClient In App.Clients
            If cltClient.checked = True Then intClientCount += 1
        Next
        Return intClientCount
    End Function
#End Region

#Region "XML"

    'Friend Sub LoadXmlSettings()
    '    If TxtHandle.CheckFile(Application.StartupPath & "\" & TxtHandle.InputFile) = True Then
    '        'LoadXmlFile
    '        xmlDoc.Load(Application.StartupPath & "\" & TxtHandle.InputFile)
    '        DbHandle.DataLocation = xmlDoc.Item("TrackManager").Item("DataBase").Item("DataLocation").InnerText
    '        DbHandle.DatabaseName = xmlDoc.Item("TrackManager").Item("DataBase").Item("DatabaseName").InnerText
    '        DbHandle.DataProvider = xmlDoc.Item("TrackManager").Item("DataBase").Item("DataProvider").InnerText
    '        DbHandle.LoginMethod = xmlDoc.Item("TrackManager").Item("DataBase").Item("LoginMethod").InnerText
    '        DbHandle.LoginName = xmlDoc.Item("TrackManager").Item("DataBase").Item("LoginName").InnerText
    '        DbHandle.Password = xmlDoc.Item("TrackManager").Item("DataBase").Item("Password").InnerText
    '    Else
    '        If SaveXmlFile() = False Then
    '            WriteLog(lanStrings.strXmlError, 1)
    '            MessageBox.Show(lanStrings.strXmlError)
    '        End If
    '    End If
    'End Sub

    'Friend Function SaveXmlFile() As Boolean
    '    '** Create or update the xml inputdata.
    '    Dim strXmlText As String
    '    strXmlText = "<?xml version=""1.0"" standalone=""yes""?>" & vbCrLf
    '    strXmlText &= "<TrackManager>" & vbCrLf
    '    strXmlText &= "	<DataBase>" & vbCrLf
    '    strXmlText &= "		<DataLocation>" & DbHandle.DataLocation & "</DataLocation>" & vbCrLf
    '    strXmlText &= "		<DatabaseName>" & DbHandle.DatabaseName & "</DatabaseName>" & vbCrLf
    '    strXmlText &= "		<DataProvider>" & DbHandle.DataProvider & "</DataProvider>" & vbCrLf
    '    strXmlText &= "		<LoginMethod>" & DbHandle.LoginMethod & "</LoginMethod>" & vbCrLf
    '    strXmlText &= "		<LoginName>" & DbHandle.LoginName & "</LoginName>" & vbCrLf
    '    strXmlText &= "		<Password>" & DbHandle.Password & "</Password>" & vbCrLf
    '    strXmlText &= "	</DataBase>" & vbCrLf
    '    strXmlText &= "</TrackManager>" & vbCrLf
    '    xmlDoc.LoadXml(strXmlText)
    '    Try
    '        SaveXmlFile = TxtHandle.CreateFile(strXmlText, Application.StartupPath & "\" & TxtHandle.InputFile)
    '    Catch ex As Exception
    '        WriteLog(lanStrings.strXmlError & vbCrLf & ex.Message, 1)
    '    End Try
    'End Function

    Friend Sub LoadXmlLanguage(strFile As String)
        Try
            If TxtHandle.CheckFile(strFile) = True Then
                'LoadXmlFile
                xmlLanguage.Load(strFile)
            Else
                MessageBox.Show("Loading the file: " & strFile & " has failed.", "Language Error")
                'proceslines
            End If
        Catch ex As Exception
            MessageBox.Show("Loading the file: " & strFile & " has failed.", "Language Error")
        End Try
    End Sub

#End Region

#Region "Language"

    Friend Sub SetLanguage(ByVal ctrl As Control)
        Dim dtsData As DataSet = LanguageHandle("Get", Nothing, CurVar.Language, Replace(ctrl.Name, "frm", ""))

        If dtsData Is Nothing Then Exit Sub
        If dtsData.Tables.Count = 0 Then Exit Sub
        If dtsData.Tables(0).Rows.Count = 0 Then Exit Sub

        For intRowCount = 0 To dtsData.Tables(0).Rows.Count - 1
            If dtsData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Select Case dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageType")
                    Case "Text"
                        FindTextControl(ctrl, dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem"), dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                    Case "List"
                        Dim strName As String = dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem")
                        'MessageBox.Show(strLeft(strName, strName.IndexOf("_")) & vbCrLf & strRight(strName, strName.Length - (strName.IndexOf("_") + 1)))
                        FindListControl(ctrl, strLeft(strName, strName.IndexOf("_")), strRight(strName, strName.Length - (strName.IndexOf("_") + 1)), dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                    Case "ListItem"
                        Dim strName As String = dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem")
                        'MessageBox.Show(strLeft(strName, strName.IndexOf("_")) & vbCrLf & strRight(strName, strName.Length - (strName.IndexOf("_") + 1)))
                        FindListItemControl(ctrl, strLeft(strName, strName.IndexOf("_")), strRight(strName, strName.Length - (strName.IndexOf("_") + 1)), dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                    Case "Menu"
                        Select Case ctrl.Name
                            Case "frmTrackManager"
                                FindTrackMenu(dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem"), dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                        End Select
                    Case "Prop"
                        FindLanString(dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem"), dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                    Case "Reports"
                        'do something
                End Select
            End If
        Next

        'If xmlLanguage.DocumentElement Is Nothing Then Exit Sub
        'Dim xmlLanNode As Xml.XmlNode = xmlLanguage.Item("TrackManager").Item("Language").Item("Form")
        'Dim intNodeCount As Integer = 0
        'Do While xmlLanNode.Attributes.GetNamedItem("Name").Value <> ctrl.Name
        '    'MessageBox.Show(xmlLanNode.Attributes.GetNamedItem("Name").Value)
        '    If Not xmlLanguage.Item("TrackManager").Item("Language").LastChild Is xmlLanNode Then
        '        xmlLanNode = xmlLanNode.NextSibling
        '    End If

        '    intNodeCount += 1
        '    If intNodeCount = 25 Then Exit Do
        'Loop

        'Dim intN As Integer = 0
        'Dim ObjectArray(3, intN) As String
        'intN = -1

        'For Each xmlEmlement In xmlLanNode.ChildNodes
        '    intN += 1
        '    ReDim Preserve ObjectArray(3, intN)
        '    ObjectArray(1, intN) = xmlEmlement.Attributes.GetNamedItem("Name").Value
        '    ObjectArray(2, intN) = xmlEmlement.Attributes.GetNamedItem("Type").Value
        '    ObjectArray(3, intN) = xmlEmlement.InnerText
        'Next
        ''MessageBox.Show(intN)
        'xmlLanNode = Nothing

        'For intCount As Integer = 0 To intN
        '    Select Case ObjectArray(2, intCount)
        '        Case "Text"
        '            FindTextControl(ctrl, ObjectArray(1, intCount), ObjectArray(3, intCount))
        '        Case "List"
        '            Dim strName As String = ObjectArray(1, intCount)
        '            'MessageBox.Show(strLeft(strName, strName.IndexOf("_")) & vbCrLf & strRight(strName, strName.Length - (strName.IndexOf("_") + 1)))
        '            FindListControl(ctrl, strLeft(strName, strName.IndexOf("_")), strRight(strName, strName.Length - (strName.IndexOf("_") + 1)), ObjectArray(3, intCount))
        '        Case "Menu"
        '            Select Case ctrl.Name
        '                Case "frmTrackManager"
        '                    FindTrackMenu(ObjectArray(1, intCount), ObjectArray(3, intCount))
        '            End Select
        '        Case "Prop"
        '            FindLanString(ObjectArray(1, intCount), ObjectArray(3, intCount))
        '    End Select
        'Next

    End Sub

    Friend Sub WriteTextControl(ByVal Container As Control)
        Dim ctrl As Control
        For Each ctrl In Container.Controls
            If Not (ctrl.Name = "TimeBoxArray" Or ctrl.Name = "BarBoxArray" Or ctrl.Name = "ClientBoxArray" Or ctrl.Name = "TeacherBoxArray") Then
                WriteLog(ctrl.Name, 0)
                If ctrl.HasChildren Then WriteTextControl(ctrl)
            End If
        Next
    End Sub

    Friend Sub FindTextControl(ByVal Container As Control, ByVal strName As String, ByVal strValue As String)
        If Container.Name = strName Then
            Container.Text = strValue
            Container.Tag = strValue
            Exit Sub
        End If
        Dim ctrl As Control
        For Each ctrl In Container.Controls
            If Not (ctrl.Name = "TimeBoxArray" Or ctrl.Name = "BarBoxArray" Or ctrl.Name = "ClientBoxArray" Or ctrl.Name = "TeacherBoxArray") Then
                'WriteLog(ctrl.Name, 0)
                If ctrl.Name = strName Then
                    ctrl.Text = strValue
                    ctrl.Tag = strValue
                    Exit Sub
                End If
                If ctrl.HasChildren Then FindTextControl(ctrl, strName, strValue)
            End If
            'If ctrl.Tag.ToString = "btnAppRemove" Then
            If Container.Name = "lvwButtons" Then
                MessageBox.Show("Found It " & ctrl.Tag)
            End If
        Next
    End Sub

    Friend Sub FindAllControls(ByVal Container As Control, dtsdata As DataSet)

        Dim strName As String = Nothing
        For intRowCount = 0 To dtsdata.Tables(0).Rows.Count - 1
            If dtsdata.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If Container.Name = dtsdata.Tables(0).Rows(intRowCount).Item("LanguageItem") Then
                    strName = dtsdata.Tables(0).Rows(intRowCount).Item("LanguageText")
                    Exit For
                End If
            End If
        Next
        If strName = Nothing Then
            WriteLog("Object not found: " & Container.Name, 3)
        Else
            Container.Name = strName
            strName = Nothing
        End If

        For Each ctrl As Control In Container.Controls
            If Not (ctrl.Name = "TimeBoxArray" Or ctrl.Name = "BarBoxArray" Or ctrl.Name = "ClientBoxArray" Or ctrl.Name = "TeacherBoxArray") Then
                'WriteLog(ctrl.Name, 0)
                For intRowCount = 0 To dtsdata.Tables(0).Rows.Count - 1
                    If dtsdata.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                        'MessageBox.Show("Cell Must be empty")
                    Else
                        If ctrl.Name = dtsdata.Tables(0).Rows(intRowCount).Item("LanguageItem") Then
                            strName = dtsdata.Tables(0).Rows(intRowCount).Item("LanguageText")
                            Exit For
                        End If
                    End If
                Next
                If strName = Nothing Then
                    WriteLog("Object not found: " & ctrl.Name, 3)
                Else
                    ctrl.Name = strName
                    strName = Nothing
                End If
                If ctrl.HasChildren Then FindAllControls(ctrl, dtsdata)
            End If
        Next
    End Sub

    Friend Sub FindListControl(ByVal Container As Control, ByVal strName As String, ByVal strCol As String, ByVal strValue As String)
        Dim ctrl As Control
        For Each ctrl In Container.Controls
            If Not (ctrl.Name = "TimeBoxArray" Or ctrl.Name = "BarBoxArray" Or ctrl.Name = "ClientBoxArray" Or ctrl.Name = "TeacherBoxArray") Then
                'WriteLog(ctrl.Name, 0)
                If ctrl.Name = strName Then
                    Dim lvwControl As ListView = ctrl
                    For Each column In lvwControl.Columns()
                        If column.tag = strCol Or column.name = strCol Then
                            column.text = strValue
                        End If
                    Next
                End If
                If ctrl.HasChildren Then FindListControl(ctrl, strName, strCol, strValue)
            End If
        Next
    End Sub

    Friend Sub FindListItemControl(ByVal Container As Control, ByVal strName As String, ByVal strItem As String, ByVal strValue As String)
        Dim ctrl As Control
        For Each ctrl In Container.Controls
            If Not (ctrl.Name = "TimeBoxArray" Or ctrl.Name = "BarBoxArray" Or ctrl.Name = "ClientBoxArray" Or ctrl.Name = "TeacherBoxArray") Then
                'WriteLog(ctrl.Name, 0)
                If ctrl.Name = strName Then
                    Dim lvwControl As ListView = ctrl
                    For Each Item In lvwControl.Items()
                        If Item.tag = strItem Or Item.name = strItem Then
                            Item.text = strValue
                        End If
                    Next
                    'For Each item In lvwControl.Items()
                    '    If item.tag = strCol Or item.name = strCol Then
                    '        item.text = strValue
                    '    End If
                    'Next
                End If
                If ctrl.HasChildren Then FindListItemControl(ctrl, strName, strItem, strValue)
            End If
        Next
    End Sub

    Public Sub FindTrackMenu(ByVal strName As String, ByVal strValue As String)
        Select Case strName
            Case "mnuMainFile"
                frmTrackManager.mnuMainFile.Text = strValue
            Case "mnuMainFileLogOff"
                frmTrackManager.mnuMainFileLogoff.Text = strValue
            Case "mnuMainFileReload"
                frmTrackManager.mnuMainFileReload.Text = strValue
            Case "mnuMainFileExit"
                frmTrackManager.mnuMainFileExit.Text = strValue
            Case "mnuMainEdit"
                frmTrackManager.mnuMainEdit.Text = strValue
            Case "mnuMainEditDay"
                frmTrackManager.mnuMainEditDay.Text = strValue
            Case "mnuMainEditTrack"
                frmTrackManager.mnuMainEditTrack.Text = strValue
            Case "mnuMainEditHour"
                frmTrackManager.mnuMainEditHour.Text = strValue
            Case "mnuMainEditClearAllLocks"
                frmTrackManager.mnuMainEditClearAllLocks.Text = strValue
            Case "mnuMainEditScreen"
                frmTrackManager.mnuMainEditScreen.Text = strValue
            Case "mnuMainWindow"
                frmTrackManager.mnuMainWindow.Text = strValue
            Case "mnuMainWindowSettings"
                frmTrackManager.mnuMainWindowSettings.Text = strValue
            Case "mnuMainWindowSecurity"
                frmTrackManager.mnuMainWindowSecurity.Text = strValue
            Case "mnuMainWindowGroups"
                frmTrackManager.mnuMainWindowGroups.Text = strValue
            Case "mnuMainWindowClients"
                frmTrackManager.mnuMainWindowClients.Text = strValue
            Case "mnuMainWindowFinance"
                frmTrackManager.mnuMainWindowFinance.Text = strValue
            Case "mnuMainHelp"
                frmTrackManager.mnuMainHelp.Text = strValue
            Case "mnuMainHelpManual"
                frmTrackManager.mnuMainHelpManual.Text = strValue
            Case "mnuMainHelpAbout"
                frmTrackManager.mnuMainHelpAbout.Text = strValue
            Case "mnuMainHelpUpdates"
                frmTrackManager.mnuMainHelpUpdates.Text = strValue
            Case "mnuRepFile"
                frmTrackManager.mnuRepFile.Text = strValue
            Case "mnuRepFileOpen"
                frmTrackManager.mnuRepFileOpen.Text = strValue
            Case "mnuRepFileSave"
                frmTrackManager.mnuRepFileSave.Text = strValue
            Case "mnuRepFilePrint"
                frmTrackManager.mnuRepFilePrint.Text = strValue
                'Case "mnuRepFilePrintPreview"
                '    frmTrackManager.mnuRepFilePrintPreview.Text = strValue
            Case "mnuRepFileNew"
                frmTrackManager.mnuRepFileNew.Text = strValue
            Case "mnuRepFileRefresh"
                frmTrackManager.mnuRepFileRefresh.Text = strValue
            Case "mnuRepEdit"
                frmTrackManager.mnuRepEdit.Text = strValue
            Case "mnuRepEditFont"
                frmTrackManager.mnuRepEditFont.Text = strValue
        End Select

    End Sub

    Friend Sub FindLanString(ByVal strName As String, ByVal strValue As String)
        For Each p As System.Reflection.PropertyInfo In lanStrings.GetType().GetProperties()
            'If p.CanRead Then
            '	MessageBox.Show(p.Name & p.GetValue(p, Nothing))
            'End If
            If p.CanWrite Then
                If p.Name = strName Then
                    p.SetValue(lanStrings, strValue, Nothing)
                End If
            End If
        Next

    End Sub

#End Region

#Region "Colors"

    Friend Enum KnownColor
        AliceBlue
        AntiqueWhite
        Aqua
        Aquamarine
        Azure
        Beige
        Bisque
        Black
        BlanchedAlmond
        Blue
        BlueViolet
        Brown
        BurlyWood
        CadetBlue
        Chocolate
        Coral
        Cornsilk
        Crimson
        Cyan
        DarkBlue
        DarkCyan
        DarkGoldenrod
        DarkGray
        DarkGreen
        DarkKhaki
        DarkMagenta
        DarkOliveGreen
        DarkOrange
        DarkOrchid
        DarkRed
        DarkSalmon
        DarkSeaGreen
        DarkSlateBlue
        DarkSlateGray
        DarkTurquoise
        DarkViolet
        DeepPink
        DeepSkyBlue
        DimGray
        DodgerBlue
        Firebrick
        FloralWhite
        ForestGreen
        Fuchsia
        Gainsboro
        GhostWhite
        Gold
        Goldenrod
        Gray
        GrayText
        Green
        GreenYellow
        Honeydew
        HotPink
        HotTrack
        IndianRed
        Indigo
        Ivory
        Khaki
        Lavender
        LavenderBlush
        LawnGreen
        LemonChiffon
        LightBlue
        LightCoral
        LightCyan
        LightGoldenrodYellow
        LightGray
        LightGreen
        LightPink
        LightSalmon
        LightSeaGreen
        LightSkyBlue
        LightSlateGray
        LightSteelBlue
        LightYellow
        Lime
        LimeGreen
        Linen
        Magenta
        Maroon
        MediumAquamarine
        MediumBlue
        MediumOrchid
        MediumPurple
        MediumSeaGreen
        MediumSlateBlue
        MediumSpringGreen
        MediumTurquoise
        MediumVioletRed
        MidnightBlue
        MintCream
        MistyRose
        Moccasin
        NavajoWhite
        Navy
        OldLace
        Olive
        OliveDrab
        Orange
        OrangeRed
        Orchid
        PaleGoldenrod
        PaleGreen
        PaleTurquoise
        PaleVioletRed
        PapayaWhip
        PeachPuff
        Peru
        Pink
        Plum
        PowderBlue
        Purple
        Red
        RosyBrown
        RoyalBlue
        SaddleBrown
        Salmon
        SandyBrown
        SeaGreen
        SeaShell
        Sienna
        Silver
        SkyBlue
        SlateBlue
        SlateGray
        Snow
        SpringGreen
        SteelBlue
        Tan
        Teal
        Thistle
        Tomato
        Turquoise
        Violet
        Wheat
        White
        WhiteSmoke
        Yellow
        YellowGreen
    End Enum

    'Friend Function ChooseBackColors(ByVal dtmTime As DateTime) As System.Drawing.Color
    '    If CurVar.OpeningHours = CurVar.ClosingHours Then
    '        ChooseBackColors = CurVar.OnHoursColor
    '    ElseIf CurVar.OpeningHours < CurVar.ClosingHours Then
    '        If dtmTime < CurVar.OpeningHours Then
    '            ChooseBackColors = CurVar.OffHoursColor
    '        ElseIf dtmTime = CurVar.OpeningHours Then
    '            ChooseBackColors = CurVar.OnHoursColor
    '        ElseIf dtmTime > CurVar.OpeningHours And dtmTime < CurVar.ClosingHours Then
    '            ChooseBackColors = CurVar.OnHoursColor
    '        ElseIf dtmTime = CurVar.ClosingHours Then
    '            ChooseBackColors = CurVar.OffHoursColor
    '        ElseIf dtmTime > CurVar.ClosingHours Then
    '            ChooseBackColors = CurVar.OffHoursColor
    '        End If

    '    ElseIf CurVar.OpeningHours > CurVar.ClosingHours Then
    '        If dtmTime < CurVar.ClosingHours Then
    '            ChooseBackColors = CurVar.OnHoursColor
    '        ElseIf dtmTime = CurVar.ClosingHours Then
    '            ChooseBackColors = CurVar.OffHoursColor
    '        ElseIf dtmTime > CurVar.ClosingHours And dtmTime < CurVar.OpeningHours Then
    '            ChooseBackColors = CurVar.OffHoursColor
    '        ElseIf dtmTime = CurVar.OpeningHours Then
    '            ChooseBackColors = CurVar.OnHoursColor
    '        ElseIf dtmTime > CurVar.OpeningHours Then
    '            ChooseBackColors = CurVar.OnHoursColor
    '        End If
    '    End If
    'End Function

    Friend Function ChooseBackColor(ByVal intTime As Integer) As System.Drawing.Color
        If CurVar.OpeningHour = CurVar.ClosingHour Then
            ChooseBackColor = CurVar.OnHoursColor
        ElseIf CurVar.OpeningHour < CurVar.ClosingHour Then
            If intTime < CurVar.OpeningHour Then
                ChooseBackColor = CurVar.OffHoursColor
            ElseIf intTime = CurVar.OpeningHour Then
                ChooseBackColor = CurVar.OnHoursColor
            ElseIf intTime > CurVar.OpeningHour And intTime < CurVar.ClosingHour Then
                ChooseBackColor = CurVar.OnHoursColor
            ElseIf intTime = CurVar.ClosingHour Then
                ChooseBackColor = CurVar.OffHoursColor
            ElseIf intTime > CurVar.ClosingHour Then
                ChooseBackColor = CurVar.OffHoursColor
            End If

        ElseIf CurVar.OpeningHour > CurVar.ClosingHour Then
            If intTime < CurVar.ClosingHour Then
                ChooseBackColor = CurVar.OnHoursColor
            ElseIf intTime = CurVar.ClosingHour Then
                ChooseBackColor = CurVar.OffHoursColor
            ElseIf intTime > CurVar.ClosingHour And intTime < CurVar.OpeningHour Then
                ChooseBackColor = CurVar.OffHoursColor
            ElseIf intTime = CurVar.OpeningHour Then
                ChooseBackColor = CurVar.OnHoursColor
            ElseIf intTime > CurVar.OpeningHour Then
                ChooseBackColor = CurVar.OnHoursColor
            End If
        End If
    End Function

    Friend Function ColorBackSet(ByVal clrARGB As System.Drawing.Color, ByVal intDarker As Integer) As System.Drawing.Color
        intDarker = intDarker * 5
        If clrARGB.R > intDarker Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R - intDarker, clrARGB.G, clrARGB.B)
        Else
            clrARGB = Color.FromArgb(clrARGB.A, 0, clrARGB.G, clrARGB.B)
        End If
        If clrARGB.G > intDarker Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G - intDarker, clrARGB.B)
        Else
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, 0, clrARGB.B)
        End If
        If clrARGB.B > intDarker Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G, clrARGB.B - intDarker)
        Else
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G, 0)
        End If
        ColorBackSet = clrARGB
    End Function

    Friend Function ColorFrontSet(ByVal clrARGB As System.Drawing.Color) As System.Drawing.Color
        If (clrARGB.R < 150 And clrARGB.G < 150) Or (clrARGB.R < 150 And clrARGB.B < 150) Or (clrARGB.G < 150 And clrARGB.B < 150) Then
            ColorFrontSet = Color.White
        Else
            ColorFrontSet = Color.Black
        End If
        'If clrARGB.R < 100 Or clrARGB.G < 100 Or clrARGB.B < 100 Then
        '	ColorFrontSet = Color.White
        'Else
        '	ColorFrontSet = Color.Black
        '	'MessageBox.Show(newARGB.R & " " & newARGB.G & " " & newARGB.B)
        'End If
    End Function

    Friend Function ColorDark(ByVal clrARGB As System.Drawing.Color) As System.Drawing.Color
        If clrARGB.R > 10 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R - 10, clrARGB.G, clrARGB.B)
        End If
        If clrARGB.G > 10 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G - 10, clrARGB.B)
        End If
        If clrARGB.B > 10 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G, clrARGB.B - 10)
        End If
        ColorDark = clrARGB
    End Function

    Friend Function ColorLight(ByVal clrARGB As System.Drawing.Color) As System.Drawing.Color
        If clrARGB.R < 245 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R + 10, clrARGB.G, clrARGB.B)
        End If
        If clrARGB.G < 245 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G + 10, clrARGB.B)
        End If
        If clrARGB.B < 245 Then
            clrARGB = Color.FromArgb(clrARGB.A, clrARGB.R, clrARGB.G, clrARGB.B + 10)
        End If
        ColorLight = clrARGB
    End Function

#End Region

#Region "Formatting"
    Friend Function FormatDateTimeSec(ByVal dtmInput As Date) As String
        If dtmInput = Nothing Then
            FormatDateTimeSec = ""
        Else
            FormatDateTimeSec = Format(dtmInput.Year, "0000") & "-" & Format(dtmInput.Month, "00") & "-" & Format(dtmInput.Day, "00") & " " & Format(dtmInput.Hour, "00") & ":" & Format(dtmInput.Minute, "00") & ":" & Format(dtmInput.Second, "00")
        End If
    End Function

    Friend Function FormatDateTime(ByVal dtmInput As Date) As String
        If dtmInput = Nothing Then
            FormatDateTime = ""
        Else
            FormatDateTime = Format(dtmInput.Year, "0000") & "-" & Format(dtmInput.Month, "00") & "-" & Format(dtmInput.Day, "00") & " " & Format(dtmInput.Hour, "00") & ":" & Format(dtmInput.Minute, "00")
        End If
    End Function

    Friend Function FormatDate(ByVal dtmInput As Date) As String
        If dtmInput = Nothing Then
            FormatDate = ""
        Else
            FormatDate = Format(dtmInput.Year, "0000") & "-" & Format(dtmInput.Month, "00") & "-" & Format(dtmInput.Day, "00")
        End If
    End Function

    Friend Function FormatGroupNumber(ByVal dtmInput As Date) As Double
        FormatGroupNumber = Format(dtmInput.Year, "0000") & Format(dtmInput.Month, "00") & Format(dtmInput.Day, "00") & Format(dtmInput.Hour, "00") & Format(dtmInput.Minute, "00") & Format(dtmInput.Second, "00")
    End Function

    Friend Function FormatLenght(ByVal strInput As String, ByVal intLenght As Integer, ByVal strType As String) As String
        Select Case strType
            '2010-10-09 00:00
            Case "Time"
                strInput = strInput.Substring(0, 2) & ":" & strInput.Substring(2, 2)
            Case "Date"
                strInput = strInput.Substring(8, 2) & "-" & strInput.Substring(5, 2) & "-" & strInput.Substring(0, 4)
            Case "DateTime"
                strInput = strInput.Substring(8, 2) & "-" & strInput.Substring(5, 2) & "-" & strInput.Substring(0, 4) & " " & strInput.Substring(11, 2) & ":" & strInput.Substring(14, 2)
            Case "DayDateTime"
                strInput = strInput.Substring(0, 2) & " " & strInput.Substring(11, 2) & "-" & strInput.Substring(8, 2) & "-" & strInput.Substring(3, 4) & " " & strInput.Substring(14, 2) & ":" & strInput.Substring(17, 2)
            Case "DayDate"
                strInput = strInput.Substring(0, 2) & " " & strInput.Substring(11, 2) & "-" & strInput.Substring(8, 2) & "-" & strInput.Substring(3, 4)
        End Select
        Do While Len(strInput) < intLenght
            strInput &= " "
        Loop
        If Len(strInput) > intLenght Then strInput = strInput.Substring(0, intLenght)
        FormatLenght = strInput
    End Function

    Friend Function strLeft(ByVal strInput As String, ByVal intLength As Integer)
        If strInput.Length > intLength And intLength > 0 Then
            strLeft = strInput.Substring(0, intLength)
        Else
            strLeft = strInput
        End If
    End Function

    Friend Function strRight(ByVal strInput As String, ByVal intLength As Integer)
        If strInput.Length > intLength And intLength > 0 Then
            strRight = strInput.Substring(strInput.Length - intLength, intLength)
        Else
            strRight = strInput
        End If

    End Function

    Friend Function FormatDecimal(ByVal strInput As String) As String
        'MessageBox.Show(", = " & InStr(strInput, ",") & vbNewLine & ". = " & InStr(strInput, "."))
        Dim decResult As Decimal
        If Decimal.TryParse(strInput, decResult) = False Then
            Return Nothing
        End If
        'If DebugMode Then MessageBox.Show("decResult: " & decResult)
        strInput = Replace(decResult, ",", ".")
        'If DebugMode Then MessageBox.Show("strInput: " & strInput)
        Return strInput
    End Function

    Friend Function FormatDecimalFromSingle(ByVal sinInput As Single) As Decimal
        'MessageBox.Show(", = " & InStr(strInput, ",") & vbNewLine & ". = " & InStr(strInput, "."))
        Dim decResult As Decimal
        If Decimal.TryParse(sinInput, decResult) = False Then
            Return Nothing
        End If
        'If DebugMode Then MessageBox.Show("decResult: " & decResult)
        'strInput = Replace(decResult, ",", ".")
        'If DebugMode Then MessageBox.Show("strInput: " & strInput)
        Return decResult
    End Function

    Friend Function FormatString(ByVal intInput As Integer, intLenght As Integer) As String
        Dim strInput As String = intInput.ToString
        Do While strInput.Length < intLenght
            strInput = "0" & strInput
        Loop
        Return strInput
    End Function

    Friend Function FormatMoney(ByVal sinInput As Single) As String
        Dim strInput As String = sinInput.ToString
        Dim intDecimal As String = strInput.LastIndexOf(".")
        If intDecimal = -1 Then
            strInput &= ".00"
        ElseIf Len(strInput) - intDecimal = 2 Then
            strInput &= "0"
        ElseIf Len(strInput) - intDecimal > 3 Then
            strInput = strInput.Substring(0, intDecimal + 2)
        End If
        Return strInput
    End Function

#End Region

#Region "security"
    Private lbtVector() As Byte = {240, 3, 45, 29, 0, 76, 173, 59}
    Private lscryptoKey As String = "ScubaFuzRulezIn2008"

    Friend Function psDecrypt(ByVal sQueryString As String) As String

        Dim buffer() As Byte
        Dim loCryptoClass As New TripleDESCryptoServiceProvider
        Dim loCryptoProvider As New MD5CryptoServiceProvider

        Try

            buffer = Convert.FromBase64String(sQueryString)
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey))
            loCryptoClass.IV = lbtVector
            Return Encoding.ASCII.GetString(loCryptoClass.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
        Catch ex As Exception
            Throw ex
        Finally
            loCryptoClass.Clear()
            loCryptoProvider.Clear()
            loCryptoClass = Nothing
            loCryptoProvider = Nothing
        End Try


    End Function
    'Author      :       Nikhil Gupta
    'Description :       This function encrypts a given string
    'Parameters  :       String
    'Return Values:      Encrypted String
    'Called From :       Business Layer
    Friend Function psEncrypt(ByVal sInputVal As String) As String

        Dim loCryptoClass As New TripleDESCryptoServiceProvider
        Dim loCryptoProvider As New MD5CryptoServiceProvider
        Dim lbtBuffer() As Byte

        Try
            lbtBuffer = System.Text.Encoding.ASCII.GetBytes(sInputVal)
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey))
            loCryptoClass.IV = lbtVector
            sInputVal = Convert.ToBase64String(loCryptoClass.CreateEncryptor().TransformFinalBlock(lbtBuffer, 0, lbtBuffer.Length()))
            psEncrypt = sInputVal
        Catch ex As CryptographicException
            Throw ex
        Catch ex As FormatException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            loCryptoClass.Clear()
            loCryptoProvider.Clear()
            loCryptoClass = Nothing
            loCryptoProvider = Nothing
        End Try
    End Function

    Friend Sub Logoff()
        CurUser.LoginID = 0
        CurUser.LoginName = "NoLogin"
        CurUser.Password = ""
        CurUser.LogonTime = Now
        CurUser.DateStart = Now.AddDays(1)
        CurUser.DateStop = Now.AddDays(-1)
        CurUser.Enabled = 0
        CurUser.SecurityAdd = 0
        CurUser.SecurityChange = 0
        CurUser.SecurityDelete = 0
        CurUser.SettingsAdd = 0
        CurUser.SettingsChange = 0
        CurUser.SettingsDelete = 0
        CurUser.FinanceAdd = 0
        CurUser.FinanceChange = 0
        CurUser.FinanceDelete = 0
        CurUser.GroupsDelete = 0
        CurUser.ClientsDelete = 0
    End Sub

#End Region

    Friend Function DgvToHtml(ByVal DgvInput As DataGridView) As StringBuilder
        Dim stbHtml As New StringBuilder
        stbHtml.AppendLine("<html><body><center><table border='1' cellpadding='0' cellspacing='0'>")
        stbHtml.AppendLine("<tr>")
        For i As Int16 = 0 To DgvInput.ColumnCount - 1
            stbHtml.AppendLine("<td align='center' valign='middle' width='" & DgvInput.Columns(i).Width & "'>" & DgvInput.Columns(i).HeaderText & "</td>")
        Next
        stbHtml.AppendLine("</tr>")

        For y As Integer = 0 To DgvInput.RowCount - 2
            stbHtml.AppendLine("<tr>")
            For Each dgvc As DataGridViewCell In DgvInput.Rows(y).Cells
                Dim strValue As String
                If dgvc.Value = Nothing Then strValue = "" Else strValue = dgvc.Value.ToString
                stbHtml.AppendLine("<td align='left' valign='middle'>" & strValue & "</td>")
            Next
            stbHtml.AppendLine("</tr>")
        Next

        stbHtml.AppendLine("</table></center></body></html>")

        Return stbHtml
    End Function

    Public Sub SendSMTP(ByVal strFromAddress As String, _
                        ByVal strFromName As String, _
                        ByVal strToAddress As String, _
                        ByVal strToName As String, _
                        ByVal strReplyToAddrr As String, _
                        ByVal strReplyToName As String, _
                        ByVal strSubject As String, _
                        ByVal strBody As String, _
                        ByVal strAttachments As String)

        Dim insMail As New MailMessage(New MailAddress(strFromAddress, strFromName), New MailAddress(strToAddress, strToName))
        With insMail
            .Subject = strSubject
            .Body = strBody
            '.ReplyTo = New MailAddress(strReplyToAddrr, strReplyToName)
            .IsBodyHtml = True
            If Not strAttachments.Equals(String.Empty) Then
                Dim strFile As String
                Dim strAttach() As String = strAttachments.Split(";")
                For Each strFile In strAttach
                    .Attachments.Add(New Attachment(strFile.Trim()))
                Next
            End If
        End With

        Dim smtp As New System.Net.Mail.SmtpClient(CurVar.SmtpServer)
        smtp.EnableSsl = CurVar.SmtpSsl
        smtp.Port = CurVar.SmtpPort
        If CurVar.SmtpCredentials = True Then
            smtp.UseDefaultCredentials = True
        Else
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(CurVar.SmtpUser, psDecrypt(CurVar.SmtpPassword))
        End If
        'smtp.Host = CurVar.SmtpServer
        smtp.Send(insMail)

    End Sub

    Public Sub SendOutlook(ByVal strToAddress As String, _
                        ByVal strToName As String, _
                        ByVal strSubject As String, _
                        ByVal strBody As String, _
                        ByVal strAttachments As String)
        Try
            Dim ol As New Outlook.Application()
            Dim ns As Outlook.NameSpace
            Dim fdMail As Outlook.MAPIFolder

            ns = ol.GetNamespace("MAPI")
            ns.Logon(, , True, True)

            'creating a new MailItem object
            Dim newMail As Outlook.MailItem

            'gets defaultfolder for my Outlook Outbox
            fdMail = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox)

            'assign values to the newMail MailItem
            newMail = fdMail.Items.Add(Outlook.OlItemType.olMailItem)
            newMail.Subject = strSubject
            'newMail.Body = strBody
            newMail.To = strToAddress
            newMail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            newMail.HTMLBody = strBody
            newMail.SaveSentMessageFolder = fdMail

            newMail.Send()

        Catch ex As Exception

            Throw ex

        End Try
    End Sub

    Friend Sub ClearOldLogs()
        If TxtHandle.LogLocation.ToLower = "database" Then
            If CurVar.LogDeleteAuto = True Then
                Dim dtmDate As Date = Today
                Select Case CurVar.LogDelete
                    Case "Day"
                        dtmDate = dtmDate.AddDays(-1)
                    Case "Week"
                        dtmDate = dtmDate.AddDays(-7)
                    Case "Month"
                        dtmDate = dtmDate.AddMonths(-1)
                    Case Else
                        Exit Sub
                End Select
                ClearDBLog(dtmDate)
            End If
        End If
    End Sub

    Public Function XMLToDataSet(ByVal xmlStr As String) As DataSet
        'Convert the XML to a dataset
        Dim sr As New IO.StringReader(xmlStr)

        'Convert xmlData to a Dataset
        Dim ds As New DataSet

        ds.ReadXml(sr)
       
        For Each relation As DataRelation In ds.Relations
            For Each c As DataColumn In relation.ParentColumns
                If Not relation.ChildTable.Columns.Contains(c.ColumnName) Then
                    relation.ChildTable.Columns.Add(c)
                End If
                For Each dr As DataRow In relation.ChildTable.Rows
                    dr(c.ColumnName) = dr.GetParentRow(relation)(c.ColumnName)
                Next
            Next
        Next

        Return ds
    End Function

    '

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As RegularExpressions.Match = RegularExpressions.Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function
End Module
