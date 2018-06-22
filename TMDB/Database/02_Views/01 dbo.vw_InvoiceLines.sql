CREATE VIEW [dbo].[vw_InvoiceLines]
AS
SELECT [FK_InvoiceID]
	,MAX([Description]) AS [Description]
	,SUM([Amount]) AS Amount
FROM [TrackManager].[dbo].[tbl_InvoiceLine]
WHERE [Active] = 1
GROUP BY [FK_InvoiceID]
