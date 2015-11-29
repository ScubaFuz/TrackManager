CREATE PROCEDURE [dbo].[usp_Report_Lessons_Appointments]
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
-- Purpose	Default report for Open/Unpaid Bills
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	***********************************************
-- 1.0		2013-10-22  BT		Initial version
-- 2.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************
--SELECT @DateStart = '2013-07-01', @DateStop = '2014-06-30'
--SELECT @LessonTypeId = -1
--SELECT @TrackId = 0
--SELECT @GroupId = 0
--SELECT @AppType = '0'
--SELECT @ClientId = 0

;WITH Appointments AS (
SELECT dbo.udf_DateFormat(@DateStart,1) As StartDate
	,dbo.udf_DateFormat(COALESCE(@DateStop,@DateStart),1) AS EndDate
	,COUNT(*) AS AppCount
	,CASE ISNULL(@AppType,'') WHEN '0' THEN 'ALL' ELSE app.[AppType] END AS [AppType]
	,CASE ISNULL(@TrackId,0) WHEN 0 THEN 'ALL' ELSE (SELECT [TrackName] FROM [dbo].[tbl_Tracks] WHERE [Active] = 1 AND [PK_TrackID] = app.[FK_TrackId]) END AS TrackName
	,CASE ISNULL(@LessonTypeId,0) WHEN 0 THEN 'ALL' ELSE (SELECT [LessonTypeName] FROM [dbo].[tbl_LessonTypes] WHERE [Active] = 1 AND [PK_LessonTypeID] = app.[FK_LessonTypeId]) END AS LessonType
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (SELECT [GroupName] FROM [dbo].[tbl_Groups] WHERE [Active] = 1 AND [PK_GroupID] = clt.[FK_GroupID]) END AS GroupName
	,CASE ISNULL(@ClientId,0) WHEN 0 THEN 'ALL' ELSE (SELECT REPLACE([FirstName] + ' ' + ISNULL([MiddleName],'') + ' ' + ISNULL([FamilyName],''),'  ',' ') FROM [dbo].[tbl_Clients] WHERE [Active] = 1 AND [PK_ClientID] = app.[FK_ClientId]) END AS ClientName
FROM [dbo].[tbl_Appointment] app

INNER JOIN [dbo].[tbl_Clients] clt
	ON app.[FK_ClientId] = clt.[PK_ClientID]

WHERE app.[Active] = 1
	AND CAST(FLOOR(CAST(app.[AppDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@TrackId,0) IN (app.[FK_TrackId],0,-1)
	AND ISNULL(@ClientId,0) IN (app.[FK_ClientId],0,-1)
	AND ISNULL(@GroupId,0) IN (clt.[FK_GroupID],0,-1)
	AND ISNULL(@AppType,'0') IN (app.[AppType],'0','-1')
	AND ISNULL(@LessonTypeId,'') IN (app.[FK_LessonTypeId],0,-1)
GROUP BY app.[AppType]
	,app.[FK_TrackId]
	,app.[FK_LessonTypeId]
	,clt.[FK_GroupID]
	,app.[FK_ClientId]
)
SELECT
	StartDate
	,EndDate
	,SUM(AppCount) AS Appointments
	,[AppType]
	,TrackName
	,LessonType
	,GroupName
	,ClientName
FROM Appointments app
GROUP BY
	StartDate
	,EndDate
	,[AppType]
	,TrackName
	,LessonType
	,GroupName
	,ClientName
;