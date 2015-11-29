Public Class TrackBox
    Inherits System.Windows.Forms.TextBox
    Private _AppointmentId As Integer = 0
	Private _IndexNumber As Integer = 0
	Private _ClientId As Double = 0
	Private _GroupId As Double = 0
	Private _LessonTypeId As Integer = 0
	Private _LevelId As Integer = 0
	Private _LessonCount As Integer = 0
	Private _ExtraCount As Integer = 0

    Public Property AppointmentId() As Integer
        Get
            Return _AppointmentId
        End Get
        Set(ByVal Value As Integer)
            _AppointmentId = Value
        End Set
    End Property

    Public Property IndexNumber() As Integer
        Get
            Return _IndexNumber
        End Get
        Set(ByVal Value As Integer)
            _IndexNumber = Value
        End Set
    End Property

	Public Property ClientId() As Double
		Get
			Return _ClientId
		End Get
		Set(ByVal Value As Double)
			_ClientId = Value
		End Set
	End Property

	Public Property GroupId() As Double
		Get
			Return _GroupId
		End Get
		Set(ByVal Value As Double)
			_GroupId = Value
		End Set
	End Property

	Public Property LessonTypeId() As Integer
		Get
			Return _LessonTypeId
		End Get
		Set(ByVal Value As Integer)
			_LessonTypeId = Value
		End Set
	End Property

	Public Property LevelId() As Integer
		Get
			Return _LevelId
		End Get
		Set(ByVal Value As Integer)
			_LevelId = Value
		End Set
	End Property

	Public Property LessonCount() As Integer
		Get
			Return _LessonCount
		End Get
		Set(ByVal Value As Integer)
			_LessonCount = Value
		End Set
	End Property

	Public Property ExtraCount() As Integer
		Get
			Return _ExtraCount
		End Get
		Set(ByVal Value As Integer)
			_ExtraCount = Value
		End Set
	End Property

End Class
