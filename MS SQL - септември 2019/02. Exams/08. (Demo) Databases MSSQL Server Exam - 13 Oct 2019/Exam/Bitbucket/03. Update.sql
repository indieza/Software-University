UPDATE [dbo].[Issues]
   SET
       [dbo].[Issues].[IssueStatus] = 'closed'
 WHERE [dbo].[Issues].[Id] = 6;