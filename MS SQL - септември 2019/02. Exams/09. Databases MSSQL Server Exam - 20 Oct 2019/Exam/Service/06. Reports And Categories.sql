  SELECT [r].[Description],
         [c].[Name] AS [CategoryName]
    FROM [dbo].[Reports] AS r
    JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
ORDER BY [r].[Description], [c].[Name];