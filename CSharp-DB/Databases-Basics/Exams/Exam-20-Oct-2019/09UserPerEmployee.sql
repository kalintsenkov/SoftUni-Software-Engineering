   SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName],
          COUNT(u.Id) AS [UsersCount]
     FROM Reports AS r
FULL JOIN Employees AS e
       ON e.Id = r.EmployeeId
FULL JOIN Users AS u
       ON u.Id = r.UserId
    WHERE e.FirstName IS NOT NULL
 GROUP BY e.FirstName, e.LastName
 ORDER BY [UsersCount] DESC,
          [FullName]