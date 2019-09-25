  SELECT [a].[FirstName] + ' ' + ISNULL([a].[MiddleName] + ' ', '') + [a].[LastName] AS [Full Name],
         DATEPART(YEAR, [a].[BirthDate]) AS [BirthYear]
    FROM [dbo].[Accounts] AS a
   WHERE DATEPART(YEAR, [a].[BirthDate]) > 1991
ORDER BY [BirthYear] DESC, [a].[FirstName];