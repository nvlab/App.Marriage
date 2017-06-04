USE [SOKNA2]
GO
SET IDENTITY_INSERT [dbo].[Enums] ON 
GO
INSERT [dbo].[Enums] ([Id], [EnumKey], [EnumValue], [NameL1], [NameL2]) VALUES (24, N'RelationStatus', N'Pending', N'انتظار', NULL)
GO
INSERT [dbo].[Enums] ([Id], [EnumKey], [EnumValue], [NameL1], [NameL2]) VALUES (25, N'RelationStatus', N'NotAccepting
', N'عدم قبول', NULL)
GO
INSERT [dbo].[Enums] ([Id], [EnumKey], [EnumValue], [NameL1], [NameL2]) VALUES (26, N'RelationStatus', N'UnderStudy', N'قيد الدراسة', NULL)
GO
INSERT [dbo].[Enums] ([Id], [EnumKey], [EnumValue], [NameL1], [NameL2]) VALUES (27, N'RelationStatus', N'Accepted', N'تم القبول', NULL)
GO
INSERT [dbo].[Enums] ([Id], [EnumKey], [EnumValue], [NameL1], [NameL2]) VALUES (28, N'RelationStatus', N'Arrcive', N'ارشيف', NULL)
GO
SET IDENTITY_INSERT [dbo].[Enums] OFF
GO
