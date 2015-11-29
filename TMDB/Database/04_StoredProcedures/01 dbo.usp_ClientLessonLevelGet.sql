CREATE PROCEDURE [dbo].[usp_ClientLessonLevelGet]
	 @ClientID int = NULL
	,@GroupID bigint = NULL
	,@ShowAllLessontypes bit = 0
	,@SeasonStart datetime
	,@seasonEnd datetime
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Eerste versie
-- 2.0		2010-03-10	BT		Active Toegevoegd
-- 3.0		2014-11-25	BT		Added Age for firstname
-- ****************************************************************************

DECLARE @intShowAge INT, @Day smalldatetime
SELECT  @intShowAge = dbo.udf_GetShowAge()
SELECT @Day = GetDate()
		
SELECT [PK_ClientID]
	,dbo.udf_FirstNameAge([FirstName],[DayOfBirth],@Day,@intShowAge) AS [FirstName]
	,cnt.[MiddleName]
	,cnt.[FamilyName]
	,cnt.[FK_GroupID]
	,cnt.[PrimaryContact]
	,cnt.[Street]
	,cnt.[HouseNumber]
	,cnt.[PostalCode]
	,cnt.[City]
	,cnt.[Country]
	,cnt.[TelePhone]
	,cnt.[Fax]
	,cnt.[Mobile]
	,cnt.[Email]
	,cnt.[MailingList]
	,cnt.[FK_PrContactID]
	,cnt.[DayOfBirth]
	,cnt.[BankAccount]
	,cnt.[Remarks]
	,cnt.[CustomField1]
	,cnt.[CustomField2]
	,cnt.[CustomField3]
	,cnt.[CustomField4]
	,cls.[PK_ClientLevelID]
	,cls.[FK_LessonTypeID]
	,cls.[FK_LevelID]
	,CASE WHEN getdate() between @SeasonStart and @seasonEnd THEN cls.[LessonCount]
		ELSE (SELECT count(*) 
				FROM tbl_Appointment App 
				WHERE App.AppDate between @SeasonStart and @seasonEnd 
					AND App.FK_ClientID = cnt.[PK_ClientID] 
					AND app.[FK_LessonTypeID] = cls.[FK_LessonTypeID]
					AND app.Active = 1)
		END AS [LessonCount]
	,cls.[ExtraCount]
	,isnull(cls.[PrimaryType],1) AS [PrimaryType]
	,cls.[LastAction]
	,lts.[LessonTypeName]
	,lvs.[LevelName]
	,bil.ivlCount
FROM [dbo].[tbl_Clients] cnt
LEFT OUTER JOIN  (
			SELECT [PK_ClientLevelID]
				  ,[FK_ClientID]
				  ,[FK_LessonTypeID]
				  ,[FK_LevelID]
				  ,[LessonCount]
				  ,[ExtraCount]
				  ,[PrimaryType]
				  ,[LastAction]
			  FROM [dbo].[tbl_ClientLevels]
			WHERE  [Active] = 1
				AND ([PrimaryType] = 1 OR @ShowAllLessontypes = 1)) cls
	ON cnt.[PK_ClientID] = cls.[FK_ClientID]
LEFT OUTER JOIN  [dbo].[tbl_LessonTypes] lts
	ON cls.[FK_LessonTypeID] = lts.[PK_LessonTypeID]
LEFT OUTER JOIN  [dbo].[tbl_Levels] lvs
	ON cls.[FK_LevelID] = lvs.[PK_LevelID]
LEFT OUTER JOIN (
		SELECT inv.FK_ClientId, SUM(ivl.[Count]) AS ivlCount 
		 FROM tbl_Invoice inv
		 LEFT OUTER JOIN tbl_InvoiceLine ivl
		   ON inv.PK_InvoiceID = ivl.FK_InvoiceId
		  AND ivl.[Active] = 1
		WHERE inv.[Active] = 1
		  AND inv.InvoiceDate between @SeasonStart and @SeasonEnd
		GROUP BY inv.FK_ClientId ) bil
	ON cnt.[PK_ClientID] = bil.[FK_ClientID] 
WHERE cnt.[Active] = 1
	AND ((isnull(@ClientID,0)=0 AND @GroupID > 0 AND cnt.[FK_GroupID] = @GroupID)
	OR (@ClientID > 0 AND cnt.[PK_ClientID] = @ClientID))
ORDER BY [PrimaryType] desc, cnt.[FirstName],cnt.[FamilyName],cnt.[PK_ClientID]
;
