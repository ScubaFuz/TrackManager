CREATE FUNCTION [dbo].[udf_GetShowAge] ()
RETURNS int

AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Get the ShowAge Setting
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2014-11-23	BT		Initial Version
-- ****************************************************************************

BEGIN
	DECLARE @nShowAge nvarchar(100), @nShowAgeMax nvarchar(100), @nShowAgeAfter nvarchar(100), @ShowAge int, @ShowAgeMax int, @ShowAgeAfter int, @Today smalldatetime
	SELECT @nShowAge = ConfigValue FROM tbl_Config WHERE ConfigName = 'ShowAge' AND [Category] = 'ScreenView'
	SELECT @nShowAgeMax = ConfigValue FROM tbl_Config WHERE ConfigName = 'ShowAgeMax' AND [Category] = 'ScreenView'
	SELECT @nShowAgeAfter = ConfigValue FROM tbl_Config WHERE ConfigName = 'ShowAgeAfter' AND [Category] = 'ScreenView'

	SELECT @ShowAge = 
			CASE @nShowAge
			WHEN 'True' Then 
				@nShowAgeMax *
				CASE @nShowAgeAfter
				WHEN 'True' Then 
					-1
				ELSE 1
				END
			ELSE 0
			END
	RETURN @ShowAge
END
