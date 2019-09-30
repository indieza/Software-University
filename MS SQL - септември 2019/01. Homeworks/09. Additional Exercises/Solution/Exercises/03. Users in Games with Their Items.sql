  SELECT [u].[Username],
         [g].[Name] AS [Game],
  	     COUNT([ugi].[ItemId]) AS [Items Count],
  	     SUM([i].[Price]) AS [Items Price]
    FROM [dbo].[Users] AS u
    JOIN [dbo].[UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
    JOIN [dbo].[Games] AS [g] ON [ug].[GameId] = [g].[Id]
    JOIN [dbo].[GameTypes] AS [gt] ON [g].[GameTypeId] = [gt].[Id]
    JOIN [dbo].[UserGameItems] AS [ugi] ON [ug].[Id] = [ugi].[UserGameId]
    JOIN [dbo].[Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
GROUP BY [u].[Username], [g].[Name]
  HAVING COUNT([ugi].[ItemId]) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, [u].[Username];