CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(15, 2))
AS
BEGIN
	  SELECT ah.FirstName,
		 ah.LastName
	    FROM AccountHolders AS ah
	    JOIN Accounts AS a
	      ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName,
		 ah.LastName
	  HAVING SUM(a.Balance) > @number
	ORDER BY ah.FirstName,
		 ah.LastName
END
