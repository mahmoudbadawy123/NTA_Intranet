USE [master]
GO
/****** Object:  Database [NTA_TASK]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE DATABASE [NTA_TASK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NTA_TASK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NTA_TASK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NTA_TASK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NTA_TASK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NTA_TASK] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NTA_TASK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NTA_TASK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NTA_TASK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NTA_TASK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NTA_TASK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NTA_TASK] SET ARITHABORT OFF 
GO
ALTER DATABASE [NTA_TASK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NTA_TASK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NTA_TASK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NTA_TASK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NTA_TASK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NTA_TASK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NTA_TASK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NTA_TASK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NTA_TASK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NTA_TASK] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NTA_TASK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NTA_TASK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NTA_TASK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NTA_TASK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NTA_TASK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NTA_TASK] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NTA_TASK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NTA_TASK] SET RECOVERY FULL 
GO
ALTER DATABASE [NTA_TASK] SET  MULTI_USER 
GO
ALTER DATABASE [NTA_TASK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NTA_TASK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NTA_TASK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NTA_TASK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NTA_TASK] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NTA_TASK', N'ON'
GO
ALTER DATABASE [NTA_TASK] SET QUERY_STORE = OFF
GO
USE [NTA_TASK]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NTA_TASK]
GO
/****** Object:  Schema [security]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE SCHEMA [security]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [dbo].[Announcements]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [dbo].[CalenderEvents]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [dbo].[MeetingTypes]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [dbo].[Storys]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [dbo].[Systems]    Script Date: 09/10/2022 10:08:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Systems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[EmployeeUserId] [nvarchar](450) NOT NULL,
	[isScheduledPublish] [bit] NULL,
	[PublishDateTime] [datetime2](7) NULL,
	[InsertUserDate] [datetime2](7) NULL,
	[UpdateUserDate] [datetime2](7) NULL,
	[InsertUserId] [nvarchar](450) NULL,
	[UpdateUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Systems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[RoleClaims]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[Roles]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[UserClaims]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[UserLogins]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[UserRoles]    Script Date: 09/10/2022 10:08:13 م ******/
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
/****** Object:  Table [security].[Users]    Script Date: 09/10/2022 10:08:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [security].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[GroupId] [int] NULL,
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
	[FullName] [nvarchar](100) NOT NULL,
	[IsFirstlogin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [security].[UserTokens]    Script Date: 09/10/2022 10:08:13 م ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930151400_MyFirstMigration', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930153534_EditGroupDatatype', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930183907_SeedingRolesMigration', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930183940_SeedingRolesMigration_V1', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930185051_SeedingGroupsMigration_V1', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930192445_SeedingGroupsMigration_V2', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930192959_SeedingGroupsMigration_V3', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930193130_DescriptionNullnGroups_V3', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930195649_AddFullNametoUser', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221001072659_addIsFirstlogincolumn', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221001160838_seedingGroups', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221001181905_AddTableAnnouncements', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221007090933_AddTableStorys', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221007154341_AddCalenderEventsTable', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008093730_AddMeetingTypesTable', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008093928_seedingMeetingTypesTable', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008131123_editMeetingTypesTable', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008152413_editMeetingTypesTable_1', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008172423_AddSystemsTable', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008195506_EditMettingTable_v1', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008223158_EditMettingTable_v2', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008223514_EditMettingTable_v3', N'6.0.9')
SET IDENTITY_INSERT [dbo].[Announcements] ON 

INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (1, N'Announcement 1', N'Nulla est. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Curabitur bibendum justo non orci. Integer in sapien. Pellentesque arcu. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Etiam dui sem, fermentum vitae, sagittis id, malesuada in, quam. In enim a arcu imperdiet malesuada. Aenean id metus id velit ullamcorper pulvinar. Nulla non lectus sed nisl molestie malesuada. Nulla non arcu lacinia neque faucibus fringilla. Aenean id metus id velit ullamcorper pulvinar. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Etiam ligula pede, sagittis quis, interdum ultricies, scelerisque eu. Proin in tellus sit amet nibh dignissim sagittis. Maecenas aliquet accumsan leo. Integer malesuada. Cras pede libero, dapibus nec, pretium sit amet, tempor quis.', 3, 1, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T00:01:01.1927919' AS DateTime2), CAST(N'2022-10-07T00:11:44.8786753' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (2, N'Announcement 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Maecenas ipsum velit, consectetuer eu lobortis ut, dictum at dui. Phasellus et lorem id felis nonummy placerat. Morbi leo mi, nonummy eget tristique non, rhoncus non leo. Etiam dictum tincidunt diam. Fusce consectetuer risus a nunc. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Duis pulvinar. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Morbi scelerisque luctus velit. Aliquam erat volutpat. Praesent dapibus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Aliquam erat volutpat. Etiam commodo dui eget wisi. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.', 3, 0, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T00:22:38.1071883' AS DateTime2), CAST(N'2022-10-07T00:11:20.5831042' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (3, N'Announcement 3', N'Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Etiam neque. Nulla pulvinar eleifend sem. Nullam at arcu a est sollicitudin euismod. In laoreet, magna id viverra tincidunt, sem odio bibendum justo, vel imperdiet sapien wisi sed libero. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam bibendum elit eget erat. Etiam dui sem, fermentum vitae, sagittis id, malesuada in, quam. In rutrum. Etiam egestas wisi a erat. Nulla non lectus sed nisl molestie malesuada.', 2, 0, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T23:14:12.2926489' AS DateTime2), CAST(N'2022-10-07T00:11:30.8834631' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (4, N'Announcement 4', N'Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Nulla accumsan, elit sit amet varius semper, nulla mauris mollis quam, tempor suscipit diam nulla vel leo. Nunc dapibus tortor vel mi dapibus sollicitudin. Duis bibendum, lectus ut viverra rhoncus, dolor nunc faucibus libero, eget facilisis enim ipsum id lacus. Aliquam erat volutpat. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Fusce nibh. Etiam neque. Aliquam erat volutpat. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Nam sed tellus id magna elementum tincidunt. Nunc tincidunt ante vitae massa. Duis pulvinar. In dapibus augue non sapien. Fusce wisi.', 4, 1, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T23:42:05.9752155' AS DateTime2), CAST(N'2022-10-07T00:10:59.1385083' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (5, N'Announcement 5', N'Nullam dapibus fermentum ipsum. Vivamus luctus egestas leo. Aliquam in lorem sit amet leo accumsan lacinia. Curabitur ligula sapien, pulvinar a vestibulum quis, facilisis vel sapien. Vivamus luctus egestas leo. Nullam rhoncus aliquam metus. Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Duis condimentum augue id magna semper rutrum. Curabitur vitae diam non enim vestibulum interdum. Aliquam in lorem sit amet leo accumsan lacinia. Pellentesque sapien. Fusce aliquam vestibulum ipsum.', 4, 1, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T23:49:31.4650185' AS DateTime2), CAST(N'2022-10-07T00:10:42.9583587' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (6, N'Announcement 6', N'Etiam dictum tincidunt diam. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Duis bibendum, lectus ut viverra rhoncus, dolor nunc faucibus libero, eget facilisis enim ipsum id lacus. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer imperdiet lectus quis justo. Integer lacinia. Mauris elementum mauris vitae tortor. Morbi scelerisque luctus velit. Mauris dictum facilisis augue. Nam quis nulla. Maecenas ipsum velit, consectetuer eu lobortis ut, dictum at dui. Quisque tincidunt scelerisque libero. Nullam sapien sem, ornare ac, nonummy non, lobortis a enim. Maecenas aliquet accumsan leo. Aenean id metus id velit ullamcorper pulvinar. Vivamus porttitor turpis ac leo.', 4, 1, CAST(N'2022-10-04T22:37:47.0000000' AS DateTime2), CAST(N'2022-10-04T23:49:54.4679865' AS DateTime2), CAST(N'2022-10-07T00:10:31.6288037' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (7, N'Announcement 7', N'Aliquam ante. Etiam dictum tincidunt diam. Praesent in mauris eu tortor porttitor accumsan. Integer tempor. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Fusce nibh. Integer lacinia. Integer pellentesque quam vel velit. Nulla quis diam. Aliquam erat volutpat. Fusce aliquam vestibulum ipsum.', 4, 1, CAST(N'2022-10-20T23:03:07.0000000' AS DateTime2), CAST(N'2022-10-04T23:51:02.7782223' AS DateTime2), CAST(N'2022-10-07T00:10:16.9740739' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (35, N'Announcement 8', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. In laoreet, magna id viverra tincidunt, sem odio bibendum justo, vel imperdiet sapien wisi sed libero. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Nulla pulvinar eleifend sem. Nam sed tellus id magna elementum tincidunt. Etiam egestas wisi a erat. Nulla non arcu lacinia neque faucibus fringilla. Maecenas aliquet accumsan leo. Nullam faucibus mi quis velit. Donec vitae arcu. Vestibulum fermentum tortor id mi. Aliquam erat volutpat. Pellentesque ipsum. In enim a arcu imperdiet malesuada. Etiam dictum tincidunt diam.', 2, 1, CAST(N'2022-10-07T00:05:31.0000000' AS DateTime2), CAST(N'2022-10-07T00:00:45.8321499' AS DateTime2), CAST(N'2022-10-07T00:09:42.5352456' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (37, N'Announcement 9', N'Hmm I was investigating the issue a bit some more. It seems our types are wrong since how I did in the stackblitz. The warning is being displayed only if we put the ? and the type of b is only as array (updated description).Hmm I was investigating the issue a bit some more. It seems our types are wrong since how I did in the stackblitz. The warning is being displayed only if we put the ? and the type of b is only as array (updated description).', 2, 1, CAST(N'2022-10-07T08:06:53.0000000' AS DateTime2), CAST(N'2022-10-07T00:07:26.3585824' AS DateTime2), CAST(N'2022-10-08T19:43:21.1635431' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Announcements] ([Id], [LabelName], [MessageBody], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (43, N'dfddf', N'dfdfxxxxxxxx', 1, 1, CAST(N'2022-10-08T19:50:00.0000000' AS DateTime2), CAST(N'2022-10-08T19:43:46.4202184' AS DateTime2), CAST(N'2022-10-08T19:46:20.3938822' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
SET IDENTITY_INSERT [dbo].[Announcements] OFF
SET IDENTITY_INSERT [dbo].[CalenderEvents] ON 

INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (1, N'Event 1', N'Event 1 Event 1 Event 1 Event 1', 1, CAST(N'2022-10-07T20:54:04.0000000' AS DateTime2), CAST(N'2022-10-07T20:54:15.8270574' AS DateTime2), CAST(N'2022-10-07T23:05:03.6317176' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (2, N'Event 4', N'ssssssssssssssssssssssssssssssss', 1, CAST(N'2022-10-08T21:33:15.0000000' AS DateTime2), CAST(N'2022-10-07T21:33:27.4114796' AS DateTime2), CAST(N'2022-10-07T22:15:14.5492666' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (4, N'Event 5', N'Event', 1, CAST(N'2022-10-15T22:02:34.0000000' AS DateTime2), CAST(N'2022-10-07T22:02:53.4358123' AS DateTime2), CAST(N'2022-10-07T22:15:23.2882957' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (6, N'Event 6', N'Event 6', 1, CAST(N'2022-10-15T22:04:42.0000000' AS DateTime2), CAST(N'2022-10-07T22:04:56.1341112' AS DateTime2), CAST(N'2022-10-07T22:15:31.8403939' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (7, N'event 2', N'sssssssssssssssssss', 2, CAST(N'2022-10-07T22:13:00.0000000' AS DateTime2), CAST(N'2022-10-07T22:13:09.5309119' AS DateTime2), CAST(N'2022-10-07T22:14:00.4062326' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (8, N'event 3', N'3', 4, CAST(N'2022-10-07T22:13:12.0000000' AS DateTime2), CAST(N'2022-10-07T22:13:34.8207261' AS DateTime2), CAST(N'2022-10-07T22:14:08.6158923' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (11, N'Event 7', N'Event 7 Event 7 Event 7', 4, CAST(N'2022-10-12T06:05:23.0000000' AS DateTime2), CAST(N'2022-10-07T23:05:38.1166819' AS DateTime2), CAST(N'2022-10-08T02:53:25.7420008' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[CalenderEvents] ([Id], [EventName], [Description], [GroupId], [EventDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (12, N'Event 8', N' Event 8 Event 8 Event 8', 1, CAST(N'2022-10-21T18:00:00.0000000' AS DateTime2), CAST(N'2022-10-07T23:16:42.1806265' AS DateTime2), CAST(N'2022-10-07T23:18:21.0335529' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
SET IDENTITY_INSERT [dbo].[CalenderEvents] OFF
SET IDENTITY_INSERT [dbo].[MeetingTypes] ON 

INSERT [dbo].[MeetingTypes] ([Id], [Name], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (1, N'Internal Meeting (NTA)', NULL, NULL, NULL, NULL)
INSERT [dbo].[MeetingTypes] ([Id], [Name], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (2, N'External Meeting', NULL, NULL, NULL, NULL)
INSERT [dbo].[MeetingTypes] ([Id], [Name], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (3, N'Online Meeting', NULL, NULL, NULL, NULL)
INSERT [dbo].[MeetingTypes] ([Id], [Name], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (4, N'Hybird Meeting', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MeetingTypes] OFF
SET IDENTITY_INSERT [dbo].[Storys] ON 

INSERT [dbo].[Storys] ([Id], [Header], [Body], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (1, N'Story 1', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1, 1, CAST(N'2022-10-07T11:20:00.0000000' AS DateTime2), CAST(N'2022-10-07T11:16:09.5694727' AS DateTime2), CAST(N'2022-10-07T11:19:41.3953642' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Storys] ([Id], [Header], [Body], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (2, N'Story 2', N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.', 4, NULL, CAST(N'2022-10-07T11:20:57.0000000' AS DateTime2), CAST(N'2022-10-07T11:21:21.4595978' AS DateTime2), CAST(N'2022-10-07T11:22:18.7823357' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Storys] ([Id], [Header], [Body], [GroupId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (4, N'Story 3', N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.', 1, NULL, CAST(N'2022-10-07T22:56:01.0000000' AS DateTime2), CAST(N'2022-10-07T22:56:13.5396107' AS DateTime2), CAST(N'2022-10-08T02:53:07.4452615' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
SET IDENTITY_INSERT [dbo].[Storys] OFF
SET IDENTITY_INSERT [dbo].[Systems] ON 

INSERT [dbo].[Systems] ([Id], [SystemName], [Link], [EmployeeUserId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (1, N'HRMS', N'http://localhost:5060/api/', N'f8900512-066e-49e5-8dc9-1f719f30dd51', NULL, CAST(N'2022-10-08T19:47:11.0000000' AS DateTime2), CAST(N'2022-10-08T19:50:04.7016276' AS DateTime2), CAST(N'2022-10-08T20:21:57.0973262' AS DateTime2), N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'a07a05b5-8d09-4b44-bf0f-e14033f9df46')
INSERT [dbo].[Systems] ([Id], [SystemName], [Link], [EmployeeUserId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (2, N'Polices & Procedures', N'http://localhost:5070/api', N'f8900512-066e-49e5-8dc9-1f719f30dd51', NULL, CAST(N'2022-10-08T20:18:31.4340000' AS DateTime2), CAST(N'2022-10-08T20:19:11.4995627' AS DateTime2), NULL, N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', NULL)
INSERT [dbo].[Systems] ([Id], [SystemName], [Link], [EmployeeUserId], [isScheduledPublish], [PublishDateTime], [InsertUserDate], [UpdateUserDate], [InsertUserId], [UpdateUserId]) VALUES (3, N'TMS', N'http://localhost:5080/api', N'f8900512-066e-49e5-8dc9-1f719f30dd51', NULL, CAST(N'2022-10-08T20:19:14.6660000' AS DateTime2), CAST(N'2022-10-08T20:19:39.5401347' AS DateTime2), NULL, N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', NULL)
SET IDENTITY_INSERT [dbo].[Systems] OFF
SET IDENTITY_INSERT [dbo].[UserGroups] ON 

INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (1, N'All NTA Employee', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (2, N'Managers', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (3, N'Directors', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (4, N'IT Depertment', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (5, N'HR Depertment', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (6, N'Executive Director Office ', N'Description', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserGroups] ([Id], [Name], [Description], [InsertUserId], [InsertUserDate], [UpdateUserId], [UpdateUserDate]) VALUES (7, N'Finance Depertment ', N'Description', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserGroups] OFF
INSERT [security].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'048c4c5c-ddf8-4d80-b752-20ca656e5b84', N'User', N'USER', N'b00f705f-167c-4323-9730-41e3b14d7c02')
INSERT [security].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1c5a7e17-68dc-480d-b46d-051c7957f84a', N'Admin', N'ADMIN', N'7d689c2b-0ae6-4127-84a1-787490064264')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'2b4d2950-e636-483f-94b4-94366a6c5cb9', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'44c7d974-d2de-40b4-bc39-b850fa256d01', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'5206a243-a6f0-4afb-a2fe-9cad9f762d55', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'8e912ba0-9a46-43de-b2e0-d15a0ad12b56', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'b4a0348b-1ca9-4e24-b471-191b081fa58b', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'f8900512-066e-49e5-8dc9-1f719f30dd51', N'048c4c5c-ddf8-4d80-b752-20ca656e5b84')
INSERT [security].[UserRoles] ([UserId], [RoleId]) VALUES (N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', N'1c5a7e17-68dc-480d-b46d-051c7957f84a')
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'2b4d2950-e636-483f-94b4-94366a6c5cb9', 3, N'Norhan_Osama', N'NORHAN_OSAMA', N'NOsama@NTA.com', N'NOSAMA@NTA.COM', 0, N'AQAAAAEAACcQAAAAEOzTGZzjVDpv+QKG+SsxyHqZn/Fkh+9LN9WFMyLOqGJpzfF3dvl/ry+959DdExQi1g==', N'L5FEMGCE6ZJ7WB3255UWRSORAVVIGPWF', N'1890cb53-3a61-4146-b647-b2d09d8cb0ed', NULL, 0, 0, NULL, 1, 0, N'Norhan Osama', 0)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'44c7d974-d2de-40b4-bc39-b850fa256d01', 2, N'Ahmed_Mourad', N'AHMED_MOURAD', N'AMourad@NTA.com', N'AMOURAD@NTA.COM', 0, N'AQAAAAEAACcQAAAAEJ2dldghSxBBrQMFLisuyii/J+F5mo6YYB9fEJSsDNnf1gZDLMe3bj6xp6nTPrMNrg==', N'F3O7EZ7BL37HMA5ZO7XEPC7CVUP3PP4L', N'a848a523-f35a-4c4b-8bcd-f1008b4f53d8', NULL, 0, 0, NULL, 1, 0, N'Ahmed Mourad', 0)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'5206a243-a6f0-4afb-a2fe-9cad9f762d55', 4, N'Sally_Ahmed', N'SALLY_AHMED', N'SAhmed@NTA.com', N'SAHMED@NTA.COM', 0, N'AQAAAAEAACcQAAAAEKm4wG3iW2ME/OnxJqxrVKpAi26F341N2HB9FnR8nAaoterv8Ck/OKD/4gjyvE4rOQ==', N'DPEOE656VVC77WJCA7NC4C36NOFXRQBN', N'be37fac0-98f2-4107-aaee-093bf1337486', NULL, 0, 0, NULL, 1, 0, N'Sally Ahmed', 0)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'8e912ba0-9a46-43de-b2e0-d15a0ad12b56', 4, N'Magdi_Abass', N'MAGDI_ABASS', N'MAbass@NTA.com', N'MABASS@NTA.COM', 0, N'AQAAAAEAACcQAAAAEPggMxHis/BEeluF02c5qh7YyFzFWNk5DRKkrGWlv2eGxkBNHS3Mda29e/t74qzaLQ==', N'NPXALQ2OZCWP7IQSP3VWEXSHLBZKYA5T', N'778d53ac-f3bb-424f-ab77-fbadff7eb171', NULL, 0, 0, NULL, 1, 0, N'Magdi Abass', 1)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'a07a05b5-8d09-4b44-bf0f-e14033f9df46', NULL, N'ADMIN', N'ADMIN', N'Admin@NTA.com', N'ADMIN@NTA.COM', 0, N'AQAAAAEAACcQAAAAEGYXmDjhfgj3mvKzez1TB7RFw/G+XL4755BH3LpgRY7xZE+nLG0Y+5Rqm6QaMtaN0A==', N'JEGZDXLUOQT2J2PHTDTHS4DXRX5XQAAU', N'630b38f5-d93b-4250-9d02-983c16940fc4', NULL, 0, 0, NULL, 1, 0, N'NTA ADMIN', 1)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'b4a0348b-1ca9-4e24-b471-191b081fa58b', 5, N'Sara_Gendy', N'SARA_GENDY', N'SGendy@NTA.com', N'SGENDY@NTA.COM', 0, N'AQAAAAEAACcQAAAAEO64z0jnYfgBtawzCqiTzsr5+zvzsJD49l7DmZcK1Asci1gyUdVXRNh0QdePv8LTGQ==', N'PQRUANRUOXLLMOZRAG57G7ZAXKMQIB2F', N'ca0fd05b-ea4d-473f-b93e-937bb513b598', NULL, 0, 0, NULL, 1, 0, N'Sara Gendy', 0)
INSERT [security].[Users] ([Id], [GroupId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsFirstlogin]) VALUES (N'f8900512-066e-49e5-8dc9-1f719f30dd51', 2, N'Hassan_Ali', N'HASSAN_ALI', N'hali@NTA.com', N'HALI@NTA.COM', 0, N'AQAAAAEAACcQAAAAEGhKKkJNlNVHas6ObbaQeQiaQV10vQ058UYTMYsH7WptcT1ILclHpggkKbfhQIeXDA==', N'VNIIZDPZYJCKZSIRXB3NRM3S44JAAOZI', N'23643217-dcd8-44d5-a23d-250a56dec859', NULL, 0, 0, NULL, 1, 0, N'Hassan Ali', 1)
/****** Object:  Index [IX_Announcements_GroupId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_GroupId] ON [dbo].[Announcements]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Announcements_InsertUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_InsertUserId] ON [dbo].[Announcements]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Announcements_UpdateUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Announcements_UpdateUserId] ON [dbo].[Announcements]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CalenderEvents_GroupId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_GroupId] ON [dbo].[CalenderEvents]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CalenderEvents_InsertUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_InsertUserId] ON [dbo].[CalenderEvents]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CalenderEvents_UpdateUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_CalenderEvents_UpdateUserId] ON [dbo].[CalenderEvents]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Storys_GroupId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_GroupId] ON [dbo].[Storys]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Storys_InsertUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_InsertUserId] ON [dbo].[Storys]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Storys_UpdateUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Storys_UpdateUserId] ON [dbo].[Storys]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Systems_EmployeeUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Systems_EmployeeUserId] ON [dbo].[Systems]
(
	[EmployeeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Systems_InsertUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Systems_InsertUserId] ON [dbo].[Systems]
(
	[InsertUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Systems_UpdateUserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Systems_UpdateUserId] ON [dbo].[Systems]
(
	[UpdateUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [security].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [security].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [security].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [security].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [security].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [security].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_GroupId]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE NONCLUSTERED INDEX [IX_Users_GroupId] ON [security].[Users]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 09/10/2022 10:08:13 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [security].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [security].[Users] ADD  DEFAULT (N'') FOR [FullName]
GO
ALTER TABLE [security].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsFirstlogin]
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
ALTER TABLE [dbo].[Systems]  WITH CHECK ADD  CONSTRAINT [FK_Systems_Users_EmployeeUserId] FOREIGN KEY([EmployeeUserId])
REFERENCES [security].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Systems] CHECK CONSTRAINT [FK_Systems_Users_EmployeeUserId]
GO
ALTER TABLE [dbo].[Systems]  WITH CHECK ADD  CONSTRAINT [FK_Systems_Users_InsertUserId] FOREIGN KEY([InsertUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Systems] CHECK CONSTRAINT [FK_Systems_Users_InsertUserId]
GO
ALTER TABLE [dbo].[Systems]  WITH CHECK ADD  CONSTRAINT [FK_Systems_Users_UpdateUserId] FOREIGN KEY([UpdateUserId])
REFERENCES [security].[Users] ([Id])
GO
ALTER TABLE [dbo].[Systems] CHECK CONSTRAINT [FK_Systems_Users_UpdateUserId]
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
ALTER DATABASE [NTA_TASK] SET  READ_WRITE 
GO
