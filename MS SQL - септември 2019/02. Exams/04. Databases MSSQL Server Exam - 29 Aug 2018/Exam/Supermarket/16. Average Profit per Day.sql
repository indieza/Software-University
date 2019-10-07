  SELECT DATEPART(DAY, [o].[DateTime]) AS [Day],
         CAST(AVG([oi].[Quantity] * [i].[Price]) AS DECIMAL(15, 2)) AS [Total profit]
    FROM [dbo].[Orders] AS o
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY DATEPART(DAY, [o].[DateTime])
ORDER BY [Day]