﻿CREATE TABLE [dbo].[TodoStatuses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NULL
)
