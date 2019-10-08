   SELECT [f].[Destination],
          COUNT([t].[Id]) AS [FilesCount]
     FROM [dbo].[Flights] AS f
LEFT JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
 GROUP BY [f].[Destination]
 ORDER BY [FilesCount] DESC, [f].[Destination];