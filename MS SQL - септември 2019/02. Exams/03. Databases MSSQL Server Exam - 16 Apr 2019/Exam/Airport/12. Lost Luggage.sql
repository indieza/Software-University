   SELECT [p].[PassportId], [p].[Address]
     FROM [dbo].[Passengers] AS p
LEFT JOIN [dbo].[Luggages] AS [l] ON [p].[Id] = [l].[PassengerId]
    WHERE [l].[LuggageTypeId] IS NULL
 ORDER BY [p].[PassportId], [p].[Address];