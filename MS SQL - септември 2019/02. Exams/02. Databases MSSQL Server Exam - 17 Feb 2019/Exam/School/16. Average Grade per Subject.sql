  SELECT [s].[Name], AVG([ss].[Grade]) AS [AverageGrade]
    FROM [dbo].[Subjects] AS s
    JOIN [dbo].[StudentsSubjects] AS [ss] ON [s].[Id] = [ss].[SubjectId]
GROUP BY [s].[Name], [s].[Id]
ORDER BY [s].[Id];