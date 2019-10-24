   SELECT [m].[FirstName] + ' ' + [m].[LastName] AS [Available]
     FROM [dbo].[Mechanics] AS m
LEFT JOIN [dbo].[Jobs] AS [j] ON [m].[MechanicId] = [j].[MechanicId]
    WHERE [j].[FinishDate] IS NOT NULL OR [j].[JobId] IS NULL
 GROUP BY [m].[FirstName], [m].[LastName], [m].[MechanicId]
 ORDER BY [m].[MechanicId];