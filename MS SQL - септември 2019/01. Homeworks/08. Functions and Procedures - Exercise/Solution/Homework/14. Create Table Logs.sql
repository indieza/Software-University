CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)
);

CREATE TRIGGER tr_UpdateBalance ON [dbo].[Accounts] FOR UPDATE
AS
BEGIN
	DECLARE @newSum DECIMAL(15, 2) = (SELECT i.[Balance] FROM [INSERTED] AS i)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT d.[Balance] FROM [DELETED] AS d)
	DECLARE @accountId INT = (SELECT i.[Id] FROM [INSERTED] AS i)

	INSERT INTO [dbo].[Logs]
	(
	    [AccountId],
	    [OldSum],
	    [NewSum]
	)
	VALUES
	(
		@accountId,
		@oldSum,
		@newSum
	)
END