CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(c.Id)
	                        FROM Commits AS c
				JOIN Users AS u
				  ON u.Id = c.ContributorId
			       WHERE u.Username = @username)

	RETURN @count
END
