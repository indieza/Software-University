CREATE DATABASE Movies;
USE Movies;

CREATE TABLE Directors(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DirectorName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Genres(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[GenreName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Categories(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[CategoryName] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(MAX)
);

CREATE TABLE Movies(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES Directors([Id]) NOT NULL,
[CopyrightYear] INT NOT NULL,
[Length] INT NOT NULL,
[GenreId] INT FOREIGN KEY REFERENCES Genres([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
[Rating] INT,
[Notes] VARCHAR(MAX)
);

INSERT INTO Directors([DirectorName], [Notes])
VALUES('Pesho', NULL),
('Gosho', 'Test * 23'),
('Milen', NULL),
('Orlando', 'Olqka e hood'),
('Penka', 'Penka ataka');

INSERT INTO Genres([GenreName], [Notes])
VALUES('Patka', NULL),
('Gorila', NULL),
('Mule', NULL),
('Olqk', NULL),
('Panda', NULL);

INSERT INTO Categories([CategoryName], [Notes])
VALUES('Comedy', NULL),
('Action', NULL),
('Serial', NULL),
('Social', NULL),
('Nature', NULL);

INSERT INTO Movies([DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES(3, 1969, 569, 4, 5, 25, NULL),
(1, 1999, 36, 3, 3, 100, NULL),
(2, 1990, 56, 1, 2, 8, NULL),
(4, 2000, 2, 2, 1, 2, NULL),
(5, 2001, 256, 5, 4, -3, NULL);