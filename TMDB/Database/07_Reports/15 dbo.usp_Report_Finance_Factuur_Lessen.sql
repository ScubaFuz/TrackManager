CREATE PROCEDURE [dbo].[usp_Report_Finance_Factuur_Lessen]
	 @DateStart datetime 
	,@DateStop datetime = NULL

AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Rapport over geboekte lessen die niet gefactureerd zijn.
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2012-02-07  BT         Eerste versie

-- ****************************************************************************

IF @DateStop IS NULL SET @DateStop = @DateStart;

WITH InvoiceNum AS
(
SELECT SUM(ivl.[Count]) AS InvoiceCount
	,clt.[FK_GroupID] AS GroupID
FROM [dbo].[tbl_Invoice] inv
INNER JOIN [dbo].[tbl_InvoiceLine] ivl
	ON inv.[PK_InvoiceID] = ivl.[FK_InvoiceID]
INNER JOIN [dbo].[tbl_Clients] clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
WHERE inv.[InvoiceDate] BETWEEN @DateStart AND @DateStop
	AND inv.[Active] = 1
	AND ivl.[Active] = 1
GROUP BY clt.[FK_GroupID]
),
LessonNum AS
(
SELECT clt.[FK_GroupID]
	,count(*) AS LessonCount
	,grp.[GroupName]
FROM [dbo].[tbl_Appointment] app
INNER JOIN [dbo].[tbl_Clients] clt
	ON app.[FK_ClientId] = clt.[PK_ClientID]
INNER JOIN [dbo].[tbl_Groups] grp
	ON clt.FK_GroupID = grp.[PK_GroupID]
WHERE app.[AppDate] BETWEEN @DateStart AND @DateStop
	AND app.[AppType] = 'Track'
	AND app.[Active] = 1
GROUP BY clt.[FK_GroupID]
	,grp.[GroupName]
)
SELECT ivn.[GroupID]
	,lsn.[GroupName]
	,ivn.[InvoiceCount]
	,lsn.[LessonCount]
	,ivn.[InvoiceCount] - lsn.[LessonCount] AS Total
FROM InvoiceNum ivn
LEFT OUTER JOIN LessonNum lsn
	ON ivn.[GroupID] = lsn.[FK_GroupID]
WHERE ivn.[InvoiceCount] - lsn.[LessonCount] < 0
