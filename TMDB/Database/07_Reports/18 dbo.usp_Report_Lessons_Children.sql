CREATE PROCEDURE [dbo].[usp_Report_Lessons_Children]
--DECLARE
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@TrackId int = 0
	,@AppType nvarchar(10) = '0'
	,@LessonTypeId int = 0
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Default report for children's appointments
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	***********************************************
-- 1.0		2013-11-08  BT		Initial version
-- 2.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************
--SELECT @DateStart = '2013-07-01', @DateStop = '2014-06-30'
--SELECT @LessonTypeId = 0
--SELECT @TrackId = 0
--SELECT @GroupId = 0
--SELECT @AppType = '0'
--SELECT @ClientId = 0

DECLARE @MaxAge int

SET @MaxAge = (SELECT TOP 1 [ConfigValue]
FROM [dbo].[tbl_Config]
WHERE [Category] = 'ScreenView'
	AND [ConfigName] = 'ShowAgeMax'
	AND GetDate() BETWEEN [DateStart] AND ISNULL([DateStop],GetDate()+1)
	AND [Active] = 1)
IF ISNULL(@MaxAge,0) = 0 SET @MaxAge = 12
--SELECT @MaxAge

;WITH Children AS (
SELECT dbo.udf_DateFormat(@DateStart,1) As StartDate
	,dbo.udf_DateFormat(COALESCE(@DateStop,@DateStart),1) AS EndDate
	,COUNT(*) AS AppCount
	,CASE ISNULL(@AppType,'') WHEN '0' THEN 'ALL' ELSE app.[AppType] END AS [AppType]
	,CASE ISNULL(@TrackId,0) WHEN 0 THEN 'ALL' ELSE (trk.[TrackName]) END AS TrackName
	,CASE ISNULL(@LessonTypeId,0) WHEN 0 THEN 'ALL' ELSE ([LessonTypeName]) END AS LessonType
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (grp.[GroupName]) END AS GroupName
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (CAST(grp.[PK_GroupID] AS nvarchar(100))) END AS GroupID
	,CASE ISNULL(@ClientId,0) WHEN 0 THEN 'ALL' ELSE (REPLACE(clt.[FirstName] + ' ' + ISNULL(clt.[MiddleName],'') + ' ' + ISNULL(clt.[FamilyName],''),'  ',' ')) END AS ClientName
	,FLOOR(DATEDIFF(dd,clt.[DayOfBirth],app.AppDate)/365.25) As Age
FROM [dbo].[tbl_Appointment] app
INNER JOIN [dbo].[tbl_Clients] clt
	On app.[FK_ClientId] = clt.[PK_ClientID]
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
INNER JOIN [dbo].[tbl_Tracks] trk
	ON app.[FK_TrackId] = trk.[PK_TrackID]
INNER JOIN [dbo].[tbl_LessonTypes] lts
	ON app.[FK_LessonTypeId] = lts.[PK_LessonTypeID]

WHERE app.[Active] = 1
	AND CAST(FLOOR(CAST(app.[AppDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND FLOOR(DATEDIFF(dd,clt.[DayOfBirth],app.AppDate)/365.25) <= @MaxAge
	AND ISNULL(@TrackId,0) IN (app.[FK_TrackId],0,-1)
	AND ISNULL(@ClientId,0) IN (app.[FK_ClientId],0,-1)
	AND ISNULL(@GroupId,0) IN (clt.[FK_GroupID],0,-1)
	AND ISNULL(@AppType,'0') IN (app.[AppType],'0','-1')
	AND ISNULL(@LessonTypeId,'') IN (app.[FK_LessonTypeId],0,-1)
GROUP BY app.[AppType]
	,trk.[TrackName]
	,lts.[LessonTypeName]
	,app.[FK_ClientId]
	,grp.[GroupName]
	,grp.[PK_GroupID]
	,REPLACE(clt.[FirstName] + ' ' + ISNULL(clt.[MiddleName],'') + ' ' + ISNULL(clt.[FamilyName],''),'  ',' ')
	,FLOOR(DATEDIFF(dd,clt.[DayOfBirth],app.AppDate)/365.25)

)
SELECT
	StartDate
	,EndDate
	,SUM(AppCount) AS Appointments
	,Age
	,AppType
	,TrackName
	,LessonType
	,GroupName
	,GroupId
	,ClientName
FROM Children chd
GROUP BY
	StartDate
	,EndDate
	,Age
	,AppType
	,TrackName
	,LessonType
	,GroupName
	,GroupId
	,ClientName
ORDER BY Age,LessonType,GroupName,ClientName
;
