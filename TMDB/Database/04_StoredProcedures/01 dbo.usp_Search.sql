CREATE PROCEDURE [dbo].[usp_Search]
	@PartialMatch int,
	@MatchAll bit,
	@MaximumHits int = 25,
	@FirstName varchar(50) = NULL,
	@LastName varchar(50) = NULL,
	@PostalCode varchar(10) = NULL,
	@City varchar(50) = NULL,
	@GroupName varchar(50) = NULL,
	@Email varchar(100) = NULL,
	@Phone varchar(100) = NULL,
	@DateOfBirth varchar(20) = NULL
AS

-- ****************************************************************************
-- Auteur	Bart Thieme
-- Doel		
-- ****************************************************************************
-- Versie	Datum       Auteur	Beschrijving
-- ******	**********	******	*********************************************
-- 01		2010-01-01	BT		Eerste versie
-- 02		
-- ****************************************************************************

DECLARE @nsql nvarchar(max)
SET @nsql = '
SELECT TOP ' + cast(@MaximumHits as varchar(10)) + ' 
	 clt.[PK_ClientID]
	,clt.[FirstName] + isnull('' '' + clt.[MiddleName],'''') + isnull('' '' +  clt.[FamilyName],'''') AS ClName
	,isnull(grp.[GroupName],'''') AS [GroupName]
	,isnull(cast(clt.[FK_GroupID] as varchar(50)),'''') AS [FK_GroupID]
	,isnull(clt.[Street],'''') AS [Street]
	,isnull(clt.[HouseNumber],'''') AS [HouseNumber]
	,isnull(clt.[PostalCode],'''') AS [PostalCode]
	,isnull(clt.[City],'''') AS [City]
	,isnull(clt.[Country],'''') AS [Country]
	,isnull(clt.[TelePhone],'''') AS [TelePhone]
	,isnull(clt.[Mobile],'''') AS [Mobile]
	,isnull(clt.[Email],'''') AS [Email]
	,isnull(convert(varchar(10),clt.[DayOfBirth],121),'''') As [DayOfBirth]
FROM tbl_Clients clt
INNER JOIN tbl_Groups grp
	ON clt.[FK_GroupID] = grp.[PK_GroupID]
	AND grp.[Active] = 1
WHERE clt.[Active] = 1 '

IF @MatchAll = 0
  BEGIN
	IF NOT @FirstName IS NULL SET @nsql = @nsql + ' AND Firstname LIKE ''[%]' + @FirstName + '%'''
	IF NOT @LastName IS NULL SET @nsql = @nsql + ' OR FamilyName LIKE ''[%]' + @LastName + '%'''
	IF NOT @PostalCode IS NULL SET @nsql = @nsql + ' OR Replace(PostalCode,'' '','''') LIKE ''[%]' + Replace(@PostalCode,' ','') +'%'''
	IF NOT @City IS NULL SET @nsql = @nsql + ' OR City LIKE ''[%]' + @City +'%'''
	IF NOT @GroupName IS NULL AND isnumeric(@GroupName)=1 SET @nsql = @nsql + ' OR FK_GroupID IN (SELECT PK_GroupID FROM tbl_Groups WHERE GroupName LIKE ''[%]' + @GroupName +'%'' UNION SELECT PK_GroupID FROM tbl_Groups WHERE CONVERT(VARCHAR(20),PK_GroupID) LIKE ''[%]' + @GroupName +'%'')' 
	IF NOT @GroupName IS NULL AND isnumeric(@GroupName)=0 SET @nsql = @nsql + ' OR FK_GroupID IN (SELECT PK_GroupID FROM tbl_Groups WHERE GroupName LIKE ''[%]' + @GroupName +'%'')' 
	IF NOT @Email IS NULL SET @nsql = @nsql + ' OR Email LIKE ''[%]' + @Email +'%'''
	IF NOT @Phone IS NULL SET @nsql = @nsql + ' OR Replace(TelePhone,'' '','''') LIKE ''[%]' + Replace(@Phone,' ','') +'%'' OR Replace(Mobile,'' '','''') LIKE ''[%]' + Replace(@Phone,' ','') +'%'''
	IF NOT @DateOfBirth IS NULL SET @nsql = @nsql +' OR DayOfBirth = ' + @DateOfBirth
  END
ELSE
  BEGIN
	IF NOT @FirstName IS NULL SET @nsql = @nsql + ' AND Firstname LIKE ''[%]' + @FirstName + '%'''
	IF NOT @LastName IS NULL SET @nsql = @nsql + ' AND FamilyName LIKE ''[%]' + @LastName + '%'''
	IF NOT @PostalCode IS NULL SET @nsql = @nsql + ' AND Replace(PostalCode,'' '','''') LIKE ''[%]' + Replace(@PostalCode,' ','') +'%'''
	IF NOT @City IS NULL SET @nsql = @nsql + ' AND City LIKE ''[%]' + @City +'%'''
	IF NOT @GroupName IS NULL AND isnumeric(@GroupName)=1 SET @nsql = @nsql + ' AND FK_GroupID IN (SELECT PK_GroupID FROM tbl_Groups WHERE GroupName LIKE ''[%]' + @GroupName +'%'' UNION SELECT PK_GroupID FROM tbl_Groups WHERE CONVERT(VARCHAR(20),PK_GroupID) LIKE ''[%]' + @GroupName +'%'')'  
	IF NOT @GroupName IS NULL AND isnumeric(@GroupName)=0 SET @nsql = @nsql + ' AND FK_GroupID IN (SELECT PK_GroupID FROM tbl_Groups WHERE GroupName LIKE ''[%]' + @GroupName +'%'')' 
	IF NOT @Email IS NULL SET @nsql = @nsql + ' AND Email LIKE ''[%]' + @Email +'%'''
	IF NOT @Phone IS NULL SET @nsql = @nsql + ' AND (Replace(TelePhone,'' '','''') LIKE ''[%]' + Replace(@Phone,' ','') +'%'' OR Replace(Mobile,'' '','''') LIKE ''[%]' + Replace(@Phone,' ','') +'%'')'
	IF NOT @DateOfBirth IS NULL SET @nsql = @nsql +' AND DayOfBirth = ' + @DateOfBirth
  END


IF @PartialMatch = 1
  BEGIN
    SET @nsql = replace(@nsql,'[%]','')
  END
IF @PartialMatch = 2
  BEGIN
    SET @nsql = replace(@nsql,'[%]','%')
  END
IF @PartialMatch = 3
  BEGIN
    SET @nsql = replace(@nsql,'[%]','')
    SET @nsql = replace(@nsql,'%','')
    SET @nsql = replace(@nsql,'LIKE','=')
  END

print @nsql
exec sp_executesql @nsql
;
