CREATE TABLE [dbo].[Table]
(
	[FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Mobile] INT NOT NULL, 
    [EmailID] VARCHAR(50) NOT NULL, 
    [Category] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Mobile]) 
)
