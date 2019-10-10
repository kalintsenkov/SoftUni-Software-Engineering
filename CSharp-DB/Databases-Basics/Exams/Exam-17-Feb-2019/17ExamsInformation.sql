SELECT k.[Quarter], 
	   k.[SubjectName], 
	   COUNT(k.StudentId) AS [StudnetsCount]
  FROM (SELECT 
		  CASE
			   WHEN e.[Date] IS NULL THEN 'TBA'
			   ELSE CONCAT('Q', DATEPART(QUARTER, e.[Date]))
		END AS [Quarter],
			   sub.[Name] AS [SubjectName],
			   se.StudentId
		  FROM Exams AS e
		  JOIN Subjects AS sub
		    ON sub.Id = e.SubjectId
		  JOIN StudentsExams AS se
		    ON se.ExamId = e.Id
		 WHERE se.Grade >= 4) AS k
GROUP BY k.[Quarter], k.SubjectName
ORDER BY [Quarter]