  SELECT [t].[FlightId], SUM([t].[Price]) AS [Price] 
    FROM [dbo].[Tickets] AS t
GROUP BY [t].[FlightId]
ORDER BY [Price] DESC, [t].[FlightId];