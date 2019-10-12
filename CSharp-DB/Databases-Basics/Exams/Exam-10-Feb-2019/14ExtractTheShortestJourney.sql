SELECT r.Id,
	   r.PlanetName,
       r.SpaceportName,
	   r.JourneyPurpose
  FROM (SELECT j.Id, 
               p.[Name] AS [PlanetName],
	           sp.[Name] AS [SpaceportName],
	           j.Purpose AS [JourneyPurpose],
	           ROW_NUMBER() OVER (ORDER BY DATEDIFF(SECOND, j.JourneyStart, j.JourneyEnd))
			AS [Rank]
          FROM Spaceports AS sp
          JOIN Planets AS p
            ON p.Id = sp.PlanetId
          JOIN Journeys AS j
            ON j.DestinationSpaceportId = sp.Id) AS r
 WHERE r.[Rank] = 1