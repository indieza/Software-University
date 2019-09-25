DELETE
  FROM [dbo].[Tickets]
 WHERE [dbo].[Tickets].[FlightId] IN (
SELECT [f].[Id]
  FROM [dbo].[Flights] AS f
 WHERE [f].[Destination] = 'Ayn Halagim');

DELETE
  FROM [dbo].[Flights]
 WHERE [dbo].[Flights].[Destination] = 'Ayn Halagim';