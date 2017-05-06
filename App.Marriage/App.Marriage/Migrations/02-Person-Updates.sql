/* تعديل حقل الصور من binary الى string URL */
USE [SOKNA]
GO

ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_Person_Users]
GO

ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_Person_Nationality]
GO

ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_Person_Country]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 5/6/2017 3:18:29 PM ******/
DROP TABLE [dbo].[Person]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 5/6/2017 3:18:29 PM ******/
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
	[Photo1] [nvarchar](max) NULL,
	[Photo2] [nvarchar](max) NULL,
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


