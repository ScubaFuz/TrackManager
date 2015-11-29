CREATE PROCEDURE [dbo].[usp_AppointmentMove]
	@AppDateNew smalldatetime = NULL,
	@AppDateOld smalldatetime = NULL,
	@AppType nvarchar(20) = NULL,
	@ClientId int = 0,
	@TrackIdNew int = 0,
	@TrackIdOld int = 0,
	@TrackIndexNew int = 0,
	@TrackIndexOld int = 0,
	@LessonTypeId int = 0,
	@LevelId int = 0,
	@LessonCount int = 0,
	@ExtraCount int = 0,
	@LoginId int = 0,
	@LastAction int = 0
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 1.1		2013-07-08	BT		Added TrackIndex		
-- 1.2		2013-09-24	BT		Added ISNULL to be able to move Bar appointment
-- ****************************************************************************

DECLARE @AppId int
DECLARE @PreviousCount int

SELECT @AppId = isnull(max([PK_AppointmentId]),0)
  FROM [dbo].[tbl_Appointment]
 WHERE [AppDate] BETWEEN @AppDateOld AND dateadd(MINUTE, (SELECT (CAST(ConfigValue AS int)) FROM tbl_Config WHERE Category = 'ScreenView' AND ConfigName = 'TimeFrame')-1,@AppDateOld)
	AND [AppType] = @AppType
	AND [FK_ClientId] = @ClientId
	AND ISNULL([FK_TrackId],0) = @TrackIdOld
	AND ISNULL([FK_LessonTypeId],0) = @LessonTypeId
	AND [Active] = 1

SELECT @PreviousCount = isnull(max([LessonCount]),0)
  FROM [dbo].[tbl_Appointment]
 WHERE [FK_ClientId] = @ClientId
   AND ISNULL([FK_LessonTypeId],0) = @LessonTypeId
   AND [Active] = 1
   AND [AppDate] = (SELECT max([AppDate]) 
					FROM [dbo].[tbl_Appointment] 
					WHERE [AppDate] < @AppDateNew
					AND [FK_ClientId] = @ClientId
					AND [FK_LessonTypeId] = @LessonTypeId
					AND [Active] = 1)

IF @AppId > 0
	BEGIN
		IF @AppDateOld < @AppDateNew --move to future
			BEGIN
				UPDATE [dbo].[tbl_Appointment]
				   SET [LessonCount] = [LessonCount] - 1
				 WHERE [AppDate] > @AppDateOld 
				   AND [AppDate] < @AppDateNew
				   AND [FK_ClientId] = @ClientId
				   AND [FK_LessonTypeId] = @LessonTypeId
				   AND [Active] = 1
			END
		IF @AppDateOld > @AppDateNew --move to past
			BEGIN
				SET @PreviousCount = @PreviousCount + 1

				UPDATE [dbo].[tbl_Appointment]
				   SET [LessonCount] = [LessonCount] + 1
				 WHERE [AppDate] < @AppDateOld 
				   AND [AppDate] > @AppDateNew
				   AND [FK_ClientId] = @ClientId
				   AND [FK_LessonTypeId] = @LessonTypeId
				   AND [Active] = 1
			END
		IF @AppDateOld = @AppDateNew --move to different track or position at same time
			BEGIN
				SET @PreviousCount = @PreviousCount + 1
			END

		EXEC dbo.usp_AppointmentHandle @Action='Upd', 
			@AppointmentId=@AppId,
			@AppDate = @AppDateNew,
			@AppType = @AppType,
			@ClientId = @ClientId,
			@TrackId = @TrackIdNew,
			@TrackIndex = @TrackIndexNew,
			@LessonTypeId = @LessonTypeId,
			@LevelId = @LevelId,
			@LessonCount = @PreviousCount,
			@ExtraCount = @ExtraCount,
			@loginId = @LoginId

	END
;
