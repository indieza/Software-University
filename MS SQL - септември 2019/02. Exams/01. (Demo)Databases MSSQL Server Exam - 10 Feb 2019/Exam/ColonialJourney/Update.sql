UPDATE [dbo].[Spaceships]
  SET 
      [LightSpeedRate]+=1
WHERE [dbo].[Spaceships].[Id] BETWEEN 8 AND 12;