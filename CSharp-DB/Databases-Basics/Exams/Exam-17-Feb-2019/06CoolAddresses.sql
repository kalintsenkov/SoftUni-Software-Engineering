  SELECT CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName) AS [Full Name], 
	 s.[Address]
    FROM Students AS s
   WHERE s.[Address] LIKE '%road%'
ORDER BY s.FirstName, 
	 s.LastName, 
         s.[Address]
