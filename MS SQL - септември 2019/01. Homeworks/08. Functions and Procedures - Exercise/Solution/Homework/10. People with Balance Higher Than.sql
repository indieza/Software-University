CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Amount DECIMAL(15, 2))
AS
  SELECT [ah].[FirstName], [ah].[LastName]
    FROM [dbo].[AccountHolders] AS ah
    JOIN [dbo].[Accounts] AS [a] ON [ah].[Id] = [a].[AccountHolderId]
GROUP BY [ah].[FirstName], [ah].[LastName]
  HAVING SUM([a].[Balance]) > @Amount
ORDER BY [ah].[FirstName], [ah].[LastName];