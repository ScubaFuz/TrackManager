CREATE PROCEDURE [dbo].[usp_ClientHandle]
	@Action nchar(3)
	,@GroupID bigint = NULL
	,@ClientId int = NULL
	,@FirstName nvarchar(50) = NULL
	,@MiddleName nvarchar(50) = NULL
	,@FamilyName nvarchar(50) = NULL
	,@PrimaryContact bit = 0
	,@Street nvarchar(50) = NULL
	,@HouseNumber nvarchar(50) = NULL
	,@PostalCode nvarchar(50) = NULL
	,@City nvarchar(50) = NULL
	,@Country nvarchar(50) = NULL
	,@TelePhone nvarchar(50) = NULL
	,@Fax nvarchar(50) = NULL
	,@Mobile nvarchar(50) = NULL
	,@Email nvarchar(50) = NULL
	,@MailingList bit = 0
	,@PrContactID int = NULL
	,@DayOfBirth nchar(8) = NULL
	,@BankAccount nvarchar(50) = NULL
	,@CreditCard nvarchar(50) = NULL
	,@CreditCardCcv int = NULL
	,@CreditCardExpire nvarchar(6) = NULL
	,@Remarks nvarchar(max) = NULL
	,@CustomField1 bit = 0
	,@CustomField2 bit = 0
	,@CustomField3 nvarchar(250) = NULL
	,@CustomField4 nvarchar(250)  = NULL
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
-- 2.1		2014-11-23	BT		Added Age with FirstName on "Get"
-- ****************************************************************************

IF NOT @PrContactId > 0 SET @PrContactId = NULL

IF @Action = 'Upd'
	BEGIN
		IF ISNULL(@GroupId,0) >0 AND ISNULL(@ClientId,0) > 0 AND ISNULL(@FirstName,'') <> ''
			BEGIN
				UPDATE [dbo].[tbl_Clients]
				SET [FirstName] = @FirstName
					,[MiddleName] = @MiddleName
					,[FamilyName] = @FamilyName
					,[FK_GroupID] = @GroupID
					,[PrimaryContact] = @PrimaryContact
					,[Street] = @Street
					,[HouseNumber] = @HouseNumber
					,[PostalCode] = @PostalCode
					,[City] = @City
					,[Country] = @Country
					,[TelePhone] = @TelePhone
					,[Fax] = @Fax
					,[Mobile] = @Mobile
					,[Email] = @Email
					,[MailingList] = @MailingList
					,[FK_PrContactID] = @PrContactID
					,[DayOfBirth] = @DayOfBirth
					,[BankAccount] = @BankAccount
					,[Remarks] = @Remarks
					,[CustomField1] =@CustomField1
					,[CustomField2] = @CustomField2
					,[CustomField3] = @CustomField3
					,[CustomField4] = @CustomField4
					,[CreditCard] = @CreditCard
					,[CreditCardCcv] = @CreditCardCcv
					,[CreditCardExpire] = @CreditCardExpire
				WHERE [PK_ClientID] =@ClientId
			END
	END

IF @Action = 'Ins'
	BEGIN

		IF len(ISNULL(@FirstName,'')) = 0 return -1

		DECLARE @intClients int
		SELECT @intClients = COUNT([FirstName]) FROM [dbo].[tbl_Clients]
		WHERE [FK_GroupID] = @GroupID
			AND [Active] = 1
		IF @intClients = 0 SET @PrimaryContact = 1

		INSERT INTO [dbo].[tbl_Clients]
			([FirstName]
			,[MiddleName]
			,[FamilyName]
			,[FK_GroupID]
			,[PrimaryContact]
			,[Street]
			,[HouseNumber]
			,[PostalCode]
			,[City]
			,[Country]
			,[TelePhone]
			,[Fax]
			,[Mobile]
			,[Email]
			,[MailingList]
			,[FK_PrContactID]
			,[DayOfBirth]
			,[BankAccount]
			,[CreditCard]
			,[CreditCardCcv]
			,[CreditCardExpire]
			,[Remarks]
			,[CustomField1]
			,[CustomField2]
			,[CustomField3]
			,[CustomField4])
		VALUES
			(@firstName
			,@MiddleName
			,@FamilyName
			,@GroupID
			,@PrimaryContact
			,@Street
			,@HouseNumber
			,@PostalCode
			,@City
			,@Country
			,@TelePhone
			,@Fax
			,@Mobile
			,@Email
			,@MailingList
			,@PrContactID
			,@DayOfBirth
			,@BankAccount
			,@CreditCard
			,@CreditCardCcv
			,@CreditCardExpire
			,@Remarks
			,@CustomField1
			,@CustomField2
			,@CustomField3
			,@CustomField4)
	END

IF @Action = 'Get'
	BEGIN
		DECLARE @intShowAge INT, @Day smalldatetime
		SELECT  @intShowAge = dbo.udf_GetShowAge()
		SELECT @Day = GetDate()
		
		SELECT [PK_ClientID]
			,dbo.udf_FirstNameAge([FirstName],[DayOfBirth],@Day,@intShowAge) AS [FirstName]
			,[MiddleName]
			,[FamilyName]
			,[FK_GroupID]
			,[PrimaryContact]
			,[Street]
			,[HouseNumber]
			,[PostalCode]
			,[City]
			,[Country]
			,[TelePhone]
			,[Fax]
			,[Mobile]
			,[Email]
			,[MailingList]
			,[FK_PrContactID]
			,[DayOfBirth]
			,[BankAccount]
			,[CreditCard]
			,[CreditCardCcv]
			,[CreditCardExpire]
			,[Remarks]
			,[CustomField1]
			,[CustomField2]
			,[CustomField3]
			,[CustomField4]
		FROM [dbo].[tbl_Clients]
		WHERE [Active] = 1
			AND ISNULL(@GroupId,0) IN ([FK_GroupID],0)
			AND ISNULL(@ClientId,0) IN ([PK_ClientID],0)
		ORDER BY [FK_GroupID],[FamilyName],[PK_ClientID]

	END

IF @Action = 'GNA'
	BEGIN
		SELECT [PK_ClientID]
			,[FirstName]
			,[MiddleName]
			,[FamilyName]
			,[FK_GroupID]
			,[PrimaryContact]
			,[Street]
			,[HouseNumber]
			,[PostalCode]
			,[City]
			,[Country]
			,[TelePhone]
			,[Fax]
			,[Mobile]
			,[Email]
			,[MailingList]
			,[FK_PrContactID]
			,[DayOfBirth]
			,[BankAccount]
			,[CreditCard]
			,[CreditCardCcv]
			,[CreditCardExpire]
			,[Remarks]
			,[CustomField1]
			,[CustomField2]
			,[CustomField3]
			,[CustomField4]
		FROM [dbo].[tbl_Clients]
		WHERE [Active] = 1
			AND ISNULL(@GroupId,0) IN ([FK_GroupID],0)
			AND ISNULL(@ClientId,0) IN ([PK_ClientID],0)
		ORDER BY [FK_GroupID],[FamilyName],[PK_ClientID]
	END

IF @Action = 'Pri'
	BEGIN
		IF @GroupId > 0
			BEGIN
				SELECT TOP 1 [PK_ClientID]
					,[FirstName]
					,[MiddleName]
					,[FamilyName]
					,[FK_GroupID]
					,[PrimaryContact]
					,[Street]
					,[HouseNumber]
					,[PostalCode]
					,[City]
					,[Country]
					,[TelePhone]
					,[Fax]
					,[Mobile]
					,[Email]
					,[MailingList]
					,[FK_PrContactID]
					,[DayOfBirth]
					,[BankAccount]
					,[CreditCard]
					,[CreditCardCcv]
					,[CreditCardExpire]
					,[Remarks]
					,[CustomField1]
					,[CustomField2]
					,[CustomField3]
					,[CustomField4]
				FROM [dbo].[tbl_Clients]
				WHERE [Active] = 1
					AND (([FK_GroupId] = @GroupId and [PK_ClientID] = @ClientId) 
					OR ([FK_GroupId] = @GroupId and [PrimaryContact] = 1))
				ORDER BY [PrimaryContact]
			END
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@ClientId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Clients]
				SET [Active] = 0
				WHERE [PK_ClientId] = @ClientId
			END
	END
;
