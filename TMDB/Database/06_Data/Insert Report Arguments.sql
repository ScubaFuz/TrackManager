DELETE FROM [tbl_Arguments]

DBCC CHECKIDENT ([tbl_Arguments], NORESEED)
DBCC CHECKIDENT ([tbl_Arguments], RESEED, 0)

SET IDENTITY_INSERT [tbl_Arguments] ON

INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(1,'@DateStart')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(2,'@DateStop')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(3,'@ClientId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(4,'@GroupId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(5,'@AppType')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(6,'@TrackId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(7,'@InvoiceId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(8,'@LessonTypeId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(9,'@LevelId')
INSERT INTO [tbl_Arguments] ([PK_ArgumentId],[ArgumentName])VALUES(10,'@Language')

SET IDENTITY_INSERT [tbl_Arguments] OFF

