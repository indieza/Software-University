CREATE DATABASE ColonialJourney;

USE ColonialJourney;

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
);

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0)
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(20) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
);

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL CHECK(Purpose = 'Medical' OR
									   Purpose = 'Technical' OR
									   Purpose = 'Educational' OR
									   Purpose = 'Military'),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports([Id]) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships([Id]) NOT NULL
);

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumber CHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) NOT NULL CHECK(JobDuringJourney = 'Pilot' OR
									           JobDuringJourney = 'Engineer' OR
											   JobDuringJourney = 'Trooper' OR
											   JobDuringJourney = 'Cleaner' OR
											   JobDuringJourney = 'Cook'),
	ColonistId INT FOREIGN KEY REFERENCES Colonists([Id]) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys([Id]) NOT NULL
);

-- 02. Insert
INSERT INTO [dbo].[Planets]([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn');

INSERT INTO Spaceships([Name], [Manufacturer], [LightSpeedRate]) VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6);

-- 03. Update
UPDATE Spaceships
   SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12;

-- 04. Delete
DELETE TravelCards
 WHERE JourneyId IN(1, 2, 3);

DELETE Journeys
 WHERE Id IN(1, 2, 3);

-- 05. Select all travel cards
  SELECT CardNumber, JobDuringJourney
    FROM TravelCards
ORDER BY CardNumber;

-- 06. Select all colonists
  SELECT Id, FirstName + ' ' + LastName AS [FullName], Ucn
    FROM Colonists
ORDER BY FirstName, LastName, Id;

-- 07. Select all military journeys
  SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy'), FORMAT(JourneyEnd, 'dd/MM/yyyy')
    FROM Journeys
   WHERE Purpose = 'Military'
ORDER BY JourneyStart;

-- 08. Select all pilots
  SELECT c.Id, c.FirstName + ' ' + c.LastName AS [full_name]
    FROM Colonists AS c
    JOIN TravelCards AS tc ON tc.ColonistId = c.Id
   WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id;

-- 09. Count colonists
SELECT COUNT(*) AS [count]
  FROM Colonists AS c
  JOIN TravelCards AS tc ON tc.ColonistId = c.Id
  JOIN Journeys AS j ON j.Id = tc.JourneyId
 WHERE j.Purpose = 'Technical';

-- 10. Select the fastest spaceship
  SELECT TOP(1) s.[Name], ss.[Name]
    FROM Spaceships AS s
    JOIN Journeys AS j ON j.SpaceshipId = s.Id
    JOIN Spaceports AS ss ON ss.Id = j.DestinationSpaceportId
ORDER BY s.LightSpeedRate DESC;

-- 11. Select spaceships with pilots younger than 30 years
  SELECT s.[Name], s.Manufacturer
    FROM Spaceships AS s
    JOIN Journeys As j ON j.SpaceshipId = s.Id
    JOIN TravelCards As tc ON tc.JourneyId = j.Id
    JOIN Colonists As c ON c.Id = tc.ColonistId
   WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
ORDER BY s.[Name];

-- 12. Select all educational mission planets and spaceports
  SELECT p.[Name], s.[Name]
    FROM Planets AS p
    JOIN Spaceports AS s ON s.PlanetId = p.Id
    JOIN Journeys As j ON j.DestinationSpaceportId = s.Id
   WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC;

-- 13. Select all planets and their journey count
  SELECT Planets.PlanetName, COUNT(Planets.PlanetName) AS [JourneysCount]
    FROM (
  SELECT p.[Name] AS [PlanetName]
    FROM Planets AS p
    JOIN Spaceports As s ON s.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id) AS Planets
GROUP BY Planets.PlanetName
ORDER BY JourneysCount DESC, Planets.PlanetName;

-- 14. Select the shortest journey
  SELECT TOP(1) k.Id, k.PlanetName, k.SpaceportName, k.Purpose
    FROM (
  SELECT j.Id, p.[Name] AS [PlanetName],
         s.[Name] As [SpaceportName],
  	     j.Purpose,
  	     DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd) AS [Days]
    FROM Journeys AS j
    JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
    JOIN Planets AS p ON p.Id = s.PlanetId) AS k
ORDER BY k.[Days];

-- 15. Select the less popular job


-- 18. Get Colonists Count
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
             FROM Colonists AS c
             JOIN TravelCards AS tc ON tc.ColonistId = c.Id
             JOIN Journeys AS j ON j.Id = tc.JourneyId
             JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
             JOIN Planets AS p ON p.Id = s.PlanetId
            WHERE p.[Name] = @PlanetName)
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')

-- 19. Change Journey Purpose
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(50))
    AS
DECLARE @targetJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

IF(@targetJourneyId IS NULL)
	RAISERROR('The journey does not exist!', 16, 1)

DECLARE @targetPurpose VARCHAR(50) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

IF(@targetPurpose = @NewPurpose)
	RAISERROR('You cannot change the purpose!', 16, 2)

UPDATE Journeys
   SET Purpose = @NewPurpose
 WHERE Id = @JourneyId

EXEC usp_ChangeJourneyPurpose 1, 'Technical'
SELECT * FROM Journeys
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'

-- 20. Deleted Journeys  (Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
CREATE TABLE DeletedJourneys
(
	Id INT,
	JourneyStart DATETIME,
	JourneyEnd DATETIME,
	Purpose VARCHAR(11),
	DestinationSpaceportId INT,
	SpaceshipId INT
);

CREATE TRIGGER tr_DeletedJourneys ON [dbo].[Journeys] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[DeletedJourneys]
	(
	    [Id],
	    [JourneyStart],
	    [JourneyEnd],
	    [Purpose],
	    [DestinationSpaceportId],
	    [SpaceshipId]
	)
	SELECT * FROM [DELETED] AS d
END

DELETE FROM TravelCards
WHERE JourneyId =  1

DELETE FROM Journeys
WHERE Id =  1