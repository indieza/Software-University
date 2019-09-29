CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE [dbo].[Flights]
	   SET
	       [dbo].[Flights].[DepartureTime] = NULL, -- datetime
	       [dbo].[Flights].[ArrivalTime] = NULL
	 WHERE [dbo].[Flights].[ArrivalTime] > [dbo].[Flights].[DepartureTime]
END