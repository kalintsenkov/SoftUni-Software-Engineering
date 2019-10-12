SELECT r.JobDuringJourney,
       r.FullName,
	   r.JobRank
  FROM (SELECT tc.JobDuringJourney,
               CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
        	   ROW_NUMBER() OVER (PARTITION BY tc.JobDuringJourney ORDER BY DATEDIFF(MONTH, c.BirthDate, GETDATE()) DESC)
        	AS [JobRank]
          FROM TravelCards AS tc
          JOIN Colonists AS c
            ON c.Id = tc.ColonistId) AS r
 WHERE r.JobRank = 2