TRUNCATE TABLE tbl_ReportArguments
TRUNCATE TABLE tbl_ReportFields
DELETE FROM tbl_Reports

DBCC CHECKIDENT ([tbl_ReportArguments], NORESEED)
DBCC CHECKIDENT ([tbl_ReportArguments], RESEED, 0)

DBCC CHECKIDENT ([tbl_ReportFields], NORESEED)
DBCC CHECKIDENT ([tbl_ReportFields], RESEED, 0)

DBCC CHECKIDENT ([tbl_Reports], NORESEED)
DBCC CHECKIDENT ([tbl_Reports], RESEED, 0)
;