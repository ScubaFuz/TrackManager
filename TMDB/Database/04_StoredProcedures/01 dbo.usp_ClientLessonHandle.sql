CREATE PROCEDURE [dbo].[usp_ClientLessonHandle]
	@Action nchar(3)
	,@ClientLevelID int = NULL
	,@ClientID int = NULL
	,@GroupID bigint = NULL
	,@LessonTypeID int = NULL
	,@LevelID int = NULL
	,@LessonCount int = NULL
	,@ExtraCount int = NULL
	,@PrimaryType bit = NULL
	,@LastAction int = NULL
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
		--IF ISNULL(@ClientLevelID,0) = 0 AND @ClientId > 0 AND @LessonTypeID > 0
		--	BEGIN
		UPDATE [dbo].[tbl_ClientLevels]
		SET [FK_LevelID] = @LevelID
			,[LessonCount] = @LessonCount
			,[ExtraCount] = @ExtraCount
			,[PrimaryType] = @PrimaryType
			,[LastAction] = @LastAction
		WHERE [Active] = 1
			AND ISNULL(@clientId,0) IN ([FK_ClientID],0)
			AND ISNULL(@LessonTypeID,0) IN ([FK_LessonTypeID],0)
			AND ISNULL(@ClientLevelID,0) IN ([PK_ClientLevelID],0)
		--	END
		--IF @ClientLevelID > 0
		--	BEGIN
		--		UPDATE [dbo].[tbl_ClientLevels]
		--		   SET [FK_LevelID] = @LevelID
		--			  ,[LessonCount] = @LessonCount
		--			  ,[ExtraCount] = @ExtraCount
		--			  ,[PrimaryType] = @PrimaryType
		--			  ,[LastAction] = @LastAction
		--		 WHERE [PK_ClientLevelID] = @ClientLevelID
		--	END
	END

IF @Action = 'Smt'
	BEGIN
		UPDATE [dbo].[tbl_ClientLevels]
		   SET [PrimaryType] = 0
		 WHERE [FK_ClientID] = @clientId

		DECLARE @Count AS integer
		 SELECT @Count = Count([PK_ClientLevelID])
		   FROM [dbo].[tbl_ClientLevels]
		  WHERE [FK_ClientID] = @clientId
		    AND [FK_LessonTypeID] = @LessonTypeID
			AND [Active] = 1

		IF @Count > 0 
			BEGIN
				EXEC [usp_ClientLessonHandle] 'Upd'
					,@ClientLevelID
					,@ClientID
					,@GroupID
					,@LessonTypeID
					,@LevelID
					,@LessonCount
					,@ExtraCount
					,@PrimaryType
					,@LastAction
			END
		ELSE
			BEGIN
				EXEC [usp_ClientLessonHandle] 'Ins'
					,@ClientLevelID
					,@ClientID
					,@GroupID
					,@LessonTypeID
					,@LevelID
					,@LessonCount
					,@ExtraCount
					,@PrimaryType
					,@LastAction
			END
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_ClientLevels]
				   ([FK_ClientID]
				   ,[FK_LessonTypeID]
				   ,[FK_LevelID]
				   ,[LessonCount]
				   ,[ExtraCount]
				   ,[PrimaryType]
				   ,[LastAction])
			 VALUES
					(@ClientID
					,@LessonTypeID
					,@LevelID
					,@LessonCount
					,@ExtraCount
					,@PrimaryType
					,@LastAction)
	END

IF @Action = 'Get'
	BEGIN
		--IF ISNULL(@GroupID,0) = 0
		--	BEGIN
				SELECT cls.[PK_ClientLevelID]
					,cls.[FK_ClientID]
					,cls.[FK_LessonTypeID]
					,cls.[FK_LevelID]
					,cls.[LessonCount]
					,cls.[ExtraCount]
					,cls.[PrimaryType]
					,cls.[LastAction]
				FROM [dbo].[tbl_ClientLevels] cls
				INNER JOIN tbl_Clients cnt
					ON cls.[FK_ClientID] = cnt.[PK_ClientID]
					AND cnt.[Active] = 1
				WHERE cls.[Active] = 1
					AND ISNULL(@ClientID,0) IN (cls.[FK_ClientID],0)
					AND ISNULL(@ClientLevelID,0) IN (cls.[PK_ClientLevelID],0)
					AND ISNULL(@GroupID,0) IN (cnt.[FK_GroupID],0)
		--	END
		--IF ISNULL(@ClientLevelID,0) = 0 AND ISNULL(@ClientID,0) = 0 AND ISNULL(@GroupID,0) > 0
		--		BEGIN
		--			SELECT [PK_ClientLevelID]
		--				  ,[FK_ClientID]
		--				  ,[FK_LessonTypeID]
		--				  ,[FK_LevelID]
		--				  ,[LessonCount]
		--				  ,[ExtraCount]
		--				  ,[PrimaryType]
		--				  ,[LastAction]
		--			  FROM [dbo].[tbl_ClientLevels] cls
		--			INNER JOIN tbl_Clients cnt
		--				ON cls.[FK_ClientID] = cnt.[PK_ClientID]
		--				AND cnt.[Active] = 1
		--			WHERE cnt.[FK_GroupID] = @GroupID
		--			  AND cls.[Active] = 1
		--		END

	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@LessonTypeId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_ClientLevels]
				SET [Active] = 0
				WHERE [PK_ClientLevelID] = @ClientLevelID
			END
	END
;
