  SELECT k.Destination,
         k.TripsCount
    FROM (    SELECT f.Destination,
                     COUNT(t.PassengerId) AS [TripsCount]
                FROM Tickets AS t
          FULL JOIN Flights AS f
                 ON f.Id = t.FlightId
           GROUP BY f.Destination) AS k
ORDER BY k.TripsCount DESC,
         k.Destination