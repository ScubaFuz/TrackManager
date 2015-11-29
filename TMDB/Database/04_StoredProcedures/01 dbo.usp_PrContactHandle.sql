CREATE PROCEDURE [dbo].[usp_PrContactHandle]
	@Action nchar(3),
	@PrContactId int = NULL,
	@PrContactName nvarchar(50) = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_PrContacts]
		   SET [PrContactName] = @PrContactName
		 WHERE [PK_PrContactID] = @PrContactId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_PrContacts]
				   ([PrContactName])
			 VALUES
				   (@PrContactName)
	END

IF @Action = 'Get'
	BEGIN
		--IF isnull(@PrContactId,0) = 0
		--	BEGIN
		SELECT [PK_PrContactID]
			,[PrContactName]
		FROM [dbo].[tbl_PrContacts]
		WHERE [Active] = 1
			AND isnull(@PrContactId,0) IN ([PK_PrContactID],0)
		--	END
		--ELSE
		--	IF @PrContactId > 0
		--		BEGIN
		--			SELECT [PK_PrContactID]
		--				  ,[PrContactName]
		--			  FROM [dbo].[tbl_PrContacts]
		--			 WHERE [PK_PrContactID] = @PrContactId
		--			   AND [Active] = 1
		--		END
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@PrContactId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_PrContacts]
				SET [Active] = 0
				WHERE [PK_PrContactID] = @PrContactId
			END
	END
;
