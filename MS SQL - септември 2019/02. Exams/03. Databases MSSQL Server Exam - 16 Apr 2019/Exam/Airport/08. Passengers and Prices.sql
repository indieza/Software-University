  SELECT TOP(10) [p].[FirstName], [p].[LastName], [t].[Price]
    FROM [dbo].[Passengers] AS p
    JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
ORDER BY [Price] DESC, [p].[FirstName], [p].[LastName];