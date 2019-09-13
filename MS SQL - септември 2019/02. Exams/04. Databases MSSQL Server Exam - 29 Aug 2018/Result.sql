CREATE DATABASE Supermarket;

USE Supermarket;

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
);

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone VARCHAR(12) NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL
);

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
);

CREATE TABLE OrderItems
(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT NOT NULL CHECK(Quantity >= 1),
	CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
);

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL,
	CONSTRAINT CHK_Shifts CHECK(CheckOut > CheckIn),
	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
);

INSERT INTO Employees(FirstName, LastName, Phone, Salary) VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25 ),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov',	'321-471-9982',	50.25);

INSERT INTO Items([Name], [Price], [CategoryId]) VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice',	5.32, 1),
('Glasses',	10,	8),
('Bottle of water',	1, 1);

UPDATE Items
   SET Price *= 1.27
 WHERE CategoryId IN (1, 2, 3);

DELETE
  FROM OrderItems
 WHERE OrderId = 48;
DELETE
  FROM Orders
 WHERE Id = 48;

  SELECT Id, FirstName
    FROM Employees
   WHERE Salary > 6500
ORDER BY FirstName, Id;

  SELECT FirstName + ' ' + LastName AS [Full Name], Phone
    FROM Employees
   WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone;

  SELECT e.FirstName, e.LastName, COUNT(o.Id) AS [Count]
    FROM Employees AS e
    JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [Count] DESC, e.FirstName;

  SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
    FROM Employees AS e
    JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName, e.Id
  HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work hours] DESC, e.Id;

  SELECT TOP(1) oi.OrderId, SUM(i.Price * oi.Quantity) AS TotalPrice
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY TotalPrice DESC;

  SELECT TOP(10) o.Id, MAX(i.Price) AS [ExpensivePrice], MIN(i.Price) AS [CheapPrice]
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY [ExpensivePrice] DESC, o.Id;

  SELECT e.Id, e.FirstName, e.LastName
    FROM Employees AS e
    FULL JOIN Orders AS o ON o.EmployeeId = e.Id
   WHERE o.Id IS NOT NULL
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY e.Id;

  SELECT e.Id, e.FirstName + ' ' + e.LastName AS [Full Name]
    FROM Employees AS e
    JOIN Shifts AS s ON s.EmployeeId = e.Id
   WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY e.Id;

  SELECT TOP(10) e.FirstName + ' ' + e.LastName AS [Full Name],
                 SUM(i.Price * oi.Quantity) AS [Total Price],
				 SUM(oi.Quantity) AS Items
    FROM Employees AS e
    JOIN Orders AS o ON o.EmployeeId = e.Id
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
   WHERE o.[DateTime] < '2018-06-15'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, Items DESC;

  SELECT e.FirstName + + ' ' + e.LastName AS [Full Name],
         CASE DATEPART(WEEKDAY, s.CheckIn)  
			WHEN 1 THEN 'Sunday' 
			WHEN 2 THEN 'Monday' 
			WHEN 3 THEN 'Tuesday' 
			WHEN 4 THEN 'Wednesday' 
			WHEN 5 THEN 'Thursday' 
			WHEN 6 THEN 'Friday' 
			WHEN 7 THEN 'Saturday' 
         END AS [Day of week]
    FROM Employees AS e
    FULL JOIN Orders AS o ON o.EmployeeId = e.Id
	JOIN Shifts AS s ON s.EmployeeId = e.Id
   WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id;