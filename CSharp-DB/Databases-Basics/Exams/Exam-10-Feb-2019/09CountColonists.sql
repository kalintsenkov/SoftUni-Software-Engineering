SELECT COUNT(c.Id) AS [count]
  FROM TravelCards AS tc
  JOIN Colonists AS c
    ON c.Id = tc.Id
  JOIN Journeys AS j
    ON j.Id = tc.JourneyId
 WHERE j.Purpose = 'technical'