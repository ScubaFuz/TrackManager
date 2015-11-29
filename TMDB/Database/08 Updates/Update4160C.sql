UPDATE tbl_Invoice SET [InvoiceName] = (SELECT ConfigValue FROM tbl_Config WHERE Category = 'General' AND ConfigName = 'InvoiceName')
	,[InvoiceNumber] = REPLACE([InvoiceNumber],(SELECT ConfigValue FROM tbl_Config WHERE Category = 'General' AND ConfigName = 'InvoiceName'),'');
UPDATE tbl_Invoice SET [InvoiceNumber] = PK_InvoiceID WHERE ISNUMERIC([InvoiceNumber]) = 0;


