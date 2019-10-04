CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @resultTable TABLE
	(
		HotelId INT,
		RoomId INT,
		RoomType VARCHAR(50),
		Beds INT,
		ResultPrice DECIMAL(15, 2)
	)

	INSERT INTO @resultTable
	(
	    [HotelId],
		[RoomId],
		[RoomType],
	    [Beds],
	    [ResultPrice]
	)
	SELECT TOP(1) [h].[Id],
	              [r].[Id],
				  [r].[Type],
				  [r].[Beds],
				  ([h].[BaseRate] + [r].[Price]) * @People AS [PriceFull]
      FROM [dbo].[Hotels] AS h
      JOIN [dbo].[Rooms] AS [r] ON @HotelId = [r].[HotelId]
      JOIN [dbo].[Trips] AS [t] ON [r].[Id] = [t].[RoomId]
     WHERE @Date NOT BETWEEN [t].[ArrivalDate] AND
	       [t].[ReturnDate] AND
		   [h].[Id] = @HotelId AND
		   [r].[Beds] > @People AND
		   [t].[CancelDate] IS NULL
  ORDER BY [PriceFull] DESC

	IF(@HotelId NOT IN (SELECT [rt].[HotelId] FROM @resultTable AS rt))
		RETURN 'No rooms available'

	DECLARE @targetRoom INT = (SELECT [rt].[RoomId] FROM @resultTable AS rt)
	DECLARE @targetType VARCHAR(50) = (SELECT [rt].[RoomType] FROM @resultTable AS rt)
	DECLARE @targetBeds INT = (SELECT [rt].[Beds] FROM @resultTable AS rt)
	DECLARE @price DECIMAL(15, 2) = (SELECT [rt].[ResultPrice] FROM @resultTable AS rt)

	RETURN 'Room ' + CAST(@targetRoom AS VARCHAR(50)) + ': ' + @targetType +
	       ' (' + CAST(@targetBeds AS VARCHAR(50)) + ' beds) - $' +
		   CAST(@price AS VARCHAR(50))
END

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)