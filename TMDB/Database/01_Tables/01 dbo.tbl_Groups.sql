SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Groups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Groups](
	[PK_GroupID] [bigint] PRIMARY KEY CLUSTERED NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

INSERT INTO [dbo].[tbl_Groups]
	SELECT 1,'_Bar',1 UNION
	SELECT 2,'_Teachers',1;
