--CREATE DATABASE Airport
--EXEC sp_changedbowner 'sa'
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)
--847-03-2587

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30)
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)
--
--INSERT
INSERT INTO Planes (Name, Seats, Range) VALUES 
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes (Type) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--UPDATE

UPDATE Tickets
 SET Price *= 1.13
 WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad')
 
--DELETE
DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. The "Tr" Planes
  SELECT Id, [Name], Seats, [Range]
    FROM Planes
   WHERE [Name] LIKE '%Tr%'
ORDER BY Id, Name, Seats, Range

--06. Flight Profits
  SELECT FlightId, SUM(Price) AS TotalPrice
    FROM Tickets
GROUP BY FlightId
ORDER BY TotalPrice DESC, FlightId

--07. Passenger Trips
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		   f.Origin,
		   f.Destination
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON f.Id = t.FlightId
    ORDER BY [Full Name], f.Origin, f.Destination

--08. Non Adventures People
    SELECT p.FirstName, p.LastName, p.Age
	  FROM Passengers AS p
 LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
     WHERE t.Id IS NULL
  ORDER BY p.Age DESC, p.FirstName, p.LastName

--09. Full Info
   SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		  pl.Name AS [Plane Name],
		  f.Origin + ' - ' + f.Destination AS [Trip],
		  lt.Type As [Luggage Type]
     FROM Passengers AS p
	 JOIN Tickets AS t ON t.PassengerId = p.Id
	 JOIN Flights AS f ON f.Id = t.FlightId
	 JOIN Planes AS pl ON pl.Id = f.PlaneId
	 JOIN Luggages AS l ON l.Id = t.LuggageId
	 JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], Name,Origin, Destination, Type

 --10. PSP
   SELECT p.Name, p.Seats, COUNT(t.Id) AS PassengersCount
     FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
 GROUP BY p.Name, p.Seats
 ORDER BY PassengersCount DESC, p.Name, p.Seats

--18. Vacation
CREATE FUNCTION udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
RETURNS VARCHAR(100)
AS
BEGIN

IF (@peopleCount <= 0)
BEGIN
	RETURN 'Invalid people count!'
END

DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)
IF (@tripId IS NULL)
BEGIN
	RETURN 'Invalid flight!'
END

DECLARE @ticketPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)

DECLARE @totalPrice DECIMAL(15, 2) = @ticketPrice * @peoplecount;

RETURN 'Total price ' + CAST(@totalPrice as VARCHAR(30));
END

--19
CREATE PROC usp_CancelFlights
AS
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime