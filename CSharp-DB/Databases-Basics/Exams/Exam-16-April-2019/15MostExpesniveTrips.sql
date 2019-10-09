  SELECT r.FirstName,
         r.LastName,
  	 r.Destination,
  	 r.Price
    FROM (SELECT p.FirstName,
                 p.LastName,
  	         f.Destination,
  	         t.Price,
  	         DENSE_RANK() OVER (PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) 
              AS [Price Rank]
            FROM Passengers AS p
            JOIN Tickets AS t
              ON t.PassengerId = p.Id
            JOIN Flights AS f
              ON f.Id = t.FlightId) AS r
   WHERE r.[Price Rank] = 1
ORDER BY r.Price DESC,
         r.FirstName,
         r.LastName,
         r.Destination
