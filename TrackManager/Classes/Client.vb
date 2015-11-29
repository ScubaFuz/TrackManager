Public Class Client
	Private _Name As String = Nothing
	Private _ID As Double = 0
    Private _Checked As Boolean = True

	Private _GroupID As Double = 0
	Private _GroupName As String = Nothing

	Private _LessonTypeID As Integer = 0
	Private _LessonTypeName As String = Nothing
	Private _LessonTypeColor As System.Drawing.Color = Nothing
	Private _LessonTypeColorStr As String = Nothing
	Private _LessonCount As Integer = 0
	Private _ExtraCount As Integer = 0

	Private _LevelID As Integer = 0
	Private _LevelName As String = Nothing
	Private _LevelColor As System.Drawing.Color = Nothing
    Private _LevelColorStr As String = Nothing
    Private _TrackIndex As Integer = 0


	Public Property Name() As String
		Get
			Return _Name
		End Get
		Set(ByVal value As String)
			_Name = value
		End Set
	End Property

	Public Property ID() As Double
		Get
			Return _ID
		End Get
		Set(ByVal value As Double)
			_ID = value
		End Set
	End Property

    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
        End Set
    End Property

    Public Property GroupID() As Double
        Get
            Return _GroupID
        End Get
        Set(ByVal value As Double)
            _GroupID = value
        End Set
    End Property

	Public Property GroupName() As String
		Get
			Return _GroupName
		End Get
		Set(ByVal value As String)
			_GroupName = value
		End Set
	End Property

	Public Property LessonTypeID() As Integer
		Get
			Return _LessonTypeID
		End Get
		Set(ByVal value As Integer)
			_LessonTypeID = value
		End Set
	End Property

	Public Property LessonTypeName() As String
		Get
			Return _LessonTypeName
		End Get
		Set(ByVal value As String)
			_LessonTypeName = value
		End Set
	End Property

	Public Property LessonTypeColor() As System.Drawing.Color
		Get
			Return _LessonTypeColor
		End Get
		Set(ByVal value As System.Drawing.Color)
			_LessonTypeColor = value
		End Set
	End Property

	Public Property LessonTypeColorStr() As String
		Get
			Return _LessonTypeColorStr
		End Get
		Set(ByVal value As String)
			_LessonTypeColorStr = value
		End Set
	End Property

	Public Property LessonCount() As Integer
		Get
			Return _LessonCount
		End Get
		Set(ByVal value As Integer)
			_LessonCount = value
		End Set
	End Property

	Public Property ExtraCount() As Integer
		Get
			Return _ExtraCount
		End Get
		Set(ByVal value As Integer)
			_ExtraCount = value
		End Set
	End Property

	Public Property LevelID() As Integer
		Get
			Return _LevelID
		End Get
		Set(ByVal value As Integer)
			_LevelID = value
		End Set
	End Property

	Public Property LevelName() As String
		Get
			Return _LevelName
		End Get
		Set(ByVal value As String)
			_LevelName = value
		End Set
	End Property

	Public Property LevelColor() As System.Drawing.Color
		Get
			Return _LevelColor
		End Get
		Set(ByVal value As System.Drawing.Color)
			_LevelColor = value
		End Set
	End Property

	Public Property LevelColorStr() As String
		Get
			Return _LevelColorStr
		End Get
		Set(ByVal value As String)
			_LevelColorStr = value
		End Set
	End Property

    Public Property TrackIndex() As Integer
        Get
            Return _TrackIndex
        End Get
        Set(ByVal value As Integer)
            _TrackIndex = value
        End Set
    End Property

    Public Function Clone() As Client
        Return DirectCast(Me.MemberwiseClone(), Client)
    End Function
End Class
