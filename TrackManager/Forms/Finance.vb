Public Class frmFinance

    Private previouslvwFinanceGroups As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwFinanceClients As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwProduct As ListViewItem 'To hold reference to previously selected TreeNode
    Private previouslvwInvoices As ListViewItem 'To hold reference to previously selected TreeNode

	Private Sub frmFinance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		BuildHandlers()
		SetLanguage(Me)
		SetScreenSettings()
        ProductsGet()
		TaxGet()
		GroupsGet()
	End Sub

	Private Sub SetScreenSettings()
		txtBilled.BackColor = CurVar.ReadOnlyBackColor
		txtPayed.BackColor = CurVar.ReadOnlyBackColor
		txtDue.BackColor = CurVar.ReadOnlyBackColor
	End Sub

	Private Sub ButtonsHandle()
		btnInvoiceAdd.Enabled = False
		btnDetailsAdd.Enabled = False
		btnDetailsSave.Enabled = False
		btnDetailsDelete.Enabled = False
		btnDetailsEdit.Enabled = False
		btnInvoiceDelete.Enabled = False
		btnInvoicePay.Enabled = False
		btnPaymentAdd.Enabled = False
		btnPaymentDelete.Enabled = False
		btncheckInvoices.Enabled = False

		If CurStatus.ClientID > 0 Then
            If txtProduct.Text.Length > 0 And IsNumeric(txtCount.Text) = True And IsNumeric(txtProductAmount.Text) = True And IsNumeric(cbxTax.Text) = True Then
                If CurUser.FinanceAdd Then btnInvoiceAdd.Enabled = True
                If CurStatus.InvoiceID > 0 Then
                    If CurUser.FinanceAdd Then btnDetailsAdd.Enabled = True
                    If lvwInvoiceLines.SelectedItems.Count = 1 Then
                        If CurUser.FinanceChange Then btnDetailsSave.Enabled = True
                    End If
                End If
            End If
            If CurStatus.InvoiceID > 0 Then
                If lvwInvoices.SelectedItems.Count = 1 Then
                    If lvwInvoices.SelectedItems.Item(0).SubItems(3).Text = lanStrings.strNo Then
                        btnInvoicePay.Enabled = True
                        If IsNumeric(txtPayAmount.Text) = True And IsNumeric(txtDue.Text) Then
                            If CInt(txtPayAmount.Text) > 0 And CInt(txtPayAmount.Text) <= CInt(txtDue.Text) Then
                                If CurUser.FinanceChange Then btnPaymentAdd.Enabled = True
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If lvwInvoiceLines.SelectedItems.Count = 1 And CurUser.FinanceChange = True Then
            btnDetailsEdit.Enabled = True
        End If
        If lvwInvoices.SelectedItems.Count = 1 And CurUser.FinanceDelete = True Then
            btnInvoiceDelete.Enabled = True
        End If
        If lvwInvoiceLines.SelectedItems.Count = 1 And CurUser.FinanceDelete = True Then
            btnDetailsDelete.Enabled = True
        End If
        If lvwPayments.SelectedItems.Count = 1 And CurUser.FinanceDelete = True Then
            btnPaymentDelete.Enabled = True
        End If
        If CurUser.FinanceDelete = True Then
            btncheckInvoices.Enabled = True
        End If
    End Sub

    Private Sub lvwFinanceGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFinanceGroups.SelectedIndexChanged
        If Not previouslvwFinanceGroups Is Nothing Then
            previouslvwFinanceGroups.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceGroups.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwFinanceGroups.SelectedItems.Count = 1 Then
            CurStatus.GroupID = lvwFinanceGroups.SelectedItems.Item(0).Tag
            CurStatus.RefreshGroup = True
            CurStatus.ClientID = 0
            FinanceClientsGet()
            InvoicesGet()
        End If
        ButtonsHandle()
    End Sub

    Private Sub lvwFinanceGroups_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles lvwFinanceGroups.Validating
        If lvwFinanceGroups.SelectedItems.Count = 1 Then
            lvwFinanceGroups.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceGroups.SelectedItems(0).ForeColor = Color.White
            previouslvwFinanceGroups = lvwFinanceGroups.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwFinanceClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFinanceClients.SelectedIndexChanged
        If Not previouslvwFinanceClients Is Nothing Then
            previouslvwFinanceClients.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceGroups.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwFinanceClients.SelectedItems.Count = 1 Then
            CurStatus.ClientID = lvwFinanceClients.SelectedItems.Item(0).Tag
            CurStatus.RefreshClient = True
        End If
        ButtonsHandle()
    End Sub

    Private Sub lvwFinanceClients_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles lvwFinanceClients.Validating
        If lvwFinanceClients.SelectedItems.Count = 1 Then
            lvwFinanceClients.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceClients.SelectedItems(0).ForeColor = Color.White
            previouslvwFinanceClients = lvwFinanceClients.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwInvoices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwInvoices.SelectedIndexChanged
        If Not previouslvwInvoices Is Nothing Then
            previouslvwInvoices.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceGroups.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwInvoices.SelectedItems.Count = 1 Then
            CurStatus.InvoiceID = lvwInvoices.SelectedItems.Item(0).Tag
            InvoiceLinesGet()
            InvoicePaymentsGet()
            txtPayAmount.Text = ""
        End If
        ButtonsHandle()
    End Sub

    Private Sub lvwInvoices_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles lvwInvoices.Validating
        If lvwInvoices.SelectedItems.Count = 1 Then
            lvwInvoices.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceClients.SelectedItems(0).ForeColor = Color.White
            previouslvwInvoices = lvwInvoices.SelectedItems(0)
        End If
    End Sub

    Private Sub BuildHandlers()
        AddHandler Me.lvwFinanceGroups.ColumnClick, AddressOf lvwFinanceGroups_ColumnClick
        lvwFinanceGroups.Columns.Add(New ColHeader("Group Name", "colGroupName", 100, HorizontalAlignment.Left, True))
        lvwFinanceGroups.Columns.Add(New ColHeader("Group Number", "colGroupNumber", 100, HorizontalAlignment.Left, True))
        AddHandler Me.lvwFinanceClients.ColumnClick, AddressOf lvwFinanceClients_ColumnClick
        lvwFinanceClients.Columns.Add(New ColHeader("First Name", "colFirstName", 80, HorizontalAlignment.Left, True))
        lvwFinanceClients.Columns.Add(New ColHeader("Middle Name", "colMiddleName", 40, HorizontalAlignment.Left, True))
        lvwFinanceClients.Columns.Add(New ColHeader("Family Name", "colFamilyName", 80, HorizontalAlignment.Left, True))

    End Sub

    Private Sub lvwFinanceGroups_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
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

    Private Sub lvwFinanceClients_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
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

    Private Sub GroupsGet()
        lvwFinanceGroups.Items.Clear()
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
                lvwFinanceGroups.Items.Add(lsvItem)
                CurStatus.ReloadGroups = False
                'CurStatus.GroupID = objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId")
                'MessageBox.Show(objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId"))
            End If
        Next
        If CurStatus.GroupID > 0 Then
            FinanceGroupSelect(CurStatus.GroupID)
        End If
    End Sub

    Private Sub FinanceClientsGet()
        If CurStatus.GroupID > 0 Then
            lvwFinanceClients.Items.Clear()
            Dim objData As DataSet
            objData = ClientsHandle("Get", CurStatus.GroupID)
            For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
                If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                    'MessageBox.Show("Cell Must be empty")
                Else
                    Dim lsvItem As New ListViewItem
                    lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_ClientId")
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
            If CurStatus.ClientID > 0 Then
                FinanceClientSelect()
            End If
        End If

    End Sub

    Private Sub ProductsGet()
        lvwProduct.Items.Clear()
        Dim objData As DataSet
        objData = ProductsHandle("Get")
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

    Private Sub TaxGet()
        cbxTax.Items.Clear()
        Dim objData As DataSet
        objData = TaxHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                cbxTax.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("PK_Tax"))
            End If
        Next
    End Sub

    Private Sub FinanceGroupSelect(ByVal dblGroupId)
        If dblGroupId > 0 Then
            If lvwFinanceGroups.SelectedItems.Count = 0 Then
                For Each item As ListViewItem In lvwFinanceGroups.Items
                    item.Selected = (CDbl(item.Tag) = dblGroupId)
                Next
                If lvwFinanceGroups.SelectedItems.Count = 1 Then
                    lvwFinanceGroups.TopItem = lvwFinanceGroups.SelectedItems.Item(0)
                    lvwFinanceGroups.Select()
                End If
                CurStatus.RefreshGroup = False
            ElseIf lvwFinanceGroups.SelectedItems(0).Tag <> dblGroupId Or CurStatus.RefreshGroup = True Then
                For Each item As ListViewItem In lvwFinanceGroups.Items
                    item.Selected = (CDbl(item.Tag) = dblGroupId)
                Next
                If lvwFinanceGroups.SelectedItems.Count = 1 Then
                    lvwFinanceGroups.TopItem = lvwFinanceGroups.SelectedItems.Item(0)
                    lvwFinanceGroups.Select()
                End If
                CurStatus.RefreshGroup = False
            End If
        End If
    End Sub

    Private Sub InvoiceSelect()
        If CurStatus.InvoiceID > 0 Then
            If lvwInvoices.SelectedItems.Count = 0 Then
                For Each item As ListViewItem In lvwInvoices.Items
                    item.Selected = (CDbl(item.Tag) = CurStatus.InvoiceID)
                Next
                If lvwInvoices.SelectedItems.Count = 1 Then
                    lvwInvoices.TopItem = lvwInvoices.SelectedItems.Item(0)
                    lvwInvoices.Select()
                End If
            ElseIf lvwInvoices.SelectedItems(0).Tag <> CurStatus.InvoiceID Then
                For Each item As ListViewItem In lvwInvoices.Items
                    item.Selected = (CDbl(item.Tag) = CurStatus.InvoiceID)
                Next
                If lvwInvoices.SelectedItems.Count = 1 Then
                    lvwInvoices.TopItem = lvwInvoices.SelectedItems.Item(0)
                    lvwInvoices.Select()
                End If
            End If
        End If
    End Sub

    Private Sub InvoicesClear(Optional ByVal blnAll As Boolean = False)
        If blnAll = True Then
            CurStatus.InvoiceID = 0
        End If
        lvwInvoices.Items.Clear()
        lvwInvoiceLines.Items.Clear()
        lvwPayments.Items.Clear()
        txtBilled.Text = ""
        txtProductAmount.Text = ""
        txtPayed.Text = ""
        txtPayAmount.Text = ""
        ButtonsHandle()
    End Sub

    Private Sub FinanceClientSelect()
        If CurStatus.ClientID > 0 Then
            If lvwFinanceClients.SelectedItems.Count = 0 Then
                For Each item As ListViewItem In lvwFinanceClients.Items
                    item.Selected = (CDbl(item.Tag) = CurStatus.ClientID)
                Next
                If lvwFinanceClients.SelectedItems.Count = 1 Then
                    lvwFinanceClients.TopItem = lvwFinanceClients.SelectedItems.Item(0)
                    lvwFinanceClients.Select()
                End If
                CurStatus.RefreshClient = False
            ElseIf lvwFinanceClients.SelectedItems(0).Tag <> CurStatus.ClientID Or CurStatus.RefreshClient = True Then
                For Each item As ListViewItem In lvwFinanceClients.Items
                    item.Selected = (CDbl(item.Tag) = CurStatus.ClientID)
                Next
                If lvwFinanceClients.SelectedItems.Count = 1 Then
                    lvwFinanceClients.TopItem = lvwFinanceClients.SelectedItems.Item(0)
                    lvwFinanceClients.Select()
                End If
                CurStatus.RefreshClient = False
            End If
        End If
    End Sub

    Private Sub InvoicesGet()
        lvwInvoices.Items.Clear()
        lvwInvoiceLines.Items.Clear()
        lvwPayments.Items.Clear()

        If CurStatus.GroupID > 0 Then

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
                    Dim strPayed As String = lanStrings.strNo
                    If objData.Tables.Item(0).Rows(intRowCount).Item("Payed") = 1 Or objData.Tables.Item(0).Rows(intRowCount).Item("Payed") = "True" Then
                        strPayed = lanStrings.strYes
                    End If
                    lsvItem.SubItems.Add(strPayed)
                    lvwInvoices.Items.Add(lsvItem)

                End If
            Next

        End If
    End Sub

    Private Sub InvoiceLinesGet()
        txtBilled.Text = ""
        Dim sinBilled As Single = 0

        lvwInvoiceLines.Items.Clear()
        Dim objData As DataSet = InvoiceLinesHandle("Get", 0, CurStatus.InvoiceID)

        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_InvoiceLineID")

                Dim strName As String = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then
                    strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
                End If
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then
                    strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
                End If
                lsvItem.Text = strName
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("LoginName"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Description"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Count"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Amount"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("FK_Tax"))
                lvwInvoiceLines.Items.Add(lsvItem)
                sinBilled += objData.Tables.Item(0).Rows(intRowCount).Item("Amount")
            End If
        Next
        txtBilled.Text = sinBilled
        If IsNumeric(txtBilled.Text) = True And IsNumeric(txtPayed.Text) = True Then
            txtDue.Text = txtBilled.Text - txtPayed.Text
        End If
    End Sub

    Private Sub InvoicePaymentsGet()
        txtPayed.Text = ""
        Dim sinPayed As Single = 0

        lvwPayments.Items.Clear()
        Dim objData As DataSet = InvoicePaymentsHandle("Get", 0, CurStatus.InvoiceID)

        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_InvoicePaymentID")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("PayDate")

                Dim strName As String = objData.Tables.Item(0).Rows(intRowCount).Item("FirstName")
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName").GetType().ToString = "System.DBNull" Then
                    strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("MiddleName")
                End If
                If Not objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName").GetType().ToString = "System.DBNull" Then
                    strName &= " " & objData.Tables.Item(0).Rows(intRowCount).Item("FamilyName")
                End If
                lsvItem.SubItems.Add(strName)
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("LoginName"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Amount"))
                lvwPayments.Items.Add(lsvItem)
                sinPayed += objData.Tables.Item(0).Rows(intRowCount).Item("Amount")
            End If
        Next
        txtPayed.Text = sinPayed
        If IsNumeric(txtBilled.Text) = True And IsNumeric(txtPayed.Text) = True Then
            txtDue.Text = txtBilled.Text - txtPayed.Text
        End If
    End Sub

    Private Sub lvwProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwProduct.SelectedIndexChanged
        If Not previouslvwProduct Is Nothing Then
            previouslvwProduct.BackColor = CurVar.UnSelectedColor
            'previouslvwFinanceGroups.ForeColor = lvwAppClients.ForeColor
        End If
        If lvwProduct.SelectedItems.Count = 1 Then
            txtProduct.Text = lvwProduct.SelectedItems(0).Text
            txtCount.Text = lvwProduct.SelectedItems(0).SubItems(1).Text
            txtProductAmount.Text = lvwProduct.SelectedItems(0).SubItems(2).Text
            cbxTax.SelectedItem = lvwProduct.SelectedItems(0).SubItems(3).Text
            cbxTax.Text = lvwProduct.SelectedItems(0).SubItems(3).Text
        End If
        ButtonsHandle()
    End Sub

    Private Sub lvwProduct_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles lvwProduct.Validating
        If lvwProduct.SelectedItems.Count = 1 Then
            lvwProduct.SelectedItems(0).BackColor = CurVar.SelectedColor
            'lvwFinanceGroups.SelectedItems(0).ForeColor = Color.White
            previouslvwProduct = lvwProduct.SelectedItems(0)
        End If
    End Sub

    Private Sub lvwInvoiceLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwInvoiceLines.Click
        ButtonsHandle()
    End Sub

    Private Sub lvwPayments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPayments.Click
        ButtonsHandle()
    End Sub

    Private Sub btnInvoiceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceAdd.Click
        Dim dtmDate As DateTime = Today
        InvoiceNumberGet()
        Dim objData As DataSet = FinancesHandle("Add", 0, CurVar.InvoiceName, FormatString(CurVar.InvoiceNumber, 3), 0, dtmDate, CurStatus.GroupID, CurStatus.ClientID, CurUser.LoginID, 0, txtProduct.Text, CInt(txtCount.Text), CSng(txtProductAmount.Text), CSng(cbxTax.Text))
        'btnInvoiceAdd.Enabled = False
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                CurStatus.InvoiceID = objData.Tables.Item(0).Rows(intRowCount).Item(0)
            End If
        Next
        InvoicesGet()
        InvoiceSelect()
    End Sub

    Private Sub btnDetailsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailsAdd.Click
        InvoiceLinesHandle("Add", 0, CurStatus.InvoiceID, CurStatus.ClientID, CurUser.LoginID, txtProduct.Text, CInt(txtCount.Text), CSng(txtProductAmount.Text), CSng(cbxTax.Text))
        InvoicesHandle("chk", CurStatus.InvoiceID)
        InvoicesGet()
        InvoiceSelect()
    End Sub

    Private Sub btnDetailsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailsSave.Click
        InvoiceLinesHandle("Upd", lvwInvoiceLines.SelectedItems.Item(0).Tag, CurStatus.InvoiceID, CurStatus.ClientID, CurUser.LoginID, txtProduct.Text, CInt(txtCount.Text), CSng(txtProductAmount.Text), CSng(cbxTax.Text))
        InvoicesHandle("chk", CurStatus.InvoiceID)
        InvoicesGet()
        InvoiceSelect()
    End Sub

    Private Sub btnInvoicePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoicePay.Click
        Dim dtmDate As DateTime = Today
        If CInt(txtDue.Text) > 0 Then
            InvoicePaymentsHandle("Add", 0, CurStatus.InvoiceID, dtmDate, CurStatus.ClientID, CurUser.LoginID, CSng(txtDue.Text))
        End If
        InvoicesHandle("chk", CurStatus.InvoiceID)
        'InvoicesHandle("Pay", CurStatus.InvoiceID, Nothing, 0, 0, 1)
        txtPayAmount.Text = ""
        InvoicesGet()
        InvoiceSelect()
    End Sub

    Private Sub btnInvoiceDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceDelete.Click
        If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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
            InvoicesClear(True)
            InvoicesGet()
        End If
    End Sub

    Private Sub btnDetailsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailsEdit.Click
        If lvwInvoiceLines.SelectedItems.Count = 1 Then
            txtProduct.Text = lvwInvoiceLines.SelectedItems(0).SubItems(2).Text
            txtCount.Text = lvwInvoiceLines.SelectedItems(0).SubItems(3).Text
            txtProductAmount.Text = lvwInvoiceLines.SelectedItems(0).SubItems(4).Text
            cbxTax.SelectedItem = lvwInvoiceLines.SelectedItems(0).SubItems(5).Text
            cbxTax.Text = lvwInvoiceLines.SelectedItems(0).SubItems(5).Text
        End If
        ButtonsHandle()
    End Sub

    Private Sub btnDetailsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailsDelete.Click
        If lvwInvoiceLines.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                InvoiceLinesHandle("Del", lvwInvoiceLines.SelectedItems.Item(0).Tag)
                InvoicesHandle("chk", CurStatus.InvoiceID)
                'InvoicesHandle("Pay", CurStatus.InvoiceID, Nothing, 0, 0, 0)
                InvoicesGet()
                InvoiceSelect()
            End If
        End If
    End Sub

    Private Sub btnPaymentAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentAdd.Click
        Dim dtmDate As DateTime = Today
        InvoicePaymentsHandle("Add", 0, CurStatus.InvoiceID, dtmDate, CurStatus.ClientID, CurUser.LoginID, CSng(txtPayAmount.Text))
        If txtDue.Text = txtPayAmount.Text Then
            InvoicesHandle("Pay", CurStatus.InvoiceID, Nothing, Nothing, 0, 0, 1)
        Else
            InvoicesHandle("Pay", CurStatus.InvoiceID, Nothing, Nothing, 0, 0, 0)
        End If
        InvoicePaymentsGet()
        txtPayAmount.Text = ""
        InvoicesGet()
        InvoiceSelect()

    End Sub

    Private Sub btnPaymentDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentDelete.Click
        If lvwPayments.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                InvoicePaymentsHandle("Del", lvwPayments.SelectedItems.Item(0).Tag)
                InvoicesHandle("chk", CurStatus.InvoiceID)
                'InvoicesHandle("Pay", CurStatus.InvoiceID, Nothing, 0, 0, 0)
                InvoicesGet()
                InvoiceSelect()
                'InvoicePaymentsGet()
            End If
        End If
    End Sub

    Private Sub txtProduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        ButtonsHandle()
    End Sub

    Private Sub txtCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCount.TextChanged
        ButtonsHandle()
    End Sub

    Private Sub txtDesciptionAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductAmount.TextChanged
        ButtonsHandle()
    End Sub

	Private Sub txtPayAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub cbxTax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxTax.TextChanged
		ButtonsHandle()
	End Sub

	Private Sub btncheckInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheckInvoices.Click
		InvoicesHandle("chk")
		InvoicesClear()
		InvoicesGet()
		InvoiceSelect()
	End Sub

    Private Sub txtGroupSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGroupSearch.TextChanged
        Dim foundItem As ListViewItem = lvwFinanceGroups.FindItemWithText(txtGroupSearch.Text, False, 0, True)
        If (foundItem IsNot Nothing) Then
            lvwFinanceGroups.TopItem = foundItem
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class