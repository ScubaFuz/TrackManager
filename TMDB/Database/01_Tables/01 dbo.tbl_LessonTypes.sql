SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LessonTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_LessonTypes](
	[PK_LessonTypeID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED  NOT NULL,
	[LessonTypeName] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

