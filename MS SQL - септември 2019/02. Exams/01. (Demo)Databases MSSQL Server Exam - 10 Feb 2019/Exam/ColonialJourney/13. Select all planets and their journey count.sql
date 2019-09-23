  SELECT [p].[Name] AS [PlanetName], COUNT([j].[Id]) AS [JourneysCount]
    FROM [dbo].[Planets] AS p
    JOIN [dbo].[Spaceports] AS [s] ON [p].[Id] = [s].[PlanetId]
    JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[DestinationSpaceportId]
GROUP BY [p].[Name]
ORDER BY [JourneysCount] DESC, [PlanetName];