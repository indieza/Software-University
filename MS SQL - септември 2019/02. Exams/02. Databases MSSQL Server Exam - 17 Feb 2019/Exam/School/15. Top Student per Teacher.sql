  SELECT [j].[Teacher Full Name],
         [j].[Subject Name],
		 [j].[Student Full Name],
		 CAST([j].[Grade] AS DECIMAL(15, 2)) AS [Grade]
    FROM (
  SELECT [k].[Teacher Full Name],
         [k].[Subject Name],
		 [k].[Student Full Name],
		 [k].[Grade],
		 ROW_NUMBER() OVER (PARTITION BY [k].[Teacher Full Name] ORDER BY [k].[Grade] DESC) AS [Row]
    FROM (
  SELECT [t].[FirstName] + ' ' + [t].[LastName] AS [Teacher Full Name],
         [s].[Name] AS [Subject Name],
  	     [s2].[FirstName] + ' ' + [s2].[LastName] AS [Student Full Name],
  	     AVG([ss].[Grade]) AS [Grade]
    FROM [dbo].[Teachers] AS t
    JOIN [dbo].[Subjects] AS [s] ON [t].[SubjectId] = [s].[Id]
    JOIN [dbo].[StudentsSubjects] AS [ss] ON [s].[Id] = [ss].[SubjectId]
    JOIN [dbo].[Students] AS [s2] ON [ss].[StudentId] = [s2].[Id]
    JOIN [dbo].[StudentsTeachers] AS [st] ON [s2].[Id] = [st].[StudentId] AND [t].[Id] = [st].[TeacherId]
GROUP BY [t].[FirstName], [t].[LastName], [s].[Name], [s2].[FirstName], [s2].[LastName]) AS k) AS j
   WHERE [j].[Row] = 1
ORDER BY [j].[Subject Name], [j].[Teacher Full Name], [Grade] DESC;