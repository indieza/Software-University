SELECT [k].[JobDuringJourney], [k].[FullName], [k].[Rank]
  FROM (
SELECT [tc].[JobDuringJourney],
       [c].[FirstName] + ' ' + [c].[LastName] AS [FullName],
	   ROW_NUMBER() OVER (PARTITION BY [tc].[JobDuringJourney] ORDER BY [c].[BirthDate]) AS [Rank]
  FROM [dbo].[Colonists] AS c
  JOIN [dbo].[TravelCards] AS [tc] ON [c].[Id] = [tc].[ColonistId]) AS k
 WHERE [k].[Rank] = 2;