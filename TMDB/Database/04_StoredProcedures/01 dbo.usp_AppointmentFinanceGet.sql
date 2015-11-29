CREATE PROCEDURE [dbo].[usp_AppointmentFinanceGet]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientID int = 0
	,@GroupID bigint = 0
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Return number of lessons booked and billed per timeframe.	
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 1.0		2014-11-29	BT		Initial Version
-- ****************************************************************************
;
WITH LC AS (
	SELECT COUNT(*) AS LessonCount
	FROM tbl_Appointment App 
	INNER JOIN [dbo].[tbl_Clients] clt
		ON App.FK_ClientId = clt.PK_ClientID 
	INNER JOIN [dbo].[tbl_Groups] grp
		ON clt.FK_GroupID = grp.[PK_GroupID]
	WHERE CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN @DateStart AND COALESCE(@DateStop,@DateStart)
		AND app.Active = 1
		AND app.AppType = 'Track'
		AND @GroupID IN (grp.PK_GroupID,0)
		AND @ClientID IN (clt.PK_ClientID,0)
), IL AS (
	SELECT SUM(ivl.[Count]) AS InvoiceLessons
	FROM [dbo].[tbl_Invoice] inv
	INNER JOIN tbl_Clients cts
		ON inv.FK_ClientID = cts.PK_ClientID
	INNER JOIN [dbo].[tbl_Groups] grp
		ON cts.FK_GroupID = grp.PK_GroupID
		AND grp.[Active] = 1
	LEFT OUTER JOIN [dbo].[tbl_InvoiceLine] ivl
		ON inv.PK_InvoiceID = ivl.FK_InvoiceID
		AND ivl.[Active] = 1
	WHERE  CAST(FLOOR(CAST(inv.InvoiceDate AS float)) AS datetime) BETWEEN @DateStart and COALESCE(@DateStop,@DateStart)
		AND inv.[Active] = 1
		AND @GroupID IN (grp.PK_GroupID,0)
		AND @ClientID IN (cts.PK_ClientID,0)
)
SELECT DISTINCT COALESCE(LC.LessonCount,0) As LessonCount
	,COALESCE(IL.InvoiceLessons,0) AS InvoiceLessons
	,COALESCE(LC.LessonCount,0) - COALESCE(IL.InvoiceLessons,0) AS [Difference]
FROM LC, IL;

