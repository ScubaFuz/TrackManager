CREATE PROCEDURE [dbo].[usp_ReportFieldsGet]
	@ReportID int = 0,
	@ReportName varchar(50) = NULL
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	*********************************************
-- 1.0		2010-01-01	BT		Eerste versie
-- 1.1		2013-10-08	BT		Added @ReportID
-- ****************************************************************************

SELECT [PK_ReportFieldId]
	  ,[FK_ReportId]
	  ,[FieldName]
	  ,[FieldAlias]
	  ,[FieldWidth]
	  ,[FieldShow]
	  ,[FieldType]
	  ,[FieldDefault]
	  ,[FieldOrder]
  FROM [dbo].[tbl_ReportFields] fld
INNER JOIN [dbo].[tbl_Reports] rep
	ON fld.[FK_ReportId] = rep.[PK_ReportId]
 WHERE ISNULL(@ReportName,'') IN (rep.[ReportName],'')
	AND ISNULL(@ReportID,0) IN (fld.[FK_ReportId],0)
ORDER BY fld.[FieldOrder]
;
