-- this query will add a role into the 'Role' table

USE [JAScheduler]
GO

INSERT INTO [dbo].[Role]
           ([Name])
     VALUES
           ('Junior Associate')
GO

-- I will now insert another role

INSERT INTO [dbo].[Role]
           ([Name])
     VALUES
           ('Cohort Leader')
GO

/***** this query will add values to the 'Users' table on the 'JASchedular' database *****/

USE [JAScheduler]
GO

INSERT INTO [dbo].[User]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate]
           ,[RoleId])
     VALUES
           ('John',
           'Arthur',
           'Smith',
           'JS@gmail.com',
           'password',
           '1234567890',
           1,
           '2016-05-16',
           1)
GO


-- below I will be creating another user with 'RoleId' as NULL

USE [JAScheduler]
GO

INSERT INTO [dbo].[User]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate])
     VALUES
           ('Jane',
           'Ataline',
           'Doe',
           'JD@gmail.com',
           'password',
           '0987654321',
           1,
           '1980-12-10')
GO