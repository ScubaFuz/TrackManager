INSERT INTO [dbo].[tbl_Config]
	([Category],[ConfigName],[ConfigValue],[DateStart],[DateStop],[DateChange],[Remarks],[Active])
SELECT 'Weekdays','1','Su',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','2','Mo',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','3','Tu',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','4','We',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','5','Th',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','6','Fr',GetDate()-1,NULL,NULL,'EN',1 UNION
SELECT 'Weekdays','7','Sa',GetDate()-1,NULL,NULL,'EN',1
