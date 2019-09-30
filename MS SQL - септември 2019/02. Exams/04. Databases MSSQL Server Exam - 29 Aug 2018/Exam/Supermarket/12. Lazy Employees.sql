  SELECT [e].[Id],
         [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
   WHERE DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut]) < 4
GROUP BY [e].[Id], [e].[FirstName], [e].[LastName]
ORDER BY [e].[Id];