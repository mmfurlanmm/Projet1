USE [master]
GO
/****** Object:  Database [SondageBDD]    Script Date: 29/01/2018 11:46:05 ******/
CREATE DATABASE [SondageBDD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SondageBDD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SondageBDD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SondageBDD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SondageBDD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SondageBDD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SondageBDD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SondageBDD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SondageBDD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SondageBDD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SondageBDD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SondageBDD] SET ARITHABORT OFF 
GO
ALTER DATABASE [SondageBDD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SondageBDD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SondageBDD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SondageBDD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SondageBDD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SondageBDD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SondageBDD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SondageBDD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SondageBDD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SondageBDD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SondageBDD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SondageBDD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SondageBDD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SondageBDD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SondageBDD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SondageBDD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SondageBDD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SondageBDD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SondageBDD] SET  MULTI_USER 
GO
ALTER DATABASE [SondageBDD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SondageBDD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SondageBDD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SondageBDD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SondageBDD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SondageBDD] SET QUERY_STORE = OFF
GO
USE [SondageBDD]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SondageBDD]
GO
/****** Object:  Table [dbo].[ChoixPossibles]    Script Date: 29/01/2018 11:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChoixPossibles](
	[IdChoix] [int] IDENTITY(1,1) NOT NULL,
	[IntituleChoix] [nvarchar](100) NULL,
	[NbVotantsParChoix] [int] NULL,
	[FkIdSondage] [int] NOT NULL,
 CONSTRAINT [PK_ChoixPossibles] PRIMARY KEY CLUSTERED 
(
	[IdChoix] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sondage]    Script Date: 29/01/2018 11:46:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sondage](
	[IdSondage] [int] IDENTITY(1,1) NOT NULL,
	[ChoixMultiple] [bit] NULL,
	[Question] [nvarchar](100) NULL,
	[NbVotants] [int] NULL,
	[LienSuppression] [nchar](150) NULL,
	[LienResultat] [nchar](150) NULL,
	[LienPartage] [nchar](150) NULL,
	[SondageActif] [bit] NULL,
 CONSTRAINT [PK_Sondage] PRIMARY KEY CLUSTERED 
(
	[IdSondage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChoixPossibles] ON 

INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (4, N'qsd', 10, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (6, N'dsqdqs', 20, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (7, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (8, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (9, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (10, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (11, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (12, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (13, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (14, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (15, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (16, NULL, NULL, 3)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (19, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (20, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (21, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (22, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (23, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (24, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (25, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (26, N'PremierChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (27, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (28, N'TroisièmeChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (29, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (30, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (31, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (32, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (33, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (34, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (35, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (36, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (37, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (38, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (39, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (40, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (41, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (42, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (43, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (44, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (45, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (46, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (47, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (48, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (49, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (50, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (51, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (52, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (53, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (54, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (55, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (56, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (57, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (58, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (59, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (60, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (61, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (62, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (63, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (64, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (65, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (66, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (67, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (68, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (69, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (70, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (71, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (72, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (73, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (74, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (75, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (76, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (77, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (78, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (79, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (80, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (81, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (82, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (83, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (84, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (85, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (86, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (87, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (88, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (89, N'SecondChoix', 30, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (90, N'TroisièmeChoix', 200, 1)
INSERT [dbo].[ChoixPossibles] ([IdChoix], [IntituleChoix], [NbVotantsParChoix], [FkIdSondage]) VALUES (91, N'SecondChoix', 30, 1)
SET IDENTITY_INSERT [dbo].[ChoixPossibles] OFF
SET IDENTITY_INSERT [dbo].[Sondage] ON 

INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (1, 0, N'dsdv', 20, N'sdsxvx                                                                                                                                                ', N'vxxcv                                                                                                                                                 ', N'vxcvxc                                                                                                                                                ', 1)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (2, 1, N'sdfsdfds', 30, N'sdfssdf                                                                                                                                               ', N'sfdsdfsdf                                                                                                                                             ', N'sdqfsdv                                                                                                                                               ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (3, 1, N'sqdsfsdx', 40, N'sdfdsfsdfsd                                                                                                                                           ', N'sdfdsfsdfdsfsd                                                                                                                                        ', N'sfdsfsdfsdsd                                                                                                                                          ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (5, 0, N'dfdsffds', 60, N'qsdqsd                                                                                                                                                ', N'qwxcwc                                                                                                                                                ', N'wxcwc                                                                                                                                                 ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (6, NULL, N'blabla', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (7, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (8, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (9, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (10, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (11, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (12, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (13, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (14, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (15, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (16, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (17, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (18, 0, N'LaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (19, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (20, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (21, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (22, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (23, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (24, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (25, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (26, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (27, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (28, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (29, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (30, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (31, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (32, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (33, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (34, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (35, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (36, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (37, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (38, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (39, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (40, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (41, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (42, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (43, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (44, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (45, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (46, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (47, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (48, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (49, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (50, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
INSERT [dbo].[Sondage] ([IdSondage], [ChoixMultiple], [Question], [NbVotants], [LienSuppression], [LienResultat], [LienPartage], [SondageActif]) VALUES (51, 0, N'DeuxLaQuestion', 30, N'leLienSuppression                                                                                                                                     ', N'leLienResultat                                                                                                                                        ', N'leLienPartage                                                                                                                                         ', 0)
SET IDENTITY_INSERT [dbo].[Sondage] OFF
ALTER TABLE [dbo].[ChoixPossibles]  WITH CHECK ADD  CONSTRAINT [FK_ChoixPossibles_Sondage] FOREIGN KEY([FkIdSondage])
REFERENCES [dbo].[Sondage] ([IdSondage])
GO
ALTER TABLE [dbo].[ChoixPossibles] CHECK CONSTRAINT [FK_ChoixPossibles_Sondage]
GO
ALTER TABLE [dbo].[Sondage]  WITH CHECK ADD  CONSTRAINT [FK_Sondage_Sondage] FOREIGN KEY([IdSondage])
REFERENCES [dbo].[Sondage] ([IdSondage])
GO
ALTER TABLE [dbo].[Sondage] CHECK CONSTRAINT [FK_Sondage_Sondage]
GO
USE [master]
GO
ALTER DATABASE [SondageBDD] SET  READ_WRITE 
GO
