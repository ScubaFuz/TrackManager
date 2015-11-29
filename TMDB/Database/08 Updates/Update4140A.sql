INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Properties','strOverbookClient','U staat op het punt om een klant te overboeken.','Prop');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lvwButtons_btnAppRemove','Verwijder uit Lijst','ListItem');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lvwButtons_btnAppCreate','Afspraak Maken','ListItem');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lvwButtons_btnAppMove','Afspraak Verplaatsen','ListItem');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lvwButtons_btnAppDelete','Afspraak Verwijderen','ListItem');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lvwButtons_btnAppClear','Lijst Wissen','ListItem');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','tpgButtons','Knoppen','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','btnButtonUp','Omhoog','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','btnButtonDown','Omlaag','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','btnButtonOrderSave','Opslaan','Text');

INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','tpgGeneral','Algemeen','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','grpDisplayWarningOverbooked','Toon een waarschuwing bij overboeken','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','rbnOverbookingNone','Toon geen waarschuwing','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','rbnOverbookingGroup','Toon een waarschuwing op groepniveau','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','rbnOverbookingClient','Toon een waarschuwing op klantniveau','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','btnSaveSettingsGeneral','Opslaan','Text');

INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Properties','strGroup','Groep','Prop');

INSERT INTO [dbo].[tbl_AppType] ([AppType]) VALUES ('Track')
INSERT INTO [dbo].[tbl_AppType] ([AppType]) VALUES ('Teacher')
INSERT INTO [dbo].[tbl_AppType] ([AppType]) VALUES ('Bar')
INSERT INTO [dbo].[tbl_AppType] ([AppType]) VALUES ('Lock')

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Appointment_tbl_AppType]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Appointment]'))
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Appointment_tbl_AppType] FOREIGN KEY([AppType])
REFERENCES [dbo].[tbl_AppType] ([AppType]);

ALTER TABLE [dbo].[tbl_Appointment] CHECK CONSTRAINT [FK_tbl_Appointment_tbl_AppType];