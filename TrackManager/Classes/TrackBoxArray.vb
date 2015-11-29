Public Class TrackBoxArray
	Inherits System.Collections.CollectionBase
	Private ReadOnly HostForm As System.Windows.Forms.Form
	Private _strName As String

	Friend Function AddNewTrackBox() As TrackBox

		Dim aTrackBox As New TrackBox
		Me.List.Add(aTrackBox)
		HostForm.Controls.Add(aTrackBox)
		aTrackBox.Tag = Me.Count
		aTrackBox.Name = _strName
		AddHandler aTrackBox.Click, AddressOf ClickHandler
		AddHandler aTrackBox.DoubleClick, AddressOf DoubleClickHandler
		Return aTrackBox
	End Function

	Friend Sub New(ByVal host As System.Windows.Forms.Form, ByVal strName As String)
		HostForm = host
		_strName = strName
		Me.AddNewTrackBox()
		Me.Item(Me.Count - 1).Visible = False
	End Sub

	Default Friend ReadOnly Property Item(ByVal Index As Integer) As TrackBox
		Get
			Return CType(Me.List.Item(Index), TrackBox)
		End Get
	End Property

	Friend ReadOnly Property Name() As String
		Get
			Return _strName
		End Get
	End Property

	Friend Sub Remove()
		If Me.Count > 1 Then
			HostForm.Controls.Remove(Me(Me.List.Count - 1))
			Me.List.RemoveAt(Me.List.Count - 1)
		End If
	End Sub

	Friend Sub ClickHandler(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim intTag As Integer
		Dim intIndex As Integer
        Dim dblClientId As Double
		Dim dblGroupId As Double
		Dim intLessonTypeId As Integer
		Dim intLevelId As Integer
		Dim strCollection As String
		Dim strBackColor As String
		Dim strForeColor As String
		Dim intLessonCount As Integer
		Dim intExtraCount As Integer
		intTag = CType(CType(sender, TrackBox).Tag, String)
		intIndex = CType(CType(sender, TrackBox).IndexNumber, String)
        dblClientID = CType(CType(sender, TrackBox).ClientId, String)
		dblGroupId = CType(CType(sender, TrackBox).GroupId, String)
		intLessonTypeId = CType(CType(sender, TrackBox).LessonTypeId, String)
		intLevelId = CType(CType(sender, TrackBox).LevelId, String)
		strCollection = CType(CType(sender, TrackBox).Name, String)
		strBackColor = CType(CType(sender, TrackBox).BackColor.ToKnownColor.ToString, String)
		strForeColor = CType(CType(sender, TrackBox).ForeColor.ToKnownColor.ToString, String)
		intLessonCount = CType(CType(sender, TrackBox).LessonCount, String)
		intExtraCount = CType(CType(sender, TrackBox).ExtraCount, String)
        TrackBoxClickHandler(intTag, intIndex, dblClientID, dblGroupId, intLessonTypeId, intLevelId, strCollection, strBackColor, strForeColor, intLessonCount, intExtraCount)
	End Sub

	Friend Sub DoubleClickHandler(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim intTag As Integer
		Dim intIndex As Integer
        Dim dblClientId As Double
        Dim dblGroupId As Double
        Dim intLessonTypeId As Integer
        Dim intLevelId As Integer
        Dim strCollection As String
		Dim clrBackColor As System.Drawing.Color
		Dim clrForeColor As System.Drawing.Color
        Dim intLessonCount As Integer
        Dim intExtraCount As Integer
        intTag = CType(CType(sender, TrackBox).Tag, String)
		intIndex = CType(CType(sender, TrackBox).IndexNumber, String)
        dblClientID = CType(CType(sender, TrackBox).ClientId, String)
        dblGroupId = CType(CType(sender, TrackBox).GroupId, String)
        intLessonTypeId = CType(CType(sender, TrackBox).LessonTypeId, String)
        intLevelId = CType(CType(sender, TrackBox).LevelId, String)
        strCollection = CType(CType(sender, TrackBox).Name, String)
		clrBackColor = CType(CType(sender, TrackBox).BackColor, System.Drawing.Color)
		clrForeColor = CType(CType(sender, TrackBox).ForeColor, System.Drawing.Color)
        intLessonCount = CType(CType(sender, TrackBox).LessonCount, String)
        intExtraCount = CType(CType(sender, TrackBox).ExtraCount, String)
        TrackBoxDoubleClickHandler(intTag, intIndex, dblClientID, dblGroupId, intLessonTypeId, intLevelId, strCollection, clrBackColor, clrForeColor, intLessonCount, intExtraCount)
	End Sub

End Class
