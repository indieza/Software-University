UPDATE [dbo].[StudentsSubjects]
   SET
       [dbo].[StudentsSubjects].[Grade] = 6.00
 WHERE [dbo].[StudentsSubjects].[SubjectId] IN (1, 2) AND [dbo].[StudentsSubjects].[Grade] >= 5.50;