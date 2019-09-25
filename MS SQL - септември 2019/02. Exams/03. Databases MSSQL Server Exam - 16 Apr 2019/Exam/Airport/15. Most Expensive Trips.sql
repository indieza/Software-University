  SELECT [k].[FirstName], [k].[LastName], [k].[Destination], [k].[Price]
    FROM (
  SELECT [p].[FirstName],
         [p].[LastName],
  	     [f].[Destination],
  	     [t].[Price],
  	     ROW_NUMBER() OVER (PARTITION BY [p].[FirstName], [p].[LastName] ORDER BY [t].[Price] DESC) AS [Rank]
    FROM [dbo].[Passengers] AS p
    JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
    JOIN [dbo].[Flights] AS [f] ON [t].[FlightId] = [f].[Id]) AS k
   WHERE [k].[Rank] = 1
ORDER BY [k].[Price] DESC, [k].[FirstName], [k].[LastName], [k].[Destination];