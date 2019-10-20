   SELECT IIF(e.FirstName IS NULL OR e.FirstName = '', 'None', CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee],
          ISNULL(d.[Name], 'None') AS [Department],
	  c.[Name] AS [Category],
	  r.[Description],
	  FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	  s.[Label] AS [Status],
	  u.[Name] AS [User]
     FROM Reports AS r
LEFT JOIN Employees AS e
       ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d
       ON d.Id = e.DepartmentId
LEFT JOIN Categories AS c
       ON c.Id = r.CategoryId
LEFT JOIN [Status] AS s
       ON s.Id = r.StatusId
LEFT JOIN Users AS u
       ON u.Id = r.UserId
 ORDER BY e.FirstName DESC, 
          e.LastName DESC,
	  d.[Name], 
	  c.[Name], 
	  r.[Description],
	  r.OpenDate, 
	  s.[Label], 
	  u.[Name]
