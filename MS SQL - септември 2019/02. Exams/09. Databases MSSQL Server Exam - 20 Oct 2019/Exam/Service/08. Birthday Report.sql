  SELECT [u].[Username],
         [c].[Name] AS [CategoryName]
    FROM [dbo].[Users] AS u
    JOIN [dbo].[Reports] AS [r] ON [u].[Id] = [r].[UserId]
    JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
   WHERE DATEPART(MONTH, [u].[Birthdate]) = DATEPART(MONTH, [r].[OpenDate]) AND
         DATEPART(DAY, [u].[Birthdate]) = DATEPART(DAY, [r].[OpenDate])
ORDER BY [u].[Username], [c].[Name];