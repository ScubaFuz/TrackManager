CREATE PROCEDURE [dbo].[usp_Report_Clients_EmailAddresses]
	@DateStart datetime 
	,@DateStop datetime = NULL

AS
-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose	Report Email Addresses from the database
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2012-02-10	BT		Initial Version
-- 2.0		2013-10-12	BT		Rewritten
-- 3.0		2014-04-15	BT		Added several fields
-- ****************************************************************************

SELECT DISTINCT isnull(clt.FirstName,'') AS FirstName
	, isnull(clt.MiddleName,'') AS MiddleName
	, isnull(clt.FamilyName,'') AS FamilyName
	, LTRIM(RTRIM(clt.Email)) AS Email
	, isnull(grp.GroupName,'') AS GroupName
	, isnull(grp.PK_GroupId,0) AS GroupId
FROM dbo.tbl_Clients clt
INNER JOIN dbo.tbl_Groups grp
	ON clt.FK_GroupID = grp.PK_GroupID
WHERE Email IS NOT NULL
	AND dbo.udf_ValidEmail(LTRIM(RTRIM(clt.Email))) = 1
	AND clt.[MailingList] = 1
	AND clt.[Active] = 1


