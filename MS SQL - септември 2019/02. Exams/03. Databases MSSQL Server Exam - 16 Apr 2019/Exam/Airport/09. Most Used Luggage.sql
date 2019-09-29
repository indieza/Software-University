  SELECT [lt].[Type], COUNT([l].[Id]) AS [MostUsedLuggage]
    FROM [dbo].[Luggages] AS l
    JOIN [dbo].[LuggageTypes] AS [lt] ON [l].[LuggageTypeId] = [lt].[Id]
GROUP BY [lt].[Type]
ORDER BY [MostUsedLuggage] DESC, [lt].[Type];