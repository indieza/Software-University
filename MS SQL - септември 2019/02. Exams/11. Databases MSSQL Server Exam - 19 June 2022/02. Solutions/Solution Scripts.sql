CREATE DATABASE Zoo;

USE Zoo;

 --01. DDL
CREATE TABLE Owners(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	[Name] varchar(50) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
	[Address] varchar(50) NULL,
);

CREATE TABLE AnimalTypes(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	AnimalType varchar(30) NOT NULL,
);

CREATE TABLE Cages(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	AnimalTypeId int FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL,
);

CREATE TABLE Animals(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	[Name] varchar(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId int FOREIGN KEY REFERENCES Owners(Id) NULL,
	AnimalTypeId int FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL,
);

CREATE TABLE AnimalsCages(
	CageId int FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId int FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY(CageId, AnimalId),
);

CREATE TABLE VolunteersDepartments(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	DepartmentName varchar(30) NOT NULL,
);

CREATE TABLE Volunteers(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	[Name] varchar(50) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
	[Address] varchar(50) NULL,
	AnimalId int FOREIGN KEY REFERENCES Animals(Id) NULL,
	DepartmentId int FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
);

--02. Insert
INSERT INTO Volunteers ([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
VALUES
	('Anita Kostova', '0896365412',	'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', null, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', null, 31, 5);

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', null, 1),
	('Tuatara', '2021-06-30', 2, 4);

--03. Update
UPDATE Animals
   SET OwnerId = 4
 WHERE OwnerId IS NULL;

--04. DELETE
DELETE
  FROM Volunteers
 WHERE DepartmentId = 2;
DELETE
  FROM VolunteersDepartments
 WHERE Id = 2;

--05. Volunteers
SELECT [Name], PhoneNumber, [Address], AnimalId, DepartmentId
  FROM Volunteers
ORDER BY [Name] ASC, AnimalId ASC, DepartmentId ASC

--06. Animals data
  SELECT a.[Name], AnimalType, FORMAT(BirthDate, 'dd.MM.yyyy') as BirthDate
    FROM Animals as a
    JOIN AnimalTypes as [at] ON a.AnimalTypeId = [at].Id
ORDER BY a.[Name] ASC;

--07. Owners and Their Animals
  SELECT TOP 5 o.[Name], COUNT(*) as CountOfAnimals
    FROM Owners as o
    JOIN Animals as [at] ON o.Id = [at].OwnerId 
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, o.[Name] ASC;

--08. Owners, Animals and Cages
  SELECT CONCAT(o.[Name], '-', a.[Name]) as OwnersAnimals, o.PhoneNumber, c.Id as CageId
    FROM Owners as o
    JOIN Animals as a ON o.Id = a.OwnerId
	JOIN AnimalTypes as [at] ON [at].Id = a.AnimalTypeId
	JOIN AnimalsCages as ac ON ac.AnimalId = a.Id
    JOIN Cages as c ON c.Id = ac.CageId
   WHERE  [at].AnimalType = 'Mammals'
ORDER BY o.[Name] ASC, a.[Name] DESC;

--09. Volunteers in Sofia
  SELECT v.[Name], v.PhoneNumber, SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 2, LEN(v.[Address])) as [Address]
    FROM Volunteers as v
    JOIN VolunteersDepartments as vd ON vd.Id = v.DepartmentId
   WHERE v.Address LIKE '%Sofia%' AND vd.DepartmentName ='Education program assistant'
ORDER BY v.[Name] ASC;

--10. Animals for Adoption
  SELECT a.[Name], YEAR(a.BirthDate) as BirthYear, [at].AnimalType
    FROM Animals as a
    JOIN AnimalTypes as [at] ON [at].Id = a.AnimalTypeId
   WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 AND [at].AnimalType != 'Birds'
ORDER BY a.[Name] ASC;

--11. All Volunteers in a Department
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment varchar(30))
RETURNS INT
AS
BEGIN
RETURN(
	SELECT COUNT(*)
	  FROM Volunteers as v
	  JOIN VolunteersDepartments as vd ON vd.Id = v.DepartmentId
	 WHERE vd.DepartmentName = @VolunteersDepartment
)
END

GO
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName varchar(30))
AS
BEGIN
	IF(SELECT OwnerId FROM Animals WHERE [Name] = @AnimalName) IS NULL
	BEGIN
		SELECT a.[Name], 'For adoption' as OwnersName
		  FROM Animals as a
		 WHERE a.[Name] = @AnimalName
	END
	ELSE
	BEGIN
		SELECT a.[Name], o.[Name] as OwnersName
		  FROM Animals as a
		  JOIN Owners as o ON o.Id = a.OwnerId
		 WHERE a.[Name] = @AnimalName
	END
END
GO