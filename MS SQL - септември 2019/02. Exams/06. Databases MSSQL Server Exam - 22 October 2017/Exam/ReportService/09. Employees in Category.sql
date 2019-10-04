  SELECT [c].[Name] AS [CategoryName],
         COUNT([e].[Id]) AS [Employees Number]
    FROM [dbo].[Categories] AS c
    JOIN [dbo].[Departments] AS [d] ON [c].[DepartmentId] = [d].[Id]
    JOIN [dbo].[Employees] AS [e] ON [d].[Id] = [e].[DepartmentId]
GROUP BY [c].[Name]
ORDER BY [CategoryName];