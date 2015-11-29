CREATE PROCEDURE [dbo].[usp_Report_Finance_Open_Facturen]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@TrackId int = 0
	,@AppType nvarchar(10) = NULL
	,@InvoiceId int = 0
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Rapport over open facturen
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2010-01-01  BT         Eerste versie

-- ****************************************************************************

DECLARE @SqlString nvarchar(2000)

SET @SqlString = '
SELECT inv.[PK_InvoiceID] AS InvoiceId
	, inv.[InvoiceDate] AS InvoiceDate
	, isnull(grp.GroupName,'''') AS GroupName
	, isnull(clt.FirstName,'''') AS FirstName
	, isnull(clt.MiddleName,'''') AS MiddleName
	, isnull(clt.FamilyName,'''') AS FamilyName
	, isnull(lgn.[LoginName],'''') AS BookedBy
	, isnull(iln.ilnAmount,0) AS ilnAmount
	, isnull(ipy.ipyAmount,0) AS ipyAmount
	, isnull(iln.ilnAmount,0) - isnull(ipy.ipyAmount,0) AS opnAmount
FROM [dbo].[tbl_Invoice] inv
INNER JOIN tbl_Clients clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
INNER JOIN  dbo.tbl_Appointment app
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
INNER JOIN tbl_Logins lgn
ON inv.[FK_loginID] = lgn.[PK_loginID]
INNER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
LEFT OUTER JOIN
	(SELECT ilc.[FK_InvoiceID] AS ilnInvoiceId
		,MAX(ilc.[Description]) AS ilnDescription
		,SUM(ilc.[Count]) AS ilnCount
		,SUM(ilc.[Amount]) AS ilnAmount
	FROM [dbo].[tbl_InvoiceLine] ilc
	WHERE ilc.[Active] = 1
	GROUP BY ilc.[FK_InvoiceID]) iln
ON inv.[PK_InvoiceID] = iln.ilnInvoiceId
LEFT OUTER JOIN
	(SELECT ipc.[FK_InvoiceID] AS ipyInvoiceId
		,SUM(ipc.[Amount]) AS ipyAmount
	FROM [dbo].[tbl_InvoicePayment] ipc
	WHERE ipc.[Active] = 1
	GROUP BY ipc.[FK_InvoiceID]) ipy
ON inv.[PK_InvoiceID] = ipy.ipyInvoiceId
WHERE inv.[Payed] = 0
	AND inv.[Active] = 1
'
IF @DateStop IS NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) = ''' + CONVERT(nvarchar(8),@DateStart,112) + ''''
	END
ELSE
	BEGIN
		SET @SqlString = @SqlString + ' AND inv.[InvoiceDate] BETWEEN ''' + CONVERT(nvarchar(8),@DateStart,112) + ''' AND ''' + CONVERT(nvarchar(8),@DateStop,112) + ''''
	END

IF @ClientId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND clt.PK_ClientId = ' + CAST(@ClientId AS nvarchar(10))
	END

IF @GroupId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND grp.PK_GroupId = ' + CAST(@GroupId AS nvarchar(20))
	END

IF @TrackId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND trk.PK_TrackId = ' + CAST(@trackId AS nvarchar(10))
	END

IF @AppType IS NOT NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND app.AppType = ''' + @AppType + ''''
	END

IF @InvoiceId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND inv.[PK_InvoiceID] = ' + CAST(@InvoiceId AS nvarchar(10))
	END

SET @SqlString = @SqlString + ' 
GROUP BY PK_InvoiceID
,clt.[FK_GroupId],inv.[FK_ClientID]
,InvoiceDate
,isnull(grp.GroupName,'''')
,isnull(clt.FirstName,'''')
,isnull(clt.MiddleName,'''')
,isnull(clt.FamilyName,'''')
,isnull(lgn.[LoginName],'''')
,isnull(iln.ilnAmount,0)
,isnull(ipy.ipyAmount,0)
,isnull(iln.ilnAmount,0) - isnull(ipy.ipyAmount,0)
ORDER BY clt.[FK_GroupId],inv.[FK_ClientID]
'

--print @SqlString
exec sp_executesql @SqlString
;
