  SELECT [p].[PeakName] AS [PeakName],
         [m].[MountainRange] AS [Mountain],
  	     [p].[Elevation] AS [Elevation]
    FROM [dbo].[Peaks] AS p
    JOIN [dbo].[Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
ORDER BY [Elevation] DESC, [PeakName];