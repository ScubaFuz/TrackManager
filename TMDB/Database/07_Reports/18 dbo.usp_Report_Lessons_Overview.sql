CREATE PROCEDURE [dbo].[usp_Report_Lessons_Overview]
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
SELECT ROW_NUMBER() OVER(ORDER BY app.AppDate, trk.TrackName, grp.GroupName) AS RowNumber
	, left(dbo.udf_Weekday(app.AppDate,''NL'') ,2) + '' '' + isnull(convert(nchar(16),app.AppDate,120),'''') AS AppDate
	, LTRIM(RTRIM(isnull(clt.FirstName,''''))) + 
		CASE WHEN LTRIM(RTRIM(isnull(clt.MiddleName,''''))) = '''' THEN '''' ELSE '' '' + LTRIM(RTRIM(isnull(clt.MiddleName,''''))) END +
		CASE WHEN LTRIM(RTRIM(isnull(clt.FamilyName,''''))) = '''' THEN '''' ELSE '' '' + LTRIM(RTRIM(isnull(clt.FamilyName,''''))) END
		AS Name
	, isnull(app.LessonCount,'''') AS LessonCount
	, isnull(mem.MemoText,'''') AS MemoText
FROM  dbo.tbl_Appointment app
INNER JOIN dbo.tbl_Clients clt
	ON app.FK_ClientId = clt.PK_ClientID 
INNER JOIN dbo.tbl_LessonTypes lts
	ON app.FK_LessonTypeId = lts.PK_LessonTypeID 
INNER JOIN dbo.tbl_Levels lvl
	ON app.FK_LevelId = lvl.PK_LevelID 
LEFT OUTER JOIN dbo.tbl_Tracks trk
	ON app.FK_TrackId = trk.PK_TrackID 
LEFT OUTER JOIN [dbo].[tbl_Memo] mem
	ON mem.[FK_GroupId] = clt.[PK_ClientID]
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE app.Active = 1
'

IF @DateStop IS NULL
	BEGIN
		SET @SqlString = @SqlString + ' AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) = ''' + CONVERT(nvarchar(8),@DateStart,112) + ''''
	END
ELSE
	BEGIN
		SET @SqlString = @SqlString + ' AND CAST(FLOOR(CAST(app.AppDate AS float)) AS datetime) BETWEEN ''' + CONVERT(nvarchar(8),@DateStart,112) + ''' AND ''' + CONVERT(nvarchar(8),@DateStop,112) + ''''
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

SET @SqlString = @SqlString + ' ORDER BY app.AppDate, clt.FirstName'

exec sp_executesql @SqlString
;
