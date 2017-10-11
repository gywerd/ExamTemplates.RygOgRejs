USE [RygOgRejs]
GO
/****** Object:  Table [dbo].[AncillaryCharges]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AncillaryCharges](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstClassPrice] [float] NOT NULL,
	[LuggagePricePerOverloadKg] [float] NOT NULL )
GO
SET IDENTITY_INSERT [dbo].[AncillaryCharges] ON
INSERT [dbo].[AncillaryCharges] ([Id], [FirstClassPrice], [LuggagePricePerOverloadKg]) VALUES ('1699.00', '290.00')
SET IDENTITY_INSERT [dbo].[AncillaryCharges] OFF
GO
/****** Object:  Table [dbo].[Transactions]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TransactionDate] [datetime] NOT NULL,
	[DestinationName] [nvarchar](35) NOT NULL,
	[IsFirstClass] [bit] NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[LuggageAmount] [float] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[AmountExclVat] [float] NOT NULL)
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions]([Id], [TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES (1, '2017-10-14', N'LEPA - PALMA DE MALLORCA, Spain', 1, 1, 5, 145, N'Jensine', N'Pedersen', 34668.00)
INSERT [dbo].[Transactions]([Id], [TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES (2, '2017-10-14', N'EKBI - BILLUND, Denmark', 0, 2, 2, 90, N'Peder', N'Andersen', 8408.00)
INSERT [dbo].[Transactions]([Id], [TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES (3, '2017-10-14', N'EKCH - COPENHAGEN, Denmark', 0, 3, 1, 94, N'Andrea', N'Hansen', 6180.00)
INSERT [dbo].[Transactions]([Id], [TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES (4, '2017-10-14', N'LEPA - PALMA DE MALLORCA, Spain', 1, 2, 1, 70, N'Hans', N'Nielsen', 18196.00)
INSERT [dbo].[Transactions]([Id], [TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES (5, '2017-10-14', N'EKCH - COPENHAGEN, Denmark', 1, 4, 2, 94, N'Nielsine', N'Jensen', 19364.00)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
/****** Object:  Table [dbo].[Destinations]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[DestinationId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DestinationName] [nvarchar](50) NOT NULL,
	[AdultPrice] [float] NOT NULL,
	[ChildrenPrice] [float] NOT NULL)
GO
SET IDENTITY_INSERT [dbo].[Destinations] ON
INSERT [dbo].[Destinations]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice]) VALUES (1, N'EKBI - BILLUND, Denmark', '390.00' , '295.00')
INSERT [dbo].[Destinations]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice]) VALUES (2, N'EKCH - COPENHAGEN, Denmark', '1595.00', '1395.00')
INSERT [dbo].[Destinations]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice]) VALUES (3, N'LEPA - PALMA DE MALLORCA, Spain', '4995.00', '3099.00')
SET IDENTITY_INSERT [dbo].[Destinations] OFF
GO
--Created by Daniel Giversen