DECLARE @ReportId int

INSERT INTO [dbo].[tbl_Reports] ([ReportName],[ReportType],[PrimaryMenu],[SecondaryMenu],[ProcedureName],[Visible],[Active])
VALUES('Overbooked','S','Finance','4','usp_Report_Standard_Overbooked',1,1)

SET @ReportId = IDENT_CURRENT('tbl_Reports')

INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStart'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStop'

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupId','GroepNr',15,1,'String',NULL,5)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupName','Groep',20,1,'String',NULL,4)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LessonCount','Lesaantal',10,1,'String',NULL,9)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'InvoiceLessons','Gefactureerd',12,1,'String',NULL,9)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'Shortage','Te weinig',10,1,'String',NULL,9)

