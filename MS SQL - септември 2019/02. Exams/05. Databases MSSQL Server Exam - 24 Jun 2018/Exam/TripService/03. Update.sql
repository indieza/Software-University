UPDATE [dbo].[Rooms]
   SET
       [dbo].[Rooms].[Price] *= 1.14
 WHERE [dbo].[Rooms].[HotelId] IN (5, 7,9);