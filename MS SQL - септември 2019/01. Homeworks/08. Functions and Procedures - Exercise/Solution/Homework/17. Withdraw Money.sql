CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
	DECLARE @targetAccountId INT = (SELECT [Id] FROM [dbo].[Accounts] AS a WHERE a.[Id] = @AccountId)
	
	IF(@targetAccountId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Id Parameter', 16, 1)
		RETURN
	END
	
	DECLARE @targetBalance DECIMAL(15, 4) = (SELECT [Balance] FROM [dbo].[Accounts] AS a WHERE a.[Id] = @targetAccountId)
	
	IF(@MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 2)
		RETURN
	END
	
	IF(@targetBalance - @MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money left', 16, 3)
		RETURN
	END
	
	UPDATE [dbo].[Accounts]
	SET
	    [Balance] -= @MoneyAmount
	WHERE Id = @AccountId
END