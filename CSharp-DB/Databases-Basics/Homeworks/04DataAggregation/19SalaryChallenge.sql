SELECT TOP(10) 
       e.FirstName,
       e.LastName,
       e.DepartmentID
  FROM (  SELECT DepartmentId,
                 AVG(Salary) 
              AS [AverageSalary]
            FROM Employees
        GROUP BY DepartmentID) AS g, 
	         Employees AS e
  WHERE e.DepartmentID = g.DepartmentID 
    AND e.Salary > g.AverageSalary
