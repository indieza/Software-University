  SELECT [p].[FirstName] + ' ' + [p].[LastName] AS [Full Name], [f].[Origin], [f].[Destination]
    FROM [dbo].[Passengers] AS p
    JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
    JOIN [dbo].[Flights] AS [f] ON [t].[FlightId] = [f].[Id]
ORDER BY [Full Name], [f].[Origin], [f].[Destination];