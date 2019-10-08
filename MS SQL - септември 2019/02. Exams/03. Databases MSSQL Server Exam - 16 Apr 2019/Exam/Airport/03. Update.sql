UPDATE [dbo].[Tickets]
   SET
       [dbo].[Tickets].[Price] *= 1.13
 WHERE [dbo].[Tickets].[FlightId] IN (SELECT [f].[Id]
                                        FROM [dbo].[Flights] AS f
									   WHERE [f].[Destination] = 'Carlsbad');