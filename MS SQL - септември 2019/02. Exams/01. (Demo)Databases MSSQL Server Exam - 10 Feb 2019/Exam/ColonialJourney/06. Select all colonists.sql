  SELECT [c].[Id],
         [c].[FirstName]+ ' ' + [c].[LastName] AS [FullName],
		 [c].[Ucn]
   FROM [dbo].[Colonists] AS c
ORDER BY [c].[FirstName], [c].[LastName], [c].[Id];