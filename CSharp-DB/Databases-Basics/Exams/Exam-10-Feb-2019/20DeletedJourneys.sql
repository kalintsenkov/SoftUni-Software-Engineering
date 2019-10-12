CREATE TRIGGER tr_DeletedJourneys ON Journeys FOR DELETE
AS
BEGIN
	INSERT INTO DeletedJourneys
		    (Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
	     SELECT d.Id, d.JourneyStart, d.JourneyEnd, 
		    d.Purpose, d.DestinationSpaceportId, d.SpaceshipId
	       FROM deleted AS d
END
