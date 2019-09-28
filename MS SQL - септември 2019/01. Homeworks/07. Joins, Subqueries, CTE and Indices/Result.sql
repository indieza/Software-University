-- Problem 1
  SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID;

-- Problem 2
  SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
    JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName;

-- Problem 3
  SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID;

-- Problem 4
  SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE e.Salary > 15000
ORDER BY e.DepartmentID;

-- Problem 5
  SELECT TOP(3) e.EmployeeID, e.FirstName
    FROM Employees AS e
    FULL JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
   WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID;

-- Problem 6
  SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate;

-- Problem 7
  SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
    FROM Employees AS e
    JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
    JOIN Projects AS p ON p.ProjectID = ep.ProjectID
   WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID;

-- Problem 8
SELECT e.EmployeeID, e.FirstName, IIF(YEAR(p.StartDate) >= 2005, NULL, p.[Name])
  FROM Employees AS e
  JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
 WHERE e.EmployeeID = 24;

-- Problem 9
  SELECT e.EmployeeID, e.FirstName, e.ManagerID, mg.FirstName AS [ManagerName]
    FROM Employees AS e
    JOIN Employees AS mg ON mg.EmployeeID = e.ManagerID
   WHERE mg.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID;

-- Problem 10
  SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS [EmployeeName],
         mg.FirstName + ' ' + mg.LastName AS [ManagerName],
		 d.[Name] AS [DepartmentName]
    FROM Employees AS e
    JOIN Employees AS mg ON mg.EmployeeID = e.ManagerID
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID;

-- Problem 11
  SELECT TOP(1) AVG(e.Salary) AS [MinAverageSalary]
    FROM Departments AS d
    JOIN Employees AS e ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY [MinAverageSalary];

USE [Geography];

-- Problem 12
  SELECT c.CountryCode, m.MountainRange, p.[PeakName], p.Elevation
    FROM Countries AS c
    JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
    JOIN Mountains AS m ON m.Id = mc.MountainId
    JOIN Peaks AS p ON p.MountainId = m.Id
   WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC;

-- Problem 13
  SELECT c.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
    FROM Countries AS c
    JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
    JOIN Mountains AS m ON m.Id = mc.MountainId
   WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode;

-- Problem 14
  SELECT TOP(5) c.CountryName, r.RiverName
    FROM Countries AS c
    FULL JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
    FULL JOIN Rivers AS r ON r.Id = cr.RiverId
   WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName;

-- Problem 15
  SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
    FROM (
  SELECT c.ContinentCode,
         c.CurrencyCode,
  	     COUNT(c.CurrencyCode) AS [CurrencyUsage],
  	     DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
    FROM Countries AS c
    JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
GROUP BY c.ContinentCode, c.CurrencyCode
  HAVING COUNT(c.CurrencyCode) != 1) AS k
   WHERE k.[Rank] = 1
ORDER BY k.ContinentCode;

-- Problem 16
SELECT COUNT(*) AS [CountryCode]
  FROM Countries AS c
  FULL JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
 WHERE mc.MountainId IS NULL;

-- Problem 17
  SELECT TOP(5) c.CountryName,
         MAX(p.Elevation) AS [HighestPeakElevation],
		 MAX(r.[Length]) AS [LongestRiverLength]
    FROM Countries AS c
    JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
    JOIN Mountains AS m ON m.Id = mc.MountainId
    JOIN Peaks AS p ON p.MountainId = mc.MountainId
    JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
    JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName;

-- Problem 18
   SELECT TOP(5) k.CountryName,
          ISNULL(k.PeakName, '(no highest peak)'),
		  ISNULL(k.[Highest Peak Elevation], 0),
		  ISNULL(k.MountainRange, '(no mountain)')
     FROM (
   SELECT c.CountryName,
          p.PeakName,
		  MAX(p.Elevation) AS [Highest Peak Elevation],
		  m.MountainRange,
		  DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
 GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
    WHERE k.[Rank] = 1
 ORDER BY k.CountryName, k.PeakName;