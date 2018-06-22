CREATE VIEW [dbo].[vw_ClientGroups]
AS
SELECT clt.[PK_ClientID]
	,clt.[ClientName]
	,clt.Active As ClientActive
	,grp.[PK_GroupID]
	,grp.[GroupName]
	,grp.Active AS GroupActive
FROM [TrackManager].[dbo].[tbl_Clients] clt
INNER JOIN [dbo].[tbl_Groups] grp
	ON clt.[FK_GroupID] = grp.[PK_GroupID]
