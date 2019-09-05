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

--05. Trips
  SELECT Origin, Destination
    FROM Flights
ORDER BY Origin, Destination

--06. The "Tr" Planes
  SELECT Id, [Name], Seats, [Range]
    FROM Planes
   WHERE [Name] LIKE '%Tr%'
ORDER BY Id, Name, Seats, Range

--07. Flight Profits
  SELECT FlightId, SUM(Price) AS TotalPrice
    FROM Tickets
GROUP BY FlightId
ORDER BY TotalPrice DESC, FlightId

--08. Passanger and Prices
  SELECT TOP(10) p.FirstName, p.LastName, t.Price
    FROM Tickets AS t
 	JOIN Passengers AS p ON p.Id = t.PassengerId
ORDER BY t.Price DESC, p.FirstName, p.LastName

--09. Most Used Luggages
  SELECT lt.[Type] , COUNT(lt.Id) AS MostUsedLuggage
    FROM Luggages AS l
LEFT JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
GROUP BY lt.[Type]
ORDER BY MostUsedLuggage DESC, lt.[Type]

--10. Passanger Trips
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		   f.Origin,
		   f.Destination
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON f.Id = t.FlightId
    ORDER BY [Full Name], f.Origin, f.Destination

--11. Non Adventures People
    SELECT p.FirstName, p.LastName, p.Age
	  FROM Passengers AS p
 LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
     WHERE t.Id IS NULL
  ORDER BY p.Age DESC, p.FirstName, p.LastName
	 
--12. Lost Luggages
   SELECT p.PassportId, p.Address 
     FROM Passengers AS p
LEFT JOIN Luggages AS l ON l.PassengerId = p.Id
    WHERE l.Id IS NULL
 ORDER BY p.PassportId, p.Address

--13. Count of Trips
   SELECT p.FirstName, p.LastName, COUNT(t.Id) AS TotalTrips
     FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
 GROUP BY p.FirstName, p.LastName
 ORDER BY TotalTrips DESC, p.FirstName, p.LastName

--14. Full Info
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

--15. Most Expesnive Trips
SELECT k.FirstName, k.LastName, k.Destination, k.Price
  FROM (
	SELECT p.FirstName, p.LastName, f.Destination, t.Price,
		   DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) As PriceRank
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON f.Id = t.FlightId
  ) AS k 
  WHERE k.PriceRank = 1
  ORDER BY k.Price DESC, k.FirstName, k.LastName, k.Destination

--16 Destinations Info
   SELECT f.Destination, COUNT(t.Id) AS [Count]
     FROM Flights AS f
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
 GROUP BY f.Destination
 ORDER BY [Count] DESC, f.Destination

 --17. PSP
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

--20
CREATE TABLE DeletedPlanes
(
	Id INT,
	Name VARCHAR(30),
	Seats INT,
	Range INT
)

CREATE TRIGGER tr_DeletedPlanes ON Planes 
AFTER DELETE AS
  INSERT INTO DeletedPlanes (Id, Name, Seats, Range) 
      (SELECT Id, Name, Seats, Range FROM deleted)
