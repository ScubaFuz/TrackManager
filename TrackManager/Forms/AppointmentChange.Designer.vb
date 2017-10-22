<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppointmentChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppointmentChange))
        Me.btnSaveAppointment = New System.Windows.Forms.Button()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.cbxTrack = New System.Windows.Forms.ComboBox()
        Me.txtGroup = New System.Windows.Forms.TextBox()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lbltrack = New System.Windows.Forms.Label()
        Me.lblLessonType = New System.Windows.Forms.Label()
        Me.cbxLessonType = New System.Windows.Forms.ComboBox()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.cbxLevel = New System.Windows.Forms.ComboBox()
        Me.dtpAppDate = New System.Windows.Forms.DateTimePicker()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTrackIndex = New System.Windows.Forms.Label()
        Me.cbxTrackIndex = New System.Windows.Forms.ComboBox()
        Me.lblExtraCount = New System.Windows.Forms.Label()
        Me.txtExtraCount = New System.Windows.Forms.TextBox()
        Me.chkUpdateFutureLevel = New System.Windows.Forms.CheckBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.txtHour = New System.Windows.Forms.TextBox()
        Me.txtMinute = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSaveMemo = New System.Windows.Forms.Button()
        Me.btnRevertMemo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSaveAppointment
        '
        Me.btnSaveAppointment.Location = New System.Drawing.Point(180, 309)
        Me.btnSaveAppointment.Name = "btnSaveAppointment"
        Me.btnSaveAppointment.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAppointment.TabIndex = 0
        Me.btnSaveAppointment.Text = "Save"
        Me.btnSaveAppointment.UseVisualStyleBackColor = True
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Location = New System.Drawing.Point(29, 30)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(33, 13)
        Me.lblClient.TabIndex = 1
        Me.lblClient.Text = "Client"
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(157, 27)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ReadOnly = True
        Me.txtClient.Size = New System.Drawing.Size(200, 20)
        Me.txtClient.TabIndex = 2
        '
        'cbxTrack
        '
        Me.cbxTrack.FormattingEnabled = True
        Me.cbxTrack.Location = New System.Drawing.Point(157, 135)
        Me.cbxTrack.Name = "cbxTrack"
        Me.cbxTrack.Size = New System.Drawing.Size(200, 21)
        Me.cbxTrack.TabIndex = 3
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(157, 54)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.ReadOnly = True
        Me.txtGroup.Size = New System.Drawing.Size(200, 20)
        Me.txtGroup.TabIndex = 5
        '
        'lblGroup
        '
        Me.lblGroup.AutoSize = True
        Me.lblGroup.Location = New System.Drawing.Point(29, 58)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(36, 13)
        Me.lblGroup.TabIndex = 4
        Me.lblGroup.Text = "Group"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(29, 86)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Date"
        '
        'lbltrack
        '
        Me.lbltrack.AutoSize = True
        Me.lbltrack.Location = New System.Drawing.Point(29, 142)
        Me.lbltrack.Name = "lbltrack"
        Me.lbltrack.Size = New System.Drawing.Size(35, 13)
        Me.lbltrack.TabIndex = 8
        Me.lbltrack.Text = "Track"
        '
        'lblLessonType
        '
        Me.lblLessonType.AutoSize = True
        Me.lblLessonType.Location = New System.Drawing.Point(29, 198)
        Me.lblLessonType.Name = "lblLessonType"
        Me.lblLessonType.Size = New System.Drawing.Size(65, 13)
        Me.lblLessonType.TabIndex = 10
        Me.lblLessonType.Text = "LessonType"
        '
        'cbxLessonType
        '
        Me.cbxLessonType.Enabled = False
        Me.cbxLessonType.FormattingEnabled = True
        Me.cbxLessonType.Location = New System.Drawing.Point(157, 191)
        Me.cbxLessonType.Name = "cbxLessonType"
        Me.cbxLessonType.Size = New System.Drawing.Size(200, 21)
        Me.cbxLessonType.TabIndex = 9
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(29, 226)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(33, 13)
        Me.lblLevel.TabIndex = 12
        Me.lblLevel.Text = "Level"
        '
        'cbxLevel
        '
        Me.cbxLevel.FormattingEnabled = True
        Me.cbxLevel.Location = New System.Drawing.Point(157, 219)
        Me.cbxLevel.Name = "cbxLevel"
        Me.cbxLevel.Size = New System.Drawing.Size(200, 21)
        Me.cbxLevel.TabIndex = 11
        '
        'dtpAppDate
        '
        Me.dtpAppDate.Location = New System.Drawing.Point(157, 81)
        Me.dtpAppDate.Name = "dtpAppDate"
        Me.dtpAppDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpAppDate.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(282, 309)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblTrackIndex
        '
        Me.lblTrackIndex.AutoSize = True
        Me.lblTrackIndex.Location = New System.Drawing.Point(29, 170)
        Me.lblTrackIndex.Name = "lblTrackIndex"
        Me.lblTrackIndex.Size = New System.Drawing.Size(64, 13)
        Me.lblTrackIndex.TabIndex = 16
        Me.lblTrackIndex.Text = "Track Index"
        '
        'cbxTrackIndex
        '
        Me.cbxTrackIndex.FormattingEnabled = True
        Me.cbxTrackIndex.Location = New System.Drawing.Point(157, 163)
        Me.cbxTrackIndex.Name = "cbxTrackIndex"
        Me.cbxTrackIndex.Size = New System.Drawing.Size(84, 21)
        Me.cbxTrackIndex.TabIndex = 15
        '
        'lblExtraCount
        '
        Me.lblExtraCount.AutoSize = True
        Me.lblExtraCount.Location = New System.Drawing.Point(29, 254)
        Me.lblExtraCount.Name = "lblExtraCount"
        Me.lblExtraCount.Size = New System.Drawing.Size(91, 13)
        Me.lblExtraCount.TabIndex = 17
        Me.lblExtraCount.Text = "Extra Level Count"
        '
        'txtExtraCount
        '
        Me.txtExtraCount.Location = New System.Drawing.Point(157, 247)
        Me.txtExtraCount.Name = "txtExtraCount"
        Me.txtExtraCount.Size = New System.Drawing.Size(84, 20)
        Me.txtExtraCount.TabIndex = 18
        '
        'chkUpdateFutureLevel
        '
        Me.chkUpdateFutureLevel.AutoSize = True
        Me.chkUpdateFutureLevel.Checked = True
        Me.chkUpdateFutureLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdateFutureLevel.Location = New System.Drawing.Point(32, 282)
        Me.chkUpdateFutureLevel.Name = "chkUpdateFutureLevel"
        Me.chkUpdateFutureLevel.Size = New System.Drawing.Size(260, 17)
        Me.chkUpdateFutureLevel.TabIndex = 19
        Me.chkUpdateFutureLevel.Text = "Update the Level of all similar future appointments"
        Me.chkUpdateFutureLevel.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(29, 114)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(30, 13)
        Me.lblTime.TabIndex = 20
        Me.lblTime.Text = "Time"
        '
        'txtHour
        '
        Me.txtHour.Location = New System.Drawing.Point(157, 109)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(39, 20)
        Me.txtHour.TabIndex = 21
        '
        'txtMinute
        '
        Me.txtMinute.Location = New System.Drawing.Point(202, 109)
        Me.txtMinute.Name = "txtMinute"
        Me.txtMinute.Size = New System.Drawing.Size(39, 20)
        Me.txtMinute.TabIndex = 22
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(29, 341)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 70
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(30, 364)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(327, 67)
        Me.txtRemarks.TabIndex = 69
        Me.txtRemarks.Tag = "0"
        '
        'btnSaveMemo
        '
        Me.btnSaveMemo.Location = New System.Drawing.Point(180, 437)
        Me.btnSaveMemo.Name = "btnSaveMemo"
        Me.btnSaveMemo.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveMemo.TabIndex = 71
        Me.btnSaveMemo.Text = "Save"
        Me.btnSaveMemo.UseVisualStyleBackColor = True
        '
        'btnRevertMemo
        '
        Me.btnRevertMemo.Location = New System.Drawing.Point(282, 437)
        Me.btnRevertMemo.Name = "btnRevertMemo"
        Me.btnRevertMemo.Size = New System.Drawing.Size(75, 23)
        Me.btnRevertMemo.TabIndex = 72
        Me.btnRevertMemo.Text = "Revert"
        Me.btnRevertMemo.UseVisualStyleBackColor = True
        '
        'frmAppointmentChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 482)
        Me.Controls.Add(Me.btnRevertMemo)
        Me.Controls.Add(Me.btnSaveMemo)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtMinute)
        Me.Controls.Add(Me.txtHour)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.chkUpdateFutureLevel)
        Me.Controls.Add(Me.txtExtraCount)
        Me.Controls.Add(Me.lblExtraCount)
        Me.Controls.Add(Me.lblTrackIndex)
        Me.Controls.Add(Me.cbxTrackIndex)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dtpAppDate)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.cbxLevel)
        Me.Controls.Add(Me.lblLessonType)
        Me.Controls.Add(Me.cbxLessonType)
        Me.Controls.Add(Me.lbltrack)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.lblGroup)
        Me.Controls.Add(Me.cbxTrack)
        Me.Controls.Add(Me.txtClient)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.btnSaveAppointment)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAppointmentChange"
        Me.Text = "Change Appointment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveAppointment As System.Windows.Forms.Button
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents txtClient As System.Windows.Forms.TextBox
    Friend WithEvents cbxTrack As System.Windows.Forms.ComboBox
    Friend WithEvents txtGroup As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lbltrack As System.Windows.Forms.Label
    Friend WithEvents lblLessonType As System.Windows.Forms.Label
    Friend WithEvents cbxLessonType As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents cbxLevel As System.Windows.Forms.ComboBox
    Friend WithEvents dtpAppDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblTrackIndex As System.Windows.Forms.Label
    Friend WithEvents cbxTrackIndex As System.Windows.Forms.ComboBox
    Friend WithEvents lblExtraCount As System.Windows.Forms.Label
    Friend WithEvents txtExtraCount As System.Windows.Forms.TextBox
    Friend WithEvents chkUpdateFutureLevel As System.Windows.Forms.CheckBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents txtHour As System.Windows.Forms.TextBox
    Friend WithEvents txtMinute As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents btnSaveMemo As Button
    Friend WithEvents btnRevertMemo As Button
End Class
