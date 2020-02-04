USE [master]
GO
/****** Object:  Database [StudentTracker]    Script Date: 2/4/2020 11:32:51 AM ******/
CREATE DATABASE [StudentTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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
/****** Object:  Table [dbo].[AcadimacYears]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcadimacYears](
	[AcadimecYearId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_AcadimacYears] PRIMARY KEY CLUSTERED 
(
	[AcadimecYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventGroup] [nchar](10) NULL,
	[AcadimecYearId] [int] NULL,
	[YearId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[ExamId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Discreptons] [nvarchar](max) NULL,
	[FullMarck] [int] NULL,
	[ExamDate] [date] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grids]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grids](
	[GridId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NULL,
	[ExamId] [bigint] NULL,
	[Grid] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Grids] PRIMARY KEY CLUSTERED 
(
	[GridId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeWorcks]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeWorcks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[Name] [nvarchar](max) NULL,
	[Disctiption] [nvarchar](max) NULL,
	[LastDayDilavary] [date] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_HomeWorcks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packeges]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packeges](
	[SchoolId] [bigint] NULL,
	[StatrtDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presness]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presness](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LectureDate] [date] NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
	[EventId] [bigint] NULL,
 CONSTRAINT [PK_Presness_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PresnessInfo]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresnessInfo](
	[PresnessInfoId] [bigint] IDENTITY(1,1) NOT NULL,
	[PresnessId] [bigint] NULL,
	[StudentId] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Presness] PRIMARY KEY CLUSTERED 
(
	[PresnessInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[SchoolId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skedjule]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skedjule](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectId] [bigint] NULL,
	[EventId] [bigint] NULL,
	[Day] [smallint] NULL,
	[LectureNumber] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_Skedjule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentEvents]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEvents](
	[StudentEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NULL,
	[EventId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_StudentEvents] PRIMARY KEY CLUSTERED 
(
	[StudentEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2/4/2020 11:32:51 AM ******/
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
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
	[MatherName] [nvarchar](50) NULL,
	[ParentId] [bigint] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [bigint] IDENTITY(1,1) NOT NULL,
	[AcadimecYearId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/4/2020 11:32:51 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Years]    Script Date: 2/4/2020 11:32:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[YearId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Years] PRIMARY KEY CLUSTERED 
(
	[YearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcadimacYears] ON 

INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'أولي تانوي', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (2, N'تانية تانوي', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[AcadimacYears] ([AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (3, N'تالتة تانوي', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AcadimacYears] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventGroup], [AcadimecYearId], [YearId], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'A         ', 1, 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Events] ([EventId], [EventGroup], [AcadimecYearId], [YearId], [CreatedBy], [CreatedOn], [Status]) VALUES (2, N'B         ', 1, 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Exams] ON 

INSERT [dbo].[Exams] ([ExamId], [EventId], [SubjectId], [Name], [Discreptons], [FullMarck], [ExamDate], [CreatedOn], [CreatedBy], [Status]) VALUES (1, 1, 1, N'Test 1', N'Test one', 50, CAST(N'2018-01-01' AS Date), CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Exams] ([ExamId], [EventId], [SubjectId], [Name], [Discreptons], [FullMarck], [ExamDate], [CreatedOn], [CreatedBy], [Status]) VALUES (2, 1, 1, N'ttttttt', N';lk;lk', 20, CAST(N'2020-02-09' AS Date), CAST(N'2020-02-01T02:40:49.777' AS DateTime), 1, 9)
SET IDENTITY_INSERT [dbo].[Exams] OFF
SET IDENTITY_INSERT [dbo].[Grids] ON 

INSERT [dbo].[Grids] ([GridId], [StudentId], [ExamId], [Grid], [CreatedOn], [CreatedBy], [Status]) VALUES (6, 13, 1, 10, CAST(N'2020-02-01T15:44:15.627' AS DateTime), 1, 1)
INSERT [dbo].[Grids] ([GridId], [StudentId], [ExamId], [Grid], [CreatedOn], [CreatedBy], [Status]) VALUES (7, 2, 1, 10, CAST(N'2020-02-01T15:44:15.660' AS DateTime), 1, 1)
INSERT [dbo].[Grids] ([GridId], [StudentId], [ExamId], [Grid], [CreatedOn], [CreatedBy], [Status]) VALUES (8, 2, 1, 10, CAST(N'2020-02-01T15:44:15.660' AS DateTime), 1, 1)
INSERT [dbo].[Grids] ([GridId], [StudentId], [ExamId], [Grid], [CreatedOn], [CreatedBy], [Status]) VALUES (9, 2, 1, 10, CAST(N'2020-02-01T15:44:15.660' AS DateTime), 1, 1)
INSERT [dbo].[Grids] ([GridId], [StudentId], [ExamId], [Grid], [CreatedOn], [CreatedBy], [Status]) VALUES (10, 2, 1, 10, CAST(N'2020-02-01T15:44:15.660' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Grids] OFF
SET IDENTITY_INSERT [dbo].[HomeWorcks] ON 

INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (1, 1, 1, N'التكامل', N'الصفحة رقم 10 من الكتاب المنزلي ', CAST(N'2020-01-01' AS Date), CAST(N'2019-01-12T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (2, 1, 1, N'sfdg', N'fsgf', CAST(N'2020-01-19' AS Date), CAST(N'2020-01-27T14:27:03.040' AS DateTime), 1, 1)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (3, 1, 1, N'sfdg', N'srg', CAST(N'2020-02-02' AS Date), CAST(N'2020-01-27T14:28:08.437' AS DateTime), 1, 1)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (4, 1, 1, N'adf', N'sadf', CAST(N'2020-01-06' AS Date), CAST(N'2020-01-27T14:29:39.877' AS DateTime), 1, 1)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (5, 1, 1, N'sdfg', N'sfsdfg', CAST(N'2020-01-19' AS Date), CAST(N'2020-01-27T14:30:07.647' AS DateTime), 1, 9)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (6, 2, 1, N'sfgsfg', N'fsdfg', CAST(N'2020-01-12' AS Date), CAST(N'2020-01-27T14:30:18.923' AS DateTime), 1, 9)
INSERT [dbo].[HomeWorcks] ([Id], [EventId], [SubjectId], [Name], [Disctiption], [LastDayDilavary], [CreatedOn], [CreatedBy], [Status]) VALUES (7, 1, 1, N'يي', N'ييي', CAST(N'2020-01-27' AS Date), CAST(N'2020-01-28T16:22:35.197' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[HomeWorcks] OFF
SET IDENTITY_INSERT [dbo].[Presness] ON 

INSERT [dbo].[Presness] ([Id], [LectureDate], [Note], [CreatedBy], [CreatedOn], [Status], [EventId]) VALUES (5, CAST(N'2020-01-06' AS Date), N'1/6/2020 10:00:00 PM', 1, CAST(N'2020-01-21T14:29:04.353' AS DateTime), 1, 1)
INSERT [dbo].[Presness] ([Id], [LectureDate], [Note], [CreatedBy], [CreatedOn], [Status], [EventId]) VALUES (6, CAST(N'2020-01-25' AS Date), N'1/25/2020 10:00:00 PM', 1, CAST(N'2020-01-22T16:59:13.553' AS DateTime), 1, 1)
INSERT [dbo].[Presness] ([Id], [LectureDate], [Note], [CreatedBy], [CreatedOn], [Status], [EventId]) VALUES (7, CAST(N'2020-01-14' AS Date), N'1/14/2020 10:00:00 PM', 1, CAST(N'2020-01-22T18:00:51.633' AS DateTime), 1, 1)
INSERT [dbo].[Presness] ([Id], [LectureDate], [Note], [CreatedBy], [CreatedOn], [Status], [EventId]) VALUES (8, CAST(N'2020-01-20' AS Date), N'1/20/2020 10:00:00 PM', 1, CAST(N'2020-01-28T16:20:39.477' AS DateTime), 1, 1)
INSERT [dbo].[Presness] ([Id], [LectureDate], [Note], [CreatedBy], [CreatedOn], [Status], [EventId]) VALUES (9, CAST(N'2020-01-26' AS Date), N'1/26/2020 10:00:00 PM', 1, CAST(N'2020-01-28T16:21:11.473' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Presness] OFF
SET IDENTITY_INSERT [dbo].[PresnessInfo] ON 

INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10017, 5, 10, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10018, 5, 8, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10019, 5, 9, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10020, 5, 2, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10021, 5, 2, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10022, 6, 10, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10023, 6, 8, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10024, 6, 9, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10025, 6, 2, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10026, 6, 2, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10027, 7, 10, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10028, 7, 8, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10029, 7, 9, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10030, 7, 2, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10031, 7, 2, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10032, 8, 14, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10033, 8, 23, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10034, 8, 10, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10035, 8, 24, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10036, 8, 12, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10037, 9, 14, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10038, 9, 23, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10039, 9, 10, 0)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10040, 9, 24, 1)
INSERT [dbo].[PresnessInfo] ([PresnessInfoId], [PresnessId], [StudentId], [Status]) VALUES (10041, 9, 12, 0)
SET IDENTITY_INSERT [dbo].[PresnessInfo] OFF
SET IDENTITY_INSERT [dbo].[Skedjule] ON 

INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (130, 1, 1, 1, 1, NULL, 1)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (131, NULL, 1, 1, 2, CAST(N'2020-02-01T19:26:47.837' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (132, NULL, 1, 1, 3, CAST(N'2020-02-01T19:26:47.840' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (133, NULL, 1, 1, 4, CAST(N'2020-02-01T19:26:47.840' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (134, NULL, 1, 1, 5, CAST(N'2020-02-01T19:26:47.840' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (135, NULL, 1, 1, 6, CAST(N'2020-02-01T19:26:47.840' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (136, NULL, 1, 1, 7, CAST(N'2020-02-01T19:26:47.840' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (137, NULL, 1, 2, 1, CAST(N'2020-02-01T19:26:48.090' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (138, NULL, 1, 2, 2, CAST(N'2020-02-01T19:26:48.090' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (139, NULL, 1, 2, 3, CAST(N'2020-02-01T19:26:48.090' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (140, NULL, 1, 2, 4, CAST(N'2020-02-01T19:26:48.090' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (141, NULL, 1, 2, 5, CAST(N'2020-02-01T19:26:48.093' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (142, NULL, 1, 2, 6, CAST(N'2020-02-01T19:26:48.093' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (143, NULL, 1, 2, 7, CAST(N'2020-02-01T19:26:48.093' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (144, NULL, 1, 3, 1, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (145, NULL, 1, 3, 2, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (146, NULL, 1, 3, 3, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (147, NULL, 1, 3, 4, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (148, NULL, 1, 3, 5, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (149, NULL, 1, 3, 6, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (150, NULL, 1, 3, 7, CAST(N'2020-02-01T19:26:48.110' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (151, NULL, 1, 4, 1, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (152, NULL, 1, 4, 2, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (153, NULL, 1, 4, 3, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (154, NULL, 1, 4, 4, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (155, NULL, 1, 4, 5, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (156, NULL, 1, 4, 6, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (157, NULL, 1, 4, 7, CAST(N'2020-02-01T19:26:48.123' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (158, NULL, 1, 5, 1, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (159, NULL, 1, 5, 2, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (160, NULL, 1, 5, 3, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (161, NULL, 1, 5, 4, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (162, NULL, 1, 5, 5, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (163, NULL, 1, 5, 6, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (164, NULL, 1, 5, 7, CAST(N'2020-02-01T19:26:48.137' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (165, NULL, 1, 6, 1, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (166, NULL, 1, 6, 2, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (167, NULL, 1, 6, 3, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (168, NULL, 1, 6, 4, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (169, NULL, 1, 6, 5, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (170, NULL, 1, 6, 6, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (171, NULL, 1, 6, 7, CAST(N'2020-02-01T19:26:48.150' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (172, NULL, 1, 1, 1, NULL, 1)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (173, NULL, 1, 1, 2, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (174, NULL, 1, 1, 3, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (175, NULL, 1, 1, 4, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (176, NULL, 1, 1, 5, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (177, NULL, 1, 1, 6, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (178, NULL, 1, 1, 7, CAST(N'2020-02-01T19:30:37.183' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (179, NULL, 1, 2, 1, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (180, NULL, 1, 2, 2, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (181, NULL, 1, 2, 3, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (182, NULL, 1, 2, 4, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (183, NULL, 1, 2, 5, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (184, NULL, 1, 2, 6, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (185, NULL, 1, 2, 7, CAST(N'2020-02-01T19:30:37.227' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (186, NULL, 1, 3, 1, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (187, NULL, 1, 3, 2, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (188, NULL, 1, 3, 3, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (189, NULL, 1, 3, 4, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (190, NULL, 1, 3, 5, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (191, NULL, 1, 3, 6, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (192, NULL, 1, 3, 7, CAST(N'2020-02-01T19:30:37.240' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (193, NULL, 1, 4, 1, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (194, NULL, 1, 4, 2, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (195, NULL, 1, 4, 3, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (196, NULL, 1, 4, 4, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (197, NULL, 1, 4, 5, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (198, NULL, 1, 4, 6, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (199, NULL, 1, 4, 7, CAST(N'2020-02-01T19:30:37.257' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (200, NULL, 1, 5, 1, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (201, NULL, 1, 5, 2, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (202, NULL, 1, 5, 3, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (203, NULL, 1, 5, 4, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (204, NULL, 1, 5, 5, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (205, NULL, 1, 5, 6, CAST(N'2020-02-01T19:30:37.270' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (206, NULL, 1, 5, 7, CAST(N'2020-02-01T19:30:37.273' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (207, NULL, 1, 6, 1, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (208, NULL, 1, 6, 2, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (209, NULL, 1, 6, 3, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (210, NULL, 1, 6, 4, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (211, NULL, 1, 6, 5, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (212, NULL, 1, 6, 6, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
INSERT [dbo].[Skedjule] ([Id], [SubjectId], [EventId], [Day], [LectureNumber], [CreatedOn], [CreatedBy]) VALUES (213, NULL, 1, 6, 7, CAST(N'2020-02-01T19:30:37.290' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Skedjule] OFF
SET IDENTITY_INSERT [dbo].[StudentEvents] ON 

INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (1, 2, 1, 1, CAST(N'2019-12-01T14:04:32.260' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (3, 2, 1, 1, CAST(N'2019-12-01T14:15:17.730' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (4, 2, 1, 1, CAST(N'2019-12-01T14:31:09.433' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (7, 2, 1, 1, CAST(N'2019-12-01T14:47:04.007' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (9, 8, 1, 1, CAST(N'2019-12-01T15:21:26.750' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (10, 9, 1, 1, CAST(N'2019-12-01T17:58:01.847' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (11, 10, 1, 1, CAST(N'2019-12-31T15:17:15.957' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (13, 12, 1, 1, CAST(N'2020-01-22T19:12:32.687' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (14, 13, 1, 1, CAST(N'2020-01-22T19:15:10.860' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (15, 14, 1, 1, CAST(N'2020-01-26T17:26:44.030' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (16, 15, 1, 1, CAST(N'2020-01-27T14:49:07.780' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (17, 16, 1, 1, CAST(N'2020-01-27T14:49:27.113' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (18, 17, 1, 1, CAST(N'2020-01-27T14:50:08.480' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (19, 18, 1, 1, CAST(N'2020-01-27T14:53:16.920' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (20, 19, 1, 1, CAST(N'2020-01-27T14:53:33.127' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (21, 20, 1, 1, CAST(N'2020-01-27T14:55:06.963' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (22, 21, 1, 1, CAST(N'2020-01-27T14:56:08.143' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (23, 22, 1, 1, CAST(N'2020-01-27T14:57:23.010' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (24, 23, 1, 1, CAST(N'2020-01-27T14:57:59.797' AS DateTime), 1)
INSERT [dbo].[StudentEvents] ([StudentEventId], [StudentId], [EventId], [CreatedBy], [CreatedOn], [Status]) VALUES (25, 24, 1, 1, CAST(N'2020-01-27T15:04:35.583' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[StudentEvents] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (1, N'Ahmed', N'Tarek', N'Tarek', N'benSuliman', N';l;l;l;l;l;l;', N'0927294572', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1, N'lklklk', 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (2, N'Tarek', N'Fathi', N'Fathi', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, 1, CAST(N'2019-12-01T14:04:25.463' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (4, N'Fathi', N'Tarek', N'Ahmed', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, 1, CAST(N'2019-12-01T14:14:55.977' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (5, N'Ahmed', N'Fathi', N'Tarek', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, 1, CAST(N'2019-12-01T14:31:09.433' AS DateTime), 9, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (6, N'Tarek', N'Fathi', N'Fathi', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, 1, CAST(N'2019-12-01T14:47:04.007' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (8, N'Fathi', N'Tarek', N'L', N'benSuliman', N'Souq-Al-goma', N'0927294572', 1, 1, CAST(N'2019-12-01T15:21:26.750' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (9, N'lkjk', N'jgqj', N'jhfq', N'gf', NULL, N'kj', 1, 1, CAST(N'2019-12-01T17:58:01.847' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (10, N'Ahmed', N'Tareck', N'Fathi', N'BenSuliman', NULL, N'0927294572', 1, 1, CAST(N'2019-12-31T15:17:15.953' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (12, N'dfgsdf', N'lkjljk', N'ljkl', N'lkj', NULL, N'0927294578', 1, 1, CAST(N'2020-01-22T19:12:32.687' AS DateTime), 1, N'sfgs', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (13, N'يبلسيلب', N'خهخحه', N'خحه', N'خحه', NULL, N'0927294575', 1, 1, CAST(N'2020-01-22T19:15:10.860' AS DateTime), 1, N'خحهخحه', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, CAST(N'2020-01-26T17:26:44.030' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (15, N'sfdg', N'sdfg', N'sdfg', N'sfdg', NULL, N'sfdg', 1, 1, CAST(N'2020-01-27T14:49:07.780' AS DateTime), 1, N'sdfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (16, N'fsdg', N'sfdg', N'sdfg', N'sfdg', NULL, N'sfg', 1, 1, CAST(N'2020-01-27T14:49:27.113' AS DateTime), 1, N'sfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (17, N'fsdgsfd', N'sdfg', N'sdfg', N'fdsg', NULL, N'sfdg', 1, 1, CAST(N'2020-01-27T14:50:08.480' AS DateTime), 1, N'sdfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (18, N'sfg', N'sfdg', N'ssfdgdfg', N'sfdg', NULL, N'sdfg', 1, 1, CAST(N'2020-01-27T14:53:16.920' AS DateTime), 1, N'sfdg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (19, N'fgsfd', N'sdfg', N'fs', N'sdfg', NULL, N'sfdg', 1, 1, CAST(N'2020-01-27T14:53:33.127' AS DateTime), 1, N'sdfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (20, N'sdfg', N'sdfg', N'sdfg', N'sdfg', NULL, N'sfdg', 1, 1, CAST(N'2020-01-27T14:55:06.963' AS DateTime), 1, N'sfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (21, N'sfg', N'sfdg', N'sdfg', N'sfdg', NULL, N'sfdg', 1, 1, CAST(N'2020-01-27T14:56:08.143' AS DateTime), 1, N'sfdg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (22, N'sfdg', N'sfg', N'sdfgsfdg', N'sfdg', NULL, N'sfg', 1, 1, CAST(N'2020-01-27T14:57:23.007' AS DateTime), 1, N'sdfg', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (23, N'adf', N'asdf', N'sdfgsfdgasdf', N'adsf', NULL, N'adf', 1, 1, CAST(N'2020-01-27T14:57:59.797' AS DateTime), 1, N'adsf', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [FatherName], [GrandFatherName], [SurName], [Adrress], [PhoneNumber], [Sex], [CreatedBy], [CreatedOn], [Status], [MatherName], [ParentId]) VALUES (24, N'asdf', N'adsf', N'sdfgsfdgasdfasdf', N'adsf', NULL, N'dfa', 1, 1, CAST(N'2020-01-27T15:04:35.583' AS DateTime), 1, N'asdf', NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (1, 1, N'رياضيات', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (2, 1, N'إحصاء', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (3, 1, N'كيمياء', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (4, 1, N'عربي', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (5, 1, N'علوم', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (6, 1, N'دين', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Subjects] ([SubjectId], [AcadimecYearId], [Name], [CreatedBy], [CreatedOn], [Status]) VALUES (7, 1, N'ديناميكا', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Phone], [LoginName], [Email], [Password], [Photo], [Gender], [UserType], [CreatedBy], [CreatedOn], [Status]) VALUES (1, N'أحمد طارق بن سليمان', N'0927294572', N'Ahmed', N'ahmedtareckb@gmail.com', N's9s29j8nmkIZkPQ0y1LP+WM0SmcSntd/D/xz+fwfRqu8v9TOnDmYXpe8xuB2k8JjD39xDYMwtgobpCV8ToDiq8aDbVkswA==', NULL, 1, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Years] ON 

INSERT [dbo].[Years] ([YearId], [Name], [CreatedBy], [CreatedOn]) VALUES (1, N'خريف 2019', 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
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
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Events]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Subjects1] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Subjects1]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_Exams] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([ExamId])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_Exams]
GO
ALTER TABLE [dbo].[Grids]  WITH CHECK ADD  CONSTRAINT [FK_Grids_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Grids] CHECK CONSTRAINT [FK_Grids_Students]
GO
ALTER TABLE [dbo].[HomeWorcks]  WITH CHECK ADD  CONSTRAINT [FK_HomeWorcks_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[HomeWorcks] CHECK CONSTRAINT [FK_HomeWorcks_Events]
GO
ALTER TABLE [dbo].[HomeWorcks]  WITH CHECK ADD  CONSTRAINT [FK_HomeWorcks_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[HomeWorcks] CHECK CONSTRAINT [FK_HomeWorcks_Subjects]
GO
ALTER TABLE [dbo].[Packeges]  WITH CHECK ADD  CONSTRAINT [FK_Packeges_Schools] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId])
GO
ALTER TABLE [dbo].[Packeges] CHECK CONSTRAINT [FK_Packeges_Schools]
GO
ALTER TABLE [dbo].[Presness]  WITH CHECK ADD  CONSTRAINT [FK_Presness_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Presness] CHECK CONSTRAINT [FK_Presness_Events]
GO
ALTER TABLE [dbo].[PresnessInfo]  WITH CHECK ADD  CONSTRAINT [FK_PresnessInfo_Presness1] FOREIGN KEY([PresnessId])
REFERENCES [dbo].[Presness] ([Id])
GO
ALTER TABLE [dbo].[PresnessInfo] CHECK CONSTRAINT [FK_PresnessInfo_Presness1]
GO
ALTER TABLE [dbo].[PresnessInfo]  WITH CHECK ADD  CONSTRAINT [FK_PresnessInfo_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[PresnessInfo] CHECK CONSTRAINT [FK_PresnessInfo_Students]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_User]
GO
ALTER TABLE [dbo].[Skedjule]  WITH CHECK ADD  CONSTRAINT [FK_Skedjule_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Skedjule] CHECK CONSTRAINT [FK_Skedjule_Events]
GO
ALTER TABLE [dbo].[Skedjule]  WITH CHECK ADD  CONSTRAINT [FK_Skedjule_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Skedjule] CHECK CONSTRAINT [FK_Skedjule_Subjects]
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
