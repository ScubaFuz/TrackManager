CREATE PROCEDURE [dbo].[usp_Report_Finance_Betalingen_Dag]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@InvoiceId int = 0
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Rapport over financien
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2010-01-01  BT         Eerste versie

-- ****************************************************************************

DECLARE @SqlString nvarchar(2000)

SET @SqlString = '
SELECT inv.[PK_InvoiceID] AS InvoiceId
	, inv.[InvoiceDate]
	, ipy.[PayDate]
	, isnull(grp.GroupName,'''') AS GroupName
	, isnull(grp.Pk_GroupId,0) AS GroupID
	, isnull(clt.FirstName,'''') AS FirstName
	, isnull(clt.MiddleName,'''') AS MiddleName
	, isnull(clt.FamilyName,'''') AS FamilyName
	, isnull(lgn.[LoginName],'''') AS BookedBy
	, isnull(ipy.Amount,0) AS ipyAmount
	, (SELECT SUM(isnull(ipy2.Amount,0)) FROM [tbl_InvoicePayment] ipy2
			WHERE ipy2.[PayDate] = ipy.[PayDate]) AS Total  
FROM [dbo].[tbl_Invoice] inv
INNER JOIN tbl_Clients clt
	ON inv.[FK_ClientID] = clt.[PK_ClientID]
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
INNER JOIN tbl_Logins lgn
	ON inv.[FK_loginID] = lgn.[PK_loginID]
INNER JOIN [tbl_InvoicePayment] ipy
	ON inv.[PK_InvoiceID] = ipy.FK_InvoiceId
WHERE inv.[Active] = 1
'
IF @DateStop IS NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND CAST(FLOOR(CAST(ipy.[PayDate] AS float)) AS datetime) = ''' + CONVERT(nvarchar(8),@DateStart,112) + ''''
	END
ELSE
	BEGIN
		SET @SqlString = @SqlString + ' AND ipy.[PayDate] BETWEEN ''' + CONVERT(nvarchar(8),@DateStart,112) + ''' AND ''' + CONVERT(nvarchar(8),@DateStop,112) + ''''
	END

IF @ClientId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND clt.PK_ClientId = ' + CAST(@ClientId AS nvarchar(10))
	END

IF @GroupId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND grp.PK_GroupId = ' + CAST(@GroupId AS nvarchar(20))
	END

IF @InvoiceId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND inv.[PK_InvoiceID] = ' + CAST(@InvoiceId AS nvarchar(10))
	END

SET @SqlString = @SqlString + ' 
ORDER BY ipy.[PayDate], isnull(grp.GroupName,''''), isnull(clt.FirstName,'''')
'

--print @SqlString
exec sp_executesql @SqlString
;
