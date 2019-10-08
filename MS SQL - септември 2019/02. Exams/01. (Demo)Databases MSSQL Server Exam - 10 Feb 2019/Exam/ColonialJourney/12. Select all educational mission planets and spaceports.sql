  SELECT [p].[Name] AS [PlanetName],
         [s].[Name] AS [SpaceportName]
    FROM [dbo].[Spaceports] AS s
    JOIN [dbo].[Planets] AS [p] ON [s].[PlanetId] = [p].[Id]
    JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[DestinationSpaceportId]
   WHERE [j].[Purpose] = 'Educational'
ORDER BY [s].[Name] DESC;