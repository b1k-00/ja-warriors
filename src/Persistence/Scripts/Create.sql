﻿/****** this query will create a table called 'Users' on the 'JAScheduler' database *****/

USE [JAScheduler]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2/7/2023 9:36:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](50) NULL,
	[PhoneNumber] [varchar](22) NULL,
	[Graduated] [bit] NULL,
	[GraduatedDate] [date] NULL
) ON [PRIMARY]
GO