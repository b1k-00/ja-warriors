
/****** Object:  Table [dbo].[UserAvailabilities]    Script Date: 3/14/2023 11:17:47 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserAvailabilities]') AND type in (N'U'))
DROP TABLE [dbo].[UserAvailabilities]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/14/2023 11:18:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[DesignStudios]    Script Date: 3/14/2023 11:41:16 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesignStudios]') AND type in (N'U'))
DROP TABLE [dbo].[DesignStudios]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/14/2023 11:22:24 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 3/14/2023 11:22:40 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Regions]') AND type in (N'U'))
DROP TABLE [dbo].[Regions]
GO
USE [JAScheduler]
GO
/****** Object:  Table [dbo].[Availabilities]    Script Date: 3/14/2023 11:04:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Availabilities]') AND type in (N'U'))
DROP TABLE [dbo].[Availabilities]
GO