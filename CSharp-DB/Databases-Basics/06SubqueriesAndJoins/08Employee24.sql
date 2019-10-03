SELECT e.EmployeeID,
       e.FirstName,
  CASE
       WHEN p.StartDate >= CAST('2005' AS DATE) THEN NULL
	   ELSE p.[Name]
END AS [ProjectName]
  FROM Employees AS e
  JOIN EmployeesProjects AS ep
    ON ep.EmployeeID = e.EmployeeID AND e.EmployeeID = 24
  JOIN Projects AS p
    ON p.ProjectID = ep.ProjectID