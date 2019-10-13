UPDATE [dbo].[Issues]
   SET
       [dbo].[Issues].[IssueStatus] = 'close'
 WHERE [dbo].[Issues].[AssigneeId] = 6;