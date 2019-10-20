UPDATE [dbo].[Reports]
   SET
       [dbo].[Reports].[CloseDate] = GETDATE()
 WHERE [dbo].[Reports].[CloseDate] IS NULL;