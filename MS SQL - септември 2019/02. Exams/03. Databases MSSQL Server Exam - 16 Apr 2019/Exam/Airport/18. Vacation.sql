CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(20), @destination VARCHAR(30), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!'

	DECLARE @targetFlightId INT = (SELECT [f].[Id]
	                                 FROM [dbo].[Flights] AS f
									WHERE [f].[Origin] = @origin AND [f].[Destination] = @destination)

	IF(@targetFlightId IS NULL)
		RETURN 'Invalid flight!'

	DECLARE @price DECIMAL(15, 2) = (SELECT [t].[Price]
	                                   FROM [dbo].[Flights] AS f
									   JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
									  WHERE [f].[Id] = @targetFlightId)

	DECLARE @sum DECIMAL(15, 2) = @price * @peopleCount

	RETURN 'Total price ' + CAST(@sum AS VARCHAR(100))
END