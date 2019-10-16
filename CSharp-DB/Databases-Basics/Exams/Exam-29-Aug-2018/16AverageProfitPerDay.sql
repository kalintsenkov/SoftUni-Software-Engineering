  SELECT DATEPART(DAY, o.[DateTime]) AS [Day],
  	 CAST(AVG(i.Price * oi.Quantity) AS DECIMAL(15, 2)) AS [Total profit]
    FROM OrderItems AS oi
    JOIN Orders AS o
      ON o.Id = oi.OrderId
    JOIN Items AS i
      ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.[DateTime])
ORDER BY [Day]
