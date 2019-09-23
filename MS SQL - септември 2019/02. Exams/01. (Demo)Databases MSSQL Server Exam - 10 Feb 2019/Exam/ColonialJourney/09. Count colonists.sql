SELECT COUNT(*) AS [count]
  FROM [dbo].[Colonists] AS c
  JOIN [dbo].[TravelCards] AS [tc] ON [c].[Id] = [tc].[ColonistId]
  JOIN [dbo].[Journeys] AS [j] ON [tc].[JourneyId] = [j].[Id]
 WHERE [j].[Purpose] = 'Technical'