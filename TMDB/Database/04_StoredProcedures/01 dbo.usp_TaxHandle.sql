CREATE PROCEDURE [dbo].[usp_TaxHandle]
	@Action nchar(3),
	@Tax_ID int = NULL,
	@Tax int = NULL,
	@Description nvarchar(100) = NULL
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
		UPDATE [dbo].[tbl_Tax]
		   SET TaxValue = @Tax
				,[TaxDescription] = @Description
		 WHERE [PK_Tax] = @Tax_ID
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Tax]
				   ([TaxValue]
				   ,[TaxDescription])
			 VALUES
				   (@Tax
				   ,@Description)
	END

IF @Action = 'Get'
	BEGIN
		--IF @Tax_ID IS NULL
		--	BEGIN
		--		SELECT [PK_Tax]
		--			,[Taxvalue]
		--			,[TaxDescription]
		--		FROM [dbo].[tbl_Tax]
		--		WHERE [Active] = 1
		--	END
		--ELSE
		--	BEGIN
				SELECT [PK_Tax]
					,[TaxValue]
					,[TaxDescription]
				FROM [dbo].[tbl_Tax]
				WHERE ISNULL(@Tax_ID,0) IN ([PK_Tax],0) 
					AND [Active] = 1
			--END
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@Tax_ID,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Tax]
				SET [Active] = 0
				WHERE [PK_Tax] = @Tax_ID
			END
	END
;
