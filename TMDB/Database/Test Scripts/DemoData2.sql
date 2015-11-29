INSERT [dbo].[tbl_Groups] ([PK_GroupID], [GroupName], [Active]) VALUES (1, N'_Bar', 1)
GO
INSERT [dbo].[tbl_Groups] ([PK_GroupID], [GroupName], [Active]) VALUES (2, N'_Teachers', 1)
GO
INSERT [dbo].[tbl_Groups] ([PK_GroupID], [GroupName], [Active]) VALUES (20120501211612, N'KlantGroep1', 1)
GO
INSERT [dbo].[tbl_Groups] ([PK_GroupID], [GroupName], [Active]) VALUES (20120501211624, N'KlantGroep2', 1)
GO
INSERT [dbo].[tbl_Groups] ([PK_GroupID], [GroupName], [Active]) VALUES (20120501212415, N'Puk', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_PrContacts] ON 

GO
INSERT [dbo].[tbl_PrContacts] ([PK_PrContactID], [PrContactName], [Active]) VALUES (1, N'Internet', 1)
GO
INSERT [dbo].[tbl_PrContacts] ([PK_PrContactID], [PrContactName], [Active]) VALUES (2, N'Krant', 1)
GO
INSERT [dbo].[tbl_PrContacts] ([PK_PrContactID], [PrContactName], [Active]) VALUES (3, N'Televisie', 1)
GO
INSERT [dbo].[tbl_PrContacts] ([PK_PrContactID], [PrContactName], [Active]) VALUES (4, N'Mond tot mond reclame', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_PrContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Clients] ON 

GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (1, N'Klant 1', NULL, NULL, 20120501211612, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (2, N'Klant 2', NULL, NULL, 20120501211612, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (3, N'Klant 3', NULL, NULL, 20120501211612, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (4, N'Klant 4', NULL, NULL, 20120501211624, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (5, N'Klant 5', NULL, NULL, 20120501211624, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (6, N'Klant 6', NULL, NULL, 20120501211624, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (7, N'Pietje', NULL, N'Puk', 20120501212415, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (8, N'Marietje', NULL, NULL, 20120501212415, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (9, N'Klaasje', NULL, NULL, 20120501212415, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (10, N'Jantje', NULL, NULL, 20120501212415, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (15, N'Leraar 1', NULL, NULL, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Clients] ([PK_ClientID], [FirstName], [MiddleName], [FamilyName], [FK_GroupID], [PrimaryContact], [Street], [HouseNumber], [PostalCode], [City], [Country], [TelePhone], [Fax], [Mobile], [Email], [MailingList], [FK_PrContactID], [DayOfBirth], [BankAccount], [Remarks], [CustomField1], [CustomField2], [CustomField3], [CustomField4], [Active]) VALUES (16, N'Barman 1', NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Memo] ON 

GO
INSERT [dbo].[tbl_Memo] ([PK_MemoId], [Type], [FK_GroupId], [MemoDate], [MemoText]) VALUES (1, N'Track', NULL, CAST(0xA0440000 AS SmallDateTime), N'Dit is een Dag Memo')
GO
INSERT [dbo].[tbl_Memo] ([PK_MemoId], [Type], [FK_GroupId], [MemoDate], [MemoText]) VALUES (2, N'Group', 20120501212415, CAST(0xA0460000 AS SmallDateTime), N'Dit is een Groepen memo')
GO
INSERT [dbo].[tbl_Memo] ([PK_MemoId], [Type], [FK_GroupId], [MemoDate], [MemoText]) VALUES (3, N'Finance', 20120501212415, CAST(0xA0460000 AS SmallDateTime), N'Dit is een Finance memo')
GO
SET IDENTITY_INSERT [dbo].[tbl_Memo] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_LessonTypes] ON 

GO
INSERT [dbo].[tbl_LessonTypes] ([PK_LessonTypeID], [LessonTypeName], [Color], [Active]) VALUES (1, N'Ski', N'LightBlue', 1)
GO
INSERT [dbo].[tbl_LessonTypes] ([PK_LessonTypeID], [LessonTypeName], [Color], [Active]) VALUES (2, N'Snowboard', N'LightGreen', 1)
GO
INSERT [dbo].[tbl_LessonTypes] ([PK_LessonTypeID], [LessonTypeName], [Color], [Active]) VALUES (3, N'Ski Kind', N'LightPink', 1)
GO
INSERT [dbo].[tbl_LessonTypes] ([PK_LessonTypeID], [LessonTypeName], [Color], [Active]) VALUES (4, N'Snowboard Kind', N'Moccasin', 1)
GO
INSERT [dbo].[tbl_LessonTypes] ([PK_LessonTypeID], [LessonTypeName], [Color], [Active]) VALUES (5, N'Bar', N'LightCoral', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_LessonTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Levels] ON 

GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (1, N'Automatic', N'White', 0, 1)
GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (2, N'Nieuw', N'Blue', 1, 1)
GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (3, N'Beginner', N'Green', 2, 1)
GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (4, N'Licht Gevorderd', N'DarkOrange', 5, 1)
GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (5, N'Gevorderd', N'DarkViolet', 10, 1)
GO
INSERT [dbo].[tbl_Levels] ([PK_LevelID], [LevelName], [Color], [LevelCount], [Active]) VALUES (6, N'Ver Gevorderd', N'DarkRed', 20, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Levels] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Tracks] ON 

GO
INSERT [dbo].[tbl_Tracks] ([PK_TrackID], [TrackName], [TrackOffset], [Active]) VALUES (1, N'Baan 1', 0, 1)
GO
INSERT [dbo].[tbl_Tracks] ([PK_TrackID], [TrackName], [TrackOffset], [Active]) VALUES (2, N'Baan 2', 30, 1)
GO
INSERT [dbo].[tbl_Tracks] ([PK_TrackID], [TrackName], [TrackOffset], [Active]) VALUES (3, N'Baan 3', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Tracks] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Appointment] ON 

GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (1, CAST(0xA0440384 AS SmallDateTime), N'Track', 10, 1, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (2, CAST(0xA0440384 AS SmallDateTime), N'Track', 9, 1, 2, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (3, CAST(0xA0440384 AS SmallDateTime), N'Track', 8, 1, 3, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (4, CAST(0xA0440384 AS SmallDateTime), N'Track', 7, 1, 4, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (5, CAST(0xA04403C0 AS SmallDateTime), N'Track', 7, 1, 4, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (6, CAST(0xA04403C0 AS SmallDateTime), N'Track', 8, 1, 3, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (7, CAST(0xA04403C0 AS SmallDateTime), N'Track', 9, 1, 2, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (8, CAST(0xA04403C0 AS SmallDateTime), N'Track', 10, 1, 1, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (9, CAST(0xA04403FC AS SmallDateTime), N'Track', 7, 1, 4, 1, 3, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (10, CAST(0xA04403FC AS SmallDateTime), N'Track', 8, 1, 3, 1, 3, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (11, CAST(0xA04403FC AS SmallDateTime), N'Track', 9, 1, 2, 1, 3, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (12, CAST(0xA04403FC AS SmallDateTime), N'Track', 10, 1, 1, 1, 3, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (13, CAST(0xA0440438 AS SmallDateTime), N'Track', 7, 1, 4, 1, 4, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (14, CAST(0xA0440438 AS SmallDateTime), N'Track', 8, 1, 3, 1, 4, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (15, CAST(0xA0440438 AS SmallDateTime), N'Track', 9, 1, 2, 1, 4, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (16, CAST(0xA0440438 AS SmallDateTime), N'Track', 10, 1, 1, 1, 4, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (17, CAST(0xA0440474 AS SmallDateTime), N'Track', 7, 1, 4, 1, 5, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (18, CAST(0xA0440474 AS SmallDateTime), N'Track', 8, 1, 3, 1, 5, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (19, CAST(0xA0440474 AS SmallDateTime), N'Track', 9, 1, 2, 1, 5, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (20, CAST(0xA0440474 AS SmallDateTime), N'Track', 10, 1, 1, 1, 5, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (21, CAST(0xA04404EC AS SmallDateTime), N'Track', 7, 1, 4, 1, 6, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (22, CAST(0xA04404EC AS SmallDateTime), N'Track', 8, 1, 3, 1, 6, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (23, CAST(0xA04404EC AS SmallDateTime), N'Track', 9, 1, 2, 1, 6, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (24, CAST(0xA04404EC AS SmallDateTime), N'Track', 10, 1, 1, 1, 6, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (49, CAST(0xA0440384 AS SmallDateTime), N'Teacher', 15, 1, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (45, CAST(0xA0450348 AS SmallDateTime), N'Lock', NULL, 1, NULL, NULL, 0, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (47, CAST(0xA0450000 AS SmallDateTime), N'Lock', NULL, 2, NULL, NULL, 0, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (28, CAST(0xA0460438 AS SmallDateTime), N'Track', 10, 1, 1, 1, 7, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (29, CAST(0xA0460438 AS SmallDateTime), N'Track', 9, 1, 2, 1, 7, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (30, CAST(0xA0460438 AS SmallDateTime), N'Track', 8, 1, 3, 1, 7, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (31, CAST(0xA0460438 AS SmallDateTime), N'Track', 7, 1, 4, 1, 7, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (32, CAST(0xA04E0474 AS SmallDateTime), N'Track', 10, 1, 1, 1, 8, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (33, CAST(0xA04E0474 AS SmallDateTime), N'Track', 9, 1, 2, 1, 8, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (50, CAST(0xA04403C0 AS SmallDateTime), N'Teacher', 15, 1, 1, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (55, CAST(0xA0440384 AS SmallDateTime), N'Bar', 16, NULL, 5, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (56, CAST(0xA04403C0 AS SmallDateTime), N'Bar', 16, NULL, 5, 1, 2, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (57, CAST(0xA04403FC AS SmallDateTime), N'Bar', 16, NULL, 5, 1, 3, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (58, CAST(0xA0440000 AS SmallDateTime), N'Lock', NULL, 2, NULL, NULL, 0, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (59, CAST(0xA044030C AS SmallDateTime), N'Lock', NULL, 1, NULL, NULL, 0, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (34, CAST(0xA04E0474 AS SmallDateTime), N'Track', 8, 1, 3, 1, 8, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (35, CAST(0xA04E0474 AS SmallDateTime), N'Track', 7, 1, 4, 1, 8, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (36, CAST(0xA0550474 AS SmallDateTime), N'Track', 10, 1, 1, 1, 9, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (37, CAST(0xA0550474 AS SmallDateTime), N'Track', 9, 1, 2, 1, 9, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (38, CAST(0xA0550474 AS SmallDateTime), N'Track', 8, 1, 3, 1, 9, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (39, CAST(0xA0550474 AS SmallDateTime), N'Track', 7, 1, 4, 1, 9, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (40, CAST(0xA05C0474 AS SmallDateTime), N'Track', 10, 1, 1, 1, 10, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (41, CAST(0xA05C0474 AS SmallDateTime), N'Track', 9, 1, 2, 1, 10, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (42, CAST(0xA05C0474 AS SmallDateTime), N'Track', 8, 1, 3, 1, 10, 0, 1, 1)
GO
INSERT [dbo].[tbl_Appointment] ([PK_AppointmentId], [AppDate], [AppType], [FK_ClientId], [FK_TrackId], [FK_LessonTypeId], [FK_LevelId], [LessonCount], [ExtraCount], [FK_LoginId], [Active]) VALUES (43, CAST(0xA05C0474 AS SmallDateTime), N'Track', 7, 1, 4, 1, 10, 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_ClientLevels] ON 

GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (1, 10, 1, 1, 10, 0, 1, 0, 1)
GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (2, 9, 2, 1, 10, 0, 1, 0, 1)
GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (3, 8, 3, 1, 10, 0, 1, 0, 1)
GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (4, 7, 4, 1, 10, 0, 1, 0, 1)
GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (6, 15, 1, 1, 2, 0, 1, 0, 1)
GO
INSERT [dbo].[tbl_ClientLevels] ([PK_ClientLevelID], [FK_ClientID], [FK_LessonTypeID], [FK_LevelID], [LessonCount], [ExtraCount], [PrimaryType], [LastAction], [Active]) VALUES (8, 16, 5, 1, 3, 0, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_ClientLevels] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice] ON 

GO
INSERT [dbo].[tbl_Invoice] ([PK_InvoiceID], [InvoiceDate], [FK_ClientID], [FK_LoginID], [Payed], [Active]) VALUES (3, CAST(0xA0440000 AS SmallDateTime), 7, 1, 1, 1)
GO
INSERT [dbo].[tbl_Invoice] ([PK_InvoiceID], [InvoiceDate], [FK_ClientID], [FK_LoginID], [Payed], [Active]) VALUES (4, CAST(0xA0440000 AS SmallDateTime), 8, 1, 1, 1)
GO
INSERT [dbo].[tbl_Invoice] ([PK_InvoiceID], [InvoiceDate], [FK_ClientID], [FK_LoginID], [Payed], [Active]) VALUES (5, CAST(0xA0460000 AS SmallDateTime), 7, 1, 1, 1)
GO
INSERT [dbo].[tbl_Invoice] ([PK_InvoiceID], [InvoiceDate], [FK_ClientID], [FK_LoginID], [Payed], [Active]) VALUES (6, CAST(0xA0460000 AS SmallDateTime), 7, 1, 0, 1)
GO
INSERT [dbo].[tbl_Invoice] ([PK_InvoiceID], [InvoiceDate], [FK_ClientID], [FK_LoginID], [Payed], [Active]) VALUES (7, CAST(0xA0460000 AS SmallDateTime), 8, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_InvoiceLine] ON 

GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (8, 3, 7, 1, N'Lespakket 10 Lessen', 10, CAST(400.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (9, 4, 8, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (10, 4, 9, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (11, 4, 10, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (12, 4, 7, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (13, 5, 7, 1, N'Lespakket 10 Lessen', 10, CAST(400.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (14, 6, 7, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (15, 6, 8, 1, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (16, 6, 9, 1, N'Losse Les', 1, CAST(50.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (17, 7, 8, 1, N'Losse Les', 1, CAST(45.00 AS Numeric(10, 2)), 6, 1)
GO
INSERT [dbo].[tbl_InvoiceLine] ([PK_InvoiceLineID], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Description], [Count], [Amount], [FK_Tax], [Active]) VALUES (18, 7, 8, 1, N'Losse Les', 1, CAST(40.00 AS Numeric(10, 2)), 6, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_InvoiceLine] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_InvoicePayment] ON 

GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (5, CAST(0xA0440000 AS SmallDateTime), 3, 7, 1, CAST(400.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (6, CAST(0xA0440000 AS SmallDateTime), 4, 7, 1, CAST(200.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (7, CAST(0xA0440000 AS SmallDateTime), 4, 8, 1, CAST(225.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (8, CAST(0xA0440000 AS SmallDateTime), 4, 9, 1, CAST(150.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (10, CAST(0xA0440000 AS SmallDateTime), 4, 10, 1, CAST(325.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (12, CAST(0xA0460000 AS SmallDateTime), 5, 8, 1, CAST(100.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[tbl_InvoicePayment] ([PK_InvoicePaymentID], [PayDate], [FK_InvoiceID], [FK_ClientID], [FK_LoginID], [Amount], [Active]) VALUES (14, CAST(0xA0460000 AS SmallDateTime), 5, 8, 1, CAST(300.00 AS Numeric(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_InvoicePayment] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Config] ON 

GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (19, N'ScreenView', N'ClientsPerTrack', N'4', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (20, N'ScreenView', N'ClientsPerGroup', N'4', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (21, N'ScreenView', N'PayLines', N'4', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (22, N'ScreenView', N'OpeningHour', N'8', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (23, N'ScreenView', N'OpeningHours', N'4-5-2012 10:00:00', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (24, N'ScreenView', N'ClosingHour', N'22', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (25, N'ScreenView', N'ClosingHours', N'4-5-2012 23:00:00', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (26, N'ScreenView', N'TimeFrame', N'60', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (27, N'ScreenView', N'ShowOffHours', N'False', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (28, N'ScreenView', N'OnHoursColor', N'White', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (29, N'ScreenView', N'OffHoursColor', N'PowderBlue', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (30, N'ScreenView', N'ReadOnlyBackColor', N'WhiteSmoke', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (31, N'ScreenView', N'Language', N'NL', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (32, N'ScreenView', N'ShowTeacher', N'True', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (33, N'ScreenView', N'ShowTimeWithTrack', N'True', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (34, N'ScreenView', N'UseFadingColors', N'False', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (35, N'General', N'SeasonStart', N'2011-07-01 00:00', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (36, N'General', N'SeasonLength', N'Year', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (37, N'General', N'DeleteEmptyInvoice', N'True', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (38, N'General', N'SelectMultipleGroups', N'True', CAST(0xA0430252 AS SmallDateTime), NULL, CAST(0xA0470576 AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[tbl_Config] ([PK_ConfigId], [Category], [ConfigName], [ConfigValue], [DateStart], [DateStop], [DateChange], [Remarks], [Active]) VALUES (39, N'Database', N'BackupLocation', N'E:\Backups', CAST(0xA04403DD AS SmallDateTime), NULL, CAST(0xA04403F7 AS SmallDateTime), N'A valid location on the server', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Config] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Descriptions] ON 

GO
INSERT [dbo].[tbl_Descriptions] ([PK_DescriptionID], [DescriptionText], [DescriptionCount], [DescriptionAmount], [FK_TaxId], [Active], [Sort]) VALUES (1, N'Losse Les', 1, CAST(50.00 AS Numeric(10, 2)), 6, 1, 1)
GO
INSERT [dbo].[tbl_Descriptions] ([PK_DescriptionID], [DescriptionText], [DescriptionCount], [DescriptionAmount], [FK_TaxId], [Active], [Sort]) VALUES (2, N'Lespakket 5 Lessen', 5, CAST(225.00 AS Numeric(10, 2)), 6, 1, 2)
GO
INSERT [dbo].[tbl_Descriptions] ([PK_DescriptionID], [DescriptionText], [DescriptionCount], [DescriptionAmount], [FK_TaxId], [Active], [Sort]) VALUES (3, N'Lespakket 10 Lessen', 10, CAST(400.00 AS Numeric(10, 2)), 6, 1, 3)
GO
INSERT [dbo].[tbl_Descriptions] ([PK_DescriptionID], [DescriptionText], [DescriptionCount], [DescriptionAmount], [FK_TaxId], [Active], [Sort]) VALUES (4, N'Herfstpakket 6 Lessen', 6, CAST(230.00 AS Numeric(10, 2)), 6, 1, 4)
GO
INSERT [dbo].[tbl_Descriptions] ([PK_DescriptionID], [DescriptionText], [DescriptionCount], [DescriptionAmount], [FK_TaxId], [Active], [Sort]) VALUES (5, N'Kerstpakket 6 Lessen', 6, CAST(230.00 AS Numeric(10, 2)), 6, 1, 5)
GO
SET IDENTITY_INSERT [dbo].[tbl_Descriptions] OFF
GO
