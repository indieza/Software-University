  SELECT [j].[Status], [j].[IssueDate]
    FROM [dbo].[Jobs] AS j
   WHERE [j].[Status] <> 'Finished'
ORDER BY [j].[IssueDate], [j].[JobId];