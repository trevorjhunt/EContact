CREATE TABLE [dbo].[Table]
(
	[ContactId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName ] VARCHAR(50) NOT NULL, 
    [ContactNo] VARCHAR(50) NULL, 
    [Address] VARCHAR(MAX) NULL, 
    [Gender] VARCHAR(50) NULL
)
