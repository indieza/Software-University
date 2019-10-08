   SELECT [p].[Name], COUNT([s].[PlanetId]) AS [Count]
     FROM [dbo].[Planets] AS p
LEFT JOIN [dbo].[Spaceports] AS [s] ON [p].[Id] = [s].[PlanetId]
 GROUP BY [p].[Name]
 ORDER BY [Count] DESC, [p].[Name];