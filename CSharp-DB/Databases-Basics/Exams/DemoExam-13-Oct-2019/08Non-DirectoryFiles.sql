   SELECT f.Id,
          f.[Name],
  	      CONCAT(f.Size, 'KB') AS [Size]
     FROM Files AS f
LEFT JOIN Files AS p
       ON p.ParentId = f.Id
	WHERE p.Id IS NULL
 ORDER BY f.Id, f.[Name], f.Size DESC