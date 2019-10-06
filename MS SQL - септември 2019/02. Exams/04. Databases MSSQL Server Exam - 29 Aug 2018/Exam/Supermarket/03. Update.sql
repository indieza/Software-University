UPDATE [dbo].[Items]
   SET
       [dbo].[Items].[Price] *= 1.27
 WHERE [dbo].[Items].[CategoryId] IN (1, 2, 3);