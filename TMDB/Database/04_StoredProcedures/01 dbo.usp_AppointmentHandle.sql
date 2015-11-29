CREATE PROCEDURE [dbo].[usp_AppointmentHandle]
	@Action nchar(3),
	@AppointmentId int = 0,
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
	@Active bit = 1
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial version
-- 1.1		2010-03-10	BT		Added Active
-- 1.2		2013-07-08	BT		Added TrackIndex
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- 2.1		2014-01-19	BT		Added lock Removal for whole day
-- ****************************************************************************

DECLARE @AppExists as int
SET @AppExists = 0

IF @Action = 'Upd'
	BEGIN
		IF ISNULL(@AppointmentId,0) = 0
			BEGIN
				SELECT @AppointmentId = [PK_AppointmentId]
				FROM [dbo].[tbl_Appointment] 
				WHERE [AppDate] = @AppDate
					AND [AppType] = @AppType
					AND [FK_ClientId] = @ClientId
					AND [FK_TrackId] = @TrackId
					AND ISNULL([TrackIndex],@TrackIndex) = @TrackIndex
					AND [Active] = 1 
			END
		IF ISNULL(@AppointmentId,0) > 0 
			BEGIN
				SELECT @AppExists = FK_TrackId 
				FROM tbl_Appointment 
				WHERE [AppDate] = @AppDate
					AND [AppType] = @AppType
					AND [FK_TrackId] = @TrackId
					AND [TrackIndex] = @TrackIndex
					AND [Active] = 1
					AND [PK_AppointmentId] <> @AppointmentId
				IF @AppExists > 0 SET @TrackIndex = NULL

				IF @ClientId = 0 SET @ClientId = NULL
				IF @TrackId = 0 SET @TrackId = NULL
				IF @LessonTypeId = 0 SET @LessonTypeId = NULL
				IF @LevelId = 0 SET @LevelId = NULL
				IF @loginId = 0 SET @loginId = NULL
				IF @TrackIndex = 0 SET @TrackIndex = NULL
				UPDATE [dbo].[tbl_Appointment]
				SET [AppDate] = @AppDate
					,[AppType] = @AppType
					,[FK_ClientId] = @ClientId
					,[FK_TrackId] = @TrackId
					,[TrackIndex] = @TrackIndex
					,[FK_LessonTypeId] = @LessonTypeId
					,[FK_LevelId] = @LevelId
					,[LessonCount] = @LessonCount
					,[ExtraCount] = @ExtraCount
					,[FK_LoginId] = @LoginId
				WHERE [PK_AppointmentId] = @AppointmentId
			END
	END

IF @Action = 'Ins'
	BEGIN
		SELECT @AppExists = FK_TrackId 
		FROM tbl_Appointment 
		WHERE [AppDate] = @AppDate
			AND [AppType] = @AppType
			AND [FK_TrackId] = @TrackId
			AND [TrackIndex] = @TrackIndex
		IF @AppExists > 0 SET @TrackIndex = NULL

		IF @ClientId = 0 SET @ClientId = NULL
		IF @TrackId = 0 SET @TrackId = NULL
		IF @LessonTypeId = 0 SET @LessonTypeId = NULL
		IF @LevelId = 0 SET @LevelId = NULL
		IF @loginId = 0 SET @loginId = NULL
		IF @TrackIndex = 0 SET @TrackIndex = NULL
		INSERT INTO [dbo].[tbl_Appointment]
			([AppDate]
			,[AppType]
			,[FK_ClientId]
			,[FK_TrackId]
			,[TrackIndex]
			,[FK_LessonTypeId]
			,[FK_LevelId]
			,[LessonCount]
			,[ExtraCount]
			,[FK_LoginId])
		VALUES
			(@AppDate
			,@AppType
			,@ClientId
			,@TrackId
			,@TrackIndex
			,@LessonTypeId
			,@LevelId
			,@LessonCount
			,@ExtraCount
			,@LoginId)
	END

IF @Action = 'Get'
	BEGIN
		SELECT [PK_AppointmentId]
				,[AppDate]
				,[AppType]
				,[FK_ClientId]
				,[FK_TrackId]
				,[TrackIndex]
				,[FK_LessonTypeId]
				,[FK_LevelId]
				,[LessonCount]
				,[ExtraCount]
				,[FK_LoginId]
			FROM [dbo].[tbl_Appointment]
			WHERE [Active] = 1
			AND ISNULL(@AppDate,0) IN ([AppDate],0)
			AND ISNULL(@AppointmentId,0) IN ([PK_AppointmentId],0)
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@AppType,'') = 'Lock' AND @AppDate IS NOT NULL
			BEGIN
				--Remove all locks from date
				DELETE [dbo].[tbl_Appointment]
				WHERE [AppDate] BETWEEN @AppDate AND DATEADD(MINUTE,-5,DATEADD(DAY,1,@AppDate))
					AND [AppType] = 'Lock'
			END
		IF ISNULL(@AppointmentId,0) > 0
			BEGIN
				UPDATE [dbo].[tbl_Appointment]
				SET [Active] = 0
				WHERE [PK_AppointmentId] = @AppointmentId
			END
	END

IF @Action = 'Und'
	BEGIN
		IF ISNULL(@AppointmentId,0) > 0
			BEGIN
				UPDATE [dbo].[tbl_Appointment]
				SET [Active] = 1
				WHERE [PK_AppointmentId] = @AppointmentId
			END
	END

IF @Action = 'Smt' AND @AppType = 'Lock'
	BEGIN
		IF NOT (DATEADD(day, DATEDIFF(day, 0, @AppDate), 0) <> @AppDate AND @TrackId = 0)
			BEGIN
				DECLARE @Return int
				SET @Return = (SELECT [PK_AppointmentId]
					  FROM [dbo].[tbl_Appointment]
					 WHERE [AppDate] = @AppDate
					   AND [AppType] = @AppType
					   AND isnull([FK_TrackId],0) = @TrackId
					   AND [Active] = 1)

				IF ISNULL(@Return,0) = 0
					BEGIN
						--Insert
						--EXEC [dbo].[usp_AppointmentHandle] 'Ins',NULL,@AppDate,@AppType,@ClientId,@TrackId,@LessonTypeId,@LevelId,@LessonCount,@ExtraCount,@loginId
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
						IF @Return > 0
							BEGIN
								--Delete
								EXEC [dbo].[usp_AppointmentHandle] 'Del', @Return
							END
					END
			END
	END
;
