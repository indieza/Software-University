  SELECT [a].[Id] AS [AccountId],
         [a].[FirstName] + ' ' + [a].[LastName] AS [FullName],
  	     MAX(DATEDIFF(DAY, [t].[ArrivalDate], [t].[ReturnDate])) AS [LongestTrip],
  	     MIN(DATEDIFF(DAY, [t].[ArrivalDate], [t].[ReturnDate])) AS [ShortestTrip]
    FROM [dbo].[Trips] AS t
    JOIN [dbo].[AccountsTrips] AS [at] ON [t].[Id] = [at].[TripId]
    JOIN [dbo].[Accounts] AS [a] ON [at].[AccountId] = [a].[Id]
   WHERE [t].[CancelDate] IS NULL AND [a].[MiddleName] IS NULL
GROUP BY [a].[Id], [a].[FirstName], [a].[LastName], [a].[MiddleName]
ORDER BY [LongestTrip] DESC, [AccountId];