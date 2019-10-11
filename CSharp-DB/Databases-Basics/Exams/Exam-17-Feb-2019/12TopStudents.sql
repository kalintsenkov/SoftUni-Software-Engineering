  SELECT TOP(10) s.FirstName,
	 s.LastName,
	 CONVERT(DECIMAL(3, 2), AVG(se.Grade)) AS [Grade]
    FROM Students AS s
    JOIN StudentsExams AS se
      ON se.StudentId = s.Id
GROUP BY s.FirstName, 
	 s.LastName
ORDER BY [Grade] DESC,
	 s.FirstName,
	 s.LastName
