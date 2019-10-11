  SELECT TOP(10) [s].[FirstName],
         [s].[LastName],
		 CAST(AVG([se].[Grade]) AS DECIMAL(15, 2)) AS [Grade]
    FROM [dbo].[Students] AS s
    JOIN [dbo].[StudentsExams] AS [se] ON [s].[Id] = [se].[StudentId]
GROUP BY [s].[FirstName], [s].[LastName]
ORDER BY [Grade] DESC, [s].[FirstName], [s].[LastName];