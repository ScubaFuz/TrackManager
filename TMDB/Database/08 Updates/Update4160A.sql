INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','chkShowAllLessonTypes','Toon alle lestypen van elke klant','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Properties','strMissingLessontype','U heeft een Lestype nodig om dit type afspraak te maken.','Prop');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Properties','strDeleteMax1Client','U kunt slechts 1 afspraak tegelijk verwijderen.','Prop');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','chkRequireLessontype','Lestype is verplicht voor de Bar','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','btnRefreshDatabase','Ververs Database','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','lblClientFieldHeight','Klant Veld Hoogte','Text');
INSERT INTO [dbo].[tbl_Language]([Language],[LanguageForm],[LanguageItem],[LanguageText],[LanguageType]) VALUES ('NL','Settings','chkDeleteMax1Client','Verwijder max 1 afspraak tegelijk','Text');

DECLARE @ReportID int
SELECT @ReportID = [PK_ReportId]
FROM [dbo].[tbl_Reports]
WHERE ReportName = 'Overbooked'
	AND [PrimaryMenu] = 'Finance'
	AND [Active] = 1;

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Appointment','Afspraak',15,1,'String',NULL,1);
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'ClientID','KlantNr',10,1,'String',NULL,2);
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'FirstName','Voornaam',20,1,'String',NULL,3);
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'FamilyName','Achternaam',20,1,'String',NULL,4);

UPDATE [tbl_ReportFields] SET [FieldOrder] = 5 WHERE [FK_ReportId] = @ReportID AND [FieldName] = 'GroupId';
UPDATE [tbl_ReportFields] SET [FieldOrder] = 6 WHERE [FK_ReportId] = @ReportID AND [FieldName] = 'GroupName';
UPDATE [tbl_ReportFields] SET [FieldOrder] = 7 WHERE [FK_ReportId] = @ReportID AND [FieldName] = 'LessonCount';
UPDATE [tbl_ReportFields] SET [FieldOrder] = 8 WHERE [FK_ReportId] = @ReportID AND [FieldName] = 'InvoiceLessons';
UPDATE [tbl_ReportFields] SET [FieldOrder] = 9 WHERE [FK_ReportId] = @ReportID AND [FieldName] = 'Difference';
