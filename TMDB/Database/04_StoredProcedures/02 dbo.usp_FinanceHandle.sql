CREATE PROCEDURE [dbo].[usp_FinanceHandle]
	@Action nchar(3),
	@SeasonStart datetime,
	@SeasonEnd datetime,
	@InvoiceId int = 0,
	@InvoiceName nvarchar(50) = NULL,
	@InvoiceNumber int = NULL,
	@InvoiceLineId int = 0,
	@InvoiceDate smalldatetime = NULL,
	@GroupId bigint = 0,
	@ClientId int = 0,
	@LoginId int = 0,
	@Payed bit = 0,
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
-- 1.1		2013-07-10	BT		Added InvoiceNumber		
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- 2.1		2013-10-20	BT		Added Active=1 to invoicelines and payments
-- 3.0		2014-12-02	BT		Unpayed invoices always show.
-- 4.0		2015-01-13	BT		Replaced InvoiceNumber with InvoiceName and InvoiceNumber
-- ****************************************************************************

IF @Action = 'Get'
	BEGIN
		IF ISNULL(@invoiceId,0) = 0 AND @GroupId > 0
			BEGIN
				SELECT inv.[PK_InvoiceID]
					,inv.[InvoiceName]
					,inv.[InvoiceNumber]
					,inv.[InvoiceDate]
					,inv.[FK_ClientID]
					,clt.[FK_GroupId]
					,clt.[FirstName]
					,clt.[MiddleName]
					,clt.[FamilyName]
					,inv.[FK_LoginID]
					,lgn.[LoginName]
					,inv.[Payed]
					,isnull(iln.ilnDescription,' ') as ilnDescription
					,isnull(iln.ilnCount,0) as ilnCount
					,isnull(iln.ilnAmount,0) as ilnAmount
					,isnull(ipy.ipyAmount,0) as ipyAmount
					,isnull(iln.ilnAmount,0) - isnull(ipy.ipyAmount,0) As opnAmount
					,ipy.ipyPayDate
				FROM [dbo].[tbl_Invoice] inv
				INNER JOIN tbl_Clients clt
				ON inv.[FK_ClientID] = clt.[PK_ClientID]
				INNER JOIN tbl_Logins lgn
				ON inv.[FK_loginID] = lgn.[PK_loginID]
				LEFT OUTER JOIN
					(SELECT ilc.[FK_InvoiceID] AS ilnInvoiceId
						,MAX(ilc.[Description]) AS ilnDescription
						,SUM(ilc.[Count]) AS ilnCount
						,SUM(ilc.[Amount]) AS ilnAmount
					FROM [dbo].[tbl_InvoiceLine] ilc
					WHERE ilc.[Active] = 1
					GROUP BY ilc.[FK_InvoiceID]) iln
				ON inv.[PK_InvoiceID] = iln.ilnInvoiceId
				LEFT OUTER JOIN
					(SELECT ipc.[FK_InvoiceID] AS ipyInvoiceId
						,SUM(ipc.[Amount]) AS ipyAmount
						,MAX(ipc.[payDate]) AS ipyPayDate
					FROM [dbo].[tbl_InvoicePayment] ipc
					WHERE ipc.[Active] = 1
					GROUP BY ipc.[FK_InvoiceID]) ipy
				ON inv.[PK_InvoiceID] = ipy.ipyInvoiceId
				WHERE clt.[FK_GroupId] = @GroupId
				  AND (COALESCE(ipy.ipyPayDate,0) between @seasonStart AND @SeasonEnd OR inv.[Payed] = 0)
				  AND inv.[Active] = 1
				ORDER BY inv.[InvoiceDate] DESC,inv.[InvoiceNumber] DESC, inv.[FK_ClientID]
			END
		IF @invoiceId > 0 
			BEGIN
				SELECT inv.[PK_InvoiceID]
					,inv.[InvoiceName]
					,inv.[InvoiceNumber]
					,inv.[InvoiceDate]
					,inv.[FK_ClientID] AS invClientId
					,icl.[FK_GroupId]
					,icl.[FirstName] AS invFirstName
					,icl.[MiddleName] AS invMiddleName
					,icl.[FamilyName] AS invFamilyName
					,inv.[FK_LoginID] AS invLoginId
					,ilg.[LoginName] AS invLoginName
					,inv.[Payed]
					,iln.ilnClientId
					,iln.ilnFirstName
					,iln.ilnMiddleName
					,iln.ilnFamilyName
					,iln.ilnLoginId
					,iln.ilnLoginName
					,iln.[Description]
					,iln.[Count]
					,iln.ilnAmount
					,iln.[FK_Tax]
					,ipy.ipyClientId
					,ipy.ipyFirstName
					,ipy.ipyMiddleName
					,ipy.ipyFamilyName
					,ipy.ipyLoginId
					,ipy.ipyLoginName
					,ipy.ipyAmount
				FROM [dbo].[tbl_Invoice] inv
				INNER JOIN [dbo].[tbl_Clients] icl
					ON inv.[FK_ClientID] = icl.[PK_ClientID]
				INNER JOIN dbo.[tbl_Logins] ilg
					ON inv.[FK_LoginID] = ilg.[PK_LoginID]
				LEFT OUTER JOIN
					(SELECT ilc.[FK_InvoiceID] AS ilnInvoiceId
							,ilc.[FK_ClientID] AS ilnClientId
							,ilc.[Description]
							,ilc.[Count]
							,ilc.[Amount] AS ilnAmount
							,ilc.[FK_Tax]
							,clt.[FirstName] AS ilnFirstName
							,clt.[MiddleName] AS ilnMiddleName
							,clt.[FamilyName] AS ilnFamilyName
							,ilc.[FK_LoginID] AS ilnLoginId
							,lgn.[LoginName] AS ilnLoginName
						FROM [dbo].[tbl_InvoiceLine] ilc
						INNER JOIN [dbo].[tbl_Clients] clt
						ON ilc.[FK_ClientID] = clt.[PK_ClientID]
						INNER JOIN dbo.[tbl_Logins] lgn
						ON ilc.[FK_LoginID] = lgn.[PK_LoginID]
						WHERE ilc.[Active] = 1) iln
					ON inv.[PK_InvoiceID] = iln.ilnInvoiceId
				LEFT OUTER JOIN
					(SELECT pay.[FK_InvoiceID] AS ipyInvoiceId
							,pay.[FK_ClientID] AS ipyClientId
							,clt.[FirstName] AS ipyFirstName
							,clt.[MiddleName] AS ipyMiddleName
							,clt.[FamilyName] AS ipyFamilyName
							,pay.[FK_LoginID] AS ipyLoginId
							,lgn.[LoginName] AS ipyLoginName
							,pay.[Amount] AS ipyAmount
						FROM [dbo].[tbl_InvoicePayment] pay
						INNER JOIN [dbo].[tbl_Clients] clt
						ON pay.[FK_ClientID] = clt.[PK_ClientID]
						INNER JOIN dbo.[tbl_Logins] lgn
						ON pay.[FK_LoginID] = lgn.[PK_LoginID]
						WHERE pay.[Active] = 1) ipy
					ON inv.[PK_InvoiceID] = ipy.ipyInvoiceId
				WHERE inv.[PK_InvoiceID] = @InvoiceId
				  --AND inv.[Active] = 1
			END
	END

IF @Action = 'Ins'
	BEGIN
		IF @InvoiceId IS NULL OR @InvoiceId = 0
			BEGIN
				DECLARE @ReturnId int
				EXEC @InvoiceId = dbo.usp_InvoiceHandle @Action='Ins', 
					@InvoiceName = @InvoiceName,
					@InvoiceNumber = @InvoiceNumber,
					@InvoiceDate = @InvoiceDate, 
					@ClientId = @ClientId, 
					@LoginId = @LoginId,
					@ReturnId = @ReturnId OUTPUT
				SET @InvoiceId = @ReturnId
			END
		IF @InvoiceId > 0 AND @Description IS NOT NULL
			BEGIN
				EXEC usp_InvoiceLineHandle @Action='Ins', 
					@InvoiceId = @InvoiceId,
					@ClientId = @ClientId, 
					@LoginId = @LoginId, 
					@Description = @Description,
					@Count = @Count,
					@Amount = @Amount,
					@Tax = @Tax
			END
		SELECT @InvoiceId AS InvoceId
	END

IF @Action = 'Del'
	BEGIN
		UPDATE [dbo].[tbl_InvoicePayment]
		SET [Active] = 0
		WHERE [FK_InvoiceID] = @InvoiceId

		UPDATE [dbo].[tbl_InvoiceLine]
		SET [Active] = 0
		WHERE [FK_InvoiceID] = @InvoiceId

		UPDATE [dbo].[tbl_Invoice]
		SET [Active] = 0
		WHERE [PK_InvoiceID] = @InvoiceId
	END

If @Action = 'Max'
	BEGIN
		BEGIN TRY
			DECLARE @InvoiceNumberNew int, @InvoiceNumberOrg int
			SET @InvoiceNumberOrg = 1
			SELECT @InvoiceName = ConfigValue FROM tbl_Config WHERE Category = 'General' AND ConfigName = 'InvoiceName'
			SELECT @InvoiceNumberOrg = ConfigValue FROM tbl_Config WHERE Category = 'General' AND ConfigName = 'InvoiceNumber'
			SELECT @InvoiceNumberNew = MAX([InvoiceNumber])
			FROM [dbo].[tbl_Invoice]
			WHERE [InvoiceName] = ISNULL(@InvoiceName,'')
				--AND [InvoiceDate] between @SeasonStart and @SeasonEnd
			SELECT CASE WHEN ISNULL(@InvoiceNumberOrg,1) > ISNULL(@InvoiceNumberNew,0)
				THEN ISNULL(@InvoiceNumberOrg,1)
				ELSE @InvoiceNumberNew + 1
			END AS InvoiceNumber
		END TRY
		BEGIN CATCH
			SELECT 1 AS InvoiceNumber
		END CATCH
	END
;
