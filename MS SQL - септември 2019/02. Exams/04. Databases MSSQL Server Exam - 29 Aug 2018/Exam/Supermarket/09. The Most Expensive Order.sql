    SELECT TOP(1) [o].[Id] AS [OrderId],
          SUM([oi].[Quantity] * [i].[Price]) AS [TotalPrice]
    FROM [dbo].[Orders] AS o
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY [o].[Id]
ORDER BY [TotalPrice] DESC;