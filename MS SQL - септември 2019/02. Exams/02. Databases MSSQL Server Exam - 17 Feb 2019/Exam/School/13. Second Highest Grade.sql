  SELECT [k].[FirstName], [k].[LastName], [k].[Grade]
    FROM (
  SELECT [s].[FirstName],
         [s].[LastName],
  	     [ss].[Grade],
  	     ROW_NUMBER() OVER (PARTITION BY [s].[FirstName], [s].[LastName] ORDER BY [ss].[Grade] DESC) AS [Rank]
    FROM [dbo].[Students] AS s
    JOIN [dbo].[StudentsSubjects] AS [ss] ON [s].[Id] = [ss].[StudentId]) AS k
   WHERE [k].[Rank] = 2
ORDER BY [k].[FirstName], [k].[LastName];