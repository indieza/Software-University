CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
AS
BEGIN
	DECLARE @targetJourney INT = (SELECT [j].[Id]
	                                FROM [dbo].[Journeys] AS j
								   WHERE [j].[Id] = @JourneyId)

	IF(@targetJourney IS NULL)
	BEGIN
		RAISERROR('The journey does not exist!', 16, 1)
		RETURN
	END

	DECLARE @targetPurpose VARCHAR(50) = (SELECT [j].[Purpose]
	                                        FROM [dbo].[Journeys] AS j
							               WHERE [j].[Id] = @targetJourney)

	IF(@targetPurpose = @NewPurpose)
	BEGIN
		RAISERROR('You cannot change the purpose!', 16, 2)
		RETURN
	END

	UPDATE [dbo].[Journeys]
	   SET
	       [dbo].[Journeys].[Purpose] = @targetPurpose
	 WHERE [dbo].[Journeys].[Id] = @targetJourney
END

EXEC usp_ChangeJourneyPurpose 1, 'Technical'
SELECT * FROM Journeys
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'