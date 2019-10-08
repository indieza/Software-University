  SELECT TOP(1) [s].[Name] AS [SpaceshipName],
         [s2].[Name] AS [SpaceportName]
    FROM [dbo].[Spaceships] AS s
    JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[SpaceshipId]
    JOIN [dbo].[Spaceports] AS [s2] ON [j].[DestinationSpaceportId] = [s2].[Id]
ORDER BY [s].[LightSpeedRate] DESC;