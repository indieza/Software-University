  SELECT *
    FROM [dbo].[Planes] AS p
   WHERE [p].[Name] LIKE '%tr%'
ORDER BY [p].[Id], [p].[Name], [p].[Seats], [p].[Range];