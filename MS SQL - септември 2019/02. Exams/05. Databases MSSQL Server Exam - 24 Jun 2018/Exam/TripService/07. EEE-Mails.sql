  SELECT [a].[FirstName],
         [a].[LastName],
  	     FORMAT([a].[BirthDate], 'MM-dd-yyyy') AS [BirthDate],
  	     [c].[Name] AS [Hometown],
  	     [a].[Email]
    FROM [dbo].[Accounts] AS a
    JOIN [dbo].[Cities] AS [c] ON [a].[CityId] = [c].[Id]
   WHERE [a].[Email] LIKE 'e%'
ORDER BY [Hometown] DESC;