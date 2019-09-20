-- Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE Salary > 35000

EXEC dbo.usp_GetEmployeesSalaryAbove35000

-- Problem 2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE Salary >= @Number

EXEC dbo.usp_GetEmployeesSalaryAboveNumber @Number = 48100

-- Problem 3
CREATE PROCEDURE usp_GetTownsStartingWith @Input VARCHAR(10)
    AS
SELECT [Name]
  FROM Towns
 WHERE [Name] LIKE @Input + '%'

EXEC dbo.usp_GetTownsStartingWith @Input = 'b'

-- Problem 4
CREATE PROCEDURE usp_GetEmployeesFromTown @TownName VARCHAR(50)
    AS
SELECT e.FirstName, e.LastName
  FROM Employees AS e
  JOIN Addresses AS a ON a.AddressID = e.AddressID
  JOIN Towns AS T ON t.TownID = a.TownID
 WHERE t.[Name] = @TownName

EXEC dbo.usp_GetEmployeesFromTown @TownName = 'Sofia'

-- Problem 5
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

-- Problem 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel @Level VARCHAR(30)
    AS
SELECT FirstName, LastName
  FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level

EXEC dbo.usp_EmployeesBySalaryLevel @Level = 'High'

-- Problem 7
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(20), @Word VARCHAR(20))
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

-- Problem 8
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

-- Problem 9
CREATE PROCEDURE usp_GetHoldersFullName
    AS
SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM AccountHolders

EXEC dbo.usp_GetHoldersFullName

-- Problem 10
  CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @Num DECIMAL(15, 2)
      AS
  SELECT FirstName, LastName
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
  HAVING SUM(a.Balance) > @Num
ORDER BY ah.FirstName, ah.LastName

-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15, 2), @Rate FLOAT, @Tears INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
	RETURN @Sum * (POWER(1 + @Rate, @Tears))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- Problem 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountID INT, @Rate FLOAT)
    AS
SELECT a.AccountHolderId AS [Account Id],
       ah.FirstName,
	   ah.LastName,
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(a.Balance, @Rate, 5) AS [Balance in 5 years]
  FROM Accounts AS a
  JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
 WHERE a.Id = @AccountID

EXEC usp_CalculateFutureValueForAccount 1, 0.1

-- Problem 13
CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(50))
RETURNS TABLE
AS
RETURN
	SELECT SUM(K.Cash) AS [SumCash]
      FROM (
    SELECT ug.Cash AS [Cash], ROW_NUMBER() OVER (PARTITION BY ug.GameId ORDER BY ug.Cash DESC) AS [Row]
      FROM Games AS g
      JOIN UsersGames AS ug ON ug.GameId = g.Id
     WHERE g.[Name] = @GameName) AS k
     WHERE k.[Row] % 2 = 1

SELECT dbo.ufn_CashInUsersGames('Lily Stargazer')
SELECT dbo.ufn_CashInUsersGames('Love in a mist')

-- Problem 14
CREATE TABLE Logs
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	NewSum DECIMAL(15, 2),
	OldSum DECIMAL(15, 2)
);

CREATE TRIGGER tr_AddBalance ON dbo.Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(15, 2) = (SELECT i.Balance FROM INSERTED i)
DECLARE @oldSum DECIMAL(15, 2) = (SELECT d.Balance FROM DELETED d)
DECLARE @accountId INT = (SELECT i.Id FROM INSERTED i)

INSERT INTO dbo.Logs
(
    AccountId,
    NewSum,
    OldSum
)
VALUES
(
	@accountId,
	@newSum,
	@oldSum
)

SELECT * FROM dbo.Accounts a
WHERE a.Id = 1

UPDATE dbo.Accounts
SET
    dbo.Accounts.Balance += 10
WHERE dbo.Accounts.Id = 1

SELECT * FROM dbo.Logs l

-- Problem 15
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES dbo.Accounts(Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX)
);

CREATE TRIGGER tr_LogInfo ON Logs FOR INSERT
AS
DECLARE @accountId INT = (SELECT i.AccountId FROM INSERTED i)
DECLARE @oldSum DECIMAL(15, 2) = (SELECT i.OldSum FROM INSERTED i)
DECLARE @newSum DECIMAL(15, 2) = (SELECT i.NewSum FROM INSERTED i)

INSERT INTO dbo.NotificationEmails
(
    Recipient,
    [Subject],
    Body
)
VALUES
(
	@accountId,
	'Balance change for account: ' + CAST(@accountId AS VARCHAR(15)),
	'On ' + CAST(GETDATE() AS VARCHAR(50)) + ' your balance was changed from ' +
	CAST(@oldSum AS VARCHAR(30)) + ' to ' +
	CAST(@newSum AS VARCHAR(50)) + '.'
)

SELECT * FROM dbo.Accounts a WHERE a.Id = 1

UPDATE dbo.Accounts
SET
    dbo.Accounts.Balance += 100 
WHERE Id = 1

SELECT* FROM dbo.NotificationEmails ne