CREATE PROCEDURE usp_EmployeesBySalaryLevel(@Level VARCHAR(50))
AS
SELECT [e].[FirstName], [e].[LastName]
  FROM [dbo].[Employees] AS e
 WHERE [dbo].ufn_GetSalaryLevel(Salary) = @Level