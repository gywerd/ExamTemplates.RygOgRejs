USE [RygOgRejs]
GO
/****** Object:  Table [dbo].[Master]    Script Date: 09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master](
	[MasterId] [int] IDENTITY(6,1) NOT NULL PRIMARY KEY,
	[MacAdress] [nvarchar](20) NOT NULL);
GO
/****** Object:  Table [dbo].[Journeys]    Script Date: 09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journeys](
	[JourneyId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Destination] [nvarchar](35) NOT NULL,
	[DepartureTime] [datetime] NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[IsFirstClass] [bit] NOT NULL,
	[LuggageAmount] [float] NOT NULL,
	[MasterId] [INT] NOT NULL);
GO
SET IDENTITY_INSERT [dbo].[Journeys] ON
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [DepartureTime], [Adults], [Children], [IsFirstClass], [LuggageAmount], [MasterId]) VALUES (1, N'LEPA - PALMA DE MALLORCA, Spain', '2017-10-14 00:00:00', 57, 5, 1, 145, 1)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [DepartureTime], [Adults], [Children], [IsFirstClass], [LuggageAmount], [MasterId]) VALUES (2, N'EKBI - BILLUND, Denmark', '2017-10-14 00:00:00', 2, 2, 0, 90, 2)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [DepartureTime], [Adults], [Children], [IsFirstClass], [LuggageAmount], [MasterId]) VALUES (3, N'EKCH - COPENHAGEN, Denmark', '2017-10-14 00:00:00', 3, 1, 0, 94, 3)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [DepartureTime], [Adults], [Children], [IsFirstClass], [LuggageAmount], [MasterId]) VALUES (4, N'LEPA - PALMA DE MALLORCA, Spain', '2017-10-14 00:00:00', 2, 1, 1, 70, 4)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [DepartureTime], [Adults], [Children], [IsFirstClass], [LuggageAmount], [MasterId]) VALUES (5, N'EKCH - COPENHAGEN, Denmark', '2017-10-14 00:00:00', 4, 2, 1, 140, 5)
SET IDENTITY_INSERT [dbo].[Journeys] OFF
GO
/****** Object:  Table [dbo].[Payers]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payers](
	[PayerId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[MasterId] [INT] NOT NULL )
GO
SET IDENTITY_INSERT [dbo].[Payers] ON
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [MasterId]) VALUES (1, N'Pedersen', N'Jensine', 1)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [MasterId]) VALUES (2, N'Andersen', N'Peder', 2)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [MasterId]) VALUES (3, N'Hansen', N'Andrea', 3)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [MasterId]) VALUES (4, N'Nielsen', N'Hans', 4)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [MasterId]) VALUES (5, N'Jensen', N'Nielsine', 5)
SET IDENTITY_INSERT [dbo].[Payers] OFF
GO
/****** Object:  Table [dbo].[Transactions]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Amount] [float] NOT NULL,
	[PayerId] [int] NOT NULL FOREIGN KEY REFERENCES Payers(PayerId),
	[JourneyId] [int] NOT NULL FOREIGN KEY REFERENCES Journeys(JourneyId),
	[MasterId] [INT] NOT NULL);
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId], [MasterId]) VALUES (1, 34668.00, 1, 1, 1)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId], [MasterId]) VALUES (2, 8408.00, 2, 2, 2)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId], [MasterId]) VALUES (3, 6180.00, 3, 3, 3)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId], [MasterId]) VALUES (4, 18196.00, 4, 4, 4)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId], [MasterId]) VALUES (5, 19364.00, 5, 5, 5)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
/****** Object:  Table [dbo].[Price]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[DestinationId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DestinationName] [nvarchar](50) NOT NULL,
	[AdultPrice] [float] NOT NULL,
	[ChildenPrice] [float] NOT NULL,
	[FirstClassPrice] [float] NOT NULL,
	[LuggagePrice] [float] NOT NULL	)
GO
SET IDENTITY_INSERT [dbo].[Price] ON
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (1, N'EKBI - BILLUND, Denmark', 390, 295, 1699, 290)
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (2, N'EKCH - COPENHAGEN, Denmark', '1595.00', '1395.00', '1699.00', '290.00')
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildrenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (3, N'LEPA - PALMA DE MALLORCA, Spain', '4995.00', '3099.00', '1699.00', '290.00')
SET IDENTITY_INSERT [dbo].[Price] OFF
GO
--Created by Daniel Giversen