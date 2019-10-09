CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT,
	Salary DECIMAL(15, 2)
)

CREATE TRIGGER tr_DeletedEmployees ON [dbo].[Employees] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[Deleted_Employees]
	(
	    [FirstName],
	    [LastName],
	    [MiddleName],
	    [JobTitle],
	    [DepartmentId],
	    [Salary]
	)
	SELECT d.[FirstName],
		   d.[LastName],
		   d.[MiddleName],
		   d.[JobTitle],
		   d.[DepartmentID],
		   d.[Salary]
      FROM [DELETED] AS d
END