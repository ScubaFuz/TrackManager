Imports System.IO


Public Class DBRef
    Friend dbVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
    Friend intCounter As Integer

    Private Function AddOne() As Integer
        intCounter = intCounter + 1
        Return intCounter
    End Function

    Public Function GetList(Optional blnIncludeTables As Boolean = True) As Array
        Dim arrScripts(100) As String
        intCounter = 0


        If blnIncludeTables = False Then
            'Bogus startscript
            arrScripts(intCounter) = "01 Use TrackManager.sql"
        Else
            'Database
            arrScripts(intCounter) = "01 Create Database.sql"

            'Tables
            arrScripts(AddOne()) = "01 dbo.tbl_Arguments.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Config.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Groups.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Language.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_LessonTypes.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Levels.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Logging.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Logins.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_PaymentMethods.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_PrContacts.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Reports.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Tax.sql"
            arrScripts(AddOne()) = "01 dbo.tbl_Tracks.sql"
            arrScripts(AddOne()) = "02 dbo.tbl_Clients.sql"
            arrScripts(AddOne()) = "02 dbo.tbl_Memo.sql"
            arrScripts(AddOne()) = "02 dbo.tbl_Products.sql"
            arrScripts(AddOne()) = "02 dbo.tbl_ReportArguments.sql"
            arrScripts(AddOne()) = "02 dbo.tbl_ReportFields.sql"
            arrScripts(AddOne()) = "03 dbo.tbl_Appointment.sql"
            arrScripts(AddOne()) = "03 dbo.tbl_ClientLevels.sql"
            arrScripts(AddOne()) = "03 dbo.tbl_Invoice.sql"
            arrScripts(AddOne()) = "04 dbo.tbl_InvoiceLine.sql"
            arrScripts(AddOne()) = "04 dbo.tbl_InvoicePayment.sql"
        End If
        'Views
        'arrScripts(AddOne()) = "dbo.VIEW_ADRESSEN_LERAREN.View.sql"
        'arrScripts(AddOne()) = "dbo.VIEW_EMAILADRESSEN.View.sql"
        'arrScripts(AddOne()) = "dbo.VIEW_ZOEK_EMAILADRES.View.sql"

        'Functions
        arrScripts(AddOne()) = "dbo.udf_DateFormat.sql"
        arrScripts(AddOne()) = "dbo.udf_EmailDomain.sql"
        arrScripts(AddOne()) = "dbo.udf_EmailPrefix.sql"
        arrScripts(AddOne()) = "dbo.udf_GetAge.sql"
        arrScripts(AddOne()) = "dbo.udf_GetShowAge.sql"
        arrScripts(AddOne()) = "dbo.udf_FirstNameAge.sql"
        arrScripts(AddOne()) = "dbo.udf_LevelColorGet.sql"
        arrScripts(AddOne()) = "dbo.udf_ValidEmail.sql"
        arrScripts(AddOne()) = "dbo.udf_Weekday.sql"

        'Stored Procedures
        arrScripts(AddOne()) = "01 dbo.usp_AppointmentFinanceGet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_AppointmentHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_BackupHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ClientHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ClientLessonHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ClientLessonLevelGet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ClientLessonLevelGet2.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ConfigHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_CorrectLessonCount.sql"
        arrScripts(AddOne()) = "01 dbo.usp_DayAppGet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ProductHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_GroupHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_InvoiceHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_InvoiceLineHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_InvoicePaymentHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_LanguageHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_LanguageListGet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_LessonTypeHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_LevelHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_LoggingHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_MemoHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_PrContactHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_PrimaryContactSet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ReportArgumentHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ReportArgumentHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ReportFieldHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ReportFieldsGet.sql"
        arrScripts(AddOne()) = "01 dbo.usp_ReportHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_Search.sql"
        arrScripts(AddOne()) = "01 dbo.usp_TaxHandle.sql"
        arrScripts(AddOne()) = "01 dbo.usp_TrackHandle.sql"

        arrScripts(AddOne()) = "02 dbo.usp_AppointmentCreate.sql"
        arrScripts(AddOne()) = "02 dbo.usp_AppointmentDelete.sql"
        arrScripts(AddOne()) = "02 dbo.usp_AppointmentMove.sql"
        arrScripts(AddOne()) = "02 dbo.usp_AppointmentUpdate.sql"
        arrScripts(AddOne()) = "02 dbo.usp_FinanceHandle.sql"
        arrScripts(AddOne()) = "02 dbo.usp_LoginHandle.sql"

        If blnIncludeTables = True Then
            'Logins
            arrScripts(AddOne()) = "01 TrackMan Login.sql"
            arrScripts(AddOne()) = "02 TrackMan User.sql"
            arrScripts(AddOne()) = "03 TrackMan AddRole.sql"

            'Data
            'arrScripts(AddOne()) = "ClearReportTables.sql"
            'arrScripts(AddOne()) = "Correct Appointment LessonCount.sql"
            arrScripts(AddOne()) = "Insert Report Arguments.sql"
            arrScripts(AddOne()) = "WeekDays.sql"
            arrScripts(AddOne()) = "LogFile.sql"
        End If

        'Reports
        arrScripts(AddOne()) = "01 dbo.usp_Report_Lessons_Lessons.sql"
        arrScripts(AddOne()) = "02 dbo.usp_Report_Finance_OpenBills.sql"
        arrScripts(AddOne()) = "03 dbo.usp_Report_Finance_Payments.sql"
        arrScripts(AddOne()) = "04 dbo.usp_Report_Finance_Overbooked.sql"
        arrScripts(AddOne()) = "11 dbo.usp_Report_Other_Logfile.sql"
        arrScripts(AddOne()) = "12 dbo.usp_Report_Clients_EmailAddresses.sql"
        arrScripts(AddOne()) = "13 dbo.usp_Report_Lessons_Overview.sql"
        arrScripts(AddOne()) = "15 dbo.usp_Report_Lessons_Appointments.sql"

        'Report Data
        If blnIncludeTables = True Then
            arrScripts(AddOne()) = "01 Report_Lessons_Lessons Data.sql"
            arrScripts(AddOne()) = "02 Report_Finance_OpenBills Data.sql"
            arrScripts(AddOne()) = "03 Report_Finance_Payments Data.sql"
            arrScripts(AddOne()) = "04 Report_Finance_Overbooked Data.sql"
            arrScripts(AddOne()) = "11 Report_Other_Logfile Data.sql"
            arrScripts(AddOne()) = "12 Report_Clients_EmailAddresses Data.sql"
            arrScripts(AddOne()) = "13 Report_Lessons_Overview Data.sql"
            arrScripts(AddOne()) = "15 Report_Lessons_Appointments Data.sql"
        End If

        ReDim Preserve arrScripts(intCounter)

        Return arrScripts
        'Return intCounter
    End Function

    Public Function GetVersion(ByVal strVersion As String) As String

        Dim verDatabase As New Version(strVersion)
        If verDatabase.CompareTo(My.Application.Info.Version) = -1 Then
            'Upgrade database
            Dim verTM4001 As New Version("4.0.0.1")
            If verDatabase.CompareTo(verTM4001) = -1 Then
                Return "4.0.0.1"
            End If
            Dim verTM4006 As New Version("4.0.0.6")
            If verDatabase.CompareTo(verTM4006) = -1 Then
                Return "4.0.0.6"
            End If
            Dim verTM40020 As New Version("4.0.0.20")
            If verDatabase.CompareTo(verTM40020) = -1 Then
                Return "4.0.0.20"
            End If
            Dim verTM40024 As New Version("4.0.0.24")
            If verDatabase.CompareTo(verTM40024) = -1 Then
                Return "4.0.0.24"
            End If
            Dim verTM40030 As New Version("4.0.0.30")
            If verDatabase.CompareTo(verTM40030) = -1 Then
                Return "4.0.0.30"
            End If
            Dim verTM4012 As New Version("4.0.1.2")
            If verDatabase.CompareTo(verTM4012) = -1 Then
                Return "4.0.1.2"
            End If
            Dim verTM4013 As New Version("4.0.1.3")
            If verDatabase.CompareTo(verTM4013) = -1 Then
                Return "4.0.1.3"
            End If
            Dim verTM4020 As New Version("4.0.2.0")
            If verDatabase.CompareTo(verTM4020) = -1 Then
                Return "4.0.2.0"
            End If
            Dim verTM4030 As New Version("4.0.3.0")
            If verDatabase.CompareTo(verTM4030) = -1 Then
                Return "4.0.3.0"
            End If
            Dim verTM4041 As New Version("4.0.4.1")
            If verDatabase.CompareTo(verTM4041) = -1 Then
                Return "4.0.4.1"
            End If
            Dim verTM4101 As New Version("4.1.0.1")
            If verDatabase.CompareTo(verTM4101) = -1 Then
                Return "4.1.0.1"
            End If
            Dim verTM4110 As New Version("4.1.1.0")
            If verDatabase.CompareTo(verTM4110) = -1 Then
                Return "4.1.1.0"
            End If
            Dim verTM4123 As New Version("4.1.2.3")
            If verDatabase.CompareTo(verTM4123) = -1 Then
                Return "4.1.2.3"
            End If
            Dim verTM4130 As New Version("4.1.3.0")
            If verDatabase.CompareTo(verTM4130) = -1 Then
                Return "4.1.3.0"
            End If
            Dim verTM4144 As New Version("4.1.4.4")
            If verDatabase.CompareTo(verTM4144) = -1 Then
                Return "4.1.4.4"
            End If
            Dim verTM4150 As New Version("4.1.5.0")
            If verDatabase.CompareTo(verTM4150) = -1 Then
                Return "4.1.5.0"
            End If
            Dim verTM4160 As New Version("4.1.6.0")
            If verDatabase.CompareTo(verTM4160) = -1 Then
                Return "4.1.6.0"
            End If
            Dim verTM4170 As New Version("4.1.7.0")
            If verDatabase.CompareTo(verTM4170) = -1 Then
                Return "4.1.7.0"
            End If
            Dim verTM4202 As New Version("4.2.0.2")
            If verDatabase.CompareTo(verTM4202) = -1 Then
                Return "4.2.0.2"
            End If
        Else
            'Return strVersion
        End If

        Return Nothing
        'Return strVersion
    End Function

    Public Function GetNewList(ByVal strVersion As String) As Array
        Dim arrScripts(1, 100) As String
        intCounter = 0

        If strVersion = "4.0.0.1" Then
            'arrScripts(0, intCounter) = "dbo.StoredProcedure1"
            'arrScripts(1, intCounter) = "CREATE"
            'arrScripts(0, AddOne()) = "dbo.StoredProcedure2.sql"
            'arrScripts(1, intCounter) = "ALTER"
            'arrScripts(0, AddOne()) = "dbo.Drops.sql"
            'arrScripts(1, intCounter) = "DROP"
            'arrScripts(0, AddOne()) = "dbo.NewData.sql"
            'arrScripts(1, intCounter) = "INSERT"
            'arrScripts(0, AddOne()) = "dbo.UpdateVersion.sql"
            'arrScripts(1, intCounter) = "SELECT"
        End If

        If strVersion = "4.0.0.6" Then
            arrScripts(0, intCounter) = "16 Report_Lessons_Logfile Data.sql"
            arrScripts(1, intCounter) = "SELECT"
            arrScripts(0, AddOne()) = "17 dbo.usp_Report_Clients_Email_adressen.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "17 Report_Clients_Email_adressen Data.sql"
            arrScripts(1, intCounter) = "INSERT"
        End If

        If strVersion = "4.0.0.20" Then
            arrScripts(0, intCounter) = "Update40020A.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update40020B.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update40020C.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_AppointmentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentCreate.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentDelete.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentMove.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_DayAppGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoiceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Standard_OpenBills.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Standard_Payments.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.0.0.24" Then
            arrScripts(0, intCounter) = "01 dbo.usp_ReportArgumentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.0.0.30" Then
            arrScripts(0, intCounter) = "01 dbo.usp_DayAppGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.0.1.2" Then
            arrScripts(0, intCounter) = "Update4012A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.0.1.3" Then
            arrScripts(0, intCounter) = "Update4013A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "01 dbo.tbl_PaymentMethods.sql"
            arrScripts(1, intCounter) = "CREATE"
        End If

        If strVersion = "4.0.2.0" Then
            arrScripts(0, intCounter) = "Update4013A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "Update4015A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "01 dbo.tbl_PaymentMethods.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "18 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "18 Report_Lessons_Overview Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientLessonLevelGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientLessonLevelGet2.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Standard_Overbooked.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "04 Report_Standard_Overbooked Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "01 dbo.usp_ConfigHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentUpdate.sql"
            arrScripts(1, intCounter) = "CREATE"
        End If

        If strVersion = "4.0.3.0" Then
            arrScripts(0, intCounter) = "01 dbo.usp_AppointmentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientLessonHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ConfigHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_CorrectLessonCount.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_GroupHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoiceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoiceLineHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoicePaymentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_LessonTypeHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_LevelHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_MemoHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_PrContactHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ProductHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportArgumentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportFieldHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_TaxHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_TrackHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentCreate.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentDelete.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentMove.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_LoginHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Standard_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.0.4.1" Then
            arrScripts(0, intCounter) = "01 dbo.usp_ClientLessonHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_AppointmentDelete.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ProductHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_Report_Standard_Lessons.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "18 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Standard_OpenBills.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "03 dbo.usp_Report_Standard_Payments.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Standard_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "11 dbo.usp_Report_Lessons_Afspraken.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "12 dbo.usp_Report_Finance_Open_Facturen.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "13 dbo.usp_Report_Lessons_Maand_Overzicht.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "14 dbo.usp_Report_Finance_Betalingen_Dag.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportFieldHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.1.0.1" Then
            arrScripts(0, intCounter) = "Update4100A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "Update4100B.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "ClearReportTables.sql"
            arrScripts(1, intCounter) = "UPDATE"

            arrScripts(0, AddOne()) = "01 dbo.tbl_Language.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_LanguageHandle.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_LanguageListGet.sql"
            arrScripts(1, intCounter) = "CREATE"

            arrScripts(0, AddOne()) = "dbo.udf_Weekday.sql"
            arrScripts(1, intCounter) = "ALTER"

            arrScripts(0, AddOne()) = "01 dbo.usp_ReportArgumentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportFieldsGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ReportHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_MemoHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_AppointmentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoiceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_CorrectLessonCount.sql"
            arrScripts(1, intCounter) = "ALTER"

            arrScripts(0, AddOne()) = "01 dbo.usp_Report_Lessons_Lessons.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 Report_Lessons_Lessons Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Finance_OpenBills.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "02 Report_Finance_OpenBills Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "03 dbo.usp_Report_Finance_Payments.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "03 Report_Finance_Payments Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Finance_Overbooked.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "04 Report_Finance_Overbooked Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "11 dbo.usp_Report_Other_Logfile.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "11 Report_Other_Logfile Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "12 dbo.usp_Report_Clients_EmailAddresses.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "12 Report_Clients_EmailAddresses Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "13 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "13 Report_Lessons_Overview Data.sql"
            arrScripts(1, intCounter) = "INSERT"
        End If

        If strVersion = "4.1.1.0" Then
            arrScripts(0, intCounter) = "15 dbo.usp_Report_Lessons_Appointments.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "15 Report_Lessons_Appointments Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "01 dbo.usp_Report_Lessons_Lessons.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Finance_OpenBills.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Finance_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "13 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_LanguageHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.1.2.3" Then
            arrScripts(0, intCounter) = "02 dbo.usp_AppointmentUnDelete.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "05 dbo.usp_Report_Finance_Underbooked.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "05 Report_Finance_Underbooked Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "16 dbo.usp_Report_Finance_Invoices.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "16 Report_Finance_Invoices Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "17 dbo.usp_Report_Finance_Products.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "17 Report_Finance_Products Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "18 dbo.usp_Report_Lessons_Children.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "18 Report_Lessons_Children Data.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update4120A.sql"
            arrScripts(1, intCounter) = "UPDATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_AppointmentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_LanguageListGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "15 dbo.usp_Report_Lessons_Appointments.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_Report_Lessons_Lessons.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Finance_OpenBills.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Finance_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "13 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "dbo.udf_GetAge.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_CorrectLessonCount.sql"
            arrScripts(1, intCounter) = "ALTER"

        End If

        If strVersion = "4.1.3.0" Then
            arrScripts(0, intCounter) = "01 dbo.usp_AppointmentHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.1.4.4" Then
            arrScripts(0, intCounter) = "dbo.udf_GetShowAge.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.tbl_AppType.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "dbo.udf_GetAge.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "dbo.udf_FirstNameAge.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientLessonLevelGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_DayAppGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_AppointmentFinanceGet.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "Update4140A.sql"
            arrScripts(1, intCounter) = "INSERT"
        End If

        If strVersion = "4.1.5.0" Then
            arrScripts(0, intCounter) = "01 dbo.usp_DayAppGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "Update4150A.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "dbo.udf_DateFormat.sql"
            arrScripts(1, intCounter) = "CREATE"
            arrScripts(0, AddOne()) = "01 dbo.usp_Report_Lessons_Lessons.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_Report_Finance_OpenBills.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "03 dbo.usp_Report_Finance_Payments.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "13 dbo.usp_Report_Lessons_Overview.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "15 dbo.usp_Report_Lessons_Appointments.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "16 dbo.usp_Report_Finance_Invoices.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "17 dbo.usp_Report_Finance_Products.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "18 dbo.usp_Report_Lessons_Children.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "Update4160A.sql"
            arrScripts(1, intCounter) = "INSERT"
            'arrScripts(0, AddOne()) = "dbo.UpdateVersion.sql"
            'arrScripts(1, intCounter) = "SELECT"
        End If

        If strVersion = "4.1.6.0" Then
            arrScripts(0, intCounter) = "Update4160A.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update4160B.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update4160C.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "Update4160D.sql"
            arrScripts(1, intCounter) = "INSERT"
            arrScripts(0, AddOne()) = "01 dbo.usp_ClientLessonLevelGet.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "02 dbo.usp_FinanceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "01 dbo.usp_InvoiceHandle.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "11 dbo.usp_Report_Other_Logfile.sql"
            arrScripts(1, intCounter) = "ALTER"
            arrScripts(0, AddOne()) = "04 dbo.usp_Report_Finance_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.1.7.0" Then
            arrScripts(0, intCounter) = "dbo.udf_GetAge.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        If strVersion = "4.2.0.2" Then
            arrScripts(0, intCounter) = "04 dbo.usp_Report_Finance_Overbooked.sql"
            arrScripts(1, intCounter) = "ALTER"
        End If

        ReDim Preserve arrScripts(1, intCounter)
        Return arrScripts
        'Return intCounter
    End Function

    Public Function GetScript(ByVal strScriptName As String) As String
        Dim myAssembly As System.Reflection.Assembly
        myAssembly = Me.GetType.Assembly
        'Dim MydbRef As New TMDB.DBRef
        'myAssembly = System.Reflection.Assembly.GetAssembly(MydbRef.GetType)

        'Dim name As String = "TMDB.01 Create Database.sql"
        strScriptName = "TMDB." & strScriptName
        Dim returnValue As Stream
        returnValue = myAssembly.GetManifestResourceStream(strScriptName)

        If returnValue Is Nothing Then Return "-1"

        Dim stream_reader As New System.IO.StreamReader(returnValue)
        Return (stream_reader.ReadToEnd())
        stream_reader.Close()

    End Function

    Private Function ParseVersion(ByVal strVersion As String) As Version
        Dim dbMajor As String = "0"
        Dim dbMinor As String = "0"
        Dim dbBuild As String = "0"
        Dim dbRevision As String = "0"
        Dim intpoint0 As Integer
        Dim intPoint1 As Integer
        Dim intPoint2 As Integer

        intpoint0 = strVersion.LastIndexOf(".")

        intPoint1 = 0
        intPoint2 = strVersion.IndexOf(".", intPoint1)
        If intPoint2 = -1 Then intPoint2 = strVersion.Length
        dbMajor = strVersion.Substring(intPoint1, intPoint2 - intPoint1)

        intPoint1 = intPoint2 + 1
        If intPoint1 < strVersion.Length Then
            intPoint2 = strVersion.IndexOf(".", intPoint1)
            If intPoint2 = -1 Then intPoint2 = strVersion.Length
            dbMinor = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
        End If

        intPoint1 = intPoint2 + 1
        If intPoint1 < strVersion.Length Then
            intPoint2 = strVersion.IndexOf(".", intPoint1)
            If intPoint2 = -1 Then intPoint2 = strVersion.Length
            dbBuild = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
        End If

        intPoint1 = intPoint2 + 1
        If intPoint1 < strVersion.Length Then
            intPoint2 = strVersion.Length
            If intPoint2 = -1 Then intPoint2 = strVersion.Length
            dbRevision = strVersion.Substring(intPoint1, intPoint2 - intPoint1)
        End If

        Dim verDatabase As New Version(dbMajor, dbMinor, dbBuild, dbRevision)
        Return verDatabase
    End Function
End Class
