DBCC CHECKIDENT ([tbl_ReportArguments], NORESEED)
DELETE FROM [tbl_ReportArguments]
DBCC CHECKIDENT ([tbl_ReportArguments], RESEED, 0)

DBCC CHECKIDENT ([tbl_ReportFields], NORESEED)
DELETE FROM [tbl_ReportFields]
DBCC CHECKIDENT ([tbl_ReportFields], RESEED, 0)

DBCC CHECKIDENT ([tbl_Reports], NORESEED)
DELETE FROM [tbl_Reports]
DBCC CHECKIDENT ([tbl_Reports], RESEED, 0)
