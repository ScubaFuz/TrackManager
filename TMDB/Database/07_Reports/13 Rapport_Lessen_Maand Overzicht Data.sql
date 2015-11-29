DECLARE @ReportId int
INSERT INTO [tbl_Reports] ([ReportName],[ReportType],[PrimaryMenu])VALUES('Maand Overzicht','S','Lessons')

SET @ReportId = IDENT_CURRENT('tbl_Reports')
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStart'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStop'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@ClientId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@GroupId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@AppType'

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Year','Jaar',5,1,'String',NULL,1)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Month','Maand',6,1,'String',NULL,2)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'AppType','Type',8,1,'String',NULL,3)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupName','Groep',20,1,'String',NULL,4)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupId','GroepNr',15,1,'String',NULL,5)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'FirstName','Voornaam',15,1,'String',NULL,6)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'MiddleName','tussenv.',10,1,'String',NULL,7)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'FamilyName','Achternaam',20,1,'String',NULL,8)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Count','Aantal',7,1,'String',NULL,9)
