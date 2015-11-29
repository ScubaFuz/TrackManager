CREATE PROCEDURE [dbo].[usp_Report_Lessons_Overview]
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
-- Purpose	Default report for Payments
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	*********************************************
-- 1.0		2012-09-26  BT		Initial version
-- 1.1		2013-10-12	BT		Rewritten
-- 2.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************

DECLARE @SqlString nvarchar(2000)

SELECT ROW_NUMBER() OVER(ORDER BY app.AppDate, trk.TrackName, ISNULL(app.TrackIndex,0), grp.GroupName) AS RowNumber
	,dbo.udf_Weekday(app.AppDate,@Language) + ' ' + dbo.udf_DateFormat(app.AppDate,1) AS AppDate
	, LTRIM(RTRIM(isnull(clt.FirstName,''))) + 
		CASE WHEN LTRIM(RTRIM(isnull(clt.MiddleName,''))) = '' THEN '' ELSE ' ' + LTRIM(RTRIM(isnull(clt.MiddleName,''))) END +
		CASE WHEN LTRIM(RTRIM(isnull(clt.FamilyName,''))) = '' THEN '' ELSE ' ' + LTRIM(RTRIM(isnull(clt.FamilyName,''))) END
		AS Name
	, isnull(app.LessonCount,'') AS LessonCount
	, isnull(mem.MemoText,'') AS MemoText
FROM  dbo.tbl_Appointment app
INNER JOIN dbo.tbl_Clients clt
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_LessonTypes lts
	ON app.FK_LessonTypeId = lts.PK_LessonTypeID 
INNER JOIN dbo.tbl_Levels lvl
	ON app.FK_LevelId = lvl.PK_LevelID 
LEFT OUTER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
LEFT OUTER JOIN [dbo].[tbl_Memo] mem
	ON mem.[FK_GroupId] = clt.[PK_ClientID]
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.Active = 1
	AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@ClientId,0) IN (clt.[PK_ClientId],0,-1)
	AND ISNULL(@GroupId,0) IN (grp.[PK_GroupID],0,-1)
	AND ISNULL(@trackId,0) IN (trk.[PK_TrackID],0,-1)
	AND ISNULL(@AppType,'') IN (app.[AppType],'')
ORDER BY RowNumber,app.AppDate, clt.FirstName
;
