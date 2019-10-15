  SELECT e.Id, e.FirstName
    FROM Employees AS e
   WHERE e.Salary > 6500
ORDER BY e.FirstName, e.Id