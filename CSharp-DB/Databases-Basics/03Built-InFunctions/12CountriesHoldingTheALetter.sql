  SELECT CountryName AS [Country Name], 
         IsoCode AS [ISO Code]
    FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode