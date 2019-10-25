  SELECT TOP(5) [c].[Name] AS [CategoryName],
         COUNT([r].[CategoryId]) AS [ReportsNumber]
    FROM [dbo].[Reports] AS r
    JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
GROUP BY [c].[Name]
ORDER BY [ReportsNumber] DESC, [c].[Name];