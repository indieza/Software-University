  SELECT [u].[Username],
         AVG([f].[Size]) AS [Size]
    FROM [dbo].[Users] AS u
    JOIN [dbo].[Commits] AS [c] ON [u].[Id] = [c].[ContributorId]
    JOIN [dbo].[Files] AS [f] ON [c].[Id] = [f].[CommitId]
GROUP BY [u].[Username]
ORDER BY [Size] DESC, [u].[Username];