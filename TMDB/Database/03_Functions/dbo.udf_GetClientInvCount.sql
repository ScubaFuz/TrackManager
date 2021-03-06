CREATE FUNCTION [dbo].[udf_GetCLientInvCount] (@RunDate date)
RETURNS @InvCount TABLE (
	FK_ClientId int NOT NULL,
	InvoiceLessons int NOT NULL)

AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Get the Appointment count for the current season
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2018-11-20	BT		Initial Version
-- ****************************************************************************

BEGIN
--DECLARE @RunDate date = '2018-11-18'
DECLARE @SeasonStart date = NULL
	,@SeasonEnd date = NULL

SELECT @SeasonStart = SeasonStart
	,@SeasonEnd = SeasonEnd
FROM dbo.udf_GetSeason(@RunDate)

INSERT INTO @InvCount (FK_ClientId,InvoiceLessons)
	SELECT ivl.FK_ClientId, SUM(ivl.[Count]) AS InvoiceLessons
	FROM [dbo].[tbl_Invoice] inv
	INNER JOIN tbl_Clients cts
		ON inv.FK_ClientID = cts.PK_ClientID
	INNER JOIN [dbo].[tbl_Groups] grp
		ON cts.FK_GroupID = grp.PK_GroupID
		AND grp.[Active] = 1
	LEFT OUTER JOIN [dbo].[tbl_InvoiceLine] ivl
		ON inv.PK_InvoiceID = ivl.FK_InvoiceID
		AND ivl.[Active] = 1
	WHERE  CAST(FLOOR(CAST(inv.InvoiceDate AS float)) AS datetime) BETWEEN @SeasonStart and COALESCE(@SeasonEnd,@SeasonStart)
		AND inv.[Active] = 1
		AND ivl.FK_ClientID IS NOT NULL
	GROUP BY ivl.FK_ClientId

RETURN;
END;