DELETE
  FROM [dbo].[TravelCards]
 WHERE [dbo].[TravelCards].[JourneyId] IN (1, 2, 3);

DELETE
  FROM [dbo].[Journeys]
 WHERE [dbo].[Journeys].[Id] IN (1, 2, 3);