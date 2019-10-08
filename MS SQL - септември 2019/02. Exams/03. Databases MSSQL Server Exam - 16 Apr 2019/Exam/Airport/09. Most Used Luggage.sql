  SELECT [lt].[Type],
         COUNT([l].[LuggageTypeId]) AS [MostUsedLuggage]
    FROM [dbo].[LuggageTypes] AS lt
    JOIN [dbo].[Luggages] AS [l] ON [lt].[Id] = [l].[LuggageTypeId]
GROUP BY [lt].[Type]
ORDER BY [MostUsedLuggage] DESC, [lt].[Type];