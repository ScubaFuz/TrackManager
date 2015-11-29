CREATE PROCEDURE [dbo].[usp_AppointmentUnDelete]
	@AppDate smalldatetime = NULL,
	@AppType nvarchar(20) = NULL,
	@ClientId int = 0,
	@TrackId int = 0,
	@TrackIndex int = 0,
	@LessonTypeId int = 0,
	@LevelId int = 0,
	@LessonCount int = 0,
	@ExtraCount int = 0,
	@LastAction int = 0
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2013-10-31	BT		Initial Version
-- ****************************************************************************

DECLARE @AppId int,@TrackInt int

SELECT @AppId = isnull(max([PK_AppointmentId]),0)
	,@TrackInt = isnull(max([TrackIndex]),0)
FROM [dbo].[tbl_Appointment]
WHERE [AppDate] BETWEEN @AppDate AND dateadd(MINUTE, (SELECT (CAST(ConfigValue AS int)) FROM tbl_Config WHERE Category = 'ScreenView' AND ConfigName = 'TimeFrame')-1,@AppDate)
	AND [AppType] = @AppType
	AND [FK_ClientId] = @ClientId
	AND isnull([FK_TrackId],0) = @TrackId
	--AND isnull([TrackIndex],@TrackIndex) = @TrackIndex
	AND [FK_LessonTypeId] = @LessonTypeId
	AND [Active] = 0
GROUP BY [TrackIndex]
ORDER BY ISNULL([TrackIndex],0) DESC

IF @AppId > 0
	BEGIN
		EXEC dbo.usp_AppointmentHandle @Action='Und', @AppointmentId=@AppId

		UPDATE [dbo].[tbl_Appointment]
		   SET [LessonCount] = [LessonCount] + 1
		 WHERE [AppDate] > @AppDate
		   AND [FK_ClientId] = @ClientId
		   AND [FK_LessonTypeId] = @LessonTypeId
		   AND [Active] = 1

		SELECT @LessonCount = isnull(max([LessonCount]),0) + 1
		FROM dbo.[tbl_ClientLevels]
		WHERE [FK_ClientId] = @ClientId
			AND [FK_LessonTypeId] = @LessonTypeId
			AND [Active] = 1

		EXEC dbo.usp_ClientLessonHandle 'Smt',0,@ClientId,0,@LessonTypeId,@LevelId,@LessonCount,@ExtraCount,1,@LastAction
	END
;
