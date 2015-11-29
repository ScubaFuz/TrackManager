INSERT INTO [dbo].[tbl_Tracks]
	SELECT 'Baan 1',0,1 UNION
	SELECT 'Baan 2',30,1 UNION
	SELECT 'Baan 3',0,1
;

INSERT INTO [dbo].[tbl_PrContacts]
	SELECT 'Internet',1 UNION
	SELECT 'Advertentie',1 UNION
	SELECT 'Mond tot mond reclame',1 UNION
	SELECT 'Krant',1
;

INSERT INTO [dbo].[tbl_Levels]
	SELECT 'Nieuw','Green',1,1 UNION
	SELECT 'Beginner','Blue',2,1 UNION
	SELECT 'Licht Gevorderd','Red',5,1 UNION
	SELECT 'Gevorderd','Black',10,1 UNION
	SELECT 'Ver Gevorderd','DarkGoldenRod',15,1 UNION
	SELECT 'Expert','DarkRed',20,1
;

INSERT INTO [dbo].[tbl_LessonTypes]
	SELECT 'Ski','LightBlue',1 UNION
	SELECT 'Snowboard','LightGreen',1 UNION
	SELECT 'Ski Kind','LightPink',1 UNION
	SELECT 'Snowboard Kind','Moccasin',1 UNION
	SELECT 'Bar','LightCoral',1 
;

INSERT INTO [dbo].[tbl_Tax]
	SELECT 0,'Belastingvrij',1 UNION
	SELECT 6,'Lage BTW tarief',1 UNION
	SELECT 21,'Hoge BTW tarief',1
;

INSERT INTO [dbo].[tbl_Products]
	SELECT 'Losse Les',1,50.00,6,1,1 UNION
	SELECT 'Lespakket 5 Lessen',5,225.00,6,1,2 UNION
	SELECT 'Lespakket 10 Lessen',10,400.00,6,1,3 UNION
	SELECT 'Herfstpakket 6 Lessen',6,230.00,6,1,4 UNION
	SELECT 'Kerstpakket 6 Lessen',6,230.00,6,1,4
;
DECLARE @DateChange datetime, @OpeningHours nvarchar(50), @ClosingHours nvarchar(50), @SeasonStart nvarchar(50)
SET @DateChange = GetDate()-1
SET @OpeningHours = (SELECT CASE WHEN month(getdate()) > 6 THEN CAST(year(getdate()) AS nvarchar(10)) + '-07-01 10:00' ELSE CAST(year(getdate())-1 AS nvarchar(10)) + '-07-01 10:00' END)
SET @ClosingHours = (SELECT CASE WHEN month(getdate()) > 6 THEN CAST(year(getdate()) AS nvarchar(10)) + '-07-01 22:00' ELSE CAST(year(getdate())-1 AS nvarchar(10)) + '-07-01 22:00' END)
SET @SeasonStart = (SELECT CASE WHEN month(getdate()) > 6 THEN CAST(year(getdate()) AS nvarchar(10)) + '-07-01 00:00' ELSE CAST(year(getdate())-1 AS nvarchar(10)) + '-07-01 00:00' END)

EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ClientsPerTrack',4,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ClientsPerGroup',4,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'PayLines',4,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'OpeningHour',600,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'OpeningHours',@OpeningHours,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ClosingHour',1320,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ClosingHours',@ClosingHours,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'TimeFrame',60,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ShowOffHours','False',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'OnHoursColor','White',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'OffHoursColor','PowderBlue',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ReadOnlyBackColor','WhiteSmoke',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'Language','NL',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ShowTeacher','True',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'ShowTimeWithTrack','True',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','ScreenView',NULL,'UseFadingColors','False',@DateChange,'DemoValue'

EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'SeasonStart',@SeasonStart,@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'SeasonLength','Year',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'DeleteEmptyInvoice','True',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'SelectMultipleGroups','True',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'InvoiceName','Demo',@DateChange,'DemoValue'
EXECUTE [dbo].[usp_ConfigHandle] 'Smt','General',NULL,'InvoiceNumber',1,@DateChange,'DemoValue'

;
EXECUTE [dbo].[usp_GroupHandle] @Action = 'Ins',@GroupId = 20100701100000, @GroupName = 'De Vries'

EXECUTE [dbo].[usp_ClientHandle] 
	@Action = 'Ins',@GroupID = 20100701100000,@FirstName = 'Peter',@MiddleName = 'de',@FamilyName = 'Vries'
	,@PrimaryContact = 1,@Country = 'Nederland',@Mobile = '+31 6 555 55598',@Email = 'peter@devries.nl'
	,@MailingList = 1,@DayOfBirth = '19690615',@Remarks = 'Goede skier'

EXECUTE [dbo].[usp_ClientHandle] @Action = 'Ins',@GroupID = 20100701100000,@FirstName = 'Anneke'
	,@MiddleName = 'de',@FamilyName = 'Vries',@Country = 'Nederland'
	,@Mobile = '+31 6 555 12345',@Email = 'anneke@devries.nl',@MailingList = 1,@DayOfBirth = '19720321'


EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20100701100000 ,@FirstName = 'Marietje'
	,@MiddleName = 'de' ,@FamilyName = 'Vries',@Country = 'Nederland'
	,@MailingList = 0 ,@DayOfBirth = '19960810'

EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20100701100000,@FirstName = 'Hans'
	,@MiddleName = 'de',@FamilyName = 'Vries',@Country = 'Nederland'
	,@MailingList = 0,@DayOfBirth = '19980228'


EXECUTE [dbo].[usp_GroupHandle] @Action = 'Ins',@GroupId = 20110408100000, @GroupName = 'Smith'

EXECUTE [dbo].[usp_ClientHandle] 
	@Action = 'Ins',@GroupID = 20110408100000,@FirstName = 'Charles',@FamilyName = 'Smith'
	,@PrimaryContact = 1,@Country = 'United States',@Mobile = '+1 555 555 997',@Email = 'charlessmith@hotmail.com'
	,@MailingList = 1,@DayOfBirth = '19690615',@Remarks = 'Brings family with him'

EXECUTE [dbo].[usp_ClientHandle] @Action = 'Ins',@GroupID = 20110408100000,@FirstName = 'Alice'
	,@FamilyName = 'Smith',@Country = 'United States'
	,@Mobile = '+1 555 555 548',@Email = 'alice@somedomain.com',@MailingList = 1,@DayOfBirth = '19720321'


EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20110408100000 ,@FirstName = 'Bob'
	,@FamilyName = 'Smith',@Country = 'United States'
	,@MailingList = 0 ,@DayOfBirth = '20040109'

EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20110408100000,@FirstName = 'Caroline'
	,@FamilyName = 'Smith',@Country = 'United States'
	,@MailingList = 0,@DayOfBirth = '20050721'


EXECUTE [dbo].[usp_GroupHandle] @Action = 'Ins',@GroupId = 20090221110000, @GroupName = 'Cavelier'

EXECUTE [dbo].[usp_ClientHandle] 
	@Action = 'Ins',@GroupID = 20090221110000,@FirstName = 'Pierre',@FamilyName = 'Cavelier'
	,@PrimaryContact = 1,@Country = 'France',@Mobile = '+31 6 555 55598',@Email = 'pierre.cavalier@unemail.fr'
	,@MailingList = 1,@DayOfBirth = '19550902',@Remarks = 'Ne pas un problem'

EXECUTE [dbo].[usp_ClientHandle] @Action = 'Ins',@GroupID = 20090221110000,@FirstName = 'Brigitte'
	,@FamilyName = 'Cavelier',@Country = 'France'
	,@Mobile = '+31 6 555 12345',@Email = 'anneke@devries.nl',@MailingList = 1,@DayOfBirth = '19510318'


EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20090221110000 ,@FirstName = 'Valerie'
	,@FamilyName = 'Cavelier',@Country = 'France'
	,@MailingList = 0 ,@DayOfBirth = '19960810'

EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 20090221110000,@FirstName = 'Hercule'
	,@FamilyName = 'Cavelier',@Country = 'France'
	,@MailingList = 0,@DayOfBirth = '19980228'

EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 2,@FirstName = 'Valiant'
	,@FamilyName = 'DownHill',@MailingList = 0

EXECUTE [dbo].[usp_ClientHandle]   @Action = 'Ins',@GroupID = 1,@FirstName = 'Bacardi'
	,@FamilyName = 'CocktailShaker',@MailingList = 0