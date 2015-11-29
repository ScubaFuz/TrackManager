CREATE PROCEDURE [dbo].[usp_InvoiceLineHandle]
	@Action nchar(3),
	@InvoiceLineId int = 0,
	@InvoiceId int = 0,
	@ClientId int = 0,
	@LoginId int = 0,
	@Description nvarchar(100) = NULL,
	@Count int = 0,
	@Amount numeric(10,2) = 0,
	@Tax int = 0
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

IF @Action = 'Get'
	BEGIN
		IF isnull(@InvoiceLineId,0) = 0 AND isnull(@InvoiceId,0) = 0
			BEGIN
				SELECT [PK_InvoiceLineID]
					  ,[FK_InvoiceID]
					  ,[FK_ClientID]
					  ,[FK_LoginID]
					  ,isnull([Description],'') AS [Description]
					  ,isnull([Count],0) AS [Count]
					  ,isnull([Amount],0) AS [Amount]
					  ,isnull([FK_Tax],0) AS [FK_Tax]
				  FROM [dbo].[tbl_InvoiceLine]
				 WHERE [Active] = 1
			END
		IF isnull(@InvoiceLineId,0) = 0 AND @InvoiceId > 0
			BEGIN
				SELECT iln.[PK_InvoiceLineID]
					  ,iln.[FK_InvoiceID]
					  ,iln.[FK_ClientID]
					  ,iln.[FK_LoginID]
					  ,isnull(iln.[Description],0) AS [Description]
					  ,isnull(iln.[Count],0) AS [Count]
					  ,isnull(iln.[Amount],0) AS [Amount]
					  ,isnull(iln.[FK_Tax],0) AS [FK_Tax]
					  ,clt.[FirstName]
					  ,clt.[MiddleName]
					  ,clt.[FamilyName]
					  ,isnull(lgn.[LoginName],'') AS [LoginName]
				FROM [dbo].[tbl_InvoiceLine] iln
				INNER JOIN dbo.[tbl_Clients] clt
					ON iln.[FK_ClientID] = clt.[PK_ClientId]
					--AND clt.[Active] = 1
				LEFT OUTER JOIN dbo.[tbl_Logins] lgn
					ON iln.[FK_LoginID] = lgn.[PK_LoginId]
					--AND lgn.[Active] = 1
				WHERE [FK_InvoiceID] = @InvoiceId
				  AND iln.[Active] = 1
			END
		IF @InvoiceLineId > 0
			BEGIN
				SELECT [PK_InvoiceLineID]
					  ,[FK_InvoiceID]
					  ,[FK_ClientID]
					  ,[FK_LoginID]
					  ,isnull([Description],'') AS [Description]
					  ,isnull([Count],0) AS [Count]
					  ,isnull([Amount],0) AS [Amount]
					  ,isnull([FK_Tax],0) AS [FK_Tax]
				  FROM [dbo].[tbl_InvoiceLine]
				 WHERE [PK_InvoiceLineID] = @InvoiceLineId
				   AND [Active] = 1
			END
	END


IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_InvoiceLine]
				   ([FK_InvoiceID]
				   ,[FK_ClientID]
				   ,[FK_LoginID]
				   ,[Description]
				   ,[Count]
				   ,[Amount]
				   ,[FK_Tax])
			 VALUES
				   (@InvoiceId
				   ,@ClientId
				   ,@LoginId
				   ,@Description
				   ,@Count
				   ,@Amount
				   ,@Tax)
		--SELECT IDENT_CURRENT('tbl_InvoiceLine') AS InvoiceLineId
	END

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_InvoiceLine]
		   SET [FK_InvoiceID] = @InvoiceId
			  ,[FK_ClientID] = @ClientId
			  ,[FK_LoginID] = @LoginId
			  ,[Description] = @Description
			  ,[Count] = @Count
			  ,[Amount] = @Amount
			  ,[FK_Tax] = @Tax
		 WHERE [PK_InvoiceLineID] = @InvoiceLineId
	END

IF @Action = 'Del'
	BEGIN
		UPDATE [dbo].[tbl_InvoiceLine]
		SET [Active] = 0
		WHERE [PK_InvoiceLineID] = @InvoiceLineId
	END
;
