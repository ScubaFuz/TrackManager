SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_ReportArguments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_ReportArguments](
	[PK_ReportArgumentId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[FK_ReportId] [int] NOT NULL,
	[FK_ArgumentId] [int] NOT NULL,
	[IsOptional] [bit] NOT NULL DEFAULT ((1)),
	[IsSelected] [bit] NOT NULL DEFAULT ((0))
) ON [PRIMARY]
END;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_ReportArguments_tbl_Arguments]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_ReportArguments]'))
ALTER TABLE [dbo].[tbl_ReportArguments]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ReportArguments_tbl_Arguments] FOREIGN KEY([FK_ArgumentId])
REFERENCES [dbo].[tbl_Arguments] ([PK_ArgumentId]);

ALTER TABLE [dbo].[tbl_ReportArguments] CHECK CONSTRAINT [FK_tbl_ReportArguments_tbl_Arguments];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_ReportArguments_tbl_Reports]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_ReportArguments]'))
ALTER TABLE [dbo].[tbl_ReportArguments]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ReportArguments_tbl_Reports] FOREIGN KEY([FK_ReportId])
REFERENCES [dbo].[tbl_Reports] ([PK_ReportId]);

ALTER TABLE [dbo].[tbl_ReportArguments] CHECK CONSTRAINT [FK_tbl_ReportArguments_tbl_Reports];

