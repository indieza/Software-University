  SELECT TOP(1) [k].[JourneyId], [tc].[JobDuringJourney]
    FROM (
  SELECT TOP(1) [j].[Id] AS [JourneyId]
    FROM [dbo].[Journeys] AS j
ORDER BY DATEDIFF(DAY, [j].[JourneyStart], [j].[JourneyEnd]) DESC) AS k
    JOIN [dbo].[TravelCards] AS tc ON [k].[JourneyId] = [tc].[JourneyId]
GROUP BY [tc].[JobDuringJourney], [k].[JourneyId]
ORDER BY COUNT([tc].[JobDuringJourney]);