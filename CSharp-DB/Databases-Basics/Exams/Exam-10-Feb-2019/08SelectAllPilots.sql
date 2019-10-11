  SELECT c.Id AS [id],
  	     CONCAT(c.FirstName, ' ', c.LastName) AS [full_name]
    FROM TravelCards AS tc
    JOIN Colonists AS c
      ON c.Id = tc.ColonistId
   WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id