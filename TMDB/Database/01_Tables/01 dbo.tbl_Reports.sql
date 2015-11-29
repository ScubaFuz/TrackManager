SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Reports](
	[PK_ReportId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[ReportName] [nvarchar](50) NOT NULL,
	[ReportType] [nchar](1) NOT NULL,
	[PrimaryMenu] [nvarchar](50) NOT NULL,
	[SecondaryMenu] [nvarchar](50) NULL,
	[ProcedureName] [nvarchar](100) NOT NULL,
	[Visible] [bit] NOT NULL DEFAULT ((1)),
	[Active] [bit] NOT NULL DEFAULT ((1))
) ON [PRIMARY]
END;

CREATE UNIQUE INDEX [IX_tbl_Reports] ON [dbo].[tbl_Reports] ([ReportName],[PrimaryMenu]) ON [PRIMARY];


