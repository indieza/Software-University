CREATE TABLE DeletedJourneys
(
	Id INT,
	JourneyStart DATETIME,
	JourneyEnd DATETIME,
	Purpose VARCHAR(50),
	DestinationSpaceportId INT,
	SpaceshipId INT
);

CREATE TRIGGER tr_DeletedJourneys ON [dbo].[Journeys] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[DeletedJourneys]
	(
	    [Id],
	    [JourneyStart],
	    [JourneyEnd],
	    [Purpose],
	    [DestinationSpaceportId],
	    [SpaceshipId]
	)
	SELECT * FROM [DELETED] AS d
END

DELETE FROM TravelCards
WHERE JourneyId =  1

DELETE FROM Journeys
WHERE Id =  1