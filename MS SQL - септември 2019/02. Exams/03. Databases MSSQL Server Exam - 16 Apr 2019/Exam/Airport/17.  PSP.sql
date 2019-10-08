   SELECT [p].[Name],
          [p].[Seats],
  	      COUNT([p2].[Id]) AS [Passengers Count]
     FROM [dbo].[Planes] AS p
LEFT JOIN [dbo].[Flights] AS [f] ON [p].[Id] = [f].[PlaneId]
LEFT JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
LEFT JOIN [dbo].[Passengers] AS [p2] ON [t].[PassengerId] = [p2].[Id]
 GROUP BY [p].[Name], [p].[Seats]
 ORDER BY [Passengers Count] DESC, [p].[Name], [p].[Seats];