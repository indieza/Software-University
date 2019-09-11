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