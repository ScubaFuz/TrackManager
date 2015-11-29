<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroups))
        Me.btnClearGroup = New System.Windows.Forms.Button()
        Me.btnAddGroup = New System.Windows.Forms.Button()
        Me.txtGroupName = New System.Windows.Forms.TextBox()
        Me.btnDeleteGroup = New System.Windows.Forms.Button()
        Me.btnEditGroup = New System.Windows.Forms.Button()
        Me.lvwGroups = New System.Windows.Forms.ListView()
        Me.txtGroupId = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtGroupSearch = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnClearGroup
        '
        Me.btnClearGroup.Location = New System.Drawing.Point(118, 349)
        Me.btnClearGroup.Name = "btnClearGroup"
        Me.btnClearGroup.Size = New System.Drawing.Size(100, 23)
        Me.btnClearGroup.TabIndex = 7
        Me.btnClearGroup.Text = "Clear"
        Me.btnClearGroup.UseVisualStyleBackColor = True
        '
        'btnAddGroup
        '
        Me.btnAddGroup.Location = New System.Drawing.Point(12, 349)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(100, 23)
        Me.btnAddGroup.TabIndex = 6
        Me.btnAddGroup.Text = "Add"
        Me.btnAddGroup.UseVisualStyleBackColor = True
        '
        'txtGroupName
        '
        Me.txtGroupName.Location = New System.Drawing.Point(12, 324)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Size = New System.Drawing.Size(100, 20)
        Me.txtGroupName.TabIndex = 4
        Me.txtGroupName.Tag = "0"
        '
        'btnDeleteGroup
        '
        Me.btnDeleteGroup.Enabled = False
        Me.btnDeleteGroup.Location = New System.Drawing.Point(118, 286)
        Me.btnDeleteGroup.Name = "btnDeleteGroup"
        Me.btnDeleteGroup.Size = New System.Drawing.Size(100, 23)
        Me.btnDeleteGroup.TabIndex = 3
        Me.btnDeleteGroup.Text = "Delete"
        Me.btnDeleteGroup.UseVisualStyleBackColor = True
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Location = New System.Drawing.Point(12, 286)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Size = New System.Drawing.Size(100, 23)
        Me.btnEditGroup.TabIndex = 2
        Me.btnEditGroup.Text = "Edit"
        Me.btnEditGroup.UseVisualStyleBackColor = True
        '
        'lvwGroups
        '
        Me.lvwGroups.FullRowSelect = True
        Me.lvwGroups.GridLines = True
        Me.lvwGroups.HideSelection = False
        Me.lvwGroups.Location = New System.Drawing.Point(12, 70)
        Me.lvwGroups.MultiSelect = False
        Me.lvwGroups.Name = "lvwGroups"
        Me.lvwGroups.Size = New System.Drawing.Size(212, 210)
        Me.lvwGroups.TabIndex = 8
        Me.lvwGroups.UseCompatibleStateImageBehavior = False
        Me.lvwGroups.View = System.Windows.Forms.View.Details
        '
        'txtGroupId
        '
        Me.txtGroupId.Location = New System.Drawing.Point(118, 324)
        Me.txtGroupId.Name = "txtGroupId"
        Me.txtGroupId.Size = New System.Drawing.Size(100, 20)
        Me.txtGroupId.TabIndex = 5
        Me.txtGroupId.Tag = "0"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(124, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtGroupSearch
        '
        Me.txtGroupSearch.Location = New System.Drawing.Point(12, 44)
        Me.txtGroupSearch.Name = "txtGroupSearch"
        Me.txtGroupSearch.Size = New System.Drawing.Size(212, 20)
        Me.txtGroupSearch.TabIndex = 9
        '
        'frmGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 393)
        Me.Controls.Add(Me.txtGroupSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtGroupId)
        Me.Controls.Add(Me.btnClearGroup)
        Me.Controls.Add(Me.btnAddGroup)
        Me.Controls.Add(Me.txtGroupName)
        Me.Controls.Add(Me.btnDeleteGroup)
        Me.Controls.Add(Me.btnEditGroup)
        Me.Controls.Add(Me.lvwGroups)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGroups"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Groups"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClearGroup As System.Windows.Forms.Button
    Friend WithEvents btnAddGroup As System.Windows.Forms.Button
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteGroup As System.Windows.Forms.Button
    Friend WithEvents btnEditGroup As System.Windows.Forms.Button
    Friend WithEvents lvwGroups As System.Windows.Forms.ListView
    Friend WithEvents txtGroupId As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtGroupSearch As System.Windows.Forms.TextBox
End Class
