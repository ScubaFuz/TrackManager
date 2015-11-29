CREATE PROCEDURE [dbo].[usp_LoggingHandle]
	@Action nchar(3),
	@LogDate datetime = NULL,
	@LogText nvarchar(2000) = NULL,
	@ClientPC nvarchar(50) = NULL
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

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Logging]
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
		SELECT DATEADD(n,-3,DATEADD(dd,1,CAST(@LogDate AS smalldatetime))) AS LogDate 
				,'This Day: ' + CAST((SELECT COUNT(*)
						FROM [dbo].[tbl_Logging]
						WHERE [LogDate] between CAST(@LogDate AS smalldatetime) AND DATEADD(dd,1,CAST(@LogDate AS smalldatetime))) AS nvarchar(10)) 
					+ '   Total: ' + CAST((SELECT COUNT(*) FROM [dbo].[tbl_Logging]) AS nvarchar(10))
					AS [Logtext]
				, 'Log Count' AS [ClientPC]
		UNION
		SELECT TOP 1000 [LogDate]
			  ,[Logtext]
			  ,[ClientPC]
		  FROM [dbo].[tbl_Logging]
		 WHERE [LogDate] between CAST(@LogDate AS smalldatetime) AND DATEADD(dd,1,CAST(@LogDate AS smalldatetime))
		 ORDER BY [LogDate] DESC
	END
	
IF @Action = 'Del'
	BEGIN
		DELETE
		  FROM [dbo].[tbl_Logging]
		 WHERE [LogDate] < @LogDate
	END

;
