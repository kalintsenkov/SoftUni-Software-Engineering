  SELECT k.ContinentCode,
         k.CurrencyCode,
         k.CurrencyUsage
    FROM (  SELECT [cont].ContinentCode,
                   [count].CurrencyCode,
          		     COUNT([count].CurrencyCode)
          	    AS [CurrencyUsage],
          	       DENSE_RANK() OVER (PARTITION BY [cont].ContinentCode ORDER BY COUNT([count].CurrencyCode) DESC)
                AS [Rank]
              FROM Countries AS [count]
              JOIN Continents AS [cont]
                ON [cont].ContinentCode = [count].ContinentCode
          GROUP BY [cont].ContinentCode,
                   [count].CurrencyCode) AS k
   WHERE k.[Rank] = 1
     AND k.CurrencyUsage != 1
ORDER BY k.ContinentCode
