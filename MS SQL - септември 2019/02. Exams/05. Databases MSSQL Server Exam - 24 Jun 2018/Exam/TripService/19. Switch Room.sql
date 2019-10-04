CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @realHotelId INT = (SELECT [h].[Id]
                                  FROM [dbo].[Hotels] AS h
								  JOIN [dbo].[Rooms] AS [r] ON [h].[Id] = [r].[HotelId]
								  JOIN [dbo].[Trips] AS [t] ON [r].[Id] = [t].[RoomId]
                                 WHERE [t].[Id] = @TripId)

	DECLARE @checkHotelId INT = (SELECT [h].[Id]
                                   FROM [dbo].[Hotels] AS h
                                   JOIN [dbo].[Rooms] AS [r] ON [h].[Id] = [r].[HotelId]
                                  WHERE [r].[Id] = @TargetRoomId)

	IF(@realHotelId <> @checkHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1)
		RETURN
	END

	DECLARE @realPeopleCount INT = (SELECT COUNT([at].[AccountId])
                                      FROM [dbo].[AccountsTrips] AS [at]
                                     WHERE [at].[TripId] = @TripId)

	DECLARE @checkRoomsCount INT = (SELECT [r].[Beds]
                                      FROM [dbo].[Rooms] AS [r]
                                     WHERE [r].[Id] = @TargetRoomId)

	IF(@realPeopleCount > @checkRoomsCount)
	BEGIN
		RAISERROR('Not enough beds in target room!', 16, 2)
		RETURN
	END

	UPDATE [dbo].[Trips]
	   SET
	       [dbo].[Trips].[RoomId] = @TargetRoomId
	 WHERE [dbo].[Trips].[Id] = @TripId
END

EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10