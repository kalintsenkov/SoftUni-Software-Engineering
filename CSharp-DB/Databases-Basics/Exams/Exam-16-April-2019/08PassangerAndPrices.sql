  SELECT TOP(10) p.FirstName,
  	 p.LastName,
  	 t.Price
    FROM Passengers AS p
    JOIN Tickets AS t
      ON t.PassengerId = p.Id
ORDER BY t.Price DESC,
	 p.FirstName,
	 p.LastName
