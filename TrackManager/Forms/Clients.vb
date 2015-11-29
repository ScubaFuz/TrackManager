Public Class frmClients

    Friend blnMoveGroup As Boolean = False
    Private btnTemp As Button

    Private Sub frmClients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SecuritySet()
        AddHandler Me.lvwGroups.ColumnClick, AddressOf lvwGroups_ColumnClick
        lvwGroups.Columns.Add(New ColHeader("Group Name", "colgroupName", 100, HorizontalAlignment.Left, True))
        lvwGroups.Columns.Add(New ColHeader("Group Number", "colGroupNumber", 100, HorizontalAlignment.Left, True))
        GroupsGet()
        If CurStatus.GroupID > 0 Then
            GroupSelect(CurStatus.GroupID)
        End If

        AddHandler Me.lvwClients.ColumnClick, AddressOf lvwClients_ColumnClick
        lvwClients.Columns.Add(New ColHeader("First Name", "colFirstName", 80, HorizontalAlignment.Left, True))
        lvwClients.Columns.Add(New ColHeader("Middle Name", "colMiddleName", 40, HorizontalAlignment.Left, True))
        lvwClients.Columns.Add(New ColHeader("Family Name", "colFamilyName", 80, HorizontalAlignment.Left, True))
        ClientsGet()
        If CurStatus.ClientID > 0 Then
            ClientSelect(CurStatus.ClientID)
        End If
        PrContactsGet()
        SetLanguage(Me)
        ResetColors()
    End Sub

	Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub

    Private Sub SuspendButton(btnInput As Button)
        btnTemp = btnInput
        btnTemp.Enabled = False
        tmrClients.Enabled = True
        tmrClients.Start()

    End Sub

    Private Sub tmrClients_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrClients.Tick
        tmrClients.Stop()
        btnTemp.Enabled = True
    End Sub

	Private Sub GroupsGet()
		lvwGroups.Items.Clear()

		Dim lsvItem0 As New ListViewItem
		lsvItem0.Tag = 0
		lsvItem0.Text = "<Auto Create>"
		lsvItem0.SubItems.Add(0)
		lvwGroups.Items.Add(lsvItem0)

		Dim objData As DataSet
		objData = GroupsHandle("Get")
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				Dim lsvItem As New ListViewItem
				lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId")
				lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("GroupName")
				lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId"))
				lvwGroups.Items.Add(lsvItem)
			End If
		Next
	End Sub

	Private Sub ClientsGet(Optional ByVal blnHighest As Boolean = False)
		If CurStatus.GroupID > 0 Then
			lvwClients.Items.Clear()
			Dim objData As DataSet
			objData = ClientsHandle("Get", CurStatus.GroupID)
			For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
				If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
					'MessageBox.Show("Cell Must be empty")
				Else
					Dim lsvItem As New ListViewItem
					lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
					If blnHighest Then
						If CurStatus.ClientID < lsvItem.Tag Then
							CurStatus.ClientID = lsvItem.Tag
						End If
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
					lvwClients.Items.Add(lsvItem)
				End If
			Next
		End If
	End Sub

    Private Sub PrContactsGet()
        lvwPrContacts.Items.Clear()
        Dim objData As DataSet
        objData = PrContactsHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_PrContactId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("PrContactName")
                lvwPrContacts.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub lvwGroups_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
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

	Private Sub lvwClients_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
		Dim clickedCol As ColHeader = CType(Me.lvwClients.Columns(e.Column), ColHeader)
		clickedCol.ascending = Not clickedCol.ascending
		Dim numItems As Integer = Me.lvwClients.Items.Count
		Me.lvwClients.BeginUpdate()
		Dim SortArray As New ArrayList
		Dim i As Integer
		For i = 0 To numItems - 1
			SortArray.Add(New SortWrapper(Me.lvwClients.Items(i), e.Column))
		Next i

		SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))
		Me.lvwClients.Items.Clear()
		Dim z As Integer
		For z = 0 To numItems - 1
			Me.lvwClients.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
		Next z
		Me.lvwClients.EndUpdate()
	End Sub

	Private Sub GroupSelect(ByVal dblGroupId)
		For Each item As ListViewItem In lvwGroups.Items
			item.Selected = (CDbl(item.Tag) = dblGroupId)
		Next
		lvwGroups.TopItem = lvwGroups.SelectedItems.Item(0)
		lvwGroups.Select()
	End Sub

	Private Sub ClientSelect(ByVal dblClientId)
		For Each item As ListViewItem In lvwClients.Items
			item.Selected = (CDbl(item.Tag) = dblClientId)
		Next
		lvwClients.TopItem = lvwClients.SelectedItems.Item(0)
        lvwClients.Select()
        ResetColors()
	End Sub

	Private Sub btnEditClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		EditClient()
	End Sub

	Private Sub btnDeleteClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteClient.Click
		If lvwClients.SelectedItems.Count = 1 Then
			If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
				Try
					ClientsHandle("Del", 0, CurStatus.ClientID)
					ClearClient(True)
					ClientsGet()
					CurStatus.ReloadClients = True
				Catch ex As Exception
					MessageBox.Show(lanStrings.strGeneralError & vbCrLf & lanStrings.strCheckLog)
					WriteLog(ex.Message, 1)
				End Try
			End If
		ElseIf lvwGroups.SelectedItems.Count > 1 Then
			MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End If

	End Sub

	Private Sub btnAddClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddClient.Click
        'MessageBox.Show(lvwGroups.SelectedItems(0).Index)
        Dim intPrContacts As Integer
        If txtEmail.Text.Trim <> "" And EmailAddressCheck(txtEmail.Text.Trim) = False Then
            MessageBox.Show(lanStrings.strInvalidEmailAddress, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lvwPrContacts.SelectedItems.Count() = 1 Then
            intPrContacts = lvwPrContacts.SelectedItems.Item(0).Tag
        Else
            intPrContacts = 0
        End If
        If txtCreditCardCcv.Text.Length > 0 And Not IsNumeric(txtCreditCardCcv.Text) Then
            MessageBox.Show("CreditCard CCV Code must be a number")
            Exit Sub
        End If
        If dtpDateOfBirth.Value > Today() Then
            MessageBox.Show("A future birthdate is not allowed")
            Exit Sub
        End If

        If lvwGroups.SelectedItems.Count = 1 Then
            If txtFirstName.Text.Length > 0 Then
                If CurStatus.GroupID = 0 And CurStatus.GroupID = lvwGroups.SelectedItems.Item(0).Tag And lvwGroups.SelectedItems.Item(0).Text = "<Auto Create>" Then
                    If txtFamilyName.Text.Length = 0 Then
                        Exit Sub
                    End If
                    CurStatus.GroupID = FormatGroupNumber(Now)
                    GroupsHandle("Add", CurStatus.GroupID, txtFamilyName.Text)
                    Dim lsvItem As New ListViewItem
                    lsvItem.Tag = CurStatus.GroupID
                    lsvItem.Text = txtFamilyName.Text
                    lsvItem.SubItems.Add(CurStatus.GroupID)
                    lvwGroups.Items.Add(lsvItem)
                    'GroupSelect(CurStatus.GroupID)
                    frmTrackManager.GroupAdd(CurStatus.GroupID, txtFamilyName.Text)
                End If
                ClientsHandle("Add", _
                  CurStatus.GroupID, _
                  Nothing, _
                  txtFirstName.Text, _
                  txtMiddleName.Text, _
                  txtFamilyName.Text, _
                  Nothing, _
                  txtStreet.Text, _
                  txtHouseNumber.Text, _
                  txtPostalCode.Text, _
                  txtCity.Text, _
                  txtCountry.Text, _
                  txtTelephone.Text, _
                  txtFax.Text, _
                  txtMobile.Text, _
                  txtEmail.Text.Trim, _
                  chkMailinglist.Checked, _
                  intPrContacts, _
                  dtpDateOfBirth.Value.Year & Format(dtpDateOfBirth.Value.Month, "00") & Format(dtpDateOfBirth.Value.Day, "00"), _
                  txtBankaccount.Text, _
                  txtCreditCard.Text, _
                  txtCreditCardCcv.Text, _
                  cbxCreditCardYear.SelectedItem & cbxCreditCardMonth.SelectedItem, _
                  txtRemarks.Text, _
                  chkCustom1.Checked, _
                  chkCustom2.Checked, _
                  txtCustom3.Text, _
                  txtCustom4.Text)

                'ClearClient(True)
                GroupSelect(CurStatus.GroupID)
                ClientsGet(True)
                CurStatus.ReloadClients = True
                If blnMoveGroup = True Then
                    blnMoveGroup = False
                    btnMoveClient.BackColor = System.Drawing.SystemColors.Control
                    btnMoveClient.FlatStyle = FlatStyle.Standard
                End If
                ResetColors()
                SuspendButton(btnAddClient)
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        Else
            MessageBox.Show(lanStrings.strAllData)
        End If
    End Sub

	Private Sub btnUpdateClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateClient.Click
        UpdateClient()
	End Sub

    Private Sub UpdateClient()
        If txtFirstName.Tag > 0 Then
            'Update mode
            Dim intPrContacts As Integer
            If txtEmail.Text.Trim <> "" And EmailAddressCheck(txtEmail.Text.Trim) = False Then
                MessageBox.Show(lanStrings.strInvalidEmailAddress, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If lvwPrContacts.SelectedItems.Count() = 1 Then
                intPrContacts = lvwPrContacts.SelectedItems.Item(0).Tag
            Else
                intPrContacts = 0
            End If
            If txtCreditCardCcv.Text.Length > 0 And Not IsNumeric(txtCreditCardCcv.Text) Then
                MessageBox.Show("CreditCard CCV Code must be a number")
                Exit Sub
            End If

            If txtFirstName.Text.Length > 0 Then
                ClientsHandle("Upd", _
                 CurStatus.GroupID, _
                 txtFirstName.Tag, _
                 txtFirstName.Text, _
                 txtMiddleName.Text, _
                 txtFamilyName.Text, _
                 Nothing, _
                 txtStreet.Text, _
                 txtHouseNumber.Text, _
                 txtPostalCode.Text, _
                 txtCity.Text, _
                 txtCountry.Text, _
                 txtTelephone.Text, _
                 txtFax.Text, _
                 txtMobile.Text, _
                 txtEmail.Text.Trim, _
                 chkMailinglist.Checked, _
                 intPrContacts, _
                 dtpDateOfBirth.Value.Year & Format(dtpDateOfBirth.Value.Month, "00") & Format(dtpDateOfBirth.Value.Day, "00"), _
                 txtBankaccount.Text, _
                 txtCreditCard.Text, _
                 txtCreditCardCcv.Text, _
                 cbxCreditCardYear.SelectedItem & cbxCreditCardMonth.SelectedItem, _
                 txtRemarks.Text, _
                 chkCustom1.Checked, _
                 chkCustom2.Checked, _
                 txtCustom3.Text, _
                 txtCustom4.Text)

                ClientsGet()
                CurStatus.ReloadClients = True
                CurStatus.ClientID = txtFirstName.Tag
                'ClearClient(False)
                'ClientSelect(CurStatus.ClientID)
                If blnMoveGroup = True Then
                    btnMoveClient_Click(Nothing, Nothing)
                End If
                ResetColors()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        End If
    End Sub

	Private Sub btnClearClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearClient.Click
        ClearClient()
        ResetColors()
	End Sub

	Private Sub EditClient()
		If lvwClients.SelectedItems.Count = 1 Then
			CurStatus.ClientID = lvwClients.SelectedItems.Item(0).Tag
			Dim objData As DataSet
            objData = ClientsHandle("GNA", 0, CurStatus.ClientID)
			ClearClient(True)
			For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
				If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
					'MessageBox.Show("Cell Must be empty")
				Else
                    CurStatus.ClientID = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                    txtClientNumber.Text = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
                    txtFirstName.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
					txtFirstName.Text = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")

					If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then txtMiddleName.Text = objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then txtFamilyName.Text = objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Street").GetType().ToString = "System.DBNull" Then txtStreet.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Street")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("HouseNumber").GetType().ToString = "System.DBNull" Then txtHouseNumber.Text = objData.Tables.Item(0).Rows(intRowCount).Item("HouseNumber")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("PostalCode").GetType().ToString = "System.DBNull" Then txtPostalCode.Text = objData.Tables.Item(0).Rows(intRowCount).Item("PostalCode")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("City").GetType().ToString = "System.DBNull" Then txtCity.Text = objData.Tables.Item(0).Rows(intRowCount).Item("City")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Country").GetType().ToString = "System.DBNull" Then txtCountry.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Country")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Telephone").GetType().ToString = "System.DBNull" Then txtTelephone.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Telephone")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Fax").GetType().ToString = "System.DBNull" Then txtFax.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Fax")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Mobile").GetType().ToString = "System.DBNull" Then txtMobile.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Mobile")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Email").GetType().ToString = "System.DBNull" Then txtEmail.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Email")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("FK_PrContactId").GetType().ToString = "System.DBNull" Then PrContactSelect(objData.Tables.Item(0).Rows(intRowCount).Item("FK_PrContactId"))
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("DayOfBirth").GetType().ToString = "System.DBNull" Then dtpDateOfBirth.Value = objData.Tables.Item(0).Rows(intRowCount).Item("DayOfBirth")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Bankaccount").GetType().ToString = "System.DBNull" Then txtBankaccount.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Bankaccount")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("CreditCard").GetType().ToString = "System.DBNull" Then txtCreditCard.Text = objData.Tables.Item(0).Rows(intRowCount).Item("CreditCard")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardCcv").GetType().ToString = "System.DBNull" Then txtCreditCardCcv.Text = objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardCcv")
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardExpire").GetType().ToString = "System.DBNull" Then cbxCreditCardMonth.SelectedItem = objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardExpire").Substring(4, 2)
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardExpire").GetType().ToString = "System.DBNull" Then cbxCreditCardYear.SelectedItem = objData.Tables.Item(0).Rows(intRowCount).Item("CreditCardExpire").Substring(0, 4)
                    If Not objData.Tables.Item(0).Rows(intRowCount).Item("Mailinglist").GetType().ToString = "System.DBNull" Then chkMailinglist.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("Mailinglist")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("CustomField1").GetType().ToString = "System.DBNull" Then chkCustom1.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("CustomField1")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("CustomField2").GetType().ToString = "System.DBNull" Then chkCustom2.Checked = objData.Tables.Item(0).Rows(intRowCount).Item("CustomField2")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("CustomField3").GetType().ToString = "System.DBNull" Then txtCustom3.Text = objData.Tables.Item(0).Rows(intRowCount).Item("CustomField3")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("CustomField4").GetType().ToString = "System.DBNull" Then txtCustom4.Text = objData.Tables.Item(0).Rows(intRowCount).Item("CustomField4")
					If Not objData.Tables.Item(0).Rows(intRowCount).Item("Remarks").GetType().ToString = "System.DBNull" Then txtRemarks.Text = objData.Tables.Item(0).Rows(intRowCount).Item("Remarks")
				End If
			Next
            ResetColors()
		End If
	End Sub

	Private Sub ClearClient(Optional ByVal blnTotal As Boolean = False)
        txtClientNumber.Text = ""
        txtFirstName.Tag = 0
		txtFirstName.Text = ""
		txtMiddleName.Text = ""
		txtFamilyName.Text = ""
		txtStreet.Text = ""
		txtHouseNumber.Text = ""
		txtPostalCode.Text = ""
		txtCity.Text = ""
		txtCountry.Text = ""
		txtTelephone.Text = ""
		txtFax.Text = ""
		txtMobile.Text = ""
		txtEmail.Text = ""
        lvwPrContacts.SelectedItems.Clear()
		dtpDateOfBirth.Value = Today
        txtBankaccount.Text = ""
        txtCreditCard.Text = ""
        txtCreditCardCcv.Text = ""
        cbxCreditCardMonth.SelectedIndex = -1
        cbxCreditCardYear.SelectedIndex = -1
		chkMailinglist.Checked = False
		chkCustom1.Checked = False
		chkCustom2.Checked = False
		txtCustom3.Text = ""
		txtCustom4.Text = ""
		txtRemarks.Text = ""

		If blnMoveGroup = True Then
			btnMoveClient_Click(Nothing, Nothing)
		End If
		btnMoveClient.Enabled = False
		If blnTotal Then
			CurStatus.ClientID = 0
        End If
        ResetColors()
		'ClientsGet()
	End Sub

	Private Sub lvwGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwGroups.SelectedIndexChanged
		If lvwGroups.SelectedItems.Count = 1 Then
			CurStatus.GroupID = lvwGroups.SelectedItems.Item(0).Tag
			CurStatus.RefreshGroup = True
			If blnMoveGroup = False Then
				ClearClient(True)
				ClientsGet()
			End If
			If CurStatus.GroupID = 0 And CurStatus.GroupID = lvwGroups.SelectedItems.Item(0).Tag Then
				lblRequiredFamily.Visible = True
			Else
				lblRequiredFamily.Visible = False
			End If
		End If
	End Sub

	Private Sub lvwClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwClients.SelectedIndexChanged
		If lvwClients.SelectedItems.Count = 1 Then
			CurStatus.ClientID = lvwClients.SelectedItems.Item(0).Tag
			EditClient()
			CurStatus.RefreshGroup = True
			btnMoveClient.Enabled = True
		End If
	End Sub

	Private Sub btnMoveClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveClient.Click
		If blnMoveGroup = False Then
			blnMoveGroup = True
			btnMoveClient.BackColor = Color.LightGoldenrodYellow
			btnMoveClient.FlatStyle = FlatStyle.Flat
		Else
            blnMoveGroup = False
            UpdateClient()
			btnMoveClient.BackColor = System.Drawing.SystemColors.Control
			btnMoveClient.FlatStyle = FlatStyle.Standard
		End If
	End Sub

	Private Sub SecuritySet()
		btnDeleteClient.Enabled = False
		If CurUser.ClientsDelete Then btnDeleteClient.Enabled = True
    End Sub

    Private Sub PrContactSelect(ByVal intPrContactId)
        If intPrContactId > 0 Then
            For Each item As ListViewItem In lvwPrContacts.Items
                item.Selected = (CDbl(item.Tag) = intPrContactId)
            Next
            If lvwPrContacts.SelectedItems.Count = 1 Then
                lvwPrContacts.TopItem = lvwPrContacts.SelectedItems.Item(0)
                lvwPrContacts.Select()
            End If
        End If
    End Sub

    Private Sub SetButtonColor()
        If btnAddClient.BackColor = CurVar.BaseColor Then
            btnUpdateClient.BackColor = CurVar.ChangedTextColor
        End If
    End Sub

    Private Sub ResetColors()
        btnAddClient.BackColor = CurVar.BaseColor
        btnUpdateClient.BackColor = CurVar.BaseColor

        txtFirstName.BackColor = CurVar.UnSelectedColor
        txtMiddleName.BackColor = CurVar.UnSelectedColor
        txtFamilyName.BackColor = CurVar.UnSelectedColor
        txtStreet.BackColor = CurVar.UnSelectedColor
        txtHouseNumber.BackColor = CurVar.UnSelectedColor
        txtPostalCode.BackColor = CurVar.UnSelectedColor
        txtCity.BackColor = CurVar.UnSelectedColor
        txtCountry.BackColor = CurVar.UnSelectedColor
        txtTelephone.BackColor = CurVar.UnSelectedColor
        txtFax.BackColor = CurVar.UnSelectedColor
        txtMobile.BackColor = CurVar.UnSelectedColor
        txtEmail.BackColor = CurVar.UnSelectedColor
        dtpDateOfBirth.BackColor = CurVar.UnSelectedColor
        txtBankaccount.BackColor = CurVar.UnSelectedColor
        txtCreditCard.BackColor = CurVar.UnSelectedColor
        txtCreditCardCcv.BackColor = CurVar.UnSelectedColor
        cbxCreditCardMonth.BackColor = CurVar.UnSelectedColor
        cbxCreditCardYear.BackColor = CurVar.UnSelectedColor
        txtCustom3.BackColor = CurVar.UnSelectedColor
        txtCustom4.BackColor = CurVar.UnSelectedColor
        txtRemarks.BackColor = CurVar.UnSelectedColor
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        txtFirstName.BackColor = CurVar.ChangedTextColor
        btnAddClient.BackColor = CurVar.ChangedTextColor
        btnUpdateClient.BackColor = CurVar.BaseColor
    End Sub

    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged
        txtMiddleName.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtFamilyName_TextChanged(sender As Object, e As EventArgs) Handles txtFamilyName.TextChanged
        txtFamilyName.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtStreet_TextChanged(sender As Object, e As EventArgs) Handles txtStreet.TextChanged
        txtStreet.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtHouseNumber_TextChanged(sender As Object, e As EventArgs) Handles txtHouseNumber.TextChanged
        txtHouseNumber.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtPostalCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostalCode.TextChanged
        txtPostalCode.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged
        txtCity.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtCountry_TextChanged(sender As Object, e As EventArgs) Handles txtCountry.TextChanged
        txtCountry.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtTelephone_TextChanged(sender As Object, e As EventArgs) Handles txtTelephone.TextChanged
        txtTelephone.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtFax_TextChanged(sender As Object, e As EventArgs) Handles txtFax.TextChanged
        txtFax.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        txtMobile.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        txtEmail.BackColor = CurVar.ChangedTextColor
        chkMailinglist.Checked = True
        SetButtonColor()
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        dtpDateOfBirth.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtBankaccount_TextChanged(sender As Object, e As EventArgs) Handles txtBankaccount.TextChanged
        txtBankaccount.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtCreditCard_TextChanged(sender As Object, e As EventArgs) Handles txtCreditCard.TextChanged
        txtCreditCard.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtCreditCardCcv_TextChanged(sender As Object, e As EventArgs) Handles txtCreditCardCcv.TextChanged
        txtCreditCardCcv.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub cbxCreditCardMonth_TextChanged(sender As Object, e As EventArgs) Handles cbxCreditCardMonth.SelectedIndexChanged
        cbxCreditCardMonth.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub cbxCreditCardYear_TextChanged(sender As Object, e As EventArgs) Handles cbxCreditCardYear.SelectedIndexChanged
        cbxCreditCardYear.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub chkMailinglist_CheckedChanged(sender As Object, e As EventArgs) Handles chkMailinglist.CheckedChanged
        SetButtonColor()
    End Sub

    Private Sub chkCustom1_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustom1.CheckedChanged
        SetButtonColor()
    End Sub

    Private Sub chkCustom2_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustom2.CheckedChanged
        SetButtonColor()
    End Sub

    Private Sub txtCustom3_TextChanged(sender As Object, e As EventArgs) Handles txtCustom3.TextChanged
        txtCustom3.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtCustom4_TextChanged(sender As Object, e As EventArgs) Handles txtCustom4.TextChanged
        txtCustom4.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged
        txtRemarks.BackColor = CurVar.ChangedTextColor
        SetButtonColor()
    End Sub

    Private Sub txtGroupSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGroupSearch.TextChanged
        Dim foundItem As ListViewItem = _
    lvwGroups.FindItemWithText(txtGroupSearch.Text, False, 0, True)

        If (foundItem IsNot Nothing) Then
            lvwGroups.TopItem = foundItem
        End If
    End Sub
End Class