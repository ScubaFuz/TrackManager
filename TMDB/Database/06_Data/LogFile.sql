INSERT INTO [dbo].[tbl_Config]
           ([Category]
           ,[ConfigName]
           ,[ConfigValue]
           ,[DateStart]
           ,[DateStop]
           ,[DateChange]
           ,[Remarks]
           ,[Active])
SELECT 'LogFile','LogLocation','Database',GETDATE()-1,NULL,GETDATE()-1,NULL,1 UNION
SELECT 'LogFile','LogFileName','TrackManData.log',GETDATE()-1,NULL,GETDATE()-1,NULL,1 UNION
SELECT 'LogFile','LogLevel','5',GETDATE()-1,NULL,GETDATE()-1,NULL,1
;
