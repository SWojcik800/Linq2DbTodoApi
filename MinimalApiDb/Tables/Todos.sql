CREATE TABLE [dbo].[Todos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(240) NULL, 
    [StatusId] INT NOT NULL, 
    CONSTRAINT [FK_Todos_TodoStatuses] FOREIGN KEY ([StatusId]) REFERENCES [TodoStatuses]([Id])
)
