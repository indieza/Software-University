CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT,
	[Subject] VARCHAR(500),
	Body VARCHAR(500)
);

CREATE TRIGGER tr_AddNewEmail ON [dbo].[Logs] FOR INSERT
AS
BEGIN
	DECLARE @recipient INT = (SELECT i.[AccountId] FROM [INSERTED] AS i)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT i.[OldSum] FROM [INSERTED] AS i)
	DECLARE @newSum DECIMAL(15, 2) = (SELECT i.[NewSum] FROM [INSERTED] AS i)

	INSERT INTO [dbo].[NotificationEmails]
	(
	    [Recipient],
	    [Subject],
	    [Body]
	)
	VALUES
	(
	    @recipient, -- Recipient - INT
	    'Balance change for account: ' + CAST(@recipient AS VARCHAR(15)),
	    'On ' + CAST(GETDATE() AS VARCHAR(50)) + ' your balance was changed from ' +
	    CAST(@oldSum AS VARCHAR(30)) + ' to ' +
	    CAST(@newSum AS VARCHAR(50)) + '.'
	)
END