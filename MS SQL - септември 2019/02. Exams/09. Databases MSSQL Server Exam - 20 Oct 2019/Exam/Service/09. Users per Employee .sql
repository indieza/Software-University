   SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [FullName],
          COUNT([r].[UserId]) AS [UsersCount]
     FROM [dbo].[Employees] AS e
LEFT JOIN [dbo].[Reports] AS [r] ON [e].[Id] = [r].[EmployeeId]
 GROUP BY [e].[FirstName], [e].[LastName]
 ORDER BY [UsersCount] DESC, [FullName];