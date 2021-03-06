CREATE FUNCTION [dbo].[udf_GetAge] (@DOB smalldatetime, @CompareDate smalldatetime)
RETURNS smallint
AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Return Age based on Date Of Birth and comparison date
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2013-11-08	BT		Initial Version
-- ****************************************************************************

BEGIN
	DECLARE @Age int = 0
 
	Select @Age =
	CASE
		WHEN DATEADD(YY, DATEDIFF(YY, @DOB , @CompareDate),  @DOB )  > @CompareDate
		THEN DATEDIFF(YY, @DOB , @CompareDate) - 1
		ELSE DATEDIFF(YY, @DOB , @CompareDate)
	END
	RETURN @Age
END
