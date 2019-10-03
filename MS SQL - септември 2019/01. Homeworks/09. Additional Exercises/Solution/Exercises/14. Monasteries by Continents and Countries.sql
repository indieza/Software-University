UPDATE [dbo].[Countries]
   SET
       [dbo].[Countries].[CountryName] = 'Burma'
 WHERE [CountryName] = 'Myanmar';

INSERT INTO [dbo].[Monasteries]
(
    [Name],
    [CountryCode]
)
VALUES
(
    'Hanga Abbey',
    'TZ'
),
(
	'Myin-Tin-Daik',
	NULL
);

 SELECT [c2].[ContinentName] AS [ContinentName],
          [c].[CountryName] AS [CountryName],
		  COUNT([m].[Id]) AS [MonasteriesCount]
     FROM [dbo].[Countries] AS c
     JOIN [dbo].[Continents] AS [c2] ON [c].[ContinentCode] = [c2].[ContinentCode]
LEFT JOIN [dbo].[Monasteries] AS m ON [c].[CountryCode] = [m].[CountryCode]
    WHERE [c].[IsDeleted] = 'false'
 GROUP BY [c2].[ContinentName], [c].[CountryName]
 ORDER BY [MonasteriesCount] DESC, [CountryName];