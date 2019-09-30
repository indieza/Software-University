  SELECT TOP(10) [o].[Id] AS [OrderId],
         MAX([i].[Price]) AS [ExpensivePrice],
  	     MIN([i].[Price]) AS [CheapPrice]
    FROM [dbo].[Orders] AS o
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY [o].[Id]
ORDER BY [ExpensivePrice] DESC, [OrderId];