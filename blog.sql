/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2019 (15.0.2000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2019
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [Blog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Text] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[src] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[alt] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTags]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTags](
	[PostId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PostTags] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Content] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UseCaseName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Data] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Actor] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastName] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirstName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCase]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 01/07/2020 16:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifidedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[PostId] [int] NOT NULL,
	[Mark] [int] NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200628231247_Start', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200701010634_LastOne', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200701020953_LastOneThis', N'3.1.5')
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 1, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 2, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 3, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 4, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (21, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (22, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (23, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (24, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tralala', 5, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Text], [PostId], [UserId]) VALUES (25, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Trata', 5, 3)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Pictures] ON 

INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src1.jpg', N'Alfa_romeo1', 1)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src2.jpg', N'Alfa_romeo2', 2)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src3.jpg', N'Alfa_romeo3', 3)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src4.jpg', N'Alfa_romeo4', 4)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src5.jpg', N'Alfa_romeo5', 5)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src6.jpg', N'Alfa_romeo6', 6)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src7.jpg', N'Alfa_romeo7', 7)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src8.jpg', N'Alfa_romeo8', 8)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src9.jpg', N'Alfa_romeo9', 9)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src10.jpg', N'Alfa_romeo10', 10)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src11.jpg', N'Alfa_romeo11', 11)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src12.jpg', N'Alfa_romeo12', 12)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src13.jpg', N'Alfa_romeo13', 13)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src14.jpg', N'Alfa_romeo14', 14)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src15.jpg', N'Alfa_romeo15', 15)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src16.jpg', N'Alfa_romeo16', 16)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src17.jpg', N'Alfa_romeo17', 17)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src18.jpg', N'Alfa_romeo18', 18)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src19.jpg', N'Alfa_romeo19', 19)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/src20c.jpg', N'Alfa_romeo20', 20)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [src], [alt], [PostId]) VALUES (21, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'images/srcc.jpg', N'Alfa_romeo21', 20)
SET IDENTITY_INSERT [dbo].[Pictures] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo1', N'Alfa Romeo 145 QV1', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo2', N'Alfa Romeo 145 QV2', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo3', N'Alfa Romeo 145 QV3', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo4', N'Alfa Romeo 145 QV4', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo5', N'Alfa Romeo 145 QV5', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo6', N'Alfa Romeo 145 QV6', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo7', N'Alfa Romeo 145 QV7', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo8', N'Alfa Romeo 145 QV8', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo9', N'Alfa Romeo 145 QV9', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo10', N'Alfa Romeo 145 QV10', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo11', N'Alfa Romeo 145 QV11', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo12', N'Alfa Romeo 145 QV12', 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo13', N'Alfa Romeo 145 QV13', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo14', N'Alfa Romeo 145 QV14', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo15', N'Alfa Romeo 145 QV15', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo16', N'Alfa Romeo 145 QV16', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo17', N'Alfa Romeo 145 QV17', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo18', N'Alfa Romeo 145 QV18', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo19', N'Alfa Romeo 145 QV19', 3)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Name], [Description], [UserId]) VALUES (20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Alfa Romeo20', N'Alfa Romeo 145 QV20', 3)
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (1, 1, 1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (1, 1, 2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (2, 2, 3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (3, 4, 4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (4, 5, 5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (5, 6, 6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (6, 7, 7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (7, 8, 8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (8, 9, 9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (9, 10, 10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (10, 11, 11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (11, 12, 12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (12, 13, 13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (13, 14, 14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (14, 15, 15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (15, 16, 16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (16, 17, 17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (17, 18, 18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (18, 19, 19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (19, 20, 20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (20, 21, 21, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[PostTags] ([PostId], [TagId], [Id], [CreatedAt], [ModifidedAt], [IsDeleted]) VALUES (2, 2, 22, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars1')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars2')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars3')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars4')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars5')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars6')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars7')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars8')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars9')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars10')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars11')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars12')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars13')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars14')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars15')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars16')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars17')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars18')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars19')
INSERT [dbo].[Tag] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [Content]) VALUES (20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-03T00:00:00.0000000' AS DateTime2), 0, N'Cars20')
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (2, CAST(N'2020-07-01T14:00:42.6933896' AS DateTime2), N'Get One Post', N'1', N'Anonymus')
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [LastName], [UserName], [FirstName], [Email], [Password]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Nikolic', N'ZafiwWorm', N'Dusan', N'dndn@gmail.com', N'Sifra123!')
INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [LastName], [UserName], [FirstName], [Email], [Password]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, N'Tastar', N'Cien', N'Bok', N'luk@gmail.com', N'Sifra123!')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUseCase] ON 

INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 1)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (2, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 2)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (3, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 3)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (4, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 4)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (5, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 5)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (6, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 6)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (7, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 7)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (8, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 8)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (9, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 9)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (10, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 10)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (11, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 11)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (12, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 12)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (13, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 13)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (14, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 14)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (15, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 15)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (16, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 16)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (17, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 17)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (18, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 18)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (19, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 19)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (20, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 20)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (21, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 21)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (22, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 22)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (23, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 23)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (24, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 24)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (25, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 25)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (26, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 26)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (27, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 2, 33)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (28, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 1)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (29, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 2)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (30, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 3)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (31, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 4)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (32, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 5)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (33, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 6)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (34, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 7)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (35, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 8)
INSERT [dbo].[UserUseCase] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [UserId], [UseCaseId]) VALUES (36, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 3, 9)
SET IDENTITY_INSERT [dbo].[UserUseCase] OFF
GO
SET IDENTITY_INSERT [dbo].[Votes] ON 

INSERT [dbo].[Votes] ([Id], [CreatedAt], [ModifidedAt], [IsDeleted], [PostId], [Mark]) VALUES (1, CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 5)
SET IDENTITY_INSERT [dbo].[Votes] OFF
GO
/****** Object:  Index [IX_Comments_PostId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_PostId] ON [dbo].[Comments]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pictures_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pictures_Id] ON [dbo].[Pictures]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pictures_PostId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Pictures_PostId] ON [dbo].[Pictures]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Posts_Id] ON [dbo].[Posts]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PostTags_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PostTags_Id] ON [dbo].[PostTags]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PostTags_TagId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_PostTags_TagId] ON [dbo].[PostTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UseCaseLogs_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UseCaseLogs_Id] ON [dbo].[UseCaseLogs]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Id] ON [dbo].[Users]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_UserName]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCase_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserUseCase_Id] ON [dbo].[UserUseCase]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCase_UserId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_UserUseCase_UserId] ON [dbo].[UserUseCase]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Votes_Id]    Script Date: 01/07/2020 16:02:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Votes_Id] ON [dbo].[Votes]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Votes_PostId]    Script Date: 01/07/2020 16:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Votes_PostId] ON [dbo].[Votes]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pictures] ADD  CONSTRAINT [DF__Pictures__Create__300424B4]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Pictures] ADD  CONSTRAINT [DF__Pictures__IsDele__30F848ED]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__CreatedAt__267ABA7A]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__IsDeleted__276EDEB3]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__UserId__48CFD27E]  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[PostTags] ADD  CONSTRAINT [DF__PostTags__Create__34C8D9D1]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[PostTags] ADD  CONSTRAINT [DF__PostTags__IsDele__35BCFE0A]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF__Tag__CreatedAt__2A4B4B5E]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF__Tag__IsDeleted__2B3F6F97]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UseCaseLogs] ADD  CONSTRAINT [DF__UseCaseLog__Date__5070F446]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreatedAt__3A81B327]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__IsDeleted__3B75D760]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Email__46E78A0C]  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Password__47DBAE45]  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[UserUseCase] ADD  CONSTRAINT [DF__UserUseCa__Creat__4BAC3F29]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserUseCase] ADD  CONSTRAINT [DF__UserUseCa__IsDel__4CA06362]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Votes] ADD  CONSTRAINT [DF__Votes__CreatedAt__45F365D3]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Votes] ADD  CONSTRAINT [DF__Votes__IsDeleted__44FF419A]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_PostId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Posts_PostId]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTags_Posts_PostId]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Tag_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTags_Tag_TagId]
GO
ALTER TABLE [dbo].[UserUseCase]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCase_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCase] CHECK CONSTRAINT [FK_UserUseCase_Users_UserId]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_Posts_PostId]
GO
