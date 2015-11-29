CREATE PROCEDURE [dbo].[usp_Report_Finance_Underbooked]
	 @DateStart datetime 
	,@DateStop datetime = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Provide a list of all/1 groups that have less lessons than billed.	
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 1.0		2013-11-07	BT		Initial Version
-- ****************************************************************************

;
WITH LC AS (
	SELECT grp.PK_GroupID,grp.GroupName,COUNT(*) AS LessonCount
	FROM tbl_Appointment App 
	INNER JOIN [dbo].[tbl_Clients] clt
		ON App.FK_ClientId = clt.PK_ClientID 
	INNER JOIN [dbo].[tbl_Groups] grp
		ON clt.FK_GroupID = grp.[PK_GroupID]
	WHERE CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
		AND app.Active = 1
		AND app.AppType = 'Track'
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
WHERE  CAST(FLOOR(CAST(inv.InvoiceDate AS float)) AS datetime) BETWEEN @DateStart and ISNULL(@DateStop,@DateStart)
	AND inv.[Active] = 1
GROUP BY cts.FK_GroupID, grp.[GroupName]
)
SELECT DISTINCT ISNULL(LC.[PK_GroupID],IL.[FK_GroupID]) AS GroupID
	,ISNULL(LC.[GroupName],IL.[GroupName]) AS [GroupName]
	,ISNULL(LC.LessonCount,0) As LessonCount
	,ISNULL(IL.InvoiceLessons,0) AS InvoiceLessons
	,ISNULL(IL.InvoiceLessons,0) - ISNULL(LC.LessonCount,0) AS [Difference]
FROM LC
FULL OUTER JOIN IL
	ON LC.PK_GroupID = IL.FK_GroupID
WHERE ISNULL(LC.LessonCount,0) - ISNULL(IL.InvoiceLessons,0) < 0

