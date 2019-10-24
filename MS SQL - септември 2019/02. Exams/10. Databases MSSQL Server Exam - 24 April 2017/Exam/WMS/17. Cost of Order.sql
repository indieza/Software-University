CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
	DECLARE @result DECIMAL(15, 2) = (SELECT SUM([p].[Price])
                                        FROM [dbo].[Jobs] AS j
                                        JOIN [dbo].[Orders] AS [o] ON [j].[JobId] = [o].[JobId]
                                        JOIN [dbo].[OrderParts] AS [op] ON [o].[OrderId] = [op].[OrderId]
                                        JOIN [dbo].[Parts] AS [p] ON [op].[PartId] = [p].[PartId]
                                       WHERE [j].[JobId] = @JobId)

	IF(@result IS NULL)
		RETURN 0

	RETURN @result
END

SELECT [j].[JobId], dbo.udf_GetCost([j].[JobId])
  FROM [dbo].[Jobs] AS j