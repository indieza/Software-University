  SELECT [c].[FirstName], [c].[LastName], [c].[Phone]
    FROM [dbo].[Clients] AS c
ORDER BY [c].[LastName], [c].[ClientId];