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

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(30)
AS
BEGIN
	DECLARE @result VARCHAR(30)

	IF(@Salary < 30000)
		SET @result = 'Low'
	IF(@Salary BETWEEN 30000 AND 50000)
		SET @result = 'Average'
	IF(@Salary > 50000)
		SET @result = 'High'

	RETURN @result
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
  FROM Employees

CREATE PROCEDURE usp_EmployeesBySalaryLevel @Level VARCHAR(30)
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level

EXEC dbo.usp_EmployeesBySalaryLevel @Level = 'High'

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(20), @Word VARCHAR(20))
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT
	DECLARE @count INT = 1

	WHILE @count <= LEN(@Word)
	BEGIN
		DECLARE @currentSymbol VARCHAR(2) = SUBSTRING(@Word, @count, 1)

		IF(CHARINDEX(@currentSymbol, @SetOfLetters)) > 0
			BEGIN
				SET @result = 1
				SET @count+=1
			END
		ELSE
			BEGIN
				SET @result = 0
				BREAK
			END
	END
	RETURN @result
END

SELECT 'oistmiahf', 'Sofiz', dbo.ufn_IsWordComprised('oistmiahf', 'Sofiz')
SELECT 'oistmiahf', 'Sofia', dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
    AS
 ALTER TABLE Departments
 ALTER COLUMN ManagerID INT

DELETE
  FROM EmployeesProjects
 WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

UPDATE Departments
   SET ManagerID = NULL
 WHERE DepartmentID = @DepartmentId

UPDATE Employees
   SET ManagerID = NULL
 WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

DELETE
  FROM Employees
 WHERE DepartmentID = @DepartmentId

DELETE
  FROM Departments
 WHERE DepartmentID = @DepartmentId

SELECT COUNT(*)
  FROM Employees
 WHERE DepartmentID = @DepartmentId

CREATE PROCEDURE usp_GetHoldersFullName
    AS
SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM AccountHolders

EXEC dbo.usp_GetHoldersFullName

  CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @Num DECIMAL(15, 2)
      AS
  SELECT FirstName, LastName
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
  HAVING SUM(a.Balance) > @Num
ORDER BY ah.FirstName, ah.LastName

CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15, 2), @Rate FLOAT, @Tears INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
	RETURN @Sum * (POWER(1 + @Rate, @Tears))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)