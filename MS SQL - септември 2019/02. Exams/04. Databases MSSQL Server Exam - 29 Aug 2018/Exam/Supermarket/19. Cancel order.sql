CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	DECLARE @targetOrderId INT = (SELECT [o].[Id]
	                                FROM [dbo].[Orders] AS o
								   WHERE [o].[Id] = @OrderId)

	IF(@targetOrderId IS NULL)
	BEGIN
		RAISERROR('The order does not exist!', 16, 1)
		RETURN
	END

	DECLARE @targetDate DATETIME = (SELECT [o].[DateTime]
	                                  FROM [dbo].[Orders] AS o
									 WHERE [o].[Id] = @OrderId)

	IF(DATEDIFF(DAY, @targetDate, @CancelDate) > 3)
	BEGIN
		RAISERROR('You cannot cancel the order!', 16, 2)
		RETURN
	END

	DELETE
	  FROM [dbo].[OrderItems]
	 WHERE [dbo].[OrderItems].[OrderId] = @OrderId

	DELETE
	  FROM [dbo].[Orders]
	 WHERE [dbo].[Orders].[Id] = @OrderId
END

EXEC usp_CancelOrder 1, '2018-06-02'
SELECT COUNT(*) FROM Orders
SELECT COUNT(*) FROM OrderItems
EXEC usp_CancelOrder 1, '2018-06-15'
EXEC usp_CancelOrder 124231, '2018-06-15'