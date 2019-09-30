  SELECT [k].[Email Provider], COUNT([k].[Email Provider]) AS [Number Of Users]
    FROM (
  SELECT SUBSTRING([u].[Email], CHARINDEX('@', [u].[Email]) + 1, LEN([u].[Email])) AS [Email Provider]
    FROM [dbo].[Users] AS u) AS k
GROUP BY [k].[Email Provider]
ORDER BY [Number Of Users] DESC, [k].[Email Provider];