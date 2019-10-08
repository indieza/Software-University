  SELECT [j].[Id],
         FORMAT([j].[JourneyStart], 'dd/MM/yyyy') AS [JourneyStart],
		 FORMAT([j].[JourneyEnd], 'dd/MM/yyyy') AS [JourneyEnd]
    FROM [dbo].[Journeys] AS j
   WHERE [j].[Purpose] = 'Military'
ORDER BY [j].[JourneyStart];