  SELECT TOP(1) ss.[Name] AS [SpaceshipName],
	 sp.[Name] AS [SpaceportName]
    FROM Journeys AS j
    JOIN Spaceships AS ss
      ON ss.Id = j.SpaceshipId
    JOIN Spaceports AS sp
      ON sp.Id = j.DestinationSpaceportId
ORDER BY ss.LightSpeedRate DESC
