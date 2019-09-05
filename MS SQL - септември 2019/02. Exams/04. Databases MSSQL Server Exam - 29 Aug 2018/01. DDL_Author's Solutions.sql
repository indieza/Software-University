USE master
GO

CREATE DATABASE Supermarket
GO

USE Supermarket
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id),
	ItemId INT FOREIGN KEY REFERENCES Items(Id),
	Quantity INT NOT NULL CHECK(Quantity >= 1)

	CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL

	
	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
)

ALTER TABLE Shifts 
ADD CONSTRAINT CHK_CheckDates CHECK(CheckIn < CheckOut)


--02. Insert
INSERT INTO Employees (FirstName, LastName, Phone, Salary) VALUES
  ('Stoyan',	'Petrov',	'888-785-8573',	500.25),
  ('Stamat',	'Nikolov',	'789-613-1122',	999995.25),
  ('Evgeni',	'Petkov',	'645-369-9517',	1234.51),
  ('Krasimir',	'Vidolov',	'321-471-9982',	50.25)

INSERT INTO Items (Name, Price, CategoryId) VALUES
  ('Tesla battery',154.25	,8),
  ('Chess',	30.25,	8),
  ('Juice',	5.32,1),
  ('Glasses',10,	8),
  ('Bottle of water',	1,	1)

--03. Update
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2, 3)

--04. Delete

DELETE FROM OrderItems
WHERE OrderID = 48

--5. Richest People
SELECT Id,FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

--6. Cool Phone Numbers
SELECT
  FirstName + ' ' + LastName AS [Full Name],
  Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

--7. Employee Statistics
SELECT
  FirstName,
  LastName,
  COUNT(o.Id) AS [Count]
FROM Employees AS e
  JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName
ORDER BY [Count] DESC, FirstName


--8. Hard Workers Club
SELECT
  FirstName,
  LastName,
  AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
FROM Employees AS e
  JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work Hours] DESC, e.Id

--9. The Most Expensive Order 
SELECT TOP (1)
  o.Id,
  SUM(i.Price * oi.Quantity) AS [TotalPrice]
FROM Orders As o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  JOIN Items As i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY TotalPrice DESC

--10. Rich Item, Poor Item
SELECT TOP (10)
  o.Id,
  MAX(i.Price) AS [ExpensivePrice],
  MIN(i.Price)    [CheapPrice]
FROM Orders AS o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id ASC

-- 11. Cashiers
SELECT DISTINCT
  e.Id,
  e.FirstName,
  e.LastName
FROM Employees AS e
  RIGHT JOIN Orders AS o ON o.EmployeeId = e.Id
ORDER BY e.Id

-- 12.Lazy Employees
SELECT DISTINCT
  e.Id,
  FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees AS e
  JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

--13. Sellers
SELECT TOP 10 E.FirstName + ' ' + E.LastName AS [Full Name],
       SUM(OI.Quantity  * I.Price) AS [Total Price],
       SUM(OI.Quantity) AS ItemsCount
FROM Orders O
JOIN Employees E on O.EmployeeId = E.Id
JOIN OrderItems OI on O.Id = OI.OrderId
JOIN Items I on OI.ItemId = I.Id
WHERE O.DateTime < '2018-06-15'
GROUP BY E.Id, E.FirstName, E.LastName
ORDER BY [Total Price] DESC, ItemsCount DESC


--14 Tough days
SELECT
  e.FirstName + ' ' + e.LastName AS FullName,
  CASE
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 2
    THEN 'Monday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 3
    THEN 'Tuesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 4
    THEN 'Wednesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 5
    THEN 'Thursday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 6
    THEN 'Friday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 7
    THEN 'Saturday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 1
    THEN 'Sunday'
  END                            as DayOfWeek
FROM Employees AS e
  LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15. Top Order per Employee 
SELECT emp.FirstName + ' ' + emp.LastName AS FullName, DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, e.TotalPrice AS TotalPrice FROM 
 (
    SELECT o.EmployeeId, SUM(oi.Quantity * i.Price) AS TotalPrice, o.DateTime,
	ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.EmployeeId, o.Id, o.DateTime
) AS e 
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC


--16 Average profit per day
SELECT
DATEPART(DAY, o.DateTime)  AS [DayOfMonth],
CAST(AVG(i.Price * oi.Quantity)  AS decimal(15, 2)) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY DayOfMonth ASC

--17
SELECT
  i.Name,
  c.Name,
  SUM(oi.Quantity)  As [Count],
  SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  RIGHT JOIN Items AS i ON i.Id = oi.ItemId
  JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.Name, c.Name
ORDER BY TotalPrice DESC, [Count] DESC

--18 Promotion day
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
	BEGIN
	 RETURN 'One of the items does not exists!'
	END

	IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
	BEGIN
	 RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @NewFirstItemPrice DECIMAL(15,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
	DECLARE @NewSecondItemPrice DECIMAL(15,2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
	DECLARE @NewThirdItemPrice DECIMAL(15,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100)

	DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	RETURN @FirstItemName + ' price: ' + CAST(ROUND(@NewFirstItemPrice,2) as varchar) + ' <-> ' +
		   @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondItemPrice,2) as varchar)+ ' <-> ' +
		   @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
END

--19
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

	IF (@order IS NULL)
	BEGIN
		;THROW 51000, 'The order does not exist!', 1
	END

	DECLARE @OrderDate DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
	DECLARE @DateDiff INT = (SELECT DATEDIFF(DAY, @OrderDate, @CancelDate))

	IF (@DateDiff > 3)
	BEGIN
		;THROW 51000, 'You cannot cancel the order!', 2
	END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId
END


--20 Cancel order
CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)

CREATE TRIGGER t_DeleteOrders
    ON OrderItems AFTER DELETE
    AS
    BEGIN
	  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	  SELECT d.OrderId, d.ItemId, d.Quantity
	    FROM deleted AS d
    END


