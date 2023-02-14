/***** this query will drop a table (in this instance, 'User') from the 'JAScheduler' database *****/

USE [JAScheduler]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2/14/2023 11:25:40 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO

/***** this query will drop a table (in this instance, 'Role') from the 'JAScheduler' database *****/

USE [JAScheduler]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 2/14/2023 11:26:22 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO