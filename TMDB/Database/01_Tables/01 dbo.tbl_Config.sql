SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Config]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Config](
	[PK_ConfigId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[Category] [nvarchar](50) NULL,
	[ConfigName] [nvarchar](50) NOT NULL,
	[ConfigValue] [nvarchar](100) NULL,
	[DateStart] [smalldatetime] NOT NULL CONSTRAINT [DF_tbl_Config_LastChange]  DEFAULT (getdate()),
	[DateStop] [smalldatetime] NULL,
	[DateChange] [smalldatetime] NULL,
	[Remarks] [nvarchar](250) NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

