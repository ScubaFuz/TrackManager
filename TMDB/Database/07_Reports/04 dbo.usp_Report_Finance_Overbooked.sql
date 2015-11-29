CREATE PROCEDURE [dbo].[usp_Report_Finance_Overbooked]
	 @DateStart datetime 
	,@DateStop datetime = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Provide a list of all/1 groups that have more lessons than billed.	
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 1.0		2013-09-08	BT		Initial Version
-- 2.0		2013-10-07	BT		Added Active = 1
-- 2.1		2013-10-08	BT		Added ISNULL to DateStop
-- 3.0		2013-10-30	BT		Replaced nested select with join
-- 4.0		2015-02-24	BT		Rewritten to include all appointments and finances in a season
--								 for a client who has an appointment in a certain timeframe.
-- ****************************************************************************

DECLARE @SeasonStart datetime, @SeasonLength nvarchar(10), @SeasonMonths tinyint, @SeasonEnd datetime

SELECT @SeasonStart = [ConfigValue]
FROM [dbo].[tbl_Config]
WHERE [Category] = 'General' 
	AND [ConfigName] = 'SeasonStart' 
	AND [Active] = 1

SELECT @SeasonLength = [ConfigValue]
FROM [dbo].[tbl_Config]
WHERE [Category] = 'General' 
	AND [ConfigName] = 'SeasonLength' 
	AND [Active] = 1

SELECT @SeasonMonths = 
	CASE @SeasonLength
		WHEN 'Year' THEN 12
		WHEN '6 Months' THEN  6
		WHEN 'Quarter' THEN  3
		WHEN 'Month' THEN  1
	END

SET @SeasonEnd = DATEADD(M,@SeasonMonths,@SeasonStart)
SET @SeasonEnd = DATEADD(D,-1,@SeasonEnd)

WHILE @SeasonStart > @DateStart OR @SeasonEnd < @DateStart
BEGIN
	IF @SeasonStart > @DateStart
	BEGIN
		SET @SeasonStart = DATEADD(M,-@SeasonMonths,@SeasonStart)
		SET @SeasonEnd = DATEADD(M,-@SeasonMonths,@SeasonEnd)
	END
	IF @SeasonEnd < @DateStart
	BEGIN
		SET @SeasonStart = DATEADD(M,@SeasonMonths,@SeasonStart)
		SET @SeasonEnd = DATEADD(M,@SeasonMonths,@SeasonEnd)
	END

END

--SELECT @SeasonStart,@SeasonEnd,@DateStart,@DateStop

;
WITH  AC AS (
	SELECT MAX(App.AppDate) AS AppDate, clt.PK_ClientID, clt.FirstName, clt.FamilyName, grp.PK_GroupID, grp.GroupName
	FROM tbl_Appointment App 
	INNER JOIN [dbo].[tbl_Clients] clt
		ON App.FK_ClientId = clt.PK_ClientID 
	INNER JOIN [dbo].[tbl_Groups] grp
		ON clt.FK_GroupID = grp.[PK_GroupID]
	WHERE CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
		AND app.Active = 1
		AND app.AppType = 'Track'
	GROUP BY clt.PK_ClientID, clt.FirstName, clt.FamilyName, grp.PK_GroupID, grp.GroupName
), LC AS (
	SELECT grp.PK_GroupID,grp.GroupName,COUNT(*) AS LessonCount
	FROM tbl_Appointment App 
	INNER JOIN [dbo].[tbl_Clients] clt
		ON App.FK_ClientId = clt.PK_ClientID 
	INNER JOIN [dbo].[tbl_Groups] grp
		ON clt.FK_GroupID = grp.[PK_GroupID]
	WHERE CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @SeasonStart AND ISNULL(@SeasonEnd,@SeasonStart)
		AND app.Active = 1
		AND app.AppType = 'Track'
		AND app.FK_ClientId IN (SELECT PK_ClientID FROM tbl_Clients WHERE FK_GroupID in (SELECT Distinct PK_GroupID FROM AC))
	Group BY grp.PK_GroupID,grp.GroupName
), IL AS (
	SELECT cts.FK_GroupID, grp.[GroupName], SUM(ivl.[Count]) AS InvoiceLessons
	FROM [dbo].[tbl_Invoice] inv
	INNER JOIN tbl_Clients cts
		ON inv.FK_ClientID = cts.PK_ClientID
	INNER JOIN [dbo].[tbl_Groups] grp
		ON cts.FK_GroupID = grp.PK_GroupID
		AND grp.[Active] = 1
	LEFT OUTER JOIN [dbo].[tbl_InvoiceLine] ivl
		ON inv.PK_InvoiceID = ivl.FK_InvoiceID
		AND ivl.[Active] = 1
	WHERE  CAST(FLOOR(CAST(inv.InvoiceDate AS float)) AS datetime) BETWEEN @SeasonStart and ISNULL(@SeasonEnd,@SeasonStart)
		AND inv.[Active] = 1
	GROUP BY cts.FK_GroupID, grp.[GroupName]
), TC AS (
	SELECT DISTINCT ISNULL(LC.[PK_GroupID],IL.[FK_GroupID]) AS GroupID
		,ISNULL(LC.[GroupName],IL.[GroupName]) AS [GroupName]
		,ISNULL(LC.LessonCount,0) As LessonCount
		,ISNULL(IL.InvoiceLessons,0) AS InvoiceLessons
		,ISNULL(LC.LessonCount,0) - ISNULL(IL.InvoiceLessons,0) AS [Difference]
	FROM LC
	FULL OUTER JOIN IL
		ON LC.PK_GroupID = IL.FK_GroupID
	WHERE ISNULL(LC.LessonCount,0) - ISNULL(IL.InvoiceLessons,0) > 0
)
SELECT AC.AppDate AS Appointment
	,AC.PK_ClientID AS ClientID
	,AC.FirstName
	,AC.FamilyName
	,AC.PK_GroupID As GroupID
	,AC.GroupName
	,TC.LessonCount
	,TC.InvoiceLessons
	,TC.[Difference]
FROM AC 
INNER JOIN TC 
	ON AC.PK_GroupID = TC.GroupID
ORDER BY AC.AppDate
	,AC.PK_GroupID
	,AC.FamilyName
	,AC.FirstName
