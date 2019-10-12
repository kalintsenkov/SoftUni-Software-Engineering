CREATE PROC usp_ChangeJourneyPurpose(@journeyId INT, @newPurpose VARCHAR(11))
AS
BEGIN TRANSACTION
	
	IF (NOT EXISTS(
		SELECT * FROM Journeys AS j
		WHERE j.Id = @journeyId))
	BEGIN
		ROLLBACK
		RAISERROR('The journey does not exist!', 16, 1)
		RETURN
	END

	DECLARE @oldPurpose VARCHAR(11);

	SET @oldPurpose = (SELECT j.Purpose
					     FROM Journeys AS j
						WHERE j.Id = @journeyId)

	IF (@oldPurpose = @newPurpose)
	BEGIN
		ROLLBACK
		RAISERROR('You cannot change the purpose!', 16, 2)
		RETURN
	END

	UPDATE Journeys
	   SET Purpose = @newPurpose
	 WHERE Id = @journeyId
COMMIT