CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!'

	DECLARE @targetId INT = (SELECT [f].[Id]
	                           FROM [dbo].[Flights] AS f
							  WHERE [f].[Origin] = @origin AND [f].[Destination] = @destination)

	IF(@targetId IS NULL)
		RETURN 'Invalid flight!'

	DECLARE @price DECIMAL(15, 2) = (SELECT [t].[Price]
	                                   FROM [dbo].[Flights] AS f
									   JOIN [dbo].[Tickets] AS [t] ON [f].[Id] = [t].[FlightId]
									  WHERE [f].[Id] = @targetId)

	RETURN CONCAT('Total price ', @peopleCount * @price)
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)