  SELECT e.Id, e.FirstName, e.LastName
    FROM Employees AS e
    JOIN Orders AS o
      ON o.EmployeeId = e.Id
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY e.Id