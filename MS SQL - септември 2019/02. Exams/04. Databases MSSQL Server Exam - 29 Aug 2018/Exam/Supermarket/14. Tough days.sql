   SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name],
          DATENAME(dw, [s].[CheckIn]) AS [Day of week]
     FROM [dbo].[Employees] AS e
LEFT JOIN [dbo].[Orders] AS [o] ON [e].[Id] = [o].[EmployeeId]
     JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
	WHERE DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut]) > 12 AND [o].[Id] IS NULL
 ORDER BY [e].[Id];