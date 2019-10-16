SELECT TOP(10) k.[Full Name],
       SUM(k.Price) AS [Total Price],
	   SUM(k.Items) AS [Items]
  FROM (SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
               i.Price * oi.Quantity AS [Price],
          	   oi.Quantity AS [Items]
          FROM OrderItems AS oi
          JOIN Items AS i
            ON i.Id = oi.ItemId
          JOIN Orders AS o
            ON o.Id = oi.OrderId
          JOIN Employees AS e
            ON e.Id = o.EmployeeId
		 WHERE o.[DateTime] < '2018-06-15') AS k
GROUP BY k.[Full Name]
ORDER BY [Total Price] DESC, [Items] DESC