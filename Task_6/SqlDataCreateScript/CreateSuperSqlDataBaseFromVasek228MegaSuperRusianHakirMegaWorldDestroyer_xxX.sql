USE [master]
GO
/****** Object:  Database [Colledge]    Script Date: 11.09.2020 2:55:19 ******/
CREATE DATABASE [Colledge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Colledge', FILENAME = N'D:\Programs\SQLServer2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\Colledge.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Colledge_log', FILENAME = N'D:\Programs\SQLServer2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\Colledge_log.ldf' , SIZE = 16384KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Colledge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Colledge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Colledge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Colledge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Colledge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Colledge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Colledge] SET ARITHABORT OFF 
GO
ALTER DATABASE [Colledge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Colledge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Colledge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Colledge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Colledge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Colledge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Colledge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Colledge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Colledge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Colledge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Colledge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Colledge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Colledge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Colledge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Colledge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Colledge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Colledge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Colledge] SET RECOVERY FULL 
GO
ALTER DATABASE [Colledge] SET  MULTI_USER 
GO
ALTER DATABASE [Colledge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Colledge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Colledge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Colledge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Colledge] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Colledge', N'ON'
GO
ALTER DATABASE [Colledge] SET QUERY_STORE = OFF
GO
USE [Colledge]
GO
/****** Object:  Table [dbo].[Credit]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[SubjectId] [int] NULL,
	[DateOfCredit] [date] NULL,
 CONSTRAINT [PK_Credit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditList]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SubjectId] [int] NULL,
	[SessionId] [int] NULL,
	[Passed] [bit] NOT NULL,
 CONSTRAINT [PK_CreditList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[SubjectId] [int] NULL,
	[DateOfExam] [date] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gradebook]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gradebook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SubjectId] [int] NULL,
	[SessionId] [int] NULL,
	[Mark] [int] NOT NULL,
 CONSTRAINT [PK_Gradebook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NOT NULL,
	[LastName] [ntext] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_Student1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 11.09.2020 2:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NULL,
	[Name] [ntext] NOT NULL,
 CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Credit] ON 

INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (2, 3, 3, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (3, 3, 4, CAST(N'2011-11-11' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (4, 3, 5, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (5, 3, 6, CAST(N'2011-11-11' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (6, 4, 7, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (7, 4, 3, CAST(N'2011-11-11' AS Date))
INSERT [dbo].[Credit] ([Id], [GroupId], [SubjectId], [DateOfCredit]) VALUES (8, 4, 5, CAST(N'2010-10-10' AS Date))
SET IDENTITY_INSERT [dbo].[Credit] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditList] ON 

INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (5, 39, 3, 9, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (6, 39, 4, 9, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (7, 39, 5, 12, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (8, 40, 6, 11, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (9, 40, 7, 11, 0)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (10, 41, 3, 9, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (11, 41, 4, 9, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (12, 41, 5, 9, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (13, 42, 6, 13, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (14, 42, 7, 12, 1)
INSERT [dbo].[CreditList] ([Id], [StudentId], [SubjectId], [SessionId], [Passed]) VALUES (15, 42, 3, 13, 0)
SET IDENTITY_INSERT [dbo].[CreditList] OFF
GO
SET IDENTITY_INSERT [dbo].[Exam] ON 

INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (8, 3, 4, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (9, 3, 5, CAST(N'2011-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (10, 3, 6, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (11, 3, 7, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (12, 4, 3, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (13, 4, 4, CAST(N'2011-11-11' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (14, 4, 5, CAST(N'2012-12-12' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (15, 4, 6, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[Exam] ([Id], [GroupId], [SubjectId], [DateOfExam]) VALUES (16, 4, 7, CAST(N'2011-11-11' AS Date))
SET IDENTITY_INSERT [dbo].[Exam] OFF
GO
SET IDENTITY_INSERT [dbo].[Gradebook] ON 

INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (12, 39, 3, 9, 2)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (13, 39, 4, 11, 3)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (14, 39, 5, 12, 2)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (15, 39, 6, 13, 9)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (16, 40, 7, 9, 8)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (17, 40, 3, 11, 9)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (18, 40, 4, 12, 10)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (19, 41, 5, 13, 6)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (20, 41, 6, 9, 7)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (21, 41, 7, 11, 6)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (22, 42, 3, 12, 10)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (23, 42, 4, 13, 3)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (24, 42, 5, 9, 2)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (25, 42, 6, 11, 8)
INSERT [dbo].[Gradebook] ([Id], [StudentId], [SubjectId], [SessionId], [Mark]) VALUES (26, 42, 7, 12, 0)
SET IDENTITY_INSERT [dbo].[Gradebook] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Name]) VALUES (3, N'IP-21')
INSERT [dbo].[Group] ([Id], [Name]) VALUES (4, N'IP-12')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Id], [GroupId], [StartDate], [EndDate]) VALUES (9, 3, CAST(N'2010-05-28' AS Date), CAST(N'2010-06-13' AS Date))
INSERT [dbo].[Session] ([Id], [GroupId], [StartDate], [EndDate]) VALUES (11, 3, CAST(N'2011-05-29' AS Date), CAST(N'2011-06-19' AS Date))
INSERT [dbo].[Session] ([Id], [GroupId], [StartDate], [EndDate]) VALUES (12, 4, CAST(N'2010-05-25' AS Date), CAST(N'2010-06-30' AS Date))
INSERT [dbo].[Session] ([Id], [GroupId], [StartDate], [EndDate]) VALUES (13, 4, CAST(N'2011-05-28' AS Date), CAST(N'2011-06-29' AS Date))
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [LastName], [DateOfBirth], [GroupId]) VALUES (39, N'Pavel', N'Ignatiev', CAST(N'2001-01-01' AS Date), 3)
INSERT [dbo].[Student] ([Id], [Name], [LastName], [DateOfBirth], [GroupId]) VALUES (40, N'Valeriy', N'Vlasov', CAST(N'2001-01-01' AS Date), 3)
INSERT [dbo].[Student] ([Id], [Name], [LastName], [DateOfBirth], [GroupId]) VALUES (41, N'Stas', N'Vasiliev', CAST(N'2002-02-02' AS Date), 4)
INSERT [dbo].[Student] ([Id], [Name], [LastName], [DateOfBirth], [GroupId]) VALUES (42, N'Tanya', N'Liteynaya', CAST(N'2002-02-02' AS Date), 4)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([Id], [Name]) VALUES (3, N'Math')
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (4, N'Language')
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (5, N'Physic')
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (6, N'Russian')
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (7, N'English')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Theme] ON 

INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (5, 3, N'MathTheme1')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (6, 3, N'MathTheme2')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (7, 4, N'LanguageTheme1')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (8, 4, N'LanguageTheme2')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (9, 5, N'PhysicTheme1')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (10, 5, N'PhysicTheme2')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (11, 6, N'RussianTheme1')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (12, 6, N'RussianTheme2')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (13, 7, N'EnglishTheme1')
INSERT [dbo].[Theme] ([Id], [SubjectId], [Name]) VALUES (14, NULL, N'EnglishTheme2')
SET IDENTITY_INSERT [dbo].[Theme] OFF
GO
ALTER TABLE [dbo].[CreditList] ADD  CONSTRAINT [DF_CreditList_Passed]  DEFAULT ((0)) FOR [Passed]
GO
ALTER TABLE [dbo].[Gradebook] ADD  CONSTRAINT [DF_Gradebook_Mark]  DEFAULT ((0)) FOR [Mark]
GO
ALTER TABLE [dbo].[Credit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Credit] CHECK CONSTRAINT [FK_Credit_Group]
GO
ALTER TABLE [dbo].[Credit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Credit] CHECK CONSTRAINT [FK_Credit_Subject]
GO
ALTER TABLE [dbo].[CreditList]  WITH CHECK ADD  CONSTRAINT [FK_CreditList_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([Id])
GO
ALTER TABLE [dbo].[CreditList] CHECK CONSTRAINT [FK_CreditList_Session]
GO
ALTER TABLE [dbo].[CreditList]  WITH CHECK ADD  CONSTRAINT [FK_CreditList_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[CreditList] CHECK CONSTRAINT [FK_CreditList_Student]
GO
ALTER TABLE [dbo].[CreditList]  WITH CHECK ADD  CONSTRAINT [FK_CreditList_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[CreditList] CHECK CONSTRAINT [FK_CreditList_Subject]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Group]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Subject]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_Session]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_Student]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_Subject]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Group]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]
GO
ALTER TABLE [dbo].[Theme]  WITH CHECK ADD  CONSTRAINT [FK_Theme_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Theme] CHECK CONSTRAINT [FK_Theme_Subject]
GO
USE [master]
GO
ALTER DATABASE [Colledge] SET  READ_WRITE 
GO
