CREATE FUNCTION [dbo].[udf_ValidEmail] (@Email varchar (100))
RETURNS BIT
AS
-- *****************************************************************************
-- Auteur       : Bart Thieme
-- Doel         : Filter valid email adresses
-- *****************************************************************************
-- Versie Datum    Auteur Beschrijving
-- ****** ******** ****** ******************************************************
-- 01     20120125 BT     Nieuw
-- *****************************************************************************

BEGIN
	DECLARE @atpos int, @dotpos int

	SET @Email = LTRIM(RTRIM(@Email)) -- remove leading and trailing blanks
	IF LEN(@Email) = 0 RETURN(0) -- nothing to validate

	IF CHARINDEX(' ',@Email) > 0  -- Embedded blanks are illegal
	or patindex ('%`[ &'',":;!+=\/()<>]%', @Email) > 0  -- Invalid characters
	or patindex ('[@.-_]%', @Email) > 0   -- Valid but cannot be starting character
	or patindex ('%[@.-_]', @Email) > 0   -- Valid but cannot be ending character
	or @Email not like '%@%.%'   -- Must contain at least one @ and one .
	or @Email like '%..%'        -- Cannot have two periods in a row
	or @Email like '%@%@%'       -- Cannot have two @ anywhere
	or @Email like '%.@%' or @Email like '%@.%' -- Cant have @ and . next to each other
	or @Email like '%.cm' or @Email like '%.co' -- Unlikely. Probably typos 
	or @Email like '%.or' or @Email like '%.ne' -- Missing last letter
	RETURN(0)

	SET @atpos = charindex('@',@Email) -- position of first (hopefully only) @
	SET @dotpos = CHARINDEX('.',REVERSE(@Email)) -- location (from rear) of last dot
	IF (@dotpos < 3) or (@dotpos > 4) or (LEN(@Email) - @dotpos) < @atpos RETURN (0) -- dot / 2 or 3 char, after @

	RETURN(1) -- Whew !!
END
;
