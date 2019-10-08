  SELECT TOP(10) [t].[FirstName],
         [t].[LastName],
  	     COUNT([st].[StudentId]) AS [StudentsCount]
    FROM [dbo].[Teachers] AS t
    JOIN [dbo].[StudentsTeachers] AS [st] ON [t].[Id] = [st].[TeacherId]
GROUP BY [t].[FirstName], [t].[LastName]
ORDER BY [StudentsCount] DESC, [t].[FirstName], [t].[LastName];