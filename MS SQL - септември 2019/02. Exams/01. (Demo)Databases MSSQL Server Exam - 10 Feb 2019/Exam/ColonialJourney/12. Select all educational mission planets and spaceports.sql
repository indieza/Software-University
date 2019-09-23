  SELECT [p].[Name] AS [PlanetName], [s].[Name] AS [SpaceportName]
    FROM [dbo].[Planets] AS p
    JOIN [dbo].[Spaceports] AS [s] ON [p].[Id] = [s].[PlanetId]
    JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[DestinationSpaceportId]
   WHERE [j].[Purpose] = 'Educational'
ORDER BY [s].[Name] DESC;