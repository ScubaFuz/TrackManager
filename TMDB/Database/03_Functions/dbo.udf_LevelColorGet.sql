CREATE FUNCTION [dbo].[udf_LevelColorGet] 
	(@LevelCount int)
RETURNS varchar(50)
AS 
-- *****************************************************************************
-- Auteur       : Bart Thieme
-- Doel         : Select correct Level Color
-- *****************************************************************************
-- Versie Datum    Auteur Beschrijving
-- ****** ******** ****** ******************************************************
-- 01     20091208 BT     Nieuw
-- *****************************************************************************

BEGIN
	DECLARE @LevelColor varchar(50)

	SELECT @LevelColor = [Color]
	FROM [dbo].[tbl_Levels]
	WHERE [LevelCount] = (SELECT isnull(max([LevelCount]),(SELECT min([LevelCount]) FROM [dbo].[tbl_Levels])) 
							FROM [dbo].[tbl_Levels]
							WHERE [LevelCount] <= @LevelCount
								AND [Active] = 1)
	RETURN @LevelColor
END
;
