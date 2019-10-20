   SELECT [r].[Description],
          FORMAT([r].[OpenDate], 'dd-MM-yyyy') AS [OpenDate]
     FROM [dbo].[Reports] AS r
LEFT JOIN [dbo].[Employees] AS [e] ON [r].[EmployeeId] = [e].[Id]
    WHERE [e].[Id] IS NULL
 ORDER BY [r].[OpenDate], [r].[Description];