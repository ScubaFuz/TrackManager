Imports System.IO
Imports System.Globalization
Imports System.Xml

Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If blnLicenseValidated = False Then
        '    For Each tpgExists In tabSettings.TabPages
        '        If Not tpgExists.Name = "tpgLicense" Then
        '            tpgExists.Dispose()
        '        End If
        '    Next
        '    btnExitTrackManager.Visible = True
        '    tabSettings.SelectTab(tpgLicense)
        '    Exit Sub
        'End If
        ShowDatabase()
        If blnDatabaseOnLine = False Then
            For Each tpgExists In tabSettings.TabPages
                If Not tpgExists.Name = "tpgDatabase" Then
                    tpgExists.Dispose()
                End If
            Next
            tabSettings.SelectTab(tpgDatabase)
            btnCreateDatabase.Enabled = True
            Exit Sub
        End If

        SecuritySet()
        If LoadVersion() = True Then
            For Each tpgExists In tabSettings.TabPages
                If Not tpgExists.Name = "tpgDatabase" Then
                    tpgExists.Dispose()
                End If
            Next
            tabSettings.SelectTab(tpgDatabase)
            btnUpgradeDatabase.BackColor = CurVar.ChangedColor
            Exit Sub
        End If
        If Not DebugMode Then
            tabSettings.TabPages("tpgPaymentMethod").Dispose()
            tabSettings.TabPages("tpgReports").Dispose()
        End If
        ShowColors()
        LoadLanguageList()
        LanguageDbLoad(CurVar.Language)
        LoadSettings()
        If blnDatabaseOnLine = True Then
            SetLanguage(Me)
            LoadBackupPath()
        End If

    End Sub

    Private Sub LoadSettings()
        ShowViewSettings()
        ShowGeneralSettings()
        ShowLogSettings()
        TracksGet()
        LessonTypesGet()
        LevelsGet()
        ProductsGet()
        PrContactsGet()
        TaxGet()
        LoadLicense()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If blnDatabaseOnLine = False Then
        '    Application.Restart()
        'End If
        Me.Dispose()
    End Sub

    Private Sub ShowColors()
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            cbxLessonTypeColor.Items.AddRange(New Object() {enumValue.ToString})
            cbxLevelColor.Items.AddRange(New Object() {enumValue.ToString})
            cbxOnHoursColor.Items.AddRange(New Object() {enumValue.ToString})
            cbxOffHoursColor.Items.AddRange(New Object() {enumValue.ToString})
            cbxReadOnlyBackColor.Items.AddRange(New Object() {enumValue.ToString})
        Next enumValue

    End Sub

    Private Sub SecuritySet()
        btnDeleteProduct.Enabled = False
        btnDeleteLessonType.Enabled = False
        btnDeleteLevel.Enabled = False
        btnDeletePrContact.Enabled = False
        btnDeleteTrack.Enabled = False
        btnDeleteTax.Enabled = False
        btnDeleteLanguage.Enabled = False
        btnEditProduct.Enabled = False
        btnEditLessonType.Enabled = False
        btnEditLevel.Enabled = False
        btnEditPrContact.Enabled = False
        btnEditTrack.Enabled = False
        btnEditTax.Enabled = False
        btnEditLanguage.Enabled = False
        btnSaveSettingsGeneral.Enabled = False
        btnSaveSettingsDatabase.Enabled = False
        btnSaveSettingsLog.Enabled = False
        btnSaveSettingsView.Enabled = False
        btnUpgradeDatabase.Enabled = False
        btnCreateDatabase.Enabled = False
        btnSaveSettingsEmail.Enabled = False
        btnSaveSettingsLanguage.Enabled = False

        If CurUser.SettingsChange Then
            btnEditProduct.Enabled = True
            btnEditLessonType.Enabled = True
            btnEditLevel.Enabled = True
            btnEditPrContact.Enabled = True
            btnEditTrack.Enabled = True
            btnEditTax.Enabled = True
            btnEditLanguage.Enabled = True
        End If

        If CurUser.SettingsDelete Then
            btnDeleteProduct.Enabled = True
            btnDeleteLessonType.Enabled = True
            btnDeleteLevel.Enabled = True
            btnDeletePrContact.Enabled = True
            btnDeleteTrack.Enabled = True
            btnDeleteTax.Enabled = True
            btnDeleteLanguage.Enabled = True
            btnSaveSettingsGeneral.Enabled = True
            btnSaveSettingsDatabase.Enabled = True
            btnSaveSettingsLog.Enabled = True
            btnSaveSettingsView.Enabled = True
            btnSaveSettingsEmail.Enabled = True
            btnSaveSettingsLanguage.Enabled = True
        End If

        If CurUser.SecurityAdd = True Then
            btnUpgradeDatabase.Enabled = True
            btnCreateDatabase.Enabled = True
        End If

    End Sub

#Region "General"
    Private Sub btnSaveSettingsGeneral_Click(sender As Object, e As EventArgs) Handles btnSaveSettingsGeneral.Click
        If IsNumeric(txtInvoiceNumber.Text) = False Then
            MessageBox.Show(lanStrings.strNumeric & vbCrLf & lanStrings.strCheckSettings)
            Exit Sub
        End If

        CurVar.DeleteEmptyInvoice = chkDeleteEmptyInvoice.Checked
        CurVar.SelectMultipleGroups = chkSelectMultipleGroups.Checked
        CurVar.InvoiceName = txtInvoiceName.Text
        CurVar.InvoiceNumber = txtInvoiceNumber.Text
        CurVar.ShowLastAppointment = chkShowLastAppointment.Checked
        CurVar.DateFormat = cbxDateFormat.SelectedItem
        CurVar.ShowAllLessonTypes = chkShowAllLessonTypes.Checked
        CurVar.RequireLessontype = chkRequireLessontype.Checked
        CurVar.DeleteMax1Client = chkDeleteMax1Client.Checked

        If rbnOverbookingNone.Checked = True Then CurVar.OverbookWarning = 0
        If rbnOverbookingGroup.Checked = True Then CurVar.OverbookWarning = 1
        If rbnOverbookingClient.Checked = True Then CurVar.OverbookWarning = 2

        If rbnShowOpenBillsNone.Checked = True Then CurVar.ShowMoney = 0
        If rbnShowOpenBillsClient.Checked = True Then CurVar.ShowMoney = 1
        If rbnShowOpenBillsGroup.Checked = True Then CurVar.ShowMoney = 2

        SaveConfigSetting("General", "DeleteEmptyInvoice", CurVar.DeleteEmptyInvoice)
        SaveConfigSetting("General", "SelectMultipleGroups", CurVar.SelectMultipleGroups)
        SaveConfigSetting("General", "InvoiceName", CurVar.InvoiceName)
        SaveConfigSetting("General", "InvoiceNumber", CurVar.InvoiceNumber)
        SaveConfigSetting("General", "OverbookWarning", CurVar.OverbookWarning)
        SaveConfigSetting("General", "ShowMoney", CurVar.OverbookWarning)
        SaveConfigSetting("General", "ShowLastAppointment", CurVar.ShowLastAppointment)
        SaveConfigSetting("General", "DateFormat", CurVar.DateFormat)
        SaveConfigSetting("General", "ShowAllLessonTypes", CurVar.ShowAllLessonTypes)
        SaveConfigSetting("General", "RequireLessontype", CurVar.RequireLessontype)
        SaveConfigSetting("General", "DeleteMax1Client", CurVar.DeleteMax1Client)

    End Sub

    Private Sub ShowGeneralSettings()
        txtInvoiceName.Text = CurVar.InvoiceName
        txtInvoiceNumber.Text = CurVar.InvoiceNumber
        chkDeleteEmptyInvoice.Checked = CurVar.DeleteEmptyInvoice
        chkSelectMultipleGroups.Checked = CurVar.SelectMultipleGroups
        chkShowLastAppointment.Checked = CurVar.ShowLastAppointment
        cbxDateFormat.SelectedItem = CurVar.DateFormat
        chkShowAllLessonTypes.Checked = CurVar.ShowAllLessonTypes
        chkRequireLessontype.Checked = CurVar.RequireLessontype
        chkDeleteMax1Client.Checked = CurVar.DeleteMax1Client

        Select Case CurVar.OverbookWarning
            Case 0
                rbnOverbookingNone.Checked = True
            Case 1
                rbnOverbookingGroup.Checked = True
            Case 2
                rbnOverbookingClient.Checked = True
        End Select

        Select Case CurVar.ShowMoney
            Case 0
                rbnShowOpenBillsNone.Checked = True
            Case 1
                rbnShowOpenBillsClient.Checked = True
            Case 2
                rbnShowOpenBillsGroup.Checked = True
        End Select
    End Sub


#End Region

#Region "Tracks"

    Private Sub TracksGet()
        lvwTracks.Items.Clear()
        Dim objData As DataSet
        objData = TracksHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_TrackId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("TrackOffset"))
                lvwTracks.Items.Add(lsvItem)
            End If
        Next

    End Sub

    Private Sub lsvTracks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwTracks.DoubleClick
        EditTrack()
    End Sub

    Private Sub btnEditTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTrack.Click
        EditTrack()
    End Sub

    Private Sub btnDeleteTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTrack.Click
        If lvwTracks.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                TracksHandle("Del", lvwTracks.SelectedItems.Item(0).Tag)
                ClearTrack()
            End If
        ElseIf lvwTracks.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnAddTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrack.Click
        If txtTrackName.Tag > 0 Then
            'Update mode
            If txtTrackName.Text.Length > 0 And txtTrackOffset.Text.Length > 0 Then
                TracksHandle("Upd", txtTrackName.Tag, txtTrackName.Text, txtTrackOffset.Text)
                ClearTrack()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        Else
            'Add mode
            If txtTrackName.Text.Length > 0 And txtTrackOffset.Text.Length > 0 Then
                TracksHandle("Add", 0, txtTrackName.Text, txtTrackOffset.Text)
                ClearTrack()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        End If
    End Sub

    Private Sub btnClearTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTrack.Click
        ClearTrack()
    End Sub

    Private Sub EditTrack()
        If CurUser.SettingsChange Then
            If lvwTracks.SelectedItems.Count = 1 Then
                txtTrackName.Tag = lvwTracks.SelectedItems.Item(0).Tag
                txtTrackName.Text = lvwTracks.SelectedItems.Item(0).Text
                txtTrackOffset.Text = lvwTracks.SelectedItems.Item(0).SubItems.Item(1).Text
                btnAddTrack.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearTrack()
        txtTrackName.Tag = 0
        txtTrackName.Text = ""
        txtTrackOffset.Text = ""
        btnAddTrack.Text = lanStrings.strAdd
        TracksGet()
    End Sub

#End Region

#Region "Lesson Types"

    Private Sub LessonTypesGet()
        lvwLessonTypes.Items.Clear()
        Dim objData As DataSet
        objData = LessonTypesHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LessonTypeId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Color"))
                lvwLessonTypes.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub lsvLessonTypes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwLessonTypes.DoubleClick
        EditLessonType()
    End Sub

    Private Sub btnEditLessonType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLessonType.Click
        EditLessonType()
    End Sub

    Private Sub btnDeleteLessonType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLessonType.Click
        If lvwLessonTypes.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                LessonTypesHandle("Del", lvwLessonTypes.SelectedItems.Item(0).Tag)
                ClearLessonType()
            End If
        ElseIf lvwLessonTypes.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub btnAddLessonType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLessonType.Click
        If txtLessonTypeName.Tag > 0 Then
            'Update mode
            If txtLessonTypeName.Text.Length > 0 And cbxLessonTypeColor.Text.Length > 0 Then
                LessonTypesHandle("Upd", txtLessonTypeName.Tag, txtLessonTypeName.Text, cbxLessonTypeColor.SelectedItem)
                ClearLessonType()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        Else
            'Add mode
            If txtLessonTypeName.Text.Length > 0 And cbxLessonTypeColor.Text.Length > 0 Then
                LessonTypesHandle("Add", 0, txtLessonTypeName.Text, cbxLessonTypeColor.SelectedItem)
                ClearLessonType()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        End If
    End Sub

    Private Sub btnClearLessonType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLessonType.Click
        ClearLessonType()
    End Sub

    Private Sub EditLessonType()
        If CurUser.SettingsChange Then
            If lvwLessonTypes.SelectedItems.Count = 1 Then
                txtLessonTypeName.Tag = lvwLessonTypes.SelectedItems.Item(0).Tag
                txtLessonTypeName.Text = lvwLessonTypes.SelectedItems.Item(0).Text
                cbxLessonTypeColor.SelectedItem = lvwLessonTypes.SelectedItems.Item(0).SubItems.Item(1).Text
                btnAddLessonType.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearLessonType()
        txtLessonTypeName.Tag = 0
        txtLessonTypeName.Text = ""
        cbxLessonTypeColor.SelectedIndex = -1
        cbxLessonTypeColor.Text = ""
        btnAddLessonType.Text = lanStrings.strAdd
        LessonTypesGet()
    End Sub

#End Region

#Region "Levels"

    Private Sub LevelsGet()
        lvwLevels.Items.Clear()
        Dim objData As DataSet
        objData = LevelsHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LevelId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LevelName")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Color"))
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("LevelCount"))
                lvwLevels.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub lsvLevels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwLevels.DoubleClick
        EditLevel()
    End Sub

    Private Sub btnEditLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLevel.Click
        If lvwLevels.SelectedItems.Item(0).Text = "Automatic" Then
            MessageBox.Show("You cannot delete or change the level 'Automatic'", lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        EditLevel()
    End Sub

    Private Sub btnDeleteLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLevel.Click
        If lvwLevels.SelectedItems.Count = 1 Then
            If lvwLevels.SelectedItems.Item(0).Text = "Automatic" Then
                MessageBox.Show("You cannot delete or change the level 'Automatic'", lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                LevelsHandle("Del", lvwLevels.SelectedItems.Item(0).Tag)
                ClearLevel()
            End If
        ElseIf lvwLevels.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnAddLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLevel.Click
        If txtLevelName.Text.Length > 0 Then
            If txtLevelName.Text = "Automatic" Then
                Exit Sub
            End If
        End If
        If txtLevelName.Tag > 0 Then
            'Update mode
            If txtLevelName.Text.Length > 0 And cbxLevelColor.Text.Length > 0 And txtLevelCount.Text.Length > 0 Then
                LevelsHandle("Upd", txtLevelName.Tag, txtLevelName.Text, cbxLevelColor.SelectedItem, txtLevelCount.Text)
                ClearLevel()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        Else
            'Add mode
            If txtLevelName.Text.Length > 0 And cbxLevelColor.Text.Length > 0 And txtLevelCount.Text.Length > 0 Then
                LevelsHandle("Add", 0, txtLevelName.Text, cbxLevelColor.SelectedItem, txtLevelCount.Text)
                ClearLevel()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        End If
    End Sub

    Private Sub btnClearLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLevel.Click
        ClearLevel()
    End Sub

    Private Sub EditLevel()
        If CurUser.SettingsChange Then
            If lvwLevels.SelectedItems.Count = 1 Then
                txtLevelName.Tag = lvwLevels.SelectedItems.Item(0).Tag
                txtLevelName.Text = lvwLevels.SelectedItems.Item(0).Text
                cbxLevelColor.SelectedItem = lvwLevels.SelectedItems.Item(0).SubItems.Item(1).Text
                txtLevelCount.Text = lvwLevels.SelectedItems.Item(0).SubItems.Item(2).Text
                btnAddLevel.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearLevel()
        txtLevelName.Tag = 0
        txtLevelName.Text = ""
        cbxLevelColor.SelectedIndex = -1
        cbxLevelColor.Text = ""
        txtLevelCount.Text = ""
        btnAddLevel.Text = lanStrings.strAdd
        LevelsGet()
    End Sub

#End Region

#Region "Products"
    Private Sub ProductsGet()
        lvwProducts.Items.Clear()
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
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("Sort"))
                lvwProducts.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub btnEditProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditProduct.Click
        EditProduct()
    End Sub

    Private Sub btnDeleteProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteProduct.Click
        If lvwProducts.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ProductsHandle("Del", lvwProducts.SelectedItems.Item(0).Tag)
                ClearProduct()
            End If
        ElseIf lvwProducts.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        Dim decResult As Decimal
        Dim intResult As Integer

        If txtProduct.Text.Length > 0 And Integer.TryParse(txtProductCount.Text, intResult) = True And Decimal.TryParse(txtProductAmount.Text, decResult) = True Then
            If txtProduct.Tag > 0 Then
                'Update mode
                ProductsHandle("Upd", txtProduct.Tag, txtProduct.Text, txtProductCount.Text, txtProductAmount.Text, cbxProductTax.SelectedItem, txtProductSort.Text)
            Else
                'Add mode
                ProductsHandle("Add", 0, txtProduct.Text, txtProductCount.Text, txtProductAmount.Text, cbxProductTax.SelectedItem, txtProductSort.Text)
            End If
            ClearProduct()
        Else
            MessageBox.Show(lanStrings.strAllData)
        End If

    End Sub

    Private Sub btnClearProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearProduct.Click
        ClearProduct()
    End Sub

    Private Sub lvwProducts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProducts.DoubleClick
        EditProduct()
    End Sub

    Private Sub EditProduct()
        If CurUser.SettingsChange Then
            If lvwProducts.SelectedItems.Count = 1 Then
                txtProduct.Tag = lvwProducts.SelectedItems.Item(0).Tag
                txtProduct.Text = lvwProducts.SelectedItems.Item(0).Text
                txtProductCount.Text = lvwProducts.SelectedItems.Item(0).SubItems.Item(1).Text
                txtProductAmount.Text = lvwProducts.SelectedItems.Item(0).SubItems.Item(2).Text
                cbxProductTax.SelectedItem = lvwProducts.SelectedItems.Item(0).SubItems.Item(3).Text
                txtProductSort.Text = lvwProducts.SelectedItems.Item(0).SubItems.Item(4).Text
                btnAddProduct.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearProduct()
        txtProduct.Tag = 0
        txtProduct.Text = ""
        txtProductCount.Text = ""
        txtProductAmount.Text = ""
        cbxProductTax.SelectedIndex = -1
        txtProductSort.Text = ""
        btnAddProduct.Text = lanStrings.strAdd
        ProductsGet()
    End Sub

    Private Sub txtProductAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductAmount.TextChanged
        'MessageBox.Show("Decimal sign: " & CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        If CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = "," Then
            If txtProductAmount.Text.Contains(".") Then
                txtProductAmount.Text = txtProductAmount.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                txtProductAmount.Select(txtProductAmount.Text.LastIndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1, 0)
            End If
        ElseIf CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = "." Then
            If txtProductAmount.Text.Contains(",") Then
                txtProductAmount.Text = txtProductAmount.Text.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                txtProductAmount.Select(txtProductAmount.Text.LastIndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1, 0)
            End If
        End If

    End Sub

#End Region

#Region "PrContacts"

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

    Private Sub lsvPrContacts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPrContacts.DoubleClick
        EditPrContact()
    End Sub

    Private Sub btnEditPrContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPrContact.Click
        EditPrContact()
    End Sub

    Private Sub btnDeletePrContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePrContact.Click
        If lvwPrContacts.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                PrContactsHandle("Del", lvwPrContacts.SelectedItems.Item(0).Tag)
                ClearPrContact()
            End If
        ElseIf lvwPrContacts.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnAddPrContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPrContact.Click
        If txtPrContact.Tag > 0 Then
            'Update mode
            If txtPrContact.Text.Length > 0 Then
                PrContactsHandle("Upd", txtPrContact.Tag, txtPrContact.Text)
                ClearPrContact()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        Else
            'Add mode
            If txtPrContact.Text.Length > 0 Then
                PrContactsHandle("Add", 0, txtPrContact.Text)
                ClearPrContact()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
        End If

    End Sub

    Private Sub btnClearPrContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPrContact.Click
        ClearPrContact()
    End Sub

    Private Sub EditPrContact()
        If CurUser.SettingsChange Then
            If lvwPrContacts.SelectedItems.Count = 1 Then
                txtPrContact.Tag = lvwPrContacts.SelectedItems.Item(0).Tag
                txtPrContact.Text = lvwPrContacts.SelectedItems.Item(0).Text
                btnAddPrContact.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearPrContact()
        txtPrContact.Tag = 0
        txtPrContact.Text = ""
        btnAddPrContact.Text = lanStrings.strAdd
        PrContactsGet()
    End Sub

#End Region

#Region "Tax"
    Private Sub TaxGet()
        lvwTax.Items.Clear()
        cbxProductTax.Items.Clear()
        Dim objData As DataSet
        objData = TaxHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_Tax")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TaxValue")
                lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("TaxDescription"))
                lvwTax.Items.Add(lsvItem)

                cbxProductTax.Items.Add(objData.Tables.Item(0).Rows(intRowCount).Item("TaxValue"))
            End If
        Next
    End Sub

    Private Sub lsvProducts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwTax.DoubleClick
        EditTax()
    End Sub

    Private Sub btnEditTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTax.Click
        EditTax()
    End Sub

    Private Sub btnDeleteTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTax.Click
        If lvwTax.SelectedItems.Count = 1 Then
            If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                TaxHandle("Del", lvwTax.SelectedItems.Item(0).Tag)
                ClearTax()
            End If
        ElseIf lvwTax.SelectedItems.Count > 1 Then
            MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub btnAddTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTax.Click
        Dim intResult As Integer

        If Integer.TryParse(txtTaxValue.Text, intResult) = True And txtTaxDescription.Text.Length > 0 = True Then
            If txtTaxValue.Tag > 0 Then
                'Update mode
                TaxHandle("Upd", txtTaxValue.Tag, txtTaxValue.Text, txtTaxDescription.Text)
            Else
                'Add mode
                TaxHandle("Add", 0, txtTaxValue.Text, txtTaxDescription.Text)
            End If
            ClearTax()
        Else
            MessageBox.Show(lanStrings.strAllData)
        End If

    End Sub

    Private Sub btnClearTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTax.Click
        ClearTax()
    End Sub

    Private Sub EditTax()
        If CurUser.SettingsChange Then
            If lvwTax.SelectedItems.Count = 1 Then
                txtTaxValue.Tag = lvwTax.SelectedItems.Item(0).Tag
                txtTaxValue.Text = lvwTax.SelectedItems.Item(0).Text
                txtTaxDescription.Text = lvwTax.SelectedItems.Item(0).SubItems.Item(1).Text
                btnAddTax.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub ClearTax()
        txtTaxValue.Tag = 0
        txtTaxValue.Text = ""
        txtTaxDescription.Text = ""
        btnAddTax.Text = lanStrings.strAdd
        TaxGet()
    End Sub


#End Region

#Region "Log"

    Private Sub ShowLogSettings()
        Select Case TxtHandle.LogLevel
            Case 0
                rbtLoggingLevel0.Checked = True
            Case 1
                rbtLoggingLevel1.Checked = True
            Case 2
                rbtLoggingLevel2.Checked = True
            Case 3
                rbtLoggingLevel3.Checked = True
            Case 4
                rbtLoggingLevel4.Checked = True
            Case 5
                rbtLoggingLevel5.Checked = True
        End Select
        txtLogfileName.Text = TxtHandle.LogFileName
        txtLogfileLocation.Text = TxtHandle.LogLocation
        'If TxtHandle.LogLocation.ToLower = "database" Then grpLogsToKeep.Visible = True

        chkAutoDeleteOldLogs.Checked = CurVar.LogDeleteAuto
        Select Case CurVar.LogDelete
            Case "Day"
                rbtKeepLogDay.Checked = True
            Case "Week"
                rbtKeepLogWeek.Checked = True
            Case "Month"
                rbtKeepLogMonth.Checked = True
            Case Else
                'Exit Sub
        End Select
    End Sub

    Private Sub btnSaveSettingsLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettingsLog.Click
        TxtHandle.LogLocation = txtLogfileLocation.Text
        TxtHandle.LogFileName = txtLogfileName.Text
        If rbtLoggingLevel0.Checked Then
            TxtHandle.LogLevel = 0
        ElseIf rbtLoggingLevel1.Checked Then
            TxtHandle.LogLevel = 1
        ElseIf rbtLoggingLevel2.Checked Then
            TxtHandle.LogLevel = 2
        ElseIf rbtLoggingLevel3.Checked Then
            TxtHandle.LogLevel = 3
        ElseIf rbtLoggingLevel4.Checked Then
            TxtHandle.LogLevel = 4
        ElseIf rbtLoggingLevel5.Checked Then
            TxtHandle.LogLevel = 5
        End If
        SaveConfigSetting("LogFile", "LogLocation", TxtHandle.LogLocation)
        SaveConfigSetting("LogFile", "LogFileName", TxtHandle.LogFileName)
        SaveConfigSetting("LogFile", "LogLevel", TxtHandle.LogLevel)

        If chkAutoDeleteOldLogs.Checked = True Then
            CurVar.LogDeleteAuto = True
            If rbtKeepLogDay.Checked = True Then CurVar.LogDelete = "Day"
            If rbtKeepLogWeek.Checked = True Then CurVar.LogDelete = "Week"
            If rbtKeepLogMonth.Checked = True Then CurVar.LogDelete = "Month"
        Else
            CurVar.LogDeleteAuto = False
        End If
        SaveConfigSetting("LogFile", "LogDelete", CurVar.LogDelete)
        SaveConfigSetting("LogFile", "LogDeleteAuto", CurVar.LogDeleteAuto)

    End Sub

    Private Sub btnClearOldLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOldLogs.Click
        If TxtHandle.LogLocation.ToLower = "database" Then
            Dim dtmDate As Date = Today

            If rbtKeepLogDay.Checked = True Then dtmDate = dtmDate.AddDays(-1)
            If rbtKeepLogWeek.Checked = True Then dtmDate = dtmDate.AddDays(-7)
            If rbtKeepLogMonth.Checked = True Then dtmDate = dtmDate.AddMonths(-1)
            If DebugMode = True Then MessageBox.Show(dtmDate.ToString)
            ClearDBLog(dtmDate)
        End If
    End Sub

    Private Sub btnLogToDatabase_Click(sender As Object, e As EventArgs) Handles btnLogToDatabase.Click
        txtLogfileLocation.Text = "Database"
        'grpLogsToKeep.Visible = True
    End Sub

    Private Sub txtLogfileLocation_TextChanged(sender As Object, e As EventArgs) Handles txtLogfileLocation.TextChanged
        If txtLogfileLocation.Text.ToLower = "database" Then
            grpLogsToKeep.Visible = True
        Else
            grpLogsToKeep.Visible = False
        End If

    End Sub

#End Region

#Region "ScreenView"

    Private Sub chkShowAge_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAge.CheckedChanged
        If chkShowAge.Checked Then
            txtShowAgeMax.Enabled = True
            chkShowAgeAfter.Enabled = True
        Else
            txtShowAgeMax.Enabled = False
            chkShowAgeAfter.Enabled = False
        End If
    End Sub

    Private Sub ShowViewSettings()
        txtClientFieldWidth.Text = CurVar.TrackBoxWidth
        cbxClientFieldHeight.Text = CurVar.TrackBoxHeight
        txtClientsPerTrack.Text = CurVar.ClientsPerTrack
        txtClientsPerGroup.Text = CurVar.ClientsPerGroup
        txtDefFinanceRows.Text = CurVar.PayLines
        'txtOpeningHour.Text = CurVar.OpeningHour
        Dim dtmOpening As Date = "1900-01-01"
        dtmOpening = dtmOpening.AddHours(Math.Floor(CurVar.OpeningHour / 60))
        dtmOpening = dtmOpening.AddMinutes(CurVar.OpeningHour - Math.Floor(CurVar.OpeningHour / 60) * 60)
        dtpOpeningHour.Value = dtmOpening
        'dtpOpeningHour.Value = CurVar.OpeningHours
        'txtClosingHour.Text = CurVar.ClosingHour
        Dim dtmClosing As Date = "1900-01-01"
        dtmClosing = dtmClosing.AddHours(Math.Floor(CurVar.ClosingHour / 60))
        dtmClosing = dtmClosing.AddMinutes(CurVar.ClosingHour - Math.Floor(CurVar.ClosingHour / 60) * 60)
        dtpClosingHour.Value = dtmClosing
        'dtpClosingHour.Value = CurVar.ClosingHours
        txtTimeFrame.Text = CurVar.TimeFrame
        If CurVar.ShowOffHours = True Then
            cbxShowClosedHours.SelectedItem = "Yes"
        Else
            cbxShowClosedHours.SelectedItem = "No"
        End If
        cbxOnHoursColor.SelectedItem = CurVar.OnHoursColor.ToKnownColor.ToString
        cbxOffHoursColor.SelectedItem = CurVar.OffHoursColor.ToKnownColor.ToString
        cbxReadOnlyBackColor.SelectedItem = CurVar.ReadOnlyBackColor.ToKnownColor.ToString
        cbxLanguage.SelectedItem = CurVar.Language
        If CurVar.ShowTeacher = True Then
            cbxShowTeacherColumn.SelectedItem = "Yes"
        Else
            cbxShowTeacherColumn.SelectedItem = "No"
        End If
        If CurVar.ShowTimeWithTrack = True Then
            cbxShowTimeWithTrack.SelectedItem = "Yes"
        Else
            cbxShowTimeWithTrack.SelectedItem = "No"
        End If

        dtmSeasonStart.Text = CurVar.SeasonStart
        cbxSeasonLength.SelectedItem = CurVar.SeasonLength
        If CurVar.UseFadingColors = True Then
            cbxUseFadingColors.SelectedItem = "Yes"
        Else
            cbxUseFadingColors.SelectedItem = "No"
        End If

        If CurVar.EmailMethod = "SMTP" Then
            rbtEmailUseSmtp.Checked = True
        Else
            rbtEmailUseOutlook.Checked = True
        End If
        txtSmtpServer.Text = CurVar.SmtpServer
        chkSmtpCredentials.Checked = CurVar.SmtpCredentials
        chkSmtpCredentials_CheckedChanged(Nothing, Nothing)
        txtSmtpServerUsername.Text = CurVar.SmtpUser
        txtSmtpServerPassword.Text = CurVar.SmtpPassword
        chkUseSslEncryption.Checked = CurVar.SmtpSsl
        txtSmtpPortNumber.Text = CurVar.SmtpPort
        txtSmtpReply.Text = CurVar.SmtpReply
        chkArchiveEmail.Checked = CurVar.ArchiveEmail
        txtArchiveEmail.Text = CurVar.ArchiveEmailAddress

        chkShowAge.Checked = CurVar.ShowAge
        chkShowAgeAfter.Checked = CurVar.ShowAgeAfter
        txtShowAgeMax.Text = CurVar.ShowAgeMax

    End Sub

    Private Sub btnSaveSettingsView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettingsView.Click
        If IsNumeric(txtClientFieldWidth.Text) = False Or _
           IsNumeric(txtClientsPerTrack.Text) = False Or _
           IsNumeric(txtClientsPerGroup.Text) = False Or _
           IsNumeric(txtDefFinanceRows.Text) = False Or _
           IsNumeric(txtTimeFrame.Text) = False Or _
           IsNumeric(txtInvoiceNumber.Text) = False Then
            MessageBox.Show(lanStrings.strNumeric & vbCrLf & lanStrings.strCheckSettings)
            Exit Sub
        End If
        If cbxClientFieldHeight.Items.Contains(cbxClientFieldHeight.Text) = False Or _
           cbxShowClosedHours.Items.Contains(cbxShowClosedHours.Text) = False Or _
           cbxOnHoursColor.Items.Contains(cbxOnHoursColor.Text) = False Or _
           cbxOffHoursColor.Items.Contains(cbxOffHoursColor.Text) = False Or _
           cbxLanguage.Items.Contains(cbxLanguage.Text) = False Or _
           cbxShowTimeWithTrack.Items.Contains(cbxShowTimeWithTrack.Text) = False Or _
           cbxShowTeacherColumn.Items.Contains(cbxShowTeacherColumn.Text) = False Or _
           cbxSeasonLength.Items.Contains(cbxSeasonLength.Text) = False Or _
           cbxUseFadingColors.Items.Contains(cbxUseFadingColors.Text) = False Then
            MessageBox.Show(lanStrings.strPreconfigured & vbCrLf & lanStrings.strCheckSettings)
            Exit Sub
        End If

        If MessageBox.Show(lanStrings.strSettingReload & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub

        CurVar.TrackBoxWidth = txtClientFieldWidth.Text
        CurVar.TrackBoxHeight = cbxClientFieldHeight.Text
        CurVar.ClientsPerTrack = txtClientsPerTrack.Text
        CurVar.ClientsPerGroup = txtClientsPerGroup.Text
        CurVar.PayLines = txtDefFinanceRows.Text
        CurVar.OpeningHour = dtpOpeningHour.Value.Hour * 60 + dtpOpeningHour.Value.Minute
        'CurVar.OpeningHours = dtpOpeningHour.Value
        CurVar.ClosingHour = dtpClosingHour.Value.Hour * 60 + dtpClosingHour.Value.Minute
        'CurVar.ClosingHours = dtpClosingHour.Value
        CurVar.TimeFrame = txtTimeFrame.Text
        If cbxShowClosedHours.Text = "Yes" Then
            CurVar.ShowOffHours = 1
        Else
            CurVar.ShowOffHours = 0
        End If
        CurVar.OnHoursColor = System.Drawing.Color.FromName(cbxOnHoursColor.SelectedItem)
        CurVar.OffHoursColor = System.Drawing.Color.FromName(cbxOffHoursColor.SelectedItem)
        CurVar.ReadOnlyBackColor = System.Drawing.Color.FromName(cbxReadOnlyBackColor.SelectedItem)
        'CurVar.Language = cbxLanguage.SelectedItem
        If cbxShowTeacherColumn.Text = "Yes" Then
            CurVar.ShowTeacher = 1
        Else
            CurVar.ShowTeacher = 0
        End If
        If cbxShowTimeWithTrack.Text = "Yes" Then
            CurVar.ShowTimeWithTrack = 1
        Else
            CurVar.ShowTimeWithTrack = 0
        End If
        If cbxUseFadingColors.Text = "Yes" Then
            CurVar.UseFadingColors = 1
        Else
            CurVar.UseFadingColors = 0
        End If

        CurVar.SeasonStart = dtmSeasonStart.Text
        CurVar.SeasonLength = cbxSeasonLength.SelectedItem
        CurVar.ShowAge = chkShowAge.Checked
        CurVar.ShowAgeAfter = chkShowAgeAfter.Checked
        CurVar.ShowAgeMax = txtShowAgeMax.Text

        RegHandle.AddCURRegKey("TrackBoxWidth", CurVar.TrackBoxWidth, RegHandle.RegistryPath)
        RegHandle.AddCURRegKey("TrackBoxHeight", CurVar.TrackBoxHeight, RegHandle.RegistryPath)
        'SaveConfigSetting("ScreenView", "TrackBoxWidth", CurVar.TrackBoxWidth)
        SaveConfigSetting("ScreenView", "ClientsPerTrack", CurVar.ClientsPerTrack)
        SaveConfigSetting("ScreenView", "ClientsPerGroup", CurVar.ClientsPerGroup)
        SaveConfigSetting("ScreenView", "PayLines", CurVar.PayLines)
        SaveConfigSetting("ScreenView", "OpeningHour", CurVar.OpeningHour)
        'SaveConfigSetting("ScreenView", "OpeningHours", CurVar.OpeningHours)
        SaveConfigSetting("ScreenView", "ClosingHour", CurVar.ClosingHour)
        'SaveConfigSetting("ScreenView", "ClosingHours", CurVar.ClosingHours)
        SaveConfigSetting("ScreenView", "TimeFrame", CurVar.TimeFrame)
        SaveConfigSetting("ScreenView", "ShowOffHours", CurVar.ShowOffHours)
        SaveConfigSetting("ScreenView", "OnHoursColor", CurVar.OnHoursColor.ToKnownColor.ToString)
        SaveConfigSetting("ScreenView", "OffHoursColor", CurVar.OffHoursColor.ToKnownColor.ToString)
        SaveConfigSetting("ScreenView", "ReadOnlyBackColor", CurVar.ReadOnlyBackColor.ToKnownColor.ToString)
        'SaveConfigSetting("ScreenView", "Language", CurVar.Language)
        SaveConfigSetting("ScreenView", "ShowTeacher", CurVar.ShowTeacher)
        SaveConfigSetting("ScreenView", "ShowTimeWithTrack", CurVar.ShowTimeWithTrack)
        SaveConfigSetting("ScreenView", "UseFadingColors", CurVar.UseFadingColors)

        SaveConfigSetting("ScreenView", "ShowAge", CurVar.ShowAge)
        SaveConfigSetting("ScreenView", "ShowAgeAfter", CurVar.ShowAgeAfter)
        SaveConfigSetting("ScreenView", "ShowAgeMax", CurVar.ShowAgeMax)

        SaveConfigSetting("General", "SeasonStart", FormatDateTime(CurVar.SeasonStart))
        SaveConfigSetting("General", "SeasonLength", CurVar.SeasonLength)

    End Sub

#End Region

#Region "Database"

    Private Sub ShowDatabase()
        cbxDataProvider.SelectedItem = DbHandle.DataProvider
        txtDatabaseLocation.Text = DbHandle.DataLocation
        txtDatabaseName.Text = DbHandle.DatabaseName
        cbxLoginMethod.SelectedItem = DbHandle.LoginMethod
        txtLoginName.Text = DbHandle.LoginName
        txtPassword.Text = DbHandle.Password
        cbxLoginMethod_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cbxLoginMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLoginMethod.SelectedIndexChanged
        If cbxLoginMethod.SelectedItem = "SQL" Then
            txtLoginName.Enabled = True
            txtPassword.Enabled = True
            txtLoginName.Text = DbHandle.LoginName
            txtPassword.Text = DbHandle.Password
        ElseIf cbxLoginMethod.SelectedItem = "Windows" Then
            txtLoginName.Enabled = False
            txtPassword.Enabled = False
            txtLoginName.Text = ""
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub btnUseDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseDefaults.Click
        txtDatabaseLocation.Text = Environment.MachineName & "\SQLEXPRESS"
        txtDatabaseName.Text = "TrackManager"
        cbxDataProvider.SelectedItem = "SQL"
        cbxLoginMethod.SelectedItem = "WINDOWS"
        txtLoginName.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub btnSaveSettingsDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettingsDatabase.Click
        If cbxDataProvider.Items.Contains(cbxDataProvider.Text) = False Or _
           cbxLoginMethod.Items.Contains(cbxLoginMethod.Text) = False Then
            MessageBox.Show(lanStrings.strPreconfigured & vbCrLf & lanStrings.strCheckSettings)
            Exit Sub
        End If
        If DbHandle.DataLocation <> txtDatabaseLocation.Text Or _
         DbHandle.DatabaseName <> txtDatabaseName.Text Or _
         DbHandle.DataProvider <> cbxDataProvider.SelectedItem Then
            If MessageBox.Show(lanStrings.strSettingReload & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        DbHandle.DataLocation = txtDatabaseLocation.Text
        DbHandle.DatabaseName = txtDatabaseName.Text
        DbHandle.DataProvider = cbxDataProvider.SelectedItem
        DbHandle.LoginMethod = cbxLoginMethod.SelectedItem
        DbHandle.LoginName = txtLoginName.Text
        DbHandle.Password = txtPassword.Text
        DatabaseTest()
        Try
            If blnDatabaseOnLine = False Then
                If MessageBox.Show("The database specified was not found." & vbCrLf & "Do you wish to save anyway?", "Database not found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            DatabaseSettingsSave()
            btnSaveSettingsDatabase.Enabled = False
            btnSaveSettingsDatabase.BackColor = Color.Transparent
            LoadSettings()
        Catch ex As Exception
            MessageBox.Show(lanStrings.strDataError & vbCrLf & lanStrings.strCheckSettings)
            DatabaseSettingsLoad()
            ShowDatabase()
        End Try
    End Sub

    Private Sub txtDatabaseLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDatabaseLocation.TextChanged
        btnSaveSettingsDatabase.Enabled = True
    End Sub

    Private Sub cbxDataProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDataProvider.SelectedIndexChanged
        btnSaveSettingsDatabase.Enabled = True
    End Sub

    Private Sub txtDatabaseName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDatabaseName.TextChanged
        btnSaveSettingsDatabase.Enabled = True
    End Sub

    Private Sub txtLoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoginName.TextChanged
        btnSaveSettingsDatabase.Enabled = True
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        btnSaveSettingsDatabase.Enabled = True
    End Sub

    Private Sub btnCreateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDatabase.Click
        CreateDatabase(True)
        btnSaveSettingsDatabase.BackColor = Color.Coral
    End Sub

    Private Sub btnRefreshDatabase_Click(sender As Object, e As EventArgs) Handles btnRefreshDatabase.Click
        If MessageBox.Show("This will update all TrackManager Views, Stored Procedures and Functions to their latest version. " & Environment.NewLine _
            & "Your Tables will not be changed." & Environment.NewLine _
            & lanStrings.strAreYouSure, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub
        CreateDatabase(False)
    End Sub

    Friend Sub CreateDatabase(Optional blnIncludeTables As Boolean = True)
        Dim strDBName As String
        Dim strSQL As String

        lblStatusDatabase.Visible = True
        prbCreateDatabase.Visible = True

        If blnIncludeTables = True Then
            DbHandle.DataProvider = cbxDataProvider.SelectedItem
            DbHandle.DataLocation = txtDatabaseLocation.Text
            DbHandle.LoginMethod = cbxLoginMethod.SelectedItem
            DbHandle.LoginName = txtLoginName.Text
            DbHandle.Password = txtPassword.Text
            DbHandle.DatabaseName = "master"
            strDBName = txtDatabaseName.Text

            If DebugMode Then
                MessageBox.Show("TrackManager v " & Application.ProductVersion & " Database Creation" & vbCrLf _
                 & "   DatabaseServer = " & DbHandle.DataLocation & vbCrLf _
                 & "   Database Context = " & DbHandle.DatabaseName & vbCrLf _
                 & "   Database to create: = " & strDBName & vbCrLf _
                 & "   DataProvider = " & DbHandle.DataProvider & vbCrLf _
                 & "   LoginMethod = " & DbHandle.LoginMethod & vbCrLf _
                 & "   Running in Debug Mode")
            End If
        Else
            strDBName = DbHandle.DatabaseName
        End If
        Try
            Dim MydbRef As New TMDB.DBRef
            Dim arrScripts(100) As String
            arrScripts = MydbRef.GetList(blnIncludeTables)
            prbCreateDatabase.Maximum = arrScripts.GetUpperBound(0)

            strSQL = MydbRef.GetScript(arrScripts(0))
            strSQL = Replace(strSQL, "TrackManager", strDBName)
            If DebugMode Then MessageBox.Show(strSQL)
            QueryDb(strSQL, False)
            DbHandle.DatabaseName = strDBName
            prbCreateDatabase.PerformStep()

            For i = 1 To arrScripts.GetUpperBound(0)
                strSQL = MydbRef.GetScript(arrScripts(i))
                If Not strSQL = "-1" Then
                    strSQL = Replace(strSQL, "TrackManager", strDBName)
                    If blnIncludeTables = False Then strSQL = Replace(strSQL, "CREATE", "ALTER", 1, 1)
                    'If DebugMode Then
                    '    MessageBox.Show(strDBName & vbCrLf & strSQL)
                    '    MessageBox.Show(DbHandle.DataConnectionString)
                    'End If
                    QueryDb(strSQL, False)
                Else
                    If DebugMode Then MessageBox.Show("The script: " & arrScripts(i) & " returned: " & strSQL)
                End If
                prbCreateDatabase.PerformStep()
            Next
            prbCreateDatabase.PerformStep()
            SaveConfigSetting("Database", "Version", My.Application.Info.Version.ToString)
            btnCreateDemoData.Visible = True

        Catch ex As Exception
            DbHandle.DatabaseName = strDBName
        End Try

        lblStatusDatabase.Visible = False
        prbCreateDatabase.Visible = False
        LoadVersion()
    End Sub

    Private Sub CreateDemoData()
        If MessageBox.Show(lanStrings.strWarningDemoData & vbCrLf & lanStrings.strAreYouSure, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub
        Dim strSQL As String

        Dim MydbRef As New TMDB.DBRef

        strSQL = MydbRef.GetScript("DemoData.sql")
        'If DebugMode Then MessageBox.Show(strSQL)
        If Not strSQL = "-1" Then
            QueryDb(strSQL, False)
        End If

    End Sub

    Private Sub btnCreateDemoData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDemoData.Click
        CreateDemoData()
        btnCreateDemoData.Visible = False
    End Sub

    Private Sub btnUpgradeDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpgradeDatabase.Click
        Dim strSQL As String
        Dim strMode As String
        Dim MydbRef As New TMDB.DBRef

        btnUpgradeDatabase.Enabled = False

        Try
            Dim arrScripts(100, 1) As String
            arrScripts = MydbRef.GetNewList(txtUpgradeDatabase.Tag)

            strSQL = MydbRef.GetScript(arrScripts(0, 0))
            If DebugMode Then MessageBox.Show("<debug>Number of Scripts: " & arrScripts.GetUpperBound(1) + 1)

            strMode = arrScripts(1, 0)
            If strSQL = "-1" Then
                MessageBox.Show("Error retrieving SQL Script " & arrScripts(0, 0) & ", please contact your vendor")
                Exit Sub
            End If
            strSQL = Replace(strSQL, "TrackManager", DbHandle.DatabaseName)
            If strMode = "ALTER" Then strSQL = Replace(strSQL, "CREATE", "ALTER", 1, 1)
            QueryDb(strSQL, False)

            For i = 1 To arrScripts.GetUpperBound(1)
                strSQL = MydbRef.GetScript(arrScripts(0, i))
                If Not strSQL = "-1" Then
                    strSQL = Replace(strSQL, "TrackManager", DbHandle.DatabaseName)
                    strMode = arrScripts(1, i)
                    If strMode = "ALTER" Then strSQL = Replace(strSQL, "CREATE", "ALTER", 1, 1)
                    QueryDb(strSQL, False)
                Else
                    MessageBox.Show("Error retrieving SQL Script " & arrScripts(0, 0) & ", please contact your vendor")
                    Exit Sub
                End If
            Next
            SaveConfigSetting("Database", "Version", txtUpgradeDatabase.Tag)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
        btnUpgradeDatabase.BackColor = CurVar.BaseColor
        txtUpgradeDatabase.Text = txtUpgradeDatabase.Tag
        txtUpgradeDatabase.Tag = ""
        MessageBox.Show("Database Update successfull")
        LoadVersion()
    End Sub

    Private Function LoadVersion() As Boolean
        Dim strVersion As String, strTarget As String
        strVersion = LoadConfigSetting("Database", "Version")
        txtUpgradeDatabase.Text = strVersion
        txtUpgradeDatabase.Tag = strVersion

        Dim MydbRef As New TMDB.DBRef
        strTarget = MydbRef.GetVersion(strVersion)

        If Not (strTarget = Nothing Or strTarget = "") Then
            btnUpgradeDatabase.Enabled = True
            txtUpgradeDatabase.Text &= " -> " & strTarget
            txtUpgradeDatabase.Tag = strTarget
            tabSettings.SelectTab(tpgDatabase)
            btnUpgradeDatabase.BackColor = CurVar.ChangedColor
            MessageBox.Show(lanStrings.strUpdateDatabase)
            Return True
        Else
            btnUpgradeDatabase.Enabled = False
            Return False
        End If

    End Function

    Private Sub LoadBackupPath()
        Dim strLocation As String
        strLocation = LoadConfigSetting("Database", "BackupLocation")
        txtBackupDatabase.Text = strLocation
    End Sub

    Private Sub btnBackupDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupDatabase.Click
        Try
            BackupDatabase(txtBackupDatabase.Text)
            SaveConfigSetting("Database", "BackupLocation", txtBackupDatabase.Text, "A valid location on the server")
        Catch ex As Exception
            MessageBox.Show("While saving the database, the following error occured: " & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        DatabaseTest()
        MessageBox.Show("Database Connection tested: " & blnDatabaseOnLine)
    End Sub

#End Region

#Region "Email"

    Private Sub chkSmtpCredentials_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSmtpCredentials.CheckedChanged
        If chkSmtpCredentials.Checked = True Then
            txtSmtpServerUsername.Enabled = False
            txtSmtpServerUsername.Text = ""
            txtSmtpServerPassword.Enabled = False
            txtSmtpServerPassword.Text = ""
        Else
            txtSmtpServerUsername.Enabled = True
            txtSmtpServerUsername.Text = CurVar.SmtpUser
            txtSmtpServerPassword.Enabled = True
            txtSmtpServerPassword.Text = CurVar.SmtpPassword
        End If
    End Sub

    Private Sub btnSaveSettingsEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettingsEmail.Click
        If chkArchiveEmail.Checked = True And EmailAddressCheck(txtArchiveEmail.Text) = False Then
            MessageBox.Show(lanStrings.strInvalidEmailAddress, "Archive Emailaddress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If rbtEmailUseSmtp.Checked = True Then
            CurVar.EmailMethod = "SMTP"
        Else
            CurVar.EmailMethod = "Outlook"
        End If
        CurVar.SmtpServer = txtSmtpServer.Text
        CurVar.SmtpCredentials = chkSmtpCredentials.Checked
        CurVar.SmtpUser = txtSmtpServerUsername.Text
        CurVar.SmtpPassword = psEncrypt(txtSmtpServerPassword.Text)
        CurVar.SmtpReply = txtSmtpReply.Text
        CurVar.SmtpPort = txtSmtpPortNumber.Text
        CurVar.SmtpSsl = chkUseSslEncryption.Checked
        CurVar.ArchiveEmail = chkArchiveEmail.Checked
        CurVar.ArchiveEmailAddress = txtArchiveEmail.Text

        SaveConfigSetting("General", "EmailMethod", CurVar.EmailMethod)
        SaveConfigSetting("General", "SmtpServer", CurVar.SmtpServer)
        SaveConfigSetting("General", "SmtpCredentials", CurVar.SmtpCredentials)
        SaveConfigSetting("General", "SmtpServerUsername", CurVar.SmtpUser)
        SaveConfigSetting("General", "SmtpServerPassword", CurVar.SmtpPassword)
        SaveConfigSetting("General", "SmtpReply", CurVar.SmtpReply)
        SaveConfigSetting("General", "SmtpPort", CurVar.SmtpPort)
        SaveConfigSetting("General", "SmtpSsl", CurVar.SmtpSsl)
        SaveConfigSetting("General", "ArchiveEmail", CurVar.ArchiveEmail)
        SaveConfigSetting("General", "ArchiveEmailAddress", CurVar.ArchiveEmailAddress)

    End Sub

    Private Sub rbtEmailUseSmtp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEmailUseSmtp.CheckedChanged
        If rbtEmailUseSmtp.Checked = True Then
            grpEmailSmtp.Enabled = True
        Else
            grpEmailSmtp.Enabled = False
        End If
    End Sub

    Private Sub chkUseSslEncryption_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseSslEncryption.CheckedChanged
        If chkUseSslEncryption.Checked Then
            txtSmtpPortNumber.Text = 587
        Else
            txtSmtpPortNumber.Text = 25
        End If
    End Sub

#End Region

#Region "License"
    Private Sub btnValidateLicense_Click(sender As Object, e As EventArgs) Handles btnValidateLicense.Click
        If CheckLicenseKey(txtLicenseKey.Text, txtLicenseName.Text, GetVersion("M"), Nothing) = False Then
            MessageBox.Show("Your License information is incorrect")
        Else
            MessageBox.Show("Your License information has been validated")
        End If

    End Sub

    Private Sub btnSaveLicense_Click(sender As Object, e As EventArgs) Handles btnSaveLicense.Click
        strLicenseName = txtLicenseName.Text
        strLicenseKey = txtLicenseKey.Text

        If CheckLicenseKey(strLicenseKey, strLicenseName, GetVersion("M"), Nothing) = False Then
            MessageBox.Show("Your License information is incorrect")
        Else
            Try
                RegHandle.AddAnyRegKey("LicenseName", strLicenseName)
                If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
                RegHandle.AddAnyRegKey("LicenseKey", strLicenseKey)
                If DebugMode And RegHandle.ErrorLevel = -1 Then MessageBox.Show(RegHandle.RegMessage)
                blnLicenseValidated = True
                MessageBox.Show("Your License information has been saved")
            Catch ex As Exception
                MessageBox.Show("An error occured saving your license information")

            End Try

        End If

    End Sub

    Private Sub btnExitTrackManager_Click(sender As Object, e As EventArgs) Handles btnExitTrackManager.Click
        Application.Exit()
    End Sub

    Private Sub LoadLicense()
        txtLicenseName.Text = strLicenseName
        txtExpiryDate.Text = strExpiryDate
        txtLicenseKey.Text = strLicenseKey
    End Sub
#End Region

#Region "Language"
    Private Sub cbxLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLanguage.SelectedIndexChanged
        If cbxLanguage.SelectedItem <> CurVar.Language Then
            LanguageDbLoad(cbxLanguage.SelectedItem)
        End If
    End Sub

    Private Sub btnSaveSettingsLanguage_Click(sender As Object, e As EventArgs) Handles btnSaveSettingsLanguage.Click
        CurVar.Language = cbxLanguage.SelectedItem
        SaveConfigSetting("ScreenView", "Language", CurVar.Language)
    End Sub

    Private Sub btnAddLanguage_Click(sender As Object, e As EventArgs) Handles btnAddLanguage.Click
        If txtLanguageItem.Text.Length > 0 And cbxLanguageForm.SelectedIndex > -1 And txtLanguageItem.Text.Length > 0 And cbxLanguageType.SelectedIndex > -1 Then
            If txtLanguageItem.Tag > 0 Then
                LanguageHandle("Upd", txtLanguageItem.Tag, cbxLanguage.Text, cbxLanguageForm.SelectedItem, txtLanguageItem.Text, TxtLanguageText.Text, cbxLanguageType.SelectedItem)
            Else
                LanguageHandle("Add", 0, cbxLanguage.Text, cbxLanguageForm.SelectedItem, txtLanguageItem.Text, TxtLanguageText.Text, cbxLanguageType.SelectedItem)
            End If
            ClearLanguage()
            LanguageDbLoad(cbxLanguage.Text)
        Else
            MessageBox.Show(lanStrings.strAllData)
        End If
    End Sub

    Private Sub btnDeleteLanguage_Click(sender As Object, e As EventArgs) Handles btnDeleteLanguage.Click
        DeleteLanguage()
    End Sub

    Private Sub EditLanguage()
        If CurUser.SettingsChange Then
            If lvwLanguage.SelectedItems.Count = 1 Then
                txtLanguageItem.ReadOnly = True
                cbxLanguageForm.SelectedItem = lvwLanguage.SelectedItems.Item(0).Group.Tag
                txtLanguageItem.Tag = lvwLanguage.SelectedItems.Item(0).Tag
                txtLanguageItem.Text = lvwLanguage.SelectedItems.Item(0).Text
                TxtLanguageText.Text = lvwLanguage.SelectedItems.Item(0).SubItems.Item(1).Text
                cbxLanguageType.SelectedItem = lvwLanguage.SelectedItems.Item(0).SubItems.Item(2).Text
                btnAddLanguage.Text = lanStrings.strUpdate
            End If
        End If
    End Sub

    Private Sub DeleteLanguage()
        If lvwLanguage.SelectedItems.Count = 1 Then
            If MessageBox.Show(lvwLanguage.SelectedItems.Item(0).Tag & vbCrLf & lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If IsNumeric(lvwLanguage.SelectedItems.Item(0).Tag) Then
                    LanguageHandle("Del", lvwLanguage.SelectedItems.Item(0).Tag)
                    LanguageDbLoad(cbxLanguage.Text)
                End If
                ClearLanguage()
            End If

        ElseIf lvwLanguage.SelectedItems.Count = 0 Then
            If MessageBox.Show(lanStrings.strLanguage & ": " & cbxLanguage.SelectedItem & vbCrLf & lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                LanguageHandle("Del", Nothing, cbxLanguage.SelectedItem)
                'LanguageDbLoad("EN")
                cbxLanguage.SelectedIndex = -1
                cbxLanguage.Text = ""
            End If
        End If
    End Sub

    Private Sub lvwLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwLanguage.SelectedIndexChanged
        btnEditLanguage.Enabled = True
    End Sub

    Private Sub btnLanguageImport_Click(sender As Object, e As EventArgs) Handles btnLanguageImport.Click
        Dim ofdFile As New OpenFileDialog
        ofdFile.Filter = "TM Language Files (*.xml)|*.xml"
        ofdFile.ShowDialog()
        If ofdFile.FileName.Length > 4 Then
            LoadXmlLanguage(ofdFile.FileName)
            LanguageXmlLoad()
            btnLanguageSaveAll.BackColor = CurVar.ChangedColor
        End If
    End Sub

    Private Sub btnLanguageExport_Click(sender As Object, e As EventArgs) Handles btnLanguageExport.Click
        'Create xml file
        Dim xmlDoc As New XmlDocument
        Dim xmlDec As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes")
        Dim RootNode As XmlElement = xmlDoc.CreateElement("TrackManager")
        xmlDoc.InsertBefore(xmlDec, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(RootNode)

        'Add parent Node
        Dim ParentNode As XmlElement = xmlDoc.CreateElement("Language")
        ParentNode.SetAttribute("Name", cbxLanguage.Text)
        xmlDoc.DocumentElement.AppendChild(ParentNode)

        'Add Group Nodes
        For Each Group In lvwLanguage.Groups
            Dim GroupNode As XmlElement = xmlDoc.CreateElement("Form")
            GroupNode.SetAttribute("Name", Group.tag)
            xmlDoc.Item("TrackManager").Item("Language").AppendChild(GroupNode)
        Next

        'Add Items to Groups
        For Each lanItem In lvwLanguage.Items
            Dim ItemNode As XmlElement = xmlDoc.CreateElement("Object")
            ItemNode.SetAttribute("Name", lanItem.Text)
            ItemNode.SetAttribute("Type", lanItem.subitems(2).Text)
            Dim ItemText As XmlText = xmlDoc.CreateTextNode(lanItem.subitems(1).Text)
            Dim xmlNode As XmlNode = ParentNode.SelectSingleNode("Form[@Name='" & lanItem.Group.Tag & "']")
            xmlNode.AppendChild(ItemNode)
            ItemNode.AppendChild(ItemText)
        Next

        Using sw As New System.IO.StringWriter()
            ' Make the XmlTextWriter to format the XML.
            Using xml_writer As New XmlTextWriter(sw)
                xml_writer.Formatting = Formatting.Indented
                xmlDoc.WriteTo(xml_writer)
                xml_writer.Flush()

                Try
                    'get the filename and location to write to
                    Dim sfdFile As New SaveFileDialog
                    sfdFile.Filter = "TM Language Files (*.xml)|*.xml"
                    sfdFile.ShowDialog()

                    'Write the XML to disk
                    TxtHandle.CreateFile(sw.ToString(), sfdFile.FileName)
                Catch ex As Exception
                    WriteLog(lanStrings.strXmlError & vbCrLf & ex.Message, 1)
                End Try
            End Using
        End Using

    End Sub

    Private Sub lvwLanguage_DoubleClick(sender As Object, e As EventArgs) Handles lvwLanguage.DoubleClick
        EditLanguage()
    End Sub

    Private Sub btnEditLanguage_Click(sender As Object, e As EventArgs) Handles btnEditLanguage.Click
        EditLanguage()
    End Sub

    Private Sub btnClearLanguage_Click(sender As Object, e As EventArgs) Handles btnClearLanguage.Click
        ClearLanguage()
    End Sub

    Private Sub ClearLanguage()
        txtLanguageItem.ReadOnly = False
        cbxLanguageForm.SelectedIndex = -1
        txtLanguageItem.Tag = 0
        txtLanguageItem.Text = ""
        TxtLanguageText.Text = ""
        cbxLanguageType.SelectedIndex = -1
        btnAddLanguage.Text = lanStrings.strAdd
    End Sub

    Private Sub btnLanguageSaveAll_Click(sender As Object, e As EventArgs) Handles btnLanguageSaveAll.Click
        Dim strLanguage As String = cbxLanguage.Text
        Dim strForm As String = Nothing
        Dim strItem As String = Nothing
        Dim strText As String = Nothing
        Dim strType As String = Nothing

        For Each lsvItem In lvwLanguage.Items
            strItem = lsvItem.Tag
            strText = lsvItem.SubItems(1).Text
            strType = lsvItem.SubItems(2).Text
            strForm = lsvItem.Group.Tag
            LanguageHandle("Smt", Nothing, strLanguage, strForm, strItem, strText, strType)
        Next
        btnSaveSettingsLanguage_Click(Nothing, Nothing)
        LoadLanguageList()
        cbxLanguage.SelectedItem = strLanguage
        btnLanguageSaveAll.BackColor = CurVar.BaseColor
    End Sub

    Private Sub btnLanguageLoad_Click(sender As Object, e As EventArgs) Handles btnLanguageLoad.Click
        If lbxLanguage.SelectedItems.Count = 1 Then
            Dim strLanguage As String = lbxLanguage.SelectedItem.Substring(0, 2)
            Dim MydbRef As New TMDB.DBRef
            xmlLanguage.LoadXml(MydbRef.GetScript(strLanguage & ".xml"))
            LanguageXmlLoad()
            'cbxLanguage.Text = strLanguage

            btnLanguageSaveAll_Click(Nothing, Nothing)
            btnSaveSettingsLanguage_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub LanguageXmlLoad()
        If xmlLanguage.DocumentElement Is Nothing Then Exit Sub

        Dim strForm As String = Nothing
        Dim strItem As String = Nothing
        Dim strText As String = Nothing
        Dim strType As String = Nothing

        lvwLanguage.Items.Clear()

        Dim xmlLanNode As Xml.XmlNode = xmlLanguage.Item("TrackManager").Item("Language")
        For Each xmlElement In xmlLanNode.ChildNodes
            strForm = Replace(xmlElement.Attributes.GetNamedItem("Name").Value, "frm", "")
            For Each xmlChildElement In xmlElement.ChildNodes
                strItem = xmlChildElement.Attributes.GetNamedItem("Name").Value()
                strType = xmlChildElement.Attributes.GetNamedItem("Type").Value()
                strText = xmlChildElement.InnerText
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = strItem
                lsvItem.Text = strItem
                lsvItem.SubItems.Add(strText)
                lsvItem.SubItems.Add(strType)
                lvwLanguage.Items.Add(lsvItem)
                For Each lvwGroup In lvwLanguage.Groups
                    If lvwGroup.Tag = strForm Then
                        lsvItem.Group = lvwGroup
                    End If
                Next

            Next
        Next
        cbxLanguage.Text = xmlLanNode.Attributes.GetNamedItem("Name").Value
    End Sub

    Private Sub LoadLanguageList()
        Dim dtsData As DataSet = LanguageListGet()

        If dtsData Is Nothing Then Exit Sub
        If dtsData.Tables.Count = 0 Then Exit Sub
        If dtsData.Tables(0).Rows.Count = 0 Then Exit Sub

        cbxLanguage.Items.Clear()
        For intRowCount = 0 To dtsData.Tables(0).Rows.Count - 1
            If dtsData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                cbxLanguage.Items.Add(dtsData.Tables.Item(0).Rows(intRowCount).Item("Language"))
            End If
        Next
    End Sub

    Private Sub LanguageDbLoad(strLanguage As String)
        Dim dtsData As DataSet = LanguageHandle("Get", Nothing, strLanguage)

        If dtsData Is Nothing Then Exit Sub
        If dtsData.Tables.Count = 0 Then Exit Sub
        If dtsData.Tables(0).Rows.Count = 0 Then Exit Sub

        lvwLanguage.Items.Clear()
        For intRowCount = 0 To dtsData.Tables(0).Rows.Count - 1
            If dtsData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = dtsData.Tables.Item(0).Rows(intRowCount).Item("PK_LanguageId")
                lsvItem.Text = dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageItem")
                lsvItem.SubItems.Add(dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageText"))
                lsvItem.SubItems.Add(dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageType"))
                lvwLanguage.Items.Add(lsvItem)
                For Each lvwGroup In lvwLanguage.Groups
                    If lvwGroup.Tag = dtsData.Tables.Item(0).Rows(intRowCount).Item("LanguageForm") Then
                        lsvItem.Group = lvwGroup
                    End If
                Next
            End If
        Next

    End Sub
#End Region

#Region "Buttons"

    Private Sub btnButtonUp_Click(sender As Object, e As EventArgs) Handles btnButtonUp.Click
        ListViewMove(lvwButtons, -1)
    End Sub

    Private Sub btnButtonDown_Click(sender As Object, e As EventArgs) Handles btnButtonDown.Click
        ListViewMove(lvwButtons, 1)
    End Sub

    Private Sub ListViewMove(objListbox As ListView, intMove As Integer)
        If objListbox.SelectedIndices.Count = 1 Then
            Dim SelIndex As Integer = objListbox.SelectedIndices.Item(0)
            Dim intPosition As Integer = SelIndex + intMove
            If intPosition < 0 Or intPosition > objListbox.Items.Count - 1 Then
                objListbox.Items(SelIndex).Selected = True
                objListbox.Focus()
                Exit Sub
            End If

            'Reorder items in the arraylist
            Dim tItem As ListViewItem
            tItem = objListbox.Items(intPosition)
            objListbox.Items(intPosition) = objListbox.Items(SelIndex).Clone
            objListbox.Items(SelIndex) = tItem.Clone
            objListbox.Items(intPosition).Selected = True
            objListbox.Focus()
        End If
    End Sub

    Private Sub btnButtonOrderSave_Click(sender As Object, e As EventArgs) Handles btnButtonOrderSave.Click
        If MessageBox.Show(lanStrings.strSettingReload & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        ButtonOrderSave()
    End Sub

    Private Sub ButtonOrderSave()
        For intRowcount = 0 To lvwButtons.Items.Count - 1
            SaveConfigSetting("Buttons", lvwButtons.Items(intRowcount).Tag, lvwButtons.Items(intRowcount).Index + 1)
        Next
    End Sub

#End Region

End Class