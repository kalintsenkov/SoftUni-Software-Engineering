CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
BEGIN
	SELECT ah.Id AS [Account Id],
	       ah.FirstName AS [First Name],
	       ah.LastName AS [Last Name],
	       a.Balance AS [Current Balance],
	       dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	    AS [Balance in 5 years]
	  FROM AccountHolders AS ah
	  JOIN Accounts AS a
	    ON a.AccountHolderId = ah.Id
	 WHERE a.Id = @accountId
END
