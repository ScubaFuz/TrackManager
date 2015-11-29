CREATE PROCEDURE [dbo].[usp_AppointmentUpdate]
	@AppDate smalldatetime,
	@ClientId int,
	@LessonTypeId int,
	@LevelId int
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Update all appointments future to the given date		
-- ****************************************************************************
-- Version	Date        Author	Description
-- *******	**********	******	*********************************************
-- 1.0		2013-09-12	BT		Initial Version
-- ****************************************************************************

DECLARE @AppointmentId int

DECLARE Cursor1 CURSOR FOR
	SELECT [PK_AppointmentId]
	FROM [dbo].[tbl_Appointment]
	WHERE [AppDate] > @AppDate
		AND [AppType] = 'Track'
		AND [FK_ClientId] = @ClientId
		AND [FK_LessonTypeId] = @LessonTypeId
		AND [Active] = 1

OPEN Cursor1
FETCH NEXT FROM Cursor1 into @AppointmentId

WHILE @@FETCH_STATUS = 0
BEGIN
	UPDATE [dbo].[tbl_Appointment]
	SET [FK_LevelId] = @LevelId
	WHERE [PK_AppointmentId] = @AppointmentId

	FETCH NEXT FROM Cursor1 into @AppointmentId
END

CLOSE Cursor1
DEALLOCATE Cursor1
;


