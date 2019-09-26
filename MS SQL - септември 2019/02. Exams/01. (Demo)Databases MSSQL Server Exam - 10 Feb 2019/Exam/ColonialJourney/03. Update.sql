UPDATE [dbo].[Spaceships]
   SET
       [dbo].[Spaceships].[LightSpeedRate] += 1
 WHERE [dbo].[Spaceships].[Id] BETWEEN 8 AND 12;