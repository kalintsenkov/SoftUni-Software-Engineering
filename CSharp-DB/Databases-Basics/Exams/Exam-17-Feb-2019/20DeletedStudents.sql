CREATE TRIGGER tr_DeletedStudents ON Students FOR DELETE
AS
BEGIN
	INSERT INTO ExcludedStudents(StudentId, StudentName)
	     SELECT d.Id,
		    d.FirstName + ' ' + d.LastName
	       FROM deleted AS d
END
