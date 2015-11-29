CREATE PROCEDURE [dbo].[usp_ReportFieldHandle]
	@Action nchar(3),
	@ReportFieldId int = NULL,
	@ReportId int = NULL,
	@FieldName nvarchar(50) = NULL,
	@FieldAlias nvarchar(50) = NULL,
	@FieldWidth int = NULL,
	@FieldShow bit = 1,
	@FieldType nvarchar(50) = NULL,
	@FieldDefault nvarchar(50) = NULL,
	@FieldOrder int = 0

AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 2.0		2013-09-22	BT		Replaced IF/OR with ISNULL
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_ReportFields]
		   SET [FK_ReportId] = @ReportId
			  ,[FieldName] = @FieldName
			  ,[FieldAlias] = @FieldAlias
			  ,[FieldWidth] = @FieldWidth
			  ,[FieldShow] = @FieldShow
			  ,[FieldType] = @FieldType
			  ,[FieldDefault] = @FieldDefault
			  ,[FieldOrder] = @FieldOrder
		 WHERE [PK_ReportFieldId] = @ReportFieldId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_ReportFields]
				   ([FK_ReportId]
				   ,[FieldName]
				   ,[FieldAlias]
				   ,[FieldWidth]
				   ,[FieldShow]
				   ,[FieldType]
				   ,[FieldDefault]
				   ,[FieldOrder])
			 VALUES
				   (@ReportId
				   ,@FieldName
				   ,@FieldAlias
				   ,@FieldWidth
				   ,@FieldShow
				   ,@FieldType
				   ,@FieldDefault
				   ,@FieldOrder)
	END

IF @Action = 'Get'
	BEGIN
		--IF (@ReportFieldId IS NULL OR @ReportFieldId = 0) AND (@ReportId IS NULL OR @ReportId = 0)
		--	BEGIN
		--		SELECT [PK_ReportFieldId]
		--			  ,[FK_ReportId]
		--			  ,[FieldName]
		--			  ,[FieldAlias]
		--			  ,[FieldWidth]
		--			  ,[FieldShow]
		--			  ,[FieldType]
		--			  ,[FieldDefault]
		--			  ,[FieldOrder]
		--		  FROM [dbo].[tbl_ReportFields]
		--	  ORDER BY [FK_ReportId],[FieldOrder]
		--	END
		--IF (@ReportFieldId IS NULL OR @ReportFieldId = 0) AND (@ReportId > 0)
		--	BEGIN
		--		SELECT [PK_ReportFieldId]
		--			  ,[FK_ReportId]
		--			  ,[FieldName]
		--			  ,[FieldAlias]
		--			  ,[FieldWidth]
		--			  ,[FieldShow]
		--			  ,[FieldType]
		--			  ,[FieldDefault]
		--			  ,[FieldOrder]
		--		  FROM [dbo].[tbl_ReportFields]
		--		 WHERE [FK_ReportId] = @ReportId
		--	  ORDER BY [FK_ReportId],[FieldOrder]
		--	END
		--IF @ReportFieldId > 0
		--	BEGIN
		SELECT [PK_ReportFieldId]
			,[FK_ReportId]
			,[FieldName]
			,[FieldAlias]
			,[FieldWidth]
			,[FieldShow]
			,[FieldType]
			,[FieldDefault]
			,[FK_ReportId],[FieldOrder]
		FROM [dbo].[tbl_ReportFields]
		WHERE ISNULL(@ReportFieldId,0) IN ([PK_ReportFieldId],0)
			AND ISNULL(@ReportId,0) IN ([FK_ReportId],0)
		ORDER BY [FieldOrder]
			--END
	END

IF @Action = 'Del'
	BEGIN
		IF NOT (@ReportFieldId IS NULL OR @ReportFieldId = 0)
			BEGIN
				DELETE FROM [dbo].[tbl_ReportFields]
					  WHERE [PK_ReportFieldId] = @ReportFieldId
			END
	END
;
