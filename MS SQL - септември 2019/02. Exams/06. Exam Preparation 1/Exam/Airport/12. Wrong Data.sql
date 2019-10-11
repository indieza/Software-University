CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE [dbo].[Flights]
	   SET
	       [dbo].[Flights].[DepartureTime] = NULL,
	       [dbo].[Flights].[ArrivalTime] = NULL
	 WHERE [dbo].[Flights].[ArrivalTime] > [dbo].[Flights].[DepartureTime];
END

EXEC usp_CancelFlights