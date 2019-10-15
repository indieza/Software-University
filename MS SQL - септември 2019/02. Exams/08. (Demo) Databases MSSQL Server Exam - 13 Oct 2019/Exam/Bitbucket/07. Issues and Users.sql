  SELECT [i].[Id],
         [u].[Username] + ' : ' + [i].[Title] AS [IssueAssignee]
    FROM [dbo].[Issues] AS i
	JOIN [dbo].[Users] AS [u] ON [i].[AssigneeId] = [u].[Id]
ORDER BY [i].[Id] DESC, [IssueAssignee];