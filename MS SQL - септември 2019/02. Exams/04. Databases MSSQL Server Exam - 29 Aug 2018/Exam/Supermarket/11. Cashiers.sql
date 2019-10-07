  SELECT [e].[Id], [e].[FirstName], [e].[LastName]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Orders] AS [o] ON [e].[Id] = [o].[EmployeeId]
GROUP BY [e].[Id], [e].[FirstName], [e].[LastName]
ORDER BY [e].[Id];