  SELECT [s].[FirstName], [s].[Address], [s].[Phone]
    FROM [dbo].[Students] AS s
   WHERE [s].[MiddleName] IS NOT NULL AND [s].[Phone] LIKE '42%'
ORDER BY [s].[FirstName];