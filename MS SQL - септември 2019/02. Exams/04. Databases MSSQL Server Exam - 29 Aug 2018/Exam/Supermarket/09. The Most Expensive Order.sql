SELECT TOP(1) [oi].[OrderId], SUM([oi].[Quantity] * [i].[Price]) AS [TotalPrice]
  FROM [dbo].[OrderItems] AS oi
  JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY [oi].[OrderId]
ORDER BY [TotalPrice] DESC;