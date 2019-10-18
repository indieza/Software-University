  SELECT [t].[FlightId],
         SUM([t].[Price]) AS [Price]
    FROM [dbo].[Flights] AS f
    JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
GROUP BY [t].[FlightId]
ORDER BY [Price] DESC, [t].[FlightId];