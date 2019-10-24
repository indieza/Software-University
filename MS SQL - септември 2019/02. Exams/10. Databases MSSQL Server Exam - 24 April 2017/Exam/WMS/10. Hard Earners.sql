   SELECT [m].[FirstName] + ' ' + [m].[LastName] AS [Mechanic],
          COUNT([j].[MechanicId]) AS [Jobs]
     FROM [dbo].[Mechanics] AS m
LEFT JOIN [dbo].[Jobs] AS [j] ON [m].[MechanicId] = [j].[MechanicId]
    WHERE [j].[FinishDate] IS NULL
 GROUP BY [m].[FirstName], [m].[LastName], [m].[MechanicId]
   HAVING COUNT([j].[MechanicId]) > 1
 ORDER BY [Jobs] DESC, [m].[MechanicId];