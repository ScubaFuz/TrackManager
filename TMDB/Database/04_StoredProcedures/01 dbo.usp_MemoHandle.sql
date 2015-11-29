CREATE PROCEDURE [dbo].[usp_MemoHandle]
	@Action nchar(3),
	@MemoId int = 0,
	@Type nvarchar(50) = NULL,
	@GroupId bigint = 0,
	@MemoDate smalldatetime = NULL,
	@MemoText nvarchar(max) = NULL
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
-- 2.1		2013-10-15	BT		filtered out Memodate for types other than Track
-- ****************************************************************************

IF @Action = 'Upd'
	BEGIN
		IF @GroupId = 0 SET @GroupId = NULL
		UPDATE [dbo].[tbl_Memo]
		   SET [Type] = @Type
			  ,[FK_GroupId] = @GroupId
			  ,[MemoDate] = @MemoDate
			  ,[MemoText] = @MemoText
		 WHERE [PK_MemoId] = @MemoId
	END

IF @Action = 'Ins'
	BEGIN
		IF @GroupId = 0 SET @GroupId = NULL
		INSERT INTO [dbo].[tbl_Memo]
				   ([Type]
				   ,[FK_GroupId]
				   ,[MemoDate]
				   ,[MemoText])
			 VALUES
				   (@Type
				   ,@GroupId
				   ,@MemoDate
				   ,@MemoText)
	END

IF @Action = 'Get'
	BEGIN
		SELECT [PK_MemoId]
			,[Type]
			,[FK_GroupId]
			,[MemoDate]
			,[MemoText]
		FROM [dbo].[tbl_Memo]
		WHERE ISNULL(@MemoId,0) IN ([PK_MemoId],0)
			AND ISNULL(@Type,'') IN ([Type],'')
			AND ISNULL(@GroupId,0) IN ([FK_GroupId],0)
			AND (@Type = 'Track' AND ISNULL(@MemoDate,0) IN ([MemoDate],0) 
				OR @Type <> 'Track')
	END

IF @Action = 'Del'
	BEGIN
		IF NOT isnull(@MemoId,0) = 0
			BEGIN
				DELETE FROM [dbo].[tbl_Memo]
					  WHERE [PK_MemoId] = @MemoId
			END
	END

IF @Action = 'Smt'
	BEGIN
		DECLARE @Return int
		SET @Return = 0
		IF @GroupId > 0 AND @Type IS NOT NULL
			BEGIN
				SET @Return = (SELECT [PK_MemoId]
								 FROM [dbo].[tbl_Memo]
								WHERE [Type] = @Type
								  AND [FK_GroupId] = @GroupId)
			END
		IF isnull(@GroupId,0) = 0 AND @Type IS NOT NULL AND @MemoDate IS NOT NULL
			BEGIN
				SET @Return = (SELECT [PK_MemoId]
								 FROM [dbo].[tbl_Memo]
								WHERE [Type] = @Type
								  AND [MemoDate] = @MemoDate)
			END

		IF isnull(@Return,0) = 0
			BEGIN
				--Insert
				EXEC [dbo].[usp_MemoHandle] 'Ins', @MemoId, @Type, @GroupId, @MemoDate, @MemoText
			END
		ELSE
			BEGIN
				IF @Return > 0
					BEGIN
						--Update
						EXEC [dbo].[usp_MemoHandle] 'Upd', @Return, @Type, @GroupId, @MemoDate, @MemoText
					END
			END
	END
;
