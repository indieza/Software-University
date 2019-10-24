  SELECT [m].[FirstName] + ' ' + [m].[LastName] AS [Mechanic],
         AVG(DATEDIFF(DAY, [j].[IssueDate], [j].[FinishDate])) AS [Average Days]
    FROM [dbo].[Mechanics] AS m
    JOIN [dbo].[Jobs] AS [j] ON [m].[MechanicId] = [j].[MechanicId]
GROUP BY [m].[FirstName], [m].[LastName], [m].[MechanicId]
ORDER BY [m].[MechanicId];