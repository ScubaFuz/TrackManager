CREATE PROCEDURE [dbo].[usp_Report_Lessons_Afspraken]
	@DateStart datetime 
	,@DateStop datetime = NULL
	,@ClientId int = 0
	,@GroupId bigint = 0
	,@TrackId int = 0
	,@AppType nvarchar(10) = NULL

AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Standaard Rapport over lessen
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2010-01-01  BT         Eerste versie

-- ****************************************************************************

DECLARE @SqlString nvarchar(2000)

SET @SqlString = '
SELECT isnull(convert(nvarchar(16),app.AppDate,120),'''') AS AppDate
	, isnull(trk.TrackName,'''') AS TrackName
	, isnull(grp.GroupName,'''') AS GroupName
	, isnull(grp.PK_GroupId,0) AS GroupId
	, isnull(clt.FirstName,'''') AS FirstName
	, isnull(clt.MiddleName,'''') AS MiddleName
	, isnull(clt.FamilyName,'''') AS FamilyName
	, isnull(lts.LessonTypeName,'''') AS LessonTypeName
	, isnull(app.LessonCount,'''') AS LessonCount
	, isnull(app.AppType,'''') AS AppType
	, isnull(app.ExtraCount,'''') AS ExtraCount
	, isnull(lvl.LevelName,'''') AS LevelName
FROM  dbo.tbl_Appointment app
INNER JOIN dbo.tbl_Clients clt
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_LessonTypes lts
	ON app.FK_LessonTypeId = lts.PK_LessonTypeID 
INNER JOIN dbo.tbl_Levels lvl
	ON app.FK_LevelId = lvl.PK_LevelID 
INNER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.[Active] = 1
'

IF @DateStop IS NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) = ''' + CONVERT(nvarchar(8),@DateStart,112) + ''''
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

IF @TrackId > 0
	BEGIN
		SET @SqlString = @SqlString + ' AND trk.PK_TrackId = ' + CAST(@trackId AS nvarchar(10))
	END

IF @AppType IS NOT NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND app.AppType = ''' + @AppType + ''''
	END

SET @SqlString = @SqlString + ' ORDER BY app.AppDate, trk.TrackName, grp.GroupName '

exec sp_executesql @SqlString
;
