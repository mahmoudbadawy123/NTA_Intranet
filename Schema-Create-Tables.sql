USE [master]
GO
/****** Object:  Database [NTA_TASK_V1]    Script Date: 14/10/2022 11:40:56 م ******/
CREATE DATABASE [NTA_TASK_V1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NTA_TASK_V1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NTA_TASK_V1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NTA_TASK_V1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NTA_TASK_V1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NTA_TASK_V1] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NTA_TASK_V1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NTA_TASK_V1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET ARITHABORT OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NTA_TASK_V1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NTA_TASK_V1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NTA_TASK_V1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NTA_TASK_V1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NTA_TASK_V1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET RECOVERY FULL 
GO
ALTER DATABASE [NTA_TASK_V1] SET  MULTI_USER 
GO
ALTER DATABASE [NTA_TASK_V1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NTA_TASK_V1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NTA_TASK_V1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NTA_TASK_V1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NTA_TASK_V1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NTA_TASK_V1', N'ON'
GO
ALTER DATABASE [NTA_TASK_V1] SET QUERY_STORE = OFF
GO
USE [NTA_TASK_V1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NTA_TASK_V1]
GO
/****** Object:  Schema [security]    Script Date: 14/10/2022 11:40:56 م ******/
CREATE SCHEMA [security]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/10/2022 11:40:56 م ******/
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
/****** Object:  Table [dbo].[Announcements]    Script Date: 14/10/2022 11:40:56 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LabelName] [nvarchar](max) NOT NULL,
	[MessageBody] [nvarchar](max) NOT NULL,
	[GroupId] [int] NULL,
	[isScheduledPublish] [bit] NULL,
	[PublishDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Announcements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserMeetings]    Script Date: 14/10/2022 11:40:56 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserMeetings](
	[MeetingId] [int] NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ApplicationUserMeetings] PRIMARY KEY CLUSTERED 
(
	[MeetingId] ASC,
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserRelatedSystems]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserRelatedSystems](
	[RelatedSystemId] [int] NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ApplicationUserRelatedSystems] PRIMARY KEY CLUSTERED 
(
	[RelatedSystemId] ASC,
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalenderEvents]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalenderEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[GroupId] [int] NULL,
	[EventDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_CalenderEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meetings]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meetings](
	[Id] [int] NOT NULL,
	[MeatingName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[MeatingLocation] [nvarchar](max) NULL,
	[MeatingLink] [nvarchar](max) NULL,
	[MeatingDateTime] [datetime2](7) NULL,
	[MeatingTypeId] [int] NULL,
	[isScheduledPublish] [bit] NULL,
	[PublishDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Meetings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingTypes]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserId] [int] NULL,
	[UpdateUserDate] [datetime2](7) NULL,
 CONSTRAINT [PK_MeetingTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedSystems]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedSystems](
	[Id] [int] NOT NULL,
	[SystemName] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[isScheduledPublish] [bit] NULL,
	[PublishDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_RelatedSystems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storys]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[GroupId] [int] NULL,
	[isScheduledPublish] [bit] NULL,
	[PublishDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Storys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[InsertUserId] [int] NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserId] [int] NULL,
	[UpdateUserDate] [datetime2](7) NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[RoleClaims]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[Roles]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserClaims]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserLogins]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserRoles]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [security].[Users]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[GroupId] [int] NULL,
	[IsFirstlogin] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserTokens]    Script Date: 14/10/2022 11:40:57 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Announcements_GroupId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_GroupId] ON [dbo].[Announcements]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Announcements_InsertUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_InsertUserId] ON [dbo].[Announcements]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Announcements_UpdateUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_UpdateUserId] ON [dbo].[Announcements]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUserMeetings_ApplicationUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUserMeetings_ApplicationUserId] ON [dbo].[ApplicationUserMeetings]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUserRelatedSystems_ApplicationUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUserRelatedSystems_ApplicationUserId] ON [dbo].[ApplicationUserRelatedSystems]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CalenderEvents_GroupId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_GroupId] ON [dbo].[CalenderEvents]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CalenderEvents_InsertUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_InsertUserId] ON [dbo].[CalenderEvents]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CalenderEvents_UpdateUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_UpdateUserId] ON [dbo].[CalenderEvents]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Meetings_InsertUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Meetings_InsertUserId] ON [dbo].[Meetings]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meetings_MeatingTypeId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Meetings_MeatingTypeId] ON [dbo].[Meetings]
(
	[MeatingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Meetings_UpdateUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Meetings_UpdateUserId] ON [dbo].[Meetings]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RelatedSystems_InsertUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_RelatedSystems_InsertUserId] ON [dbo].[RelatedSystems]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RelatedSystems_UpdateUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_RelatedSystems_UpdateUserId] ON [dbo].[RelatedSystems]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Storys_GroupId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_GroupId] ON [dbo].[Storys]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Storys_InsertUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_InsertUserId] ON [dbo].[Storys]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Storys_UpdateUserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_UpdateUserId] ON [dbo].[Storys]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [security].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [security].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [security].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [security].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [security].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [security].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_GroupId]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE NONCLUSTERED INDEX [IX_Users_GroupId] ON [security].[Users]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 14/10/2022 11:40:58 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [security].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Announcements]  WITH CHECK ADD  CONSTRAINT [FK_Announcements_UserGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[Announcements] CHECK CONSTRAINT [FK_Announcements_UserGroups_GroupId]
GO
ALTER TABLE [dbo].[Announcements]  WITH CHECK ADD  CONSTRAINT [FK_Announcements_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Announcements] CHECK CONSTRAINT [FK_Announcements_Users_InsertUserId]
GO
ALTER TABLE [dbo].[Announcements]  WITH CHECK ADD  CONSTRAINT [FK_Announcements_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Announcements] CHECK CONSTRAINT [FK_Announcements_Users_UpdateUserId]
GO
ALTER TABLE [dbo].[ApplicationUserMeetings]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserMeetings_Meetings_MeetingId] FOREIGN KEY([MeetingId])
REFERENCES [dbo].[Meetings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserMeetings] CHECK CONSTRAINT [FK_ApplicationUserMeetings_Meetings_MeetingId]
GO
ALTER TABLE [dbo].[ApplicationUserMeetings]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserMeetings_Users_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserMeetings] CHECK CONSTRAINT [FK_ApplicationUserMeetings_Users_ApplicationUserId]
GO
ALTER TABLE [dbo].[ApplicationUserRelatedSystems]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRelatedSystems_RelatedSystems_RelatedSystemId] FOREIGN KEY([RelatedSystemId])
REFERENCES [dbo].[RelatedSystems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserRelatedSystems] CHECK CONSTRAINT [FK_ApplicationUserRelatedSystems_RelatedSystems_RelatedSystemId]
GO
ALTER TABLE [dbo].[ApplicationUserRelatedSystems]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRelatedSystems_Users_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserRelatedSystems] CHECK CONSTRAINT [FK_ApplicationUserRelatedSystems_Users_ApplicationUserId]
GO
ALTER TABLE [dbo].[CalenderEvents]  WITH CHECK ADD  CONSTRAINT [FK_CalenderEvents_UserGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[CalenderEvents] CHECK CONSTRAINT [FK_CalenderEvents_UserGroups_GroupId]
GO
ALTER TABLE [dbo].[CalenderEvents]  WITH CHECK ADD  CONSTRAINT [FK_CalenderEvents_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[CalenderEvents] CHECK CONSTRAINT [FK_CalenderEvents_Users_InsertUserId]
GO
ALTER TABLE [dbo].[CalenderEvents]  WITH CHECK ADD  CONSTRAINT [FK_CalenderEvents_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[CalenderEvents] CHECK CONSTRAINT [FK_CalenderEvents_Users_UpdateUserId]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_MeetingTypes_MeatingTypeId] FOREIGN KEY([MeatingTypeId])
REFERENCES [dbo].[MeetingTypes] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_MeetingTypes_MeatingTypeId]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_Users_InsertUserId]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_Users_UpdateUserId]
GO
ALTER TABLE [dbo].[RelatedSystems]  WITH CHECK ADD  CONSTRAINT [FK_RelatedSystems_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[RelatedSystems] CHECK CONSTRAINT [FK_RelatedSystems_Users_InsertUserId]
GO
ALTER TABLE [dbo].[RelatedSystems]  WITH CHECK ADD  CONSTRAINT [FK_RelatedSystems_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[RelatedSystems] CHECK CONSTRAINT [FK_RelatedSystems_Users_UpdateUserId]
GO
ALTER TABLE [dbo].[Storys]  WITH CHECK ADD  CONSTRAINT [FK_Storys_UserGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[Storys] CHECK CONSTRAINT [FK_Storys_UserGroups_GroupId]
GO
ALTER TABLE [dbo].[Storys]  WITH CHECK ADD  CONSTRAINT [FK_Storys_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Storys] CHECK CONSTRAINT [FK_Storys_Users_InsertUserId]
GO
ALTER TABLE [dbo].[Storys]  WITH CHECK ADD  CONSTRAINT [FK_Storys_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Storys] CHECK CONSTRAINT [FK_Storys_Users_UpdateUserId]
GO
ALTER TABLE [security].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [security].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [security].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [security].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [security].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [security].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [security].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [security].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [security].[Users] CHECK CONSTRAINT [FK_Users_UserGroups_GroupId]
GO
ALTER TABLE [security].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [security].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [NTA_TASK_V1] SET  READ_WRITE 
GO
