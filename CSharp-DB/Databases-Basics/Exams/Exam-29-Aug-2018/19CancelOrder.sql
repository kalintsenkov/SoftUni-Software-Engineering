CREATE PROC usp_CancelOrder(@orderId INT, @cancelDate DATE)
AS
BEGIN TRANSACTION
	DECLARE @issueDate DATE;

	IF (NOT EXISTS(
	    SELECT * FROM Orders
	     WHERE Id = @orderId))
	BEGIN
		ROLLBACK
		RAISERROR('The order does not exist!', 16, 1)
		RETURN
	END

	SET @issueDate = (SELECT o.[DateTime]
	                    FROM Orders AS o
			   WHERE o.Id = @orderId)

	IF (DATEDIFF(DAY, @issueDate, @cancelDate) > 3)
	BEGIN
		ROLLBACK
		RAISERROR('You cannot cancel the order!', 16, 2)
		RETURN
	END

	DELETE FROM OrderItems
	      WHERE OrderId = @orderId
	
	DELETE FROM Orders
	      WHERE Id = @orderId
COMMIT
