   SELECT [p].[FirstName], [p].[LastName], COUNT([t].[PassengerId]) AS [Total Trips]
     FROM [dbo].[Passengers] AS p
LEFT JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
 GROUP BY [p].[FirstName], [p].[LastName]
 ORDER BY [Total Trips] DESC, [p].[FirstName], [p].[LastName];