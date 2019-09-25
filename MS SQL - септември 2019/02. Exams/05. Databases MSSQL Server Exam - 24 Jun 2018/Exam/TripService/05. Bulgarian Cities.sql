  SELECT [c].[Id], [c].[Name]
    FROM [dbo].[Cities] AS c
   WHERE [c].[CountryCode] = 'BG'
ORDER BY [c].[Name];