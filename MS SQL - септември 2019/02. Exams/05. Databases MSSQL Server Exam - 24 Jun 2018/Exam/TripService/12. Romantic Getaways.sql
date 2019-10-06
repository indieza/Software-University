  SELECT [a].[Id],
         [a].[Email],
  	     [c].[Name] AS [City],
  	     COUNT([at].[TripId]) AS [Trips]
    FROM [dbo].[Accounts] AS a
    JOIN [dbo].[AccountsTrips] AS [at] ON [a].[Id] = [at].[AccountId]
    JOIN [dbo].[Trips] AS [t] ON [at].[TripId] = [t].[Id]
    JOIN [dbo].[Rooms] AS [r] ON [t].[RoomId] = [r].[Id]
    JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
    JOIN [dbo].[Cities] AS [c] ON [h].[CityId] = [c].[Id]
   WHERE [a].[CityId] = [h].[CityId]
GROUP BY [a].[Id], [a].[Email], [c].[Name]
ORDER BY [Trips] DESC, [a].[Id];