  SELECT c.Id,
	 CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
	 c.Ucn
    FROM Colonists AS c
ORDER BY c.FirstName, c.LastName, c.Id
