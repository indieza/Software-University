   SELECT [p].[Name], [p].[Seats], COUNT([t].[PassengerId]) AS [Passengers Count]
     FROM [dbo].[Planes] AS p
LEFT JOIN [dbo].[Flights] AS [f] ON [p].[Id] = [f].[PlaneId]
LEFT JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
 GROUP BY [p].[Name], [p].[Seats]
 ORDER BY [Passengers Count] DESC, [p].[Name], [p].[Seats];