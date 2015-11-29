CREATE PROCEDURE [dbo].[usp_LessonTypeHandle]
	@Action nchar(3),
	@LessonTypeId int = NULL,
	@LessonTypeName nvarchar(50) = NULL,
	@LessonTypecolor nvarchar(50) = NULL
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
		IF ISNULL(@LessonTypeId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_LessonTypes]
				   SET [LessonTypeName] = @LessonTypeName
					  ,[Color] = @LessonTypecolor
				 WHERE [PK_LessonTypeId] = @LessonTypeId
			END
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_LessonTypes]
				   ([LessonTypeName]
				   ,[Color])
			 VALUES
				   (@LessonTypeName
				   ,@LessonTypeColor)
	END

IF @Action = 'Get'
	BEGIN
		--IF ISNULL(@LessonTypeId,0) = 0 AND ISNULL(@LessonTypeName,'') = ''
		--	BEGIN
				SELECT [PK_LessonTypeID]
					,[LessonTypeName]
					,[Color]
				FROM [dbo].[tbl_LessonTypes]
				WHERE [Active] = 1
					AND ISNULL(@LessonTypeId,0) IN ([PK_LessonTypeID],0)
					AND ISNULL(@LessonTypeName,'') IN ([LessonTypeName],'')
		--	END
		--IF ISNULL(@LessonTypeId,0) = 0 AND (LEN(@LessonTypeName) > 0)
		--	BEGIN
		--		SELECT [PK_LessonTypeID]
		--			  ,[LessonTypeName]
		--			  ,[Color]
		--		FROM [dbo].[tbl_LessonTypes]
		--		WHERE [LessonTypeName] = @LessonTypeName
		--		  AND [Active] = 1
		--	END
		--IF @LessonTypeId > 0
		--	BEGIN
		--		SELECT [PK_LessonTypeID]
		--			  ,[LessonTypeName]
		--			  ,[Color]
		--		FROM [dbo].[tbl_LessonTypes]
		--		WHERE [PK_LessonTypeID] = @LessonTypeId
		--		  --AND [Active] = 1
		--	END
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@LessonTypeId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_LessonTypes]
				SET [Active] = 0
				WHERE [PK_LessonTypeId] = @LessonTypeId
			END
	END
;
