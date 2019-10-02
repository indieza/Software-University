  SELECT [at].[AccountId] AS [Id],
         [a].[Email],
  	     [c].[Name] AS [City],
  	     COUNT([at].[TripId]) AS [Trips]
    FROM [dbo].[AccountsTrips] AS [at]
    JOIN [dbo].[Trips] AS [t] ON [at].[TripId] = [t].[Id]
    JOIN [dbo].[Rooms] AS [r] ON [t].[RoomId] = [r].[Id]
    JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
    JOIN [dbo].[Cities] AS [c] ON [h].[CityId] = [c].[Id]
    JOIN [dbo].[Accounts] AS [a] ON [c].[Id] = [a].[CityId] AND [at].[AccountId] = [a].[Id]
   WHERE [a].[CityId] = [h].[CityId]
GROUP BY [at].[AccountId], [a].[Email], [c].[Name]
ORDER BY [Trips] DESC, [Id];