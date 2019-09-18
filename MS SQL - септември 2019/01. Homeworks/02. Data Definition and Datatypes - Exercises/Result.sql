-- Problem 4
INSERT INTO Towns([Id], [Name])
VALUES(1, 'Sofia'),
	  (2, 'Plovdiv'),
	  (3, 'Varna');
	  	  
INSERT INTO Minions([Id], [Name], [Age], [TownId])
VALUES(1, 'Kevin', 22, 1),
	  (2, 'Bob', 15, 3),
	  (3, 'Steward', NULL, 2);

-- Problem 7
CREATE TABLE People(
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Name] VARCHAR(30) NOT NULL,
[Picture] IMAGE,
[Height] DECIMAL(10, 2),
[Weight] DECIMAL(10, 2),
[Gender] VARCHAR(1) NOT NULL CHECK([Gender] = 'f' OR [Gender] = 'm'),
[Birthdate] DATE NOT NULL,
[Biography] VARCHAR(MAX)
);

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES('Pesho', NULL, 1.239, 69.236, 'm', '2005/01/13', NULL),
('Minka', NULL, 1.596, 56.231, 'f', '1996/09/15', 'Az sam Minka'),
('Gosho', NULL, 2.102, 105.36, 'm', '2001/02/23', NULL),
('Penka', NULL, 2.012, 68.236, 'f', '1996/02/11', NULL),
('Petranka', NULL, 1.369, 12.2365, 'f', '1996/06/03', NULL);

-- Problem 8
CREATE TABLE Users(
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] IMAGE,
[LastLoginTime] DATETIME,
[IsDeleted] VARCHAR(5) NOT NULL CHECK([IsDeleted] = 'true' OR [IsDeleted] = 'false')
);

INSERT INTO Users([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('Pesho', '1234', NULL, NULL, 'false'),
('Pesho1', '12345', NULL, NULL, 'false'),
('Pesho2', '123456', NULL, NULL, 'true'),
('Pesho3', '1234567', NULL, NULL, 'true'),
('Pesho4', '12345678', NULL, NULL, 'false');

-- Problem 13
CREATE TABLE Directors(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DirectorName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Genres(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[GenreName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Categories(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[CategoryName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Movies(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES Directors([Id]) NOT NULL,
[CopyrightYear] INT NOT NULL,
[Length] INT NOT NULL,
[GenreId] INT FOREIGN KEY REFERENCES Genres([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
[Rating] INT,
[Notes] VARCHAR(MAX)
);

INSERT INTO Directors([DirectorName], [Notes])
VALUES('Pesho', NULL),
('Gosho', 'Test * 23'),
('Milen', NULL),
('Orlando', 'Olqka e hood'),
('Penka', 'Penka ataka');

INSERT INTO Genres([GenreName], [Notes])
VALUES('Patka', NULL),
('Gorila', NULL),
('Mule', NULL),
('Olqk', NULL),
('Panda', NULL);

INSERT INTO Categories([CategoryName], [Notes])
VALUES('Comedy', NULL),
('Action', NULL),
('Serial', NULL),
('Social', NULL),
('Nature', NULL);

INSERT INTO Movies([DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES(3, 1969, 569, 4, 5, 25, NULL),
(1, 1999, 36, 3, 3, 100, NULL),
(2, 1990, 56, 1, 2, 8, NULL),
(4, 2000, 2, 2, 1, 2, NULL),
(5, 2001, 256, 5, 4, -3, NULL);

-- Problem 14
CREATE TABLE Categories(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[CategoryName] VARCHAR(20) NOT NULL,
[DailyRate] INT,
[WeeklyRate] INT,
[MonthlyRate] INT,
[WeekendRate] INT
);

INSERT INTO Categories([CategoryName])
VALUES('OF-Road'),
('Speed'),
('Drag Race');

CREATE TABLE Cars(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[PlateNumber] INT NOT NULL,
[Manufacturer] VARCHAR(20) NOT NULL, 
[Model] VARCHAR(20), 
[CarYear] INT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
[Doors] INT NOT NULL,
[Picture] IMAGE,
[Condition] VARCHAR(100),
[Available] VARCHAR(5) NOT NULL CHECK([Available] = 'Yes' Or [Available] = 'No')
);

INSERT INTO Cars([PlateNumber], [Manufacturer], [CarYear], [CategoryId], [Doors], [Available])
VALUES(20, 'Pesho', 1999, 2, 5, 'Yes'),
(30, 'Pesho2', 2001, 1, 3, 'No'),
(40, 'Peshoy', 2018, 3, 2, 'Yes');

CREATE TABLE Employees(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[Title] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName])
VALUES('Pesho', 'Peshov'),
('Gosho', 'Penev'),
('Mario', 'Manchev');

CREATE TABLE Customers(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DriverLicenceNumber] INT NOT NULL,
[FullName] VARCHAR(100) NOT NULL, 
[Address] VARCHAR(30),
[City] VARCHAR(20), 
[ZIPCode] INT,
[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([DriverLicenceNumber], [FullName])
VALUES(123562, 'Aleks Penev'),
(2560, 'Toma Tomov'),
(236549, 'Milen Malov');

CREATE TABLE RentalOrders(
[Id]INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
[CustomerId]  INT FOREIGN KEY REFERENCES Customers([Id]) NOT NULL,
[CarId]  INT FOREIGN KEY REFERENCES Cars([Id]) NOT NULL, 
[TankLevel] INT, 
[KilometrageStart] INT NOT NULL, 
[KilometrageEnd] INT, 
[TotalKilometrage] INT,
[StartDate] DATETIME,
[EndDate] DATETIME, 
[TotalDays] INT, 
[RateApplied] INT, 
[TaxRate] INT, 
[OrderStatus] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO RentalOrders([EmployeeId], [CustomerId], [CarId], [KilometrageStart])
VALUES(2, 1, 3, 1253620),
(1, 2, 3, 1236322036),
(3, 3, 1, 1523692);

-- Problem 15
CREATE TABLE Employees(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[FirstName] VARCHAR(20) NOT NULL, 
[LastName] VARCHAR(20) NOT NULL, 
[Title] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName])
VALUES('Peshp', 'Penev'),
('Milen', 'Markov'),
('Filip', 'Maskov');

CREATE TABLE Customers(
[AccountNumber] INT PRIMARY KEY NOT NULL, 
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL, 
[PhoneNumber] VARCHAR(12), 
[EmergencyName] VARCHAR(20), 
[EmergencyNumber] VARCHAR(12), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([AccountNumber], [FirstName], [LastName])
VALUES(12, 'Peshp', 'Penev'),
(13, 'Milen', 'Markov'),
(14, 'Filip', 'Maskov');

CREATE TABLE RoomStatus(
[RoomStatus] VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Full' OR RoomStatus = 'Half'),
[Notes] VARCHAR(MAX)
);

INSERT INTO RoomStatus([RoomStatus])
VALUES('Free'),
('Half'),
('Full');

CREATE TABLE RoomTypes(
[RoomType] VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO RoomTypes([RoomType])
VALUES('Tripple'),
('Double'),
('Mezonet');

CREATE TABLE BedTypes(
[BedType]  VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO BedTypes([BedType])
VALUES('Single'),
('Double'),
('Tripple');

CREATE TABLE Rooms(
[RoomNumber] INT PRIMARY KEY NOT NULL, 
[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes([RoomType]) NOT NULL,
[BedType] VARCHAR(20) FOREIGN KEY REFERENCES BedTypes([BedType]) NOT NULL,
[Rate] INT,
[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]) NOT NULL, 
[Notes] VARCHAR(MAX)
);

INSERT INTO Rooms([RoomNumber], [RoomType], [BedType], [RoomStatus])
VALUES(123, 'Tripple', 'Tripple', 'Free'),
(1254, 'Mezonet', 'Single', 'Full'),
(2563, 'Double', 'Single', 'Half');

CREATE TABLE Payments(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
[PaymentDate] DATETIME,
[AccountNumber] INT,
[FirstDateOccupied] DATETIME,
[LastDateOccupied] DATETIME,
[TotalDays] INT,
[AmountCharged] DECIMAL(15, 2),
[TaxRate] INT, 
[TaxAmount] DECIMAL(15, 2),
[PaymentTotal] DECIMAL(15, 2), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Payments([EmployeeId])
VALUES(2),
(3),
(1);

CREATE TABLE Occupancies(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL, 
[DateOccupied] DATETIME, 
[AccountNumber] INT, 
[RoomNumber] INT, 
[RateApplied] INT, 
[PhoneCharge] INT, 
[Notes] VARCHAR(MAX)
);

INSERT INTO Occupancies([EmployeeId])
VALUES(2),
(1),
(3);

-- Problem 19
SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

-- Problem 20
SELECT * FROM Towns ORDER BY Name;
SELECT * FROM Departments ORDER BY Name;
SELECT * FROM Employees ORDER BY Salary DESC;

-- Problem 21
SELECT [Name] FROM Towns
ORDER BY Name;

SELECT [Name] FROM Departments
ORDER BY Name;

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC;

-- Problem 22
UPDATE Employees
SET [Salary] = [Salary] + [Salary] * 0.10;
SELECT [Salary] FROM Employees;

-- Problem 23
UPDATE Payments
SET [TaxRate] -= [TaxRate] * 0.03;
SELECT [TaxRate] FROM Payments;

-- Problem 24
TRUNCATE Table Occupancies; 