CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts AS a 
		WHERE a.Id = @AccountId) OR @accountId IS NULL)
	BEGIN 
		ROLLBACK
		RAISERROR('Invalid accountId', 16, 2)
		RETURN
	END

	UPDATE Accounts
	   SET Balance -= @moneyAmount
	 WHERE Id = @accountId
COMMIT