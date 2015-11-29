CREATE PROCEDURE [dbo].[usp_LanguageHandle]
	@Action nchar(3),
	@LanguageId int = NULL,
	@Language nvarchar(50) = NULL,
	@LanguageForm nvarchar(50) = NULL,
	@LanguageItem nvarchar(50) = NULL,
	@LanguageText nvarchar(255) = NULL,
	@LanguageType nvarchar(50) = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-10-09	BT		Initial Version
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		IF ISNULL(@languageId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Language]
				SET [Language] = @Language
					,[LanguageForm] = @LanguageForm
					,[LanguageItem] = @LanguageItem
					,[LanguageText] = @LanguageText
					,[LanguageType] = @LanguageType
				WHERE [PK_LanguageId] = @languageId
			END
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Language]
			([Language]
			,[LanguageForm]
			,[LanguageItem]
			,[LanguageText]
			,[LanguageType])
		VALUES
			(@Language
			,@LanguageForm
			,@LanguageItem
			,@LanguageText
			,@LanguageType)
	END

IF @Action = 'Get'
	BEGIN
		SELECT [PK_LanguageId]
			,[Language]
			,[LanguageForm]
			,[LanguageItem]
			,[LanguageText]
			,[LanguageType]
		FROM [dbo].[tbl_Language]
		WHERE ISNULL(@languageId,0) IN ([PK_LanguageId],0)
			AND ISNULL(@Language,'') IN ([Language],'')
			AND ISNULL(@LanguageForm,'') IN ([LanguageForm],'')
			AND ISNULL(@LanguageItem,'') IN ([LanguageItem],'')
		ORDER BY [LanguageForm],[LanguageItem]
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@languageId,0) <> 0
			BEGIN
				DELETE [dbo].[tbl_Language]
				WHERE [PK_LanguageId] = @languageId
			END
		IF ISNULL(@Language,'') <> '' AND ISNULL(@languageId,0) = 0
			BEGIN
				DELETE [dbo].[tbl_Language]
				WHERE [Language] = @Language
			END
	END

IF @Action = 'Smt'
	BEGIN
		IF ISNULL(@LanguageId,0) = 0
			BEGIN
				SELECT @LanguageId = [PK_LanguageId]
				FROM [dbo].[tbl_Language]
				WHERE [Language] = @Language
					AND [LanguageForm] = @LanguageForm
					AND [LanguageItem] = @LanguageItem

				IF ISNULL(@LanguageId,0) = 0
					BEGIN
						EXECUTE [dbo].[usp_LanguageHandle]
							@Action = 'Ins',
							@Language = @Language,
							@LanguageForm = @LanguageForm,
							@LanguageItem = @LanguageItem,
							@LanguageText = @LanguageText,
							@LanguageType = @LanguageType
					END
				ELSE
					BEGIN
						EXECUTE [dbo].[usp_LanguageHandle]
							@Action = 'Upd',
							@LanguageId = @LanguageId,
							@Language = @Language,
							@LanguageForm = @LanguageForm,
							@LanguageItem = @LanguageItem,
							@LanguageText = @LanguageText,
							@LanguageType = @LanguageType
					END
			END
	END
;
