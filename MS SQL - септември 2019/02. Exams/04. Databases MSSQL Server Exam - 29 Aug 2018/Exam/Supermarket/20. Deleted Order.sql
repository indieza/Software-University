CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
);

CREATE TRIGGER tr_DeletedOrders ON [dbo].[OrderItems] FOR DELETE
AS
BEGIN
	INSERT INTO [dbo].[DeletedOrders]
	(
	    [OrderId],
	    [ItemId],
	    [ItemQuantity]
	)
	SELECT * FROM [DELETED] AS d
END

DELETE FROM OrderItems
WHERE OrderId = 5

DELETE FROM Orders
WHERE Id = 5