  SELECT [r].[OpenDate], [r].[Description], [u].[Email]
    FROM [dbo].[Reports] AS r
    JOIN [dbo].[Users] AS [u] ON [r].[UserId] = [u].[Id]
    JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
   WHERE [r].[CloseDate] IS NULL AND
         LEN([r].[Description]) > 20 AND
         [r].[Description] LIKE '%str%' AND
         [c].[DepartmentId] IN (1, 4, 5)
ORDER BY [r].[OpenDate], [u].[Email], [r].[Id];