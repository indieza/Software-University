  SELECT [r].[Description], [r].[OpenDate]
    FROM [dbo].[Reports] AS r
   WHERE [r].[EmployeeId] IS NULL
ORDER BY [r].[OpenDate], [r].[Description];