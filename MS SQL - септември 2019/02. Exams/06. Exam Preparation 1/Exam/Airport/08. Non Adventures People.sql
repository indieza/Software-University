   SELECT [p].[FirstName], [p].[LastName], [p].[Age]
     FROM [dbo].[Passengers] AS p
LEFT JOIN [dbo].[Tickets] AS [t] ON [p].[Id] = [t].[PassengerId]
    WHERE [t].[PassengerId] IS NULL
 ORDER BY [p].[Age] DESC, [p].[FirstName], [p].[LastName];