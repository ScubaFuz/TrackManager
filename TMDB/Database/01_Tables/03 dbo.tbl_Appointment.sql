SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Appointment](
	[PK_AppointmentId] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[AppDate] [smalldatetime] NOT NULL,
	[AppType] [nvarchar](20) NOT NULL,
	[FK_ClientId] [int] NULL,
	[FK_TrackId] [int] NULL,
	[TrackIndex] [int] NULL,
	[FK_LessonTypeId] [int] NULL,
	[FK_LevelId] [int] NULL,
	[LessonCount] [int] NULL,
	[ExtraCount] [int] NULL,
	[FK_LoginId] [int] NULL,
	[Active] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]
END;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_Clients] FOREIGN KEY([FK_ClientId])
REFERENCES [dbo].[tbl_Clients] ([PK_ClientID]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_Clients];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_LessonTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_LessonTypes] FOREIGN KEY([FK_LessonTypeId])
REFERENCES [dbo].[tbl_LessonTypes] ([PK_LessonTypeID]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_LessonTypes];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_Levels]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_Levels] FOREIGN KEY([FK_LevelId])
REFERENCES [dbo].[tbl_Levels] ([PK_LevelID]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_Levels];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_Logins]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_Logins] FOREIGN KEY([FK_LoginId])
REFERENCES [dbo].[tbl_Logins] ([PK_LoginID]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_Logins];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_Tracks]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_Tracks] FOREIGN KEY([FK_TrackId])
REFERENCES [dbo].[tbl_Tracks] ([PK_TrackID]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_Tracks];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_AppType]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_AppType] FOREIGN KEY([AppType])
REFERENCES [dbo].[tbl_AppType] ([AppType]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_AppType];