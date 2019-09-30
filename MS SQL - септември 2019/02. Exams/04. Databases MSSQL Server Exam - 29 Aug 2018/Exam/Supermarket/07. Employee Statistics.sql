  SELECT [e].[FirstName], [e].[LastName], COUNT([o].[Id]) AS [Count]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Orders] AS [o] ON [e].[Id] = [o].[EmployeeId]
GROUP BY [e].[FirstName], [e].[LastName]
ORDER BY [Count] DESC, [e].[FirstName];