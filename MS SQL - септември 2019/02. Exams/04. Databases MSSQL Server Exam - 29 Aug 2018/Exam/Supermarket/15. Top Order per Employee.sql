  SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name],
         DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut]) AS [WorkHours],
		 [k].[TotalPrice]
   FROM (
  SELECT [o].[EmployeeId],
         [o].[DateTime],
         SUM([i].[Price] * [oi].[Quantity]) AS [TotalPrice],
  	     ROW_NUMBER() OVER (PARTITION BY [o].[EmployeeId] ORDER BY SUM([i].[Price] * [oi].[Quantity]) DESC) AS [Row]
    FROM [dbo].[Orders] AS o
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY [o].[EmployeeId], [o].[DateTime], [o].[Id]) As k
    JOIN [dbo].[Employees] AS e ON k.[EmployeeId] = [e].[Id]
	JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
   WHERE [k].[Row] = 1 AND [k].[DateTime] BETWEEN [s].[CheckIn] AND [s].[CheckOut]
ORDER BY [Full Name], [WorkHours] DESC, [k].[TotalPrice] DESC;