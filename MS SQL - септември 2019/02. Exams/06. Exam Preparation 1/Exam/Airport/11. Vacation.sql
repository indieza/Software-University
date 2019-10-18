CREATE FUNCTION dbo.udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!'

	DECLARE @flightId INT = (SELECT [f].[Id]
	                           FROM [dbo].[Flights] AS f
							  WHERE [f].[Origin] = @origin AND [f].[Destination] = @destination)

	IF(@flightId IS NULL)
		RETURN 'Invalid flight!'

	DECLARE @price DECIMAL(15, 2) = (SELECT [t].[Price]
	                                   FROM [dbo].[Tickets] AS t
									  WHERE [t].[FlightId] = @flightId)

	RETURN CONCAT('Total price ', @price * @peopleCount)
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)