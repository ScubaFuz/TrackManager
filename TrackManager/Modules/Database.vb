Module Database

	Friend Function QueryDb(ByVal strQueryData As String, ByVal ReturnValue As Boolean) As DataSet
        WriteLog(strQueryData, 5)

        Dim dtsData As DataSet
        Try
            dtsData = DbHandle.QueryDatabase(strQueryData, ReturnValue)
            Return dtsData
        Catch ex As Exception
            WriteLog(ex.Message, 1)
            If blnDatabaseOnLine Then
                MessageBox.Show(lanStrings.strDataError & vbCrLf & lanStrings.strCheckLog)
                WriteLog(lanStrings.strDataError, 1)
                blnDatabaseOnLine = False
            End If
            Return Nothing
        End Try
    End Function

	Private Sub GetData()
		If DebugMode Then
			strQuery = "Select <Value> from <table> where <Column> = <Value>"
            Dim dtsData As DataSet
            dtsData = QueryDb(strQuery, True)
            If dtsData Is Nothing Then Exit Sub
            If dtsData.Tables.Count = 0 Then Exit Sub
            For intRowCount = 0 To dtsData.Tables(0).Rows.Count - 1
                If dtsData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    MessageBox.Show(dtsData.Tables(0).Rows(intRowCount).Item(0))
                End If
            Next
        End If
	End Sub

	Friend Sub LoadLogSettings()
		'		strQuery = "Select ConfigName, ConfigValue from tbl_config where Category = 'LogFile'"
		strQuery = "exec usp_ConfigHandle 'Get','LogFile'"
		Dim objData As DataSet
		Try
			objData = DbHandle.QueryDatabase(strQuery, True)
			For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
				If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
					'MessageBox.Show("Cell Must be empty")
				Else
					If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = "LogLocation" Then TxtHandle.LogLocation = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
					If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = "LogFileName" Then TxtHandle.LogFileName = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
					If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = "LogLevel" Then TxtHandle.LogLevel = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = "LogDelete" Then CurVar.LogDelete = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = "LogDeleteAuto" Then CurVar.LogDeleteAuto = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                End If
			Next
        Catch ex As Exception
            If DebugMode Then
                MessageBox.Show("Reading Loglocation Failed " & vbCrLf & ex.Message)
            End If
            WriteLog(ex.Message, 1)
            If blnDatabaseOnLine Then
                MessageBox.Show(lanStrings.strDataError & vbCrLf & lanStrings.strCheckLog)
                WriteLog(lanStrings.strDataError, 1)
                blnDatabaseOnLine = False
            End If
		End Try

        If TxtHandle.LogLocation.ToLower <> "database" And TxtHandle.CheckDir(TxtHandle.LogLocation) = False Then
            TxtHandle.LogFileName = "TrackManData.Log"
            TxtHandle.LogLevel = 5
            TxtHandle.LogLocation = Application.StartupPath & "\LOG"
        End If

        'If DebugMode Then
        '          MessageBox.Show("TrackManager v " & Application.ProductVersion & " application start" & vbCrLf _
        '           & "   Licensed to: " & strLicenseName & vbCrLf _
        '           & "   " & vbCrLf _
        '           & "   DatabaseServer = " & DbHandle.DataLocation & vbCrLf _
        '           & "   DatabaseName = " & DbHandle.DatabaseName & vbCrLf _
        '           & "   DataProvider = " & DbHandle.DataProvider & vbCrLf _
        '           & "   LoginMethod = " & DbHandle.LoginMethod & vbCrLf _
        '           & "   " & vbCrLf _
        '           & "   LogLocation = " & TxtHandle.LogLocation & vbCrLf _
        '           & "   LogFileName = " & TxtHandle.LogFileName & vbCrLf _
        '           & "   LogLevel = " & TxtHandle.LogLevel & vbCrLf _
        '           & "   LogDelete = " & CurVar.LogDelete & vbCrLf _
        '           & "   LogDeleteAuto = " & CurVar.LogDeleteAuto & vbCrLf _
        '           & "   " & vbCrLf _
        '           & "   Running in Debug Mode")
        'End If
		WriteLog("**********************************************************", 1)
		WriteLog("TrackManager v " & Application.ProductVersion & " application start", 1)
		WriteLog("**********************************************************", 1)
	End Sub

	Friend Sub SaveConfigSetting(ByVal strCategory As String, ByVal strConfigName As String, ByVal strConfigValue As String, Optional ByVal strRemarks As String = Nothing)
		strQuery = "exec usp_ConfigHandle 'Smt','" & strCategory & "',NULL,'" & strConfigName & "','" & strConfigValue & "','" & Now.Year & Format(Now.Month, "00") & Format(Now.Day, "00") & " " & Format(Now.Hour, "00") & ":" & Format(Now.Minute, "00") & "'"
		If strRemarks = Nothing Then
			'Do nothing
		Else
			strQuery &= ",'" & strRemarks & "'"
		End If
		QueryDb(strQuery, False)
	End Sub

    Friend Function LoadConfigSetting(ByVal strCategory As String, ByVal strConfigName As String) As String
        strQuery = "exec usp_ConfigHandle 'Get','" & strCategory & "',NULL,'" & strConfigName & "'"
        Dim objData As DataSet
        objData = QueryDb(strQuery, True)
        Dim strReturn As String = Nothing

        If objData Is Nothing Then
            blnDatabaseOnLine = False
            Return ""
        End If
        If objData.Tables.Count = 0 Then Return ""
        If objData.Tables(0).Rows.Count = 0 Then Return ""

        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If objData.Tables.Item(0).Rows(intRowCount).Item("Category") = strCategory Then
                    If objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") = strConfigName Then
                        strReturn = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    End If
                End If
            End If
        Next
        Return strReturn
    End Function

    Friend Sub LoadViewSettings()
        'CurVar.TrackBoxWidth = RegHandle.ReadLMRegKey("TrackBoxWidth", RegHandle.RegistryPath)
        strQuery = "exec usp_ConfigHandle 'Get','ScreenView'"
        Dim objData As DataSet
        objData = QueryDb(strQuery, True)
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Try
                    Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName")
                        'Case "TrackBoxWidth"
                        'CurVar.TrackBoxWidth = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ClientsPerTrack"
                            CurVar.ClientsPerTrack = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ClientsPerGroup"
                            CurVar.ClientsPerGroup = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "PayLines"
                            CurVar.PayLines = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "OpeningHour"
                            CurVar.OpeningHour = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                            'Case "OpeningHours"
                            '    Dim tmpDate As Date = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                            '    CurVar.OpeningHours = CurVar.OpeningHours.AddHours(tmpDate.Hour)
                            '    CurVar.OpeningHours = CurVar.OpeningHours.AddMinutes(tmpDate.Minute)
                        Case "ClosingHour"
                            CurVar.ClosingHour = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                            'Case "ClosingHours"
                            '    Dim tmpDate As Date = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                            '    CurVar.ClosingHours = CurVar.ClosingHours.AddHours(tmpDate.Hour)
                            '    CurVar.ClosingHours = CurVar.ClosingHours.AddMinutes(tmpDate.Minute)
                        Case "TimeFrame"
                            CurVar.TimeFrame = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowOffHours"
                            CurVar.ShowOffHours = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "OnHoursColor"
                            CurVar.OnHoursColor = System.Drawing.Color.FromName(objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue"))
                        Case "OffHoursColor"
                            CurVar.OffHoursColor = System.Drawing.Color.FromName(objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue"))
                        Case "ReadOnlyBackColor"
                            CurVar.ReadOnlyBackColor = System.Drawing.Color.FromName(objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue"))
                        Case "Language"
                            CurVar.Language = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowTeacher"
                            CurVar.ShowTeacher = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowTimeWithTrack"
                            CurVar.ShowTimeWithTrack = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "UseFadingColors"
                            CurVar.UseFadingColors = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowAge"
                            CurVar.ShowAge = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowAgeAfter"
                            CurVar.ShowAgeAfter = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                        Case "ShowAgeMax"
                            CurVar.ShowAgeMax = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    End Select
                Catch ex As Exception
                    MessageBox.Show("There was an error processing the Config value: " & objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName") & " : " & objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue") & vbCrLf & "Please check your settings")
                End Try

            End If
        Next
    End Sub

	Friend Sub LoadGeneralSettings()
		strQuery = "exec usp_ConfigHandle 'Get','General'"
		Dim objData As DataSet
		objData = QueryDb(strQuery, True)
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName")
                    Case "SeasonStart"
                        CurVar.SeasonStart = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SeasonLength"
                        CurVar.SeasonLength = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "DeleteEmptyInvoice"
                        CurVar.DeleteEmptyInvoice = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SelectMultipleGroups"
                        CurVar.SelectMultipleGroups = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "InvoiceName"
                        CurVar.InvoiceName = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "InvoiceNumber"
                        CurVar.InvoiceNumber = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "OverbookWarning"
                        CurVar.OverbookWarning = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "ShowMoney"
                        CurVar.ShowMoney = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "ShowLastAppointment"
                        CurVar.ShowLastAppointment = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "ShowAllLessonTypes"
                        CurVar.ShowAllLessonTypes = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "RequireLessontype"
                        CurVar.RequireLessontype = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "DeleteMax1Client"
                        CurVar.DeleteMax1Client = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")

                    Case "EmailMethod"
                        CurVar.EmailMethod = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpServer"
                        CurVar.SmtpServer = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpServerUsername"
                        CurVar.SmtpUser = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpServerPassword"
                        CurVar.SmtpPassword = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpCredentials"
                        CurVar.SmtpCredentials = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpReply"
                        CurVar.SmtpReply = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpPort"
                        CurVar.SmtpPort = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "SmtpSsl"
                        CurVar.SmtpSsl = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "ArchiveEmail"
                        CurVar.ArchiveEmail = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "ArchiveEmailAddress"
                        CurVar.ArchiveEmailAddress = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "DateFormat"
                        CurVar.DateFormat = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                End Select
            End If
        Next
	End Sub

    Friend Sub LoadButtonSettings()
        strQuery = "exec usp_ConfigHandle 'Get','Buttons'"
        Dim objData As DataSet
        objData = QueryDb(strQuery, True)
        If objData.Tables.Count = 0 Then Exit Sub
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName")
                    Case "btnAppRemove"
                        CurVar.btnAppRemoveSortOrder = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "btnAppCreate"
                        CurVar.btnAppCreateSortOrder = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "btnAppMove"
                        CurVar.btnAppMoveSortOrder = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "btnAppDelete"
                        CurVar.btnAppDeleteSortOrder = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                    Case "btnAppClear"
                        CurVar.btnAppClearSortOrder = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
                End Select
            End If
        Next
    End Sub

    Friend Sub WriteDBLog(ByVal strLogText As String)
        strQuery = ""
        strLogText = Replace(strLogText, "'", "~")
        strQuery = "exec usp_LoggingHandle 'Ins',NULL,'" & strLogText & "','" & Environment.MachineName.ToString & "'"

        Try
            DbHandle.QueryDatabase(strQuery, False)
        Catch ex As Exception
            TxtHandle.LogLocation = ""
            WriteLog(ex.Message, 1)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Friend Sub ClearDBLog(ByVal dtmDate As Date)
        strQuery = ""
        strQuery = "exec usp_LoggingHandle 'Del','" & FormatDate(dtmDate) & "'"

        Try
            QueryDb(strQuery, False)
        Catch ex As Exception
            TxtHandle.LogLocation = ""
            WriteLog(ex.Message, 1)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Friend Sub BackupDatabase(ByVal strPath As String)

        Dim strDateTime As String
        strDateTime = Replace(Replace(Replace(FormatDateTime(Now()), ":", ""), " ", "_"), "-", "")
        strQuery = ""
        strQuery = "exec usp_BackupHandle 'CREATE','" & DbHandle.DatabaseName & "','" & strPath & "','" & strDateTime & "'"
        If DebugMode Then MessageBox.Show("DbHandle.DatabaseName = " & DbHandle.DatabaseName & vbCrLf & _
                                            "strPath = " & strPath & vbCrLf & _
                                            "strDateTime = " & strDateTime & vbCrLf & _
                                            strQuery)
        Try
            QueryDb(strQuery, False)
        Catch ex As Exception
            TxtHandle.LogLocation = ""
            WriteLog(ex.Message, 1)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Friend Sub LoadScreenSettings()
    '	strQuery = "exec usp_ConfigHandle 'Get','ScreenPosition'"
    '	Dim objData As DataSet
    '	objData = DbHandle.QueryDatabase(strQuery, True)
    '	For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
    '		If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
    '			'MessageBox.Show("Cell Must be empty")
    '		Else
    '			Select Case objData.Tables.Item(0).Rows(intRowCount).Item("ConfigName")
    '				Case "ScreenTop"
    '					CurVar.ScreenTop = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
    '				Case "ScreenLeft"
    '					CurVar.ScreenLeft = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
    '				Case "ScreenWidth"
    '					CurVar.ScreenWidth = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
    '				Case "ScreenHeight"
    '					CurVar.ScreenHeight = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
    '				Case "ScreenState"
    '					CurVar.ScreenState = objData.Tables.Item(0).Rows(intRowCount).Item("ConfigValue")
    '			End Select
    '		End If
    '	Next
    'End Sub

	Friend Function PrContactsHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strName As String = Nothing) As DataSet
		Select Case strAction
			Case "Get"
				If intInputId = 0 Then
					PrContactsHandle = QueryDb("Exec usp_PrContactHandle 'Get'", True)
				Else
					PrContactsHandle = QueryDb("Exec usp_PrContactHandle 'Get', " & intInputId, True)
				End If
			Case "Add"
				PrContactsHandle = QueryDb("Exec usp_PrContactHandle 'Ins',0, '" & strName & "'", False)
			Case "Upd"
				PrContactsHandle = QueryDb("Exec usp_PrContactHandle 'Upd'," & intInputId & ",'" & strName & "'", False)
			Case "Del"
				PrContactsHandle = QueryDb("Exec usp_PrContactHandle 'Del'," & intInputId, False)
			Case Else
				PrContactsHandle = Nothing
		End Select
	End Function

#Region "Groups"

	Friend Function GroupsHandle(ByVal strAction As String, Optional ByVal intInputId As Double = 0, Optional ByVal strName As String = Nothing) As DataSet
		Select Case strAction
			Case "Get"
				If intInputId = 0 Then
					GroupsHandle = QueryDb("Exec usp_GroupHandle 'Get'", True)
				Else
					GroupsHandle = QueryDb("Exec usp_GroupHandle 'Get', " & intInputId, True)
				End If
			Case "Top"
				GroupsHandle = QueryDb("Exec usp_GroupHandle 'Top'", True)
			Case "Add"
				GroupsHandle = QueryDb("Exec usp_GroupHandle 'Ins'," & intInputId & ",'" & strName & "'", False)
			Case "Upd"
				GroupsHandle = QueryDb("Exec usp_GroupHandle 'Upd'," & intInputId & ",'" & strName & "'", False)
			Case "Del"
				GroupsHandle = QueryDb("Exec usp_GroupHandle 'Del'," & intInputId, False)
			Case Else
				GroupsHandle = Nothing
		End Select
	End Function

	Friend Function GroupNameGet(ByVal dblGroupId As Double) As String
		Dim objData As DataSet = GroupsHandle("Get", dblGroupId)
		Dim strGroupName As String = ""
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				strGroupName = objData.Tables.Item(0).Rows(intRowCount).Item("GroupName")
			End If
		Next
		Return strGroupName
	End Function

#End Region

#Region "Clients"

    Friend Function ClientsHandle( _
    ByVal strAction As String, _
    Optional ByVal dblGroupId As Double = 0, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal strFirstName As String = Nothing, _
    Optional ByVal strMiddleName As String = Nothing, _
    Optional ByVal strFamilyName As String = Nothing, _
    Optional ByVal blnPrimaryContact As Boolean = Nothing, _
    Optional ByVal strStreet As String = Nothing, _
    Optional ByVal strHouseNumber As String = Nothing, _
    Optional ByVal strPostalCode As String = Nothing, _
    Optional ByVal strCity As String = Nothing, _
    Optional ByVal strCountry As String = Nothing, _
    Optional ByVal strTelephone As String = Nothing, _
    Optional ByVal strFax As String = Nothing, _
    Optional ByVal strMobile As String = Nothing, _
    Optional ByVal strEmail As String = Nothing, _
    Optional ByVal blnMailinglist As Boolean = 0, _
    Optional ByVal intPrContact As Integer = Nothing, _
    Optional ByVal strDayOfBirth As String = Nothing, _
    Optional ByVal strBankaccount As String = Nothing, _
    Optional ByVal strCreditCard As String = Nothing, _
    Optional ByVal strCreditCardCcv As String = Nothing, _
    Optional ByVal strCreditCardExpire As String = Nothing, _
    Optional ByVal strRemarks As String = Nothing, _
    Optional ByVal blnCustom1 As Boolean = 0, _
    Optional ByVal blnCustom2 As Boolean = 0, _
    Optional ByVal strCustom3 As String = Nothing, _
    Optional ByVal strCustom4 As String = Nothing _
    ) As DataSet

        Select Case strAction
            Case "Get", "GNA"
                If dblGroupId = 0 And dblClientId = 0 Then
                    ClientsHandle = QueryDb("Exec usp_ClientHandle @Action = '" & strAction & "'", True)
                ElseIf dblGroupId > 0 Then
                    ClientsHandle = QueryDb("Exec usp_ClientHandle @Action = '" & strAction & "', @GroupId=" & dblGroupId, True)
                ElseIf dblClientId > 0 Then
                    ClientsHandle = QueryDb("Exec usp_ClientHandle @Action = '" & strAction & "', @ClientId=" & dblClientId, True)
                Else
                    ClientsHandle = Nothing
                End If
            Case "Add"
                strQuery = ""
                strQuery = " Exec usp_ClientHandle @Action = 'Ins', @GroupId = " & dblGroupId & ", @FirstName = '" & strFirstName & "'"
                'If Not strFirstName Is Nothing AndAlso strFirstName.Length > 0 Then strQuery &= ", @FirstName = '" & strFirstName & "'"
                If Not strMiddleName Is Nothing AndAlso strMiddleName.Length > 0 Then strQuery &= ", @MiddleName = '" & strMiddleName & "'"
                If Not strFamilyName Is Nothing AndAlso strFamilyName.Length > 0 Then strQuery &= ", @FamilyName = '" & strFamilyName & "'"
                If Not blnPrimaryContact = Nothing Then strQuery &= ", @PrimaryContact = " & blnPrimaryContact
                If Not strStreet Is Nothing AndAlso strStreet.Length > 0 Then strQuery &= ", @Street = '" & strStreet & "'"
                If Not strHouseNumber Is Nothing AndAlso strHouseNumber.Length > 0 Then strQuery &= ", @HouseNumber = '" & strHouseNumber & "'"
                If Not strPostalCode Is Nothing AndAlso strPostalCode.Length > 0 Then strQuery &= ", @PostalCode = '" & strPostalCode & "'"
                If Not strCity Is Nothing AndAlso strCity.Length > 0 Then strQuery &= ", @City = '" & strCity & "'"
                If Not strCountry Is Nothing AndAlso strCountry.Length > 0 Then strQuery &= ", @Country = '" & strCountry & "'"
                If Not strTelephone Is Nothing AndAlso strTelephone.Length > 0 Then strQuery &= ", @TelePhone = '" & strTelephone & "'"
                If Not strFax Is Nothing AndAlso strFax.Length > 0 Then strQuery &= ", @Fax = '" & strFax & "'"
                If Not strMobile Is Nothing AndAlso strMobile.Length > 0 Then strQuery &= ", @Mobile = '" & strMobile & "'"
                If Not strEmail Is Nothing AndAlso strEmail.Length > 0 Then strQuery &= ", @Email = '" & strEmail & "'"
                If Not blnMailinglist = Nothing Then strQuery &= ", @Mailinglist = " & blnMailinglist
                If Not intPrContact = Nothing Then strQuery &= ", @PrContactID = " & intPrContact
                If Not strDayOfBirth Is Nothing AndAlso Not (strDayOfBirth = "19000101" Or strDayOfBirth = Today.Year & Format(Today.Month, "00") & Format(Today.Day, "00")) Then
                    If strDayOfBirth.Length = 8 Then strQuery &= ", @DayOfBirth = '" & strDayOfBirth & "'"
                End If
                If Not strBankaccount Is Nothing AndAlso strBankaccount.Length > 0 Then strQuery &= ", @Bankaccount = '" & strBankaccount & "'"

                If Not strCreditCard Is Nothing AndAlso strCreditCard.Length > 0 Then strQuery &= ", @CreditCard = '" & strCreditCard & "'"
                If Not strCreditCardCcv Is Nothing AndAlso strCreditCardCcv.Length > 0 Then strQuery &= ", @CreditCardCcv = '" & strCreditCardCcv & "'"
                If Not strCreditCardExpire Is Nothing AndAlso strCreditCardExpire.Length > 0 Then strQuery &= ", @CreditCardExpire = '" & strCreditCardExpire & "'"

                If Not strRemarks Is Nothing AndAlso strRemarks.Length > 0 Then strQuery &= ", @Remarks = '" & strRemarks & "'"
                If Not blnCustom1 = Nothing Then strQuery &= ", @CustomField1 = " & blnCustom1
                If Not blnCustom2 = Nothing Then strQuery &= ", @CustomField2 = " & blnCustom2
                If Not strCustom3 Is Nothing AndAlso strCustom3.Length > 0 Then strQuery &= ", @CustomField3 = '" & strCustom3 & "'"
                If Not strCustom4 Is Nothing AndAlso strCustom4.Length > 0 Then strQuery &= ", @CustomField4 = '" & strCustom4 & "'"
                ClientsHandle = QueryDb(strQuery, False)
            Case "Upd"
                strQuery = ""
                strQuery = " Exec usp_ClientHandle @Action = 'Upd', @GroupId = " & dblGroupId & ", @ClientId = " & dblClientId
                If Not strFirstName Is Nothing AndAlso strFirstName.Length > 0 Then strQuery &= ", @FirstName = '" & strFirstName & "'"
                If Not strMiddleName Is Nothing AndAlso strMiddleName.Length > 0 Then strQuery &= ", @MiddleName = '" & strMiddleName & "'"
                If Not strFamilyName Is Nothing AndAlso strFamilyName.Length > 0 Then strQuery &= ", @FamilyName = '" & strFamilyName & "'"
                If Not blnPrimaryContact = Nothing Then strQuery &= ", @PrimaryContact = " & blnPrimaryContact
                If Not strStreet Is Nothing AndAlso strStreet.Length > 0 Then strQuery &= ", @Street = '" & strStreet & "'"
                If Not strHouseNumber Is Nothing AndAlso strHouseNumber.Length > 0 Then strQuery &= ", @HouseNumber = '" & strHouseNumber & "'"
                If Not strPostalCode Is Nothing AndAlso strPostalCode.Length > 0 Then strQuery &= ", @PostalCode = '" & strPostalCode & "'"
                If Not strCity Is Nothing AndAlso strCity.Length > 0 Then strQuery &= ", @City = '" & strCity & "'"
                If Not strCountry Is Nothing AndAlso strCountry.Length > 0 Then strQuery &= ", @Country = '" & strCountry & "'"
                If Not strTelephone Is Nothing AndAlso strTelephone.Length > 0 Then strQuery &= ", @TelePhone = '" & strTelephone & "'"
                If Not strFax Is Nothing AndAlso strFax.Length > 0 Then strQuery &= ", @Fax = '" & strFax & "'"
                If Not strMobile Is Nothing AndAlso strMobile.Length > 0 Then strQuery &= ", @Mobile = '" & strMobile & "'"
                If Not strEmail Is Nothing AndAlso strEmail.Length > 0 Then strQuery &= ", @Email = '" & strEmail & "'"
                If Not blnMailinglist = Nothing Then strQuery &= ", @Mailinglist = " & blnMailinglist
                If Not intPrContact = Nothing Then strQuery &= ", @PrContactID = " & intPrContact
                If Not strDayOfBirth Is Nothing AndAlso Not (strDayOfBirth = "19000101" Or strDayOfBirth = Today.Year & Format(Today.Month, "00") & Format(Today.Day, "00")) Then
                    If strDayOfBirth.Length = 8 Then strQuery &= ", @DayOfBirth = '" & strDayOfBirth & "'"
                End If
                If Not strBankaccount Is Nothing AndAlso strBankaccount.Length > 0 Then strQuery &= ", @Bankaccount = '" & strBankaccount & "'"

                If Not strCreditCard Is Nothing AndAlso strCreditCard.Length > 0 Then strQuery &= ", @CreditCard = '" & strCreditCard & "'"
                If Not strCreditCardCcv Is Nothing AndAlso strCreditCardCcv.Length > 0 Then strQuery &= ", @CreditCardCcv = '" & strCreditCardCcv & "'"
                If Not strCreditCardExpire Is Nothing AndAlso strCreditCardExpire.Length > 0 Then strQuery &= ", @CreditCardExpire = '" & strCreditCardExpire & "'"

                If Not strRemarks Is Nothing AndAlso strRemarks.Length > 0 Then strQuery &= ", @Remarks = '" & strRemarks & "'"
                If Not blnCustom1 = Nothing Then strQuery &= ", @CustomField1 = " & blnCustom1
                If Not blnCustom2 = Nothing Then strQuery &= ", @CustomField2 = " & blnCustom2
                If Not strCustom3 Is Nothing AndAlso strCustom3.Length > 0 Then strQuery &= ", @CustomField3 = '" & strCustom3 & "'"
                If Not strCustom4 Is Nothing AndAlso strCustom4.Length > 0 Then strQuery &= ", @CustomField4 = '" & strCustom4 & "'"
                ClientsHandle = QueryDb(strQuery, False)
            Case "Del"
                ClientsHandle = QueryDb("Exec usp_ClientHandle @Action = 'Del', @ClientId = " & dblClientId, False)
            Case Else
                ClientsHandle = Nothing
        End Select
    End Function

	Friend Function ClientNameGet(ByVal dblClientId As Double) As String
		Dim objData As DataSet = ClientsHandle("Get", 0, dblClientId)
		ClientNameGet = ""
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				ClientNameGet = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
				If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then ClientNameGet &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
				If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then ClientNameGet &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
			End If
		Next
		Return ClientNameGet
	End Function

    Friend Function ClientMemoGet(ByVal dblClientId As Double) As String
        Dim objData As DataSet = ClientsHandle("Get", 0, dblClientId)
        ClientMemoGet = ""
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                If Not IsDBNull(objData.Tables.Item(0).Rows(intRowCount).Item("Remarks")) Then
                    ClientMemoGet = objData.Tables.Item(0).Rows(intRowCount).Item("Remarks")
                End If
            End If
        Next
        Return ClientMemoGet
    End Function

    Public Function NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function

    Friend Sub PrimaryContactSet(ByVal dblGroupId As Double, ByVal dblClientId As Double)
		QueryDb("Exec usp_PrimaryContactSet @GroupId = " & dblGroupId & ", @ClientId = " & dblClientId, False)
	End Sub

    Friend Function ClientLessonsHandle( _
      ByVal strAction As String, _
    Optional ByVal dblClientLevelId As Double = 0, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal dblGroupId As Double = 0, _
    Optional ByVal intLessonTypeID As Integer = Nothing, _
    Optional ByVal intLevelID As Integer = Nothing, _
    Optional ByVal intExtraCount As Integer = Nothing, _
    Optional ByVal intLessonCount As Integer = Nothing, _
    Optional ByVal blnPrimaryType As Boolean = Nothing, _
    Optional ByVal intLastAction As Integer = Nothing _
      ) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        Dim intPrimaryType As Integer = 0
        If blnPrimaryType = True Then intPrimaryType = 1

        ClientLessonsHandle = QueryDb("Exec usp_ClientLessonHandle @Action='" & strAction & _
                "', @ClientLevelId=" & dblClientLevelId & _
                ",@ClientId=" & dblClientId & _
                ",@GroupId=" & dblGroupId & _
                ",@LessonTypeId=" & intLessonTypeID & _
                ",@LevelId=" & intLevelID & _
                ",@ExtraCount=" & intExtraCount & _
                ",@LessonCount=" & intLessonCount & _
                ",@PrimaryType=" & intPrimaryType & _
                ",@LastAction=" & intLastAction _
                , True)
    End Function

	Friend Function ClientLessonLevelGet( _
	  Optional ByVal dblClientId As Double = 0, _
	  Optional ByVal dblGroupId As Double = 0) As DataSet

        ClientLessonLevelGet = QueryDb("Exec usp_ClientLessonLevelGet @ClientId=" & dblClientId & _
                                       " ,@GroupId=" & dblGroupId & _
                                       " ,@ShowAllLessonTypes=" & CurVar.ShowAllLessonTypes & _
                                       " ,@SeasonStart='" & FormatDate(CurVar.SeasonStart) & "'" & _
                                       " ,@SeasonEnd='" & FormatDate(CurVar.SeasonEnd) & "'", True)
	End Function

    Friend Function ClientLessonLevelGet2( _
       ByVal dblClientId As Double, _
       ByVal strType As String) As DataSet

        ClientLessonLevelGet2 = QueryDb("Exec usp_ClientLessonLevelGet2 @ClientId=" & dblClientId & _
                                       " ,@LessonType='" & strType & "'" & _
                                       " ,@SeasonStart='" & FormatDate(CurVar.SeasonStart) & "'" & _
                                       " ,@SeasonEnd='" & FormatDate(CurVar.SeasonEnd) & "'", True)
    End Function

#End Region

#Region "Levels"

	Friend Function LevelsHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strName As String = Nothing, Optional ByVal strColor As String = Nothing, Optional ByVal intCount As Integer = Nothing) As DataSet
		Select Case strAction
			Case "Get"
				If intInputId = 0 And strName = Nothing Then
					LevelsHandle = QueryDb("Exec usp_LevelHandle @Action = 'Get'", True)
				ElseIf intInputId > 0 Then
					LevelsHandle = QueryDb("Exec usp_LevelHandle @Action = 'Get', @LevelId = " & intInputId, True)
				ElseIf strName.Length > 0 Then
					LevelsHandle = QueryDb("Exec usp_LevelHandle @Action = 'Get', @levelName = '" & strName & "'", True)
				Else
					LevelsHandle = QueryDb("Exec usp_LevelHandle @Action = 'Get'", True)
				End If
			Case "Add"
				LevelsHandle = QueryDb("Exec usp_LevelHandle 'Ins',0, '" & strName & "','" & strColor & "'" & "," & intCount, False)
			Case "Upd"
				LevelsHandle = QueryDb("Exec usp_LevelHandle 'Upd'," & intInputId & ",'" & strName & "','" & strColor & "'" & "," & intCount, False)
			Case "Del"
				LevelsHandle = QueryDb("Exec usp_LevelHandle 'Del'," & intInputId, False)
			Case Else
				LevelsHandle = Nothing
		End Select
	End Function

	Friend Function LevelIdGet(ByVal strLevelName As String) As Integer
		Dim objData As DataSet = LevelsHandle("Get", 0, strLevelName)
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				LevelIdGet = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LevelId")
			End If
		Next
		Return LevelIdGet
	End Function

	Friend Function LevelNameGet(ByVal intLevelId As Integer) As String
		LevelNameGet = ""
		Dim objData As DataSet = LevelsHandle("Get", intLevelId)
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				LevelNameGet = objData.Tables.Item(0).Rows(intRowCount).Item("LevelName")
			End If
		Next
		Return LevelNameGet
	End Function

#End Region

#Region "LessonTypes"

	Friend Function LessonTypesHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strName As String = Nothing, Optional ByVal strColor As String = Nothing) As DataSet
		Select Case strAction
			Case "Get"
				If intInputId = 0 And strName = Nothing Then
					LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Get'", True)
				ElseIf intInputId > 0 Then
					LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Get', " & intInputId, True)
				ElseIf strName.Length > 0 Then
					LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle @Action = 'Get', @LessontypeName = '" & strName & "'", True)
				Else
					LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Get'", True)
				End If
			Case "Add"
				LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Ins',0, '" & strName & "','" & strColor & "'", False)
			Case "Upd"
				LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Upd'," & intInputId & ",'" & strName & "','" & strColor & "'", False)
			Case "Del"
				LessonTypesHandle = QueryDb("Exec usp_LessonTypeHandle 'Del'," & intInputId, False)
			Case Else
				LessonTypesHandle = Nothing
		End Select
	End Function

    Friend Function LessonTypeIdGet(ByVal strLessonTypeName As String) As Integer
        If strLessonTypeName Is Nothing Then Return 0
        Dim objData As DataSet = LessonTypesHandle("Get", 0, strLessonTypeName)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                LessonTypeIdGet = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LessonTypeId")
            End If
        Next
        Return LessonTypeIdGet
    End Function

	Friend Function LessonTypeNameGet(ByVal intLessonTypeId As Integer) As String
		Dim objData As DataSet = LessonTypesHandle("Get", intLessonTypeId)
		LessonTypeNameGet = ""
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				LessonTypeNameGet = objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName")
			End If
		Next
		Return LessonTypeNameGet
	End Function

    Friend Sub CorrectLessonCount(ByVal dtmStartDate As DateTime, _
          ByVal dtmEndDate As DateTime, _
          Optional ByVal dblGroupId As Double = 0, _
          Optional ByVal dblClientId As Double = 0)

        strQuery = "Exec usp_CorrectLessonCount @StartDate='" & FormatDateTime(dtmStartDate) & "'"
        strQuery &= ", " & "@EndDate='" & FormatDateTime(dtmEndDate) & "'"
        strQuery &= ", " & "@GroupID=" & dblGroupId
        strQuery &= ", " & "@ClientId=" & dblClientID

        QueryDb(strQuery, False)
    End Sub

#End Region

#Region "Tracks"

	Friend Function TracksHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strName As String = Nothing, Optional ByVal intOffset As Integer = Nothing) As DataSet
		Select Case strAction
			Case "Get"
				If intInputId = 0 Then
					TracksHandle = QueryDb("Exec usp_TrackHandle 'Get'", True)
				Else
					TracksHandle = QueryDb("Exec usp_TrackHandle 'Get', " & intInputId, True)
				End If
			Case "Add"
				TracksHandle = QueryDb("Exec usp_TrackHandle 'Ins',0, '" & strName & "','" & intOffset & "'", False)
			Case "Upd"
				TracksHandle = QueryDb("Exec usp_TrackHandle 'Upd'," & intInputId & ",'" & strName & "','" & intOffset & "'", False)
			Case "Del"
				TracksHandle = QueryDb("Exec usp_TrackHandle 'Del'," & intInputId, False)
			Case Else
				TracksHandle = Nothing
		End Select
	End Function

	Friend Function TrackNameGet(ByVal intTrackId As Integer) As String
		TrackNameGet = ""
		If intTrackId > 0 Then
			Dim objData As DataSet = TracksHandle("Get", intTrackId)
			For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
				If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
					'MessageBox.Show("Cell Must be empty")
				Else
					TrackNameGet = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
				End If
			Next
		End If
		Return TrackNameGet
	End Function

#End Region

#Region "Memo"

	Friend Function MemosHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strType As String = Nothing, Optional ByVal dblGroupId As Double = 0, Optional ByVal dtmDate As DateTime = Nothing, Optional ByVal strText As String = Nothing) As DataSet
		Select Case strAction
			Case "Get"
                MemosHandle = QueryDb("Exec usp_MemoHandle @Action='Get', @MemoId=" & intInputId & ",@Type='" & strType & "',@GroupId=" & dblGroupId & ",@MemoDate='" & FormatDate(dtmDate) & "'", True)
			Case "Add"
                MemosHandle = QueryDb("Exec usp_MemoHandle @Action='Ins', @MemoId=" & intInputId & ",@Type='" & strType & "',@GroupId=" & dblGroupId & ",@MemoDate='" & FormatDate(dtmDate) & "', @MemoText=" & strText, False)
			Case "Upd"
                MemosHandle = QueryDb("Exec usp_MemoHandle @Action='Upd', @MemoId=" & intInputId & ",@Type='" & strType & "',@GroupId=" & dblGroupId & ",@MemoDate='" & FormatDate(dtmDate) & "'', @MemoText=" & strText, False)
			Case "Del"
                MemosHandle = QueryDb("Exec usp_MemoHandle @Action='Del', @MemoId=" & intInputId & ",@Type='" & strType & "',@GroupId=" & dblGroupId & ",@MemoDate='" & FormatDate(dtmDate) & "'", False)
			Case "Smt"
                MemosHandle = QueryDb("Exec usp_MemoHandle @Action='Smt', @MemoId=" & intInputId & ",@Type='" & strType & "',@GroupId=" & dblGroupId & ",@MemoDate='" & FormatDate(dtmDate) & "', @MemoText='" & strText & "'", False)
			Case Else
				MemosHandle = Nothing
		End Select
	End Function

#End Region

#Region "Appointments"

    Friend Function AppointmentsHandle(ByVal strAction As String, _
      Optional ByVal intInputId As Integer = 0, _
      Optional ByVal dtmDate As DateTime = Nothing, _
      Optional ByVal strType As String = Nothing, _
      Optional ByVal dblClientId As Double = 0, _
      Optional ByVal intTrackId As Integer = 0, _
      Optional ByVal intTrackIndex As Integer = 0, _
      Optional ByVal intLessonTypeId As Integer = 0, _
      Optional ByVal intLevelId As Integer = 0, _
      Optional ByVal intLessonCount As Integer = 0, _
      Optional ByVal intExtraCount As Integer = 0, _
      Optional ByVal intLoginId As Integer = 0) As DataSet
        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_AppointmentHandle @Action='" & strAction & "'"
        strQuery &= ", " & "@AppointmentId=" & intInputId
        strQuery &= ", " & "@AppDate='" & FormatDateTime(dtmDate) & "'"
        strQuery &= ", " & "@AppType='" & strType & "'"
        strQuery &= ", " & "@ClientId=" & dblClientID
        strQuery &= ", " & "@TrackId=" & intTrackId
        strQuery &= ", " & "@TrackIndex=" & intTrackIndex
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId
        strQuery &= ", " & "@LessonCount=" & intLessonCount
        strQuery &= ", " & "@ExtraCount=" & intExtraCount
        strQuery &= ", " & "@LoginId=" & intLoginId

        AppointmentsHandle = QueryDb(strQuery, True)

    End Function

    Friend Sub AppointmentCreate(ByVal dtmDate As DateTime, _
    ByVal strType As String, _
    ByVal dblClientId As Double, _
    ByVal intTrackId As Integer, _
    ByVal intTrackIndex As Integer, _
    ByVal intLessonTypeId As Integer, _
    ByVal intLevelId As Integer, _
    ByVal intLessonCount As Integer, _
    ByVal intExtraCount As Integer, _
    ByVal intLoginId As Integer, _
    Optional ByVal intLastAction As Integer = 0)

        strQuery = "Exec usp_AppointmentCreate "
        strQuery &= "@AppDate='" & FormatDateTime(dtmDate) & "'"
        strQuery &= ", " & "@AppType='" & strType & "'"
        strQuery &= ", " & "@ClientId=" & dblClientID
        strQuery &= ", " & "@TrackId=" & intTrackId
        strQuery &= ", " & "@TrackIndex=" & intTrackIndex
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId
        strQuery &= ", " & "@LessonCount=" & intLessonCount
        strQuery &= ", " & "@ExtraCount=" & intExtraCount
        strQuery &= ", " & "@LoginId=" & intLoginId
        strQuery &= ", " & "@LastAction=" & intLastAction

        QueryDb(strQuery, False)

    End Sub

    Friend Sub AppointmentDelete(ByVal dtmDate As DateTime, _
    ByVal strType As String, _
    ByVal dblClientId As Double, _
    ByVal intTrackId As Integer, _
    ByVal intTrackIndex As Integer, _
    ByVal intLessonTypeId As Integer, _
    ByVal intLevelId As Integer, _
    ByVal intLessonCount As Integer, _
    ByVal intExtraCount As Integer)

        strQuery = "Exec usp_AppointmentDelete "
        strQuery &= "@AppDate='" & FormatDateTime(dtmDate) & "'"
        strQuery &= ", " & "@AppType='" & strType & "'"
        strQuery &= ", " & "@ClientId=" & dblClientID
        strQuery &= ", " & "@TrackId=" & intTrackId
        strQuery &= ", " & "@TrackIndex=" & intTrackIndex
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId
        strQuery &= ", " & "@LessonCount=" & intLessonCount
        strQuery &= ", " & "@ExtraCount=" & intExtraCount

        QueryDb(strQuery, False)

    End Sub

    Friend Sub AppointmentUnDelete(ByVal dtmDate As DateTime, _
    ByVal strType As String, _
    ByVal dblClientId As Double, _
    ByVal intTrackId As Integer, _
    ByVal intTrackIndex As Integer, _
    ByVal intLessonTypeId As Integer, _
    ByVal intLevelId As Integer, _
    ByVal intLessonCount As Integer, _
    ByVal intExtraCount As Integer)

        strQuery = "Exec usp_AppointmentUnDelete "
        strQuery &= "@AppDate='" & FormatDateTime(dtmDate) & "'"
        strQuery &= ", " & "@AppType='" & strType & "'"
        strQuery &= ", " & "@ClientId=" & dblClientId
        strQuery &= ", " & "@TrackId=" & intTrackId
        strQuery &= ", " & "@TrackIndex=" & intTrackIndex
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId
        strQuery &= ", " & "@LessonCount=" & intLessonCount
        strQuery &= ", " & "@ExtraCount=" & intExtraCount

        QueryDb(strQuery, False)

    End Sub

    Friend Sub AppointmentMove(ByVal dtmDateNew As DateTime, _
    ByVal dtmDateOld As DateTime, _
    ByVal strType As String, _
    ByVal dblClientId As Double, _
    ByVal intTrackIdNew As Integer, _
    ByVal intTrackIdOld As Integer, _
    ByVal intTrackIndexNew As Integer, _
    ByVal intTrackIndexOld As Integer, _
    ByVal intLessonTypeId As Integer, _
    ByVal intLevelId As Integer, _
    ByVal intLessonCount As Integer, _
    ByVal intExtraCount As Integer, _
    ByVal intLoginId As Integer, _
    Optional ByVal intLastAction As Integer = 0)

        strQuery = "Exec usp_AppointmentMove "
        strQuery &= "@AppDateNew='" & FormatDateTime(dtmDateNew) & "'"
        strQuery &= ", " & "@AppDateOld='" & FormatDateTime(dtmDateOld) & "'"
        strQuery &= ", " & "@AppType='" & strType & "'"
        strQuery &= ", " & "@ClientId=" & dblClientId
        strQuery &= ", " & "@TrackIdNew=" & intTrackIdNew
        strQuery &= ", " & "@TrackIdOld=" & intTrackIdOld
        strQuery &= ", " & "@TrackIndexNew=" & intTrackIndexNew
        strQuery &= ", " & "@TrackIndexOld=" & intTrackIndexOld
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId
        strQuery &= ", " & "@LessonCount=" & intLessonCount
        strQuery &= ", " & "@ExtraCount=" & intExtraCount
        strQuery &= ", " & "@LoginId=" & intLoginId
        strQuery &= ", " & "@LastAction=" & intLastAction

        QueryDb(strQuery, False)

    End Sub

    Friend Sub AppointmentUpdate(ByVal dtmDate As DateTime, _
    ByVal dblClientId As Double, _
    ByVal intLessonTypeId As Integer, _
    ByVal intLevelId As Integer)

        strQuery = "Exec usp_AppointmentUpdate "
        strQuery &= "@AppDate='" & FormatDateTime(dtmDate) & "'"
        strQuery &= ", " & "@ClientId=" & dblClientID
        strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        strQuery &= ", " & "@LevelId=" & intLevelId

        QueryDb(strQuery, False)

    End Sub

    Friend Function DayAppGet(ByVal dtmDate As DateTime) As DataSet
        DayAppGet = QueryDb("EXEC usp_DayAppGet '" & FormatDate(dtmDate) & "'," & CurVar.ShowMoney & "," & CurVar.ShowLastAppointment, True)
    End Function

#End Region

#Region "Finance"

    Friend Function FinancesHandle(ByVal strAction As String, _
    Optional ByVal intInvoiceId As Integer = 0, _
    Optional ByVal strInvoiceName As String = Nothing, _
    Optional ByVal strInvoiceNumber As String = Nothing, _
    Optional ByVal intInvoiceLineId As Integer = 0, _
    Optional ByVal dtmDate As DateTime = Nothing, _
    Optional ByVal intGroupId As Double = 0, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal intLoginId As Integer = 0, _
    Optional ByVal blnPayed As Boolean = 0, _
    Optional ByVal strDescription As String = Nothing, _
    Optional ByVal intCount As Integer = 0, _
    Optional ByVal sinAmount As Single = 0, _
    Optional ByVal intTax As Integer = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_FinanceHandle @Action='" & strAction & "'"
        strQuery &= ", @SeasonStart='" & FormatDate(CurVar.SeasonStart) & "'"
        strQuery &= ", @SeasonEnd='" & FormatDate(CurVar.SeasonEnd) & "'"
        If intInvoiceId > 0 Then strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        If Not strInvoiceName Is Nothing Then strQuery &= ", " & "@InvoiceName='" & strInvoiceName & "'"
        If Not strInvoiceNumber Is Nothing Then strQuery &= ", " & "@InvoiceNumber=" & strInvoiceNumber
        If intInvoiceLineId > 0 Then strQuery &= ", " & "@InvoiceLineId=" & intInvoiceLineId
        If Not dtmDate = Nothing Then strQuery &= ", " & "@InvoiceDate='" & FormatDateTime(dtmDate) & "'"
        If intGroupId > 0 Then strQuery &= ", " & "@GroupId=" & intGroupId
        strQuery &= ", " & "@ClientId=" & dblClientId
        strQuery &= ", " & "@LoginId=" & intLoginId
        strQuery &= ", " & "@Payed=" & blnPayed
        If Not strDescription Is Nothing Then strQuery &= ", " & "@Description='" & strDescription & "'"
        If intCount > 0 Then strQuery &= ", " & "@Count=" & intCount
        If sinAmount > 0 Then strQuery &= ", " & "@Amount=" & FormatDecimal(sinAmount)
        strQuery &= ", " & "@Tax=" & intTax

        FinancesHandle = QueryDb(strQuery, True)

    End Function

    Friend Sub InvoiceNumberGet()
        Dim objData As DataSet
        objData = FinancesHandle("Max")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                CurVar.InvoiceNumber = objData.Tables.Item(0).Rows(intRowCount).Item("InvoiceNumber")
            End If
        Next
    End Sub

    Friend Function InvoicesHandle(ByVal strAction As String, _
    Optional ByVal intInvoiceId As Integer = 0, _
    Optional ByVal strInvoiceNumber As String = Nothing, _
    Optional ByVal dtmDate As DateTime = Nothing, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal intLoginId As Integer = 0, _
    Optional ByVal blnPayed As Boolean = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_InvoiceHandle @Action='" & strAction & "'"
        If intInvoiceId > 0 Then strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        If Not strInvoiceNumber Is Nothing Then strQuery &= ", " & "@InvoiceNumber='" & strInvoiceNumber & "'"
        If Not dtmDate = Nothing Then strQuery &= ", " & "@InvoiceDate='" & FormatDate(dtmDate) & "'"
        strQuery &= ", " & "@ClientId=" & dblClientID
        strQuery &= ", " & "@LoginId=" & intLoginId
        strQuery &= ", " & "@Payed=" & blnPayed
        strQuery &= ", " & "@ReturnId=" & intInvoiceId
        InvoicesHandle = QueryDb(strQuery, True)

    End Function

    Friend Function InvoicePaymentsHandle(ByVal strAction As String, _
    Optional ByVal intInvoicePaymentId As Integer = 0, _
    Optional ByVal intInvoiceId As Integer = 0, _
    Optional ByVal dtmDate As DateTime = Nothing, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal intLoginId As Integer = 0, _
    Optional ByVal sinAmount As Single = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_InvoicePaymentHandle @Action='" & strAction & "'"
        If intInvoicePaymentId > 0 Then strQuery &= ", " & "@InvoicePaymentId=" & intInvoicePaymentId
        strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        If Not dtmDate = Nothing Then strQuery &= ", " & "@PayDate='" & FormatDate(dtmDate) & "'"
        strQuery &= ", " & "@ClientId=" & dblClientId
        strQuery &= ", " & "@LoginId=" & intLoginId
        strQuery &= ", " & "@Amount=" & FormatDecimal(sinAmount)

        InvoicePaymentsHandle = QueryDb(strQuery, True)

    End Function

    Friend Function InvoiceLinesHandle(ByVal strAction As String, _
    Optional ByVal intInvoiceLineId As Integer = 0, _
    Optional ByVal intInvoiceId As Integer = 0, _
    Optional ByVal dblClientId As Double = 0, _
    Optional ByVal intLoginId As Integer = 0, _
    Optional ByVal strDescription As String = Nothing, _
    Optional ByVal intCount As Integer = 0, _
    Optional ByVal sinAmount As Single = 0, _
    Optional ByVal intTax As Integer = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_InvoiceLineHandle @Action='" & strAction & "'"
        If intInvoiceLineId > 0 Then strQuery &= ", " & "@InvoiceLineId=" & intInvoiceLineId
        strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        strQuery &= ", " & "@ClientId=" & dblClientId
        strQuery &= ", " & "@LoginId=" & intLoginId
        If Not strDescription Is Nothing Then strQuery &= ", " & "@Description='" & strDescription & "'"
        strQuery &= ", " & "@Count=" & intCount
        strQuery &= ", " & "@Amount=" & FormatDecimal(sinAmount)
        strQuery &= ", " & "@Tax=" & intTax

        InvoiceLinesHandle = QueryDb(strQuery, True)

    End Function

    Friend Function AppointmentFinanceGet(dblGroupID As Double, intClientID As Integer) As Integer
        Dim intOverbooked As Integer = 0
        Dim objData As DataSet

        If CurVar.OverbookWarning = 0 Then Return -1
        If CurVar.OverbookWarning = 1 Then intClientID = 0

        ' @DateStart datetime 
        ',@DateStop datetime = NULL
        ',@ClientID int = 0
        ',@GroupID bigint = 0

        objData = QueryDb("Exec [dbo].[usp_AppointmentFinanceGet] @DateStart = '" & FormatDate(CurVar.SeasonStart) & "', @DateStop = '" & FormatDate(CurVar.SeasonEnd) & "', @ClientID = " & intClientID & ", @GroupID = " & dblGroupID, True)
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                intOverbooked = objData.Tables.Item(0).Rows(intRowCount).Item("Difference")
            End If
        Next
        AppointmentFinanceGet = intOverbooked
    End Function
#End Region

#Region "Products"

    Friend Function ProductsHandle(ByVal strAction As String, Optional ByVal intInputId As Integer = 0, Optional ByVal strName As String = Nothing, Optional ByVal intCount As Integer = 0, Optional ByVal decAmount As Decimal = 0, Optional ByVal intTax As Integer = 0, Optional ByVal intSort As Integer = 0)
        Select Case strAction
            Case "Get"
                If intInputId = 0 Then
                    ProductsHandle = QueryDb("Exec usp_ProductHandle 'Get'", True)
                Else
                    ProductsHandle = QueryDb("Exec usp_ProductHandle 'Get', " & intInputId, True)
                End If
            Case "Add"
                ProductsHandle = QueryDb("Exec usp_ProductHandle 'Ins',0, '" & strName & "','" & intCount & "','" & FormatDecimal(decAmount) & "','" & FormatDecimal(intTax) & "'," & intSort, False)
            Case "Upd"
                ProductsHandle = QueryDb("Exec usp_ProductHandle 'Upd'," & intInputId & ",'" & strName & "','" & intCount & "'" & ",'" & FormatDecimal(decAmount) & "','" & FormatDecimal(intTax) & "'," & intSort, False)
            Case "Del"
                ProductsHandle = QueryDb("Exec usp_ProductHandle 'Del'," & intInputId, False)
            Case Else
                ProductsHandle = Nothing
        End Select
    End Function
#End Region

#Region "Tax"

    Friend Function TaxHandle(ByVal strAction As String, Optional ByVal intTaxId As Integer = Nothing, Optional ByVal intTax As Integer = Nothing, Optional ByVal strDescription As String = Nothing)
        Select Case strAction
            Case "Get"
                If intTaxId = Nothing Then
                    TaxHandle = QueryDb("Exec usp_TaxHandle 'Get'", True)
                Else
                    TaxHandle = QueryDb("Exec usp_TaxHandle 'Get', " & intTaxId, True)
                End If
            Case "Add"
                TaxHandle = QueryDb("Exec usp_TaxHandle 'Ins', " & intTaxId & "," & intTax & ",'" & strDescription & "'", False)
            Case "Upd"
                TaxHandle = QueryDb("Exec usp_TaxHandle 'Upd', " & intTaxId & "," & intTax & ",'" & strDescription & "'", False)
            Case "Del"
                TaxHandle = QueryDb("Exec usp_TaxHandle 'Del', " & intTaxId, False)
            Case Else
                TaxHandle = Nothing
        End Select
    End Function

#End Region

#Region "Reports"
    Friend Function ReportsHandle(ByVal strAction As String, _
        Optional ByVal intReportId As Integer = 0, _
        Optional ByVal strReportName As String = Nothing, _
        Optional ByVal strReportType As String = Nothing, _
        Optional ByVal strPrimaryMenu As String = Nothing, _
        Optional ByVal strSecondaryMenu As String = Nothing, _
        Optional ByVal strProcedureName As String = Nothing, _
        Optional ByVal blnVisible As Boolean = True, _
        Optional ByVal strLanguage As String = Nothing) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_ReportHandle @Action='" & strAction & "'"
        If intReportId > 0 Then strQuery &= ", " & "@ReportId=" & intReportId
        If Not strReportName Is Nothing Then strQuery &= ", " & "@ReportName='" & strReportName & "'"
        If Not strReportType Is Nothing Then strQuery &= ", " & "@ReportType='" & strReportType & "'"
        If Not strPrimaryMenu Is Nothing Then strQuery &= ", " & "@PrimaryMenu='" & strPrimaryMenu & "'"
        If Not strSecondaryMenu Is Nothing Then strQuery &= ", " & "@SecondaryMenu='" & strSecondaryMenu & "'"
        If Not strProcedureName Is Nothing Then strQuery &= ", " & "@ProcedureName='" & strProcedureName & "'"
        strQuery &= ", " & "@Visible='" & blnVisible & "'"
        If Not strLanguage Is Nothing Then strQuery &= ", " & "@Language='" & strLanguage & "'"

        ReportsHandle = QueryDb(strQuery, True)

    End Function

    Friend Function ReportArgumentsHandle(ByVal strAction As String, _
      Optional ByVal intReportArgumentsId As Integer = 0, _
      Optional ByVal intReportId As Integer = 0, _
      Optional ByVal intArgumentId As Integer = 0, _
      Optional ByVal blnIsOptional As Boolean = 0, _
      Optional ByVal strReportName As String = Nothing) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_ReportArgumentHandle @Action='" & strAction & "'"
        If intReportArgumentsId > 0 Then strQuery &= ", " & "@ReportArgumentId=" & intReportArgumentsId
        If intReportId > 0 Then strQuery &= ", " & "@ReportId=" & intReportId
        If intArgumentId > 0 Then strQuery &= ", " & "@ArgumentId=" & intArgumentId
        strQuery &= ", " & "@IsOptional=" & blnIsOptional
        If Not strReportName Is Nothing Then strQuery &= ", " & "@ReportName='" & strReportName & "'"

        ReportArgumentsHandle = QueryDb(strQuery, True)

    End Function

    Friend Function ReportStandardCreate(ByVal strReportName As String, _
        ByVal strReportType As String, _
        Optional ByVal dtmDateStart As DateTime = Nothing, _
        Optional ByVal dtmDateStop As DateTime = Nothing, _
        Optional ByVal dblClientId As Double = 0, _
        Optional ByVal dblGroupId As Double = 0, _
        Optional ByVal strAppType As String = Nothing, _
        Optional ByVal intTrackId As Integer = 0, _
        Optional ByVal intInvoiceId As Integer = 0, _
        Optional ByVal intLessonTypeId As Integer = 0, _
        Optional ByVal intLevelId As Integer = 0) As DataSet

        strQuery = "Exec usp_Report_" & strReportType & "_" & Replace(strReportName, " ", "_")
        strQuery &= " @DateStart='" & FormatDate(dtmDateStart) & "'"
        If Not dtmDateStop = Nothing Then strQuery &= ", " & "@DateStop='" & FormatDate(dtmDateStop) & "'"
        If dblClientId > 0 Then strQuery &= ", " & "@ClientId=" & dblClientId
        If dblGroupId > 0 Then strQuery &= ", " & "@GroupId=" & dblGroupId
        If Not strAppType = Nothing Then strQuery &= ", " & "@AppType='" & strAppType & "'"
        If intTrackId > 0 Then strQuery &= ", " & "@TrackId=" & intTrackId
        If intInvoiceId > 0 Then strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        If intLessonTypeId > 0 Then strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        If intLevelId > 0 Then strQuery &= ", " & "@LevelId=" & intLevelId

        ReportStandardCreate = QueryDb(strQuery, True)

    End Function

    Friend Function ReportCreate(ByVal intReportID As Integer, _
        Optional ByVal dtmDateStart As DateTime = Nothing, _
        Optional ByVal dtmDateStop As DateTime = Nothing, _
        Optional ByVal dblClientId As Double = 0, _
        Optional ByVal dblGroupId As Double = 0, _
        Optional ByVal strAppType As String = Nothing, _
        Optional ByVal intTrackId As Integer = 0, _
        Optional ByVal intInvoiceId As Integer = 0, _
        Optional ByVal intLessonTypeId As Integer = 0, _
        Optional ByVal intLevelId As Integer = 0, _
        Optional ByVal strLanguage As String = "EN") As DataSet

        Dim dtsReportProc As DataSet = ReportsHandle("Get", CurStatus.ReportID)
        Dim strReportProc As String = Nothing

        If dtsReportProc.Tables.Count = 0 Then Return Nothing
        If dtsReportProc.Tables(0).Rows.Count = 0 Then Return Nothing

        For intRowCount0 As Integer = 0 To dtsReportProc.Tables(0).Rows.Count - 1
            If dtsReportProc.Tables.Item(0).Rows(intRowCount0).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                strReportProc = dtsReportProc.Tables.Item(0).Rows(intRowCount0).Item("ProcedureName")
            End If
        Next

        strQuery = "Exec " & strReportProc & ""
        strQuery &= " @DateStart='" & FormatDate(dtmDateStart) & "'"
        If Not dtmDateStop = Nothing Then strQuery &= ", " & "@DateStop='" & FormatDate(dtmDateStop) & "'"
        If dblClientId <> 0 Then strQuery &= ", " & "@ClientId=" & dblClientId
        If dblGroupId <> 0 Then strQuery &= ", " & "@GroupId=" & dblGroupId
        If Not strAppType = Nothing Then strQuery &= ", " & "@AppType='" & strAppType & "'"
        If intTrackId <> 0 Then strQuery &= ", " & "@TrackId=" & intTrackId
        If intInvoiceId > 0 Then strQuery &= ", " & "@InvoiceId=" & intInvoiceId
        If intLessonTypeId <> 0 Then strQuery &= ", " & "@LessonTypeId=" & intLessonTypeId
        If intLevelId > 0 Then strQuery &= ", " & "@LevelId=" & intLevelId

        ReportCreate = QueryDb(strQuery, True)

    End Function

    Friend Function ReportFieldsHandle(ByVal strAction As String, _
    Optional ByVal intReportFieldId As Integer = 0, _
    Optional ByVal intReportId As Integer = 0, _
    Optional ByVal strFieldName As String = Nothing, _
    Optional ByVal strFieldAlias As String = Nothing, _
    Optional ByVal intFieldWidth As Integer = 0, _
    Optional ByVal blnFieldShow As Boolean = 0, _
    Optional ByVal strFieldType As String = Nothing, _
    Optional ByVal strFieldDefault As String = Nothing, _
    Optional ByVal intFieldOrder As Integer = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_ReportFieldHandle @Action='" & strAction & "'"
        If intReportFieldId > 0 Then strQuery &= ", " & "@ReportFieldId=" & intReportFieldId
        If intReportId > 0 Then strQuery &= ", " & "@ReportId=" & intReportId

        If Not strFieldName Is Nothing Then strQuery &= ", " & "@FieldName='" & strFieldName & "'"
        If Not strFieldAlias Is Nothing Then strQuery &= ", " & "@FieldAlias='" & strFieldAlias & "'"
        If intFieldWidth > 0 Then strQuery &= ", " & "@FieldWidth=" & intFieldWidth
        strQuery &= ", " & "@FieldShow=" & blnFieldShow
        If Not strFieldType Is Nothing Then strQuery &= ", " & "@FieldType='" & strFieldType & "'"
        If Not strFieldDefault Is Nothing Then strQuery &= ", " & "@FieldDefault='" & strFieldDefault & "'"
        If intFieldOrder > 0 Then strQuery &= ", " & "@FieldOrder=" & intFieldOrder

        ReportFieldsHandle = QueryDb(strQuery, True)

    End Function

    Friend Function ReportFieldsGet(ByVal intReportId As Integer) As DataSet
        strQuery = "Exec usp_ReportFieldsGet @ReportID='" & intReportId & "'"
        ReportFieldsGet = QueryDb(strQuery, True)
    End Function

#End Region

#Region "Logins"

    Friend Function LoginsHandle(ByVal strAction As String, _
       Optional ByVal intLoginId As Integer = 0, _
       Optional ByVal strLoginName As String = Nothing, _
       Optional ByVal strLoginPassword As String = Nothing, _
       Optional ByVal dtmDateStart As DateTime = Nothing, _
       Optional ByVal dtmDateStop As DateTime = Nothing, _
       Optional ByVal blnEnabled As Boolean = 0, _
       Optional ByVal blnSecurity_Add As Boolean = 0, _
       Optional ByVal blnSecurity_Change As Boolean = 0, _
       Optional ByVal blnSecurity_Delete As Boolean = 0, _
       Optional ByVal blnFinance_Add As Boolean = 0, _
       Optional ByVal blnFinance_Change As Boolean = 0, _
       Optional ByVal blnFinance_Delete As Boolean = 0, _
       Optional ByVal blnSettings_Add As Boolean = 0, _
       Optional ByVal blnSettings_Change As Boolean = 0, _
       Optional ByVal blnSettings_Delete As Boolean = 0, _
       Optional ByVal blnGroups_Delete As Boolean = 0, _
       Optional ByVal blnClients_Delete As Boolean = 0) As DataSet

        If strAction = "Add" Then strAction = "Ins"
        strQuery = "Exec usp_LoginHandle @Action='" & strAction & "'"
        If intLoginId > 0 Then strQuery &= ", " & "@LoginId=" & intLoginId
        If Not strLoginName = Nothing Then strQuery &= ", " & "@LoginName='" & strLoginName & "'"
        If Not strLoginPassword = Nothing Then strQuery &= ", " & "@LoginPassword='" & strLoginPassword & "'"
        If Not dtmDateStart = Nothing Then strQuery &= ", " & "@DateStart='" & FormatDate(dtmDateStart) & "'"
        If Not dtmDateStop = Nothing Then strQuery &= ", " & "@DateStop='" & FormatDate(dtmDateStop) & "'"
        strQuery &= ", " & "@Enabled=" & blnEnabled
        strQuery &= ", " & "@Security_Add=" & blnSecurity_Add
        strQuery &= ", " & "@Security_Change=" & blnSecurity_Change
        strQuery &= ", " & "@Security_Delete=" & blnSecurity_Delete
        strQuery &= ", " & "@Finance_Add=" & blnFinance_Add
        strQuery &= ", " & "@Finance_Change=" & blnFinance_Change
        strQuery &= ", " & "@Finance_Delete=" & blnFinance_Delete
        strQuery &= ", " & "@Settings_Add=" & blnSettings_Add
        strQuery &= ", " & "@Settings_Change=" & blnSettings_Change
        strQuery &= ", " & "@Settings_Delete=" & blnSettings_Delete
        strQuery &= ", " & "@Groups_Delete=" & blnGroups_Delete
        strQuery &= ", " & "@Clients_Delete=" & blnClients_Delete
        LoginsHandle = QueryDb(strQuery, True)

    End Function

#End Region

#Region "Search"

    Friend Function Search(ByVal intSearchPartialMatch As Integer, _
        ByVal booSearchMatchAll As Boolean, _
        ByVal intSearchMaximum As Integer, _
        Optional ByVal strSearchFirstName As String = Nothing, _
        Optional ByVal strSearchLastName As String = Nothing, _
        Optional ByVal strSearchPostalcode As String = Nothing, _
        Optional ByVal strSearchCity As String = Nothing, _
        Optional ByVal strSearchGroupName As String = Nothing, _
        Optional ByVal strSearchEmail As String = Nothing, _
        Optional ByVal strSearchPhone As String = Nothing, _
        Optional ByVal strSearchDateOfBirth As String = Nothing _
        ) As DataSet

        strQuery = "Exec usp_Search @PartialMatch=" & intSearchPartialMatch
        strQuery &= ", @MatchAll=" & booSearchMatchAll
        strQuery &= ", @MaximumHits=" & intSearchMaximum
        If Not strSearchFirstName = Nothing Then strQuery &= ", @FirstName='" & strSearchFirstName & "'"
        If Not strSearchLastName = Nothing Then strQuery &= ", @LastName='" & strSearchLastName & "'"
        If Not strSearchPostalcode = Nothing Then strQuery &= ", @PostalCode='" & strSearchPostalcode & "'"
        If Not strSearchCity = Nothing Then strQuery &= ", @City='" & strSearchCity & "'"
        If Not strSearchGroupName = Nothing Then strQuery &= ", @GroupName='" & strSearchGroupName & "'"
        If Not strSearchEmail = Nothing Then strQuery &= ", @Email='" & strSearchEmail & "'"
        If Not strSearchPhone = Nothing Then strQuery &= ", @Phone='" & strSearchPhone & "'"
        If Not strSearchDateOfBirth = Nothing Then strQuery &= ", @DateOfBirth='" & strSearchDateOfBirth & "'"

        Search = QueryDb(strQuery, True)

    End Function

#End Region

#Region "Language"

    Friend Function Translate(ByVal strLanguage As String, ByVal strLanguageForm As String, ByVal strLanguageItem As String) As String
        Dim dtsData As DataSet = LanguageHandle("Get", 0, strLanguage, strLanguageForm, strLanguageItem)
        If dtsData Is Nothing Then Return ""
        If dtsData.Tables.Count = 0 Then Return ""
        For intRowCount = 0 To dtsData.Tables(0).Rows.Count - 1
            If dtsData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
                Return ""
            Else
                Return (dtsData.Tables(0).Rows(intRowCount).Item("LanguageText"))
            End If
        Next
        Return strLanguageItem
    End Function

    Friend Function LanguageHandle(ByVal strAction As String, Optional ByVal intLanguageId As Integer = Nothing, Optional ByVal strLanguage As String = Nothing, Optional ByVal strLanguageForm As String = Nothing, Optional ByVal strLanguageItem As String = Nothing, Optional ByVal strLanguageText As String = Nothing, Optional ByVal strLanguageType As String = Nothing)
        'Select Case strAction
        '    Case "Get"
        If strAction = "Add" Then strAction = "Ins"

        strQuery = "EXECUTE [dbo].[usp_LanguageHandle]"
        strQuery &= " @Action = '" & strAction & "'"
        strQuery &= " ,@LanguageId = " & intLanguageId
        strQuery &= " ,@Language = '" & strLanguage & "'"
        strQuery &= " ,@LanguageForm = '" & strLanguageForm & "'"
        strQuery &= " ,@LanguageItem = '" & strLanguageItem & "'"
        strQuery &= " ,@LanguageText = '" & strLanguageText & "'"
        strQuery &= " ,@LanguageType = '" & strLanguageType & "'"
        LanguageHandle = QueryDb(strQuery, True)
        '    Case "Add"
        'LanguageHandle = QueryDb("Exec usp_LanguageHandle 'Ins', " & intTaxId & "," & intTax & ",'" & strDescription & "'", False)
        '    Case "Upd"
        'LanguageHandle = QueryDb("Exec usp_LanguageHandle 'Upd', " & intTaxId & "," & intTax & ",'" & strDescription & "'", False)
        '    Case "Del"
        'LanguageHandle = QueryDb("Exec usp_LanguageHandle 'Del', " & intTaxId, False)
        '    Case Else
        'LanguageHandle = Nothing
        'End Select
    End Function

    Friend Function LanguageListGet() As DataSet
        strQuery = "EXECUTE [dbo].[usp_LanguageListGet]"
        LanguageListGet = QueryDb(strQuery, True)
    End Function

#End Region


End Module
