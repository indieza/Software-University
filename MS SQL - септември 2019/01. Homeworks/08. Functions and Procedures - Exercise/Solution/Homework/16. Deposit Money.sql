CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
	DECLARE @targetAccountId INT = (SELECT a.Id FROM dbo.Accounts a WHERE a.Id = @AccountId)

	IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END
	
	IF(@targetAccountId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Id Parameter', 16, 2)
		RETURN
	END

	UPDATE [dbo].[Accounts]
	   SET
	       [dbo].[Accounts].[Balance] += @MoneyAmount
	 WHERE [dbo].[Accounts].[Id] = @AccountId
END