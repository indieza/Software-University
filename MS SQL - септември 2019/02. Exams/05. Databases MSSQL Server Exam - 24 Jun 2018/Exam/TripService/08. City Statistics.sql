   SELECT [c].[Name] AS [City],
          COUNT([h].[Id]) AS [Hotels]
     FROM [dbo].[Cities] AS c
LEFT JOIN [dbo].[Hotels] AS [h] ON [c].[Id] = [h].[CityId]
 GROUP BY [c].[Name]
 ORDER BY [Hotels] DESC, [City];