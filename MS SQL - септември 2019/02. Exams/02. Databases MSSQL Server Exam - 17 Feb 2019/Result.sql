CREATE DATABASE School;

USE School;

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL CHECK(Age > 0),
	[Address] NVARCHAR(50),
	Phone VARCHAR(10)
);

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK(Lessons > 0)
);

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15, 2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
);

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
);

CREATE TABLE StudentsExams
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15, 2) NOT NULL CHECK (Grade BETWEEN 2 AND 6),
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
);

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	Phone VARCHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
);

CREATE TABLE StudentsTeachers
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
);

INSERT INTO Teachers([FirstName], [LastName], [Address], [Phone], [SubjectId]) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard',	'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4);

INSERT INTO Subjects([Name], [Lessons]) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9);

UPDATE StudentsSubjects
   SET Grade = 6.00
 WHERE SubjectId IN(1, 2) AND Grade >= 5.50;

DELETE
  FROM StudentsTeachers
 WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone  LIKE '%72%');
DELETE
  FROM Teachers
 WHERE Phone LIKE '%72%';

  SELECT FirstName, LastName, Age
    FROM Students
   WHERE Age >= 12
ORDER BY FirstName, LastName;

  SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], [Address]
    FROM Students
   WHERE [Address] LIKE '%road%'
ORDER BY FirstName, LastName, [Address];

  SELECT FirstName, [Address], Phone 
    FROM Students
   WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName;

  SELECT s.FirstName, s.LastName, COUNT(st.StudentId) AS [TeachersCount]
    FROM Students AS s
    JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName;

  SELECT t.FirstName + ' ' + t.LastName AS [FullName],
         s.[Name] + '-' + CAST(s.Lessons AS NVARCHAR(20)) AS Subjects,
  	     COUNT(st.StudentId) AS [Students]
    FROM Teachers AS t
    JOIN Subjects AS s ON s.Id = t.SubjectId
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName, s.[Name], s.Lessons
ORDER BY [Students] DESC, [FullName], s.[Name];

  SELECT s.FirstName + ' ' + s.LastName AS [Full Name]
    FROM Students AS s
    FULL JOIN StudentsExams AS se ON se.StudentId = s.Id
   WHERE se.Grade IS NULL
ORDER BY [Full Name];

  SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS [StudentsCount]
    FROM Teachers AS t
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName;

SELECT TOP(10) s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(15, 2)) AS [Grade]
  FROM Students AS s
  JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName;

  SELECT FirstName, LastName, Grade
    FROM (
  SELECT s.FirstName, s.LastName, se.Grade, ROW_NUMBER() OVER (PARTITION BY FirstName, LastName ORDER BY Grade DESC) AS [Rank] 
    FROM Students AS s
    JOIN StudentsSubjects AS se ON se.StudentId = s.Id) AS [Ranked]
   WHERE [Ranked].[Rank] = 2
ORDER BY FirstName, LastName;

  SELECT s.FirstName + ' ' + ISNULL(s.MiddleName + ' ', '') + s.LastName AS [Full Name]
    FROM Students AS s
    FULL JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
   WHERE ss.StudentId IS NULL
ORDER BY [Full Name];

  SELECT s.[Name], AVG(ss.Grade) AS [AverageGrade]
    FROM Subjects AS s
    JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id;

  SELECT res.[Quarter], res.SubjectName, COUNT(res.StudentId) AS StudentsCount
    FROM (
  SELECT s.[Name] AS SubjectName, se.StudentId,
    CASE
  		WHEN DATEPART(MONTH, e.[Date]) BETWEEN 1 AND 3 THEN 'Q1'
  		WHEN DATEPART(MONTH, e.[Date]) BETWEEN 4 AND 6 THEN 'Q2'
  		WHEN DATEPART(MONTH, e.[Date]) BETWEEN 7 AND 9 THEN 'Q3'
  		WHEN DATEPART(MONTH, e.[Date]) BETWEEN 10 AND 12 THEN 'Q4'
  	ELSE 'TBA'
     END AS [Quarter]
    FROM Exams AS e
    JOIN Subjects AS s ON s.Id = e.SubjectId
    JOIN StudentsExams AS se ON se.ExamId = e.Id
   WHERE se.Grade >= 4.00) AS res
GROUP BY res.SubjectName, res.[Quarter]
ORDER BY res.[Quarter];

SELECT *
  FROM Students AS s
  JOIN StudentsExams AS se ON se.StudentId = s.Id
  WHERE s.Id = 12 AND se.Grade BETWEEN 5.50 AND 6

SELECT *
  FROM Students AS s
  JOIN StudentsExams AS se ON se.StudentId = s.Id
  JOIN Exams AS e ON e.Id = se.ExamId

CREATE FUNCTION udf_ExamGradesToUpdate(@StudentId INT, @Grade DECIMAL(15, 2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@StudentId NOT IN(SELECT Id FROM Students))
		RETURN 'The student with provided id does not exist in the school!'
	IF(@Grade > 6.00)
		RETURN 'Grade cannot be above 6.00!'

	DECLARE @name VARCHAR(50) = (SELECT s.FirstName
					               FROM Students AS s
								  WHERE s.Id = @StudentId)
	DECLARE @count INT = (SELECT COUNT(*)
					        FROM Students AS s
					        JOIN StudentsExams AS se ON se.StudentId = s.Id
					        JOIN Exams AS e ON e.Id = se.ExamId
						    WHERE s.Id = @StudentId AND se.Grade BETWEEN @Grade AND @Grade + 0.50)

	RETURN 'You have to update ' +  CAST(@count AS VARCHAR(50)) + ' grades for the student ' + @name
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
    AS
IF(@StudentId NOT IN(SELECT Id FROM Students))
		RAISERROR('This school has no student with the provided id!', 16, 1)
DELETE
  FROM StudentsTeachers
 WHERE StudentId = @StudentId
DELETE
  FROM StudentsSubjects
 WHERE StudentId = @StudentId
DELETE
  FROM StudentsExams
 WHERE StudentId = @StudentId
DELETE
  FROM Students
 WHERE Id = @StudentId

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
EXEC usp_ExcludeFromSchool 301