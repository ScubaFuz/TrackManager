CREATE PROCEDURE [dbo].[usp_Report_Finance_OpenBills]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@TrackId int = 0
	,@AppType nvarchar(10) = NULL
	,@InvoiceId int = 0
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Default report for Open/Unpaid Bills
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********  *******	***********************************************
-- 1.0		2010-01-01  BT		Initial version
-- 1.1		2010-11-11  BT		various Updates
-- 1.2		2013-07-10	BT		Added InvoiceNumber
-- 2.0		2013-10-12	BT		Rewritten
-- 3.0		2014-12-16	BT		Added DateFormatting
-- 4.0		2018-04-02	BT		Rewritten including views
-- ****************************************************************************

DECLARE @SqlString nvarchar(max)

SELECT inv.[PK_InvoiceID] AS InvoiceId
	, dbo.udf_DateFormat(inv.[InvoiceDate],0) AS InvoiceDate
    , dbo.udf_DateFormat(MAX(app.[AppDate]),1) AS AppDate
	, isnull(clt.GroupName,'') AS GroupName
	, isnull(clt.PK_GroupID,'') AS GroupID
	, isnull(clt.ClientName,'') AS ClientName
	, isnull(lgn.[LoginName],'') AS BookedBy
	, isnull(iln.Amount,0) AS ilnAmount
	, isnull(ipy.Amount,0) AS ipyAmount
	, isnull(iln.Amount,0) - isnull(ipy.Amount,0) AS opnAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN [dbo].[vw_InvoiceLines] iln
	ON inv.[PK_InvoiceID] = iln.[FK_InvoiceID]
LEFT OUTER JOIN [dbo].[vw_InvoicePayments] ipy
	ON inv.[PK_InvoiceID] = ipy.[FK_InvoiceID]
INNER JOIN [dbo].[vw_ClientGroups] clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
	AND clt.ClientActive = 1
	AND clt.GroupActive = 1
INNER JOIN  dbo.tbl_Appointment app
	ON app.FK_ClientId = clt.PK_ClientID 
	AND app.[Active] = 1
LEFT OUTER JOIN tbl_Logins lgn
	ON inv.[FK_loginID] = lgn.[PK_loginID]
INNER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
WHERE inv.[Payed] = 0
	AND inv.[Active] = 1

	AND (CAST(FLOOR(CAST(app.[AppDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
		--OR CAST(FLOOR(CAST(inv.[InvoiceDate] AS float)) AS datetime) BETWEEN @DateStart AND ISNULL(@DateStop,@DateStart)
		)
	AND ISNULL(@ClientId,0) IN (clt.PK_ClientId,0,-1)
	AND ISNULL(@GroupId,0) IN (clt.PK_GroupId,0,-1)
	AND ISNULL(@trackId,0) IN (trk.PK_TrackId,0,-1)
	AND ISNULL(@AppType,'') IN (app.AppType,'')
	AND ISNULL(@InvoiceId,0) IN (inv.[PK_InvoiceID],0)
GROUP BY inv.[PK_InvoiceID]
	,clt.[PK_GroupId],inv.[FK_ClientID]
	,inv.[InvoiceDate]
	,isnull(clt.GroupName,'')
	,isnull(clt.PK_GroupID,'')
	,isnull(clt.ClientName,'')
	,isnull(lgn.[LoginName],'')
	,isnull(iln.Amount,0)
	,isnull(ipy.Amount,0)
	,isnull(iln.Amount,0) - isnull(ipy.Amount,0)
ORDER BY inv.[InvoiceDate], clt.[PK_GroupId], inv.[PK_InvoiceID], inv.[FK_ClientID]
;
