CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @Rate FLOAT)
AS
BEGIN
	SELECT [a].[Id] AS [Account Id],
	       [ah].[FirstName] AS [First Name],
		   [ah].[LastName] AS [Last Name],
		   [a].[Balance] AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(a.[Balance], @Rate, 5) AS [Balance in 5 years]
	  FROM [dbo].[Accounts] AS a
	  JOIN [dbo].[AccountHolders] AS [ah] ON [a].[AccountHolderId] = [ah].[Id]
	 WHERE [a].[Id] = @AccountId
END