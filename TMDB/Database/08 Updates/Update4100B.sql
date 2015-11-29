ALTER TABLE [dbo].[tbl_Reports] ADD 
	[SecondaryMenu] [nvarchar](50) NULL,
	[ProcedureName] [nvarchar](100) NULL,
	[Visible] [bit] NOT NULL DEFAULT 1,
	[Active] [bit] NOT NULL DEFAULT 1;
