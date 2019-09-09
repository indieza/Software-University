CREATE DATABASE ColonialJourney;

USE ColonialJourney;

CREATE TABLE Planets
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE Spaceports
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
);

CREATE TABLE Spaceships
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0 NOT NULL
);

CREATE TABLE Colonists
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
);

CREATE TABLE Journeys
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL CHECK(Purpose = 'Medical' OR
	                                   Purpose = 'Technical' OR
									   Purpose = 'Educational' OR
									   Purpose = 'Military'),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
);

CREATE TABLE TravelCards
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CardNumber VARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) NOT NULL CHECK(JobDuringJourney = 'Pilot' OR
	                                           JobDuringJourney = 'Engineer' OR
											   JobDuringJourney = 'Trooper' OR
											   JobDuringJourney = 'Cleaner' OR
											   JobDuringJourney = 'Cook'),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
);

INSERT INTO Planets([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn');

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda',	4),
('Falcon9',	'SpaceX', 1),
('Bed',	'Vidolov', 6);

UPDATE Spaceships
   SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12;

DELETE
  FROM TravelCards
 WHERE JourneyId IN(1, 2, 3);
DELETE
  FROM Journeys
 WHERE Id IN(1, 2, 3);

  SELECT CardNumber, JobDuringJourney
    FROM TravelCards
ORDER BY CardNumber;

  SELECT Id, FirstName + ' ' + LastName AS [FullName], Ucn
    FROM Colonists
ORDER BY FirstName, LastName, Id;

  SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy'), FORMAT(JourneyEnd, 'dd/MM/yyyy')
    FROM Journeys
   WHERE Purpose = 'Military'
ORDER BY JourneyStart;

  SELECT c.Id, c.FirstName + ' ' + c.LastName AS [full_name]
    FROM Colonists as c
    JOIN TravelCards AS t ON ColonistId = c.Id
   WHERE t.JobDuringJourney = 'Pilot'
ORDER BY c.Id;

SELECT COUNT(*) AS [Count]
  FROM TravelCards AS tc
  JOIN Journeys AS j ON tc.JourneyId = j.Id
  JOIN Spaceships AS s ON s.Id = j.SpaceshipId
 WHERE j.Purpose = 'Technical';

  SELECT TOP(1) s.[Name] AS [SpaceshipName], ss.[Name] AS [SpaceportName]
    FROM Spaceships AS s
    JOIN Journeys AS j ON s.Id = j.SpaceshipId
    JOIN Spaceports AS ss ON j.DestinationSpaceportId = ss.Id
ORDER BY s.LightSpeedRate DESC;

  SELECT s.[Name], s.Manufacturer
    FROM Colonists AS c
    JOIN TravelCards AS tc ON tc.ColonistId = c.Id
    JOIN Journeys AS j ON j.Id = tc.JourneyId
    JOIN Spaceships AS s ON s.Id = j.SpaceshipId
   WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name];

  SELECT p.[Name] AS [PlanetName], s.[Name] AS [SpaceportName]
    FROM Planets AS p
    JOIN Spaceports AS S ON s.PlanetId = p.Id
    JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
   WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC;