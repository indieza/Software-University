CREATE DATABASE Airport;

USE Airport;

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
);

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
);

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId VARCHAR(11) NOT NULL
);

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Type] VARCHAR(30) NOT NULL
);

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL
);

INSERT INTO Planes([Name], [Seats], [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541);

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag');

UPDATE Tickets
   SET Price *= 1.13
 WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad');

DELETE
  FROM Tickets
 WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim');
DELETE
  FROM Flights
 WHERE Destination = 'Ayn Halagim';

  SELECT Origin, Destination
    FROM Flights
ORDER BY Origin, Destination;

  SELECT *
    FROM Planes
   WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range];

  SELECT f.Id, SUM(t.Price) AS [Price]
    FROM Flights AS f
    JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY Price DESC, f.Id;

  SELECT TOP(10) p.FirstName, p.LastName, t.Price
    FROM Passengers AS p
    JOIN Tickets AS t ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.FirstName, p.LastName;

  SELECT lt.[Type], COUNT(lt.Id) AS MostUsedLuggage
    FROM LuggageTypes AS lt
    JOIN Luggages AS l ON l.LuggageTypeId = lt.Id
GROUP BY lt.[Type], lt.Id
ORDER BY MostUsedLuggage DESC, lt.[Type];

  SELECT p.FirstName + ' ' + p.LastName AS [Full Name], f.Origin, f.Destination
    FROM Passengers AS p
    JOIN Tickets AS t ON t.PassengerId = p.Id
    JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name], f.Origin, f.Destination;

  SELECT p.FirstName, p.LastName, p.Age
    FROM Passengers AS p
    FULL JOIN Tickets AS t ON t.PassengerId = p.Id
    WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName;

  SELECT p.PassportId, p.[Address]
    FROM Passengers AS p
    FULL JOIN Luggages AS l ON l.PassengerId = p.Id
   WHERE l.LuggageTypeId IS NULL
ORDER BY p.PassportId, p.[Address];

  SELECT p.FirstName, p.LastName, COUNT(t.PassengerId) AS [Total Trips]
    FROM Passengers AS p
    FULL JOIN Tickets AS t ON t.PassengerId = p.Id
GROUP BY p.FirstName, p.LastName
ORDER BY[Total Trips] DESC, p.FirstName, p.LastName;

  SELECT p.FirstName + ' ' + p.LastName AS [Full Name], 
         pl.[Name] AS [Plane Name],
		 f.Origin + ' - ' + f.Destination AS Trip,
		 lt.[Type]
    FROM Passengers AS p
    JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
	JOIN Planes AS pl ON pl.Id = f.PlaneId
	JOIN Luggages AS l ON l.Id = t.LuggageId
	JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], pl.[Name], f.Origin, f.Destination, lt.[Type];