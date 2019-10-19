  SELECT TOP(5) [r].[Id],
         [r].[Name],
		 COUNT([c].[Id]) AS [Commits]
    FROM [dbo].[Repositories] AS r
    JOIN [dbo].[Commits] AS [c] ON [r].[Id] = [c].[RepositoryId]
	JOIN [dbo].[RepositoriesContributors] AS [rc] ON [r].[Id] = [rc].[RepositoryId]
GROUP BY [r].[Id], [r].[Name]
ORDER BY [Commits] DESC, [r].[Id], [r].[Name];