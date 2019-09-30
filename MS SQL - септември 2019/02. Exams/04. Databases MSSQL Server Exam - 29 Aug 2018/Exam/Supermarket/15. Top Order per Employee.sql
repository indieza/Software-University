  SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Full Name],
         DATEDIFF(HOUR, [s].[CheckIn], [s].[CheckOut]) AS [WorkHours],
		 [k].[Total Price]
    FROM (
  SELECT [o].[EmployeeId],
         SUM([oi].[Quantity] * [i].[Price]) AS [Total Price],
  	     ROW_NUMBER() OVER (PARTITION BY [o].[EmployeeId] ORDER BY SUM([oi].[Quantity] * [i].[Price]) DESC) AS [Row],
		 [o].[DateTime]
    FROM [dbo].[Orders] AS o
    JOIN [dbo].[OrderItems] AS [oi] ON [o].[Id] = [oi].[OrderId]
    JOIN [dbo].[Items] AS [i] ON [oi].[ItemId] = [i].[Id]
GROUP BY [o].[EmployeeId], [o].[Id], [o].[DateTime]) AS k
    JOIN [dbo].[Employees] AS e ON [k].[EmployeeId] = [e].[Id]
	JOIN [dbo].[Shifts] AS [s] ON [e].[Id] = [s].[EmployeeId]
   WHERE [k].[Row] = 1 AND [k].[DateTime] BETWEEN [s].[CheckIn] AND [s].[CheckOut]
ORDER BY [Full Name], [WorkHours] DESC, [k].[Total Price] DESC;