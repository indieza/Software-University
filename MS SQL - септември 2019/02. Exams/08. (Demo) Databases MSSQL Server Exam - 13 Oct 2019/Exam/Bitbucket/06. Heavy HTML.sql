  SELECT [f].[Id], [f].[Name], [f].[Size]
    FROM [dbo].[Files] AS f
   WHERE [f].[Size] > 1000 AND [f].[Name] LIKE '%html%'
ORDER BY [f].[Size] DESC, [f].[Id], [f].[Name];