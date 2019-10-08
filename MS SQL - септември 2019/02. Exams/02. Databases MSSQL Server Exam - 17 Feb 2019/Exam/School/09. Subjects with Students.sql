  SELECT [k].[FullName],
         [k].[Subjects],
		 COUNT([st].[StudentId]) AS [Students]
    FROM (
  SELECT [t].[Id],
         [t].[FirstName] + ' ' + [t].[LastName] AS [FullName],
         [s].[Name] + '-' + CAST([s].[Lessons] AS VARCHAR(20)) AS [Subjects]
    FROM [dbo].[Teachers] AS t
    JOIN [dbo].[Subjects] AS [s] ON [t].[SubjectId] = [s].[Id]) AS k
	JOIN [dbo].[StudentsTeachers] AS st ON [k].[Id] = [st].[TeacherId]
GROUP BY [k].[FullName], [k].[Subjects]
ORDER BY [Students] DESC, [k].[FullName], [k].[Subjects];