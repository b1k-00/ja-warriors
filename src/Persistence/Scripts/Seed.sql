/***** this query will add values to the 'Users' table on the 'JASchedular' database *****/

USE [JAScheduler]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[MiddleName]
           ,[Email]
           ,[Password]
           ,[PhoneNumber]
           ,[Graduated]
           ,[GraduatedDate])
     VALUES
           ('Happy',
           'Gilmore',
           'B',
           'happy@ruralsourcing.com',
           'Password1',
           '1234567890',
           'yes',
           '1980-05-12')
GO