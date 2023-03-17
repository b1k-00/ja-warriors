USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Availabilities]    Script Date: 3/14/2023 10:16:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availabilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [varchar](500) NULL,
	[EndTime] [varchar](500) NULL,
	[DayOfTheWeek] [int] NULL,
 CONSTRAINT [PK_Availabilities] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 3/14/2023 10:38:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/14/2023 10:39:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[DesignStudios]    Script Date: 3/14/2023 10:32:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignStudios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[RegionId] [int] NULL,
 CONSTRAINT [PK_DesignStudios] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DesignStudios]  WITH CHECK ADD  CONSTRAINT [FK_DesignStudios_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[DesignStudios] CHECK CONSTRAINT [FK_DesignStudios_Regions]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/14/2023 10:41:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](22) NULL,
	[Graduated] [bit] NOT NULL,
	[GraduatedDate] [date] NULL,
	[RoleId] [int] NOT NULL,
	[DesignStudiosId] [int] NOT NULL
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([DesignStudiosId])
REFERENCES [dbo].[DesignStudios] ([Id])
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[UserAvailabilities]    Script Date: 3/14/2023 10:39:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAvailabilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AvailabilityId] [int] NULL,
 CONSTRAINT [PK_UserAvailabilities] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAvailabilities]  WITH CHECK ADD  CONSTRAINT [FK_UserAvailabilities_Availabilities] FOREIGN KEY([AvailabilityId])
REFERENCES [dbo].[Availabilities] ([Id])
GO
ALTER TABLE [dbo].[UserAvailabilities] CHECK CONSTRAINT [FK_UserAvailabilities_Availabilities]
GO
ALTER TABLE [dbo].[UserAvailabilities]  WITH CHECK ADD  CONSTRAINT [FK_UserAvailabilities_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserAvailabilities] CHECK CONSTRAINT [FK_UserAvailabilities_Users]
GO









