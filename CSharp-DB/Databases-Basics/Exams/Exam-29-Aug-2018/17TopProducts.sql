   SELECT i.[Name] AS [Item],
		  c.[Name] AS [Category],
		  SUM(oi.Quantity) AS [Count],
		  SUM(i.Price * oi.Quantity) AS [TotalPrice]
     FROM OrderItems AS oi
FULL JOIN Orders AS o
       ON o.Id = oi.OrderId
FULL JOIN Items AS i
       ON i.Id = oi.ItemId
FULL JOIN Categories AS c
       ON c.Id = i.CategoryId
 GROUP BY i.[Name], c.[Name]
 ORDER BY [TotalPrice] DESC, [Count] DESC