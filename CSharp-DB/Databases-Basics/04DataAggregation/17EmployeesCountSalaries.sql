  SELECT COUNT(Salary) AS [Count]
    FROM Employees
GROUP BY ManagerID
  HAVING ManagerID IS NULL