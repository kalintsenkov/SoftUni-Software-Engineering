  SELECT s.[Name],
	 AVG(ss.Grade) AS [AverageGrade]
    FROM StudentsSubjects AS ss
    JOIN Subjects AS s
      ON s.Id = ss.SubjectId
GROUP BY s.Id, s.[Name]
ORDER BY s.Id
