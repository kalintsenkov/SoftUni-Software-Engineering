  SELECT s.[Name], s.Manufacturer
    FROM Spaceships AS s
    JOIN Journeys AS j
  	ON j.SpaceshipId = s.Id
    JOIN TravelCards AS tc
      ON tc.JourneyId = j.Id
    JOIN Colonists AS c
      ON c.Id = tc.ColonistId
   WHERE tc.JobDuringJourney = 'pilot'
     AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30
ORDER BY s.[Name]