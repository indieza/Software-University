  SELECT [t].[Id],
         [a].[FirstName] + ' ' + ISNULL([a].[MiddleName] + ' ', '') + [a].[LastName] AS [Full Name],
  	     [c].[Name] AS [From],
  	     [c2].[Name] AS [To],
  	     CASE
  		     WHEN [t].[CancelDate] IS NOT NULL THEN 'Canceled'
  		     ELSE CAST(DATEDIFF(DAY, [t].[ArrivalDate], [t].[ReturnDate]) AS VARCHAR(50)) + ' days'
  	     END AS [Duration]
    FROM [dbo].[Trips] AS t
    JOIN [dbo].[AccountsTrips] AS [at] ON [t].[Id] = [at].[TripId]
    JOIN [dbo].[Accounts] AS [a] ON [at].[AccountId] = [a].[Id]
    JOIN [dbo].[Rooms] AS [r] ON [t].[RoomId] = [r].[Id]
    JOIN [dbo].[Hotels] AS [h] ON [r].[HotelId] = [h].[Id]
    JOIN [dbo].[Cities] AS [c] ON [a].[CityId] = [c].[Id]
    JOIN [dbo].[Cities] AS [c2] ON [h].[CityId] = [c2].[Id]
ORDER BY [Full Name], [t].[Id];