CREATE DATABASE People;
Use People;

CREATE TABLE People(
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Name] VARCHAR(30) NOT NULL,
[Picture] IMAGE,
[Height] DECIMAL(10, 2),
[Weight] DECIMAL(10, 2),
[Gender] VARCHAR(1) NOT NULL CHECK([Gender] = 'f' OR [Gender] = 'm'),
[Birthdate] DATE NOT NULL,
[Biography] VARCHAR(MAX)
);

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES('Pesho', NULL, 1.239, 69.236, 'm', '2005/01/13', NULL),
('Minka', NULL, 1.596, 56.231, 'f', '1996/09/15', 'Az sam Minka'),
('Gosho', NULL, 2.102, 105.36, 'm', '2001/02/23', NULL),
('Penka', NULL, 2.012, 68.236, 'f', '1996/02/11', NULL),
('Petranka', NULL, 1.369, 12.2365, 'f', '1996/06/03', NULL);