   SELECT ISNULL([e].[FirstName] + ' ' + [e].[LastName], 'None') AS [Employee],
          ISNULL([d].[Name], 'None') AS [Department],
		  ISNULL([c].[Name], 'None') AS [Category],
		  ISNULL([r].[Description], 'None') AS [Description],
		  ISNULL(FORMAT([r].[OpenDate], 'dd.MM.yyyy'), 'None') AS [OpenDate],
		  ISNULL([s].[Label], 'None') AS [Status],
		  ISNULL([u].[Name], 'None') AS [User]
     FROM [dbo].[Reports] AS r
LEFT JOIN [dbo].[Employees] AS [e] ON [r].[EmployeeId] = [e].[Id]
LEFT JOIN [dbo].[Departments] AS [d] ON [e].[DepartmentId] = [d].[Id]
LEFT JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
LEFT JOIN [dbo].[Status] AS [s] ON [r].[StatusId] = [s].[Id]
LEFT JOIN [dbo].[Users] AS [u] ON [r].[UserId] = [u].[Id]
 ORDER BY [e].[FirstName] DESC,
          [e].[LastName] DESC,
		  [d].[Name],
		  [c].[Name],
		  [r].[Description],
		  [r].[OpenDate],
		  [s].[Label],
		  [u].[Name];