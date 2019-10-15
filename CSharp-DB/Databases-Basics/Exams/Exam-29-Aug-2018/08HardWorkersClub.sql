  SELECT a.FirstName,
         a.LastName,
  	 a.[Work hours]
    FROM (  SELECT d.Id,
		   d.FirstName, 
                   d.LastName,
                   AVG(d.[Hours]) AS [Work hours]
              FROM (SELECT e.Id,
			   e.FirstName,
              	           e.LastName,
              	           DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [Hours]
                      FROM Shifts AS s
                      JOIN Employees AS e
                        ON e.Id = s.EmployeeId) AS d
          GROUP BY d.Id, d.FirstName, d.LastName) AS a
   WHERE a.[Work hours] > 7
ORDER BY a.[Work hours] DESC, a.Id
