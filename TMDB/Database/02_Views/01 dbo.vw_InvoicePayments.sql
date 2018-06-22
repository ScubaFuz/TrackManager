CREATE VIEW [dbo].[vw_InvoicePayments]
AS
SELECT [FK_InvoiceID]
	,SUM([Amount]) as Amount
FROM [TrackManager].[dbo].[tbl_InvoicePayment]
WHERE [Active] = 1
GROUP BY [FK_InvoiceID]
	