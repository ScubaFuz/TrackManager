Public NotInheritable Class frmSplash

	Private Sub frmSplash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
		Me.Close()
	End Sub

	Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim strCore As New SecCore.SecCore

        If Not strLicenseName Is Nothing Then lblLicenseName.Text = "Licensed to: " & strLicenseName
        If Not strExpiryDate Is Nothing Then lblLicenseDate.Text = "Expiry Date: " & strExpiryDate
        lblVersion.Text = "Version: " & GetVersion("R")
        lblCopyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub pnlMain_Click(sender As Object, e As EventArgs) Handles pnlMain.Click
        Me.Close()
    End Sub

    Private Sub lblLicenseName_Click(sender As Object, e As EventArgs) Handles lblLicenseName.Click
        Me.Close()
    End Sub

    Private Sub lblLicenseDate_Click(sender As Object, e As EventArgs) Handles lblLicenseDate.Click
        Me.Close()
    End Sub

    Private Sub lblVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVersion.Click
        If TxtHandle.CheckFile(Application.StartupPath & "\Resources\TrackManager VersionLog.txt") Then
            'MessageBox.Show(TxtHandle.ReadFile(Application.StartupPath & "\Resources\TrackManager VersionLog.txt").ReadToEnd)
            System.Diagnostics.Process.Start(Application.StartupPath & "\Resources\TrackManager VersionLog.txt")
        Else
            MessageBox.Show("The Version Log was not found")
        End If
        'Me.Close()
    End Sub

    Private Sub lblCopyright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCopyright.Click
        Me.Close()
    End Sub

    Private Sub frmSplash_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        If CurVar.CallSplash = True Then
            Me.Close()
        End If
    End Sub

    'Private Sub Version_LostFocus(sender As Object, e As EventArgs) Handles Version.LostFocus
    '    If CurVar.CallSplash = True Then
    '        Me.Close()
    '    End If
    'End Sub

End Class
