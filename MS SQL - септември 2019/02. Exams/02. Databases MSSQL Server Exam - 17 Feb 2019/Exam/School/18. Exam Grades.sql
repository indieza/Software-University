CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@studentId NOT IN (SELECT [s].[Id] FROM [dbo].[Students] AS s))
		RETURN 'The student with provided id does not exist in the school!'

	IF(@grade > 6.00)
		RETURN 'Grade cannot be above 6.00!'

	DECLARE @count INT = (SELECT COUNT(*)
						    FROM [dbo].[Students] AS s
							JOIN [dbo].[StudentsExams] AS [se] ON [s].[Id] = [se].[StudentId]
						   WHERE [s].[Id] = @studentId AND [se].[Grade] BETWEEN @grade AND @grade + 0.50)

	DECLARE @firstName VARCHAR(50) = (SELECT [s].[FirstName]
							            FROM [dbo].[Students] AS s
									   WHERE [s].[Id] = @studentId)

	RETURN 'You have to update ' + CAST(@count AS VARCHAR(20)) + ' grades for the student ' + @firstName
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)