  SELECT [j].[Teacher Full Name], [j].[Subject Name], [j].[Student Full Name], CAST([j].[Grade] AS DECIMAL(15, 2)) AS [Grade]
    FROM (
  SELECT [k].[Teacher Full Name],
         [k].[Subject Name],
		 [k].[Student Full Name],
		 [k].[Grade],
		 ROW_NUMBER() OVER (PARTITION BY [k].[Teacher Full Name] ORDER BY [k].[Grade] DESC) AS [Rank]
    FROM (
  SELECT [t].[FirstName] + ' ' + [t].[LastName] AS [Teacher Full Name],
         [s2].[Name] AS [Subject Name],
  	     [s].[FirstName] + ' ' + [s].[LastName] AS [Student Full Name],
  	     AVG([ss].[Grade]) AS [Grade]
    FROM [dbo].[Teachers] AS t
    JOIN [dbo].[StudentsTeachers] AS [st] ON [t].[Id] = [st].[TeacherId]
    JOIN [dbo].[Students] AS [s] ON [st].[StudentId] = [s].[Id]
    JOIN [dbo].[StudentsSubjects] AS [ss] ON [s].[Id] = [ss].[StudentId]
    JOIN [dbo].[Subjects] AS [s2] ON [ss].[SubjectId] = [s2].[Id] AND [t].[SubjectId] = [s2].[Id]
GROUP BY [t].[FirstName], [t].[LastName], [s].[FirstName], [s].[LastName], [s2].[Name]) AS k) AS j
   WHERE [j].[Rank] = 1
ORDER BY [j].[Subject Name], [j].[Teacher Full Name], [j].[Grade] DESC;