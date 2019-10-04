  SELECT [c].[Name] AS [CategoryName],
         COUNT([r].[CategoryId]) AS [ReportsNumber]
    FROM [dbo].[Categories] AS c
    JOIN [dbo].[Reports] AS [r] ON [c].[Id] = [r].[CategoryId]
GROUP BY [c].[Name]
ORDER BY [ReportsNumber] DESC, [CategoryName];