CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @resultTable TABLE
	(
		[HotelId] INT,
        [RoomId] INT,
		[RoomType] VARCHAR(50),
		[RoomBeds] INT,
		[Price] DECIMAL(15, 2)
	)

	INSERT INTO @resultTable
	(
	    [HotelId],
	    [RoomId],
	    [RoomType],
	    [RoomBeds],
	    [Price]
	)
	SELECT TOP(1) [h].[Id],
           [r].[Id],
 		   [r].[Type],
 		   [r].[Beds],
 		   ([h].[BaseRate] + [r].[Price]) * @People AS [Price]
      FROM [dbo].[Hotels] AS h
      JOIN [dbo].[Rooms] AS [r] ON [h].[Id] = [r].[HotelId]
      JOIN [dbo].[Trips] AS [t] ON [r].[Id] = [t].[RoomId]
     WHERE [h].[Id] = @HotelId AND @Date NOT BETWEEN [t].[ArrivalDate] AND [t].[ReturnDate] AND [r].[Beds] > @People
  ORDER BY [Price] DESC

	IF(@HotelId NOT IN (SELECT [rt].[HotelId] FROM @resultTable AS rt))
	BEGIN
		RETURN 'No rooms available'
	END

	DECLARE @targetRoomId INT = (SELECT [rt].[RoomId] FROM @resultTable AS rt WHERE [rt].[HotelId] = @HotelId)
	DECLARE @targetRoomType VARCHAR(50) = (SELECT [rt].[RoomType] FROM @resultTable AS rt WHERE [rt].[HotelId] = @HotelId)
	DECLARE @targetRoomBeds INT = (SELECT [rt].[RoomBeds] FROM @resultTable AS rt WHERE [rt].[HotelId] = @HotelId)
	DECLARE @price DECIMAL(15, 2) = (SELECT [rt].[Price] FROM @resultTable AS rt WHERE [rt].[HotelId] = @HotelId)

	RETURN 'Room ' +
	       CAST(@TargetRoomId AS VARCHAR(50)) + ': ' + @targetRoomType + 
		   ' (' + CAST(@targetRoomBeds AS VARCHAR(50)) + ' beds) - $' + CAST(@price AS VARCHAR(50))
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)