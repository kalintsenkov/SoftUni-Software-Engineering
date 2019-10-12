    SELECT p.[Name],
		   COUNT(sp.Id) AS [Count]
      FROM Spaceports AS sp
RIGHT JOIN Planets AS p
        ON p.Id = sp.PlanetId
  GROUP BY p.[Name]
  ORDER BY [Count] DESC, p.[Name]