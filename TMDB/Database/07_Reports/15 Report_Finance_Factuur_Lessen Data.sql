DECLARE @ReportId int

INSERT INTO [dbo].[tbl_Reports] ([ReportName],[ReportType],[PrimaryMenu],[SecondaryMenu],[ProcedureName],[Visible],[Active])
VALUES('Factuur Lessen','S','Finance','0','usp_Report_Finance_Factuur_Lessen',1,1)
SET @ReportId = IDENT_CURRENT('tbl_Reports')

INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,0,1 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStart'
INSERT INTO [tbl_ReportArguments] ([FK_ReportId],[FK_ArgumentId],[IsOptional],[IsSelected]) SELECT @ReportId, [PK_ArgumentId] ,1,0 FROM [dbo].[tbl_Arguments] WHERE [ArgumentName] = '@DateStop'

INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupID','GroepNr',15,1,'String',NULL,1)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'GroupName','Groep',20,1,'String',NULL,2)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'InvoiceCount','FactAantal',10,1,'String',NULL,3)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'LessonCount','LesAantal',10,1,'String',NULL,4)
INSERT INTO [tbl_ReportFields] ([FK_ReportId],[FieldName],[FieldAlias],[FieldWidth],[FieldShow],[FieldType],[FieldDefault],[FieldOrder])VALUES(@ReportId,'total','Totaal',10,1,'String',NULL,5)
