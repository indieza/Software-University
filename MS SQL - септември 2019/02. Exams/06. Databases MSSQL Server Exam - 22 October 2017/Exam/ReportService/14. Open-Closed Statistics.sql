  SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Name],
         [r].[CloseDate],
  	     [r].[OpenDate],
		 CASE
			WHEN DATEPART(YEAR, [r].[OpenDate]) = 2015 AND DATEPART(YEAR, [r].[CloseDate]) = 2016 THEN 1
		END AS [Name Closed Open Reports]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Reports] AS [r] ON [e].[Id] = [r].[EmployeeId]
   WHERE (DATEPART(YEAR, [r].[OpenDate]) = 2016 OR DATEPART(YEAR, [r].[CloseDate]) = 2016)
ORDER BY [Name], [e].[Id];