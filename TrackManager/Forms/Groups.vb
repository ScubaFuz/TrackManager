Public Class frmGroups
	Private Sub Groups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		SecuritySet()
		AddHandler Me.lvwGroups.ColumnClick, AddressOf listView_ColumnClick
		lvwGroups.Columns.Add(New ColHeader("Group Name", "colGroupName", 100, HorizontalAlignment.Left, True))
		lvwGroups.Columns.Add(New ColHeader("Group Number", "colGroupNumber", 100, HorizontalAlignment.Left, True))
		GroupsGet()
		SetLanguage(Me)

        If Not CurStatus.GroupID = 0 Then
            'txtGroupId.Text = FormatGroupNumber(Now)
            'txtGroupId.Text = CurStatus.GroupID
            'txtGroupName.Text = GroupNameGet(CurStatus.GroupID)
            Try
                GroupSelect(CurStatus.GroupID)
            Catch ex As Exception
                WriteLog(ex.Message, 1)
                MessageBox.Show(lanStrings.strGeneralError & vbCrLf & lanStrings.strCheckLog)
            End Try
        End If

	End Sub

	Private Sub GroupsGet()
		lvwGroups.Items.Clear()
		Dim objData As DataSet
		objData = GroupsHandle("Get")
		lvwGroups.BeginUpdate()
		For intRowCount = 0 To objData.Tables(0).Rows.Count - 1
			If objData.Tables.Item(0).Rows(intRowCount).Item(0).GetType().ToString = "System.DBNull" Then
				'MessageBox.Show("Cell Must be empty")
			Else
				Dim lsvItem As New ListViewItem
				lsvItem.Tag = objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId")
				lsvItem.Text = objData.Tables.Item(0).Rows(intRowCount).Item("GroupName")
				lsvItem.SubItems.Add(objData.Tables.Item(0).Rows(intRowCount).Item("PK_GroupId"))
				lvwGroups.Items.Add(lsvItem)
			End If
		Next
		lvwGroups.EndUpdate()
		GroupSelect(CurStatus.GroupID)
	End Sub

	Private Sub GroupSelect(ByVal dblGroupId)
		If dblGroupId > 0 Then
			For Each item As ListViewItem In lvwGroups.Items
				item.Selected = (CDbl(item.Tag) = dblGroupId)
			Next
			lvwGroups.TopItem = lvwGroups.SelectedItems.Item(0)
			lvwGroups.Select()
		End If
	End Sub

	Private Sub GroupAdd(ByVal dblGroupID As Double, ByVal strGroupName As String)
		Dim lsvItem As New ListViewItem
		lsvItem.Tag = dblGroupID
		lsvItem.Text = strGroupName
		lsvItem.SubItems.Add(dblGroupID)
		lvwGroups.Items.Add(lsvItem)
	End Sub

	Private Sub GroupUpdate(ByVal dblGroupID As Double, ByVal strGroupName As String)
		For intCount As Integer = 0 To lvwGroups.Items.Count - 1
			If lvwGroups.Items(intCount).Tag = dblGroupID Then
				lvwGroups.Items(intCount).Text = strGroupName
				Exit Sub
			End If
		Next
	End Sub

	Private Sub GroupRemove(ByVal dblGroupID As Double)
		For intCount As Integer = 0 To lvwGroups.Items.Count - 1
			If lvwGroups.Items(intCount).Tag = dblGroupID Then
				lvwGroups.Items(intCount).Remove()
				Exit Sub
			End If
		Next
	End Sub

	Private Sub listView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

		' Create an instance of the ColHeader class. 
		Dim clickedCol As ColHeader = CType(Me.lvwGroups.Columns(e.Column), ColHeader)

		' Set the ascending property to sort in the opposite order.
		clickedCol.ascending = Not clickedCol.ascending

		' Get the number of items in the list.
		Dim numItems As Integer = Me.lvwGroups.Items.Count

		' Turn off display while data is repoplulated.
		Me.lvwGroups.BeginUpdate()

		' Populate an ArrayList with a SortWrapper of each list item.
		Dim SortArray As New ArrayList
		Dim i As Integer
		For i = 0 To numItems - 1
			SortArray.Add(New SortWrapper(Me.lvwGroups.Items(i), e.Column))
		Next i

		' Sort the elements in the ArrayList using a new instance of the SortComparer
		' class. The parameters are the starting index, the length of the range to sort,
		' and the IComparer implementation to use for comparing elements. Note that
		' the IComparer implementation (SortComparer) requires the sort  
		' direction for its constructor; true if ascending, othwise false.
		SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

		' Clear the list, and repopulate with the sorted items.
		Me.lvwGroups.Items.Clear()
		Dim z As Integer
		For z = 0 To numItems - 1
			Me.lvwGroups.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
		Next z
		' Turn display back on.
		Me.lvwGroups.EndUpdate()
	End Sub

	Private Sub btnEditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditGroup.Click
		EditGroup()
	End Sub

	Private Sub btnDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteGroup.Click
		If lvwGroups.SelectedItems.Count = 1 Then
			Dim objData As DataSet
			objData = ClientsHandle("Get", lvwGroups.SelectedItems.Item(0).Tag)
			If objData.Tables(0).Rows.Count > 0 Then
				MessageBox.Show(lanStrings.strGroupNotEmpty, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Exit Sub
			End If

			If MessageBox.Show(lanStrings.strPermanentDelete & vbCrLf & lanStrings.strContinue, lanStrings.strWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
				Try
					GroupsHandle("Del", lvwGroups.SelectedItems.Item(0).Tag)
					frmTrackManager.GroupRemove(lvwGroups.SelectedItems.Item(0).Tag)
					GroupRemove(lvwGroups.SelectedItems.Item(0).Tag)
					'ClearGroup()
					CurStatus.GroupID = 0
					'GroupsGet()
					'CurStatus.ReloadGroups = True
				Catch ex As Exception
					WriteLog(ex.Message, 1)
					MessageBox.Show(lanStrings.strGeneralError & vbCrLf & lanStrings.strCheckLog)
				End Try
			End If
		ElseIf lvwGroups.SelectedItems.Count > 1 Then
			MessageBox.Show(lanStrings.strDelete1, lanStrings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End If
	End Sub

	Private Sub btnAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGroup.Click
		If txtGroupName.Tag > 0 Then
			'Update mode
			If txtGroupName.Text.Length > 0 Then
				CurStatus.GroupID = txtGroupName.Tag
				GroupsHandle("Upd", CurStatus.GroupID, txtGroupName.Text)
				GroupUpdate(CurStatus.GroupID, txtGroupName.Text)
				frmTrackManager.GroupUpdate(CurStatus.GroupID, txtGroupName.Text)
				'ClearGroup()
				'CurStatus.ReloadGroups = True
				'GroupsGet()
				GroupSelect(CurStatus.GroupID)
				EditGroup()
			Else
				MessageBox.Show(lanStrings.strAllData)
			End If
		Else
			'Add mode
            If txtGroupName.Text.Length > 0 Then
                If Not txtGroupId.Text.Length > 0 Then
                    txtGroupId.Text = FormatGroupNumber(Now)
                End If
                CurStatus.GroupID = txtGroupId.Text
                GroupsHandle("Add", CurStatus.GroupID, txtGroupName.Text)
                GroupAdd(CurStatus.GroupID, txtGroupName.Text)
                frmTrackManager.GroupAdd(CurStatus.GroupID, txtGroupName.Text)
                'ClearGroup()
                'CurStatus.ReloadGroups = True
                'GroupsGet()
                GroupSelect(CurStatus.GroupID)
                EditGroup()
            Else
                MessageBox.Show(lanStrings.strAllData)
            End If
		End If
	End Sub

	Private Sub btnClearGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearGroup.Click
		ClearGroup()
	End Sub

	Private Sub EditGroup()
		If lvwGroups.SelectedItems.Count = 1 Then
			txtGroupName.Tag = lvwGroups.SelectedItems.Item(0).Tag
			txtGroupName.Text = lvwGroups.SelectedItems.Item(0).Text
			txtGroupId.Text = lvwGroups.SelectedItems.Item(0).SubItems.Item(1).Text
			btnAddGroup.Text = lanStrings.strUpdate
		End If
	End Sub

	Private Sub ClearGroup()
		txtGroupName.Tag = 0
		txtGroupName.Text = ""
        txtGroupId.Text = ""
		btnAddGroup.Text = lanStrings.strAdd
	End Sub

	Private Sub lsvGroups_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwGroups.DoubleClick
		EditGroup()
	End Sub

	Private Sub lsvGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwGroups.SelectedIndexChanged
		If lvwGroups.SelectedItems.Count = 1 Then
			CurStatus.GroupID = lvwGroups.SelectedItems.Item(0).Tag
			CurStatus.ClientID = 0
			CurStatus.RefreshGroup = True
		End If
	End Sub

	Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
		Me.Dispose()
	End Sub

	Private Sub SecuritySet()
		btnDeleteGroup.Enabled = False
		If CurUser.GroupsDelete Then btnDeleteGroup.Enabled = True
	End Sub

    Private Sub txtGroupSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGroupSearch.TextChanged
        ' Call FindItemWithText with the contents of the textbox. 
        Dim foundItem As ListViewItem = _
            lvwGroups.FindItemWithText(txtGroupSearch.Text, False, 0, True)

        If (foundItem IsNot Nothing) Then
            lvwGroups.TopItem = foundItem
        End If

    End Sub


End Class