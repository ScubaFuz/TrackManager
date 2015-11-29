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
-- ****************************************************************************
--select 	 @DateStart = '2013-10-01' 
--	,@DateStop = '2014-10-31'
--	,@ClientId = 0
--	,@GroupId = -1
--	,@InvoiceId = 0

;WITH invoices As (
SELECT dbo.udf_DateFormat(@DateStart,1) As StartDate
	,dbo.udf_DateFormat(COALESCE(@DateStop,@DateStart),1) AS EndDate
	,COUNT(*) AS InvoiceCount
	,CASE ISNULL(@ClientId,0) WHEN 0 THEN 'ALL' ELSE (REPLACE(clt.[FirstName] + ' ' + ISNULL(clt.[MiddleName],'') + ' ' + ISNULL(clt.[FamilyName],''),'  ',' ')) END AS ClientName
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (grp.[GroupName]) END AS GroupName
	,CASE ISNULL(@GroupId,0) WHEN 0 THEN 'ALL' ELSE (CAST(grp.[PK_GroupID] AS nvarchar(100))) END AS GroupID
	,isnull(SUM(iln.[Amount]),0) AS ilnAmount
	,isnull(SUM(ipy.[Amount]),0) AS ipyAmount
	,isnull(SUM(iln.[Amount]),0) - isnull(SUM(ipy.[Amount]),0) AS opnAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN tbl_Clients clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
	--AND clt.[Active] = 1
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
	--AND grp.[Active] = 1
LEFT OUTER JOIN [dbo].[tbl_InvoiceLine] iln
	ON inv.[PK_InvoiceID] = iln.[FK_InvoiceID]
	AND iln.[Active] = 1
LEFT OUTER JOIN [dbo].[tbl_InvoicePayment] ipy
	ON inv.[PK_InvoiceID] = ipy.[FK_InvoiceID]
	AND ipy.[Active] = 1
WHERE inv.[Active] = 1
	AND CAST(FLOOR(CAST(inv.[InvoiceDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@ClientId,0) IN (clt.PK_ClientId,0,-1)
	AND ISNULL(@GroupId,0) IN (grp.PK_GroupId,0,-1)
GROUP BY ISNULL(inv.[InvoiceNumber],inv.[PK_InvoiceID])
	,grp.[GroupName]
	,grp.[PK_GroupID]
	,REPLACE(clt.[FirstName] + ' ' + ISNULL(clt.[MiddleName],'') + ' ' + ISNULL(clt.[FamilyName],''),'  ',' ')
)
SELECT StartDate
	,EndDate
	,SUM(InvoiceCount) AS InvoiceCount
	,ClientName
	,GroupName
	,GroupID
	,SUM(ilnAmount) AS ilnAmount
	,SUM(ipyAmount) As ipyAmount
	,SUM(opnAmount) AS opnAmount
FROM invoices
GROUP BY StartDate
	,EndDate
	,ClientName
	,GroupID
	,GroupName
ORDER BY GroupName
;

