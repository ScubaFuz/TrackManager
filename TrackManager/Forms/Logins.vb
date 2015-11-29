Public Class frmLogins

	Private Sub frmLogins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateStart.Text = Today
        txtDateStop.Text = ""
		LoginsGet()
		SetLanguage(Me)
	End Sub

	Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub

	Private Sub btnLoginAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginAdd.Click
		Dim dtmDateStart As DateTime = txtDateStart.Text
		Dim dtmDateStop As DateTime = Nothing
		If Not txtDateStop.Text = "" Then
			dtmDateStop = txtDateStop.Text
		End If
		LoginsHandle("Add", 0, txtLoginName.Text, psEncrypt(txtPassword.Text), dtmDateStart, dtmDateStop, chkEnabled.Checked, chkLoginAdd.Checked, chkLoginChange.Checked, chkLoginDelete.Checked, chkFinanceAdd.Checked, chkFinanceChange.Checked, chkfinanceDelete.Checked, chkSettingsAdd.Checked, chkSettingsChange.Checked, chkSettingsDelete.Checked, chkGroupsDelete.Checked, chkClientsDelete.Checked)
		LoginsGet()
	End Sub

	Private Sub btnLoginDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginDelete.Click
		If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
			LoginsHandle("Del", lvwLoginName.SelectedItems(0).Tag)
			FieldsClear()
			LoginsGet()
		End If
	End Sub

	Private Sub btnLoginSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginSave.Click
		Dim strPassword As String = Nothing
		If Len(txtPassword.Text) > 0 Then
			strPassword = psEncrypt(txtPassword.Text)
		End If
		Dim dtmDateStart As DateTime = txtDateStart.Text
		Dim dtmDateStop As DateTime = Nothing
		If Not txtDateStop.Text = "" Then
			dtmDateStop = txtDateStop.Text
		End If

		LoginsHandle("Upd", lvwLoginName.SelectedItems(0).Tag, txtLoginName.Text, strPassword, dtmDateStart, dtmDateStop, chkEnabled.Checked, chkLoginAdd.Checked, chkLoginChange.Checked, chkLoginDelete.Checked, chkFinanceAdd.Checked, chkFinanceChange.Checked, chkfinanceDelete.Checked, chkSettingsAdd.Checked, chkSettingsChange.Checked, chkSettingsDelete.Checked, chkGroupsDelete.Checked, chkClientsDelete.Checked)
		LoginsGet()
	End Sub

	Private Sub btnLoginClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoginClear.Click
		FieldsClear()
	End Sub

	Private Sub txtLoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginName.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub LoginsGet()
		lvwLoginName.Items.Clear()
		Dim objData As DataSet = LoginsHandle("Get")
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				Dim lsvItem As New ListViewItem
				lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LoginId")
				lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LoginName")
				lvwLoginName.Items.Add(lsvItem)
			End If
		Next
	End Sub

	Private Sub FieldsClear()
		txtLoginName.Text = ""
		txtLoginName.Tag = 0
		txtPassword.Text = ""
		txtDateStart.Text = FormatDate(Today)
		txtDateStop.Text = ""
		chkEnabled.Checked = False
		chkLoginAdd.Checked = False
		chkLoginChange.Checked = False
		chkLoginDelete.Checked = False
		chkFinanceAdd.Checked = False
		chkFinanceChange.Checked = False
		chkfinanceDelete.Checked = False
		chkSettingsAdd.Checked = False
		chkSettingsChange.Checked = False
		chkSettingsDelete.Checked = False
		chkGroupsDelete.Checked = False
		chkClientsDelete.Checked = False
		ButtonsHandle()
	End Sub

	Private Sub ButtonsHandle()
		btnLoginAdd.Enabled = False
		btnLoginDelete.Enabled = False
		btnLoginSave.Enabled = False

        If Len(txtLoginName.Text) > 2 Then
            If CurUser.SettingsChange Then btnLoginSave.Enabled = True
            If Len(txtPassword.Text) > 3 Then
                If CurUser.SecurityAdd Then btnLoginAdd.Enabled = True
            End If
        End If
		If lvwLoginName.SelectedItems.Count = 1 Then
			If CurUser.SecurityDelete Then btnLoginDelete.Enabled = True
		End If
	End Sub

	Private Sub lvwLoginName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLoginName.SelectedIndexChanged
		If lvwLoginName.SelectedItems.Count = 1 Then
			Dim objData As DataSet = LoginsHandle("Get", lvwLoginName.SelectedItems(0).Tag)
			For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
				If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
					'MessageBox.Show("Cell Must be empty")
				Else
					txtLoginName.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LoginName")
					txtDateStart.Text = objData.Tables.Item(0).Rows(intRowCount).Item("DateStart")
					If objData.Tables.Item(0).Rows(intRowCount).Item("DateStop").GetType.ToString = "System.DBNull" Then
						txtDateStop.Text = ""
					Else
						txtDateStop.Text = objData.Tables.Item(0).Rows(intRowCount).Item("DateStop")
					End If
					chkEnabled.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Enabled")
					txtPassword.Text = ""
					chkEnabled.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Enabled")
					chkLoginAdd.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Security_Add")
					chkLoginChange.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Security_Change")
					chkLoginDelete.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Security_Delete")
					chkFinanceAdd.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Finance_Add")
					chkFinanceChange.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Finance_Change")
					chkfinanceDelete.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Finance_Delete")
					chkSettingsAdd.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Settings_Add")
					chkSettingsChange.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Settings_Change")
					chkSettingsDelete.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Settings_Delete")
					chkGroupsDelete.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Groups_Delete")
					chkClientsDelete.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Clients_Delete")
				End If
			Next
		End If

		ButtonsHandle()
	End Sub

	Private Sub dtpDateStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateStart.ValueChanged
		txtDateStart.Text = dtpDateStart.Value
	End Sub

	Private Sub dtpDateStop_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateStop.ValueChanged
		txtDateStop.Text = dtpDateStop.Value
	End Sub

	Private Sub txtDateStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDateStart.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub txtDateStop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDateStop.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub btnDateStopClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateStopClear.Click
		txtDateStop.Text = ""
	End Sub
End Class