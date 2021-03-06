/*
   22 May 201722:21:34
   User: 
   Server: .
   Database: SOKNA2
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChatRoomMessage
	DROP CONSTRAINT FK_ChatRoomMessage_Users
GO
ALTER TABLE dbo.Users SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Users', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Users', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Users', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChatRoomMessage
	DROP CONSTRAINT FK_ChatRoomMessage_RelationRequest
GO
ALTER TABLE dbo.RelationRequest SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RelationRequest', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RelationRequest', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RelationRequest', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ChatRoomMessage
	(
	Id int NOT NULL IDENTITY (1, 1),
	Message nvarchar(MAX) NULL,
	RelationRequest_Id int NULL,
	SenderUser_Id int NULL,
	MsgDate datetime NULL,
	Entity_Order int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ChatRoomMessage SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ChatRoomMessage ON
GO
IF EXISTS(SELECT * FROM dbo.ChatRoomMessage)
	 EXEC('INSERT INTO dbo.Tmp_ChatRoomMessage (Id, Message, RelationRequest_Id, SenderUser_Id, MsgDate, Entity_Order)
		SELECT Id, Message, RelationRequest_Id, SenderUser_Id, MsgDate, Entity_Order FROM dbo.ChatRoomMessage WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ChatRoomMessage OFF
GO
DROP TABLE dbo.ChatRoomMessage
GO
EXECUTE sp_rename N'dbo.Tmp_ChatRoomMessage', N'ChatRoomMessage', 'OBJECT' 
GO
ALTER TABLE dbo.ChatRoomMessage ADD CONSTRAINT
	PK_ChatRoomMessage PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ChatRoomMessage ADD CONSTRAINT
	FK_ChatRoomMessage_RelationRequest FOREIGN KEY
	(
	RelationRequest_Id
	) REFERENCES dbo.RelationRequest
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChatRoomMessage ADD CONSTRAINT
	FK_ChatRoomMessage_Users FOREIGN KEY
	(
	SenderUser_Id
	) REFERENCES dbo.Users
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChatRoomMessage', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChatRoomMessage', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChatRoomMessage', 'Object', 'CONTROL') as Contr_Per 