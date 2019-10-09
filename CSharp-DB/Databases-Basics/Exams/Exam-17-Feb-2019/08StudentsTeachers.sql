  SELECT s.FirstName,
		 s.LastName,
		 COUNT(TeacherId) AS [TeachersCount]
    FROM StudentsTeachers AS st
    JOIN Students AS s
      ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName