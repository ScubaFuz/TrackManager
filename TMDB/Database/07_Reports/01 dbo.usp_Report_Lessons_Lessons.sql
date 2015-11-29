CREATE PROCEDURE [dbo].[usp_Report_Lessons_Lessons]
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
-- 1.0		2010-01-01	BT		Initial Version
-- 2.0		2013-10-12	BT		Rewritten
-- 3.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************

SELECT ROW_NUMBER() OVER(ORDER BY app.AppDate, trk.TrackName, grp.GroupName) AS RowNumber
	, left(dbo.udf_Weekday(app.AppDate, @Language) ,2) + ' ' + dbo.udf_DateFormat(app.AppDate,1) AS AppDate
	, isnull(trk.TrackName,'') AS TrackName
	, isnull(grp.GroupName,'') AS GroupName
	, isnull(grp.PK_GroupId,0) AS GroupId
	, isnull(clt.FirstName,'') AS FirstName
	, isnull(clt.MiddleName,'') AS MiddleName
	, isnull(clt.FamilyName,'') AS FamilyName
	, isnull(lts.LessonTypeName,'') AS LessonTypeName
	, isnull(app.LessonCount,'') AS LessonCount
	, isnull(app.AppType,'') AS AppType
	, isnull(app.ExtraCount,'') AS ExtraCount
	, isnull(lvl.LevelName,'') AS LevelName
FROM  dbo.tbl_Appointment app
INNER JOIN dbo.tbl_Clients clt
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_LessonTypes lts
	ON app.FK_LessonTypeId = lts.PK_LessonTypeID 
INNER JOIN dbo.tbl_Levels lvl
	ON app.FK_LevelId = lvl.PK_LevelID 
LEFT OUTER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.Active = 1
	AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@ClientId,0) IN (clt.PK_ClientId,0,-1)
	AND ISNULL(@GroupId,0) IN (grp.PK_GroupId,0,-1)
	AND ISNULL(@trackId,0) IN (trk.PK_TrackId,0,-1)
	AND ISNULL(@AppType,'') IN (app.AppType,'')
ORDER BY app.AppDate, trk.TrackName, grp.GroupName;
