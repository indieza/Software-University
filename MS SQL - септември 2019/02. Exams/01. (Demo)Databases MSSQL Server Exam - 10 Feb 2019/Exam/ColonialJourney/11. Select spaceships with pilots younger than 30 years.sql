  SELECT [s].[Name], [s].[Manufacturer]
    FROM [dbo].[Spaceships] AS s
    JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[SpaceshipId]
    JOIN [dbo].[TravelCards] AS [tc] ON [j].[Id] = [tc].[JourneyId]
    JOIN [dbo].[Colonists] AS [c] ON [tc].[ColonistId] = [c].[Id]
   WHERE DATEDIFF(YEAR, [c].[BirthDate], '01/01/2019') < 30 AND [tc].[JobDuringJourney] = 'Pilot'
ORDER BY [s].[Name];