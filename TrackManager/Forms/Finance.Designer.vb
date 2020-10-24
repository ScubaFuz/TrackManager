<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFinance))
        Me.btnInvoicePay = New System.Windows.Forms.Button()
        Me.btnInvoiceDelete = New System.Windows.Forms.Button()
        Me.lvwProduct = New System.Windows.Forms.ListView()
        Me.colProducts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCounts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAmounts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblFinanceProduct = New System.Windows.Forms.Label()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.lblGroupName = New System.Windows.Forms.Label()
        Me.lvwFinanceClients = New System.Windows.Forms.ListView()
        Me.lvwFinanceGroups = New System.Windows.Forms.ListView()
        Me.btnInvoiceAdd = New System.Windows.Forms.Button()
        Me.btnDetailsEdit = New System.Windows.Forms.Button()
        Me.lvwPayments = New System.Windows.Forms.ListView()
        Me.colPayDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayLogin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPayAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblInvoicePayments = New System.Windows.Forms.Label()
        Me.lblInvoiceDetails = New System.Windows.Forms.Label()
        Me.lblInvoices = New System.Windows.Forms.Label()
        Me.lvwInvoiceLines = New System.Windows.Forms.ListView()
        Me.colLineClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLineLogin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLineProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLineCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLineAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLineTax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvwInvoices = New System.Windows.Forms.ListView()
        Me.colInvoiceDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colInvoiceClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colInvoiceLogin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colInvoicePayed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.txtProductAmount = New System.Windows.Forms.TextBox()
        Me.cbxTax = New System.Windows.Forms.ComboBox()
        Me.btnDetailsSave = New System.Windows.Forms.Button()
        Me.btnDetailsDelete = New System.Windows.Forms.Button()
        Me.btnPaymentDelete = New System.Windows.Forms.Button()
        Me.btnPaymentAdd = New System.Windows.Forms.Button()
        Me.btnDetailsAdd = New System.Windows.Forms.Button()
        Me.txtPayAmount = New System.Windows.Forms.TextBox()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.txtDue = New System.Windows.Forms.TextBox()
        Me.txtPayed = New System.Windows.Forms.TextBox()
        Me.txtBilled = New System.Windows.Forms.TextBox()
        Me.lblBilled = New System.Windows.Forms.Label()
        Me.lblPayed = New System.Windows.Forms.Label()
        Me.lblDue = New System.Windows.Forms.Label()
        Me.btncheckInvoices = New System.Windows.Forms.Button()
        Me.txtGroupSearch = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInvoicePay
        '
        Me.btnInvoicePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInvoicePay.Enabled = False
        Me.btnInvoicePay.Location = New System.Drawing.Point(856, 60)
        Me.btnInvoicePay.Name = "btnInvoicePay"
        Me.btnInvoicePay.Size = New System.Drawing.Size(110, 23)
        Me.btnInvoicePay.TabIndex = 19
        Me.btnInvoicePay.Text = "Pay Invoice"
        Me.btnInvoicePay.UseVisualStyleBackColor = True
        '
        'btnInvoiceDelete
        '
        Me.btnInvoiceDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInvoiceDelete.Enabled = False
        Me.btnInvoiceDelete.Location = New System.Drawing.Point(856, 89)
        Me.btnInvoiceDelete.Name = "btnInvoiceDelete"
        Me.btnInvoiceDelete.Size = New System.Drawing.Size(110, 23)
        Me.btnInvoiceDelete.TabIndex = 20
        Me.btnInvoiceDelete.Text = "Delete Invoice"
        Me.btnInvoiceDelete.UseVisualStyleBackColor = True
        '
        'lvwProduct
        '
        Me.lvwProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwProduct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProducts, Me.colCounts, Me.colAmounts, Me.colTax})
        Me.lvwProduct.FullRowSelect = True
        Me.lvwProduct.GridLines = True
        Me.lvwProduct.Location = New System.Drawing.Point(12, 20)
        Me.lvwProduct.MultiSelect = False
        Me.lvwProduct.Name = "lvwProduct"
        Me.lvwProduct.Size = New System.Drawing.Size(222, 121)
        Me.lvwProduct.TabIndex = 3
        Me.lvwProduct.UseCompatibleStateImageBehavior = False
        Me.lvwProduct.View = System.Windows.Forms.View.Details
        '
        'colProducts
        '
        Me.colProducts.Tag = "colProducts"
        Me.colProducts.Text = "Product"
        Me.colProducts.Width = 76
        '
        'colCounts
        '
        Me.colCounts.Tag = "colCounts"
        Me.colCounts.Text = "Count"
        Me.colCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCounts.Width = 40
        '
        'colAmounts
        '
        Me.colAmounts.Tag = "colAmounts"
        Me.colAmounts.Text = "Amount"
        Me.colAmounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colAmounts.Width = 48
        '
        'colTax
        '
        Me.colTax.Tag = "colTax"
        Me.colTax.Text = "Tax"
        Me.colTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTax.Width = 30
        '
        'lblFinanceProduct
        '
        Me.lblFinanceProduct.AutoSize = True
        Me.lblFinanceProduct.Location = New System.Drawing.Point(12, 4)
        Me.lblFinanceProduct.Name = "lblFinanceProduct"
        Me.lblFinanceProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblFinanceProduct.TabIndex = 105
        Me.lblFinanceProduct.Text = "Product"
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Location = New System.Drawing.Point(9, 9)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(64, 13)
        Me.lblClientName.TabIndex = 104
        Me.lblClientName.Text = "Client Name"
        '
        'lblGroupName
        '
        Me.lblGroupName.AutoSize = True
        Me.lblGroupName.Location = New System.Drawing.Point(12, 10)
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.Size = New System.Drawing.Size(67, 13)
        Me.lblGroupName.TabIndex = 103
        Me.lblGroupName.Text = "Group Name"
        '
        'lvwFinanceClients
        '
        Me.lvwFinanceClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwFinanceClients.FullRowSelect = True
        Me.lvwFinanceClients.GridLines = True
        Me.lvwFinanceClients.Location = New System.Drawing.Point(11, 25)
        Me.lvwFinanceClients.MultiSelect = False
        Me.lvwFinanceClients.Name = "lvwFinanceClients"
        Me.lvwFinanceClients.Size = New System.Drawing.Size(222, 254)
        Me.lvwFinanceClients.TabIndex = 2
        Me.lvwFinanceClients.UseCompatibleStateImageBehavior = False
        Me.lvwFinanceClients.View = System.Windows.Forms.View.Details
        '
        'lvwFinanceGroups
        '
        Me.lvwFinanceGroups.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwFinanceGroups.FullRowSelect = True
        Me.lvwFinanceGroups.GridLines = True
        Me.lvwFinanceGroups.Location = New System.Drawing.Point(12, 52)
        Me.lvwFinanceGroups.MultiSelect = False
        Me.lvwFinanceGroups.Name = "lvwFinanceGroups"
        Me.lvwFinanceGroups.Size = New System.Drawing.Size(222, 95)
        Me.lvwFinanceGroups.TabIndex = 1
        Me.lvwFinanceGroups.UseCompatibleStateImageBehavior = False
        Me.lvwFinanceGroups.View = System.Windows.Forms.View.Details
        '
        'btnInvoiceAdd
        '
        Me.btnInvoiceAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInvoiceAdd.Enabled = False
        Me.btnInvoiceAdd.Location = New System.Drawing.Point(12, 200)
        Me.btnInvoiceAdd.Name = "btnInvoiceAdd"
        Me.btnInvoiceAdd.Size = New System.Drawing.Size(110, 23)
        Me.btnInvoiceAdd.TabIndex = 8
        Me.btnInvoiceAdd.Text = "Add Invoice"
        Me.btnInvoiceAdd.UseVisualStyleBackColor = True
        '
        'btnDetailsEdit
        '
        Me.btnDetailsEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetailsEdit.Enabled = False
        Me.btnDetailsEdit.Location = New System.Drawing.Point(856, 25)
        Me.btnDetailsEdit.Name = "btnDetailsEdit"
        Me.btnDetailsEdit.Size = New System.Drawing.Size(110, 23)
        Me.btnDetailsEdit.TabIndex = 21
        Me.btnDetailsEdit.Text = "Edit Details"
        Me.btnDetailsEdit.UseVisualStyleBackColor = True
        '
        'lvwPayments
        '
        Me.lvwPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPayDate, Me.colPayClient, Me.colPayLogin, Me.colPayAmount})
        Me.lvwPayments.FullRowSelect = True
        Me.lvwPayments.GridLines = True
        Me.lvwPayments.HideSelection = False
        Me.lvwPayments.Location = New System.Drawing.Point(240, 20)
        Me.lvwPayments.MultiSelect = False
        Me.lvwPayments.Name = "lvwPayments"
        Me.lvwPayments.Size = New System.Drawing.Size(613, 121)
        Me.lvwPayments.TabIndex = 14
        Me.lvwPayments.UseCompatibleStateImageBehavior = False
        Me.lvwPayments.View = System.Windows.Forms.View.Details
        '
        'colPayDate
        '
        Me.colPayDate.Tag = "colPayDate"
        Me.colPayDate.Text = "Date"
        Me.colPayDate.Width = 77
        '
        'colPayClient
        '
        Me.colPayClient.Tag = "colPayClient"
        Me.colPayClient.Text = "Payed By"
        Me.colPayClient.Width = 145
        '
        'colPayLogin
        '
        Me.colPayLogin.Tag = "colPayLogin"
        Me.colPayLogin.Text = "Booked By"
        Me.colPayLogin.Width = 75
        '
        'colPayAmount
        '
        Me.colPayAmount.Tag = "colPayAmount"
        Me.colPayAmount.Text = "Amount"
        Me.colPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPayAmount.Width = 72
        '
        'lblInvoicePayments
        '
        Me.lblInvoicePayments.AutoSize = True
        Me.lblInvoicePayments.Location = New System.Drawing.Point(240, 4)
        Me.lblInvoicePayments.Name = "lblInvoicePayments"
        Me.lblInvoicePayments.Size = New System.Drawing.Size(91, 13)
        Me.lblInvoicePayments.TabIndex = 113
        Me.lblInvoicePayments.Text = "Invoice Payments"
        '
        'lblInvoiceDetails
        '
        Me.lblInvoiceDetails.AutoSize = True
        Me.lblInvoiceDetails.Location = New System.Drawing.Point(239, 9)
        Me.lblInvoiceDetails.Name = "lblInvoiceDetails"
        Me.lblInvoiceDetails.Size = New System.Drawing.Size(77, 13)
        Me.lblInvoiceDetails.TabIndex = 112
        Me.lblInvoiceDetails.Text = "Invoice Details"
        '
        'lblInvoices
        '
        Me.lblInvoices.AutoSize = True
        Me.lblInvoices.Location = New System.Drawing.Point(240, 10)
        Me.lblInvoices.Name = "lblInvoices"
        Me.lblInvoices.Size = New System.Drawing.Size(47, 13)
        Me.lblInvoices.TabIndex = 111
        Me.lblInvoices.Text = "Invoices"
        '
        'lvwInvoiceLines
        '
        Me.lvwInvoiceLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwInvoiceLines.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLineClient, Me.colLineLogin, Me.colLineProduct, Me.colLineCount, Me.colLineAmount, Me.colLineTax})
        Me.lvwInvoiceLines.FullRowSelect = True
        Me.lvwInvoiceLines.GridLines = True
        Me.lvwInvoiceLines.HideSelection = False
        Me.lvwInvoiceLines.Location = New System.Drawing.Point(240, 25)
        Me.lvwInvoiceLines.MultiSelect = False
        Me.lvwInvoiceLines.Name = "lvwInvoiceLines"
        Me.lvwInvoiceLines.Size = New System.Drawing.Size(613, 254)
        Me.lvwInvoiceLines.TabIndex = 13
        Me.lvwInvoiceLines.UseCompatibleStateImageBehavior = False
        Me.lvwInvoiceLines.View = System.Windows.Forms.View.Details
        '
        'colLineClient
        '
        Me.colLineClient.Tag = "colLineClient"
        Me.colLineClient.Text = "Client"
        Me.colLineClient.Width = 84
        '
        'colLineLogin
        '
        Me.colLineLogin.Tag = "colLineLogin"
        Me.colLineLogin.Text = "Booked By"
        Me.colLineLogin.Width = 64
        '
        'colLineProduct
        '
        Me.colLineProduct.Tag = "colLineProduct"
        Me.colLineProduct.Text = "Product"
        Me.colLineProduct.Width = 104
        '
        'colLineCount
        '
        Me.colLineCount.Tag = "colLineCount"
        Me.colLineCount.Text = "Count"
        Me.colLineCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLineCount.Width = 41
        '
        'colLineAmount
        '
        Me.colLineAmount.Tag = "colLineAmount"
        Me.colLineAmount.Text = "Amount"
        Me.colLineAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLineAmount.Width = 49
        '
        'colLineTax
        '
        Me.colLineTax.Tag = "colLineTax"
        Me.colLineTax.Text = "Tax"
        Me.colLineTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLineTax.Width = 31
        '
        'lvwInvoices
        '
        Me.lvwInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwInvoices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colInvoiceDate, Me.colInvoiceClient, Me.colInvoiceLogin, Me.colInvoicePayed})
        Me.lvwInvoices.FullRowSelect = True
        Me.lvwInvoices.GridLines = True
        Me.lvwInvoices.Location = New System.Drawing.Point(240, 26)
        Me.lvwInvoices.MultiSelect = False
        Me.lvwInvoices.Name = "lvwInvoices"
        Me.lvwInvoices.Size = New System.Drawing.Size(613, 121)
        Me.lvwInvoices.TabIndex = 12
        Me.lvwInvoices.UseCompatibleStateImageBehavior = False
        Me.lvwInvoices.View = System.Windows.Forms.View.Details
        '
        'colInvoiceDate
        '
        Me.colInvoiceDate.Tag = "colInvoiceDate"
        Me.colInvoiceDate.Text = "Date"
        Me.colInvoiceDate.Width = 64
        '
        'colInvoiceClient
        '
        Me.colInvoiceClient.Tag = "colInvoiceClient"
        Me.colInvoiceClient.Text = "Client"
        Me.colInvoiceClient.Width = 155
        '
        'colInvoiceLogin
        '
        Me.colInvoiceLogin.Tag = "colInvoiceLogin"
        Me.colInvoiceLogin.Text = "Booked By"
        Me.colInvoiceLogin.Width = 93
        '
        'colInvoicePayed
        '
        Me.colInvoicePayed.Tag = "colInvoicePayed"
        Me.colInvoicePayed.Text = "Payed"
        '
        'txtProduct
        '
        Me.txtProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProduct.Location = New System.Drawing.Point(12, 147)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(222, 20)
        Me.txtProduct.TabIndex = 4
        '
        'txtCount
        '
        Me.txtCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCount.Location = New System.Drawing.Point(12, 173)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(67, 20)
        Me.txtCount.TabIndex = 5
        Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductAmount
        '
        Me.txtProductAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProductAmount.Location = New System.Drawing.Point(85, 173)
        Me.txtProductAmount.Name = "txtProductAmount"
        Me.txtProductAmount.Size = New System.Drawing.Size(67, 20)
        Me.txtProductAmount.TabIndex = 6
        Me.txtProductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxTax
        '
        Me.cbxTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxTax.FormattingEnabled = True
        Me.cbxTax.Location = New System.Drawing.Point(158, 173)
        Me.cbxTax.Name = "cbxTax"
        Me.cbxTax.Size = New System.Drawing.Size(76, 21)
        Me.cbxTax.TabIndex = 7
        '
        'btnDetailsSave
        '
        Me.btnDetailsSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDetailsSave.Enabled = False
        Me.btnDetailsSave.Location = New System.Drawing.Point(128, 229)
        Me.btnDetailsSave.Name = "btnDetailsSave"
        Me.btnDetailsSave.Size = New System.Drawing.Size(110, 23)
        Me.btnDetailsSave.TabIndex = 11
        Me.btnDetailsSave.Text = "Update Details"
        Me.btnDetailsSave.UseVisualStyleBackColor = True
        '
        'btnDetailsDelete
        '
        Me.btnDetailsDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetailsDelete.Enabled = False
        Me.btnDetailsDelete.Location = New System.Drawing.Point(856, 54)
        Me.btnDetailsDelete.Name = "btnDetailsDelete"
        Me.btnDetailsDelete.Size = New System.Drawing.Size(110, 23)
        Me.btnDetailsDelete.TabIndex = 22
        Me.btnDetailsDelete.Text = "Delete Details"
        Me.btnDetailsDelete.UseVisualStyleBackColor = True
        '
        'btnPaymentDelete
        '
        Me.btnPaymentDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPaymentDelete.Enabled = False
        Me.btnPaymentDelete.Location = New System.Drawing.Point(859, 49)
        Me.btnPaymentDelete.Name = "btnPaymentDelete"
        Me.btnPaymentDelete.Size = New System.Drawing.Size(110, 23)
        Me.btnPaymentDelete.TabIndex = 24
        Me.btnPaymentDelete.Text = "Delete Payment"
        Me.btnPaymentDelete.UseVisualStyleBackColor = True
        '
        'btnPaymentAdd
        '
        Me.btnPaymentAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPaymentAdd.Enabled = False
        Me.btnPaymentAdd.Location = New System.Drawing.Point(859, 20)
        Me.btnPaymentAdd.Name = "btnPaymentAdd"
        Me.btnPaymentAdd.Size = New System.Drawing.Size(110, 23)
        Me.btnPaymentAdd.TabIndex = 23
        Me.btnPaymentAdd.Text = "Make Payment"
        Me.btnPaymentAdd.UseVisualStyleBackColor = True
        '
        'btnDetailsAdd
        '
        Me.btnDetailsAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDetailsAdd.Enabled = False
        Me.btnDetailsAdd.Location = New System.Drawing.Point(128, 200)
        Me.btnDetailsAdd.Name = "btnDetailsAdd"
        Me.btnDetailsAdd.Size = New System.Drawing.Size(110, 23)
        Me.btnDetailsAdd.TabIndex = 9
        Me.btnDetailsAdd.Text = "Add Details"
        Me.btnDetailsAdd.UseVisualStyleBackColor = True
        '
        'txtPayAmount
        '
        Me.txtPayAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPayAmount.Location = New System.Drawing.Point(566, 225)
        Me.txtPayAmount.Name = "txtPayAmount"
        Me.txtPayAmount.Size = New System.Drawing.Size(73, 20)
        Me.txtPayAmount.TabIndex = 18
        Me.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPayment
        '
        Me.lblPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPayment.AutoSize = True
        Me.lblPayment.Location = New System.Drawing.Point(465, 228)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(48, 13)
        Me.lblPayment.TabIndex = 126
        Me.lblPayment.Text = "Payment"
        '
        'txtDue
        '
        Me.txtDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDue.Enabled = False
        Me.txtDue.Location = New System.Drawing.Point(566, 199)
        Me.txtDue.Name = "txtDue"
        Me.txtDue.Size = New System.Drawing.Size(73, 20)
        Me.txtDue.TabIndex = 17
        Me.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPayed
        '
        Me.txtPayed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPayed.Enabled = False
        Me.txtPayed.Location = New System.Drawing.Point(566, 173)
        Me.txtPayed.Name = "txtPayed"
        Me.txtPayed.Size = New System.Drawing.Size(73, 20)
        Me.txtPayed.TabIndex = 16
        Me.txtPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBilled
        '
        Me.txtBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBilled.Enabled = False
        Me.txtBilled.Location = New System.Drawing.Point(566, 147)
        Me.txtBilled.Name = "txtBilled"
        Me.txtBilled.Size = New System.Drawing.Size(73, 20)
        Me.txtBilled.TabIndex = 15
        Me.txtBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBilled
        '
        Me.lblBilled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBilled.AutoSize = True
        Me.lblBilled.Location = New System.Drawing.Point(465, 150)
        Me.lblBilled.Name = "lblBilled"
        Me.lblBilled.Size = New System.Drawing.Size(32, 13)
        Me.lblBilled.TabIndex = 130
        Me.lblBilled.Text = "Billed"
        '
        'lblPayed
        '
        Me.lblPayed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPayed.AutoSize = True
        Me.lblPayed.Location = New System.Drawing.Point(465, 176)
        Me.lblPayed.Name = "lblPayed"
        Me.lblPayed.Size = New System.Drawing.Size(37, 13)
        Me.lblPayed.TabIndex = 131
        Me.lblPayed.Text = "Payed"
        '
        'lblDue
        '
        Me.lblDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDue.AutoSize = True
        Me.lblDue.Location = New System.Drawing.Point(465, 202)
        Me.lblDue.Name = "lblDue"
        Me.lblDue.Size = New System.Drawing.Size(27, 13)
        Me.lblDue.TabIndex = 132
        Me.lblDue.Text = "Due"
        '
        'btncheckInvoices
        '
        Me.btncheckInvoices.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncheckInvoices.Enabled = False
        Me.btncheckInvoices.Location = New System.Drawing.Point(12, 229)
        Me.btncheckInvoices.Name = "btncheckInvoices"
        Me.btncheckInvoices.Size = New System.Drawing.Size(110, 23)
        Me.btncheckInvoices.TabIndex = 10
        Me.btncheckInvoices.Text = "Check Invoices"
        Me.btncheckInvoices.UseVisualStyleBackColor = True
        '
        'txtGroupSearch
        '
        Me.txtGroupSearch.Location = New System.Drawing.Point(12, 26)
        Me.txtGroupSearch.Name = "txtGroupSearch"
        Me.txtGroupSearch.Size = New System.Drawing.Size(222, 20)
        Me.txtGroupSearch.TabIndex = 133
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(856, 26)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 23)
        Me.btnClose.TabIndex = 134
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.lvwInvoices)
        Me.Panel1.Controls.Add(Me.txtGroupSearch)
        Me.Panel1.Controls.Add(Me.lvwFinanceGroups)
        Me.Panel1.Controls.Add(Me.lblGroupName)
        Me.Panel1.Controls.Add(Me.btnInvoiceDelete)
        Me.Panel1.Controls.Add(Me.btnInvoicePay)
        Me.Panel1.Controls.Add(Me.lblInvoices)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 150)
        Me.Panel1.TabIndex = 135
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btncheckInvoices)
        Me.Panel2.Controls.Add(Me.lvwPayments)
        Me.Panel2.Controls.Add(Me.lblDue)
        Me.Panel2.Controls.Add(Me.btnInvoiceAdd)
        Me.Panel2.Controls.Add(Me.lblPayed)
        Me.Panel2.Controls.Add(Me.lblFinanceProduct)
        Me.Panel2.Controls.Add(Me.lblBilled)
        Me.Panel2.Controls.Add(Me.lvwProduct)
        Me.Panel2.Controls.Add(Me.txtBilled)
        Me.Panel2.Controls.Add(Me.lblInvoicePayments)
        Me.Panel2.Controls.Add(Me.txtPayed)
        Me.Panel2.Controls.Add(Me.txtProduct)
        Me.Panel2.Controls.Add(Me.txtDue)
        Me.Panel2.Controls.Add(Me.txtCount)
        Me.Panel2.Controls.Add(Me.lblPayment)
        Me.Panel2.Controls.Add(Me.txtProductAmount)
        Me.Panel2.Controls.Add(Me.txtPayAmount)
        Me.Panel2.Controls.Add(Me.cbxTax)
        Me.Panel2.Controls.Add(Me.btnDetailsAdd)
        Me.Panel2.Controls.Add(Me.btnDetailsSave)
        Me.Panel2.Controls.Add(Me.btnPaymentAdd)
        Me.Panel2.Controls.Add(Me.btnPaymentDelete)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 437)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(978, 256)
        Me.Panel2.TabIndex = 136
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lvwFinanceClients)
        Me.Panel3.Controls.Add(Me.btnDetailsDelete)
        Me.Panel3.Controls.Add(Me.lvwInvoiceLines)
        Me.Panel3.Controls.Add(Me.lblInvoiceDetails)
        Me.Panel3.Controls.Add(Me.btnDetailsEdit)
        Me.Panel3.Controls.Add(Me.lblClientName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 150)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(978, 287)
        Me.Panel3.TabIndex = 137
        '
        'frmFinance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 693)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFinance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Finance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnInvoicePay As System.Windows.Forms.Button
    Friend WithEvents btnInvoiceDelete As System.Windows.Forms.Button
    Friend WithEvents lvwProduct As System.Windows.Forms.ListView
    Friend WithEvents colProducts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCounts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAmounts As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTax As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblFinanceProduct As System.Windows.Forms.Label
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents lblGroupName As System.Windows.Forms.Label
    Friend WithEvents lvwFinanceClients As System.Windows.Forms.ListView
    Friend WithEvents lvwFinanceGroups As System.Windows.Forms.ListView
    Friend WithEvents btnInvoiceAdd As System.Windows.Forms.Button
    Friend WithEvents btnDetailsEdit As System.Windows.Forms.Button
    Friend WithEvents lvwPayments As System.Windows.Forms.ListView
    Friend WithEvents lblInvoicePayments As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceDetails As System.Windows.Forms.Label
    Friend WithEvents lblInvoices As System.Windows.Forms.Label
    Friend WithEvents lvwInvoiceLines As System.Windows.Forms.ListView
    Friend WithEvents lvwInvoices As System.Windows.Forms.ListView
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents txtProductAmount As System.Windows.Forms.TextBox
    Friend WithEvents cbxTax As System.Windows.Forms.ComboBox
    Friend WithEvents btnDetailsSave As System.Windows.Forms.Button
    Friend WithEvents btnDetailsDelete As System.Windows.Forms.Button
    Friend WithEvents btnPaymentDelete As System.Windows.Forms.Button
    Friend WithEvents colPayDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPaymentAdd As System.Windows.Forms.Button
    Friend WithEvents btnDetailsAdd As System.Windows.Forms.Button
    Friend WithEvents txtPayAmount As System.Windows.Forms.TextBox
    Friend WithEvents colPayAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLineClient As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInvoiceDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInvoiceClient As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInvoiceLogin As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInvoicePayed As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLineLogin As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLineProduct As System.Windows.Forms.ColumnHeader
	Friend WithEvents colLineCount As System.Windows.Forms.ColumnHeader
	Friend WithEvents colLineAmount As System.Windows.Forms.ColumnHeader
	Friend WithEvents colLineTax As System.Windows.Forms.ColumnHeader
	Friend WithEvents colPayClient As System.Windows.Forms.ColumnHeader
	Friend WithEvents colPayLogin As System.Windows.Forms.ColumnHeader
	Friend WithEvents lblPayment As System.Windows.Forms.Label
	Friend WithEvents txtDue As System.Windows.Forms.TextBox
	Friend WithEvents txtPayed As System.Windows.Forms.TextBox
	Friend WithEvents txtBilled As System.Windows.Forms.TextBox
	Friend WithEvents lblBilled As System.Windows.Forms.Label
	Friend WithEvents lblPayed As System.Windows.Forms.Label
	Friend WithEvents lblDue As System.Windows.Forms.Label
    Friend WithEvents btncheckInvoices As System.Windows.Forms.Button
    Friend WithEvents txtGroupSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
