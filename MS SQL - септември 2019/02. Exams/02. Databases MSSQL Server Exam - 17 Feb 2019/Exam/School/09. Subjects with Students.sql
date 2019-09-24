  SELECT [t].[FirstName] + ' ' + [t].[LastName] AS [FullName],
         [s].[Name] + '-' + CAST([s].[Lessons] AS VARCHAR(20)) AS [Subjects],
		 COUNT([st].[TeacherId]) AS [Students]
    FROM [dbo].[Teachers] AS t
    JOIN [dbo].[Subjects] AS [s] ON [t].[SubjectId] = [s].[Id]
	JOIN [dbo].[StudentsTeachers] AS [st] ON [t].[Id] = [st].[TeacherId]
GROUP BY [t].[FirstName], [t].[LastName], [s].[Name], [s].[Lessons]
ORDER BY [Students] DESC, [FullName], [Subjects];