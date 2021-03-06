CREATE PROCEDURE [dbo].[usp_ClientLessonLevelGet2]
	 @ClientID int
	,@LessonType varchar(50)
	,@SeasonStart datetime
	,@seasonEnd datetime
AS
-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	***********************************************
-- 1.0		2012-01-01	BT		Initial Version
-- 1.1		2013-09-08	BT		Added Active = 1
-- ****************************************************************************

SELECT cls.[FK_LevelID]
	,CASE WHEN GetDate() between @SeasonStart and @seasonEnd THEN cls.[LessonCount]
		ELSE (SELECT count(*) 
				FROM tbl_Appointment app 
				WHERE app.AppDate between @SeasonStart and @seasonEnd 
					AND app.FK_ClientID = cls.[FK_ClientID] 
					AND app.[FK_LessonTypeID] = cls.[FK_LessonTypeID]
					AND Active = 1)
		END AS [LessonCount]
	,cls.[ExtraCount]
	,lvs.[LevelName]
FROM [dbo].[tbl_ClientLevels] cls
LEFT OUTER JOIN  [dbo].[tbl_LessonTypes] lts
	ON cls.[FK_LessonTypeID] = lts.[PK_LessonTypeID]
	AND lts.[Active] = 1
LEFT OUTER JOIN  [dbo].[tbl_Levels] lvs
	ON cls.[FK_LevelID] = lvs.[PK_LevelID]
	AND lvs.[Active] = 1
WHERE cls.[Active] = 1
	AND cls.[FK_LessonTypeID] = (SELECT TOP 1 PK_LessonTypeId FROM [tbl_LessonTypes] WHERE LessonTypeName = @LessonType AND Active = 1)
	AND cls.[FK_ClientID] = @ClientID
;



