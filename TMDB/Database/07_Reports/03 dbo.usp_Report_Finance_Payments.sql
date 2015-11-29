CREATE PROCEDURE [dbo].[usp_Report_Finance_Payments]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@InvoiceId int = 0
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Default report for Payments
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	*********************************************
-- 1.0		2010-01-01  BT		Initial version
-- 1.1		2013-07-10	BT		Added InvoiceNumber
-- 2.0		2014-12-16	BT		Added DateFormatting
-- ****************************************************************************

SELECT ISNULL(inv.[InvoiceNumber],inv.[PK_InvoiceID]) AS InvoiceId
	, dbo.udf_DateFormat(inv.[InvoiceDate],0) AS InvoiceDate
	, dbo.udf_DateFormat(ipy.[PayDate],0) AS [PayDate]
	, isnull(grp.GroupName,'') AS GroupName
	, isnull(grp.Pk_GroupId,0) AS GroupID
	, isnull(clt.FirstName,'') AS FirstName
	, isnull(clt.MiddleName,'') AS MiddleName
	, isnull(clt.FamilyName,'') AS FamilyName
	, isnull(lgn.[LoginName],'') AS BookedBy
	, isnull(ipy.Amount,0) AS ipyAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN tbl_Clients clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
	AND clt.[Active] = 1
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
	AND grp.[Active] = 1
LEFT OUTER JOIN tbl_Logins lgn
	ON inv.[FK_loginID] = lgn.[PK_loginID]
INNER JOIN [tbl_InvoicePayment] ipy
	ON inv.[PK_InvoiceID] = ipy.FK_InvoiceId
	AND ipy.[Active] = 1
WHERE inv.[Active] = 1
	AND CAST(FLOOR(CAST(ipy.[PayDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
	AND ISNULL(@ClientId,0) IN (clt.PK_ClientId,0)
	AND ISNULL(@GroupId,0) IN (grp.PK_GroupId,0)
	AND ISNULL(@InvoiceId,0) IN (inv.[PK_InvoiceID],0)
ORDER BY ipy.[PayDate], isnull(grp.GroupName,''), isnull(clt.FirstName,'')
;
