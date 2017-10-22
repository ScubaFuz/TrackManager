Public Class frmAppointmentChange

    Private Sub AppointmentChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClientSelect()
        ClientMemoSelect()
        GroupSelect()
        DateSelect()
        TimeSelect()
        TracksGet()
        TrackSelect()
        TrackIndexGet()
        TrackIndexSelect()
        LessonTypesGet()
        LessonTypesSelect()
        LevelsGet()
        LevelSelect()
        ExtraCountSelect()
        SetOptions()
        SetLanguage(Me)
    End Sub

    Private Sub ClientSelect()
        txtClient.Tag = CurStatus.ClientID
        txtClient.Text = ClientNameGet(CurStatus.ClientID)
    End Sub

    Private Sub ClientMemoSelect()
        'txtClient.Tag = CurStatus.ClientID
        txtRemarks.Text = ClientMemoGet(CurStatus.ClientID)
    End Sub

    Private Sub GroupSelect()
        txtGroup.Tag = CurStatus.GroupID
        txtGroup.Text = GroupNameGet(CurStatus.GroupID)
    End Sub

    Private Sub DateSelect()
        dtpAppDate.Value = CurApp.Day
    End Sub

    Private Sub TimeSelect()
        txtHour.Text = Format(CurApp.Day.Hour, "00")
        txtMinute.Text = Format(CurApp.Day.Minute, "00")
    End Sub

    Private Sub TracksGet()
        cbxTrack.Items.Clear()
        cbxTrack.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim objData As DataSet
        objData = TracksHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_TrackId")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("TrackName")
                cbxTrack.Items.Add(lsvItem)
            End If
        Next

    End Sub

    Private Sub TrackSelect()
        For i = 0 To cbxTrack.Items.Count - 1
            If Val(DirectCast(cbxTrack.Items(i), ListViewItem).Tag) = CurStatus.TrackID Then
                cbxTrack.SelectedItem = cbxTrack.Items(i)
                Exit Sub
            End If
        Next
        'Dim x As Integer = Val(DirectCast(cbxTrack.SelectedItem, ListViewItem).Tag)
    End Sub

    Private Sub TrackIndexGet()
        For i = 1 To CurVar.ClientsPerTrack
            cbxTrackIndex.Items.Add(i)
        Next
    End Sub

    Private Sub TrackIndexSelect()
        For Each Client In CurApp.Clients
            If Client.ID = CurStatus.ClientID Then
                cbxTrackIndex.SelectedItem = Client.TrackIndex
            End If
        Next
    End Sub

    Private Sub LessonTypesGet()
        cbxLessonType.Items.Clear()
        cbxLessonType.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim objData As DataSet
        objData = LessonTypesHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LessonTypeID")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LessonTypeName")
                cbxLessonType.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub LessonTypesSelect()
        For Each Client In CurApp.Clients
            If Client.ID = CurStatus.ClientID Then
                For i = 0 To cbxLessonType.Items.Count - 1
                    If Val(DirectCast(cbxLessonType.Items(i), ListViewItem).Tag) = Client.LessonTypeID Then
                        cbxLessonType.SelectedItem = cbxLessonType.Items(i)
                        Exit Sub
                    End If
                Next
                'Exit Sub
            End If
        Next
    End Sub

    Private Sub LevelsGet()
        cbxLevel.Items.Clear()
        cbxLevel.DisplayMember = "Text" 'Make sure the Text property is used to display the item
        Dim objData As DataSet
        objData = LevelsHandle("Get")
        For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
            If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
                'MessageBox.Show("Cell Must be empty")
            Else
                Dim lsvItem As New ListViewItem
                lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_LevelID")
                lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("LevelName")
                cbxLevel.Items.Add(lsvItem)
            End If
        Next
    End Sub

    Private Sub LevelSelect()
        For Each Client In CurApp.Clients
            If Client.ID = CurStatus.ClientID Then
                For i = 0 To cbxLevel.Items.Count - 1
                    If Val(DirectCast(cbxLevel.Items(i), ListViewItem).Tag) = Client.LevelID Then
                        cbxLevel.SelectedItem = cbxLevel.Items(i)
                        Exit Sub
                    End If
                Next
                'Exit Sub
            End If
        Next
    End Sub

    Private Sub ExtraCountSelect()
        For Each Client In CurApp.Clients
            If Client.ID = CurStatus.ClientID Then
                txtExtraCount.Tag = Client.LessonCount
                txtExtraCount.Text = Client.ExtraCount
                'Exit Sub
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub SetOptions()
        If cbxLessonType.SelectedIndex = -1 Then
            cbxLessonType.Enabled = True
            dtpAppDate.Enabled = False
            txtHour.Enabled = False
            txtMinute.Enabled = False
            cbxTrack.Enabled = False
            cbxTrackIndex.Enabled = False
            cbxLevel.Enabled = False
            txtExtraCount.Enabled = False
            chkUpdateFutureLevel.Enabled = False
            chkUpdateFutureLevel.Checked = False
        End If
    End Sub

    Private Sub btnSaveAppointment_Click(sender As Object, e As EventArgs) Handles btnSaveAppointment.Click
        dtpAppDate.Value = dtpAppDate.Value.Date
        dtpAppDate.Value = dtpAppDate.Value.AddHours(txtHour.Text)
        dtpAppDate.Value = dtpAppDate.Value.AddMinutes(txtMinute.Text)
        Dim strAppType As String = CurApp.Name.Replace("BoxArray", "")
        strAppType = strAppType.Replace("Client", "Track")

        'Check all selected items
        'MessageBox.Show("cbxTrack.SelectedItem = " & cbxTrack.SelectedItem.ToString & vbCrLf & _
        '        "CurApp.TrackId = " & CurApp.TrackId & vbCrLf & _
        '        "cbxTrackIndex.SelectedItem = " & cbxTrackIndex.SelectedIndex & vbCrLf & _
        '        "cbxLessonType.SelectedItem = " & cbxLessonType.SelectedIndex & vbCrLf & _
        '        "cbxLevel.SelectedItem = " & cbxLevel.SelectedIndex & vbCrLf & _
        '        "txtExtraCount.Tag = " & txtExtraCount.Tag & vbCrLf & _
        '        "txtExtraCount.Text = " & txtExtraCount.Text)

        If cbxLessonType.Enabled = True Then
            If cbxLessonType.SelectedIndex = -1 Then
                MessageBox.Show(lanStrings.strAllData, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            AppointmentsHandle("Upd", 0, CurApp.Day, strAppType, CurStatus.ClientID, CurApp.TrackId, CurApp.TrackIndex, Val(DirectCast(cbxLessonType.SelectedItem, ListViewItem).Tag), Val(DirectCast(cbxLevel.SelectedItem, ListViewItem).Tag), txtExtraCount.Tag, txtExtraCount.Text, CurUser.LoginID)
        Else
            AppointmentMove(dtpAppDate.Value, CurApp.Day, strAppType, CurStatus.ClientID, Val(DirectCast(cbxTrack.SelectedItem, ListViewItem).Tag), CurApp.TrackId, cbxTrackIndex.SelectedItem, CurApp.TrackIndex, Val(DirectCast(cbxLessonType.SelectedItem, ListViewItem).Tag), Val(DirectCast(cbxLevel.SelectedItem, ListViewItem).Tag), txtExtraCount.Tag, txtExtraCount.Text, CurUser.LoginID)
            For Each AppClient In CurApp.Clients
                If AppClient.ID = CurStatus.ClientID Then
                    AppClient.LessonTypeID = Val(DirectCast(cbxLessonType.SelectedItem, ListViewItem).Tag)
                    AppClient.LessonTypeName = LessonTypeNameGet(AppClient.LessonTypeID)
                    AppClient.LevelID = Val(DirectCast(cbxLevel.SelectedItem, ListViewItem).Tag)
                    AppClient.LevelName = LevelNameGet(AppClient.LevelID)
                    AppClient.TrackIndex = cbxTrackIndex.SelectedItem
                    AppClient.LessonCount = txtExtraCount.Tag
                    AppClient.ExtraCount = txtExtraCount.Text
                    Exit For
                End If
            Next
            If chkUpdateFutureLevel.Checked = True Then
                AppointmentUpdate(dtpAppDate.Value, CurStatus.ClientID, Val(DirectCast(cbxLessonType.SelectedItem, ListViewItem).Tag), Val(DirectCast(cbxLevel.SelectedItem, ListViewItem).Tag))
            End If
        End If
        CurStatus.ReloadDay = True
        Me.Dispose()
    End Sub

    Private Sub btnSaveMemo_Click(sender As Object, e As EventArgs) Handles btnSaveMemo.Click
        Dim strRemarks As String = txtRemarks.Text
        If strRemarks.Length = 0 Then strRemarks = " "
        ClientsHandle("Upd", CurStatus.GroupID, CurStatus.ClientID, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, txtRemarks.Text)
    End Sub

    Private Sub btnRevertMemo_Click(sender As Object, e As EventArgs) Handles btnRevertMemo.Click
        ClientMemoSelect()
    End Sub
End Class