CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(50))
AS
BEGIN
	SELECT [f].[Id],
	       [f].[Name],
		   CONCAT([f].[Size], 'KB') AS [Size]
	  FROM [dbo].[Files] AS f
	 WHERE CHARINDEX(@extension, [f].[Name]) > 0
  ORDER BY [f].[Id], [f].[Name], [f].[Size] DESC
END

EXEC usp_FindByExtension 'txt'