SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_AppType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_AppType](
	[AppType] [nvarchar](20) PRIMARY KEY CLUSTERED NOT NULL
) ON [PRIMARY]
END;

