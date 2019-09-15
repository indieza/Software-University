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