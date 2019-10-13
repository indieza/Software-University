  SELECT [c].[Id], [c].[Message], [c].[RepositoryId], [c].[ContributorId]
    FROM [dbo].[Commits] AS c
ORDER BY [c].[Id], [c].[Message], [c].[RepositoryId], [c].[ContributorId];