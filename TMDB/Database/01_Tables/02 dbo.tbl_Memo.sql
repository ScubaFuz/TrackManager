SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Memo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Memo](
	[PK_MemoId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[FK_GroupId] [bigint] NULL,
	[MemoDate] [smalldatetime] NULL,
	[MemoText] [nvarchar](max) NULL
) ON [PRIMARY]
END;



