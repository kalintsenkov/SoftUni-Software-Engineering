  SELECT e.FirstName,
         e.LastName,
	 COUNT(o.Id) AS [Count]
    FROM Employees AS e
    JOIN Orders AS o
      ON o.EmployeeId = e.Id
GROUP BY e.FirstName, 
         e.LastName
ORDER BY [Count] DESC,
         e.FirstName
