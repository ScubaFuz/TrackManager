CREATE PROCEDURE [dbo].[usp_ProductHandle]
	@Action nchar(3),
	@ProductId int = NULL,
	@ProductText nvarchar(250) = NULL,
	@ProductCount int = NULL,
	@ProductAmount numeric(10,2) = NULL,
	@Tax int = 0,
	@Sort tinyint = 0
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
		UPDATE [dbo].[tbl_Products]
		   SET [ProductText] = @ProductText
			  ,[ProductCount] = @ProductCount
			  ,[ProductAmount] = @ProductAmount
			  ,[Tax] = @Tax
			  ,[Sort] = @Sort
		 WHERE [PK_ProductId] = @ProductId
	END

IF @Action = 'Ins'
	BEGIN
		IF @Sort = 0 
			BEGIN
				SELECT @Sort = (Max([Sort]) + 1) FROM [dbo].[tbl_Products]
			END
		INSERT INTO [dbo].[tbl_Products]
				   ([ProductText]
				   ,[ProductCount]
				   ,[ProductAmount]
				   ,[Tax]
				   ,[Sort])
			 VALUES
				   (@ProductText
				   ,@ProductCount
				   ,@ProductAmount
				   ,@Tax
				   ,@Sort)
	END

IF @Action = 'Get'
	BEGIN
		--IF ISNULL(@ProductId,0) = 0
		--	BEGIN
				SELECT [PK_ProductID]
					  ,[ProductText]
					  ,[ProductCount]
					  ,[ProductAmount]
					  ,[Tax]
					  ,isnull([Sort],0) AS [Sort]
				  FROM [dbo].[tbl_Products]
				 WHERE [Active] = 1
					AND ISNULL(@ProductId,0) IN ([PK_ProductID],0)
			  ORDER BY [Sort],[PK_ProductID]
		--	END
		--ELSE
		--	IF @ProductId > 0
		--		BEGIN
		--			SELECT [PK_ProductID]
		--				  ,[ProductText]
		--				  ,[ProductCount]
		--				  ,[ProductAmount]
		--				  ,[Tax]
		--				  ,isnull([Sort],0) AS [Sort]
		--			  FROM [dbo].[tbl_Products]
		--			 WHERE [PK_ProductID] = @ProductId
		--		 	   AND [Active] = 1
	 --			  ORDER BY [Sort],[PK_ProductID]
		--		END
	END

IF @Action = 'Del'
	BEGIN
		IF NOT (@ProductId IS NULL OR @ProductId = 0)
			BEGIN
				UPDATE [dbo].[tbl_Products]
				SET [Active] = 0
				WHERE [PK_ProductID] = @ProductId
			END
	END
;
