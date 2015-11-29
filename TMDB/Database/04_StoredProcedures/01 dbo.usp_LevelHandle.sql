CREATE PROCEDURE [dbo].[usp_LevelHandle]
	@Action nchar(3),
	@LevelId int = NULL,
	@LevelName nvarchar(50) = NULL,
	@LevelColor nvarchar(50) = NULL,
	@LevelCount int = NULL
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
		IF ISNULL(@LevelId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Levels]
				   SET [LevelName] = @LevelName
					  ,[Color] = @LevelColor
					  ,[LevelCount] = @LevelCount
				 WHERE [PK_LevelId] = @LevelId
			 END
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Levels]
				   ([LevelName]
				   ,[Color]
				   ,[LevelCount])
			 VALUES
				   (@LevelName
				   ,@LevelColor
				   ,@LevelCount)
	END

IF @Action = 'Get'
	BEGIN
		--IF ISNULL(@LevelId,0) = 0 AND isnull(@LevelName,'') = ''
		--	BEGIN
		SELECT [PK_LevelID]
			,[LevelName]
			,[Color]
			,[LevelCount]
		FROM [dbo].[tbl_Levels]
		WHERE [Active] = 1
			AND ISNULL(@LevelId,0) IN ([PK_LevelID],0)
			AND isnull(@LevelName,'') IN ([LevelName],'')
		ORDER BY [LevelCount]
		--	END
		--IF ISNULL(@LevelId,0) = 0 AND LEN(@LevelName) > 0
		--	BEGIN
		--		SELECT [PK_LevelID]
		--			  ,[LevelName]
		--			  ,[Color]
		--			  ,[LevelCount]
		--		 FROM [dbo].[tbl_Levels]
		--		WHERE [LevelName] = @LevelName
		--		  AND [Active] = 1
		--	END
		--IF @LevelId > 0
		--	BEGIN
		--		SELECT [PK_LevelID]
		--			  ,[LevelName]
		--			  ,[Color]
		--			  ,[LevelCount]
		--		 FROM [dbo].[tbl_Levels]
		--		WHERE [PK_LevelID] = @LevelId
		--		  --AND [Active] = 1
		--	END
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@LevelId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Levels]
				SET [Active] = 0
				WHERE [PK_LevelID] = @LevelId
			END
	END
;
