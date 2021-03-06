SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_LoggingHandle]
	@Action nchar(3),
	@LogDate datetime = NULL,
	@LogText nvarchar(2000) = NULL,
	@ClientPC nvarchar(50) = NULL
AS

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [TrackManager3].[dbo].[tbl_Logging]
				   ([LogDate]
				   ,[Logtext]
				   ,[ClientPC])
			 VALUES
				   (GetDate()
				   ,@LogText
				   ,@ClientPC)	
	END

IF @Action = 'Get'
	BEGIN
		SELECT [LogDate]
			  ,[Logtext]
			  ,[ClientPC]
		  FROM [dbo].[tbl_Logging]
		 WHERE [LogDate] >= @LogDate
	END

