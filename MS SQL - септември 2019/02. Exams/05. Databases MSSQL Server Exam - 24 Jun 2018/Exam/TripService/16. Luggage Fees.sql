  SELECT [t].[Id] AS [TripId],
         SUM([at].[Luggage]) AS [Luggage],
		 CAST(CASE
				WHEN SUM([at].[Luggage]) > 5 THEN '$' + CAST(SUM([at].[Luggage]) * 5 AS VARCHAR(50))
			    ELSE '$0'
		      END AS VARCHAR(50)) AS [Fee]
    FROM [dbo].[Trips] AS t
    JOIN [dbo].[AccountsTrips] AS [at] ON [t].[Id] = [at].[TripId]
GROUP BY [t].[Id]
  HAVING SUM([at].[Luggage]) > 0
ORDER BY [Luggage] DESC;