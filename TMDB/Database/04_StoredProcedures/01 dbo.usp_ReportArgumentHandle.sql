CREATE PROCEDURE [dbo].[usp_ReportArgumentHandle]
	@Action nchar(3),
	@ReportArgumentId int = NULL,
	@ReportId int = 0,
	@ArgumentId int = 0,
	@IsOptional bit = 1,
	@IsSelected bit = 0,
	@ReportName nvarchar(100) = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 1.1		2013-07-25	BT		Added Chk for allowed arguments		
-- 2.0		2013-09-22	BT		Replaced IF/OR with ISNULL
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_ReportArguments]
		   SET [FK_ReportId] = @ReportId
			  ,[FK_ArgumentId] = @ArgumentId
			  ,[IsOptional] = @IsOptional
			  ,[IsSelected] = @IsSelected
		 WHERE [PK_ReportArgumentId] = @ReportArgumentId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_ReportArguments]
				   ([FK_ReportId]
				   ,[FK_ArgumentId]
				   ,[IsOptional]
				   ,[IsSelected])
			 VALUES
				   (@ReportId
				   ,@ArgumentId
				   ,@IsOptional
				   ,@IsSelected)
	END

IF @Action = 'Get'
	BEGIN
		SELECT rat.[PK_ReportArgumentId]
			,rat.[FK_ReportId]
			,rat.[FK_ArgumentId]
			,rat.[IsOptional]
			,rat.[IsSelected]
			,arg.[ArgumentName]
			,rps.[ReportName]
		FROM [dbo].[tbl_ReportArguments] rat
		INNER JOIN [dbo].[tbl_Arguments] arg
			ON rat.[FK_ArgumentId] = arg.[PK_ArgumentId]
		INNER JOIN [dbo].[tbl_Reports] rps
			ON rat.[FK_ReportId] = rps.[PK_ReportId]
		WHERE ISNULL(@ReportId,0) IN (rat.[FK_ReportId],0)
			AND ISNULL(@ReportArgumentId,0) IN (rat.[PK_ReportArgumentId],0)
			AND ISNULL(@ReportName,'0') IN (rps.[ReportName],'0')
	END

IF @Action = 'Del'
	BEGIN
		IF NOT (@ReportArgumentId IS NULL OR @ReportArgumentId = 0)
			BEGIN
				DELETE FROM [dbo].[tbl_ReportArguments]
				WHERE [PK_ReportArgumentId] = @ReportArgumentId
			END
	END

IF @Action = 'Chk'
	BEGIN
		;WITH ReportArgs AS (
			SELECT rts.PK_ReportId
				,ras.FK_ArgumentId
				,ras.IsOptional
			FROM tbl_Reports rts
			INNER JOIN tbl_ReportArguments ras
				ON rts.PK_ReportId = ras.FK_ReportId
			WHERE rts.ReportName = @ReportName OR rts.PK_ReportId = @ReportId
			)
		SELECT ats.ArgumentName
			,ISNULL(ras.PK_ReportArgumentId,0) AS Allowed
			,ISNULL(ras.FK_ArgumentId,0) AS FK_ArgumentId
			,ISNULL(ras.IsOptional,0) As IsOptional
		FROM tbl_Arguments ats
		LEFT OUTER JOIN tbl_ReportArguments ras
			ON ats.PK_ArgumentId = ras.FK_ArgumentId
			AND ras.FK_ReportId = (SELECT TOP 1 PK_ReportId FROM ReportArgs)
	END;
