BEGIN

DECLARE @statusesCount int;

SELECT @statusesCount = COUNT(*) FROM TodoStatuses;

--Create initial statuses if statuses table is empty
IF(@statusesCount = 0) 
	INSERT INTO TodoStatuses (Name, Description)
	VALUES (N'New', N'Newly created todo'),
	(N'In progress', N'Todo in progress'),
	(N'Completed', N'Completed todo');


END;