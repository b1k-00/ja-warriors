-- Inserts values into the Availabilities table --

INSERT INTO [dbo].[Availabilities]
           ([StartTime]
           ,[EndTime]
           ,[DayOfTheWeek])
     VALUES
           ('1:00 pm'
           ,'2:00 pm'
           ,1)
GO
INSERT INTO [dbo].[Availabilities]
           ([StartTime]
           ,[EndTime]
           ,[DayOfTheWeek])
     VALUES
           ('12:00 pm'
           ,'1:30 pm'
           ,2)
GO
INSERT INTO [dbo].[Availabilities]
           ([StartTime]
           ,[EndTime]
           ,[DayOfTheWeek])
     VALUES
           ('10:00 am'
           ,'11:30 am'
           ,3)
GO
-- Inserts values into the Regions table --

INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
           ('Southeast')
GO
INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
           ('Northeast')
GO
INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
           ('Central')
GO
INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
           ('Central-South')
GO
INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
           ('West')
GO
-- Inserts values to the Roles table --

INSERT INTO [dbo].[Roles]
           ([Name])
     VALUES
           ('Junior Associate')
GO
INSERT INTO [dbo].[Roles]
           ([Name])
     VALUES
           ('Manager')
GO
-- Inserts values to the Design Studios table --

INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Albuquerque'
           ,5)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Augusta'
           ,1)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Baton Rouge'
           ,4)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Buffalo'
           ,2)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Fort Wayne'
           ,2)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Jonesboro'
           ,4)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Mobile'
           ,1)
GO
INSERT INTO [dbo].[DesignStudios]
           ([Name]
           ,[RegionId])
     VALUES
           ('Oklahoma City'
           ,4)
GO
-- Inserts values into the Users table. --

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate]
           ,[RoleId]
           ,[DesignStudiosId])
     VALUES
           ('Libby'
           ,'B.'
           ,'Blair'
           ,'libby.blair@teamsparq.com'
           ,'test'
           ,'1234567890'
           ,'true'
           ,'2020-05-17'
           ,1
           ,4)
GO
INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate]
           ,[RoleId]
           ,[DesignStudiosId])
     VALUES
           ('Brennen'
           ,'B.'
           ,'Collins'
           ,'brennen.collins@teamsparq.com'
           ,'test1'
           ,'0987654321'
           ,'false'
           ,NULL
           ,1
           ,5)
GO
INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate]
           ,[RoleId]
           ,[DesignStudiosId])
     VALUES
           ('Andrew'
           ,'A.'
           ,'Ringle'
           ,'andrew.ringle@teamsparq.com'
           ,'test2'
           ,'1324576890'
           ,'true'
           ,'2019-12-10'
           ,1
           ,2)
GO
INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate]
           ,[RoleId]
           ,[DesignStudiosId])
     VALUES
           ('Layken'
           ,'L.'
           ,'Varholdt'
           ,'layken.varholdt@teamsparq.com'
           ,'test'
           ,'0897645321'
           ,'false'
           ,NULL
           ,1
           ,1)
GO
-- This inserts values into UserAvailabilities table --

INSERT INTO [dbo].[UserAvailabilities]
           ([UserId]
           ,[AvailabilityId])
     VALUES
           (1
           ,1)
GO
INSERT INTO [dbo].[UserAvailabilities]
           ([UserId]
           ,[AvailabilityId])
     VALUES
           (3
           ,2)
GO
INSERT INTO [dbo].[UserAvailabilities]
           ([UserId]
           ,[AvailabilityId])
     VALUES
           (2
           ,3)
GO