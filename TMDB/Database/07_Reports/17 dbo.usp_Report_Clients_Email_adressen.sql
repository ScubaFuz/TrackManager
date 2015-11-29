CREATE PROCEDURE [dbo].[usp_Report_Clients_Email_adressen]
	@DateStart datetime 
	,@DateStop datetime = NULL

AS

SELECT DISTINCT LTRIM(RTRIM(Email)) AS Email
FROM dbo.tbl_Clients
WHERE Email IS NOT NULL
	AND dbo.udf_ValidEmail(Email) = 1
	AND [MailingList] = 1
	AND [Active] = 1


