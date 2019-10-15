  SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
  	     e.Phone AS [Phone Number]
    FROM Employees AS e
   WHERE e.Phone LIKE '3%'
ORDER BY e.FirstName, e.Phone