SELECT r.[DepartmentID],
       r.[Salary] AS [ThirdHighestSalary]
  FROM (  SELECT DepartmentId, 
                 Salary,
		 DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC)
	      AS [Rank]
            FROM Employees
	GROUP BY DepartmentID,
	         Salary) AS r
 WHERE r.[Rank] = 3
