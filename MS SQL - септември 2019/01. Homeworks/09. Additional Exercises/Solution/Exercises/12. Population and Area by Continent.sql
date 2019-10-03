  SELECT [c].[ContinentName] AS [ContinentName],
         SUM(CAST([c2].[AreaInSqKm] AS BIGINT)) AS [CountriesArea],
		 SUM(CAST([c2].[Population] AS BIGINT)) AS [CountriesPopulation]
    FROM [dbo].[Continents] AS c
    JOIN [dbo].[Countries] AS [c2] ON [c].[ContinentCode] = [c2].[ContinentCode]
GROUP BY [c].[ContinentName]
ORDER BY [CountriesPopulation] DESC;