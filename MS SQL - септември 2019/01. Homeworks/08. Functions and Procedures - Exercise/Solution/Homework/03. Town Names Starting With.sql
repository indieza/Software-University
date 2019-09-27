CREATE PROCEDURE usp_GetTownsStartingWith(@Identity VARCHAR(20))
AS
SELECT [t].[Name] AS [Town]
  FROM [dbo].[Towns] AS t
 WHERE [t].[Name] LIKE @Identity + '%'