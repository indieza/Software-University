  SELECT TOP(10) [p].[FirstName],
         [p].[LastName],
  	     SUM([t].[Price]) AS [Price]
    FROM [dbo].[Passengers] AS p
    JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
GROUP BY [p].[FirstName], [p].[LastName], [t].[FlightId]
ORDER BY [Price] DESC, [p].[FirstName], [p].[LastName];