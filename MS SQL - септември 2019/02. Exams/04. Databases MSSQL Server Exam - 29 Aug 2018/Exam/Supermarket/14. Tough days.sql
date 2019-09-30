   SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name],
          DATENAME(WEEKDAY, [s].[CheckIn]) AS [Day of week]
     FROM [dbo].[Employees] AS e
LEFT JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
LEFT JOIN [dbo].[Orders] AS [o] ON [e].[Id] = [o].[EmployeeId]
    WHERE DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut]) > 12 AND [o].[EmployeeId] IS NULL
 ORDER BY [e].[Id];