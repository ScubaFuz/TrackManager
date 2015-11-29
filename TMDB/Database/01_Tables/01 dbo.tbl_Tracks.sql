SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Tracks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Tracks](
	[PK_TrackID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[TrackName] [nvarchar](50) NULL,
	[TrackOffset] [int] NOT NULL DEFAULT ((0)),
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;
