  SELECT emp.EmployeeID,
		 emp.FirstName,
		 emp.ManagerID,
		 mng.FirstName AS [ManagerName]
    FROM Employees AS emp
    JOIN Employees AS mng
      ON mng.EmployeeID = emp.ManagerID
   WHERE emp.ManagerID IN (3, 7)
ORDER BY emp.EmployeeID