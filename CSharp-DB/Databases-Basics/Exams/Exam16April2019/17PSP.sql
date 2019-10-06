   SELECT p.[Name],
          p.Seats,
          COUNT(t.PassengerId) AS [Passengers Count]
     FROM Flights AS f
FULL JOIN Tickets AS t
       ON t.FlightId = f.Id
FULL JOIN Planes AS p
       ON p.Id = f.PlaneId
 GROUP BY p.[Name],
          p.Seats
 ORDER BY [Passengers Count] DESC,
          p.[Name],
	  p.Seats
