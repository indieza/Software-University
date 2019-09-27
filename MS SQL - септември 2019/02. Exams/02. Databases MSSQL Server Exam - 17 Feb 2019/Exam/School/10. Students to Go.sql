   SELECT [s].[FirstName] + ' ' + [s].[LastName] AS [Full Name]
     FROM [dbo].[Students] AS s
LEFT JOIN [dbo].[StudentsExams] AS [se] ON [s].[Id] = [se].[StudentId]
    WHERE [se].[ExamId] IS NULL
 ORDER BY [Full Name];