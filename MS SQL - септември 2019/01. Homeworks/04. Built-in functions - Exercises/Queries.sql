USE SoftUni;

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'SA%';

SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%';

SELECT FirstName
  FROM Employees
  WHERE DepartmentID IN(3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005;

SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%';

  SELECT [Name]
    FROM Towns
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name];

  SELECT *
    FROM Towns
   WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
ORDER BY [Name];

  SELECT *
    FROM Towns
   WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
ORDER BY [Name];

CREATE VIEW V_EmployeesHiredAfter2000 AS
     SELECT FirstName, LastName
       FROM Employees
      WHERE DATEPART(YEAR, HireDate) > 2000;

SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5;

  SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION by Salary order by EmployeeID) AS [Rank]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

  SELECT *
    FROM
(
  SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION by Salary order by EmployeeID) AS [Rank]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
)     AS MyRanking
   WHERE MyRanking.[Rank] = 2
ORDER BY MyRanking.Salary DESC;

USE Geography;

  SELECT CountryName, IsoCode
    FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

  SELECT PeakName, RiverName, LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
    FROM Peaks, Rivers
   WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;