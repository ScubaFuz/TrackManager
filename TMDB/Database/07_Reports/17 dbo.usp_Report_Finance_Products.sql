CREATE PROCEDURE [dbo].[usp_Report_Finance_Products]
--DECLARE
	 @DateStart datetime 
	,@DateStop datetime = NULL
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Default report for sold Products
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	***********************************************
-- 1.0		2013-11-08  BT		Initial version
-- 2.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************
--SELECT @DateStart = '2013-07-01', @DateStop = '2014-06-30'

SELECT dbo.udf_DateFormat(@DateStart,1) As StartDate
	,dbo.udf_DateFormat(COALESCE(@DateStop,@DateStart),1) AS EndDate
	,COUNT(*) AS ProdCount
	,ivl.[Description]
	,SUM(ivl.[Amount]) AS ilnAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN [dbo].[tbl_InvoiceLine] ivl
	ON inv.[PK_InvoiceID] = ivl.[FK_InvoiceID]
INNER JOIN [dbo].[vw_ClientGroups] clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
	AND clt.ClientActive = 1
	AND clt.GroupActive = 1
WHERE inv.[Active] = 1
	AND CAST(FLOOR(CAST(inv.[InvoiceDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
GROUP BY ivl.[Description]
ORDER BY ProdCount DESC,ilnAmount DESC
