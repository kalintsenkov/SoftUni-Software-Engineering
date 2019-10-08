CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN 
	SELECT SUM(r.Cash) AS [SumCash]
	  FROM (SELECT g.[Name],
	               us.Cash,
	  	       ROW_NUMBER() OVER (PARTITION BY @gameName ORDER BY us.Cash DESC)
	            AS [Row Number]
	          FROM Games AS g
	          JOIN UsersGames AS us
	            ON us.GameId = g.Id
	         WHERE g.[Name] = @gameName) AS r
	  WHERE r.[Row Number] % 2 != 0
