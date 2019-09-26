CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	          FROM [dbo].[Planets] AS p
			  JOIN [dbo].[Spaceports] AS [s] ON [p].[Id] = [s].[PlanetId]
			  JOIN [dbo].[Journeys] AS [j] ON [s].[Id] = [j].[DestinationSpaceportId]
			  JOIN [dbo].[TravelCards] AS [tc] ON [j].[Id] = [tc].[JourneyId]
			  JOIN [dbo].[Colonists] AS [c] ON [tc].[ColonistId] = [c].[Id]
			 WHERE [p].[Name] = @PlanetName)
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')