CREATE PROCEDURE [dbo].[usp_AppointmentCreate]
	@AppDate smalldatetime = NULL,
	@AppType nvarchar(20) = NULL,
	@ClientId int = 0,
	@TrackId int = 0,
	@TrackIndex int = 0,
	@LessonTypeId int = 0,
	@LevelId int = 0,
	@LessonCount int = 0,
	@ExtraCount int = 0,
	@loginId int = 0,
	@lastAction int = NULL

AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial version
-- 1.1		2013-07-08	BT		Added TrackIndex		
-- 2.0		2013-09-23	BT		Added check for correct level
-- ****************************************************************************

DECLARE @PreviousCount int,
		@maxCount int,
		@DoubleBooking int,
		@NextLevel int,
		@LastLevel int

SELECT @DoubleBooking = COUNT(*)
FROM [dbo].[tbl_Appointment]
WHERE [AppDate] = @AppDate
	AND [FK_TrackID] = @TrackId
	AND TrackIndex = @TrackIndex

IF @DoubleBooking > 0 
	BEGIN
		SET @TrackIndex = 0
	END

SELECT @PreviousCount = isnull(max([LessonCount]),0)
  FROM [dbo].[tbl_Appointment]
 WHERE [FK_ClientId] = @ClientId
   AND [FK_LessonTypeId] = @LessonTypeId
   AND [AppDate] = (SELECT max([AppDate]) 
					FROM [dbo].[tbl_Appointment] 
					WHERE [AppDate] < @AppDate
					AND [FK_ClientId] = @ClientId
					AND [FK_LessonTypeId] = @LessonTypeId
					AND [Active] = 1)

SELECT @MaxCount = isnull(max([LessonCount]),0)
  FROM [dbo].[tbl_Appointment]
 WHERE [FK_ClientId] = @ClientId
   AND [FK_LessonTypeId] = @LessonTypeId
   AND [Active] = 1

SELECT @NextLevel = [FK_LevelId]
FROM [dbo].[tbl_Appointment]
WHERE [FK_ClientId] = @ClientId
	AND [FK_LessonTypeId] = @LessonTypeId
	AND [AppDate] = (SELECT min([AppDate]) 
					FROM [dbo].[tbl_Appointment]
					WHERE [FK_ClientId] = @ClientId
						AND [FK_LessonTypeId] = @LessonTypeId
						AND [AppDate] > @AppDate)

SELECT @LastLevel = [FK_LevelID]
FROM [dbo].[tbl_ClientLevels]
WHERE [Active] = 1
	AND [FK_ClientID] = @ClientId
	AND [FK_LessonTypeID] = @LessonTypeId

SELECT @LevelId = COALESCE(@NextLevel,@LastLevel,@LevelId)

IF @PreviousCount = @MaxCount
	BEGIN
		SET @LessonCount = @MaxCount + 1
		--EXEC dbo.usp_AppointmentHandle 'Ins',0,@AppDate,@AppType,@ClientId,@TrackId,@LessonTypeId,@LevelId,@LessonCount,@ExtraCount,@LoginId
		EXECUTE [dbo].[usp_AppointmentHandle] 
		   'Ins'
		  ,0
		  ,@AppDate
		  ,@AppType
		  ,@ClientId
		  ,@TrackId
		  ,@TrackIndex
		  ,@LessonTypeId
		  ,@LevelId
		  ,@LessonCount
		  ,@ExtraCount
		  ,@loginId
		  ,1
	END
ELSE
	BEGIN
		SET @LessonCount = @PreviousCount + 1
		--EXEC dbo.usp_AppointmentHandle 'Ins',0,@AppDate,@AppType,@ClientId,@TrackId,@LessonTypeId,@LevelId,@LessonCount,@ExtraCount,@LoginId
		EXECUTE [dbo].[usp_AppointmentHandle] 
		   'Ins'
		  ,0
		  ,@AppDate
		  ,@AppType
		  ,@ClientId
		  ,@TrackId
		  ,@TrackIndex
		  ,@LessonTypeId
		  ,@LevelId
		  ,@LessonCount
		  ,@ExtraCount
		  ,@loginId
		  ,1

		UPDATE [dbo].[tbl_Appointment]
		   SET [LessonCount] = [LessonCount] + 1
			  ,[ExtraCount] = @ExtraCount
			  ,[FK_LoginId] = @LoginId
		 WHERE [AppDate] > @AppDate
		   AND [FK_ClientId] = @ClientId
		   AND [FK_LessonTypeId] = @LessonTypeId
		   AND [Active] = 1
	END
	
SELECT @LessonCount = isnull(max([LessonCount]),0) + 1
FROM dbo.[tbl_ClientLevels]
WHERE [FK_ClientId] = @ClientId
	AND [FK_LessonTypeId] = @LessonTypeId
	AND [Active] = 1

SELECT @LevelId = COALESCE(@LastLevel,@NextLevel,@LevelId)
EXEC dbo.usp_ClientLessonHandle 'Smt',0,@ClientId,0,@LessonTypeId,@LevelId,@LessonCount,@ExtraCount,1,@LastAction
;

