SELECT SUM([p].[Price] * [op].[Quantity]) AS [Parts Total]
  FROM [dbo].[Parts] AS p
  JOIN [dbo].[OrderParts] AS [op] ON [p].[PartId] = [op].[PartId]
  JOIN [dbo].[Orders] AS [o] ON [op].[OrderId] = [o].[OrderId]
 WHERE DATEDIFF(WEEK, [o].[IssueDate], '2017-04-24') <= 3;