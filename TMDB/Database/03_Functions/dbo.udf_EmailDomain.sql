CREATE FUNCTION [dbo].[udf_EmailDomain] (@Email varchar (100))
RETURNS varchar (100)
AS
-- *****************************************************************************
-- Auteur       : Bart Thieme
-- Doel         : Give domain of email address
-- *****************************************************************************
-- Versie Datum    Auteur Beschrijving
-- ****** ******** ****** ******************************************************
-- 01     20091208 BT     Nieuw
-- *****************************************************************************

BEGIN
RETURN (SUBSTRING(@Email, charindex('@', @Email+'@')+1, LEN(@Email)))
END

