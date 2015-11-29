SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_ReportFields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_ReportFields](
	[PK_ReportFieldId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[FK_ReportId] [int] NOT NULL,
	[FieldName] [nvarchar](50) NULL,
	[FieldAlias] [nvarchar](50) NULL,
	[FieldWidth] [int] NULL,
	[FieldShow] [bit] NOT NULL DEFAULT ((1)),
	[FieldType] [nvarchar](50) NULL,
	[FieldDefault] [nvarchar](50) NULL,
	[FieldOrder] [int] NULL
) ON [PRIMARY]
END;

ALTER TABLE [dbo].[tbl_ReportFields]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ReportFields_tbl_Reports] FOREIGN KEY([FK_ReportId])
REFERENCES [dbo].[tbl_Reports] ([PK_ReportId]);

ALTER TABLE [dbo].[tbl_ReportFields] CHECK CONSTRAINT [FK_tbl_ReportFields_tbl_Reports];
