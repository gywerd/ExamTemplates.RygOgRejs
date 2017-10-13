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
INSERT [dbo].[AncillaryCharges] ([FirstClassPrice], [LuggagePricePerOverloadKg]) VALUES ('1699.00', '290.00')
GO
/****** Object:  Table [dbo].[Transactions]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TransactionDate] [datetime] NOT NULL,
	[DestinationName] [nvarchar](20) NOT NULL,
	[IsFirstClass] [bit] NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[LuggageAmount] [float] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[AmountExclVat] [float] NOT NULL)
GO
INSERT [dbo].[Transactions]([TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES ('2017-10-14', N'PalmaDeMallorca', 1, 1, 5, 145, N'Jensine', N'Pedersen', 34668.00)
INSERT [dbo].[Transactions]([TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES ('2017-10-14', N'Billund', 0, 2, 2, 90, N'Peder', N'Andersen', 8408.00)
INSERT [dbo].[Transactions]([TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES ('2017-10-14', N'Copenhagen', 0, 3, 1, 94, N'Andrea', N'Hansen', 6180.00)
INSERT [dbo].[Transactions]([TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES ('2017-10-14', N'PalmaDeMallorca', 1, 2, 1, 70, N'Hans', N'Nielsen', 18196.00)
INSERT [dbo].[Transactions]([TransactionDate], [DestinationName], [IsFirstClass], [Adults], [Children], [LuggageAmount], [FirstName], [LastName], [AmountExclVat]) VALUES ('2017-10-14', N'Copenhagen', 1, 4, 2, 94, N'Nielsine', N'Jensen', 19364.00)
GO
/****** Object:  Table [dbo].[Destinations]    09/14/2017 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[DestinationId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DestinationName] [nvarchar](20) NOT NULL,
	[IATA] [NVARCHAR](4) NOT NULL,
	[ICAO] [NVARCHAR](4) NOT NULL,
	[CountryCode] [NVARCHAR](3) NOT NULL,
	[AdultPrice] [float] NOT NULL,
	[ChildrenPrice] [float] NOT NULL)
GO
INSERT [dbo].[Destinations]([DestinationName], [IATA], [ICAO], [CountryCode], [AdultPrice], [ChildrenPrice]) VALUES (N'Billund', N'BLL', N'EKBI', N'DK', '390.00' , '295.00')
INSERT [dbo].[Destinations]([DestinationName], [IATA], [ICAO], [CountryCode], [AdultPrice], [ChildrenPrice]) VALUES (N'Copenhagen', N'CPH', N'EKCH', N'DK', '1595.00', '1395.00')
INSERT [dbo].[Destinations]([DestinationName], [IATA], [ICAO], [CountryCode], [AdultPrice], [ChildrenPrice]) VALUES (N'PalmaDeMallorca', N'PMI', N'LEPA', N'ES', '4995.00', '3099.00')
GO
--Created by Daniel Giversen Modifyed by Emil