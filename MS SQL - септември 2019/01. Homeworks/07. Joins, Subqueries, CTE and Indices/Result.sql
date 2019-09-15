  SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID;

  SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
    JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName;

  SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID;

  SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE e.Salary > 15000
ORDER BY e.DepartmentID;

  SELECT TOP(3) e.EmployeeID, e.FirstName
    FROM Employees AS e
    FULL JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
   WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID;

  SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate;

  SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
    FROM Employees AS e
    JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
    JOIN Projects AS p ON p.ProjectID = ep.ProjectID
   WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID;

SELECT e.EmployeeID, e.FirstName, IIF(YEAR(p.StartDate) >= 2005, NULL, p.[Name])
  FROM Employees AS e
  JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
 WHERE e.EmployeeID = 24;

  SELECT e.EmployeeID, e.FirstName, e.ManagerID, mg.FirstName AS [ManagerName]
    FROM Employees AS e
    JOIN Employees AS mg ON mg.EmployeeID = e.ManagerID
   WHERE mg.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID;

  SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS [EmployeeName],
         mg.FirstName + ' ' + mg.LastName AS [ManagerName],
		 d.[Name] AS [DepartmentName]
    FROM Employees AS e
    JOIN Employees AS mg ON mg.EmployeeID = e.ManagerID
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID;