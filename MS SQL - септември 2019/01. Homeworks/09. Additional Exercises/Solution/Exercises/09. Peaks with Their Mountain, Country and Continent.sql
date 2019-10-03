  SELECT [p].[PeakName] AS [PeakName],
         [m].[MountainRange] AS [Mountain],
		 [c].[CountryName] AS [CountryName],
		 [c2].[ContinentName] AS [ContinentName]
    FROM [dbo].[Peaks] AS p
    JOIN [dbo].[Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
    JOIN [dbo].[MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
    JOIN [dbo].[Countries] AS [c] ON [mc].[CountryCode] = [c].[CountryCode]
    JOIN [dbo].[Continents] AS [c2] ON [c].[ContinentCode] = [c2].[ContinentCode]
ORDER BY [PeakName], [CountryName];