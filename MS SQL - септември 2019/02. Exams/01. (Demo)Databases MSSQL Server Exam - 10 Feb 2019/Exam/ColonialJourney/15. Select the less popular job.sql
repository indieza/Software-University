  SELECT TOP(1) [k].[JourneyId], [k].[JobName]
    FROM (
  SELECT [j].[Id] AS [JourneyId],
         [tc].[JobDuringJourney] AS [JobName],
		 DATEDIFF(DAY, [j].[JourneyStart], [j].[JourneyEnd]) AS [Days]
    FROM [dbo].[Journeys] AS j
    JOIN [dbo].[TravelCards] AS [tc] ON [j].[Id] = [tc].[JourneyId]) AS k
GROUP BY [k].[JourneyId], [k].[JobName], [k].[Days]
ORDER BY [k].[Days] DESC, COUNT([k].[JourneyId]);