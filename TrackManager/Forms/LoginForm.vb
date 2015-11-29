Public Class frmLoginForm

	Private intLoginCount As Integer = 0
	Private blnLoginOK As Boolean = False

    Private Sub frmLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLoginname.Top = pnlLogin.Height * 0.2
        txtLoginName.Top = pnlLogin.Height * 0.3
        lblPassword.Top = pnlLogin.Height * 0.5
        txtPassword.Top = pnlLogin.Height * 0.6
        lblUnknown.Top = pnlLogin.Height * 0.7
        btnOK.Top = pnlLogin.Height * 0.8
        btnCancel.Top = pnlLogin.Height * 0.8
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtLoginName.Text = "ScubaFuz2008" And psEncrypt(txtPassword.Text) = "qalhXpdDZ/YVpj8QEW8gFqQNsHkWfFmD" Then
            'You are admin
            CurUser.LoginID = 1
            CurUser.LoginName = "Admin"
            CurUser.LogonTime = Now
            CurUser.DateStart = Now.AddDays(-1)
            CurUser.DateStop = Now.AddDays(1)
            CurUser.Enabled = 1
            CurUser.SecurityAdd = 1
            CurUser.SecurityChange = 1
            CurUser.SecurityDelete = 1
            CurUser.SettingsAdd = 1
            CurUser.SettingsChange = 1
            CurUser.SettingsDelete = 1
            CurUser.FinanceAdd = 1
            CurUser.FinanceChange = 1
            CurUser.FinanceDelete = 1
            CurUser.GroupsDelete = 1
            CurUser.ClientsDelete = 1
            blnLoginOK = True
            DebugMode = True
        Else
            'you must logon
            Dim objData As DataSet = LoginsHandle("Get", 0, txtLoginName.Text)
            If objData.Tables(0).Rows.Count = 0 Then
                intLoginCount += 1
                lblUnknown.Text = lblLoginname.Text & " / " & lblPassword.Text & " combination unknown!"
                blnLoginOK = False
                If intLoginCount = 3 Then Application.Exit()
                Exit Sub
            Else
                If objData.Tables.Count = 0 Then
                    intLoginCount += 1
                    lblUnknown.Text = lblLoginname.Text & " / " & lblPassword.Text & " combination unknown!"
                    blnLoginOK = False
                    If intLoginCount = 3 Then Application.Exit()
                    Exit Sub
                End If
                If objData.Tables.Item(0).Rows(0).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                    intLoginCount += 1
                    lblUnknown.Text = lblLoginname.Text & " / " & lblPassword.Text & " combination unknown!"
                    blnLoginOK = False
                    If intLoginCount = 3 Then Application.Exit()
                    Exit Sub
                Else
                    If psEncrypt(txtPassword.Text) = objData.Tables.Item(0).Rows(0).Item("LoginPassword") Then
                        CurUser.LoginID = objData.Tables.Item(0).Rows(0).Item("PK_LoginId")
                        CurUser.LoginName = objData.Tables.Item(0).Rows(0).Item("LoginName")
                        CurUser.LogonTime = Now
                        CurUser.DateStart = objData.Tables.Item(0).Rows(0).Item("DateStart")
                        If objData.Tables.Item(0).Rows(0).Item("DateStop").GetType().ToString = "System.DBNull" Then
                            CurUser.DateStop = Now.AddDays(1)
                        Else
                            CurUser.DateStop = objData.Tables.Item(0).Rows(0).Item("DateStop")
                        End If
                        CurUser.Enabled = objData.Tables.Item(0).Rows(0).Item("Enabled")
                        CurUser.SecurityAdd = objData.Tables.Item(0).Rows(0).Item("Security_Add")
                        CurUser.SecurityChange = objData.Tables.Item(0).Rows(0).Item("Security_Change")
                        CurUser.SecurityDelete = objData.Tables.Item(0).Rows(0).Item("Security_Delete")
                        CurUser.SettingsAdd = objData.Tables.Item(0).Rows(0).Item("Settings_Add")
                        CurUser.SettingsChange = objData.Tables.Item(0).Rows(0).Item("Settings_Change")
                        CurUser.SettingsDelete = objData.Tables.Item(0).Rows(0).Item("Settings_Delete")
                        CurUser.FinanceAdd = objData.Tables.Item(0).Rows(0).Item("Finance_Add")
                        CurUser.FinanceChange = objData.Tables.Item(0).Rows(0).Item("Finance_Change")
                        CurUser.FinanceDelete = objData.Tables.Item(0).Rows(0).Item("Finance_Delete")
                        CurUser.GroupsDelete = objData.Tables.Item(0).Rows(0).Item("Groups_Delete")
                        CurUser.ClientsDelete = objData.Tables.Item(0).Rows(0).Item("Clients_Delete")
                        blnLoginOK = True
                    Else
                        intLoginCount += 1
                        lblUnknown.Text = lblLoginname.Text & " / " & lblPassword.Text & " combination unknown!"
                        blnLoginOK = False
                        If intLoginCount = 3 Then Application.Exit()
                        Exit Sub
                    End If
                End If
            End If
        End If

        If CurUser.Enabled = False Or CurUser.DateStop < Today Or CurUser.DateStart > Today Then
            intLoginCount += 1
            lblUnknown.Text = "The current user is disabled"
            blnLoginOK = False
            Exit Sub
        End If

        If DebugMode Then
            MessageBox.Show( _
            "LoginID = " & CurUser.LoginID & vbCrLf & _
            "LoginName = " & CurUser.LoginName & vbCrLf & _
            "LogonTime = " & CurUser.LogonTime & vbCrLf & _
            "DateStart = " & CurUser.DateStart & vbCrLf & _
            "DateStop = " & CurUser.DateStop & vbCrLf & _
            "Enabled = " & CurUser.Enabled & vbCrLf & _
            "SecurityAdd = " & CurUser.SecurityAdd & vbCrLf & _
            "SecurityChange = " & CurUser.SecurityChange & vbCrLf & _
            "SecurityDelete = " & CurUser.SecurityDelete & vbCrLf & _
            "SettingsAdd = " & CurUser.SettingsAdd & vbCrLf & _
            "SettingsChange = " & CurUser.SettingsChange & vbCrLf & _
            "SettingsDelete = " & CurUser.SettingsDelete & vbCrLf & _
            "FinanceAdd = " & CurUser.FinanceAdd & vbCrLf & _
            "FinanceChange = " & CurUser.FinanceChange & vbCrLf & _
            "FinanceDelete = " & CurUser.FinanceDelete & vbCrLf & _
            "GroupsDelete = " & CurUser.GroupsDelete & vbCrLf & _
            "ClientsDelete = " & CurUser.ClientsDelete)
        End If
        If blnLoginOK = False And intLoginCount = 3 Then Application.Exit()
        If CurUser.DateStop > Now.AddDays(1) Then CurUser.DateStop = Now.AddDays(1)
        If blnLoginOK = True Then
            WriteLog("Logged on user: " & CurUser.LoginName, 1)
            Me.Close()
        End If
        '		Me.Close()
    End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Application.Exit()
		'Me.Close()
	End Sub

End Class
