   SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
     CASE
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 1 THEN 'Sunday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 2 THEN 'Monday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 3 THEN 'Tuesday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 4 THEN 'Wednesday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 5 THEN 'Thursday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 6 THEN 'Friday'
	  WHEN DATEPART(WEEKDAY, s.CheckIn) = 7 THEN 'Saturday'
   END AS [Day of week]
     FROM Employees AS e
LEFT JOIN Orders AS o
       ON e.Id = o.EmployeeId
LEFT JOIN Shifts AS s
       ON s.EmployeeId = e.Id
    WHERE o.Id IS NULL
      AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
 ORDER BY e.Id
