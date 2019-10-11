CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	DECLARE @projectsCount INT;

	SET @projectsCount = (SELECT COUNT(ep.EmployeeID)
				FROM EmployeesProjects AS ep
                               WHERE ep.EmployeeID = @emloyeeId)

	IF (@projectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	VALUES	    (@emloyeeId, @projectID)
COMMIT
