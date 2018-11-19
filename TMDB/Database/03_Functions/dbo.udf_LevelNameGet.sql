CREATE FUNCTION [dbo].[udf_LevelnameGet] 
	(@LevelCount int)
RETURNS varchar(50)
AS 
-- *****************************************************************************
-- Auteur       : Bart Thieme
-- Doel         : Select correct Level Color
-- *****************************************************************************
-- Versie Datum    Auteur Beschrijving
-- ****** ******** ****** ******************************************************
-- 01     20181117 BT     Nieuw
-- *****************************************************************************

BEGIN
	DECLARE @LevelName varchar(50)

	SELECT @LevelName = [LevelName]
	FROM [dbo].[tbl_Levels]
	WHERE [LevelCount] = (SELECT isnull(max([LevelCount]),(SELECT min([LevelCount]) FROM [dbo].[tbl_Levels])) 
							FROM [dbo].[tbl_Levels]
							WHERE [LevelCount] <= @LevelCount
								AND [Active] = 1)
	RETURN @LevelName
END
;
