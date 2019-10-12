CREATE FUNCTION udf_GetColonistsCount(@planetName VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @count INT;

	SET @count = (SELECT COUNT(tc.ColonistId)
			FROM TravelCards AS tc
	               WHERE tc.JourneyId IN (SELECT j.Id
					        FROM Journeys AS j
					        JOIN Spaceports AS sp
					          ON j.DestinationSpaceportId = sp.Id
					        JOIN Planets AS p
					          ON p.Id = sp.PlanetId
					       WHERE p.[Name] = @planetName));
	
	RETURN @count;
END
