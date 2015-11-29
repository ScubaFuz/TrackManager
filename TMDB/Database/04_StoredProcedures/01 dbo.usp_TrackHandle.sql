CREATE PROCEDURE [dbo].[usp_TrackHandle]
	@Action nchar(3),
	@TrackId int = NULL,
	@TrackName nvarchar(50) = NULL,
	@TrackOffset int = NULL
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
		UPDATE [dbo].[tbl_Tracks]
		   SET [TrackName] = @TrackName
			  ,[TrackOffset] = @TrackOffset
		 WHERE [PK_TrackId] = @TrackId
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Tracks]
				   ([TrackName]
				   ,[TrackOffset])
			 VALUES
				   (@TrackName
				   ,@TrackOffset)
	END

IF @Action = 'Get'
	BEGIN
		--IF isnull(@TrackId,0) = 0
		--	BEGIN
		--		SELECT [PK_TrackID]
		--			  ,[TrackName]
		--			  ,[TrackOffset]
		--		 FROM [dbo].[tbl_Tracks]
		--		WHERE [Active] = 1
		--	END
		--ELSE
		--	IF @trackId > 0
		--		BEGIN
		SELECT [PK_TrackID]
			,[TrackName]
			,[TrackOffset]
		FROM [dbo].[tbl_Tracks]
		WHERE ISNULL(@TrackId,0) IN ([PK_TrackID],0) 
			AND [Active] = 1
				--END
	END

IF @Action = 'Del'
	BEGIN
		IF NOT isnull(@TrackId,0) = 0
			BEGIN
				UPDATE [dbo].[tbl_Tracks]
				SET [Active] = 0
				WHERE [PK_TrackId] = @TrackId
			END
	END
;
