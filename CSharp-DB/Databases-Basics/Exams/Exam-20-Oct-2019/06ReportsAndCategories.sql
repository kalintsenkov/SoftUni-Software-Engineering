  SELECT r.[Description],
  	     c.[Name] AS [CategoryName]
    FROM Reports AS r
    JOIN Categories AS c
      ON c.Id = r.CategoryId
ORDER BY r.[Description], c.[Name]