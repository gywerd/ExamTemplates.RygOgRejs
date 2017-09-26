USE [Aquila]
GO
/****** Object:  Table [dbo].[Journeys]    Script Date: 09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journeys](
	[JourneyId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Destination] [nvarchar](20) NOT NULL,
	[DepartureDate] [datetime](24) NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[IsFirstClass] [bit] NOT NULL,
	[LuggageAmount] [int] NOT NULL );
GO
SET IDENTITY_INSERT [dbo].[Journeys] ON
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (1, N'Palma de Mallorca', '2017-10-14 00:00:00', 57, 5, 1, 145)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (2, N'Billund', '2017-10-14 00:00:00', 2, 2, 0, 90)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (3, N'København', '2017-10-14 00:00:00', 3, 1, 0, 24)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (4, N'Palma de Mallorca', '2017-10-14 00:00:00', 2, 1, 1, 70)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (5, N'København', '2017-10-14 00:00:00', 4, 2, 1, 140)
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
GO
SET IDENTITY_INSERT [dbo].[Payers] ON
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName]) VALUES (1, N'Pedersen', N'Jensine')
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName]) VALUES (2, N'Andersen', N'Peder')
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName]) VALUES (3, N'Hansen', N'Andrea')
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName]) VALUES (4, N'Nielsen', N'Hans')
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName]) VALUES (5, N'Jensen', N'Nielsine')
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
	[JourneyId] [int] NOT NULL FOREIGN KEY REFERENCES Journeys(JourneyId));
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (1, 34668.00, 1, 1)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (2, 8408.00, 2, 2)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (3, 6180.00, 3, 3)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (4, 18196.00, 4, 4)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (5, 19364.00, 5, 5)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
/****** Object:  Table [dbo].[Price]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[DestinationId] [nvarchar] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DestinationName] [nvarchar] NOT NULL,
	[AdultPrice] [float] NOT NULL,
	[ChildenPrice] [float] NOT NULL,
	[FirstClassPrice] [float] NOT NULL,
	[LuggagePrice] [float] NOT NULL	);
GO
SET IDENTITY_INSERT [dbo].[Price] ON
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (1, 390.00, 295.00, 1699.00, 290.00)
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (2, 1595.00, 1395.00, 1699.00, 290.00)
INSERT [dbo].[Price]([DestinationId], [DestinationName], [AdultPrice], [ChildenPrice], [FirstClassPrice], [LuggagePrice]) VALUES (3, 4995.00, 3099.00, 1699.00, 290.00)
SET IDENTITY_INSERT [dbo].[Price] OFF
GO

--Created by Daniel Giversen