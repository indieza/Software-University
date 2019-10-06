  SELECT TOP(5) [c].[Id],
         [c].[Name] AS [City],
  	     [c].[CountryCode] AS [Country],
  	     COUNT([a].[Id]) AS Accounts
    FROM [dbo].[Cities] AS c
    JOIN [dbo].[Accounts] AS [a] ON [c].[Id] = [a].[CityId]
GROUP BY [c].[Id], [c].[Name], [c].[CountryCode]
ORDER BY [Accounts] DESC;