  SELECT [f].[Id] AS [FlightId], SUM([t].[Price]) AS [Price]
    FROM [dbo].[Flights] AS f
    JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
GROUP BY [f].[Id]
ORDER BY [Price] DESC, [FlightId];