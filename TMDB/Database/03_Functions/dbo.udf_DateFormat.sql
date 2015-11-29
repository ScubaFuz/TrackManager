CREATE FUNCTION [dbo].[udf_DateFormat] (@Date smalldatetime,@IncludeTime bit = 1)
RETURNS varchar (100)
AS
-- *******************************************************************************
-- Author       : Bart Thieme
-- Purpose      : Format the Date and Time according to configsetting
-- *******************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	**************************************************
-- 1.0		2014-12-16	BT		Initial Version
-- *******************************************************************************

BEGIN
	DECLARE @DateFormat nvarchar(20)
	DECLARE @ReturnDate nvarchar(20)

	SELECT @DateFormat = [ConfigValue]
	FROM [dbo].[tbl_Config]
	WHERE [Category] = 'General'
		AND [ConfigName] = 'DateFormat'
		AND [Active] = 1

	IF @DateFormat IS NULL SET @DateFormat = 'yyyy-mm-dd'

	IF @DateFormat = 'yyyy-mm-dd'
		BEGIN
			SELECT @ReturnDate = COALESCE(CONVERT(nchar(10),@Date,120),'')
		END
	IF @DateFormat = 'dd-mm-yyyy'
		BEGIN
			SELECT @ReturnDate = COALESCE(CONVERT(nchar(10),@Date,105),'')
		END
	IF @DateFormat = 'mm/dd/yyyy'
		BEGIN
			SELECT @ReturnDate = COALESCE(CONVERT(nchar(10),@Date,101),'')
		END

	IF @IncludeTime = 1 SET @ReturnDate = @ReturnDate + ' ' + CONVERT(VARCHAR(5), @Date, 108)
	RETURN @ReturnDate
END
