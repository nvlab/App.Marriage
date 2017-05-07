CREATE TABLE dbo.Enums
	(
	Id int NOT NULL IDENTITY (1, 1),
	EnumKey nvarchar(150) NULL,
	EnumValue nvarchar(250) NULL,
	NameL1 nvarchar(250) NULL,
	NameL2 nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Enums ADD CONSTRAINT
	PK_Enums PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Enums SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Enums', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Enums', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Enums', 'Object', 'CONTROL') as Contr_Per 