CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	ALTER TABLE [dbo].[Departments]
	ALTER COLUMN [ManagerID] INT

	DELETE
	  FROM [dbo].[EmployeesProjects]
	 WHERE [dbo].[EmployeesProjects].[EmployeeID] IN (SELECT [e].[EmployeeID]
	                                                    FROM [dbo].[Employees] AS e
													   WHERE [e].[DepartmentID] = @departmentId);
	UPDATE [dbo].[Departments]
	   SET
	       [dbo].[Departments].[ManagerID] = NULL
	 WHERE [dbo].[Departments].[DepartmentID] = @departmentId;

	 UPDATE [dbo].[Employees]
	    SET
	        [dbo].[Employees].[ManagerID] = NULL
	  WHERE [dbo].[Employees].[ManagerID] IN (SELECT [e].[EmployeeID]
	                                            FROM [dbo].[Employees] AS e
											   WHERE [e].[DepartmentID] = @departmentId);

	DELETE
	  FROM [dbo].[Employees]
	 WHERE [dbo].[Employees].[DepartmentID] = @departmentId;

	DELETE
	  FROM [dbo].[Departments]
	 WHERE [dbo].[Departments].[DepartmentID] = @departmentId;

	 SELECT COUNT(*)
       FROM Employees
      WHERE DepartmentID = @DepartmentId
END