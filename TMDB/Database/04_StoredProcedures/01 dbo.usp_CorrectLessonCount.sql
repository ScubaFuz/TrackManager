CREATE PROCEDURE dbo.usp_CorrectLessonCount
	@StartDate DateTime,
	@EndDate DateTime,
	@GroupID BigInt = 0,
	@ClientID Int = 0
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2012-02-17	BT		Initial Version
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- ****************************************************************************

DECLARE @Aantal int,
	@LessonTypeId int,
	@message varchar(80),
	@ExtraCOunt int

/* selecteert iedereen die dit seizoen lessen heeft, per lestype */
IF object_id('tempdb..#LessonsNew') IS NOT NULL DROP TABLE #LessonsNew

SELECT app.FK_ClientId, app.FK_LessonTypeId, count(*) as Aantal 
INTO #LessonsNew
FROM tbl_Appointment app
INNER JOIN tbl_Clients cls
	ON app.FK_ClientId = cls.PK_ClientID
WHERE app.AppDate BETWEEN @StartDate And @EndDate
	AND AppType <> 'Lock'
	AND FK_ClientId IS NOT NULL
	AND @GroupID IN (cls.FK_GroupID,0)
	AND @ClientID IN (app.FK_ClientId,0)
	AND app.[Active] = 1
GROUP BY app.FK_ClientId, app.FK_LessonTypeId
ORDER BY app.FK_ClientId, app.FK_LessonTypeId

--SELECT * FROM #LessonsNew

/* werkt iedereen bij die dit seizoen geen lessen heeft maar wel een lessoncount, per lestype */
UPDATE tbl_ClientLevels
SET [ExtraCount] = [LessonCount] + [ExtraCount], [Lessoncount] = 0
FROM (
	SELECT clv.[FK_ClientId], clv.[FK_LessonTypeId] 
	FROM [tbl_ClientLevels] clv
	INNER JOIN [tbl_Clients] cls
		ON clv.[FK_ClientID] = cls.[PK_ClientID]
	LEFT OUTER JOIN #LessonsNew new
		ON clv.[FK_ClientId] = new.[FK_ClientId]
		AND clv.[FK_LessonTypeId] = new.[FK_LessonTypeId]
	WHERE @GroupID IN (cls.[FK_GroupID],0)
		AND @ClientID IN (clv.[FK_ClientId],0)
		AND new.[FK_ClientId] IS NULL
		AND clv.[LessonCount] > 0
		AND clv.[Active] = 1
) coll
WHERE [tbl_ClientLevels].[FK_ClientId] = coll.[FK_ClientId]
	AND [tbl_ClientLevels].[FK_LessonTypeId] = coll.[FK_LessonTypeId]


/* werkt iedereen bij die dit seizoen lessen heeft, per lestype */
UPDATE clvl
SET [ExtraCount] = clvl.[ExtraCount] + CASE WHEN(clvl.[LessonCount] - new.[Aantal] < 0) THEN 0 ELSE clvl.[LessonCount] - new.[Aantal] END, [LessonCount] = new.[Aantal]
FROM #LessonsNew new
INNER JOIN [tbl_ClientLevels] clvl
	ON new.[FK_ClientId] = clvl.[FK_ClientId]
	AND new.[FK_LessonTypeId] = clvl.[FK_LessonTypeId]
	AND clvl.[Active] = 1


/* Maakt een lijst aan van ale mensen die lessen hebben dit seizoen en werkt ze 1 voor 1 af */
DECLARE Cursor1 CURSOR FOR
	SELECT  new.[FK_ClientId], new.[FK_LessonTypeId], new.[Aantal], clvl.[ExtraCount]
	FROM #LessonsNew new
	INNER JOIN [tbl_ClientLevels] clvl
		ON new.[FK_ClientId] = clvl.[FK_ClientId]
		AND new.[FK_LessonTypeId] = clvl.[FK_LessonTypeId]
		AND clvl.[Active] = 1

OPEN Cursor1
FETCH NEXT FROM Cursor1 into @ClientId, @LessonTypeId, @Aantal, @ExtraCount

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @AppId int, @RunTime int
	SET @RunTime = 1 -- Dit is het nieuwe lesnummer

	/* Haalt alle lessen op van deze persoon voor dit lestype en werkt ze 1 voor 1 af */
	DECLARE InnerCur CURSOR FOR
		SELECT app.[PK_AppointmentId]
		FROM [tbl_Appointment] app
		WHERE app.[FK_ClientId] = @ClientId
			AND app.[FK_LessonTypeId] = @LessonTypeId
			AND app.[AppDate] BETWEEN @StartDate And @EndDate
			AND app.[Active] = 1
		ORDER BY app.[AppDate], app.[FK_TrackId]

	OPEN InnerCur
	FETCH NEXT FROM InnerCur into @AppId

	WHILE @@FETCH_STATUS = 0
	BEGIN
		/* Werkt elke les bij met het nieuwe lesnummer en de ExtraLessen */
		UPDATE [tbl_Appointment]
		SET [LessonCount] = @RunTime, [ExtraCount] = @ExtraCount
		WHERE [PK_AppointmentId] = @AppId

		/* Lesnummer met 1 ophogen en volgende les zoeken */ 
		SET @RunTime = @RunTime + 1
		FETCH NEXT FROM InnerCur into @AppId
	END

	CLOSE InnerCur
	DEALLOCATE InnerCur
	/* volgense persoon / Lestype nemen */
	FETCH NEXT FROM Cursor1 into @ClientId, @LessonTypeId, @Aantal, @ExtraCount
END

CLOSE Cursor1
DEALLOCATE Cursor1
