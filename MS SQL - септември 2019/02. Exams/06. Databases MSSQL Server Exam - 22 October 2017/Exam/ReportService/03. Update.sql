UPDATE [dbo].[Reports]
   SET
       [dbo].[Reports].[StatusId] = 2
 WHERE [dbo].[Reports].[StatusId] = 1 AND [dbo].[Reports].[CategoryId] = 4;