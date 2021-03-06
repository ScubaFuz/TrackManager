CREATE FUNCTION [dbo].[udf_Weekday](

  @DateStamp datetime,
  @Language Char(2)
)
  returns varchar(20)
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Weekday based on date
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2009-12-08	BT		Initial Version
-- 2.0		2013-10-12	BT		Added Language table
-- ****************************************************************************

BEGIN
	DECLARE @Weekday varchar(20)

	SELECT @Weekday = [LanguageText]
	FROM [dbo].[tbl_Language]
	WHERE [LanguageItem] = datepart(dw,@DateStamp)
		AND [Language] = @Language
		AND [LanguageType] = 'WeekDays'
		AND [LanguageForm] = 'Properties'

	IF @Weekday IS NULL
		BEGIN
			SELECT @Weekday = ConfigValue
			FROM   tbl_Config 
			WHERE  Category = 'Weekdays'
				AND  ConfigName = datepart(dw,@DateStamp)
				AND  Remarks = 'EN'
		END

	RETURN @Weekday
END
;


