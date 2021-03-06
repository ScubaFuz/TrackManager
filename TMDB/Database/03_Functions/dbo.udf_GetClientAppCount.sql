CREATE FUNCTION [dbo].[udf_GetCLientAppCount] (@RunDate date)
RETURNS @AppCount TABLE (
	FK_ClientId int NOT NULL,
	LessonCount int NOT NULL)

AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Get the Appointment count for the current season
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2018-11-20	BT		Initial Version
-- ****************************************************************************

BEGIN
--SET @RunDate = '2018-11-18'
DECLARE @SeasonStart date = NULL
	,@SeasonEnd date = NULL

SELECT @SeasonStart = SeasonStart
	,@SeasonEnd = SeasonEnd
FROM dbo.udf_GetSeason(@RunDate)

INSERT INTO @AppCount (FK_ClientId,LessonCount)
SELECT app.FK_ClientId, COUNT(app.AppDate) AS LessonCount
FROM tbl_Appointment App 
INNER JOIN [dbo].[tbl_Clients] clt
	ON App.FK_ClientId = clt.PK_ClientID 
INNER JOIN [dbo].[tbl_Groups] grp
	ON clt.FK_GroupID = grp.[PK_GroupID]
WHERE CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @SeasonStart AND COALESCE(@SeasonEnd,@SeasonStart)
	AND app.Active = 1
	AND app.AppType = 'Track'
GROUP BY app.FK_ClientId;

RETURN;
END;