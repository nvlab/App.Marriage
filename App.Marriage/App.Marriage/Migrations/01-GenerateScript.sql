USE [SOKNA]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titles] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Artical_Image] [image] NULL,
	[Contents] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NULL,
	[Category_Id] [int] NULL,
	[Entity_Order] [int] NULL,
	[IsPublish] [bit] NULL,
	[ArticalDate] [date] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](250) NULL,
	[Entity_Order] [int] NULL,
	[CatType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatRoomMessage]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoomMessage](
	[Id] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[RelationRequest_Id] [int] NULL,
	[SenderUser_Id] [int] NULL,
	[MsgDate] [datetime] NULL,
	[Entity_Order] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameL1] [nchar](10) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MsgHeader] [nvarchar](250) NULL,
	[User_Id] [int] NULL,
	[MsgType] [nvarchar](50) NULL,
	[Messages] [nvarchar](max) NULL,
	[MsgDate] [datetime] NULL,
	[MsgStatus] [nchar](10) NULL,
	[ReciverUser_Id] [int] NULL,
	[Person_Id] [int] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nationality]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameL1] [nvarchar](250) NULL,
 CONSTRAINT [PK_Nationality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissons]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameL1] [nvarchar](250) NULL,
 CONSTRAINT [PK_Permissons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nationality_Id] [int] NULL,
	[FullName] [nvarchar](250) NULL,
	[Father] [nvarchar](250) NULL,
	[Mother] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[BirthDate] [datetime] NULL,
	[height] [int] NULL,
	[Weight] [int] NULL,
	[PlaceBirth] [nvarchar](250) NULL,
	[Adress] [nchar](10) NULL,
	[Residence_Country_Id] [int] NULL,
	[SocialStatus] [int] NULL,
	[Color] [nvarchar](250) NULL,
	[Gender] [nvarchar](50) NULL,
	[Photo1] [image] NULL,
	[Photo2] [image] NULL,
	[User_Id] [int] NULL,
	[NationalityNumber] [nvarchar](250) NULL,
	[PassportNumber] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[Phone1] [nvarchar](250) NULL,
	[Phone2] [nvarchar](250) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionBank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Category_Id] [int] NULL,
	[Image] [image] NULL,
	[Entity_Order] [int] NULL,
 CONSTRAINT [PK_QuestionBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegisterRequests]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisterRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestDate] [datetime] NULL,
	[Person_Id] [int] NULL,
	[RequestStatus] [int] NULL,
	[ResponseMessage] [int] NULL,
	[Links] [nvarchar](250) NULL,
	[RequestMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_RegisterRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelationRequest]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelationRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestUser_Id] [int] NULL,
	[RegisterRequests_Id] [int] NULL,
	[TargetUser_Id] [int] NULL,
	[RequestDate] [datetime] NULL,
	[RequestMessage] [nvarchar](max) NULL,
	[ResponseMessage] [nvarchar](max) NULL,
	[RequestStatus] [nvarchar](50) NULL,
	[AllowChatRoom] [bit] NULL,
	[ResponsibleManager_Id] [int] NULL,
 CONSTRAINT [PK_RelationRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestQuestionSenario]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestQuestionSenario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question_id] [int] NULL,
	[Answers] [nvarchar](250) NULL,
	[RegisterRequests_Id] [int] NULL,
	[Entity_Order] [int] NULL,
 CONSTRAINT [PK_RequestQuestionSenario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Permission_Id] [int] NULL,
	[Roles_Id] [int] NULL,
	[InsertDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[RoleStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/04/2017 22:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[UserType] [nvarchar](50) NULL,
	[Role_Id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Category]
GO
ALTER TABLE [dbo].[ChatRoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomMessage_RelationRequest] FOREIGN KEY([RelationRequest_Id])
REFERENCES [dbo].[RelationRequest] ([Id])
GO
ALTER TABLE [dbo].[ChatRoomMessage] CHECK CONSTRAINT [FK_ChatRoomMessage_RelationRequest]
GO
ALTER TABLE [dbo].[ChatRoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomMessage_Users] FOREIGN KEY([SenderUser_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ChatRoomMessage] CHECK CONSTRAINT [FK_ChatRoomMessage_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Person] FOREIGN KEY([Person_Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Person]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users1] FOREIGN KEY([ReciverUser_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users1]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Country] FOREIGN KEY([Residence_Country_Id])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Country]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Nationality] FOREIGN KEY([Nationality_Id])
REFERENCES [dbo].[Nationality] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Nationality]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Users]
GO
ALTER TABLE [dbo].[QuestionBank]  WITH CHECK ADD  CONSTRAINT [FK_QuestionBank_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[QuestionBank] CHECK CONSTRAINT [FK_QuestionBank_Category]
GO
ALTER TABLE [dbo].[RegisterRequests]  WITH CHECK ADD  CONSTRAINT [FK_RegisterRequests_Person] FOREIGN KEY([Person_Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[RegisterRequests] CHECK CONSTRAINT [FK_RegisterRequests_Person]
GO
ALTER TABLE [dbo].[RelationRequest]  WITH CHECK ADD  CONSTRAINT [FK_RelationRequest_RegisterRequests] FOREIGN KEY([RegisterRequests_Id])
REFERENCES [dbo].[RegisterRequests] ([Id])
GO
ALTER TABLE [dbo].[RelationRequest] CHECK CONSTRAINT [FK_RelationRequest_RegisterRequests]
GO
ALTER TABLE [dbo].[RelationRequest]  WITH CHECK ADD  CONSTRAINT [FK_RelationRequest_Users] FOREIGN KEY([RequestUser_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RelationRequest] CHECK CONSTRAINT [FK_RelationRequest_Users]
GO
ALTER TABLE [dbo].[RelationRequest]  WITH CHECK ADD  CONSTRAINT [FK_RelationRequest_Users1] FOREIGN KEY([TargetUser_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RelationRequest] CHECK CONSTRAINT [FK_RelationRequest_Users1]
GO
ALTER TABLE [dbo].[RelationRequest]  WITH CHECK ADD  CONSTRAINT [FK_RelationRequest_Users2] FOREIGN KEY([ResponsibleManager_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RelationRequest] CHECK CONSTRAINT [FK_RelationRequest_Users2]
GO
ALTER TABLE [dbo].[RequestQuestionSenario]  WITH CHECK ADD  CONSTRAINT [FK_RequestQuestionSenario_QuestionBank] FOREIGN KEY([Question_id])
REFERENCES [dbo].[QuestionBank] ([Id])
GO
ALTER TABLE [dbo].[RequestQuestionSenario] CHECK CONSTRAINT [FK_RequestQuestionSenario_QuestionBank]
GO
ALTER TABLE [dbo].[RequestQuestionSenario]  WITH CHECK ADD  CONSTRAINT [FK_RequestQuestionSenario_RegisterRequests] FOREIGN KEY([RegisterRequests_Id])
REFERENCES [dbo].[RegisterRequests] ([Id])
GO
ALTER TABLE [dbo].[RequestQuestionSenario] CHECK CONSTRAINT [FK_RequestQuestionSenario_RegisterRequests]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissons] FOREIGN KEY([Permission_Id])
REFERENCES [dbo].[Permissons] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissons]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY([Roles_Id])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role_Id])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
