CREATE PROCEDURE [dbo].[usp_ReportHandle]
	@Action nchar(3),
	@ReportId int = NULL,
	@ReportName nvarchar(50) = NULL,
	@ReportType nchar(1) = NULL,
	@PrimaryMenu nvarchar(50) = NULL,
	@SecondaryMenu nvarchar(50) = NULL,
	@Procedure nvarchar(100) = NULL,
	@Visible bit = true,
	@Language nvarchar(50) = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 2.0		2013-09-22	BT		Replaced IF/OR with ISNULL
-- 3.0		2013-10-08	BT		Added several fields
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_Reports]
		SET [ReportName] = ISNULL(@ReportName,[ReportName])
			,[ReportType] = ISNULL(@ReportType,[ReportType])
			,[PrimaryMenu] = ISNULL(@PrimaryMenu,[PrimaryMenu])
			,[SecondaryMenu] = ISNULL(@SecondaryMenu,[SecondaryMenu])
			,[ProcedureName] = ISNULL(@Procedure,[ProcedureName])
			,[Visible] = ISNULL(@Visible,[Visible])
		WHERE [PK_ReportId] = @ReportId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Reports]
			([ReportName]
			,[ReportType]
			,[PrimaryMenu]
			,[SecondaryMenu]
			,[ProcedureName]
			,[Visible]
			,[Active])
		VALUES
			(@ReportName
			,@ReportType
			,@PrimaryMenu
			,@SecondaryMenu
			,@Procedure
			,@Visible
			,1)
	END

IF @Action = 'Get'
	BEGIN
		SELECT rep.[PK_ReportId]
			,ISNULL(lan.[LanguageText],rep.[ReportName]) AS [ReportName]
			,rep.[ReportType]
			,rep.[PrimaryMenu]
			,ISNULL(rep.[SecondaryMenu],0) AS [SecondaryMenu]
			,ISNULL(rep.[ProcedureName],'') AS [ProcedureName]
			,rep.[Visible]
			,rep.[Active]
		FROM [dbo].[tbl_Reports] rep
		LEFT OUTER JOIN [dbo].[tbl_Language] lan
			ON rep.[ReportName] = lan.[LanguageItem]
			AND lan.[Language] = @Language
			AND lan.[LanguageForm] = 'Reports'
			AND lan.[LanguageType] = 'Report'
		WHERE [Active] = 1
			AND ISNULL(@ReportId,0) IN ([PK_ReportId],0)
			AND ISNULL(@ReportName,'') IN ([ReportName],'')
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@ReportId,0) <> 0
			BEGIN
				DELETE FROM [dbo].[tbl_ReportArguments]
					  WHERE [FK_ReportId] = @ReportId
				DELETE FROM [dbo].[tbl_ReportFields]
					  WHERE [FK_ReportId] = @ReportId
				DELETE FROM [dbo].[tbl_Reports]
					  WHERE [PK_ReportId] = @ReportId
			END
	END

IF @Action = 'Sec'
	BEGIN
		UPDATE [dbo].[tbl_Reports]
		SET [SecondaryMenu] = 0
		WHERE [SecondaryMenu] = @SecondaryMenu

		UPDATE [dbo].[tbl_Reports]
		SET [SecondaryMenu] = ISNULL(@SecondaryMenu,[SecondaryMenu])
		WHERE [PK_ReportId] = @ReportId
	END
;
