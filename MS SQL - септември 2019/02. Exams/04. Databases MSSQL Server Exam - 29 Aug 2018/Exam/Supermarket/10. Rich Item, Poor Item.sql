  SELECT TOP(10) [oi].[OrderId],
         MAX([i].[Price]) AS [ExpensivePrice],
  	     MIN([i].[Price]) AS [CheapPrice]
    FROM [dbo].[Items] AS i
    JOIN [dbo].[OrderItems] AS [oi] ON [i].[Id] = [oi].[ItemId]
GROUP BY [oi].[OrderId]
ORDER BY [ExpensivePrice] DESC, [oi].[OrderId];