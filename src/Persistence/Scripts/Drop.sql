/***** this query will drop a table (in this instance, 'Users') from the 'JAScheduler' database *****/

USE [JAScheduler]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2/14/2023 11:25:40 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

/***** this query will drop a table (in this instance, 'Roles') from the 'JAScheduler' database *****/

USE [JAScheduler]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 2/14/2023 11:26:22 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO