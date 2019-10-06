   SELECT p.PassportId, 
		  p.[Address]
     FROM Passengers AS p
LEFT JOIN Luggages AS l
       ON l.PassengerId = p.Id
    WHERE l.LuggageTypeId IS NULL
 ORDER BY p.PassportId, 
		  p.[Address]