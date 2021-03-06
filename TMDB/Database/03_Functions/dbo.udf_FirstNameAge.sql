CREATE FUNCTION [dbo].[udf_FirstNameAge] (@FirstName nvarchar(50), @DayOfBirth smalldatetime, @CompareDate smalldatetime, @ShowAge int)
RETURNS nvarchar(54)
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Return FirstName with Age
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2013-11-23	BT		Initial Version
-- ****************************************************************************

BEGIN
	DECLARE @FirstNameAge as nvarchar(54)
	SET @FirstNameAge = @FirstName

	DECLARE @Age int
	SET @Age = dbo.udf_GetAge(@DayOfBirth,@CompareDate)

	IF @DayOfBirth IS NULL OR @CompareDate IS NULL OR @ShowAge = 0 RETURN @FirstNameAge

	SELECT @FirstNameAge =
		CASE 
		WHEN MONTH(@DayOfBirth)-MONTH(@CompareDate) = 0 AND DAY(@DayOfBirth)-DAY(@CompareDate) = 0 
				THEN '*' + CAST(@Age AS nvarchar(3)) + ' ' + @FirstName
			WHEN @Age < @ShowAge AND @ShowAge > 0 
				THEN CAST(@Age AS nvarchar(3)) + ' ' + @FirstName
			WHEN @Age < (@ShowAge * -1) AND @ShowAge < 0 
				THEN @FirstName + ' ' + CAST(@Age AS nvarchar(3))
			ELSE @FirstName
		 END 
	RETURN @FirstNameAge
END
