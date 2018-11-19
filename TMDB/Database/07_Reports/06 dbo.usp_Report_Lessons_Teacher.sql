CREATE PROCEDURE [dbo].[usp_Report_Lessons_Teacher]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@TrackId int = 0
	,@AppType nvarchar(10) = NULL
	,@Language nvarchar(10) = 'EN'

AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2018-11-14	BT		Initial Version
-- ****************************************************************************

;WITH Teacher AS (
SELECT [AppDate]
	,[FK_TrackId]
FROM [dbo].[tbl_Appointment] app
WHERE app.Active = 1
	AND CAST(FLOOR(CAST(app.[AppDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND @ClientId = app.[FK_ClientId]
	AND [AppType] = 'Teacher'
)
SELECT ROW_NUMBER() OVER(ORDER BY app.AppDate, trk.TrackName, grp.GroupName) AS RowNumber
	, left(dbo.udf_Weekday(app.AppDate, @Language) ,2) + ' ' + dbo.udf_DateFormat(app.AppDate,1) AS AppDate
	, isnull(trk.TrackName,'') AS TrackName
	, isnull(grp.GroupName,'') AS GroupName
	, isnull(grp.PK_GroupId,0) AS GroupId
	, isnull(clt.ClientName,'') AS ClientName
	, DATEDIFF(YEAR,clt.DayOfBirth,GetDate()) - CASE WHEN (MONTH(clt.DayOfBirth) > MONTH(GetDate())) OR (MONTH(clt.DayOfBirth) = MONTH(GetDate()) AND DAY(clt.DayOfBirth) >= DAY(GetDate())) THEN 1 ELSE 0 END AS Age
	, isnull(lts.LessonTypeName,'') AS LessonTypeName
	, isnull(app.LessonCount,'') AS LessonCount
	, isnull(dbo.udf_LevelnameGet(app.LessonCount + app.ExtraCount),'') AS LevelName
FROM  dbo.tbl_Appointment app
INNER JOIN Teacher
	ON app.AppDate = Teacher.AppDate
	AND app.FK_TrackId = Teacher.FK_TrackId
INNER JOIN dbo.tbl_Clients clt
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_LessonTypes lts
	ON app.FK_LessonTypeId = lts.PK_LessonTypeID 
LEFT OUTER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.Active = 1
	AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@trackId,0) IN (trk.PK_TrackId,0,-1)
	AND app.AppType = 'Track'
ORDER BY app.AppDate, trk.TrackName, grp.GroupName;
