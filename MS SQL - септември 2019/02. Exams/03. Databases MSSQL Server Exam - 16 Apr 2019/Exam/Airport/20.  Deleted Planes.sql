CREATE TABLE DeletedPlanes
(
	Id INT,
	[Name] VARCHAR(30),
	Seats INT,
	[Range] INT
);

CREATE TRIGGER tr_DeletedPlanes ON [dbo].[Planes] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[DeletedPlanes]
	(
	    [Id],
	    [Name],
	    [Seats],
	    [Range]
	)
	SELECT * FROM [DELETED] AS d
END

DELETE Tickets
WHERE FlightId IN (SELECT Id FROM Flights WHERE PlaneId = 8)

DELETE FROM Flights
WHERE PlaneId = 8

DELETE FROM Planes
WHERE Id = 8