CREATE PROCEDURE [dbo].[usp_InvoicePaymentHandle]
	@Action nchar(3),
	@InvoicePaymentId int = 0,
	@InvoiceId int = 0,
	@PayDate smalldatetime = NULL,
	@ClientId int = 0,
	@LoginId int = 0,
	@Amount numeric(10,2) = 0
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
		IF isnull(@InvoicePaymentId,0) = 0 AND isnull(@InvoiceId,0) = 0
			BEGIN
				SELECT [PK_InvoicePaymentID]
					  ,[PayDate]
					  ,[FK_InvoiceID]
					  ,[FK_ClientID]
					  ,[FK_LoginID]
					  ,[Amount]
				  FROM [dbo].[tbl_InvoicePayment]
				 WHERE [Active] = 1
			END
		IF isnull(@InvoicePaymentId,0) = 0 AND (@InvoiceId > 0)
			BEGIN
				SELECT pay.[PK_InvoicePaymentID]
					  ,pay.[PayDate]
					  ,pay.[FK_InvoiceID]
					  ,pay.[FK_ClientID]
					  ,pay.[FK_LoginID]
					  ,pay.[Amount]
					  ,clt.[FirstName]
					  ,clt.[MiddleName]
					  ,clt.[FamilyName]
					  ,isnull(lgn.[LoginName],'') AS [LoginName]
				FROM [dbo].[tbl_InvoicePayment] pay
				INNER JOIN dbo.[tbl_Clients] clt
					ON pay.[FK_ClientID] = clt.[PK_ClientId]
					--AND clt.[Active] = 1
				LEFT OUTER JOIN dbo.[tbl_Logins] lgn
					ON pay.[FK_LoginID] = lgn.[PK_LoginId]
					--AND lgn.[Active] = 1
				WHERE [FK_InvoiceID] = @InvoiceId
				  AND pay.[Active] = 1
			END
		IF @InvoicePaymentId > 0
			BEGIN
				SELECT [PK_InvoicePaymentID]
					  ,[PayDate]
					  ,[FK_InvoiceID]
					  ,[FK_ClientID]
					  ,[FK_LoginID]
					  ,[Amount]
				  FROM [dbo].[tbl_InvoicePayment]
				 WHERE [PK_InvoicePaymentID] = @InvoicePaymentId
				   AND [Active] = 1
			END
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_InvoicePayment]
				   ([PayDate]
				   ,[FK_InvoiceID]
				   ,[FK_ClientID]
				   ,[FK_LoginID]
				   ,[Amount])
			 VALUES
				   (@Paydate
				   ,@InvoiceId
				   ,@ClientId
				   ,@LoginId
				   ,@Amount)
		--SELECT IDENT_CURRENT('tbl_InvoicePayment') AS InvoicePaymentId
	END

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_InvoicePayment]
		   SET [PayDate] = @PayDate
			  ,[FK_InvoiceID] = @InvoiceId
			  ,[FK_ClientID] = @ClientId
			  ,[FK_LoginID] = @LoginId
			  ,[Amount] = @Amount
		 WHERE [PK_InvoicePaymentID] = @InvoicePaymentId
	END

IF @Action = 'Del'
	BEGIN
		UPDATE [dbo].[tbl_InvoicePayment]
		SET [Active] = 0
		WHERE [PK_InvoicePaymentID] = @InvoicePaymentId
	END
;
