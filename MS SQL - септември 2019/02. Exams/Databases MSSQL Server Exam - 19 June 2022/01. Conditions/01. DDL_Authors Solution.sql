CREATE DATABASE Zoo
USE Zoo

--1. Database design
CREATE TABLE Owners(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT IDENTITY PRIMARY KEY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT IDENTITY PRIMARY KEY,
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id),
)

CREATE TABLE Animals(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT IDENTITY PRIMARY KEY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--2. Insert
INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

--3. Update
SELECT * FROM Animals
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

--4. Delete
DELETE FROM Volunteers
WHERE DepartmentId = 2

SELECT * FROM VolunteersDepartments
DELETE FROM VolunteersDepartments
WHERE Id = 2

--5. Volunteers
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId FROM Volunteers
ORDER BY Name, AnimalId, DepartmentId

--6. Animals data
SELECT Name, at.AnimalType, FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
ORDER BY Name

--7. Owners and Their Animals
SELECT TOP(5) o.Name AS Owner, COUNT(*) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, Owner ASC

--8. Owners, Animals and Cages
SELECT CONCAT(o.Name, '-', a.Name) as OwnersAnimals , o.PhoneNumber, c.Id as CageId
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.id
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Cages AS c ON c.Id = ac.CageId
WHERE AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

--9. Volunteers
SELECT v.Name, v.PhoneNumber,
SUBSTRING(Address, CHARINDEX(',', Address) + 2, LEN(v.Address)) AS Address
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE vd.DepartmentName = 'Education program assistant'
AND v.Address LIKE ('%Sofia%')
ORDER BY v.Name

--10. Animals for Adoption
SELECT Name, YEAR(a.BirthDate) AS BirthYear, at.AnimalType 
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
WHERE OwnerId IS NULL
	AND AnimalTypeId != 3
	AND DATEDIFF(YEAR, BirthDate, '01/01/2022') < 5
ORDER BY Name

--11. All Volunteers in a Department
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR (30))
RETURNS INT
AS
BEGIN	
	RETURN(SELECT COUNT(v.Id) FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
	WHERE vd.DepartmentName = @VolunteersDepartment)
END
GO
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--12. Animals with Owner or Not
GO
CREATE PROC usp_AnimalsWithOwnersOrNot
		(@AnimalName VARCHAR(30))
AS
BEGIN
IF (SELECT OwnerId FROM Animals
			WHERE Name = @AnimalName) IS NULL
	BEGIN 
		SELECT Name, 'For adoption' AS OwnerName
			FROM Animals
			WHERE Name = @AnimalName
	END
	ELSE
	BEGIN
		SELECT a.Name, o.Name as OwnerName
			FROM Animals AS a
			JOIN Owners AS o ON o.Id = a.OwnerId
			WHERE a.Name = @AnimalName
	END
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
GO