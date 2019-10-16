  SELECT TOP(1) oi.OrderId,
	 SUM(i.Price * oi.Quantity) AS [Total Price]
    FROM OrderItems AS oi
    JOIN Items AS i
      ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY [Total Price] DESC
