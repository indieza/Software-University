   SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Name],
          COUNT([r].[UserId]) AS [Users Number]
     FROM [dbo].[Employees] AS e
LEFT JOIN [dbo].[Reports] AS [r] ON [e].[Id] = [r].[EmployeeId]
 GROUP BY [e].[FirstName], [e].[LastName]
 ORDER BY [Users Number] DESC, [Name];