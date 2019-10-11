CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @result VARCHAR(MAX);
	DECLARE @studentName VARCHAR(MAX);
	DECLARE @studentsCount INT;

	IF (@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!';
	END

 	SET @studentsCount = (SELECT COUNT(s.Id)
			        FROM Students AS s
	                       WHERE s.Id = @studentId)

        IF (@studentsCount = 0)
        BEGIN
        	RETURN 'The student with provided id does not exist in the school!';
        END

        SET @studentsCount = (SELECT COUNT(s.Id)
        			FROM Students AS s
        			JOIN StudentsExams AS se
        			  ON se.StudentId = s.Id
        		       WHERE se.Grade BETWEEN @grade AND @grade + 50 
        			 AND s.Id = @studentId)

        SET @studentName = (SELECT TOP(1) s.FirstName
        		      FROM Students AS s
			      JOIN StudentsExams AS se
			        ON se.StudentId = s.Id
			     WHERE se.Grade BETWEEN @grade 
			       AND @grade + 50 AND s.Id = @studentId)

        SET @result = 'You have to update ' + CAST(@studentsCount AS VARCHAR(MAX)) + ' grades for the student ' + @studentName;

        RETURN @result
END
