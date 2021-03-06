USE [master]
GO
/****** Object:  Database [UniGuide]    Script Date: 4/15/2015 12:41:56 PM ******/
CREATE DATABASE [UniGuide]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniGuide', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012D\MSSQL\DATA\UniGuide.mdf' , SIZE = 26304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniGuide_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012D\MSSQL\DATA\UniGuide_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniGuide] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniGuide].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniGuide] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniGuide] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniGuide] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniGuide] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniGuide] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniGuide] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniGuide] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniGuide] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniGuide] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniGuide] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniGuide] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniGuide] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniGuide] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniGuide] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniGuide] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniGuide] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniGuide] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniGuide] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniGuide] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniGuide] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniGuide] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniGuide] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniGuide] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniGuide] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniGuide] SET  MULTI_USER 
GO
ALTER DATABASE [UniGuide] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniGuide] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniGuide] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniGuide] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniGuide', N'ON'
GO
USE [UniGuide]
GO
/****** Object:  Table [dbo].[AdmissionType]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdmissionType](
	[AdmisionID] [int] IDENTITY(1,1) NOT NULL,
	[AdmisionEng] [varchar](50) NOT NULL,
	[AdmisionArb] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AdmissionType] PRIMARY KEY CLUSTERED 
(
	[AdmisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryEng] [varchar](50) NOT NULL,
	[CategoryArb] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cities](
	[CountryID] [int] NOT NULL,
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityEng] [varchar](50) NOT NULL,
	[CityArb] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryEng] [varchar](50) NULL,
	[CountryArb] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Countries] UNIQUE NONCLUSTERED 
(
	[CountryEng] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Degrees](
	[DegreeID] [int] IDENTITY(1,1) NOT NULL,
	[DegreeEng] [varchar](50) NOT NULL,
	[DegreeArb] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Degrees] PRIMARY KEY CLUSTERED 
(
	[DegreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Diciplines]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diciplines](
	[DiciID] [int] IDENTITY(1,1) NOT NULL,
	[DiciplineEng] [varchar](50) NOT NULL,
	[DiciplineArb] [nvarchar](50) NOT NULL,
	[CatID] [int] NOT NULL,
 CONSTRAINT [PK_Diciplines] PRIMARY KEY CLUSTERED 
(
	[DiciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyID] [bigint] IDENTITY(1,1) NOT NULL,
	[FacultyEng] [varchar](100) NOT NULL,
	[FacultyArb] [nvarchar](100) NOT NULL,
	[AboutEng] [varchar](700) NULL,
	[AboutArb] [nvarchar](700) NULL,
	[logo] [varbinary](max) NULL,
	[City] [int] NOT NULL,
	[Location] [geography] NULL,
	[CreateDate] [date] NULL,
	[FacultyURL] [varchar](50) NULL,
	[AdmissionType] [int] NOT NULL,
	[Hybird] [int] NOT NULL,
	[UniversityID] [int] NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacultyComments]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacultyComments](
	[CommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[FacultyID] [bigint] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_FacultyComments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hybird]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hybird](
	[HybirdID] [int] IDENTITY(1,1) NOT NULL,
	[HybirdEng] [varchar](10) NOT NULL,
	[HybirdArb] [nvarchar](10) NULL,
 CONSTRAINT [PK_Hybird] PRIMARY KEY CLUSTERED 
(
	[HybirdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProgramComments]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProgramComments](
	[CommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProgramID] [bigint] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_ProgramComments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProgramDicipline]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramDicipline](
	[ProgramID] [bigint] NOT NULL,
	[DiciplineID] [int] NOT NULL,
 CONSTRAINT [PK_ProgramDicipline] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC,
	[DiciplineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Programs]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Programs](
	[ProgramID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProgramEng] [varchar](100) NOT NULL,
	[ProgramArb] [nvarchar](100) NOT NULL,
	[AboutEng] [varchar](700) NULL,
	[AboutArb] [nvarchar](700) NULL,
	[Period] [decimal](5, 2) NOT NULL,
	[Semesters] [int] NOT NULL,
	[ProgramURL] [varchar](50) NULL,
	[FacultyID] [bigint] NOT NULL,
	[DegreeID] [int] NOT NULL,
 CONSTRAINT [PK_Programs] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Universities]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Universities](
	[UniveristyID] [int] IDENTITY(1,1) NOT NULL,
	[UniversityEng] [varchar](100) NOT NULL,
	[UniversityArb] [nvarchar](100) NOT NULL,
	[AboutUniversityEng] [varchar](700) NULL,
	[AboutUniversityArb] [nvarchar](700) NULL,
	[City] [int] NOT NULL,
	[Location] [geography] NULL,
	[logo] [varbinary](max) NULL,
	[CreatedDate] [date] NULL,
	[UniversityURL] [varchar](50) NULL,
	[GlobalRank] [int] NULL,
	[ContinetRank] [int] NULL,
	[RegionalRank] [int] NULL,
	[LocalRank] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[UniveristyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UniversityComments]    Script Date: 4/15/2015 12:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UniversityComments](
	[CommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[UniveristyID] [int] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[userID] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_UniversityComments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FacultyComments] ADD  CONSTRAINT [DF_FacultyComments_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[ProgramComments] ADD  CONSTRAINT [DF_ProgramComments_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[UniversityComments] ADD  CONSTRAINT [DF_UniversityComments_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
ALTER TABLE [dbo].[Diciplines]  WITH CHECK ADD  CONSTRAINT [FK_Diciplines_Categories] FOREIGN KEY([CatID])
REFERENCES [dbo].[Categories] ([CatID])
GO
ALTER TABLE [dbo].[Diciplines] CHECK CONSTRAINT [FK_Diciplines_Categories]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_AdmissionType] FOREIGN KEY([AdmissionType])
REFERENCES [dbo].[AdmissionType] ([AdmisionID])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_AdmissionType]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Cities] FOREIGN KEY([City])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Cities]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Hybird] FOREIGN KEY([Hybird])
REFERENCES [dbo].[Hybird] ([HybirdID])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Hybird]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Universities] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[Universities] ([UniveristyID])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Universities]
GO
ALTER TABLE [dbo].[FacultyComments]  WITH CHECK ADD  CONSTRAINT [FK_FacultyComments_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([FacultyID])
GO
ALTER TABLE [dbo].[FacultyComments] CHECK CONSTRAINT [FK_FacultyComments_Faculties]
GO
ALTER TABLE [dbo].[ProgramComments]  WITH CHECK ADD  CONSTRAINT [FK_ProgramComments_Programs] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Programs] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramComments] CHECK CONSTRAINT [FK_ProgramComments_Programs]
GO
ALTER TABLE [dbo].[ProgramDicipline]  WITH CHECK ADD  CONSTRAINT [FK_ProgramDicipline_Diciplines] FOREIGN KEY([DiciplineID])
REFERENCES [dbo].[Diciplines] ([DiciID])
GO
ALTER TABLE [dbo].[ProgramDicipline] CHECK CONSTRAINT [FK_ProgramDicipline_Diciplines]
GO
ALTER TABLE [dbo].[ProgramDicipline]  WITH CHECK ADD  CONSTRAINT [FK_ProgramDicipline_Programs] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Programs] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramDicipline] CHECK CONSTRAINT [FK_ProgramDicipline_Programs]
GO
ALTER TABLE [dbo].[Programs]  WITH CHECK ADD  CONSTRAINT [FK_Programs_Degrees] FOREIGN KEY([DegreeID])
REFERENCES [dbo].[Degrees] ([DegreeID])
GO
ALTER TABLE [dbo].[Programs] CHECK CONSTRAINT [FK_Programs_Degrees]
GO
ALTER TABLE [dbo].[Programs]  WITH CHECK ADD  CONSTRAINT [FK_Programs_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([FacultyID])
GO
ALTER TABLE [dbo].[Programs] CHECK CONSTRAINT [FK_Programs_Faculties]
GO
ALTER TABLE [dbo].[Universities]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Cities] FOREIGN KEY([City])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[Universities] CHECK CONSTRAINT [FK_Table_1_Cities]
GO
ALTER TABLE [dbo].[UniversityComments]  WITH CHECK ADD  CONSTRAINT [FK_UniversityComments_Universities] FOREIGN KEY([UniveristyID])
REFERENCES [dbo].[Universities] ([UniveristyID])
GO
ALTER TABLE [dbo].[UniversityComments] CHECK CONSTRAINT [FK_UniversityComments_Universities]
GO
USE [master]
GO
ALTER DATABASE [UniGuide] SET  READ_WRITE 
GO
