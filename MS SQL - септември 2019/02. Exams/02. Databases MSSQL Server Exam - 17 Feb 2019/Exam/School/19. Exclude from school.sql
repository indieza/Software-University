CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @targetId INT = (SELECT [s].[Id] FROM [dbo].[Students] AS s WHERE [s].[Id] = @StudentId)

	IF(@targetId IS NULL)
		RAISERROR('This school has no student with the provided id!', 16, 1)

    DELETE
      FROM [dbo].[StudentsTeachers]
     WHERE [dbo].[StudentsTeachers].[StudentId] = @targetId

	DELETE
	 FROM [dbo].[StudentsSubjects]
	WHERE [dbo].[StudentsSubjects].[StudentId] = @targetId
    
    DELETE
      FROM [dbo].[StudentsExams]
     WHERE [dbo].[StudentsExams].[StudentId] = @targetId;
   
   DELETE
    FROM [dbo].[StudentsExams]
   WHERE [dbo].[StudentsExams].[StudentId] = @targetId

	DELETE
	  FROM [dbo].[Students]
	 WHERE [dbo].[Students].[Id] = @targetId
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
EXEC usp_ExcludeFromSchool 301