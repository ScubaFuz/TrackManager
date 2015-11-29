CREATE PROCEDURE [dbo].[usp_PrimaryContactSet]
	@GroupID bigint
	,@ClientId int

AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 01		2010-01-01	BT		Eerste versie
-- 02		
-- ****************************************************************************

UPDATE tbl_Clients
  SET [PrimaryContact] = 0 
WHERE [FK_GroupId] = @GroupId
  AND [Active] = 1

UPDATE tbl_Clients
  SET [Primarycontact] = 1
WHERE [FK_GroupId] = @GroupId
  AND [PK_ClientId] = @ClientId
  AND [Active] = 1
;
