BEGIN TRANSACTION

DECLARE @Date datetime
	, @ClientId int
	, @Aantal int
	, @LessonTypeId int
	, @message varchar(80)
	, @ExtraCOunt int

/* Selecteert de startdatum van dit seizoen */
SELECT @Date = cast(ConfigValue as datetime) FROM tbl_Config
WHERE ConfigName = 'SeasonStart'
	AND (DateStop IS NULL OR DateStop > getdate())
	AND Active = 1

/* selecteert iedereen die dit seizoen lessen heeft, per lestype */
IF object_id('tempdb..#LessonsNew') IS NOT NULL DROP TABLE #LessonsNew

SELECT FK_ClientId, FK_LessonTypeId, count(*) as Aantal 
INTO #LessonsNew
FROM tbl_Appointment
WHERE AppDate >= @Date
	AND AppType <> 'Lock'
	AND FK_ClientId IS NOT NULL
GROUP BY FK_ClientId, FK_LessonTypeId
ORDER BY FK_ClientId, FK_LessonTypeId

/* werkt iedereen bij die dit seizoen geen lessen heeft maar wel een lessoncount, per lestype */
UPDATE tbl_ClientLevels
SET ExtraCount = LessonCount + ExtraCount, Lessoncount = 0
FROM (
SELECT clv.FK_ClientId, clv.FK_LessonTypeId FROM tbl_ClientLevels clv
LEFT OUTER JOIN #LessonsNew new
	ON clv.FK_ClientId = new.FK_ClientId
	AND clv.FK_LessonTypeId = new.FK_LessonTypeId
WHERE new.FK_ClientId IS NULL
	AND clv.[LessonCount] > 0
) coll
WHERE tbl_ClientLevels.FK_ClientId = coll.FK_ClientId
	AND tbl_ClientLevels.FK_LessonTypeId = coll.FK_LessonTypeId

/* werkt iedereen bij die dit seizoen lessen heeft, per lestype */
UPDATE clvl
SET ExtraCount = clvl.ExtraCount + clvl.LessonCount - new.Aantal, LessonCount = new.Aantal
FROM #LessonsNew new
INNER JOIN tbl_ClientLevels clvl
	ON new.FK_ClientId = clvl.FK_ClientId
	AND new.FK_LessonTypeId = clvl.FK_LessonTypeId

/* Maakt een lijst aan van ale mensen die lessen hebben dit seizoen en werkt ze 1 voor 1 af */
DECLARE Cursor1 CURSOR FOR
	SELECT  new.FK_ClientId, new.FK_LessonTypeId, new.Aantal, clvl.ExtraCount
	FROM #LessonsNew new
	INNER JOIN tbl_ClientLevels clvl
		ON new.FK_ClientId = clvl.FK_ClientId
		AND new.FK_LessonTypeId = clvl.FK_LessonTypeId

OPEN Cursor1
FETCH NEXT FROM Cursor1 into @ClientId, @LessonTypeId, @Aantal, @ExtraCount

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @AppId int, @RunTime int
	SET @RunTime = 1 -- Dit is het nieuwe lesnummer

	/* Haalt alle lessen op van deze persoon voor dit lestype en werkt ze 1 voor 1 af */
	DECLARE InnerCur CURSOR FOR
		SELECT PK_AppointmentId 
		FROM tbl_Appointment
		WHERE FK_ClientId = @ClientId
			AND FK_LessonTypeId = @LessonTypeId
			AND AppDate >= @Date
		ORDER BY AppDate, FK_TrackId

	OPEN InnerCur
	FETCH NEXT FROM InnerCur into @AppId

	WHILE @@FETCH_STATUS = 0
	BEGIN
		/* Werkt elke les bij met het nieuwe lesnummer en de ExtraLessen */
		UPDATE tbl_Appointment
		SET LessonCount = @RunTime, ExtraCount = @ExtraCount
		WHERE PK_AppointmentId = @AppId

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

--ROLLBACK
--COMMIT
