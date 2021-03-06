USE [SOKNA]
GO
SET IDENTITY_INSERT [dbo].[Permissons] ON 

INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (1, N'المستخدمين')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (2, N'المشتركين')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (3, N'الرسائل')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (4, N'غرف المحادثة')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (5, N'بنك الاسئلة')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (6, N'قبول المشتركين')
INSERT [dbo].[Permissons] ([Id], [NameL1]) VALUES (7, N'الصلاحيات')
SET IDENTITY_INSERT [dbo].[Permissons] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [RoleStatus]) VALUES (1, N'Admin', NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [RoleStatus]) VALUES (2, N'NormalUser', NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [RoleStatus]) VALUES (3, N'Suppervisor', NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [RoleStatus]) VALUES (4, N'IT', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[RolePermissions] ON 

INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (1, 1, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (2, 2, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (3, 3, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (4, 4, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (5, 5, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (6, 6, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (7, 1, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (8, 2, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (9, 3, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (10, 4, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (11, 5, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (12, 6, 2, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (13, 7, 1, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [Permission_Id], [Roles_Id], [InsertDate], [IsActive]) VALUES (14, 7, 2, NULL, 1)
SET IDENTITY_INSERT [dbo].[RolePermissions] OFF
