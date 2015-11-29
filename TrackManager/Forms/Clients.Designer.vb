<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClients))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClearClient = New System.Windows.Forms.Button()
        Me.btnUpdateClient = New System.Windows.Forms.Button()
        Me.btnDeleteClient = New System.Windows.Forms.Button()
        Me.lvwGroups = New System.Windows.Forms.ListView()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblFamilyName = New System.Windows.Forms.Label()
        Me.txtFamilyName = New System.Windows.Forms.TextBox()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.lblHouseNumber = New System.Windows.Forms.Label()
        Me.txtHouseNumber = New System.Windows.Forms.TextBox()
        Me.lblPostalCode = New System.Windows.Forms.Label()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.lblTelephone = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.lblMobile = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblDateOfBirth = New System.Windows.Forms.Label()
        Me.lblBankaccount = New System.Windows.Forms.Label()
        Me.txtBankaccount = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblCustom1 = New System.Windows.Forms.Label()
        Me.lblCustom2 = New System.Windows.Forms.Label()
        Me.lblCustom3 = New System.Windows.Forms.Label()
        Me.txtCustom3 = New System.Windows.Forms.TextBox()
        Me.lblCustom4 = New System.Windows.Forms.Label()
        Me.txtCustom4 = New System.Windows.Forms.TextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.chkCustom1 = New System.Windows.Forms.CheckBox()
        Me.chkCustom2 = New System.Windows.Forms.CheckBox()
        Me.chkMailinglist = New System.Windows.Forms.CheckBox()
        Me.lblMailinglist = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.lvwClients = New System.Windows.Forms.ListView()
        Me.lblGroupName = New System.Windows.Forms.Label()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.lblRequiredFirst = New System.Windows.Forms.Label()
        Me.btnAddClient = New System.Windows.Forms.Button()
        Me.lblRequiredFamily = New System.Windows.Forms.Label()
        Me.btnMoveClient = New System.Windows.Forms.Button()
        Me.btnVerifyAddress = New System.Windows.Forms.Button()
        Me.lvwPrContacts = New System.Windows.Forms.ListView()
        Me.colPrContacts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblPrContact = New System.Windows.Forms.Label()
        Me.lblCreditcard = New System.Windows.Forms.Label()
        Me.txtCreditCard = New System.Windows.Forms.TextBox()
        Me.lblCreditCardCcv = New System.Windows.Forms.Label()
        Me.txtCreditCardCcv = New System.Windows.Forms.TextBox()
        Me.lblCreditCardValidThru = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxCreditCardMonth = New System.Windows.Forms.ComboBox()
        Me.cbxCreditCardYear = New System.Windows.Forms.ComboBox()
        Me.txtGroupSearch = New System.Windows.Forms.TextBox()
        Me.tmrClients = New System.Windows.Forms.Timer(Me.components)
        Me.lblClientNumber = New System.Windows.Forms.Label()
        Me.txtClientNumber = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(370, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(121, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClearClient
        '
        Me.btnClearClient.Location = New System.Drawing.Point(382, 646)
        Me.btnClearClient.Name = "btnClearClient"
        Me.btnClearClient.Size = New System.Drawing.Size(110, 23)
        Me.btnClearClient.TabIndex = 5
        Me.btnClearClient.Text = "Clear"
        Me.btnClearClient.UseVisualStyleBackColor = True
        '
        'btnUpdateClient
        '
        Me.btnUpdateClient.Location = New System.Drawing.Point(138, 646)
        Me.btnUpdateClient.Name = "btnUpdateClient"
        Me.btnUpdateClient.Size = New System.Drawing.Size(110, 23)
        Me.btnUpdateClient.TabIndex = 3
        Me.btnUpdateClient.Text = "Update"
        Me.btnUpdateClient.UseVisualStyleBackColor = True
        '
        'btnDeleteClient
        '
        Me.btnDeleteClient.Enabled = False
        Me.btnDeleteClient.Location = New System.Drawing.Point(260, 646)
        Me.btnDeleteClient.Name = "btnDeleteClient"
        Me.btnDeleteClient.Size = New System.Drawing.Size(110, 23)
        Me.btnDeleteClient.TabIndex = 4
        Me.btnDeleteClient.Text = "Delete"
        Me.btnDeleteClient.UseVisualStyleBackColor = True
        '
        'lvwGroups
        '
        Me.lvwGroups.FullRowSelect = True
        Me.lvwGroups.GridLines = True
        Me.lvwGroups.HideSelection = False
        Me.lvwGroups.Location = New System.Drawing.Point(14, 79)
        Me.lvwGroups.MultiSelect = False
        Me.lvwGroups.Name = "lvwGroups"
        Me.lvwGroups.Size = New System.Drawing.Size(222, 121)
        Me.lvwGroups.TabIndex = 31
        Me.lvwGroups.UseCompatibleStateImageBehavior = False
        Me.lvwGroups.View = System.Windows.Forms.View.Details
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(369, 70)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstName.TabIndex = 7
        Me.txtFirstName.Tag = "0"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(254, 73)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblFirstName.TabIndex = 40
        Me.lblFirstName.Text = "First Name"
        '
        'lblFamilyName
        '
        Me.lblFamilyName.AutoSize = True
        Me.lblFamilyName.Location = New System.Drawing.Point(254, 123)
        Me.lblFamilyName.Name = "lblFamilyName"
        Me.lblFamilyName.Size = New System.Drawing.Size(67, 13)
        Me.lblFamilyName.TabIndex = 42
        Me.lblFamilyName.Text = "Family Name"
        '
        'txtFamilyName
        '
        Me.txtFamilyName.Location = New System.Drawing.Point(369, 120)
        Me.txtFamilyName.Name = "txtFamilyName"
        Me.txtFamilyName.Size = New System.Drawing.Size(121, 20)
        Me.txtFamilyName.TabIndex = 9
        Me.txtFamilyName.Tag = "0"
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(254, 148)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(35, 13)
        Me.lblStreet.TabIndex = 44
        Me.lblStreet.Text = "Street"
        '
        'txtStreet
        '
        Me.txtStreet.Location = New System.Drawing.Point(369, 145)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(121, 20)
        Me.txtStreet.TabIndex = 10
        Me.txtStreet.Tag = "0"
        '
        'lblHouseNumber
        '
        Me.lblHouseNumber.AutoSize = True
        Me.lblHouseNumber.Location = New System.Drawing.Point(254, 173)
        Me.lblHouseNumber.Name = "lblHouseNumber"
        Me.lblHouseNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblHouseNumber.TabIndex = 46
        Me.lblHouseNumber.Text = "Housenumber"
        '
        'txtHouseNumber
        '
        Me.txtHouseNumber.Location = New System.Drawing.Point(370, 170)
        Me.txtHouseNumber.Name = "txtHouseNumber"
        Me.txtHouseNumber.Size = New System.Drawing.Size(68, 20)
        Me.txtHouseNumber.TabIndex = 11
        Me.txtHouseNumber.Tag = "0"
        '
        'lblPostalCode
        '
        Me.lblPostalCode.AutoSize = True
        Me.lblPostalCode.Location = New System.Drawing.Point(254, 198)
        Me.lblPostalCode.Name = "lblPostalCode"
        Me.lblPostalCode.Size = New System.Drawing.Size(64, 13)
        Me.lblPostalCode.TabIndex = 48
        Me.lblPostalCode.Text = "Postal Code"
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(370, 195)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(68, 20)
        Me.txtPostalCode.TabIndex = 12
        Me.txtPostalCode.Tag = "0"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(254, 223)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 13)
        Me.lblCity.TabIndex = 50
        Me.lblCity.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(369, 220)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(121, 20)
        Me.txtCity.TabIndex = 14
        Me.txtCity.Tag = "0"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(254, 248)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 52
        Me.lblCountry.Text = "Country"
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(369, 245)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(121, 20)
        Me.txtCountry.TabIndex = 15
        Me.txtCountry.Tag = "0"
        '
        'lblTelephone
        '
        Me.lblTelephone.AutoSize = True
        Me.lblTelephone.Location = New System.Drawing.Point(254, 273)
        Me.lblTelephone.Name = "lblTelephone"
        Me.lblTelephone.Size = New System.Drawing.Size(58, 13)
        Me.lblTelephone.TabIndex = 54
        Me.lblTelephone.Text = "Telephone"
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(369, 270)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(121, 20)
        Me.txtTelephone.TabIndex = 16
        Me.txtTelephone.Tag = "0"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(254, 298)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(24, 13)
        Me.lblFax.TabIndex = 56
        Me.lblFax.Text = "Fax"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(369, 295)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(121, 20)
        Me.txtFax.TabIndex = 17
        Me.txtFax.Tag = "0"
        '
        'lblMobile
        '
        Me.lblMobile.AutoSize = True
        Me.lblMobile.Location = New System.Drawing.Point(254, 323)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Size = New System.Drawing.Size(38, 13)
        Me.lblMobile.TabIndex = 58
        Me.lblMobile.Text = "Mobile"
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(369, 320)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(121, 20)
        Me.txtMobile.TabIndex = 18
        Me.txtMobile.Tag = "0"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(253, 348)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 60
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(369, 345)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(121, 20)
        Me.txtEmail.TabIndex = 19
        Me.txtEmail.Tag = "0"
        '
        'lblDateOfBirth
        '
        Me.lblDateOfBirth.AutoSize = True
        Me.lblDateOfBirth.Location = New System.Drawing.Point(253, 373)
        Me.lblDateOfBirth.Name = "lblDateOfBirth"
        Me.lblDateOfBirth.Size = New System.Drawing.Size(66, 13)
        Me.lblDateOfBirth.TabIndex = 64
        Me.lblDateOfBirth.Text = "Date of Birth"
        '
        'lblBankaccount
        '
        Me.lblBankaccount.AutoSize = True
        Me.lblBankaccount.Location = New System.Drawing.Point(253, 398)
        Me.lblBankaccount.Name = "lblBankaccount"
        Me.lblBankaccount.Size = New System.Drawing.Size(71, 13)
        Me.lblBankaccount.TabIndex = 66
        Me.lblBankaccount.Text = "Bankaccount"
        '
        'txtBankaccount
        '
        Me.txtBankaccount.Location = New System.Drawing.Point(369, 395)
        Me.txtBankaccount.Name = "txtBankaccount"
        Me.txtBankaccount.Size = New System.Drawing.Size(121, 20)
        Me.txtBankaccount.TabIndex = 22
        Me.txtBankaccount.Tag = "0"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(13, 422)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 68
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(14, 445)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(222, 67)
        Me.txtRemarks.TabIndex = 67
        Me.txtRemarks.Tag = "0"
        '
        'lblCustom1
        '
        Me.lblCustom1.AutoSize = True
        Me.lblCustom1.Location = New System.Drawing.Point(253, 523)
        Me.lblCustom1.Name = "lblCustom1"
        Me.lblCustom1.Size = New System.Drawing.Size(48, 13)
        Me.lblCustom1.TabIndex = 70
        Me.lblCustom1.Text = "Custom1"
        '
        'lblCustom2
        '
        Me.lblCustom2.AutoSize = True
        Me.lblCustom2.Location = New System.Drawing.Point(253, 548)
        Me.lblCustom2.Name = "lblCustom2"
        Me.lblCustom2.Size = New System.Drawing.Size(48, 13)
        Me.lblCustom2.TabIndex = 72
        Me.lblCustom2.Text = "Custom2"
        '
        'lblCustom3
        '
        Me.lblCustom3.AutoSize = True
        Me.lblCustom3.Location = New System.Drawing.Point(253, 573)
        Me.lblCustom3.Name = "lblCustom3"
        Me.lblCustom3.Size = New System.Drawing.Size(48, 13)
        Me.lblCustom3.TabIndex = 74
        Me.lblCustom3.Text = "Custom3"
        '
        'txtCustom3
        '
        Me.txtCustom3.Location = New System.Drawing.Point(369, 570)
        Me.txtCustom3.Name = "txtCustom3"
        Me.txtCustom3.Size = New System.Drawing.Size(121, 20)
        Me.txtCustom3.TabIndex = 26
        Me.txtCustom3.Tag = "0"
        '
        'lblCustom4
        '
        Me.lblCustom4.AutoSize = True
        Me.lblCustom4.Location = New System.Drawing.Point(253, 598)
        Me.lblCustom4.Name = "lblCustom4"
        Me.lblCustom4.Size = New System.Drawing.Size(48, 13)
        Me.lblCustom4.TabIndex = 76
        Me.lblCustom4.Text = "Custom4"
        '
        'txtCustom4
        '
        Me.txtCustom4.Location = New System.Drawing.Point(369, 595)
        Me.txtCustom4.Name = "txtCustom4"
        Me.txtCustom4.Size = New System.Drawing.Size(121, 20)
        Me.txtCustom4.TabIndex = 27
        Me.txtCustom4.Tag = "0"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.AutoSize = True
        Me.lblMiddleName.Location = New System.Drawing.Point(254, 98)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(69, 13)
        Me.lblMiddleName.TabIndex = 78
        Me.lblMiddleName.Text = "Middle Name"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(370, 95)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(68, 20)
        Me.txtMiddleName.TabIndex = 8
        Me.txtMiddleName.Tag = "0"
        '
        'chkCustom1
        '
        Me.chkCustom1.AutoSize = True
        Me.chkCustom1.Location = New System.Drawing.Point(475, 494)
        Me.chkCustom1.Name = "chkCustom1"
        Me.chkCustom1.Size = New System.Drawing.Size(15, 14)
        Me.chkCustom1.TabIndex = 24
        Me.chkCustom1.UseVisualStyleBackColor = True
        '
        'chkCustom2
        '
        Me.chkCustom2.AutoSize = True
        Me.chkCustom2.Location = New System.Drawing.Point(475, 519)
        Me.chkCustom2.Name = "chkCustom2"
        Me.chkCustom2.Size = New System.Drawing.Size(15, 14)
        Me.chkCustom2.TabIndex = 25
        Me.chkCustom2.UseVisualStyleBackColor = True
        '
        'chkMailinglist
        '
        Me.chkMailinglist.AutoSize = True
        Me.chkMailinglist.Location = New System.Drawing.Point(475, 469)
        Me.chkMailinglist.Name = "chkMailinglist"
        Me.chkMailinglist.Size = New System.Drawing.Size(15, 14)
        Me.chkMailinglist.TabIndex = 23
        Me.chkMailinglist.UseVisualStyleBackColor = True
        '
        'lblMailinglist
        '
        Me.lblMailinglist.AutoSize = True
        Me.lblMailinglist.Location = New System.Drawing.Point(253, 498)
        Me.lblMailinglist.Name = "lblMailinglist"
        Me.lblMailinglist.Size = New System.Drawing.Size(101, 13)
        Me.lblMailinglist.TabIndex = 81
        Me.lblMailinglist.Text = "Include in Mailinglist"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(369, 370)
        Me.dtpDateOfBirth.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpDateOfBirth.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(121, 20)
        Me.dtpDateOfBirth.TabIndex = 21
        Me.dtpDateOfBirth.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'lvwClients
        '
        Me.lvwClients.FullRowSelect = True
        Me.lvwClients.GridLines = True
        Me.lvwClients.HideSelection = False
        Me.lvwClients.Location = New System.Drawing.Point(14, 228)
        Me.lvwClients.MultiSelect = False
        Me.lvwClients.Name = "lvwClients"
        Me.lvwClients.Size = New System.Drawing.Size(222, 121)
        Me.lvwClients.TabIndex = 85
        Me.lvwClients.UseCompatibleStateImageBehavior = False
        Me.lvwClients.View = System.Windows.Forms.View.Details
        '
        'lblGroupName
        '
        Me.lblGroupName.AutoSize = True
        Me.lblGroupName.Location = New System.Drawing.Point(14, 25)
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.Size = New System.Drawing.Size(67, 13)
        Me.lblGroupName.TabIndex = 86
        Me.lblGroupName.Text = "Group Name"
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Location = New System.Drawing.Point(14, 212)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(64, 13)
        Me.lblClientName.TabIndex = 87
        Me.lblClientName.Text = "Client Name"
        '
        'lblRequiredFirst
        '
        Me.lblRequiredFirst.AutoSize = True
        Me.lblRequiredFirst.Location = New System.Drawing.Point(358, 73)
        Me.lblRequiredFirst.Name = "lblRequiredFirst"
        Me.lblRequiredFirst.Size = New System.Drawing.Size(11, 13)
        Me.lblRequiredFirst.TabIndex = 88
        Me.lblRequiredFirst.Text = "*"
        '
        'btnAddClient
        '
        Me.btnAddClient.Location = New System.Drawing.Point(16, 646)
        Me.btnAddClient.Name = "btnAddClient"
        Me.btnAddClient.Size = New System.Drawing.Size(110, 23)
        Me.btnAddClient.TabIndex = 2
        Me.btnAddClient.Text = "Add"
        Me.btnAddClient.UseVisualStyleBackColor = True
        '
        'lblRequiredFamily
        '
        Me.lblRequiredFamily.AutoSize = True
        Me.lblRequiredFamily.Location = New System.Drawing.Point(358, 125)
        Me.lblRequiredFamily.Name = "lblRequiredFamily"
        Me.lblRequiredFamily.Size = New System.Drawing.Size(11, 13)
        Me.lblRequiredFamily.TabIndex = 90
        Me.lblRequiredFamily.Text = "*"
        Me.lblRequiredFamily.Visible = False
        '
        'btnMoveClient
        '
        Me.btnMoveClient.Enabled = False
        Me.btnMoveClient.Location = New System.Drawing.Point(14, 387)
        Me.btnMoveClient.Name = "btnMoveClient"
        Me.btnMoveClient.Size = New System.Drawing.Size(222, 23)
        Me.btnMoveClient.TabIndex = 1
        Me.btnMoveClient.Text = "Move to different group"
        Me.btnMoveClient.UseVisualStyleBackColor = True
        '
        'btnVerifyAddress
        '
        Me.btnVerifyAddress.BackgroundImage = Global.TrackManager.My.Resources.Resources.preferences
        Me.btnVerifyAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerifyAddress.Location = New System.Drawing.Point(469, 171)
        Me.btnVerifyAddress.Name = "btnVerifyAddress"
        Me.btnVerifyAddress.Size = New System.Drawing.Size(21, 20)
        Me.btnVerifyAddress.TabIndex = 13
        Me.btnVerifyAddress.UseVisualStyleBackColor = True
        Me.btnVerifyAddress.Visible = False
        '
        'lvwPrContacts
        '
        Me.lvwPrContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPrContacts})
        Me.lvwPrContacts.FullRowSelect = True
        Me.lvwPrContacts.GridLines = True
        Me.lvwPrContacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwPrContacts.HideSelection = False
        Me.lvwPrContacts.Location = New System.Drawing.Point(14, 546)
        Me.lvwPrContacts.MultiSelect = False
        Me.lvwPrContacts.Name = "lvwPrContacts"
        Me.lvwPrContacts.Size = New System.Drawing.Size(222, 69)
        Me.lvwPrContacts.TabIndex = 91
        Me.lvwPrContacts.UseCompatibleStateImageBehavior = False
        Me.lvwPrContacts.View = System.Windows.Forms.View.Details
        '
        'colPrContacts
        '
        Me.colPrContacts.Tag = "colPrContacts"
        Me.colPrContacts.Text = "Pr. Contacts"
        Me.colPrContacts.Width = 193
        '
        'lblPrContact
        '
        Me.lblPrContact.AutoSize = True
        Me.lblPrContact.Location = New System.Drawing.Point(14, 523)
        Me.lblPrContact.Name = "lblPrContact"
        Me.lblPrContact.Size = New System.Drawing.Size(65, 13)
        Me.lblPrContact.TabIndex = 92
        Me.lblPrContact.Text = "Pr. Contacts"
        '
        'lblCreditcard
        '
        Me.lblCreditcard.AutoSize = True
        Me.lblCreditcard.Location = New System.Drawing.Point(254, 423)
        Me.lblCreditcard.Name = "lblCreditcard"
        Me.lblCreditcard.Size = New System.Drawing.Size(59, 13)
        Me.lblCreditcard.TabIndex = 94
        Me.lblCreditcard.Text = "Credit Card"
        '
        'txtCreditCard
        '
        Me.txtCreditCard.Location = New System.Drawing.Point(369, 420)
        Me.txtCreditCard.Name = "txtCreditCard"
        Me.txtCreditCard.Size = New System.Drawing.Size(121, 20)
        Me.txtCreditCard.TabIndex = 93
        Me.txtCreditCard.Tag = "0"
        '
        'lblCreditCardCcv
        '
        Me.lblCreditCardCcv.AutoSize = True
        Me.lblCreditCardCcv.Location = New System.Drawing.Point(253, 448)
        Me.lblCreditCardCcv.Name = "lblCreditCardCcv"
        Me.lblCreditCardCcv.Size = New System.Drawing.Size(111, 13)
        Me.lblCreditCardCcv.TabIndex = 96
        Me.lblCreditCardCcv.Text = "Credit Card CCV Code"
        '
        'txtCreditCardCcv
        '
        Me.txtCreditCardCcv.Location = New System.Drawing.Point(370, 445)
        Me.txtCreditCardCcv.Name = "txtCreditCardCcv"
        Me.txtCreditCardCcv.Size = New System.Drawing.Size(69, 20)
        Me.txtCreditCardCcv.TabIndex = 95
        Me.txtCreditCardCcv.Tag = "0"
        '
        'lblCreditCardValidThru
        '
        Me.lblCreditCardValidThru.AutoSize = True
        Me.lblCreditCardValidThru.Location = New System.Drawing.Point(253, 473)
        Me.lblCreditCardValidThru.Name = "lblCreditCardValidThru"
        Me.lblCreditCardValidThru.Size = New System.Drawing.Size(115, 13)
        Me.lblCreditCardValidThru.TabIndex = 98
        Me.lblCreditCardValidThru.Text = "Valid Thru (MM/YYYY)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(423, 473)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "/"
        '
        'cbxCreditCardMonth
        '
        Me.cbxCreditCardMonth.FormattingEnabled = True
        Me.cbxCreditCardMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbxCreditCardMonth.Location = New System.Drawing.Point(370, 470)
        Me.cbxCreditCardMonth.Name = "cbxCreditCardMonth"
        Me.cbxCreditCardMonth.Size = New System.Drawing.Size(47, 21)
        Me.cbxCreditCardMonth.TabIndex = 101
        '
        'cbxCreditCardYear
        '
        Me.cbxCreditCardYear.FormattingEnabled = True
        Me.cbxCreditCardYear.Items.AddRange(New Object() {"2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023"})
        Me.cbxCreditCardYear.Location = New System.Drawing.Point(437, 470)
        Me.cbxCreditCardYear.Name = "cbxCreditCardYear"
        Me.cbxCreditCardYear.Size = New System.Drawing.Size(53, 21)
        Me.cbxCreditCardYear.TabIndex = 102
        '
        'txtGroupSearch
        '
        Me.txtGroupSearch.Location = New System.Drawing.Point(14, 53)
        Me.txtGroupSearch.Name = "txtGroupSearch"
        Me.txtGroupSearch.Size = New System.Drawing.Size(222, 20)
        Me.txtGroupSearch.TabIndex = 103
        '
        'tmrClients
        '
        Me.tmrClients.Interval = 1000
        '
        'lblClientNumber
        '
        Me.lblClientNumber.AutoSize = True
        Me.lblClientNumber.Location = New System.Drawing.Point(254, 47)
        Me.lblClientNumber.Name = "lblClientNumber"
        Me.lblClientNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblClientNumber.TabIndex = 105
        Me.lblClientNumber.Text = "Client Number"
        '
        'txtClientNumber
        '
        Me.txtClientNumber.Enabled = False
        Me.txtClientNumber.Location = New System.Drawing.Point(370, 44)
        Me.txtClientNumber.Name = "txtClientNumber"
        Me.txtClientNumber.Size = New System.Drawing.Size(68, 20)
        Me.txtClientNumber.TabIndex = 104
        Me.txtClientNumber.Tag = "0"
        '
        'frmClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 680)
        Me.Controls.Add(Me.lblClientNumber)
        Me.Controls.Add(Me.txtClientNumber)
        Me.Controls.Add(Me.txtGroupSearch)
        Me.Controls.Add(Me.cbxCreditCardYear)
        Me.Controls.Add(Me.cbxCreditCardMonth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCreditCardValidThru)
        Me.Controls.Add(Me.lblCreditCardCcv)
        Me.Controls.Add(Me.txtCreditCardCcv)
        Me.Controls.Add(Me.lblCreditcard)
        Me.Controls.Add(Me.txtCreditCard)
        Me.Controls.Add(Me.lblPrContact)
        Me.Controls.Add(Me.lvwPrContacts)
        Me.Controls.Add(Me.btnVerifyAddress)
        Me.Controls.Add(Me.btnMoveClient)
        Me.Controls.Add(Me.lblRequiredFamily)
        Me.Controls.Add(Me.btnAddClient)
        Me.Controls.Add(Me.lblRequiredFirst)
        Me.Controls.Add(Me.lblClientName)
        Me.Controls.Add(Me.lblGroupName)
        Me.Controls.Add(Me.lvwClients)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.chkMailinglist)
        Me.Controls.Add(Me.lblMailinglist)
        Me.Controls.Add(Me.chkCustom2)
        Me.Controls.Add(Me.chkCustom1)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.txtMiddleName)
        Me.Controls.Add(Me.lblCustom4)
        Me.Controls.Add(Me.txtCustom4)
        Me.Controls.Add(Me.lblCustom3)
        Me.Controls.Add(Me.txtCustom3)
        Me.Controls.Add(Me.lblCustom2)
        Me.Controls.Add(Me.lblCustom1)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblBankaccount)
        Me.Controls.Add(Me.txtBankaccount)
        Me.Controls.Add(Me.lblDateOfBirth)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblMobile)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.lblTelephone)
        Me.Controls.Add(Me.txtTelephone)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.lblPostalCode)
        Me.Controls.Add(Me.txtPostalCode)
        Me.Controls.Add(Me.lblHouseNumber)
        Me.Controls.Add(Me.txtHouseNumber)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.txtStreet)
        Me.Controls.Add(Me.lblFamilyName)
        Me.Controls.Add(Me.txtFamilyName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClearClient)
        Me.Controls.Add(Me.btnUpdateClient)
        Me.Controls.Add(Me.btnDeleteClient)
        Me.Controls.Add(Me.lvwGroups)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClients"
        Me.ShowInTaskbar = False
        Me.Text = "Clients"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClearClient As System.Windows.Forms.Button
    Friend WithEvents btnUpdateClient As System.Windows.Forms.Button
    Friend WithEvents btnDeleteClient As System.Windows.Forms.Button
    Friend WithEvents lvwGroups As System.Windows.Forms.ListView
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblFamilyName As System.Windows.Forms.Label
    Friend WithEvents txtFamilyName As System.Windows.Forms.TextBox
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents lblHouseNumber As System.Windows.Forms.Label
    Friend WithEvents txtHouseNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPostalCode As System.Windows.Forms.Label
    Friend WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephone As System.Windows.Forms.Label
    Friend WithEvents txtTelephone As System.Windows.Forms.TextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents lblMobile As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblDateOfBirth As System.Windows.Forms.Label
    Friend WithEvents lblBankaccount As System.Windows.Forms.Label
    Friend WithEvents txtBankaccount As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblCustom1 As System.Windows.Forms.Label
    Friend WithEvents lblCustom2 As System.Windows.Forms.Label
    Friend WithEvents lblCustom3 As System.Windows.Forms.Label
    Friend WithEvents txtCustom3 As System.Windows.Forms.TextBox
    Friend WithEvents lblCustom4 As System.Windows.Forms.Label
    Friend WithEvents txtCustom4 As System.Windows.Forms.TextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents chkCustom1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCustom2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMailinglist As System.Windows.Forms.CheckBox
    Friend WithEvents lblMailinglist As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvwClients As System.Windows.Forms.ListView
    Friend WithEvents lblGroupName As System.Windows.Forms.Label
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents lblRequiredFirst As System.Windows.Forms.Label
    Friend WithEvents btnAddClient As System.Windows.Forms.Button
    Friend WithEvents lblRequiredFamily As System.Windows.Forms.Label
    Friend WithEvents btnMoveClient As System.Windows.Forms.Button
    Friend WithEvents btnVerifyAddress As System.Windows.Forms.Button
    Friend WithEvents lvwPrContacts As System.Windows.Forms.ListView
    Friend WithEvents colPrContacts As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPrContact As System.Windows.Forms.Label
    Friend WithEvents lblCreditcard As System.Windows.Forms.Label
    Friend WithEvents txtCreditCard As System.Windows.Forms.TextBox
    Friend WithEvents lblCreditCardCcv As System.Windows.Forms.Label
    Friend WithEvents txtCreditCardCcv As System.Windows.Forms.TextBox
    Friend WithEvents lblCreditCardValidThru As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxCreditCardMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCreditCardYear As System.Windows.Forms.ComboBox
    Friend WithEvents txtGroupSearch As System.Windows.Forms.TextBox
    Friend WithEvents tmrClients As System.Windows.Forms.Timer
    Friend WithEvents lblClientNumber As System.Windows.Forms.Label
    Friend WithEvents txtClientNumber As System.Windows.Forms.TextBox
End Class
