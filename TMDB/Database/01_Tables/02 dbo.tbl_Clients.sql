SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Clients](
	[PK_ClientID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[FamilyName] [nvarchar](50) NULL,
	[ClientName]  AS (RTRIM(REPLACE((COALESCE([FirstName],'')+COALESCE(' '+[MiddleName],''))+COALESCE(' '+[FamilyName],''),'  ',' '))),
	[FK_GroupID] [bigint] NULL,
	[PrimaryContact] [bit] NOT NULL DEFAULT ((0)),
	[Street] [nvarchar](50) NULL,
	[HouseNumber] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[TelePhone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MailingList] [bit] NOT NULL DEFAULT ((0)),
	[FK_PrContactID] [int] NULL,
	[DayOfBirth] [smalldatetime] NULL,
	[BankAccount] [nvarchar](50) NULL,
	[CreditCard] [nvarchar](50) NULL,
	[CreditCardCcv] [int] NULL,
	[CreditCardExpire] [nvarchar](6) NULL,
	[Remarks] [nvarchar](max) NULL,
	[CustomField1] [bit] NOT NULL DEFAULT ((0)),
	[CustomField2] [bit] NOT NULL DEFAULT ((0)),
	[CustomField3] [nvarchar](250) NULL,
	[CustomField4] [nvarchar](250) NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

CREATE INDEX [IX_tbClients] ON [dbo].[tbl_Clients] ([FK_GroupID],[FirstName],[FamilyName]) ON [PRIMARY];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbClients_tbl_Groups]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Clients]'))
ALTER TABLE [dbo].[tbl_Clients]  WITH CHECK ADD  CONSTRAINT [FK_tbClients_tbl_Groups] FOREIGN KEY([FK_GroupID])
REFERENCES [dbo].[tbl_Groups] ([PK_GroupID]);

ALTER TABLE [dbo].[tbl_Clients] CHECK CONSTRAINT [FK_tbClients_tbl_Groups];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbClients_tbl_PrContacts]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Clients]'))
ALTER TABLE [dbo].[tbl_Clients]  WITH CHECK ADD  CONSTRAINT [FK_tbClients_tbl_PrContacts] FOREIGN KEY([FK_PrContactID])
REFERENCES [dbo].[tbl_PrContacts] ([PK_PrContactID]);

ALTER TABLE [dbo].[tbl_Clients] CHECK CONSTRAINT [FK_tbClients_tbl_PrContacts];
