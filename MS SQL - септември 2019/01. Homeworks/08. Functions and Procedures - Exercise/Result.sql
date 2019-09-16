CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE Salary > 35000

EXEC dbo.usp_GetEmployeesSalaryAbove35000

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE Salary >= @Number

EXEC dbo.usp_GetEmployeesSalaryAboveNumber @Number = 48100

CREATE PROCEDURE usp_GetTownsStartingWith @Input VARCHAR(10)
    AS
SELECT [Name]
  FROM Towns
 WHERE [Name] LIKE @Input + '%'

EXEC dbo.usp_GetTownsStartingWith @Input = 'b'