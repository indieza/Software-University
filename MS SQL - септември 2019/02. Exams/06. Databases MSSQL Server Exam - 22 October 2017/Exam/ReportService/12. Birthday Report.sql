  SELECT DISTINCT [c].[Name] AS [Category Name]
    FROM [dbo].[Categories] AS c
    JOIN [dbo].[Reports] AS [r] ON [c].[Id] = [r].[CategoryId]
    JOIN [dbo].[Users] AS [u] ON [r].[UserId] = [u].[Id]
   WHERE DAY([r].[OpenDate]) = DAY([u].[BirthDate]) AND MONTH([r].[OpenDate]) = MONTH([u].[BirthDate])
ORDER BY [c].[Name];