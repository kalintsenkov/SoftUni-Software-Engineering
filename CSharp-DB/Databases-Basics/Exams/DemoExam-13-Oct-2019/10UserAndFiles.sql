  SELECT u.Username,
		 AVG(f.Size) AS [Size]
    FROM Commits AS c
    JOIN Users AS u
      ON u.Id = c.ContributorId
	JOIN Files AS f
	  ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC,
         u.Username