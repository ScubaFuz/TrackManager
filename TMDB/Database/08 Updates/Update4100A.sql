INSERT INTO [tbl_Arguments] ([ArgumentName])VALUES('@Language')
UPDATE [dbo].[tbl_Memo] SET [Type] = 'Group' WHERE [Type] = 'Finance'
UPDATE [dbo].[tbl_Memo] SET [Type] = 'Client' WHERE [Type] = 'Report'
;