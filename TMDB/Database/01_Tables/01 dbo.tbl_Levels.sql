SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Levels]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Levels](
	[PK_LevelID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[LevelName] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[LevelCount] [int] NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

INSERT INTO [dbo].[tbl_Levels] ([LevelName],[Color],[LevelCount],[Active]) 
	VALUES ('Automatic','White','0',1);
	
