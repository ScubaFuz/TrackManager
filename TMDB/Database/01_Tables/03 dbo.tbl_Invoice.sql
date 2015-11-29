SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Invoice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Invoice](
	[PK_InvoiceID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[InvoiceName] [nvarchar](20) NULL,
	[InvoiceNumber] [int] NULL,
	[InvoiceDate] [smalldatetime] NULL,
	[FK_ClientID] [int] NULL,
	[FK_LoginID] [int] NULL,
	[Payed] [bit] NOT NULL DEFAULT ((0)),
	[Active] [bit] NOT NULL DEFAULT ((1))
) ON [PRIMARY]
END;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Invoice_tbl_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Invoice]'))
ALTER TABLE [dbo].[tbl_Invoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Invoice_tbl_Clients] FOREIGN KEY([FK_ClientID])
REFERENCES [dbo].[tbl_Clients] ([PK_ClientID]);

ALTER TABLE [dbo].[tbl_Invoice] CHECK CONSTRAINT [FK_tbl_Invoice_tbl_Clients];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Invoice_tbl_Logins]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Invoice]'))
ALTER TABLE [dbo].[tbl_Invoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Invoice_tbl_Logins] FOREIGN KEY([FK_LoginID])
REFERENCES [dbo].[tbl_Logins] ([PK_LoginID]);

ALTER TABLE [dbo].[tbl_Invoice] CHECK CONSTRAINT [FK_tbl_Invoice_tbl_Logins];

