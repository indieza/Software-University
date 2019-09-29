CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
BEGIN
	DECLARE @targetSender INT = (SELECT Id FROM [dbo].[Accounts] AS a WHERE a.[Id] = @SenderId)
	DECLARE @targetReciver INT = (SELECT Id FROM [dbo].[Accounts] AS a WHERE a.[Id] = @ReceiverId)
	
	IF(@targetReciver IS NULL OR @targetSender IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Id Parameter', 16, 1)
		RETURN
	END
	
	IF(@Amount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 2)
		RETURN
	END
	
	EXEC dbo.usp_WithdrawMoney @targetSender, @Amount
	EXEC dbo.usp_DepositMoney @targetReciver, @Amount
END