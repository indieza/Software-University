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
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id)
);

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0)
);

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
);

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL 
	                       CHECK(Purpose = 'Medical' OR Purpose = 'Technical' OR Purpose = 'Educational' OR Purpose = 'Military'),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id),
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id)
);

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumber NVARCHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) NOT NULL
		                           CHECK(JobDuringJourney = 'Pilot' OR
								         JobDuringJourney = 'Engineer' OR
										 JobDuringJourney = 'Trooper' OR
										 JobDuringJourney = 'Cleaner' OR
										 JobDuringJourney = 'Cook'),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id)
);

INSERT INTO Planets([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn');

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6);

UPDATE Spaceships
   SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12;

 DELETE
   FROM TravelCards
  WHERE JourneyId IN (1, 2, 3);
 DELETE 
   FROM Journeys
  WHERE Id IN (1, 2, 3);

  SELECT CardNumber, JobDuringJourney
    FROM TravelCards
ORDER BY CardNumber;

  SELECT Id, FirstName + ' ' + LastName AS FullName, Ucn
    FROM Colonists
ORDER BY FirstName, LastName, Id;

  SELECT id, FORMAT(JourneyStart, 'dd/MM/yyyy'), FORMAT(JourneyEnd, 'dd/MM/yyyy')
    FROM Journeys
   WHERE Purpose = 'Military'
ORDER BY JourneyStart;

  SELECT c.Id, c.FirstName + ' ' + c.LastName AS [full_name]
    FROM Colonists AS c
    JOIN TravelCards AS tc ON c.Id = tc.ColonistId
   WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id;