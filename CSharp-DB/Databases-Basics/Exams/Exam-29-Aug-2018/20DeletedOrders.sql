CREATE TRIGGER tr_DeletedOrders ON OrderItems FOR DELETE
AS
BEGIN
	INSERT INTO DeletedOrders(OrderId, ItemId, ItemQuantity)
	     SELECT d.OrderId, d.ItemId, d.Quantity
	       FROM deleted AS d
END
