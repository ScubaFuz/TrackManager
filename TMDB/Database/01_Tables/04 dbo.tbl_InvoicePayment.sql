SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_InvoicePayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_InvoicePayment](
	[PK_InvoicePaymentID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[PayDate] [smalldatetime] NULL,
	[FK_InvoiceID] [int] NULL,
	[FK_ClientID] [int] NULL,
	[FK_LoginID] [int] NULL,
	[Amount] [numeric](10, 2) NULL,
	[FK_PaymentMethodID] [int] NULL,
	[Active] [bit] NOT NULL DEFAULT ((1))
) ON [PRIMARY]
END;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_InvoicePayment_tbl_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_InvoicePayment]'))
ALTER TABLE [dbo].[tbl_InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InvoicePayment_tbl_Clients] FOREIGN KEY([FK_ClientID])
REFERENCES [dbo].[tbl_Clients] ([PK_ClientID]);

ALTER TABLE [dbo].[tbl_InvoicePayment] CHECK CONSTRAINT [FK_tbl_InvoicePayment_tbl_Clients];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_InvoicePayment_tbl_Invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_InvoicePayment]'))
ALTER TABLE [dbo].[tbl_InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InvoicePayment_tbl_Invoice] FOREIGN KEY([FK_InvoiceID])
REFERENCES [dbo].[tbl_Invoice] ([PK_InvoiceID]);

ALTER TABLE [dbo].[tbl_InvoicePayment] CHECK CONSTRAINT [FK_tbl_InvoicePayment_tbl_Invoice];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_InvoicePayment_tbl_Logins]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_InvoicePayment]'))
ALTER TABLE [dbo].[tbl_InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InvoicePayment_tbl_Logins] FOREIGN KEY([FK_LoginID])
REFERENCES [dbo].[tbl_Logins] ([PK_LoginID]);

ALTER TABLE [dbo].[tbl_InvoicePayment] CHECK CONSTRAINT [FK_tbl_InvoicePayment_tbl_Logins];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_InvoicePayment_tbl_PaymentMethods]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_PaymentMethods]'))
ALTER TABLE [dbo].[tbl_InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InvoicePayment_tbl_PaymentMethods] FOREIGN KEY([FK_PaymentMethodID])
REFERENCES [dbo].[tbl_PaymentMethods] ([PK_PaymentMethodID]);

ALTER TABLE [dbo].[tbl_InvoicePayment] CHECK CONSTRAINT [FK_tbl_InvoicePayment_tbl_PaymentMethods];
