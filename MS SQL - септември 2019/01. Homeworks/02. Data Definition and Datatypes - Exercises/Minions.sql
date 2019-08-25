CREATE DATABASE Minions;
USE Minions;

SET IDENTITY_INSERT Towns OFF;
SET IDENTITY_INSERT Towns ON;
SET IDENTITY_INSERT Minions ON;
SET IDENTITY_INSERT Minions OFF;

-- Create Table Minions
CREATE TABLE Minions([Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
[Age] INT);

-- Create Table Towns
CREATE TABLE Towns([Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20)	NOT NULL);

-- Connect Table Towns Into Table Minions
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns([Id]);

-- Insert Colums And Add Values
INSERT INTO Towns([Id], [Name])
VALUES(1, 'Sofia'),
	  (2, 'Plovdiv'),
	  (3, 'Varna');
	
-- Insert Colums And Add Values
INSERT INTO Minions([Id], [Name], [Age], [TownId])
VALUES(1, 'Kevin', 22, 1),
	  (2, 'Bob', 15, 3),
	  (3, 'Steward', NULL, 2);