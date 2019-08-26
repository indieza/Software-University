CREATE DATABASE People;
USE People;

SET IDENTITY_INSERT People ON;

CREATE TABLE People(
[Id] INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(200),
[Height] DOUBLE PRECISION(2),
[Weight] DOUBLE PRECISION(2),
[Gender] NVARCHAR(1) NOT NULL CHECK([Gender] = 'm' OR [Gender] = 'f'),
[Birthdate] DATETIME NOT NULL,
[Biography] NVARCHAR(MAX)
);

INSERT INTO People([Id], [Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES(1, 'Pesho1', NULL, 1.259, 2.356, 'm', '2015-11-05 14:29:36', 'asdfg'),
	  (2, 'Pesho2', NULL, 1.260, 2.357, 'f', '2015-11-05 14:29:36', 'asdfgh'),
	  (3, 'Pesho3', NULL, 1.262, 2.358, 'm', '2015-11-05 14:29:36', 'asdfgds'),
	  (4, 'Pesho4', NULL, 1.261, 2.359, 'm', '2015-11-05 14:29:36', 'afg'),
	  (5, 'Pesho5', NULL, 1.263, 2.360, 'f', '2015-11-05 14:29:36', 'adfg')