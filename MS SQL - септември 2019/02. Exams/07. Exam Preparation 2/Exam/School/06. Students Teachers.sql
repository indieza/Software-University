  SELECT [s].[FirstName],
         [s].[LastName],
  	     COUNT([st].[TeacherId]) AS [TeachersCount]
    FROM [dbo].[Students] AS s
    JOIN [dbo].[StudentsTeachers] AS [st] ON [s].[Id] = [st].[StudentId]
GROUP BY [s].[FirstName], [s].[LastName];