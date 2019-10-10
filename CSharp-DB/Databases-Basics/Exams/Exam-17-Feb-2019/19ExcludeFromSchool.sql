CREATE OR ALTER PROC usp_ExcludeFromSchool(@studentId INT)
AS
BEGIN TRANSACTION
	IF (NOT EXISTS(
		SELECT * FROM Students AS s
		 WHERE s.Id = @studentId))
	BEGIN
		ROLLBACK
		RAISERROR('This school has no student with the provided id!', 16, 1)
		RETURN
	END

	DELETE FROM StudentsExams
	      WHERE StudentId = @studentId

	DELETE FROM StudentsSubjects
	      WHERE StudentId = @studentId

	DELETE FROM StudentsTeachers
	      WHERE StudentId = @studentId

	DELETE FROM Students
	      WHERE Id = @studentId
COMMIT