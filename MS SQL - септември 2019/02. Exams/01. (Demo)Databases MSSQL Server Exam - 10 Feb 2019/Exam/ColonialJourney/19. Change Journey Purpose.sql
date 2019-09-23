CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
AS
DECLARE @targetId INT = (SELECT [j].[Id] FROM [dbo].[Journeys] AS j WHERE [j].[Id] = @JourneyId);

IF(@targetId IS NULL)
	RAISERROR('The journey does not exist!', 16, 1)

DECLARE @targetPurpose VARCHAR(30) = (SELECT [j].[Purpose] FROM [dbo].[Journeys] AS j WHERE [j].[Id] = @JourneyId)

IF(@targetPurpose = @NewPurpose)
	RAISERROR('You cannot change the purpose!', 16, 2)

UPDATE [dbo].[Journeys]
SET
    [dbo].[Journeys].[Purpose] = @NewPurpose -- varchar
WHERE [dbo].[Journeys].[Id] = @JourneyId

EXEC usp_ChangeJourneyPurpose 1, 'Technical'
SELECT * FROM Journeys
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'