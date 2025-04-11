USE [master]
GO
/****** Object:  Database [BiddingManagementDB]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE DATABASE [BiddingManagementDB] ON  PRIMARY 
( NAME = N'BiddingManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BiddingManagementDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BiddingManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BiddingManagementDB_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BiddingManagementDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BiddingManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BiddingManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BiddingManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BiddingManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BiddingManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BiddingManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BiddingManagementDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BiddingManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BiddingManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BiddingManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [BiddingManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BiddingManagementDB] SET DB_CHAINING OFF 
GO
USE [BiddingManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BidDocuments]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BidDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BidId] [int] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[UploadedAt] [datetime2](7) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_BidDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bids]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bids](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenderId] [int] NOT NULL,
	[BidderId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[SubmittedAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Bids] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluations]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BidId] [int] NOT NULL,
	[EvaluatorId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Evaluations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[DateSent] [datetime2](7) NOT NULL,
	[IsRead] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenderDocuments]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenderDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenderId] [int] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[UploadedAt] [datetime2](7) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TenderDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenders]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[Budget] [decimal](18, 2) NULL,
	[Category] [nvarchar](max) NOT NULL,
	[ProcurementOfficerId] [int] NULL,
	[IssueDate] [datetime2](7) NULL,
	[TenderType] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[ContactEmail] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Tenders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/11/2025 10:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_BidDocuments_BidId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_BidDocuments_BidId] ON [dbo].[BidDocuments]
(
	[BidId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bids_BidderId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bids_BidderId] ON [dbo].[Bids]
(
	[BidderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bids_TenderId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bids_TenderId] ON [dbo].[Bids]
(
	[TenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Evaluations_BidId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Evaluations_BidId] ON [dbo].[Evaluations]
(
	[BidId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Evaluations_EvaluatorId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Evaluations_EvaluatorId] ON [dbo].[Evaluations]
(
	[EvaluatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notifications_UserId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_UserId] ON [dbo].[Notifications]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TenderDocuments_TenderId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_TenderDocuments_TenderId] ON [dbo].[TenderDocuments]
(
	[TenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tenders_ProcurementOfficerId]    Script Date: 4/11/2025 10:58:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tenders_ProcurementOfficerId] ON [dbo].[Tenders]
(
	[ProcurementOfficerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BidDocuments]  WITH CHECK ADD  CONSTRAINT [FK_BidDocuments_Bids_BidId] FOREIGN KEY([BidId])
REFERENCES [dbo].[Bids] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BidDocuments] CHECK CONSTRAINT [FK_BidDocuments_Bids_BidId]
GO
ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_Tenders_TenderId] FOREIGN KEY([TenderId])
REFERENCES [dbo].[Tenders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_Tenders_TenderId]
GO
ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_Users_BidderId] FOREIGN KEY([BidderId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_Users_BidderId]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Bids_BidId] FOREIGN KEY([BidId])
REFERENCES [dbo].[Bids] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Bids_BidId]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Users_EvaluatorId] FOREIGN KEY([EvaluatorId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Users_EvaluatorId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users_UserId]
GO
ALTER TABLE [dbo].[TenderDocuments]  WITH CHECK ADD  CONSTRAINT [FK_TenderDocuments_Tenders_TenderId] FOREIGN KEY([TenderId])
REFERENCES [dbo].[Tenders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TenderDocuments] CHECK CONSTRAINT [FK_TenderDocuments_Tenders_TenderId]
GO
ALTER TABLE [dbo].[Tenders]  WITH CHECK ADD  CONSTRAINT [FK_Tenders_Users_ProcurementOfficerId] FOREIGN KEY([ProcurementOfficerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tenders] CHECK CONSTRAINT [FK_Tenders_Users_ProcurementOfficerId]
GO
USE [master]
GO
ALTER DATABASE [BiddingManagementDB] SET  READ_WRITE 
GO
