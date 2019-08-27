CREATE DATABASE CarRental;
USE CarRental;

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