USE [master]
GO
/****** Object:  Database [StudentTracker]    Script Date: 1/18/2020 2:19:36 AM ******/
CREATE DATABASE [StudentTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentTracker] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentTracker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentTracker] SET  MULTI_USER 
GO
ALTER DATABASE [StudentTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentTracker] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentTracker', N'ON'
GO
ALTER DATABASE [StudentTracker] SET QUERY_STORE = OFF
GO
USE [StudentTracker]
GO
/****** Object:  Table [dbo].[AcadimacYears]    Script Date: 1/18/2020 2:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcadimacYears](
	[AcadimecYearId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_AcadimacYears] PRIMARY KEY CLUSTERED 
(
	[AcadimecYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 1/18/2020 2:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventGroup] [nchar](10) NULL,
	[AcadimecYearId] [int] NULL,
	[YearId] [bigint] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examing]    Script Date: 1/18/2020 2:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examing](
	[ExamingId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Marck] [int] NULL,
	[EventId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Examing] PRIMARY KEY CLUSTERED 
(
	[ExamingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grids]    Script Date: 1/18/2020 2:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grids](
	[Grid] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentEventId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Grids] PRIMARY KEY CLUSTERED 
(
	[Grid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packeges]    Script Date: 1/18/2020 2:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packeges](
	[SchoolId] [bigint] NULL,
	[StatrtDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presness]    Script Date: 1/18/2020 2:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presness](
	[PresnessId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentEventId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Presness] PRIMARY KEY CLUSTERED 
(
	[PresnessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 1/18/2020 2:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[SchoolId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserId] [bigint] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentEvents]    Script Date: 1/18/2020 2:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEvents](
	[StudentEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NULL,
	[EventId] [bigint] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_StudentEvents] PRIMARY KEY CLUSTERED 
(
	[StudentEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentNotes]    Script Date: 1/18/2020 2:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentNotes](
	[StudentId] [bigint] NULL,
	[Note] [nvarchar](128) NULL,
	[Discreptions] [nchar](10) NULL,
	[CreatedBy] [nchar](10) NULL,
	[CreatedOn] [nchar](10) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/18/2020 2:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[GrandFatherName] [nvarchar](50) NULL,
	[SurName] [nvarchar](50) NULL,
	[Adrress] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
	[MatherName] [nvarchar](50) NULL,
	[ParentId] [bigint] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/18/2020 2:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [bigint] IDENTITY(1,1) NOT NULL,
	[AcadimecYearId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/18/2020 2:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](200) NULL,
	[Photo] [varbinary](max) NULL,
	[Gender] [smallint] NOT NULL,
	[UserType] [smallint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Years]    Script Date: 1/18/2020 2:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[YearId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Years] PRIMARY KEY CLUSTERED 
(
	[YearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcadimacYears] ON 

INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'أولي تانوي', N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (2, N'تانية تانوي', N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (3, N'تالتة تانوي', N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AcadimacYears] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventGroup], [AcadimecYearId], [YearId], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'A         ', 1, 1, N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Events] ([EventId], [EventGroup], [AcadimecYearId], [YearId], [CreatedBy], [CreatedOn], [Status]) VALUES (2, N'B         ', 1, 1, N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Presness] ON 

INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (2, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (3, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (4, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 2)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (5, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 2)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (6, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (7, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (8, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 3)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (9, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[Presness] ([PresnessId], [StudentEventId], [CreatedOn], [CreatedBy], [Status]) VALUES (10, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'1', 1)
SET IDENTITY_INSERT [dbo].[Presness] OFF
SET IDENTITY_INSERT [dbo].[StudentEvents] ON 

INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (1, 2, 1, N'1', CAST(N'2019-12-01T14:04:32.260' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (3, 2, 1, N'1', CAST(N'2019-12-01T14:15:17.730' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (4, 2, 1, N'1', CAST(N'2019-12-01T14:31:09.433' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (7, 2, 1, N'1', CAST(N'2019-12-01T14:47:04.007' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (9, 8, 1, N'1', CAST(N'2019-12-01T15:21:26.750' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (10, 9, 1, N'1', CAST(N'2019-12-01T17:58:01.847' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (11, 10, 1, N'1', CAST(N'2019-12-31T15:17:15.957' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[StudentEvents] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (1, N'Ahmed', N'Tarek', N'Tarek', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (2, N'Tarek', N'Fathi', N'Fathi', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2019-12-01T14:04:25.463' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (4, N'Fathi', N'Tarek', N'Ahmed', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2019-12-01T14:14:55.977' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (5, N'Ahmed', N'Fathi', N'Tarek', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2019-12-01T14:31:09.433' AS DateTime), 9, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (6, N'Tarek', N'Fathi', N'Fathi', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2019-12-01T14:47:04.007' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (8, N'Fathi', N'Tarek', N'L', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, N'1', CAST(N'2019-12-01T15:21:26.750' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (9, N'lkjk', N'jgqj', N'jhfq', N'gf', NULL, N'kj', 1, N'1', CAST(N'2019-12-01T17:58:01.847' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (10, N'Ahmed', N'Tareck', N'Fathi', N'BenSuliman', NULL, N'0927294572', 1, N'1', CAST(N'2019-12-31T15:17:15.953' AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Phone], [LoginName], [Email], [Password], [Photo], [Gender], [UserType], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'أحمد طارق بن سليمان', N'0927294572', N'Ahmed', N'ahmedtareckb@gmail.com', N's9s29j8nmkIZkPQ0y1LP+WM0SmcSntd/D/xz+fwfRqu8v9TOnDmYXpe8xuB2k8JjD39xDYMwtgobpCV8ToDiq8aDbVkswA==', NULL, 1, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Years] ON 

INSERT [dbo].[Years] ([YearId], [Name], [CreatedBy], [CreatedOn]) VALUES (1, N'خريف 2019', N'1', CAST(N'2018-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Years] OFF
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_AcadimacYears] FOREIGN KEY([AcadimecYearId])
REFERENCES [dbo].[AcadimacYears] ([AcadimecYearId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_AcadimacYears]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Years] FOREIGN KEY([YearId])
REFERENCES [dbo].[Years] ([YearId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Years]
GO
ALTER TABLE [dbo].[Examing]  WITH CHECK ADD  CONSTRAINT [FK_Examing_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Examing] CHECK CONSTRAINT [FK_Examing_Events]
GO
ALTER TABLE [dbo].[Examing]  WITH CHECK ADD  CONSTRAINT [FK_Examing_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Examing] CHECK CONSTRAINT [FK_Examing_Subjects]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_StudentEvents] FOREIGN KEY([StudentEventId])
REFERENCES [dbo].[StudentEvents] ([StudentEventId])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_StudentEvents]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_Subjects]
GO
ALTER TABLE [dbo].[Packeges]  WITH CHECK ADD  CONSTRAINT [FK_Packeges_Schools] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId])
GO
ALTER TABLE [dbo].[Packeges] CHECK CONSTRAINT [FK_Packeges_Schools]
GO
ALTER TABLE [dbo].[Presness]  WITH CHECK ADD  CONSTRAINT [FK_Presness_StudentEvents1] FOREIGN KEY([StudentEventId])
REFERENCES [dbo].[StudentEvents] ([StudentEventId])
GO
ALTER TABLE [dbo].[Presness] CHECK CONSTRAINT [FK_Presness_StudentEvents1]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_User]
GO
ALTER TABLE [dbo].[StudentEvents]  WITH CHECK ADD  CONSTRAINT [FK_StudentEvents_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[StudentEvents] CHECK CONSTRAINT [FK_StudentEvents_Events]
GO
ALTER TABLE [dbo].[StudentEvents]  WITH CHECK ADD  CONSTRAINT [FK_StudentEvents_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentEvents] CHECK CONSTRAINT [FK_StudentEvents_Students]
GO
ALTER TABLE [dbo].[StudentNotes]  WITH CHECK ADD  CONSTRAINT [FK_StudentNotes_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentNotes] CHECK CONSTRAINT [FK_StudentNotes_Students]
GO
ALTER TABLE [dbo].[Students]  WITH NOCHECK ADD  CONSTRAINT [FK_Students_User] FOREIGN KEY([ParentId])
REFERENCES [dbo].[User] ([UserId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Students] NOCHECK CONSTRAINT [FK_Students_User]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_AcadimacYears] FOREIGN KEY([AcadimecYearId])
REFERENCES [dbo].[AcadimacYears] ([AcadimecYearId])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_AcadimacYears]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-admin
2-parent
3-student' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-not active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Status'
GO
USE [master]
GO
ALTER DATABASE [StudentTracker] SET  READ_WRITE 
GO
