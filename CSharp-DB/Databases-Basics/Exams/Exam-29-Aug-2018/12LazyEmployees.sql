  SELECT DISTINCT e.Id,
         CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
    FROM Shifts AS s
    JOIN Employees AS e
      ON e.Id = s.EmployeeId
   WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id