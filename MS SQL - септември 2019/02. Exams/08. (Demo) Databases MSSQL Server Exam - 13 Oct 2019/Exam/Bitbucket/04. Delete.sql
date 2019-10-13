DELETE
  FROM [dbo].[Issues]
 WHERE [dbo].[Issues].[RepositoryId] IN (SELECT [r].[Id]
                                           FROM [dbo].[Repositories] AS r
										  WHERE [r].[Name] = 'Softuni-Teamwork');
										  
DELETE
  FROM [dbo].[RepositoriesContributors]
 WHERE [dbo].[RepositoriesContributors].[RepositoryId] IN (SELECT [r].[Id]
                                                             FROM [dbo].[Repositories] AS r
										                    WHERE [r].[Name] = 'Softuni-Teamwork');