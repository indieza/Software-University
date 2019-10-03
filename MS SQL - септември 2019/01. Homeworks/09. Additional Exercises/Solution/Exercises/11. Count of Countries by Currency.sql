    SELECT [c2].[CurrencyCode] AS [CurrencyCode],
           [c2].[Description] AS [Currency],
  	       COUNT([c].[CountryCode]) AS [NumberOfCountries]
      FROM [dbo].[Countries] AS c
RIGHT JOIN [dbo].[Currencies] AS [c2] ON [c].[CurrencyCode] = [c2].[CurrencyCode]
  GROUP BY [c2].[CurrencyCode], [c2].[Description]
  ORDER BY [NumberOfCountries] DESC, [Currency];