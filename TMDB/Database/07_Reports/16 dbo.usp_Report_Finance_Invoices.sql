CREATE PROCEDURE [dbo].[usp_Report_Finance_Invoices]
--declare
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Default report for Invoices
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	***********************************************
-- 1.0		2013-11-07  BT		Initial version
-- 2.0		2014-12-16	BT		Added DateFormatting
-- 3.0		2018-04-01	BT		Rewritten including views; only existing clients
-- ****************************************************************************
--select 	 @DateStart = '2013-10-01' 
--	,@DateStop = '2014-10-31'
--	,@ClientId = 0
--	,@GroupId = -1
--	,@InvoiceId = 0


SELECT dbo.udf_DateFormat(@DateStart,1) As StartDate
	,dbo.udf_DateFormat(COALESCE(@DateStop,@DateStart),1) AS EndDate
	,COUNT(*) AS InvoiceCount
	,CASE ISNULL(@ClientId,0) WHEN 0 THEN 'ALL' ELSE (clt.[ClientName]) END AS ClientName
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (clt.[GroupName]) END AS GroupName
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (CAST(clt.[PK_GroupID] AS nvarchar(100))) END AS GroupID
	,ISNULL(SUM(iln.[Amount]),0) AS ilnAmount
	,ISNULL(SUM(ipy.[Amount]),0) AS ipyAmount
	,ISNULL(SUM(iln.[Amount]),0) - ISNULL(SUM(ipy.[Amount]),0) AS opnAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN [dbo].[vw_InvoiceLines] iln
	ON inv.[PK_InvoiceID] = iln.[FK_InvoiceID]
LEFT OUTER JOIN [dbo].[vw_InvoicePayments] ipy
	ON inv.[PK_InvoiceID] = ipy.[FK_InvoiceID]
INNER JOIN [dbo].[vw_ClientGroups] clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
	AND clt.ClientActive = 1
	AND clt.GroupActive = 1
WHERE inv.[Active] = 1
	AND CAST(FLOOR(CAST(inv.[InvoiceDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@ClientId,0) IN (clt.PK_ClientId,0,-1)
	AND ISNULL(@GroupId,0) IN (clt.PK_GroupId,0,-1)
GROUP BY CASE ISNULL(@ClientId,0) WHEN 0 THEN 'ALL' ELSE (clt.[ClientName]) END
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (clt.[GroupName]) END
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (CAST(clt.[PK_GroupID] AS nvarchar(100))) END
ORDER BY GroupName
;
