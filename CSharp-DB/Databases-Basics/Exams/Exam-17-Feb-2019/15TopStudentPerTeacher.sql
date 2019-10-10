  SELECT r.[Teacher Full Name],
  	     r.[Subject Name],
  	     r.[Student Full Name],
  	     CONVERT(DECIMAL(3, 2), r.AvgGrade) AS [Grade]
  	FROM (  SELECT CONCAT(t.FirstName, ' ', t.LastName) AS [Teacher Full Name],
  	               su.[Name] AS [Subject Name],
  	  		       CONCAT(s.FirstName, ' ', s.LastName) AS [Student Full Name],
  	  		       AVG(ss.Grade) AS [AvgGrade],
			       DENSE_RANK() OVER (PARTITION BY t.FirstName, t.LastName ORDER BY AVG(ss.Grade) DESC) AS [Rank]
  	          FROM Teachers AS t
  	      	  JOIN StudentsTeachers AS st
  	      	    ON st.TeacherId = t.Id
  	      	  JOIN Students AS s
  	      	    ON s.Id = st.StudentId
  	      	  JOIN StudentsSubjects AS ss
  	      	    ON ss.StudentId = s.Id
  	      	  JOIN Subjects AS su
  	      	    ON su.Id = t.SubjectId AND su.Id = ss.SubjectId
	      GROUP BY t.FirstName, t.LastName, su.[Name], s.FirstName, s.LastName) AS r
   WHERE r.[Rank] = 1
ORDER BY r.[Subject Name], r.[Teacher Full Name], Grade DESC