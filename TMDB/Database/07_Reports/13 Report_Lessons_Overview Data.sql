DECLARE @ReportId int

INSERT INTO [dbo].[tbl_Reports] ([ReportName],[ReportType],[PrimaryMenu],[SecondaryMenu],[ProcedureName],[Visible],[Active])
VALUES('Overview','S','Lessons','0','usp_Report_Lessons_Overview',1,1)
SET @ReportId = IDENT_CURRENT('tbl_Reports')

INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStart'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStop'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@ClientId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@GroupId'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@AppType'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@TrackId'

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'RowNumber','Nr',5,1,'String',NULL,1)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'AppDate','Datum',19,1,'DayDateTime',NULL,2)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Name','Naam',25,1,'String',NULL,3)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LessonCount','Lesnummer',10,1,'String',NULL,4)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'MemoText','Opmerkingen',100,1,'String',NULL,5)
