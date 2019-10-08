  SELECT TOP(1) [j].[Id],
         [p].[Name] AS [PlanetName],
		 [s].[Name] AS [SpaceportName],
		 [j].[Purpose] AS [JourneyPurpose]
    FROM [dbo].[Journeys] AS j
    JOIN [dbo].[Spaceports] AS [s] ON [j].[DestinationSpaceportId] = [s].[Id]
    JOIN [dbo].[Planets] AS [p] ON [s].[PlanetId] = [p].[Id]
ORDER BY DATEDIFF(DAY, [j].[JourneyStart], [j].[JourneyEnd]);