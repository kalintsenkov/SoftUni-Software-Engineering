   SELECT TOP(5) k.Country,
		  ISNULL(k.PeakName, '(no highest peak)') 
	   AS [Highest Peak Name],
		  ISNULL(k.[Highest Peak Elevation], 0) 
	   AS [Highest Peak Elevation],
		  ISNULL(k.MountainRange, '(no mountain)') 
	   AS [Mountain]
     FROM (   SELECT c.CountryName AS [Country],
           		     p.PeakName,
                     MAX(p.Elevation) AS [Highest Peak Elevation],
           		     m.MountainRange,
           		     DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC)
           	      AS [Rank]
                FROM Countries AS c
           LEFT JOIN MountainsCountries AS mc
                  ON mc.CountryCode = c.CountryCode
           LEFT JOIN Mountains AS m
                  ON m.Id = mc.MountainId
           LEFT JOIN Peaks AS p
                  ON p.MountainId = m.Id
            GROUP BY c.CountryName,
           		     p.PeakName,
           		     m.MountainRange) AS k
    WHERE k.[Rank] = 1
 ORDER BY k.Country, [Highest Peak Name]