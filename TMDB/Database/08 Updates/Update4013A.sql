ALTER TABLE [dbo].[tbl_InvoicePayment] ADD 
	[FK_PaymentMethodID] [int] NULL;

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_InvoicePayment_tbl_PaymentMethods]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_PaymentMethods]'))
ALTER TABLE [dbo].[tbl_InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InvoicePayment_tbl_PaymentMethods] FOREIGN KEY([FK_PaymentMethodID])
REFERENCES [dbo].[tbl_PaymentMethods] ([PK_PaymentMethodID]);

ALTER TABLE [dbo].[tbl_InvoicePayment] CHECK CONSTRAINT [FK_tbl_InvoicePayment_tbl_PaymentMethods];
