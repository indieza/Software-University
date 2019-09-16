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

CREATE PROCEDURE usp_GetEmployeesFromTown @TownName VARCHAR(50)
    AS
SELECT e.FirstName, e.LastName
  FROM Employees AS e
  JOIN Addresses AS a ON a.AddressID = e.AddressID
  JOIN Towns AS T ON t.TownID = a.TownID
 WHERE t.[Name] = @TownName

EXEC dbo.usp_GetEmployeesFromTown @TownName = 'Sofia'