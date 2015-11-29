<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogins
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogins))
        Me.lvwLoginName = New System.Windows.Forms.ListView()
        Me.colLoginName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtLoginName = New System.Windows.Forms.TextBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.lblLoginName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblDateStart = New System.Windows.Forms.Label()
        Me.txtDateStop = New System.Windows.Forms.TextBox()
        Me.lblDateStop = New System.Windows.Forms.Label()
        Me.txtDateStart = New System.Windows.Forms.TextBox()
        Me.chkClientsDelete = New System.Windows.Forms.CheckBox()
        Me.chkGroupsDelete = New System.Windows.Forms.CheckBox()
        Me.chkSettingsDelete = New System.Windows.Forms.CheckBox()
        Me.chkSettingsChange = New System.Windows.Forms.CheckBox()
        Me.chkSettingsAdd = New System.Windows.Forms.CheckBox()
        Me.chkfinanceDelete = New System.Windows.Forms.CheckBox()
        Me.chkFinanceChange = New System.Windows.Forms.CheckBox()
        Me.chkFinanceAdd = New System.Windows.Forms.CheckBox()
        Me.chkLoginDelete = New System.Windows.Forms.CheckBox()
        Me.chkLoginChange = New System.Windows.Forms.CheckBox()
        Me.chkLoginAdd = New System.Windows.Forms.CheckBox()
        Me.btnLoginAdd = New System.Windows.Forms.Button()
        Me.btnLoginSave = New System.Windows.Forms.Button()
        Me.btnLoginDelete = New System.Windows.Forms.Button()
        Me.btnLoginClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateStop = New System.Windows.Forms.DateTimePicker()
        Me.btnDateStopClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwLoginName
        '
        Me.lvwLoginName.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLoginName})
        Me.lvwLoginName.FullRowSelect = True
        Me.lvwLoginName.HideSelection = False
        Me.lvwLoginName.Location = New System.Drawing.Point(12, 12)
        Me.lvwLoginName.MultiSelect = False
        Me.lvwLoginName.Name = "lvwLoginName"
        Me.lvwLoginName.Size = New System.Drawing.Size(138, 132)
        Me.lvwLoginName.TabIndex = 1
        Me.lvwLoginName.UseCompatibleStateImageBehavior = False
        Me.lvwLoginName.View = System.Windows.Forms.View.Details
        '
        'colLoginName
        '
        Me.colLoginName.Tag = "colLoginName"
        Me.colLoginName.Text = "Login Name"
        Me.colLoginName.Width = 111
        '
        'txtLoginName
        '
        Me.txtLoginName.Location = New System.Drawing.Point(156, 62)
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(135, 20)
        Me.txtLoginName.TabIndex = 3
        '
        'chkEnabled
        '
        Me.chkEnabled.Location = New System.Drawing.Point(159, 127)
        Me.chkEnabled.MaximumSize = New System.Drawing.Size(112, 17)
        Me.chkEnabled.MinimumSize = New System.Drawing.Size(65, 17)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(112, 17)
        Me.chkEnabled.TabIndex = 5
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoSize = True
        Me.lblLoginName.Location = New System.Drawing.Point(156, 46)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(64, 13)
        Me.lblLoginName.TabIndex = 3
        Me.lblLoginName.Text = "Login Name"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(156, 85)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(156, 101)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(135, 20)
        Me.txtPassword.TabIndex = 4
        '
        'lblDateStart
        '
        Me.lblDateStart.AutoSize = True
        Me.lblDateStart.Location = New System.Drawing.Point(15, 162)
        Me.lblDateStart.Name = "lblDateStart"
        Me.lblDateStart.Size = New System.Drawing.Size(55, 13)
        Me.lblDateStart.TabIndex = 7
        Me.lblDateStart.Text = "Start Date"
        '
        'txtDateStop
        '
        Me.txtDateStop.Location = New System.Drawing.Point(156, 178)
        Me.txtDateStop.Name = "txtDateStop"
        Me.txtDateStop.ReadOnly = True
        Me.txtDateStop.Size = New System.Drawing.Size(89, 20)
        Me.txtDateStop.TabIndex = 6
        '
        'lblDateStop
        '
        Me.lblDateStop.AutoSize = True
        Me.lblDateStop.Location = New System.Drawing.Point(156, 162)
        Me.lblDateStop.Name = "lblDateStop"
        Me.lblDateStop.Size = New System.Drawing.Size(62, 13)
        Me.lblDateStop.TabIndex = 9
        Me.lblDateStop.Text = "Expire Date"
        '
        'txtDateStart
        '
        Me.txtDateStart.Location = New System.Drawing.Point(15, 178)
        Me.txtDateStart.Name = "txtDateStart"
        Me.txtDateStart.ReadOnly = True
        Me.txtDateStart.Size = New System.Drawing.Size(106, 20)
        Me.txtDateStart.TabIndex = 8
        '
        'chkClientsDelete
        '
        Me.chkClientsDelete.AutoSize = True
        Me.chkClientsDelete.Location = New System.Drawing.Point(159, 333)
        Me.chkClientsDelete.Name = "chkClientsDelete"
        Me.chkClientsDelete.Size = New System.Drawing.Size(91, 17)
        Me.chkClientsDelete.TabIndex = 19
        Me.chkClientsDelete.Text = "Delete Clients"
        Me.chkClientsDelete.UseVisualStyleBackColor = True
        '
        'chkGroupsDelete
        '
        Me.chkGroupsDelete.AutoSize = True
        Me.chkGroupsDelete.Location = New System.Drawing.Point(159, 287)
        Me.chkGroupsDelete.Name = "chkGroupsDelete"
        Me.chkGroupsDelete.Size = New System.Drawing.Size(94, 17)
        Me.chkGroupsDelete.TabIndex = 18
        Me.chkGroupsDelete.Text = "Delete Groups"
        Me.chkGroupsDelete.UseVisualStyleBackColor = True
        '
        'chkSettingsDelete
        '
        Me.chkSettingsDelete.AutoSize = True
        Me.chkSettingsDelete.Location = New System.Drawing.Point(159, 250)
        Me.chkSettingsDelete.Name = "chkSettingsDelete"
        Me.chkSettingsDelete.Size = New System.Drawing.Size(98, 17)
        Me.chkSettingsDelete.TabIndex = 17
        Me.chkSettingsDelete.Text = "Delete Settings"
        Me.chkSettingsDelete.UseVisualStyleBackColor = True
        '
        'chkSettingsChange
        '
        Me.chkSettingsChange.AutoSize = True
        Me.chkSettingsChange.Location = New System.Drawing.Point(159, 227)
        Me.chkSettingsChange.Name = "chkSettingsChange"
        Me.chkSettingsChange.Size = New System.Drawing.Size(104, 17)
        Me.chkSettingsChange.TabIndex = 16
        Me.chkSettingsChange.Text = "Change Settings"
        Me.chkSettingsChange.UseVisualStyleBackColor = True
        '
        'chkSettingsAdd
        '
        Me.chkSettingsAdd.AutoSize = True
        Me.chkSettingsAdd.Location = New System.Drawing.Point(159, 204)
        Me.chkSettingsAdd.Name = "chkSettingsAdd"
        Me.chkSettingsAdd.Size = New System.Drawing.Size(86, 17)
        Me.chkSettingsAdd.TabIndex = 15
        Me.chkSettingsAdd.Text = "Add Settings"
        Me.chkSettingsAdd.UseVisualStyleBackColor = True
        '
        'chkfinanceDelete
        '
        Me.chkfinanceDelete.AutoSize = True
        Me.chkfinanceDelete.Location = New System.Drawing.Point(15, 333)
        Me.chkfinanceDelete.Name = "chkfinanceDelete"
        Me.chkfinanceDelete.Size = New System.Drawing.Size(100, 17)
        Me.chkfinanceDelete.TabIndex = 14
        Me.chkfinanceDelete.Text = "Delete Invoices"
        Me.chkfinanceDelete.UseVisualStyleBackColor = True
        '
        'chkFinanceChange
        '
        Me.chkFinanceChange.AutoSize = True
        Me.chkFinanceChange.Location = New System.Drawing.Point(15, 310)
        Me.chkFinanceChange.Name = "chkFinanceChange"
        Me.chkFinanceChange.Size = New System.Drawing.Size(106, 17)
        Me.chkFinanceChange.TabIndex = 13
        Me.chkFinanceChange.Text = "Change Invoices"
        Me.chkFinanceChange.UseVisualStyleBackColor = True
        '
        'chkFinanceAdd
        '
        Me.chkFinanceAdd.AutoSize = True
        Me.chkFinanceAdd.Location = New System.Drawing.Point(15, 287)
        Me.chkFinanceAdd.Name = "chkFinanceAdd"
        Me.chkFinanceAdd.Size = New System.Drawing.Size(89, 17)
        Me.chkFinanceAdd.TabIndex = 12
        Me.chkFinanceAdd.Text = "Add Invoiced"
        Me.chkFinanceAdd.UseVisualStyleBackColor = True
        '
        'chkLoginDelete
        '
        Me.chkLoginDelete.AutoSize = True
        Me.chkLoginDelete.Location = New System.Drawing.Point(15, 250)
        Me.chkLoginDelete.Name = "chkLoginDelete"
        Me.chkLoginDelete.Size = New System.Drawing.Size(91, 17)
        Me.chkLoginDelete.TabIndex = 11
        Me.chkLoginDelete.Text = "Delete Logins"
        Me.chkLoginDelete.UseVisualStyleBackColor = True
        '
        'chkLoginChange
        '
        Me.chkLoginChange.AutoSize = True
        Me.chkLoginChange.Location = New System.Drawing.Point(15, 227)
        Me.chkLoginChange.Name = "chkLoginChange"
        Me.chkLoginChange.Size = New System.Drawing.Size(97, 17)
        Me.chkLoginChange.TabIndex = 10
        Me.chkLoginChange.Text = "Change Logins"
        Me.chkLoginChange.UseVisualStyleBackColor = True
        '
        'chkLoginAdd
        '
        Me.chkLoginAdd.AutoSize = True
        Me.chkLoginAdd.Location = New System.Drawing.Point(15, 204)
        Me.chkLoginAdd.Name = "chkLoginAdd"
        Me.chkLoginAdd.Size = New System.Drawing.Size(79, 17)
        Me.chkLoginAdd.TabIndex = 9
        Me.chkLoginAdd.Text = "Add Logins"
        Me.chkLoginAdd.UseVisualStyleBackColor = True
        '
        'btnLoginAdd
        '
        Me.btnLoginAdd.Enabled = False
        Me.btnLoginAdd.Location = New System.Drawing.Point(15, 366)
        Me.btnLoginAdd.Name = "btnLoginAdd"
        Me.btnLoginAdd.Size = New System.Drawing.Size(135, 23)
        Me.btnLoginAdd.TabIndex = 20
        Me.btnLoginAdd.Text = "Add Login"
        Me.btnLoginAdd.UseVisualStyleBackColor = True
        '
        'btnLoginSave
        '
        Me.btnLoginSave.Enabled = False
        Me.btnLoginSave.Location = New System.Drawing.Point(15, 395)
        Me.btnLoginSave.Name = "btnLoginSave"
        Me.btnLoginSave.Size = New System.Drawing.Size(135, 23)
        Me.btnLoginSave.TabIndex = 21
        Me.btnLoginSave.Text = "Update Login"
        Me.btnLoginSave.UseVisualStyleBackColor = True
        '
        'btnLoginDelete
        '
        Me.btnLoginDelete.Enabled = False
        Me.btnLoginDelete.Location = New System.Drawing.Point(156, 366)
        Me.btnLoginDelete.Name = "btnLoginDelete"
        Me.btnLoginDelete.Size = New System.Drawing.Size(135, 23)
        Me.btnLoginDelete.TabIndex = 22
        Me.btnLoginDelete.Text = "Delete Login"
        Me.btnLoginDelete.UseVisualStyleBackColor = True
        '
        'btnLoginClear
        '
        Me.btnLoginClear.Location = New System.Drawing.Point(156, 395)
        Me.btnLoginClear.Name = "btnLoginClear"
        Me.btnLoginClear.Size = New System.Drawing.Size(135, 23)
        Me.btnLoginClear.TabIndex = 23
        Me.btnLoginClear.Text = "Clear Fields"
        Me.btnLoginClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(156, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(135, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpDateStart
        '
        Me.dtpDateStart.CustomFormat = ""
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(15, 178)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(135, 20)
        Me.dtpDateStart.TabIndex = 6
        Me.dtpDateStart.Value = New Date(2008, 11, 30, 0, 0, 0, 0)
        '
        'dtpDateStop
        '
        Me.dtpDateStop.CustomFormat = ""
        Me.dtpDateStop.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStop.Location = New System.Drawing.Point(156, 178)
        Me.dtpDateStop.Name = "dtpDateStop"
        Me.dtpDateStop.Size = New System.Drawing.Size(135, 20)
        Me.dtpDateStop.TabIndex = 7
        Me.dtpDateStop.Value = New Date(2008, 11, 30, 0, 0, 0, 0)
        '
        'btnDateStopClear
        '
        Me.btnDateStopClear.BackgroundImage = CType(resources.GetObject("btnDateStopClear.BackgroundImage"), System.Drawing.Image)
        Me.btnDateStopClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDateStopClear.Location = New System.Drawing.Point(242, 179)
        Me.btnDateStopClear.Name = "btnDateStopClear"
        Me.btnDateStopClear.Size = New System.Drawing.Size(21, 19)
        Me.btnDateStopClear.TabIndex = 8
        Me.btnDateStopClear.UseVisualStyleBackColor = True
        '
        'frmLogins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 427)
        Me.Controls.Add(Me.btnDateStopClear)
        Me.Controls.Add(Me.txtDateStop)
        Me.Controls.Add(Me.dtpDateStop)
        Me.Controls.Add(Me.txtDateStart)
        Me.Controls.Add(Me.dtpDateStart)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnLoginClear)
        Me.Controls.Add(Me.btnLoginDelete)
        Me.Controls.Add(Me.btnLoginSave)
        Me.Controls.Add(Me.btnLoginAdd)
        Me.Controls.Add(Me.chkLoginAdd)
        Me.Controls.Add(Me.chkLoginChange)
        Me.Controls.Add(Me.chkLoginDelete)
        Me.Controls.Add(Me.chkFinanceAdd)
        Me.Controls.Add(Me.chkFinanceChange)
        Me.Controls.Add(Me.chkfinanceDelete)
        Me.Controls.Add(Me.chkSettingsAdd)
        Me.Controls.Add(Me.chkSettingsChange)
        Me.Controls.Add(Me.chkSettingsDelete)
        Me.Controls.Add(Me.chkGroupsDelete)
        Me.Controls.Add(Me.chkClientsDelete)
        Me.Controls.Add(Me.lblDateStop)
        Me.Controls.Add(Me.lblDateStart)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblLoginName)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.txtLoginName)
        Me.Controls.Add(Me.lvwLoginName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(326, 465)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(326, 465)
        Me.Name = "frmLogins"
        Me.ShowInTaskbar = False
        Me.Text = "Logins"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents lvwLoginName As System.Windows.Forms.ListView
	Friend WithEvents colLoginName As System.Windows.Forms.ColumnHeader
	Friend WithEvents txtLoginName As System.Windows.Forms.TextBox
	Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
	Friend WithEvents lblLoginName As System.Windows.Forms.Label
	Friend WithEvents lblPassword As System.Windows.Forms.Label
	Friend WithEvents txtPassword As System.Windows.Forms.TextBox
	Friend WithEvents lblDateStart As System.Windows.Forms.Label
	Friend WithEvents txtDateStop As System.Windows.Forms.TextBox
	Friend WithEvents lblDateStop As System.Windows.Forms.Label
	Friend WithEvents txtDateStart As System.Windows.Forms.TextBox
	Friend WithEvents chkClientsDelete As System.Windows.Forms.CheckBox
	Friend WithEvents chkGroupsDelete As System.Windows.Forms.CheckBox
	Friend WithEvents chkSettingsDelete As System.Windows.Forms.CheckBox
	Friend WithEvents chkSettingsChange As System.Windows.Forms.CheckBox
	Friend WithEvents chkSettingsAdd As System.Windows.Forms.CheckBox
	Friend WithEvents chkfinanceDelete As System.Windows.Forms.CheckBox
	Friend WithEvents chkFinanceChange As System.Windows.Forms.CheckBox
	Friend WithEvents chkFinanceAdd As System.Windows.Forms.CheckBox
	Friend WithEvents chkLoginDelete As System.Windows.Forms.CheckBox
	Friend WithEvents chkLoginChange As System.Windows.Forms.CheckBox
	Friend WithEvents chkLoginAdd As System.Windows.Forms.CheckBox
	Friend WithEvents btnLoginAdd As System.Windows.Forms.Button
	Friend WithEvents btnLoginSave As System.Windows.Forms.Button
	Friend WithEvents btnLoginDelete As System.Windows.Forms.Button
	Friend WithEvents btnLoginClear As System.Windows.Forms.Button
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpDateStop As System.Windows.Forms.DateTimePicker
	Friend WithEvents btnDateStopClear As System.Windows.Forms.Button
End Class
