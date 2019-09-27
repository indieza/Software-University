CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Money DECIMAL(18, 4))
AS
SELECT [e].[FirstName], [e].[LastName]
  FROM [dbo].[Employees] AS e
 WHERE [e].[Salary] >= @Money