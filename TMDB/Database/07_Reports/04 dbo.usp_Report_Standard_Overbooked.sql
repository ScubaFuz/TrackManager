CREATE PROCEDURE [dbo].[usp_Report_Standard_Overbooked]
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
-- ****************************************************************************

;
WITH LC AS (
SELECT DISTINCT grp.[PK_GroupID]
	, grp.[GroupName]
	--, SUM(cls.[LessonCount]) AS LessonCount
	,(SELECT COUNT(*) 
		FROM tbl_Appointment App 
		WHERE App.AppDate between @DateStart and @DateStop 
			AND app.Active = 1
			AND app.AppType = 'Track'
			AND App.FK_ClientID IN (SELECT [PK_ClientID] 
										FROM [dbo].[tbl_Clients]
										WHERE [FK_GroupID] = grp.[PK_GroupID]))
		AS [LessonCount]
FROM [dbo].[tbl_Groups] grp
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
WHERE inv.InvoiceDate between @DateStart and ISNULL(@DateStop,Dateadd(dd,1,@DateStart))
	AND inv.[Active] = 1
GROUP BY cts.FK_GroupID, grp.[GroupName]
)
SELECT DISTINCT ISNULL(LC.[PK_GroupID],IL.[FK_GroupID]) AS GroupID
	,ISNULL(LC.[GroupName],IL.[GroupName]) AS [GroupName]
	,ISNULL(LC.LessonCount,0) As LessonCount
	,ISNULL(IL.InvoiceLessons,0) AS InvoiceLessons
	,ISNULL(LC.LessonCount,0) - ISNULL(IL.InvoiceLessons,0) AS Shortage
FROM LC
FULL OUTER JOIN IL
	ON LC.PK_GroupID = IL.FK_GroupID
WHERE ISNULL(LC.LessonCount,0) - ISNULL(IL.InvoiceLessons,0) > 0

