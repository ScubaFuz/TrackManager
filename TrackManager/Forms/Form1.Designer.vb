<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Me.wbrExport = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbrExport
        '
        Me.wbrExport.Location = New System.Drawing.Point(272, 188)
        Me.wbrExport.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrExport.Name = "wbrExport"
        Me.wbrExport.Size = New System.Drawing.Size(250, 250)
        Me.wbrExport.TabIndex = 0
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 633)
        Me.Controls.Add(Me.wbrExport)
        Me.Name = "frmExport"
        Me.Text = "Export"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbrExport As System.Windows.Forms.WebBrowser
End Class
