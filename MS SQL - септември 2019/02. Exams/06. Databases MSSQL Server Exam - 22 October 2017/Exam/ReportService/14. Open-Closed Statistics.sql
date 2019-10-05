  SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Name],
         [r].[CloseDate],
  	     [r].[OpenDate]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Reports] AS [r] ON [e].[Id] = [r].[EmployeeId]
   WHERE (DATEPART(YEAR, [r].[OpenDate]) = 2016 OR DATEPART(YEAR, [r].[CloseDate]) = 2016)