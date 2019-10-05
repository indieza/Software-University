  SELECT [r].[Id],
         [r].[Price],
  	     [h].[Name] AS [Hotel],
  	     [c].[Name] AS [City]
    FROM [dbo].[Rooms] AS r
    JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
    JOIN [dbo].[Cities] AS [c] ON [h].[CityId] = [c].[Id]
 WHERE [r].[Type] = 'First Class'
ORDER BY [r].[Price] DESC, [r].[Id];