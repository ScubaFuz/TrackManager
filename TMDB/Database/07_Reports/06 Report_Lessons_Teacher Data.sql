DECLARE @ReportId int

INSERT INTO [dbo].[tbl_Reports] ([ReportName],[ReportType],[PrimaryMenu],[SecondaryMenu],[ProcedureName],[Visible],[Active])
VALUES('Teacher','S','Lessons','0','usp_Report_Lessons_Teacher',1,1)
SET @ReportId = IDENT_CURRENT('tbl_Reports')

INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStart'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStop'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@ClientId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@GroupId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@AppType'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@TrackId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@Language'

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'RowNumber','Nr',5,1,'String',NULL,1)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'AppDate','Datum',19,1,'DayDateTime',NULL,2)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'TrackName','Baan',20,1,'String',NULL,3)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupName','Groep',20,1,'String',NULL,4)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupId','GroepNr',15,1,'String',NULL,5)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'ClientName','Klantnaam',15,1,'String',NULL,6)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Age','Leeftijd',10,1,'String',NULL,7)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LessonTypeName','Lestype',15,1,'String',NULL,9)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LessonCount','Lesnummer',10,1,'String',NULL,10)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LevelName','Niveau',15,1,'String',NULL,11)
