  SELECT [k].[Quarter], [k].[SubjectName], COUNT([k].[StudentId]) AS [StudentsCount]
    FROM (
  SELECT CASE
  		     WHEN DATEPART(MONTH, [e].[Date]) BETWEEN 1 AND 3 THEN 'Q1'
  		     WHEN DATEPART(MONTH, [e].[Date]) BETWEEN 4 AND 6 THEN 'Q2'
  		     WHEN DATEPART(MONTH, [e].[Date]) BETWEEN 7 AND 9 THEN 'Q3'
  		     WHEN DATEPART(MONTH, [e].[Date]) BETWEEN 10 AND 12 THEN 'Q4'
  		     ELSE 'TBA'
  	     END AS [Quarter],
  	     [s].[Name] AS [SubjectName],
  	     [se].[StudentId],
		 [se].[Grade]
    FROM [dbo].[Exams] AS e
    JOIN [dbo].[StudentsExams] AS [se] ON [e].[Id] = [se].[ExamId]
    JOIN [dbo].[Subjects] AS [s] ON [e].[SubjectId] = [s].[Id]) AS k
   WHERE [k].[Grade] >= 4.00
GROUP BY [k].[Quarter], [k].[SubjectName]
ORDER BY [k].[Quarter];