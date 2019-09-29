CREATE FUNCTION ufn_CashInUsersGames(@Game VARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT SUM([k].[Cash]) AS [SumCash]
  FROM (
SELECT [ug].[Cash] AS [Cash],
       ROW_NUMBER() OVER (PARTITION BY [g].[Name] ORDER BY [ug].[Cash] DESC) AS [Row]
  FROM [dbo].[Games] AS g
  JOIN [dbo].[UsersGames] AS [ug] ON [g].[Id] = [ug].[GameId]
 WHERE [g].[Name] = @Game) AS k
 WHERE [k].[Row] % 2 = 1