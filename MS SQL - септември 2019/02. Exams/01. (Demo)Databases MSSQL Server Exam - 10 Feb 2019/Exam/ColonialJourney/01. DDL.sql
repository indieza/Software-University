CREATE DATABASE ColonialJourney;

USE [ColonialJourney];

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES [dbo].[Planets]([Id]) NOT NULL
);

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT NOT NULL DEFAULT(0)
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
	Purpose VARCHAR(11) NOT NULL CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES [dbo].[Spaceports]([Id]) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES [dbo].[Spaceships]([Id]) NOT NULL
);

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumber CHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) NOT NULL CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES [dbo].[Colonists]([Id]) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES [dbo].[Journeys]([Id]) NOT NULL
);