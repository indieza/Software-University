  SELECT [t].[Id],
         [h].[Name] AS [HotelName],
  	     [r].[Type] AS [RoomType],
		 CASE
			WHEN [t].[CancelDate] IS NULL THEN SUM([h].[BaseRate] + [r].[Price])
			ELSE 0
		 END AS [Revenue]
    FROM [dbo].[Trips] AS t
    JOIN [dbo].[AccountsTrips] AS [at] ON [t].[Id] = [at].[TripId]
    JOIN [dbo].[Rooms] AS [r] ON [t].[RoomId] = [r].[Id]
    JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
GROUP BY [t].[Id], [h].[Name], [r].[Type], [t].[CancelDate]
ORDER BY [RoomType], [t].[Id];