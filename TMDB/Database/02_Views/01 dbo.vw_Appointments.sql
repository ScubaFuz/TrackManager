CREATE VIEW [dbo].[vw_Appointments]
AS
SELECT [FK_ClientId]
	,count(*) AS LessonCount
FROM [TrackManager].[dbo].[tbl_Appointment]
WHERE [Active] = 1
GROUP BY [FK_ClientId]
	