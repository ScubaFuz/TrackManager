SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Language]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Language](
	[PK_LanguageId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[LanguageForm] [nvarchar](50) NOT NULL,
	[LanguageItem] [nvarchar](50) NOT NULL,
	[LanguageText] [nvarchar](255) NOT NULL,
	[LanguageType] [nvarchar](50) NOT NULL
) ON [PRIMARY]
END;
