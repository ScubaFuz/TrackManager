CREATE PROCEDURE [dbo].[usp_Report_Lessons_Maand_Overzicht]
	 @DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@AppType nvarchar(10) = NULL
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Rapport over lessen per maand
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2010-01-01  BT         Eerste versie

-- ****************************************************************************

DECLARE @SqlString nvarchar(2000)

SET @SqlString = '
SELECT year(AppDate) as [Year]
	, month(AppDate) as [Month]
	, AppType
	, isnull(grp.GroupName,'''') AS GroupName
	, isnull(grp.PK_GroupId,0) AS GroupId
	, isnull(clt.FirstName,'''') AS FirstName
	, isnull(clt.MiddleName,'''') AS MiddleName
	, isnull(clt.FamilyName,'''') AS FamilyName
	, count(*) as [Count] 
FROM dbo.tbl_Appointment app
INNER JOIN tbl_Clients clt
	ON app.[FK_ClientID] = clt.[PK_ClientID]
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.[Active] = 1
'
IF @DateStop IS NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND YEAR(app.AppDate) = ' + CAST(YEAR(@DateStart) AS nvarchar(4)) + ' AND MONTH(app.AppDate) = ' + CAST(MONTH(@DateStart) AS nvarchar(2))
	END
ELSE
	BEGIN
		SET @SqlString = @SqlString + ' AND app.AppDate BETWEEN ''' + CONVERT(nvarchar(8),@DateStart,112) + ''' AND ''' + CONVERT(nvarchar(8),@DateStop,112) + ''''
	END

IF @ClientId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND clt.PK_ClientId = ' + CAST(@ClientId AS nvarchar(10))
	END

IF @GroupId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND grp.PK_GroupId = ' + CAST(@GroupId AS nvarchar(20))
	END

IF @AppType IS NOT NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND app.AppType = ''' + @AppType + ''''
	END

SET @SqlString = @SqlString + ' 
Group by year(AppDate)
	,month(AppDate)
	,AppType
	,isnull(grp.GroupName,'''')
	,isnull(grp.PK_GroupId,0)
	,isnull(clt.FirstName,'''')
	,isnull(clt.MiddleName,'''')
	,isnull(clt.FamilyName,'''')
ORDER BY year(AppDate)
	,month(AppDate)
	,AppType
	,isnull(grp.GroupName,'''')
	,isnull(clt.FirstName,'''')
'

--print @SqlString
exec sp_executesql @SqlString
;
