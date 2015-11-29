CREATE FUNCTION [dbo].[udf_EmailPrefix] (@Email varchar (100))
RETURNS varchar (100)
AS
-- *****************************************************************************
-- Auteur       : Bart Thieme
-- Doel         : Give name of email address
-- *****************************************************************************
-- Versie Datum    Auteur Beschrijving
-- ****** ******** ****** ******************************************************
-- 01     20120125 BT     Nieuw
-- *****************************************************************************

BEGIN
RETURN (LEFT(@Email, charindex('@', @Email+'@')-1))
END

