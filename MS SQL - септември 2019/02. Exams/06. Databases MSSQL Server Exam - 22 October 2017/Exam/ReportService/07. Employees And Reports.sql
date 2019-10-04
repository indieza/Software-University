  SELECT [e].[FirstName],
         [e].[LastName],
		 [r].[Description],
		 FORMAT([r].[OpenDate], 'yyyy-MM-dd') AS [OpenDate]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Reports] AS [r] ON [e].[Id] = [r].[EmployeeId]
ORDER BY [e].[Id], [OpenDate], [r].[Id];