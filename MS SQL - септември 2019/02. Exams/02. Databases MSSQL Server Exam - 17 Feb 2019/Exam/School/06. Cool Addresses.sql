  SELECT [st].[FirstName] + ' ' + ISNULL(st.[MiddleName], '') + ' ' + [st].[LastName] AS [Full Name], [st].[Address]
    FROM [dbo].[Students] AS st
   WHERE [st].[Address] LIKE '%road%'
ORDER BY [st].[FirstName], [st].[LastName], [st].[Address];