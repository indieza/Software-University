CREATE DATABASE SoftUni;
USE SoftUni;

CREATE TABLE Towns(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[Name] VARCHAR(20) NOT NULL
);

INSERT INTO Towns([Name])
VALUES('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');

CREATE TABLE Addresses(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[AddressText] VARCHAR(30),
[TownId] INT FOREIGN KEY REFERENCES Towns([Id]) NOT NULL
);

CREATE TABLE Departments(
[Id]  INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[Name] VARCHAR(20) NOT NULL
);

INSERT INTO Departments([Name])
VALUES('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');

CREATE TABLE Employees(
[Id]  INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[FirstName] VARCHAR(30) NOT NULL, 
[MiddleName] VARCHAR(20),
[LastName] VARCHAR(20),
[JobTitle] VARCHAR(20) NOT NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES Departments([Id]) NOT NULL,
[HireDate] DATE NOT NULL,
[Salary] DECIMAL(15, 2) NOT NULL,
[AddressId] VARCHAR(30)
);

INSERT INTO Employees([FirstName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES('Ivan Ivanov Ivanov', '.NET Developer', 4, '2013-02-23', 3500.00),
('Petar Petrov Petrov',	'Senior Engineer', 1, '2014-03-24', 4000.00),
('Maria Petrova Ivanova', 'Intern', 5, '2016-08-16', 525.25),
('Georgi Teziev Ivanov', 'CEO',	2, '2015-12-27', 3000.00),
('Peter Pan Pan', 'Intern', 3, '2016-08-20', 599.88)

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

SELECT * FROM Towns
ORDER BY Name;

SELECT * FROM Departments
ORDER BY Name;

SELECT * FROM Employees
ORDER BY Salary DESC;

SELECT [Name] FROM Towns
ORDER BY Name;

SELECT [Name] FROM Departments
ORDER BY Name;

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC;

UPDATE Employees
SET [Salary] += [Salary] * 0.10;
SELECT [Salary] FROM Employees;

USE Hotel;

UPDATE Payments
SET [TaxRate] -= [TaxRate] * 0.03;
SELECT [TaxRate] FROM Payments;

USE Hotel;

TRUNCATE Table Occupancies; 