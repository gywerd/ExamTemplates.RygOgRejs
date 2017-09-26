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
	[DepartureDate] [date](24) NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[IsFirstClass] [bit] NOT NULL
	[LuggageAmount] [int] NOT NULL );
GO
SET IDENTITY_INSERT [dbo].[Journeys] ON
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (1, N'Palma de Mallorca' DATE'2017-10-14', 57, 5, BIT'1', 30)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (2, N'Billund' DATE'2017-10-14', 2, 2, BIT'0', 22)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (3, N'København' DATE'2017-10-14', 3, 1, BIT'0', 24)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (4, N'Palma de Mallorca' DATE'2017-10-14', 2, 1, BIT'1', 19)
INSERT [dbo].[Journeys] ([JourneyId], [Destination], [Adults], [Children], [IsFirstClass], [LuggageAmount]) VALUES (5, N'København' DATE'2017-10-14', 4, 2, BIT'1', 33)
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
	[Ssn] [nvarchar](13) NOT NULL,
	[JourneyId] [int](20) NOT NULLFOREIGN KEY REFERENCES Journeys(JourneyID))
	
GO
SET IDENTITY_INSERT [dbo].[Payers] ON
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [Ssn], [JourneyId]) VALUES (1, N'Pedersen', N'Jensine', N'0711995154', 1)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [Ssn], [JourneyId]) VALUES (2, N'Andersen', N'Peder', N'1204573539', 2)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [Ssn], [JourneyId]) VALUES (3, N'Hansen', N'Andrea', N'1306791270', 3)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [Ssn], [JourneyId]) VALUES (4, N'Nielsen', N'Hans', N'0201007747', 4)
INSERT [dbo].[Payers] ([PayerId], [LastName], [FirstName], [Ssn], [JourneyId]) VALUES (5, N'Jensen', N'Nielsine', N'0101002144', 5)
SET IDENTITY_INSERT [dbo].[Payers] OFF
GO
/****** Object:  Table [dbo].[Transactions]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Amount] [float](60) NOT NULL,
	[PayerId] [int] NOT NULL FOREIGN KEY REFERENCES Payers(PayerId)
	[JourneyId] [int] NOT NULL FOREIGN KEY REFERENCES Journeys(JourneyId));
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (1, FLOAT'', 1, 1)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (2, FLOAT'', 2, 2)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (3, FLOAT'', 3, 3)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (4, FLOAT'', 4, 4)
INSERT [dbo].[Transactions]([TransactionId], [Amount], [PayerId], [JourneyId]) VALUES (5, FLOAT'', 5, 5)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
/****** Object:  Table [dbo].[UserCredentials]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCredentials](
	[UserId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserName] [nvarchar](60) NOT NULL,
	[Password] [nvarchar](60) NOT NULL);
GO
SET IDENTITY_INSERT [dbo].[UserCredentials] ON
INSERT [dbo].[UserCredentials](UserId], [UserName], [Password]) VALUES (1, N'Mara', N'1234')
INSERT [dbo].[UserCredentials](UserId], [UserName], [Password]) VALUES (2, N'JensC', N'1234')
INSERT [dbo].[UserCredentials](UserId], [UserName], [Password]) VALUES (3, N'JensO', N'1234')
INSERT [dbo].[UserCredentials](UserId], [UserName], [Password]) VALUES (4, N'Daniel', N'0412')
SET IDENTITY_INSERT [dbo].[UserCredentials] OFF
GO

--Created by Daniel Giversen