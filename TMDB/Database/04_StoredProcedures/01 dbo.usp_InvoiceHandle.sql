CREATE PROCEDURE [dbo].[usp_InvoiceHandle]
	@Action nchar(3),
	@InvoiceId int = 0,
	@InvoiceName nvarchar(50) = NULL,
	@InvoiceNumber int = NULL,
	@InvoiceDate smalldatetime = NULL,
	@ClientId int = 0,
	@LoginId int = 0,
	@Payed bit = 0,
	@ReturnId int OUTPUT
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial version
-- 1.1		2010-11-11	BT		isnull added to where-clause
-- 1.2		2013-07-10	BT		Added InvoiceNumber
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- 2.1		2013-10-20	BT		Added Active=1 to chk
-- 3.0		2015-01-13	BT		Added InvoiceName
-- ****************************************************************************

SET @ReturnId = 0

IF @Action = 'Get'
	BEGIN
		SELECT [PK_InvoiceID]
			,[InvoiceName]
			,[InvoiceNumber]
			,[InvoiceDate]
			,[FK_ClientID]
			,[FK_LoginID]
			,[Payed]
		FROM [dbo].[tbl_Invoice]
		WHERE [Active] = 1
			AND ISNULL(@InvoiceId,0) IN ([PK_InvoiceID],0)
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Invoice]
				   ([InvoiceName]
				   ,[InvoiceNumber]
				   ,[InvoiceDate]
				   ,[FK_ClientID]
				   ,[FK_LoginID]
				   ,[Payed])
			 VALUES
				   (@InvoiceName
				   ,@InvoiceNumber
				   ,@InvoiceDate
				   ,@ClientId
				   ,@LoginId
				   ,@Payed)
		SET @ReturnId = IDENT_CURRENT('tbl_Invoice')
		Return @ReturnId
	END

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_Invoice]
		SET [InvoiceName] = @InvoiceName
			,[InvoiceNumber] = @InvoiceNumber
			,[FK_ClientID] = @ClientId
			,[FK_LoginID] = @LoginId
			,[Payed] = @Payed
		WHERE [PK_InvoiceID] = @InvoiceId
	END

IF @Action = 'Pay'
	BEGIN
		UPDATE [dbo].[tbl_Invoice]
		   SET [Payed] = @Payed
		 WHERE [PK_InvoiceID] = @InvoiceId
	END

IF @Action = 'Chk'
	BEGIN
		UPDATE [dbo].[tbl_Invoice]
		SET [dbo].[tbl_Invoice].[Payed] = 0 
		FROM (
			SELECT inv.[PK_InvoiceID]
				,inv.[InvoiceDate]
				,inv.[Payed]
				,isnull(iln.ilnAmount,0) as ilnAmount
				,isnull(ipy.ipyAmount,0) as ipyAmount
			FROM [dbo].[tbl_Invoice] inv
			LEFT OUTER JOIN
				(SELECT ilc.[FK_InvoiceID] AS ilnInvoiceId
					,SUM(ilc.[Amount]) AS ilnAmount
				FROM [dbo].[tbl_InvoiceLine] ilc
				WHERE ilc.Active = 1
					AND ISNULL(@InvoiceId,0) IN (ilc.FK_InvoiceID,0)
				GROUP BY ilc.[FK_InvoiceID]) iln
			ON inv.[PK_InvoiceID] = iln.ilnInvoiceId
			LEFT OUTER JOIN
				(SELECT ipc.[FK_InvoiceID] AS ipyInvoiceId
					,SUM(ipc.[Amount]) AS ipyAmount
				FROM [dbo].[tbl_InvoicePayment] ipc
				WHERE ipc.Active = 1
					AND ISNULL(@InvoiceId,0) IN (ipc.FK_InvoiceID,0)
				GROUP BY ipc.[FK_InvoiceID]) ipy
			ON inv.[PK_InvoiceID] = ipy.ipyInvoiceId
			WHERE inv.[Payed] = 1 
				AND ISNULL(@InvoiceId,0) IN (inv.PK_InvoiceID,0)
				AND isnull(ilnAmount,0)-isnull(ipyAmount,0) <> 0) pay
		WHERE pay.[PK_InvoiceID] = [dbo].[tbl_Invoice].[PK_InvoiceID]
			AND ISNULL(@InvoiceId,0) IN ([dbo].[tbl_Invoice].[PK_InvoiceID], 0)
			AND [tbl_Invoice].[Active] = 1

		UPDATE [dbo].[tbl_Invoice]
		SET [dbo].[tbl_Invoice].[Payed] = 1 
		FROM (
			SELECT inv.[PK_InvoiceID]
				,inv.[InvoiceDate]
				,inv.[Payed]
				,isnull(iln.ilnAmount,0) as ilnAmount
				,isnull(ipy.ipyAmount,0) as ipyAmount
			FROM [dbo].[tbl_Invoice] inv
			LEFT OUTER JOIN
				(SELECT ilc.[FK_InvoiceID] AS ilnInvoiceId
					,SUM(ilc.[Amount]) AS ilnAmount
				FROM [dbo].[tbl_InvoiceLine] ilc
				WHERE ilc.Active = 1
					AND ISNULL(@InvoiceId,0) IN (ilc.FK_InvoiceID,0)
				GROUP BY ilc.[FK_InvoiceID]) iln
			ON inv.[PK_InvoiceID] = iln.ilnInvoiceId
			LEFT OUTER JOIN
				(SELECT ipc.[FK_InvoiceID] AS ipyInvoiceId
					,SUM(ipc.[Amount]) AS ipyAmount
				FROM [dbo].[tbl_InvoicePayment] ipc
				WHERE ipc.Active = 1
					AND ISNULL(@InvoiceId,0) IN (ipc.FK_InvoiceID,0)
				GROUP BY ipc.[FK_InvoiceID]) ipy
			ON inv.[PK_InvoiceID] = ipy.ipyInvoiceId
			WHERE Payed = 0 
				AND ISNULL(@InvoiceId,0) IN (inv.PK_InvoiceID,0)
				AND isnull(ilnAmount,0)-isnull(ipyAmount,0) = 0) pay
		WHERE pay.[PK_InvoiceID] = [dbo].[tbl_Invoice].[PK_InvoiceID]
			AND ISNULL(@InvoiceId,0) IN ([dbo].[tbl_Invoice].[PK_InvoiceID], 0)
			AND [dbo].[tbl_Invoice].[Active] = 1
	END

IF @Action = 'Del'
	BEGIN
		UPDATE [dbo].[tbl_Invoice]
		SET [Active] = 0
		WHERE [PK_InvoiceID] = @InvoiceId
	END
;
