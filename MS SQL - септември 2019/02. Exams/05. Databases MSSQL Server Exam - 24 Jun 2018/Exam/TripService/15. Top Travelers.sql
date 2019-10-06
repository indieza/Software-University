  SELECT [k].[AccountId], [k].[Email], [k].[CountryCode], [k].[Trips]
    FROM (
  SELECT [a].[Id] AS [AccountId],
         [a].[Email],
  	     [c].[CountryCode],
  	     COUNT([at].[TripId]) AS [Trips],
		 ROW_NUMBER() OVER (PARTITION BY [c].[CountryCode] ORDER BY COUNT([at].[TripId]) DESC) AS [Row]
    FROM [dbo].[Accounts] AS a
    JOIN [dbo].[AccountsTrips] AS [at] ON [a].[Id] = [at].[AccountId]
	JOIN [dbo].[Trips] AS [t] ON [at].[TripId] = [t].[Id]
	JOIN [dbo].[Rooms] AS [r] ON [t].[RoomId] = [r].[Id]
	JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
	JOIN [dbo].[Cities] AS [c] ON [h].[CityId] = [c].[Id]
GROUP BY [a].[Id], [a].[Email], [c].[CountryCode]) AS k
   WHERE [k].[Row] = 1
ORDER BY [k].[Trips] DESC, [k].[AccountId];