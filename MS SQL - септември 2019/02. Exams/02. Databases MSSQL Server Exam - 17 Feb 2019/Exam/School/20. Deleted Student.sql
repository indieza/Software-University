CREATE TABLE ExcludedStudents
(
	StudentId INT,
	StudentName NVARCHAR(100)
);

CREATE TRIGGER tr_DeletedSrudents ON [dbo].[Students] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[ExcludedStudents]
	(
	    [StudentId],
	    [StudentName]
	)
	SELECT d.[Id], d.[FirstName] + ' ' + d.[LastName] FROM [DELETED] AS d
END

DELETE FROM StudentsExams
WHERE StudentId = 1

DELETE FROM StudentsTeachers
WHERE StudentId = 1

DELETE FROM StudentsSubjects
WHERE StudentId = 1

DELETE FROM Students
WHERE Id = 1

SELECT * FROM ExcludedStudents