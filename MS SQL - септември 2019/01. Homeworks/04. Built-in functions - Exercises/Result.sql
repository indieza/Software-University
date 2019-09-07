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

USE Diablo;

  SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE DATEPART(Year, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name];

  SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username;

  SELECT Username, IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username;

  SELECT [Name], 
    CASE
  	WHEN DATEPART(HOUR, [Start]) >= 0 AND  DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
  	WHEN DATEPART(HOUR, [Start]) >= 12 AND  DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
  	ELSE 'Evening'
    END AS [Part of the Day],
    CASE
  	WHEN Duration <= 3 THEN 'Extra Short'
  	WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
  	WHEN Duration > 6 THEN 'Long'
  	ELSE 'Extra Long'
    END AS [DurationName]
    FROM Games
ORDER BY [Name], [DurationName], [Part of the Day]

USE Orders;

SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due],DATEADD(MONTH, 1, OrderDate) AS [Deliver Due] 
  FROM Orders;