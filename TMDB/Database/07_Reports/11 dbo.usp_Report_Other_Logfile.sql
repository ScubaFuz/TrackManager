CREATE PROCEDURE [dbo].[usp_Report_Other_Logfile]
	 @DateStart datetime 
	 ,@DateStop datetime = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Report Logging from the database
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2012-02-10	BT		Initial Version
-- 2.0		2013-10-12	BT		Rewritten
-- ****************************************************************************

SELECT CAST(GetDate() AS smalldatetime) AS [LogDate] 
	,'Selected period: ' + CAST((SELECT COUNT(*)
			FROM [dbo].[tbl_Logging]
			WHERE [LogDate] between CAST(@DateStart AS smalldatetime) 
				AND DATEADD(dd,1,CAST(ISNULL(@DateStop,@DateStart) AS smalldatetime))) AS nvarchar(10)) 
		+ '   Total: ' + CAST((SELECT COUNT(*) FROM [dbo].[tbl_Logging]) AS nvarchar(10))
		+ '   Showing max. 1000' AS [Logtext]
	, 'Log Count' AS [ClientPC]
UNION ALL
SELECT * FROM
(SELECT TOP 1000 [LogDate]
		,[Logtext]
		,[ClientPC]
	FROM [dbo].[tbl_Logging]
	WHERE [LogDate] between CAST(@DateStart AS smalldatetime) AND DATEADD(dd,1,CAST(ISNULL(@DateStop,@DateStart) AS smalldatetime))
	ORDER BY [LogDate] DESC) Q
;