SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Tax]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Tax](
	[PK_Tax] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[TaxValue] [int] NOT NULL,
	[TaxDescription] [nvarchar](100) NULL,
	[Active] [bit] NOT NULL DEFAULT ((1))
) ON [PRIMARY]
END;
