SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Arguments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Arguments](
	[PK_ArgumentId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[ArgumentName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
END

