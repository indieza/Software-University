DELETE
  FROM [dbo].[StudentsTeachers]
 WHERE [dbo].[StudentsTeachers].[TeacherId] IN (SELECT [t].[Id] FROM [dbo].[Teachers] AS t WHERE [t].[Phone] LIKE '%72%');

DELETE
  FROM [dbo].[Teachers]
 WHERE [dbo].[Teachers].[Phone] LIKE '%72%';