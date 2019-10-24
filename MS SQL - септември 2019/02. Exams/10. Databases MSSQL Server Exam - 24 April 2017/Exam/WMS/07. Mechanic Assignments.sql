  SELECT [m].[FirstName] + ' ' + [m].[LastName] AS [Mechanic],
         [j].[Status],
		 [j].[IssueDate]
    FROM [dbo].[Mechanics] AS m
    JOIN [dbo].[Jobs] AS [j] ON [m].[MechanicId] = [j].[MechanicId]
ORDER BY [m].[MechanicId], [j].[IssueDate], [j].[JobId];