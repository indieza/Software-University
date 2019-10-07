   SELECT [i].[Name] AS [Item],
          [c].[Name] AS [Category],
   	      SUM([oi].[Quantity]) AS [Count],
   	      SUM([oi].[Quantity] * [i].[Price]) AS [TotalPrice]
     FROM [dbo].[Items] AS i
LEFT JOIN [dbo].[Categories] AS [c] ON [i].[CategoryId] = [c].[Id]
LEFT JOIN [dbo].[OrderItems] AS [oi] ON [i].[Id] = [oi].[ItemId]
LEFT JOIN [dbo].[Orders] AS [o] ON [oi].[OrderId] = [o].[Id]
 GROUP BY [i].[Name], [c].[Name]
 ORDER BY [TotalPrice] DESC, [Count] DESC;