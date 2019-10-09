  SELECT lt.[Type],
  	 COUNT(t.LuggageTypeId)
      AS [MostUsedLuggage]
    FROM LuggageTypes AS lt
    JOIN Luggages AS t
      ON t.LuggageTypeId = lt.Id
GROUP BY lt.[Type]
ORDER BY COUNT(t.LuggageTypeId) DESC,
         lt.[Type] 
