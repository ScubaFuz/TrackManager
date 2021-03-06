CREATE FUNCTION [dbo].[udf_GetSeason] (@RunDate date)
RETURNS @SeasonDates TABLE (
	SeasonStart date NOT NULL,
	SeasonEnd date NOT NULL)

AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Get the ShowAge Setting
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2018-11-20	BT		Initial Version
-- ****************************************************************************

BEGIN

SET @RunDate = NULLIF(@RunDate,'')

DECLARE @SeasonStart date
	,@SeasonEnd date
	,@SeasonLengthN nvarchar(10)
	,@SeasonLength int
	 
SELECT @SeasonStart = [ConfigValue]
FROM [TrackManager].[dbo].[tbl_Config]
WHERE [Active] = 1
	AND [Category] = 'General' 
	AND [ConfigName] = 'SeasonStart';

SELECT @SeasonLengthN = [ConfigValue]
FROM [TrackManager].[dbo].[tbl_Config]
WHERE [Active] = 1
	AND [Category] = 'General' 
	AND [ConfigName] = 'SeasonLength';

SELECT @SeasonLength = 
	CASE @SeasonLengthN
		WHEN 'Year' THEN 12
		WHEN '6 Months' THEN 6
		WHEN 'Quarter' THEN 3
		WHEN 'Month' THEN 1
	END

SELECT @SeasonEnd = DATEADD(DAY,-1,DATEADD(MONTH,@SeasonLength,@SeasonStart));


WHILE @RunDate < @SeasonStart OR @RunDate > @SeasonEnd
	BEGIN
		IF @RunDate < @SeasonStart 
			BEGIN
				SET @SeasonStart = DATEADD(MONTH,(@SeasonLength * -1),@SeasonStart)
				SET @SeasonEnd = DATEADD(MONTH,(@SeasonLength * -1),@SeasonEnd)
			END
		ELSE IF @RunDate > @SeasonEnd 
			BEGIN
				SET @SeasonStart = DATEADD(MONTH,@SeasonLength,@SeasonStart)
				SET @SeasonEnd = DATEADD(MONTH,@SeasonLength,@SeasonEnd)
			END
	END;

INSERT INTO @SeasonDates (SeasonStart,SeasonEnd)
SELECT @SeasonStart , @SeasonEnd;

RETURN;


END
;
