   SELECT r.FirstName,
   	  r.LastName,
   	  r.Grade
     FROM (SELECT s.FirstName,
   		  s.LastName,
   		  ss.Grade,
   		  ROW_NUMBER() OVER (PARTITION BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) 
               AS [RowNum]
   	     FROM Students AS s
   	     JOIN StudentsSubjects AS ss
   	       ON ss.StudentId = s.Id) AS r
   WHERE r.RowNum = 2
ORDER BY r.FirstName, r.LastName
