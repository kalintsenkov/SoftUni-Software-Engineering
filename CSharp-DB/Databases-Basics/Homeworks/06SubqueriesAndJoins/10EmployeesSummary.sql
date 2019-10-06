  SELECT TOP(50) emp.EmployeeID,
	 emp.FirstName + ' ' + emp.LastName
      AS [EmployeeName],
         mng.FirstName + ' ' + mng.LastName
      AS [ManagerName],
	 dep.[Name] AS [DepartmentName]
    FROM Employees AS emp
    JOIN Employees AS mng
      ON mng.EmployeeID = emp.ManagerID
    JOIN Departments AS dep
      ON dep.DepartmentID = emp.DepartmentID
ORDER BY emp.EmployeeID
