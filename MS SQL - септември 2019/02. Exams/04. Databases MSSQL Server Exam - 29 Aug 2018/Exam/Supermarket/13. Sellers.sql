  SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name],
         SUM([i].[Price] * [oi].[Quantity]) AS [Total Price],
  	     SUM([oi].[Quantity]) AS [Items]
    FROM [dbo].[Employees] AS e
    JOIN [dbo].[Orders] AS [o] ON [e].[Id] = [o].[EmployeeId]
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
   WHERE [o].[DateTime] < '2018-06-15'
GROUP BY [e].[FirstName], [e].[LastName]
ORDER BY [Total Price] DESC, [Items] DESC;