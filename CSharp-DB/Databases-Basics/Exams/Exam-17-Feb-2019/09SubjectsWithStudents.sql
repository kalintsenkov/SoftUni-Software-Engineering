  SELECT CONCAT(t.FirstName, ' ', t.LastName) AS [FullName],
		 CONCAT(s.[Name], '-', s.Lessons) AS [Subjects],
		 COUNT(st.StudentId) AS [Students]
    FROM Teachers AS t
    JOIN Subjects AS s
      ON s.Id = t.SubjectId
    JOIN StudentsTeachers AS st
      ON st.TeacherId = t.Id
GROUP BY t.FirstName,
		 t.LastName,
		 s.[Name],
		 s.Lessons
ORDER BY [Students] DESC,
		 [FullName],
		 [Subjects]