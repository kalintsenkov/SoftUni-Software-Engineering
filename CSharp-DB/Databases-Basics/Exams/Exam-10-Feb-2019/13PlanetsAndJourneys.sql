  SELECT p.[Name] AS [PlanetName],
		 COUNT(j.Id) AS [JourneysCount]
    FROM Journeys AS j
    JOIN Spaceports AS sp
      ON sp.Id = j.DestinationSpaceportId
    JOIN Planets AS p
      ON p.Id = sp.PlanetId
GROUP BY p.[Name]
ORDER BY [JourneysCount] DESC, [PlanetName]