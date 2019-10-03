   SELECT [i].[Name] AS [Item],
          [i].[Price] AS [Price],
   	      [i].[MinLevel] AS [MinLevel],
   	      [gt].[Name] AS [Forbidden Game Type]
     FROM [dbo].[Items] AS i
LEFT JOIN [dbo].[GameTypeForbiddenItems] AS [gtfi] ON [i].[Id] = [gtfi].[ItemId]
LEFT JOIN [dbo].[GameTypes] AS [gt] ON [gtfi].[GameTypeId] = [gt].[Id]
 ORDER BY [Forbidden Game Type] DESC, [Item];