CREATE PROCEDURE [dbo].[usp_LanguageListGet]
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	retrieve a list of available Languages
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	*********************************************
-- 1.0		2013-10-10	BT		Eerste versie
-- ****************************************************************************

SELECT DISTINCT [Language]
FROM [dbo].[tbl_Language]
ORDER BY [Language]
;
