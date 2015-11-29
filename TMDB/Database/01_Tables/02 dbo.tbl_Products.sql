SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Products](
	[PK_ProductID] [int] IDENTITY(1,1) PRIMARY KEY NONCLUSTERED NOT NULL,
	[ProductText] [nvarchar](100) NULL,
	[ProductCount] [int] NULL,
	[ProductAmount] [numeric](10, 2) NULL,
	[Tax] [int] NOT NULL CONSTRAINT [DF_tbl_Products_FK_Tax]  DEFAULT ((0)),
	[Sort] [tinyint] NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;
