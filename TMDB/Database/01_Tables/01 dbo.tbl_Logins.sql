SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Logins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Logins](
	[PK_LoginID] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[LoginName] [nvarchar](50) UNIQUE NONCLUSTERED NOT NULL,
	[LoginPassword] [nvarchar](250) NOT NULL,
	[DateStart] [smalldatetime] NOT NULL DEFAULT (getdate()),
	[DateStop] [smalldatetime] NULL,
	[Enabled] [bit] NOT NULL DEFAULT ((0)),
	[Security_Add] [bit] NOT NULL DEFAULT ((0)),
	[Security_Change] [bit] NOT NULL DEFAULT ((0)),
	[Security_Delete] [bit] NOT NULL DEFAULT ((0)),
	[Finance_Add] [bit] NOT NULL DEFAULT ((0)),
	[Finance_Change] [bit] NOT NULL DEFAULT ((0)),
	[Finance_Delete] [bit] NOT NULL DEFAULT ((0)),
	[Settings_Add] [bit] NOT NULL DEFAULT ((0)),
	[Settings_Change] [bit] NOT NULL DEFAULT ((0)),
	[Settings_Delete] [bit] NOT NULL DEFAULT ((0)),
	[Groups_Delete] [bit] NOT NULL DEFAULT ((0)),
	[Clients_Delete] [bit] NOT NULL DEFAULT ((0)),
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

INSERT INTO tbl_Logins VALUES ('Admin','1JlM9v0rh6c=',getdate()-1,NULL,1,1,1,1,1,1,1,1,1,1,1,1,1);

