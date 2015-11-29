<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblLicenseDate = New System.Windows.Forms.Label()
        Me.lblLicenseName = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCopyright.BackColor = System.Drawing.Color.Transparent
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCopyright.Location = New System.Drawing.Point(7, 255)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(300, 20)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "Copyright"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblVersion.Location = New System.Drawing.Point(7, 230)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(300, 20)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version {0}.{1:00}"
        '
        'lblLicenseDate
        '
        Me.lblLicenseDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLicenseDate.BackColor = System.Drawing.Color.Transparent
        Me.lblLicenseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseDate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblLicenseDate.Location = New System.Drawing.Point(7, 205)
        Me.lblLicenseDate.Name = "lblLicenseDate"
        Me.lblLicenseDate.Size = New System.Drawing.Size(300, 20)
        Me.lblLicenseDate.TabIndex = 4
        '
        'lblLicenseName
        '
        Me.lblLicenseName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLicenseName.BackColor = System.Drawing.Color.Transparent
        Me.lblLicenseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseName.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblLicenseName.Location = New System.Drawing.Point(7, 180)
        Me.lblLicenseName.Name = "lblLicenseName"
        Me.lblLicenseName.Size = New System.Drawing.Size(300, 20)
        Me.lblLicenseName.TabIndex = 3
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.BackgroundImage = Global.TrackManager.My.Resources.Resources.TMSplashscreen1
        Me.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMain.Controls.Add(Me.lblCopyright)
        Me.pnlMain.Controls.Add(Me.lblLicenseName)
        Me.pnlMain.Controls.Add(Me.lblVersion)
        Me.pnlMain.Controls.Add(Me.lblLicenseDate)
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(475, 285)
        Me.pnlMain.TabIndex = 5
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(470, 280)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLicenseName As System.Windows.Forms.Label
    Friend WithEvents lblLicenseDate As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

End Class
