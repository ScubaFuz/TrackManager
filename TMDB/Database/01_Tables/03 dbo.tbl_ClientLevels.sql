SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_ClientLevels]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_ClientLevels](
	[PK_ClientLevelID] [int] IDENTITY(1,1) PRIMARY KEY NONCLUSTERED NOT NULL,
	[FK_ClientID] [int] NOT NULL,
	[FK_LessonTypeID] [int] NOT NULL,
	[FK_LevelID] [int] NOT NULL DEFAULT ((1)),
	[LessonCount] [int] NOT NULL DEFAULT ((0)),
	[ExtraCount] [int] NOT NULL DEFAULT ((0)),
	[PrimaryType] [bit] NOT NULL DEFAULT ((0)),
	[LastAction] [int] NOT NULL DEFAULT ((0)),
	[Active] [bit] NOT NULL DEFAULT ((1))
) ON [PRIMARY]
END;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_ClientLevels_tbClients]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_ClientLevels]'))
ALTER TABLE [dbo].[tbl_ClientLevels]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ClientLevels_tbClients] FOREIGN KEY([FK_ClientID])
REFERENCES [dbo].[tbl_Clients] ([PK_ClientID]);

ALTER TABLE [dbo].[tbl_ClientLevels] CHECK CONSTRAINT [FK_tbl_ClientLevels_tbClients];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_ClientLevels_tbl_LessonTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_ClientLevels]'))
ALTER TABLE [dbo].[tbl_ClientLevels]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ClientLevels_tbl_LessonTypes] FOREIGN KEY([FK_LessonTypeID])
REFERENCES [dbo].[tbl_LessonTypes] ([PK_LessonTypeID]);

ALTER TABLE [dbo].[tbl_ClientLevels] CHECK CONSTRAINT [FK_tbl_ClientLevels_tbl_LessonTypes];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_ClientLevels_tbl_Levels]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_ClientLevels]'))
ALTER TABLE [dbo].[tbl_ClientLevels]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ClientLevels_tbl_Levels] FOREIGN KEY([FK_LevelID])
REFERENCES [dbo].[tbl_Levels] ([PK_LevelID]);

ALTER TABLE [dbo].[tbl_ClientLevels] CHECK CONSTRAINT [FK_tbl_ClientLevels_tbl_Levels];
