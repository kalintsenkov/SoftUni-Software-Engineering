  SELECT e.DepartmentID,
         SUM(e.Salary) AS [TotalSalary]
    FROM Employees AS e
GROUP BY DepartmentID
ORDER BY DepartmentID