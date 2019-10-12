SELECT r.Id, r.JobName
  FROM (SELECT j.Id,
	       tc.JobDuringJourney AS [JobName],
	       ROW_NUMBER() OVER (ORDER BY DATEDIFF(SECOND, j.JourneyStart, j.JourneyEnd) DESC)
	    AS [Rank]
          FROM Spaceports AS sp
          JOIN Planets AS p
            ON p.Id = sp.PlanetId
          JOIN Journeys AS j
            ON j.DestinationSpaceportId = sp.Id
          JOIN TravelCards AS tc
	    ON tc.JourneyId = j.Id) AS r
 WHERE r.[Rank] = 1
