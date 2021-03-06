USE [master]
GO
/****** Object:  Database [SmartEducation]    Script Date: 29/03/2020 07:12:54 ******/
CREATE DATABASE [SmartEducation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SmartEducation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SmartEducation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SmartEducation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SmartEducation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SmartEducation] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartEducation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartEducation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SmartEducation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SmartEducation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SmartEducation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SmartEducation] SET ARITHABORT OFF 
GO
ALTER DATABASE [SmartEducation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SmartEducation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SmartEducation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SmartEducation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SmartEducation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SmartEducation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SmartEducation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SmartEducation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SmartEducation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SmartEducation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SmartEducation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SmartEducation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SmartEducation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SmartEducation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SmartEducation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SmartEducation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SmartEducation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SmartEducation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SmartEducation] SET  MULTI_USER 
GO
ALTER DATABASE [SmartEducation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SmartEducation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SmartEducation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SmartEducation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SmartEducation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SmartEducation] SET QUERY_STORE = OFF
GO
USE [SmartEducation]
GO
/****** Object:  Table [dbo].[AcadimacYears]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcadimacYears](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_AcadimacYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ads]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ads](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[Post] [nvarchar](max) NULL,
	[Image] [varbinary](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Ads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdsFiles]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdsFiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AdsId] [bigint] NULL,
	[AttashmentFile] [nvarchar](max) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_AdsFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionID] [bigint] NULL,
	[ExamAnswers] [nvarchar](150) NULL,
	[ModifiedBy] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[Discreptions] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectId] [bigint] NULL,
	[EventId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[FullMarck] [int] NULL,
	[Length] [time](7) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LectureFiles]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LectureFiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LectureId] [bigint] NULL,
	[AttashmentFile] [nvarchar](max) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_LectureFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lectures]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectures](
	[Id] [bigint] NOT NULL,
	[ShaptersId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Lectures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[Coordinates] [nvarchar](150) NULL,
	[Level] [smallint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipalitys]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipalitys](
	[Id] [bigint] NOT NULL,
	[ResponsibleId] [bigint] NULL,
	[LocationId] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[AddressDiscreption] [nvarchar](150) NULL,
	[Discreption] [nvarchar](150) NULL,
	[ModifiedBy] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Municipality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionGroup]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[PermissioinId] [int] NULL,
	[Name] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK_PermissionGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ExamId] [bigint] NULL,
	[Number] [int] NULL,
	[Question] [nvarchar](250) NULL,
	[Points] [int] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MunicipalityId] [bigint] NULL,
	[LocationId] [bigint] NULL,
	[ResponsibleId] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[AddressDiscreption] [nvarchar](150) NULL,
	[EducationalLevel] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shapters]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shapters](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Shapters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAnswer]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAnswer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentExamId] [bigint] NULL,
	[AnsewrId] [bigint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_StudentAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentExam]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentExam](
	[Id] [bigint] NOT NULL,
	[StudentId] [bigint] NULL,
	[ExamId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_StudentExam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SchoolId] [bigint] NULL,
	[AcadimecYearId] [bigint] NULL,
	[NID] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[GrandFatherName] [nvarchar](50) NULL,
	[SurName] [nvarchar](50) NULL,
	[MatherName] [nvarchar](50) NULL,
	[Adrress] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AcadimecYearId] [bigint] NULL,
	[Name] [nvarchar](150) NULL,
	[Discreptions] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/03/2020 07:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](250) NULL,
	[Image] [varbinary](max) NULL,
	[Phone] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[LoginTryAttemptDate] [datetime] NULL,
	[LoginTryAttempts] [smallint] NULL,
	[LastLoginOn] [datetime] NULL,
	[Gender] [smallint] NULL,
	[UserType] [smallint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[PermissionGroup] ADD  CONSTRAINT [DF_PermissionGroup_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Permissions_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserType_1]  DEFAULT ((2)) FOR [UserType]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_State_1]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[AdsFiles]  WITH CHECK ADD  CONSTRAINT [FK_AdsFiles_Ads] FOREIGN KEY([AdsId])
REFERENCES [dbo].[Ads] ([Id])
GO
ALTER TABLE [dbo].[AdsFiles] CHECK CONSTRAINT [FK_AdsFiles_Ads]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Subjects]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Events]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Subjects]
GO
ALTER TABLE [dbo].[LectureFiles]  WITH CHECK ADD  CONSTRAINT [FK_LectureFiles_Lectures] FOREIGN KEY([LectureId])
REFERENCES [dbo].[Lectures] ([Id])
GO
ALTER TABLE [dbo].[LectureFiles] CHECK CONSTRAINT [FK_LectureFiles_Lectures]
GO
ALTER TABLE [dbo].[Lectures]  WITH CHECK ADD  CONSTRAINT [FK_Lectures_Shapters] FOREIGN KEY([ShaptersId])
REFERENCES [dbo].[Shapters] ([Id])
GO
ALTER TABLE [dbo].[Lectures] CHECK CONSTRAINT [FK_Lectures_Shapters]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Locations] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Locations]
GO
ALTER TABLE [dbo].[Municipalitys]  WITH CHECK ADD  CONSTRAINT [FK_Municipalitys_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Municipalitys] CHECK CONSTRAINT [FK_Municipalitys_Locations]
GO
ALTER TABLE [dbo].[Municipalitys]  WITH CHECK ADD  CONSTRAINT [FK_Municipalitys_Users] FOREIGN KEY([ResponsibleId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Municipalitys] CHECK CONSTRAINT [FK_Municipalitys_Users]
GO
ALTER TABLE [dbo].[PermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_PermissionGroup_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[PermissionGroup] CHECK CONSTRAINT [FK_PermissionGroup_Groups]
GO
ALTER TABLE [dbo].[PermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_PermissionGroup_Permissions] FOREIGN KEY([PermissioinId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[PermissionGroup] CHECK CONSTRAINT [FK_PermissionGroup_Permissions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Exams] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Exams]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_Locations]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Municipalitys] FOREIGN KEY([MunicipalityId])
REFERENCES [dbo].[Municipalitys] ([Id])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_Municipalitys]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Users] FOREIGN KEY([ResponsibleId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_Users]
GO
ALTER TABLE [dbo].[Shapters]  WITH CHECK ADD  CONSTRAINT [FK_Shapters_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[Shapters] CHECK CONSTRAINT [FK_Shapters_Events]
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Answers] FOREIGN KEY([AnsewrId])
REFERENCES [dbo].[Answers] ([Id])
GO
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Answers]
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_StudentExam] FOREIGN KEY([StudentExamId])
REFERENCES [dbo].[StudentExam] ([Id])
GO
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_StudentExam]
GO
ALTER TABLE [dbo].[StudentExam]  WITH CHECK ADD  CONSTRAINT [FK_StudentExam_Exams] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([Id])
GO
ALTER TABLE [dbo].[StudentExam] CHECK CONSTRAINT [FK_StudentExam_Exams]
GO
ALTER TABLE [dbo].[StudentExam]  WITH CHECK ADD  CONSTRAINT [FK_StudentExam_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[StudentExam] CHECK CONSTRAINT [FK_StudentExam_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_AcadimacYears] FOREIGN KEY([AcadimecYearId])
REFERENCES [dbo].[AcadimacYears] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_AcadimacYears]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Schools] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Schools] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Schools]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_AcadimacYears] FOREIGN KEY([AcadimecYearId])
REFERENCES [dbo].[AcadimacYears] ([Id])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_AcadimacYears]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Group]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-public
2-private
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ads', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-image
2-pdf
3-sound' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdsFiles', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-true Answer
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Answers', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-public
2-private 
9-deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-active
2-not active
3-stopped
4-admin
9-delete
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Groups', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-image
2-pdf
3-sound' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LectureFiles', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Municipalitys', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-active
2-not active
3-stopped
4-admin
9-delete
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionGroup', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-active
2-not active
3-stopped
4-admin
9-delete
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questions', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-hiegh school
2-college
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schools', @level2type=N'COLUMN',@level2name=N'EducationalLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-private 
2-public ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schools', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentAnswer', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentExam', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-admin
2-user
3-doctor
4-employ
5-SchoolManger
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-active
2-not active
3-stopped
4-admin
9-delete
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'State'
GO
USE [master]
GO
ALTER DATABASE [SmartEducation] SET  READ_WRITE 
GO
