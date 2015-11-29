CREATE PROCEDURE [dbo].[usp_DayAppGet]
	@Day smalldatetime
	,@ShowMoney as integer = 0
	,@ShowLastAppointment as bit = 0
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 1.1		2010-01-01	BT		Eerste versie
-- 1.2		2012-02-10	BT		[Active] disabled for dependent items
-- 1.3		2013-07-08	BT		[TrackIndex] added
-- 2.0		2013-08-27	BT		Added age to firstname
-- 2.1		2014-11-23	BT		Replaced Age method with SQL Function
-- 3.0		2014-12-11	BT		Added unpaid invoice check
--								Added Last Appointment Check
-- ****************************************************************************
DECLARE @intShowAge INT , @GroupID bigint
SELECT  @intShowAge = dbo.udf_GetShowAge()

SELECT app.[PK_AppointmentId]
	,app.[AppDate]
	,app.[AppType]
	,isnull(app.[FK_ClientId],0) as [FK_ClientId]
	,isnull(app.[FK_TrackId],0) as [FK_TrackId]
	,isnull(app.[TrackIndex],0) as [TrackIndex]
	,app.[FK_LessonTypeId]
	,app.[FK_LevelId]
	,app.[LessonCount]
	,app.[ExtraCount]
	,CASE WHEN app.[LessonCount] = cls.LessonCount AND app.[AppType] = 'Track' AND @ShowLastAppointment = 1 THEN '!'
		ELSE ''
		END +
		dbo.udf_FirstNameAge(clt.[FirstName],clt.[DayOfBirth],@Day,@intShowAge) AS [FirstName]
	,clt.[MiddleName]
	,clt.[FamilyName]
	,clt.[FK_GroupID]
	,ltp.[LessonTypeName]
	,ltp.[Color] as [LessonTypeColor]
	,lvl.[LevelName]
	,CASE 
		WHEN app.[FK_LevelId] = 1 THEN dbo.udf_LevelColorGet(app.[LessonCount]+app.[ExtraCount])
		ELSE lvl.[Color]
		END as LevelColor
	,lvl.[LevelCount]
	,CASE --WHEN @ShowMoney = 0 THEN 1
		WHEN inv.Payed = 0 THEN 0
		WHEN inv.Payed = 1 THEN 1
		ELSE 1
		END AS Payed
FROM [dbo].[tbl_Appointment] app
LEFT OUTER JOIN [dbo].[tbl_Clients] clt
	ON app.[FK_ClientId] = clt.[PK_ClientId]
	--AND clt.[Active] = 1
LEFT OUTER JOIN [dbo].[tbl_LessonTypes] ltp
	ON app.[FK_LessonTypeId] = ltp.[PK_LessonTypeId]
	--AND ltp.[Active] = 1
LEFT OUTER JOIN [dbo].[tbl_Levels] lvl
	ON app.[FK_LevelId] = lvl.[PK_LevelId]
	--AND lvl.[Active] = 1
LEFT OUTER JOIN (SELECT Distinct [FK_ClientId],[FK_GroupID],[Payed]
					FROM [dbo].[tbl_Invoice] i
					INNER JOIN [dbo].[tbl_Clients] c
						ON i.[FK_ClientID] = c.[PK_ClientID]
					WHERE [Payed] = 0
						AND i.[Active] = 1) inv
	ON (app.[FK_ClientId] = inv.[FK_ClientId] AND @ShowMoney > 0)
		OR (inv.[FK_GroupID] = (SELECT [FK_GroupID] FROM [dbo].[tbl_clients] WHERE [PK_ClientId] = app.[FK_ClientId]) AND @ShowMoney = 2)
LEFT OUTER JOIN [dbo].[tbl_ClientLevels] cls
	ON app.[FK_ClientId] = cls.[FK_ClientID]
		AND app.[FK_LessonTypeID] = cls.[FK_LessonTypeID]
WHERE DATEDIFF(day, app.[AppDate], @Day) = 0
	AND app.[Active] = 1
ORDER BY app.[AppType]
	,isnull(app.[FK_TrackId],0)
	,app.[AppDate]
	,isnull(app.[TrackIndex],0) DESC
	,isnull(app.[FK_ClientId],0)

;
