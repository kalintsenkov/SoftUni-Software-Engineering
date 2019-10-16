  SELECT emp.FirstName + ' ' + emp.LastName AS FullName, 
         DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
  	     e.TotalPrice AS TotalPrice 
    FROM (  SELECT o.EmployeeId, 
                   SUM(oi.Quantity * i.Price) AS TotalPrice, 
  				   o.[DateTime],
          	       ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC) 
  			    AS [Rank]
              FROM Orders AS o
              JOIN OrderItems AS oi 
  			    ON oi.OrderId = o.Id
              JOIN Items AS i
  			    ON i.Id = oi.ItemId
          GROUP BY o.EmployeeId, o.Id, o.[DateTime]) AS e 
    JOIN Employees AS emp 
	  ON emp.Id = e.EmployeeId
    JOIN Shifts AS s 
	  ON s.EmployeeId = e.EmployeeId
   WHERE e.[Rank] = 1 
     AND e.[DateTime] BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC