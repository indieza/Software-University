   SELECT [c].[CountryName] AS [CountryName],
          [c2].[ContinentName] AS [ContinentName],
  	      COUNT([cr].[RiverId]) AS [RiversCount],
		  CASE
			 WHEN COUNT([cr].[RiverId]) = 0 THEN 0
			 ELSE SUM([r].[Length])
  	      END AS [TotalLength]
     FROM [dbo].[Countries] AS c
LEFT JOIN [dbo].[Continents] AS [c2] ON [c].[ContinentCode] = [c2].[ContinentCode]
LEFT JOIN [dbo].[CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
LEFT JOIN [dbo].[Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
 GROUP BY [c].[CountryName], [c2].[ContinentName]
 ORDER BY [RiversCount] DESC, [TotalLength] DESC, [CountryName];