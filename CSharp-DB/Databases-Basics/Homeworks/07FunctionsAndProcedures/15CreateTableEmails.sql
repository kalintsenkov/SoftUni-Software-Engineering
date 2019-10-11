CREATE TRIGGER tr_CreateEmail ON Logs FOR INSERT
AS
BEGIN
	DECLARE @recipient INT;
	DECLARE @subject VARCHAR(200);
	DECLARE @oldBalance DECIMAL(15, 2);
	DECLARE @newBalance DECIMAL(15, 2);
	DECLARE @body VARCHAR(200);

	SET @recipient = (SELECT i.AccountId FROM inserted AS i)
	SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(MAX))
	SET @oldBalance = (SELECT i.OldSum FROM inserted AS i)
	SET @newBalance = (SELECT i.NewSum FROM inserted AS i)
	SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(MAX)) 
	            + ' your balance was changed from ' + CAST(@oldBalance AS VARCHAR(MAX))
		    + ' to ' + CAST(@newBalance AS VARCHAR(MAX))

	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	VALUES	    (@recipient, @subject, @body)
END
