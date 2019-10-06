SELECT COUNT(c.CountryCode) AS [CountryCode]
  FROM (   SELECT c.CountryCode
             FROM Countries AS c 
        LEFT JOIN MountainsCountries AS mc
               ON mc.CountryCode = c.CountryCode
        LEFT JOIN Mountains AS m
               ON m.Id = mc.MountainId
            WHERE m.Id IS NULL
         GROUP BY c.CountryCode) AS c
