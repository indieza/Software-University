  SELECT [e].[FirstName],
         [e].[LastName],
         AVG(DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut])) AS [Work hours]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
GROUP BY [e].[FirstName], [e].[LastName], [e].[Id]
  HAVING AVG(DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut])) > 7
ORDER BY [Work hours] DESC, [e].[Id];