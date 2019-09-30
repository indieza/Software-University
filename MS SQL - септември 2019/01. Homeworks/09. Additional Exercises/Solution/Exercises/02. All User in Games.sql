  SELECT [g].[Name] AS [Game],
         [gt].[Name] AS [Game Type],
  	     [u].[Username],
  	     [ug].[Level],
  	     [ug].[Cash],
  	     [c].[Name] AS [Character]
    FROM [dbo].[Users] AS u
    JOIN [dbo].[UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
    JOIN [dbo].[Characters] AS [c] ON [ug].[CharacterId] = [c].[Id]
    JOIN [dbo].[Games] AS [g] ON [ug].[GameId] = [g].[Id]
    JOIN [dbo].[GameTypes] AS [gt] ON [g].[GameTypeId] = [gt].[Id]
ORDER BY [ug].[Level] DESC, [u].[Username], [g].[Name];