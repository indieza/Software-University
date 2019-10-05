  SELECT DISTINCT [u].[Username]
    FROM [dbo].[Users] AS u
    JOIN [dbo].[Reports] AS [r] ON [u].[Id] = [r].[UserId]
   WHERE (LEFT([u].[Username], 1) LIKE '[0123456789]%' AND
         CAST([r].[CategoryId] AS VARCHAR(2)) = LEFT([u].[Username], 1)) OR 
  	     (RIGHT([u].[Username], 1) LIKE '%[0123456789]' AND
  	     CAST([r].[CategoryId] AS VARCHAR(2)) = RIGHT([u].[Username], 1))
ORDER BY [u].[Username];