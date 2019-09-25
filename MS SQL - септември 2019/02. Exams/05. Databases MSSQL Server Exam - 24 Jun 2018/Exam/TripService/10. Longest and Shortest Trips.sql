  SELECT [a].[Id],
         [a].[FirstName] + ' ' + [a].[LastName] AS [Full Name],
   	     MAX(DATEDIFF(DAY, [t].[ArrivalDate], [t].[ReturnDate])) AS [LongestTrip],
   	     MIN(DATEDIFF(DAY, [t].[ArrivalDate], [t].[ReturnDate])) AS [ShortestTrip]
    FROM [dbo].[Accounts] AS a
    JOIN [dbo].[AccountsTrips] AS [at] ON [a].[Id] = [at].[AccountId]
    JOIN [dbo].[Trips] AS [t] ON [at].[TripId] = [t].[Id]
   WHERE [a].[MiddleName] IS NULL AND [t].[CancelDate] IS NULL
GROUP BY [a].[Id], [a].[FirstName], [a].[LastName]
ORDER BY [LongestTrip] DESC, [a].[Id];