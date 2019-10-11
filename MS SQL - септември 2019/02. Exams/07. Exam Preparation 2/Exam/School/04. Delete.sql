DELETE
  FROM [dbo].[StudentsTeachers]
 WHERE [dbo].[StudentsTeachers].[TeacherId] IN (SELECT [dbo].[Teachers].[Id]
                                                  FROM [dbo].[Teachers]
                                                 WHERE [dbo].[Teachers].[Phone] LIKE '%72%');

DELETE
  FROM [dbo].[Teachers]
 WHERE [dbo].[Teachers].[Phone] LIKE '%72%';