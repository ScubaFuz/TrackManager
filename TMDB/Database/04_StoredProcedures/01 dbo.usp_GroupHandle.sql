CREATE PROCEDURE [dbo].[usp_GroupHandle]
	@Action nchar(3),
	@GroupId bigint = NULL,
	@GroupName nvarchar(50) = NULL
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
		UPDATE [dbo].[tbl_Groups]
		   SET [GroupName] = @GroupName
		 WHERE [PK_GroupId] = @GroupId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Groups]
				   ([PK_GroupId]
				   ,[GroupName])
			 VALUES
				   (@GroupId
				   ,@GroupName)
	END

IF @Action = 'Get'
	BEGIN
		--IF @GroupId IS NULL OR @GroupId = 0
		--	BEGIN
				SELECT [PK_GroupId]
					  ,[GroupName]
				FROM [dbo].[tbl_Groups]
				WHERE [Active] = 1
					AND ISNULL(@GroupId,0) IN ([PK_GroupId],0)
				ORDER BY [GroupName],[PK_GroupId]
		--	END
		--ELSE
		--	IF @GroupId > 0
		--		BEGIN
		--			SELECT [PK_GroupId]
		--				  ,[GroupName]
		--			FROM [dbo].[tbl_Groups]
		--			WHERE [PK_GroupId] = @GroupId
		--			AND [Active] = 1
		--		END
	END

IF @Action = 'Top'
	BEGIN
		SELECT TOP 1 [PK_GroupId]
			  ,[GroupName]
		FROM [dbo].[tbl_Groups]
		WHERE [Active] = 1
			AND ISNULL(@GroupId,0) IN ([PK_GroupId],0)
		ORDER BY [PK_GroupId] DESC
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@GroupId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Groups]
				SET [Active] = 0
				WHERE [PK_GroupId] = @GroupId
			END
	END
;
