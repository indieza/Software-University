  SELECT TOP(5) [r].[Id],
         [r].[Name],
  	     COUNT([c].[Id]) AS [Commits]
    FROM [dbo].[Repositories] AS r
	JOIN [dbo].[RepositoriesContributors] AS [rc] ON [r].[Id] = [rc].[RepositoryId]
	JOIN [dbo].[Users] AS [u] ON [rc].[ContributorId] = [u].[Id]
	JOIN [dbo].[Commits] AS [c] ON [r].[Id] = [c].[RepositoryId]
GROUP BY [r].[Id], [r].[Name]
ORDER BY [Commits] DESC, [r].[Id], [r].[Name];