  SELECT TOP(5) c.[Name] AS [CategoryName],
         COUNT(r.Id) AS [ReportsNumber]
    FROM Reports AS r
    JOIN Categories AS c
      ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY COUNT(r.Id) DESC, 
         c.[Name]