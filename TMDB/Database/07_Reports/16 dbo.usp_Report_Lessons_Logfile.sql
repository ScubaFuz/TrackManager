CREATE PROCEDURE [dbo].[usp_Report_Lessons_Logfile]
	 @DateStart datetime 
	 ,@DateStop datetime = NULL
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		Rapport over Logregels in de databse.
-- ****************************************************************************
-- Versie  Datum       Auteur     Beschrijving
-- ******  **********  *********  *********************************************
-- 01      2012-02-10  BT         Eerste versie

-- ****************************************************************************

EXEC dbo.usp_LoggingHandle 'Get',@DateStart

