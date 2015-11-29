SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_PrContacts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_PrContacts](
	[PK_PrContactID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[PrContactName] [nvarchar](100) NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;