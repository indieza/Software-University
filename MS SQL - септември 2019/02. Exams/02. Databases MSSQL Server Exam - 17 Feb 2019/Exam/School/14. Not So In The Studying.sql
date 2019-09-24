   SELECT [s].[FirstName] + ' ' + ISNULL(s.[MiddleName] + ' ', '') + [s].[LastName] AS [Full Name]
     FROM [dbo].[Students] AS s
LEFT JOIN [dbo].[StudentsSubjects] AS [ss] ON [s].[Id] = [ss].[StudentId]
    WHERE [ss].[SubjectId] IS NULL
 ORDER BY [Full Name];