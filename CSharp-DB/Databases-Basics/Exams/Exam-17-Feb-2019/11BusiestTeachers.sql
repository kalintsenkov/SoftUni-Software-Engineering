  SELECT TOP(10) t.FirstName,
	 t.LastName,
	 COUNT(st.StudentId) AS [StudentsCount]
    FROM StudentsTeachers AS st
    JOIN Teachers AS t
      ON t.Id = st.TeacherId
GROUP BY t.FirstName, t.LastName
ORDER BY [StudentsCount] DESC,
	 t.FirstName,
	 t.LastName
